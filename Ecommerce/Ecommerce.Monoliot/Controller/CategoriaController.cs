using Ecommerce.Migrations.Entities;
using Ecommerce.Monolito.Core.Dtos;
using Ecommerce.Monolito.Core.Interface;
using Ecommerce.Monolito.Util;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Monolito.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet("{id}", Name = "GetCategoriaById")]
        public async Task<ActionResult<CategoriaDto>> GetCategoriaById(int id)
        {
            var categoria = await _categoriaService.GetCategoriaByIdAsync(id);
            if (categoria == null || categoria.Equals(new Categoria()))
            {
                return NotFound();
            }

            return Ok(categoria);
        }


        [HttpGet(Name = "GetAllCategorias")]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> GetAllCategorias()
        {
            var categorias = await _categoriaService.GetAllCategoriasAsync();

            return Ok(categorias);
        }


        [HttpDelete("{id}", Name = "DeleteCategoria")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            await _categoriaService.DeleteCategoriaByIdAsync(id);
            return NoContent();
        }



        [HttpPost(Name = "AddCategoria")]
        public async Task<ActionResult> AddCategoria(CategoriaDto categoriaDto)
        {
            if (string.IsNullOrWhiteSpace(categoriaDto.Nome) || NomeContemPalavraProibidaUtil.NomeContemPalavraProibida(categoriaDto.Nome))
                return BadRequest("Nome é obrigatório");

            var existe = await _categoriaService.ExisteCategoriaAsync(categoriaDto.Nome);

            if (existe)
                return BadRequest("Ja existe este categoria");

            var categoria = new Categoria
            {
                Nome = categoriaDto.Nome,
            };

            await _categoriaService.AddCategoriaAsync(categoria);

            return CreatedAtAction(nameof(GetCategoriaById), new { id = categoria.Id }, categoriaDto);
        }


        [HttpPut("{id}", Name = "UpdateCategoria")]
        public async Task<IActionResult> UpdateCategoria(int id, CategoriaDto categoriaDto)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var categoria = await _categoriaService.GetCategoriaByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            if (string.IsNullOrWhiteSpace(categoriaDto.Nome) || NomeContemPalavraProibidaUtil.NomeContemPalavraProibida(categoriaDto.Nome))
                    return BadRequest("Nome invalido");

            if (await _categoriaService.ExisteCategoriaAsync(categoriaDto.Nome))
                return BadRequest("O Nome desta categoria ja esta cadastrado");

            categoria.Nome = categoriaDto.Nome;
            await _categoriaService.UpdateCategoriaAsync(categoria);

            return NoContent();
        }

    }
}
