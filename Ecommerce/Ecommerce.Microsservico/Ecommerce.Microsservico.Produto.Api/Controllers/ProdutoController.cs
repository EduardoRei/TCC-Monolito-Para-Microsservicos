using Ecommerce.Commons.Dtos;
using Ecommerce.Commons.Enums;
using Ecommerce.Commons.RabbitMq.Producer;
using Ecommerce.Commons.Util;
using Ecommerce.Microsservico.Produto.Api.Core.Entities;
using Ecommerce.Microsservico.Produto.Api.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Microsservico.Produto.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly ICategoriaService _categoriaService;
        private readonly IMessageProducer _producer;

        public ProdutoController(IProdutoService productService,
                                 ICategoriaService categoriaService,
                                 IMessageProducer producer)
        {
            _produtoService = productService;
            _categoriaService = categoriaService;
            _producer = producer;
        }

        [HttpGet("{id}", Name = "GetProdutoById")]
        public async Task<ActionResult<ProdutoDto>> GetProdutoById(int id)
        {
            var produto = await _produtoService.GetProdutoByIdAsync(id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpGet(Name = "GetAllProdutos")]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetAllProdutos()
        {
            var produtos = await _produtoService.GetAllProdutosAsync();

            return Ok(produtos);
        }

        [HttpPost("getListProdutosByListIds", Name = "GetListProdutoByIds")]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetListProdutosByListIds([FromBody] List<int> listaIds)
        {
            if (listaIds == null || !listaIds.Any())
                return BadRequest("A lista de IDs não pode ser vazia.");

            var produtos = await _produtoService.GetListaProdutosByIdListAsync(listaIds);

            if (produtos == null || !produtos.Any())
                return NotFound("Nenhum produto encontrado para os IDs fornecidos.");

            return Ok(produtos);
        }

        [HttpGet("quantidade/{id}", Name = "GetQuantidadeProduto")]
        public async Task<ActionResult<int>> GetQuantidadeProduto(int id)
        {
            var quantidade = await _produtoService.GetQuantidadeProdutoByIdAsync(id);
            return Ok(quantidade);
        }

        [HttpDelete("{id}", Name = "DeleteProduto")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            await _produtoService.DeleteProdutoByIdAsync(id);
            return NoContent();
        }

        [HttpPost(Name = "AddProduto")]
        public async Task<ActionResult> AddProduto(ProdutoCreateDto produtoDto)
        {
            if (string.IsNullOrWhiteSpace(produtoDto.Nome) || NomeContemPalavraProibidaUtil.NomeContemPalavraProibida(produtoDto.Nome))
                return BadRequest("Nome é obrigatório.");

            if (produtoDto.PrecoUnitario <= 0)
                return BadRequest("PrecoUnitario é obrigatório.");

            if (produtoDto.QuantidadeEstoque <= 0)
                return BadRequest("QuantidadeEstoque é obrigatório.");

            if (produtoDto.IdCategoria <= 0)
                return BadRequest("IdCategoria é obrigatório.");

            if (!await _categoriaService.ExisteCategoriaAsync(produtoDto.IdCategoria))
                return BadRequest("Categoria informada não existe.");

            if (!await _produtoService.ExisteProdutoAsync(produtoDto.Nome, produtoDto.IdCategoria))
                return BadRequest("Ja existe este produto.");

            var produto = new ProdutoDto
            {
                Nome = produtoDto.Nome,
                Descricao = produtoDto.Descricao,
                PrecoUnitario = produtoDto.PrecoUnitario,
                QuantidadeEstoque = produtoDto.QuantidadeEstoque,
                IdCategoria = produtoDto.IdCategoria
            };

            await _produtoService.AddProdutoAsync(produto);

            return CreatedAtAction(nameof(GetProdutoById), new { id = produto.Id }, produto);
        }

        [HttpPut( Name = "UpdateProduto")]
        public async Task<IActionResult> UpdateProduto(ProdutoDto produtoDto)
        {
            if (produtoDto.Id <= 0)
                return BadRequest("Id não encontrado.");

            var produto = await _produtoService.GetProdutoByIdAsync(produtoDto.Id);
            if (produto == null)
                return NotFound($"Nenhum produto foi encontrado com o id: {produtoDto.Id}");

            if (produtoDto.QuantidadeEstoque.HasValue && produtoDto.QuantidadeEstoque > 0)
                produto.QuantidadeEstoque = produtoDto.QuantidadeEstoque.Value;

            if (produtoDto.IdCategoria.HasValue && produtoDto.IdCategoria > 0)
                produto.IdCategoria = produtoDto.IdCategoria.Value;

            if (produtoDto.PrecoUnitario.HasValue && produtoDto.PrecoUnitario > 0)
                produto.PrecoUnitario = produtoDto.PrecoUnitario.Value;

            if (!string.IsNullOrWhiteSpace(produtoDto.Nome)
                && !NomeContemPalavraProibidaUtil.NomeContemPalavraProibida(produtoDto.Nome))
                produto.Nome = produtoDto.Nome;

            await _produtoService.UpdateProdutoAsync(produto);

            return NoContent();
        }

        [HttpPut("UpdateQuantidadeEstoqueProduto", Name = "UpdateQuantidadeEstoqueProduto")]
        public async Task<IActionResult> UpdateQuantidadeEstoqueProduto(ProdutoAtualizarDto produtoAtualizar)
        {
            if (produtoAtualizar.IdProduto <= 0)
                return BadRequest("Id não encontrado.");

            if (produtoAtualizar.QuantidadeVendida <= 0)
                return BadRequest("QuantidadeVendida deve ser maior que 0.");

            var produto = await _produtoService.GetProdutoByIdAsync(produtoAtualizar.IdProduto);
            if (produto == null)
                return NotFound($"Nenhum produto foi encontrado com o id: {produtoAtualizar.IdProduto}");

            await _produtoService.RemoverQuantidadeProdutoAsync(produtoAtualizar.IdProduto, produtoAtualizar.QuantidadeVendida);

            var mensagemProduto = new MensagemProdutoAlterado(produtoAtualizar.IdProduto, AlteracaoProdutoEnum.QuantidadeAlterada);
            await _producer.SendMessage(mensagemProduto, RabbitMqQueueEnum.ProdutoQueue, RabbitMqRoutingKeyEnum.ProdutoModificado);

            return NoContent();
        }
    }
}
