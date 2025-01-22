using Ecommerce.Migrations.Entities;
using Ecommerce.Monolito.Core.Dtos;
using Ecommerce.Monolito.Core.Interface;
using Ecommerce.Monolito.Util;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Monolito.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService productService)
        {
            _produtoService = productService;
        }


        [HttpGet("{id}", Name = "GetProdutoById")]
        public async Task<ActionResult<ProdutoDto>> GetProdutoById(int id)
        {
            var produto = await _produtoService.GetProdutoByIdAsync(id);
            if (produto == null || produto.Equals(new Produto()))
            {
                return NotFound();
            }

            return Ok(produto);
        }


        [HttpGet(Name = "GetAllProdutos")]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetAllProdutos()
        {
            var produtos = await _produtoService.GetAllProdutosAsync();

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
        public async Task<ActionResult> AddProduto(ProdutoDto produtoDto)
        {
            if (string.IsNullOrWhiteSpace(produtoDto.Nome) || NomeContemPalavraProibidaUtil.NomeContemPalavraProibida(produtoDto.Nome))
                return BadRequest("Nome é obrigatório");

            if (!produtoDto.PrecoUnitario.HasValue || produtoDto.PrecoUnitario <= 0)
                return BadRequest("PrecoUnitario é obrigatório");

            if (!produtoDto.QuantidadeEstoque.HasValue)
                return BadRequest("QuantidadeEstoque é obrigatório");

            if (!produtoDto.IdCategoria.HasValue || produtoDto.IdCategoria <= 0)
                return BadRequest("IdCategoria é obrigatório");

            if (await _produtoService.ExisteProdutoAsync(produtoDto.Nome, produtoDto.IdCategoria))
                return BadRequest("Ja existe este produto");

            var produto = new Produto
            {
                Nome = produtoDto.Nome,
                PrecoUnitario = produtoDto.PrecoUnitario.Value,
                QuantidadeEstoque = produtoDto.QuantidadeEstoque.Value,
                IdCategoria = produtoDto.IdCategoria.Value
            };

            await _produtoService.AddProdutoAsync(produto);

            return CreatedAtAction(nameof(GetProdutoById), new { id = produto.Id }, produtoDto);
        }


        [HttpPut("{id}", Name = "UpdateProduto")]
        public async Task<IActionResult> UpdateProduto(int id, ProdutoDto produtoDto)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var produto = await _produtoService.GetProdutoByIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            if (produtoDto.QuantidadeEstoque.HasValue && produtoDto.QuantidadeEstoque > 0)
                produto.QuantidadeEstoque = produtoDto.QuantidadeEstoque.Value;

            if (produtoDto.IdCategoria.HasValue && produtoDto.IdCategoria > 0)
                produto.IdCategoria = produtoDto.IdCategoria.Value;

            if (produtoDto.PrecoUnitario.HasValue && produtoDto.PrecoUnitario > 0)
                produto.PrecoUnitario = produtoDto.PrecoUnitario.Value;

            if (!string.IsNullOrWhiteSpace(produtoDto.Nome) && !NomeContemPalavraProibidaUtil.NomeContemPalavraProibida(produtoDto.Nome))
                produto.Nome = produtoDto.Nome;

            await _produtoService.UpdateProdutoAsync(produto);

            return NoContent();
        }
    }
}
