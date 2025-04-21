using Ecommerce.Commons.Dtos;
using Ecommerce.Commons.Enums;
using Ecommerce.Commons.RabbitMq.Producer;
using Ecommerce.Microsservico.Pagamento.Api.Core.Entities;
using Ecommerce.Microsservico.Pagamento.Api.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Microsservico.Pagamento.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoService _service;
        private readonly IMessageProducer _producer;

        public PagamentoController(IPagamentoService service,
                                   IMessageProducer producer )
        {
            _service = service;
            _producer = producer;
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
        public async Task<IActionResult> Add(CreatePagamentoDto createPagamento)
        {
            if(createPagamento.IdPedido == 0)
                return BadRequest("IdPedido é obrigatório.");

            var pagamento = new PagamentoDto() { IdPedido = createPagamento.IdPedido, FormaPagamento = createPagamento.FormaPagamento};
            await _service.AddAsync(pagamento);
            var mensagemPagamento = new MensagemPagamentoCriado(pagamento.IdPedido, pagamento.Id);
            await _producer.SendMessage(mensagemPagamento, RabbitMqQueueEnum.PagamentoQueue, RabbitMqRoutingKeyEnum.PagamentoPedidoCriado);
            return CreatedAtAction(nameof(Get), new { id = pagamento.Id }, pagamento);
        }

        [HttpPut]
        public async Task<IActionResult> Update(PagamentoDto pagamentoDto)
        {
            var pagamento = await _service.GetByIdAsync(pagamentoDto.Id);
            if (pagamento == null)
                return NotFound($"Não foi possivel alterar a forma de pagamento do Id {pagamentoDto.Id}, Id não encontrado.");
            
            await _service.UpdateAsync(pagamento);
            return NoContent();
        }

        [HttpPut("AlterarFormaPagamento")]
        public async Task<IActionResult> UpdateFormaPagamento(int id, FormaPagamentoEnum formaPagamento)
        {
            var pagamento = await _service.GetByIdAsync(id);
            if (pagamento == null)
                return NotFound($"Não foi possivel alterar a forma de pagamento do Id {id}, Id não encontrado.");
 
            pagamento.FormaPagamento = formaPagamento;
            await _service.UpdateAsync(pagamento);
            return NoContent();
        }

        [HttpPut( "AlterarStatusPagamento")]
        public async Task<IActionResult> UpdateStatusPagamento(UpdatePagamentoDto updatePagamento)
        {
            var pagamento = await _service.GetByIdAsync(updatePagamento.Id);
            if (pagamento == null)
                return NotFound($"Não foi possivel alterar a forma de pagamento do Id {updatePagamento.Id}, Id não encontrado.");
            
            pagamento.StatusPagamento = updatePagamento.StatusPagamento;
            if(pagamento.StatusPagamento == StatusPagamentoEnum.PagamentoIdentificado 
                || pagamento.StatusPagamento == StatusPagamentoEnum.ProcessandoPagamento)
                pagamento.DataPagamento = DateTime.Now;

            await _service.UpdateAsync(pagamento);

            var mensagemPagamento = new MensagemPagamentoCriado(pagamento.IdPedido, pagamento.Id);
            await _producer.SendMessage(mensagemPagamento, RabbitMqQueueEnum.PagamentoQueue, RabbitMqRoutingKeyEnum.PagamentoPedidoEvento);

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
