using Ecommerce.Commons.Enums;

namespace Ecommerce.Monolito.Core.Enity
{
    public record RealizarPagamentoDto (int Id, StatusPagamentoEnum StatusPagamento);
    public record UpdateFormaPagamentoDto (int Id, FormaPagamentoEnum FormaPagamento);
}
