using Ecommerce.Commons.Enums;

namespace Ecommerce.Microsservico.Pagamento.Api.Core.Entities
{
    public record UpdatePagamentoDto (int Id, StatusPagamentoEnum StatusPagamento);
}
