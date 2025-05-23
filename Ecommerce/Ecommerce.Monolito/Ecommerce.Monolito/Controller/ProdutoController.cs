﻿using Ecommerce.Commons.Dtos;
using Ecommerce.Monolito.Core.Interface;
using Ecommerce.Commons.Util;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Monolito.Core.Enity;

namespace Ecommerce.Monolito.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly ICategoriaService _categoriaService;

        public ProdutoController(IProdutoService productService, ICategoriaService categoriaService)
        {
            _produtoService = productService;
            _categoriaService = categoriaService;
        }

        [HttpGet("{id}", Name = "GetProdutoById")]
        public async Task<ActionResult<ProdutoDto>> GetProdutoById(int id)
        {
            var produto = await _produtoService.GetProdutoByIdAsync(id);
            if (produto == null)
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

            if (await _produtoService.ExisteProdutoAsync(produtoDto.Nome, produtoDto.IdCategoria))
                return BadRequest("Ja existe este produto.");

            var produto = new ProdutoDto
            {
                IdCategoria = produtoDto.IdCategoria,
                Nome = produtoDto.Nome,
                Descricao = produtoDto.Descricao,
                QuantidadeEstoque = produtoDto.QuantidadeEstoque,
                PrecoUnitario = produtoDto.PrecoUnitario
            };

            await _produtoService.AddProdutoAsync(produto);

            return CreatedAtAction(nameof(GetProdutoById), new { id = produto.Id }, produto);
        }

        [HttpPut( Name = "UpdateProduto")]
        public async Task<IActionResult> UpdateProduto(ProdutoDto produtoDto)
        {
            if (produtoDto.Id <= 0)
            {
                return BadRequest("Id não encontrado.");
            }

            var produto = await _produtoService.GetProdutoByIdAsync(produtoDto.Id);
            if (produto == null)
            {
                return NotFound($"Nenhum produto foi encontrado com o id: {produtoDto.Id}");
            }

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
    }
}
