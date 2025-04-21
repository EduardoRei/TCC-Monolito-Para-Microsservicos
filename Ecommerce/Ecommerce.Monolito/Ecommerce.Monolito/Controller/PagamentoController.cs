using Ecommerce.Commons.Dtos;
using Ecommerce.Commons.Enums;
using Ecommerce.Monolito.Core.Enity;
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
        public async Task<IActionResult> Add(PagamentoCreateDto pagamentoDto)
        {
            if (pagamentoDto == null)
                return BadRequest();

            if (pagamentoDto.IdPedido == 0)
                return BadRequest("IdPedido não informado.");

            var pagamento = new PagamentoDto
            {
                IdPedido = pagamentoDto.IdPedido,
                FormaPagamento = pagamentoDto.FormaPagamento,
                StatusPagamento = StatusPagamentoEnum.AguardandoPagamento
            };

            await _service.AddAsync(pagamento);
            return CreatedAtAction(nameof(Get), new { id = pagamento.Id }, pagamento);
        }

        [HttpPut]
        public async Task<IActionResult> Update(PagamentoUpdateDto updatePagamento)
        {
            if (updatePagamento.Id == 0)
                return BadRequest("Id não informado.");

            var pagamento = await _service.GetByIdAsync(updatePagamento.Id);

            if (pagamento == null)
                return NotFound($"Não foi possivel alterar o pagamento do Id {updatePagamento.Id}, Id não encontrado.");

            if (updatePagamento.IdPedido != 0 && updatePagamento.IdPedido.HasValue)
            {
                if (await _pedidoService.GetByIdAsync(updatePagamento.IdPedido.Value) == null)
                    return NotFound($"Não foi possivel alterar o pagamento do Id {updatePagamento.Id}, Pedido não encontrado.");

                pagamento.IdPedido = (int)updatePagamento?.IdPedido;
            }

            if (updatePagamento.StatusPagamento != null && updatePagamento.StatusPagamento.HasValue)
                pagamento.StatusPagamento = updatePagamento.StatusPagamento.Value;

            if (updatePagamento.FormaPagamento != null && updatePagamento.FormaPagamento.HasValue)
                pagamento.FormaPagamento = updatePagamento.FormaPagamento.Value;

            if (updatePagamento.DataPagamento != null && updatePagamento.FormaPagamento.HasValue)
                pagamento.DataPagamento = updatePagamento.DataPagamento.Value;

            await _service.UpdateAsync(pagamento);
            return NoContent();
        }

        [HttpPut("AlterarFormaPagamento")]
        public async Task<IActionResult> UpdateFormaPagamento(UpdateFormaPagamentoDto updateForma)
        {
            var pagamento = await _service.GetByIdAsync(updateForma.Id);
            if (pagamento == null)
                return NotFound($"Não foi possivel alterar a forma de pagamento do Id {updateForma.Id}, Id não encontrado.");

            pagamento.FormaPagamento = updateForma.FormaPagamento;

            await _service.UpdateAsync(pagamento);
            return NoContent();
        }

        [HttpPut("RealizarPagamento")]
        public async Task<IActionResult> UpdateRealizarPagamento(RealizarPagamentoDto realizarPagamento)
        {
            var pagamento = await _service.GetByIdAsync(realizarPagamento.Id);
            if (pagamento == null)
                return NotFound($"Não foi possivel alterar a forma de pagamento do Id {realizarPagamento.Id}, Id não encontrado.");

            pagamento.StatusPagamento = realizarPagamento.StatusPagamento;
            pagamento.DataPagamento = DateTime.Now;
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await _service.UpdateAsync(pagamento);
                var statusPedido = StatusPedidoEnum.PedidoCancelado;
                if (realizarPagamento.StatusPagamento == StatusPagamentoEnum.ProcessandoPagamento ||
                    realizarPagamento.StatusPagamento == StatusPagamentoEnum.PagamentoIdentificado)
                    statusPedido = StatusPedidoEnum.SeparandoPedido;

                await _pedidoService.UpdatePedidoStatusAsync(pagamento.IdPedido, statusPedido);
                transaction.Complete();
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
