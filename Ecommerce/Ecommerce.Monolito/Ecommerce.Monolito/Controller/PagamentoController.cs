using Ecommerce.Commons.Dtos;
using Ecommerce.Commons.Enums;
using Ecommerce.Monolito.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace Ecommerce.Monolito.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoService _service;
        private readonly IPedidoService _pedidoService;

        public PagamentoController(IPagamentoService service, IPedidoService pedidoService)
        {
            _service = service;
            _pedidoService = pedidoService;
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
        public async Task<IActionResult> Add(PagamentoDto pagamento)
        {
            await _service.AddAsync(pagamento);
            return CreatedAtAction(nameof(Get), new { id = pagamento.Id }, pagamento);
        }

        [HttpPut]
        public async Task<IActionResult> Update(PagamentoDto pagamento)
        {
            await _service.UpdateAsync(pagamento);
            return NoContent();
        }

        [HttpPut("AlterarFormaPagamento")]
        public async Task<IActionResult> UpdateFormaPagamento(int id, FormaPagamentoEnum formaPagamento)
        {
            var pagamento = await _service.GetByIdAsync(id);
            if (pagamento == null)
                return NotFound($"Não foi possivel alterar a forma de pagamento do Id {id}, Id não encontrado.");

            await _service.UpdateAsync(pagamento);
            return NoContent();
        }

        [HttpPut("RealizarPagamento")]
        public async Task<IActionResult> UpdateRealizarPagamento(int id, StatusPagamentoEnum statusPagamento)
        {
            var pagamento = await _service.GetByIdAsync(id);
            if (pagamento == null)
                return NotFound($"Não foi possivel alterar a forma de pagamento do Id {id}, Id não encontrado.");

            pagamento.StatusPagamento = statusPagamento;
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await _service.UpdateAsync(pagamento);
                var statusPedido = StatusPedidoEnum.PedidoCancelado;
                if (statusPagamento == StatusPagamentoEnum.ProcessandoPagamento || 
                    statusPagamento == StatusPagamentoEnum.PagamentoIdentificado)
                    statusPedido = StatusPedidoEnum.SeparandoPedido;

                await _pedidoService.UpdatePedidoStatusAsync(pagamento.IdPedido, statusPedido);
            }

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
