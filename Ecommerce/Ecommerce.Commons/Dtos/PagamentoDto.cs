using Ecommerce.Commons.Enums;

namespace Ecommerce.Commons.Dtos
{
    public class PagamentoDto
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public FormaPagamentoEnum FormaPagamento { get; set; }
        public StatusPagamentoEnum StatusPagamento { get; set; }
        public DateTime? DataPagamento { get; set; }
    }
}
