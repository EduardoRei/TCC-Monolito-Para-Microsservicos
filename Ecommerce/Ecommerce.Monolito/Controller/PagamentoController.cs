using Ecommerce.Commons.Entities;
using Ecommerce.Monolito.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Monolito.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoService _service;

        public PagamentoController(IPagamentoService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var pagamento = await _service.GetByIdAsync(id);
            if (pagamento == null)
                return NotFound();

            return Ok(pagamento);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pagamentos = await _service.GetAllAsync();
            return Ok(pagamentos);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Pagamento pagamento)
        {
            await _service.AddAsync(pagamento);
            return CreatedAtAction(nameof(Get), new { id = pagamento.Id }, pagamento);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Pagamento pagamento)
        {
            await _service.UpdateAsync(pagamento);
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
