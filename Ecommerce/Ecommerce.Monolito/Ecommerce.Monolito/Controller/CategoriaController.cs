using Ecommerce.Commons.Dtos;
using Ecommerce.Monolito.Core.Interface;
using Ecommerce.Commons.Util;
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
            if (categoria == null)
                return NotFound("Categoria informada não encontrada.");

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

            var existe = await _categoriaService.ExisteNomeCategoriaAsync(categoriaDto.Nome);

            if (existe)
                return BadRequest("Ja existe este categoria");

            await _categoriaService.AddCategoriaAsync(categoriaDto);

            return CreatedAtAction(nameof(GetCategoriaById), new { id = categoriaDto.Id }, categoriaDto);
        }

        [HttpPut( Name = "UpdateCategoria")]
        public async Task<IActionResult> UpdateCategoria(CategoriaDto categoriaDto)
        {
            if (categoriaDto.Id <= 0)
            {
                return BadRequest();
            }

            var categoria = await _categoriaService.GetCategoriaByIdAsync(categoriaDto.Id);
            if (categoria == null)
            {
                return NotFound();
            }

            if (string.IsNullOrWhiteSpace(categoriaDto.Nome) || NomeContemPalavraProibidaUtil.NomeContemPalavraProibida(categoriaDto.Nome))
                return BadRequest("Nome invalido");

            if (await _categoriaService.ExisteNomeCategoriaAsync(categoriaDto.Nome))
                return BadRequest("O Nome desta categoria ja esta cadastrado");

            await _categoriaService.UpdateCategoriaAsync(categoriaDto);

            return NoContent();
        }
    }
}
