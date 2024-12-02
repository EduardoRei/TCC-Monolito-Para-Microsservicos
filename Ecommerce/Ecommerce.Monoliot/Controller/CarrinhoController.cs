using Ecommerce.Migrations.Entities;
using Ecommerce.Monolito.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Monolito.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrinhoController : ControllerBase
    {
        private readonly ICarrinhoService _service;

        public CarrinhoController(ICarrinhoService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var carrinho = await _service.GetByIdAsync(id);
            if (carrinho == null)
                return NotFound();

            return Ok(carrinho);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var carrinhos = await _service.GetAllAsync();
            return Ok(carrinhos);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Carrinho carrinho)
        {
            await _service.AddAsync(carrinho);
            return CreatedAtAction(nameof(Get), new { id = carrinho.Id }, carrinho);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Carrinho carrinho)
        {
            await _service.UpdateAsync(carrinho);
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
