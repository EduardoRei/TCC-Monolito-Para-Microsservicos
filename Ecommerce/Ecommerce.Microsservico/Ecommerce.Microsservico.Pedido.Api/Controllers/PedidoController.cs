using Ecommerce.Commons.Dtos;
using Ecommerce.Commons.Enums;
using Ecommerce.Microsservico.Pedido.Api.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using System.Transactions;

namespace Ecommerce.Microsservico.Pedido.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {

        private readonly IPedidoService _service;
        private readonly IProdutoPedidoService _produtoPedidoService;

        public PedidoController(
                IPedidoService service,
                IProdutoPedidoService produtoPedidoService)
        {
            _service = service;
            _produtoPedidoService = produtoPedidoService;
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

        /*

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduto(int id)
        {
            Produto produto = null;
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"http://produto-api:8080/api/Produto/{id}");
                if (response.IsSuccessStatusCode)
                {
                    produto = await response.Content.ReadFromJsonAsync<Produto>();
                    var ex = StatusCode((int)response.StatusCode, response.ReasonPhrase);
                }
            }
            return Ok(new { Pedido = "PedidoInfo", Produto = produto });
        }
        */

        [HttpPost]
        public async Task<IActionResult> Add(CreatePedidoDto createPedidoDto, FormaPagamentoEnum formaPagamento)
        {
            try
            {
                bool usuarioExists = await UsuarioExistsAsync(createPedidoDto.IdUsuario);
                if (!usuarioExists)
                    return BadRequest("Usuário não encontrado");

                if (!createPedidoDto.CreateProdutoPedido.Any())
                    return BadRequest("Pedido sem produtos");

                if (createPedidoDto.CreateProdutoPedido.Any(x => x.QuantidadeProduto == 0))
                    return BadRequest("Não é possivel adicionar um produto sem informar a quantidade");

                var produtos = await GetListaProdutosAsync(createPedidoDto.CreateProdutoPedido.Select(x => x.IdProduto).ToList());

                if (!produtos.Any())
                    return BadRequest("Nenhum produto foi encontrado.");

                var listaProdutoPedidoDto = createPedidoDto.CreateProdutoPedido
                .GroupBy(p => p.IdProduto)
                .Select(group => new ProdutoPedidoDto()
                {
                    IdProduto = group.Key,
                    QuantidadeProduto = group.Sum(p => p.QuantidadeProduto) 
                })
                .ToList();

                if (produtos.Count != listaProdutoPedidoDto.Count)
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
                    ProdutoPedido = listaProdutoPedidoDto,
                    PrecoTotal = precoTotal,
                    StatusPedido = StatusPedidoEnum.SeparandoPedido
                };

                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await _service.AddAsync(pedidoDto);

                    // Disparar mensagem para o microsserviço de pagamento para criar um pagamento com as informações nescessarias para esse pedio
                    // Disparar mensagem para o microsserviço de estoque para atualizar a quantidade de produtos no estoque

                    transaction.Complete();
                    return CreatedAtAction(nameof(Get), new { id = pedidoDto.Id }, pedidoDto);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Ocorreu um erro ao processar o pedido: " + e.StackTrace);
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

        private async Task<bool> UsuarioExistsAsync(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"http://usuario-api:8080/api/Usuario/{id}");
                return response.IsSuccessStatusCode;
            }
        }

        private async Task<List<ProdutoDto>> GetListaProdutosAsync(List<int> listaIds)
        {
            List<ProdutoDto> produtos = new List<ProdutoDto>();
            using (var httpClient = new HttpClient())
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(listaIds), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("http://produto-api:8080/api/Produto/getListProdutosByListIds", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var produtosRetornados = await response.Content.ReadFromJsonAsync<List<ProdutoDto>>();

                    if (produtosRetornados != null)
                    {
                        produtos.AddRange(produtosRetornados);
                    }
                }
            }
            return produtos;
        }
    }
}