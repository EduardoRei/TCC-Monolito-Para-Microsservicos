using Ecommerce.Commons.Enums;

namespace Ecommerce.Microsservico.Pagamento.Api.Core.Entities
{
    public record UpdatePagamentoDto (int id, StatusPagamentoEnum statusPagamento);
}
