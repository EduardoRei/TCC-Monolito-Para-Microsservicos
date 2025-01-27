using Ecommerce.Commons.Entities;
using Ecommerce.Commons.Enums;
using Ecommerce.Monolito.Core.Dtos;
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
        public async Task<IActionResult> Add(PedidoDto pedidoDto)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var usuario = await _usuarioService.GetUsuarioByIdAsync(pedidoDto.IdUsuario);
                    decimal precoTotal = 0;

                    if (usuario == null)
                        return BadRequest("Usuário não encontrado");

                    if (!pedidoDto.ProdutoPedido.Any())
                        return BadRequest("Pedido sem produtos");

                    if(!pedidoDto.ProdutoPedido.Any(x => x.Quantidade_Produto == 0))
                        return BadRequest("Não é possivel adicionar um produto sem informar a quantidade");

                    var produtos = await _produtoService.GetListaProdutosByIdListAsync(pedidoDto.ProdutoPedido.Select(x => x.IdProduto).ToList());

                    foreach (var produto in produtos)
                    {
                        var produtoPedido = pedidoDto.ProdutoPedido.FirstOrDefault(x => x.IdProduto == produto.Id);
                        if (produto.QuantidadeEstoque < produtoPedido?.Quantidade_Produto)
                        {
                            return BadRequest("Quantidade de produto insuficiente no estoque");
                        }
                        precoTotal += produto.PrecoUnitario * (decimal)(produtoPedido?.Quantidade_Produto ?? 0);
                    }

                    Pedido pedido = new Pedido
                    {
                        Id = 0,
                        IdUsuario = pedidoDto.IdUsuario,
                        IdPagamento = 0,
                        StatusPedido = StatusPedidoEnum.SeparandoPedido,
                        PrecoTotal = precoTotal
                    };

                    await _service.AddAsync(pedido);

                    foreach (var pedidoProdutoDto in pedidoDto.ProdutoPedido)
                    {
                        var produtoPedido = new ProdutoPedido
                        {
                            IdPedido = pedido.Id,
                            IdProduto = pedidoProdutoDto.IdProduto,
                            Quantidade_Produto = pedidoProdutoDto.Quantidade_Produto
                        };

                        await _produtoPedidoService.AddAsync(produtoPedido);
                    }

                    if (await _pagamentoService.PagamentoExistsByIdPedido(pedido.Id))
                        return BadRequest("Pagamento já cadastrado para este pedido");

                    await _pagamentoService.AddAsync(new Pagamento
                    {
                        Id = 0,
                        IdPedido = pedido.Id,
                        FormaPagamento = pedidoDto.FormaPagamento,
                        StatusPagamento = StatusPagamentoEnum.AguardandoPagamento
                    });

                    transaction.Complete();
                    return CreatedAtAction(nameof(Get), new { id = pedido.Id }, pedido);
                }
                catch (Exception)
                {
                    return StatusCode(500, "Ocorreu um erro ao processar o pedido");
                }
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Pedido pedido)
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
