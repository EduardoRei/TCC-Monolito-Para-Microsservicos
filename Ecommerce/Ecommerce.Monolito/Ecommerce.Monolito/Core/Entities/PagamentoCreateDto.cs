using Ecommerce.Commons.Enums;

namespace Ecommerce.Monolito.Core.Enity
{
    public class PagamentoCreateDto
    {
        public int IdPedido { get; set; }
        public FormaPagamentoEnum FormaPagamento { get; set; }
        public StatusPagamentoEnum StatusPagamento { get; set; }
    }
}
