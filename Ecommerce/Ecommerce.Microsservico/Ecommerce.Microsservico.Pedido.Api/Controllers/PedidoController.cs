using Ecommerce.Commons.Dtos;
using Ecommerce.Commons.Enums;
using Ecommerce.Commons.RabbitMq.Producer;
using Ecommerce.Microsservico.Pedido.Api.Core.Entities;
using Ecommerce.Microsservico.Pedido.Api.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Microsservico.Pedido.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {

        private readonly IPedidoService _service;
        private readonly IProdutoPedidoService _produtoPedidoService;
        private readonly IProdutoService _produtoService;
        private readonly IUsuarioService _usuarioService;
        private readonly IMessageProducer _producer;

        private const string UsuarioApiUrl = "http://kong:8000/usuario/api/Usuario/";
        private const string ProdutoApiUrl = "http://kong:8000/produto/api/Produto/";

        public PedidoController(
                IPedidoService service,
                IMessageProducer producer,
                IUsuarioService usuarioService,
                IProdutoService produtoService,
                IProdutoPedidoService produtoPedidoService)
        {
            _service = service;
            _produtoPedidoService = produtoPedidoService;
            _producer = producer;
            _usuarioService = usuarioService;
            _produtoService = produtoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var pedido = await _service.GetByIdAsync(id);

            if (pedido == null)
                return NotFound();

            return Ok(pedido);

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pedidos = await _service.GetAllAsync();
            return Ok(pedidos);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreatePedidoDto createPedidoDto)
        {
            try
            {
                if (createPedidoDto.CreateProdutoPedido.Count == 0)
                    return BadRequest("Pedido sem produtos");

                if (createPedidoDto.CreateProdutoPedido.Any(x => x.QuantidadeProduto <= 0))
                    return BadRequest("Quantidade de produto inválida");

                var produtosAgrupados = createPedidoDto.CreateProdutoPedido
                    .GroupBy(p => p.IdProduto)
                    .Select(group => new
                    {
                        IdProduto = group.Key,
                        QuantidadeTotal = group.Sum(p => p.QuantidadeProduto)
                    })
                    .ToList();

                var usuarioTask = _usuarioService.UsuarioExistsAsync(createPedidoDto.IdUsuario);
                var produtosTask = _produtoService.GetListaProdutosAsync(produtosAgrupados.Select(x => x.IdProduto).ToList());

                await Task.WhenAll(usuarioTask, produtosTask);

                if (!usuarioTask.Result)
                    return BadRequest("Usuário não encontrado");

                var produtos = produtosTask.Result;
                if (produtos.Count == 0)
                    return BadRequest("Nenhum produto foi encontrado.");

                var produtosDict = produtos.ToDictionary(p => p.Id);
                if (produtos.Count != produtosAgrupados.Count)
                    return BadRequest("Nem todos os produtos foram encontrados");

                double precoTotal = 0;
                var listaProdutoPedidoDto = new List<ProdutoPedidoDto>();

                foreach (var produtoAgrupado in produtosAgrupados)
                {
                    if (!produtosDict.TryGetValue(produtoAgrupado.IdProduto, out var produto))
                        return BadRequest($"Produto {produtoAgrupado.IdProduto} não encontrado.");

                    if (produto.QuantidadeEstoque < produtoAgrupado.QuantidadeTotal)
                        return BadRequest($"Estoque insuficiente para {produto.Nome}");

                    precoTotal += (produto.PrecoUnitario ?? 0) * produtoAgrupado.QuantidadeTotal;

                    listaProdutoPedidoDto.Add(new ProdutoPedidoDto
                    {
                        IdProduto = produtoAgrupado.IdProduto,
                        QuantidadeProduto = produtoAgrupado.QuantidadeTotal
                    });
                }

                var pedidoDto = new PedidoDto()
                {
                    IdUsuario = createPedidoDto.IdUsuario,
                    ProdutoPedido = listaProdutoPedidoDto,
                    PrecoTotal = precoTotal,
                    StatusPedido = StatusPedidoEnum.AguardandoPagamento
                };

                var mensagens = listaProdutoPedidoDto
                    .Select(p => new MensagemPedidoCriadoProduto(p.IdProduto, p.QuantidadeProduto))
                    .ToList();

                var addTask = _service.AddAsync(pedidoDto, mensagens);
                var sendMessageTask = _producer.SendMessage(
                    new MensagemPedidoCriadoPagamento(pedidoDto.Id, createPedidoDto.FormaPagamento),
                    RabbitMqQueueEnum.PedidoQueue,
                    RabbitMqRoutingKeyEnum.PedidoPagamento);

                await Task.WhenAll(addTask, sendMessageTask);

                pedidoDto.ProdutoPedido.ForEach(p => p.IdPedido = pedidoDto.Id);

                return CreatedAtAction(nameof(Get), new { id = pedidoDto.Id }, pedidoDto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao processar o pedido");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(PedidoDto pedidoDto)
        {
            var pedido = await _service.GetByIdAsync(pedidoDto.Id);
            if (pedido == null)
                return BadRequest("Pedido não encontrado");

            if(pedidoDto.StatusPedido.HasValue && pedidoDto.StatusPedido != 0)
                pedido.StatusPedido = pedidoDto.StatusPedido;
            
            if(pedidoDto.IdPagamento.HasValue && pedidoDto.IdPagamento != 0)
                pedido.IdPagamento = pedidoDto.IdPagamento;
            
            if (pedidoDto.PrecoTotal.HasValue && pedidoDto.PrecoTotal != 0)
                pedido.PrecoTotal = pedido.PrecoTotal;

            await _service.UpdateAsync(pedido);
            return NoContent();
        }

        [HttpPut("AtualizarIdPagamento", Name = "AtualizarIdPagamento")]
        public async Task<IActionResult> UpdateIdPagamento(AtualizarIdPagamentoDto atualizarPedido)
        {
            var pedido = await _service.GetByIdAsync(atualizarPedido.IdPedido);
            if (pedido == null)
                return BadRequest("Pedido não encontrado");

            pedido.IdPagamento = atualizarPedido.IdPagamento;
            await _service.UpdateAsync(pedido);
            return NoContent();
        }

        [HttpPut("AtualizarStatusPedido", Name = "AtualizarStatusPagamento")]
        public async Task<IActionResult> UpdateStatusPagamento(AtualizarPagamentoDto atualizarPedido)
        {
            var statusPedido = atualizarPedido.StatusPagamento == StatusPagamentoEnum.PagamentoIdentificado ||
                                atualizarPedido.StatusPagamento == StatusPagamentoEnum.ProcessandoPagamento ? StatusPedidoEnum.SeparandoPedido : StatusPedidoEnum.PedidoCancelado;

            var pedido = await _service.GetByIdAsync(atualizarPedido.IdPedido);
            if (pedido == null)
                return BadRequest("Pedido não encontrado");

            pedido.StatusPedido = statusPedido;
            await _service.UpdateAsync(pedido);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}