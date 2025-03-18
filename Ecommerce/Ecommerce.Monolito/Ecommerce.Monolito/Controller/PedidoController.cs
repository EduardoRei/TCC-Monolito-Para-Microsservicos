using Ecommerce.Commons.Dtos;
using Ecommerce.Commons.Enums;
using Ecommerce.Monolito.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace Ecommerce.Monolito.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _service;
        private readonly IUsuarioService _usuarioService;
        private readonly IProdutoService _produtoService;
        private readonly IProdutoPedidoService _produtoPedidoService;
        private readonly IPagamentoService _pagamentoService;

        public PedidoController(
                IPedidoService service,
                IUsuarioService usuarioService,
                IPagamentoService pagamentoService,
                IProdutoService produtoService,
                IProdutoPedidoService produtoPedidoService)
        {
            _service = service;
            _usuarioService = usuarioService;
            _produtoService = produtoService;
            _produtoPedidoService = produtoPedidoService;
            _pagamentoService = pagamentoService;
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
        public async Task<IActionResult> Add(CreatePedidoDto createPedidoDto, FormaPagamentoEnum formaPagamento)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var usuario = await _usuarioService.GetUsuarioByIdAsync(createPedidoDto.IdUsuario);

                    if (usuario == null)
                        return BadRequest("Usuário não encontrado");

                    if (!createPedidoDto.CreateProdutoPedido.Any())
                        return BadRequest("Pedido sem produtos");

                    if(createPedidoDto.CreateProdutoPedido.Any(x => x.QuantidadeProduto == 0))
                        return BadRequest("Não é possivel adicionar um produto sem informar a quantidade");

                    var produtos = await _produtoService.GetListaProdutosByIdListAsync(createPedidoDto.CreateProdutoPedido.Select(x => x.IdProduto).ToList());

                    if (produtos.Count == 0)
                        return BadRequest("Nenhum produto foi encontrado.");

                    if (produtos.Count != createPedidoDto.CreateProdutoPedido.Count)
                        return BadRequest("Nem todos os produtos foram encontrados.");

                    double precoTotal = 0;
                    foreach (var produto in produtos)
                    {
                        var produtoPedido = createPedidoDto.CreateProdutoPedido.FirstOrDefault(x => x.IdProduto == produto.Id);
                        if (produto.QuantidadeEstoque < produtoPedido?.QuantidadeProduto)
                            return BadRequest($"A Quantidade solicitada de produto {produto.Nome} é maior do que a quantidade disponivel no estoque.");

                        precoTotal += produto.PrecoUnitario ?? 0 * (produtoPedido?.QuantidadeProduto ?? 0);
                    }

                    var pedidoDto = new PedidoDto()
                    {
                        IdUsuario = createPedidoDto.IdUsuario,
                        ProdutoPedido = createPedidoDto.CreateProdutoPedido.Select(p => new ProdutoPedidoDto()
                        {
                            IdProduto = p.IdProduto,
                            QuantidadeProduto = p.QuantidadeProduto
                        }).ToList(),
                        PrecoTotal = precoTotal,
                        StatusPedido = StatusPedidoEnum.SeparandoPedido
                    };

                    await _service.AddAsync(pedidoDto);

                    await _pagamentoService.AddAsync(new PagamentoDto
                    {
                        IdPedido = pedidoDto.Id,
                        FormaPagamento = formaPagamento,
                        StatusPagamento = StatusPagamentoEnum.AguardandoPagamento
                    });

                    transaction.Complete();
                    return CreatedAtAction(nameof(Get), new { id = pedidoDto.Id }, pedidoDto);
                }
                catch (Exception e)
                {
                    return StatusCode(500, "Ocorreu um erro ao processar o pedido" + e.StackTrace);
                }
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(PedidoDto pedido)
        {
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
