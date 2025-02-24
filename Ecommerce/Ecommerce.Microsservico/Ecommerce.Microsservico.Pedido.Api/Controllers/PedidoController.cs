using Ecommerce.Commons.Dtos;
using Ecommerce.Commons.Entities;
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
        private readonly IHttpService _httpService;

        public PedidoController(
                IPedidoService service,
                IHttpService httpService,
                IProdutoPedidoService produtoPedidoService)
        {
            _service = service;
            _produtoPedidoService = produtoPedidoService;
            _httpService = httpService;
        }

            /*
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var pedido = await _service.GetByIdAsync(id);

            if (pedido == null)
                return NotFound();

            return Ok(pedido);

        }
            */

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pedidos = await _service.GetAllAsync();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduto(int id)
        {
            // Exemplo de chamada ao endpoint "getUsuario" do microsserviço "usuario"
            var produto = await _httpService.GetAsync<Produto>("ProdutoService", $"/api/produtos/{id}");

            // Lógica para processar o pedido com as informações do usuário...
            return Ok(new { Pedido = "PedidoInfo", Produto = produto });
        }

        /*
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPedidoComUsuario(int id)
        {
            // Exemplo de chamada ao endpoint "getUsuario" do microsserviço "usuario"
            var usuario = await _httpService.GetAsync<Usuario>($"/api/usuarios/{id}");

            // Lógica para processar o pedido com as informações do usuário...
            return Ok(new { Pedido = "PedidoInfo", Usuario = usuario });
        }

        [HttpPost]
        public async Task<IActionResult> Add(PedidoDto pedidoDto, FormaPagamentoEnum formaPagamento)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))  
            {
                try
                {
                    var usuario = await _usuarioService.GetUsuarioByIdAsync(pedidoDto.IdUsuario);
                    long precoTotal = 0;

                    if (usuario == null)
                        return BadRequest("Usuário não encontrado");

                    if (!pedidoDto.ProdutoPedido.Any())
                        return BadRequest("Pedido sem produtos");

                    if (!pedidoDto.ProdutoPedido.Any(x => x.Quantidade_Produto == 0))
                        return BadRequest("Não é possivel adicionar um produto sem informar a quantidade");

                    var produtos = await _produtoService.GetListaProdutosByIdListAsync(pedidoDto.ProdutoPedido.Select(x => x.IdProduto).ToList());

                    foreach (var produto in produtos)
                    {
                        var produtoPedido = pedidoDto.ProdutoPedido.FirstOrDefault(x => x.IdProduto == produto.Id);
                        if (produto.QuantidadeEstoque < produtoPedido?.Quantidade_Produto)
                            return BadRequest($"A Quantidade solicitada de produto {produto.Nome} é maior do que a quantidade disponivel no estoque.");

                        precoTotal += (long)(produto.PrecoUnitario ?? 0 * (produtoPedido?.Quantidade_Produto ?? 0));
                    }

                    pedidoDto.StatusPedido = StatusPedidoEnum.SeparandoPedido;
                    pedidoDto.PrecoTotal = precoTotal;

                    await _service.AddAsync(pedidoDto);

                    foreach (var pedidoProdutoDto in pedidoDto.ProdutoPedido)
                    {
                        await _produtoPedidoService.AddAsync(pedidoProdutoDto);
                    }

                    if (await _pagamentoService.PagamentoExistsByIdPedido(pedidoDto.Id))
                        return BadRequest("Pagamento já cadastrado para este pedido");

                    await _pagamentoService.AddAsync(new PagamentoDto
                    {
                        IdPedido = pedidoDto.Id,
                        FormaPagamento = formaPagamento,
                        StatusPagamento = StatusPagamentoEnum.AguardandoPagamento
                    });

                    transaction.Complete();
                    return CreatedAtAction(nameof(Get), new { id = pedidoDto.Id }, pedidoDto);
                }
                catch (Exception)
                {
                    return StatusCode(500, "Ocorreu um erro ao processar o pedido");
                }
            }
        }
        */

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