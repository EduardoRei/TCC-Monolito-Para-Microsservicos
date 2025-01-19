namespace Ecommerce.Monolito.Core.Dtos
{
    public class PagamentoDto
    {
        public int IdUsuario { get; set; }
        public int IdCarrinho { get; set; }
        public DateTime Data { get; set; }
        public int IdTipoPagamento { get; set; }
        public int IdStatusPagamento { get; set; }
        public decimal ValorCarrinho { get; set; }
    }
}
