using Ecommerce.Commons.Enums;

namespace Ecommerce.Microsservico.Pagamento.Api.Core.Entities
{
    public record MensagemPagamentoCriado(int IdPedido, int IdPagamento, StatusPagamentoEnum EventoPagamento);
}
