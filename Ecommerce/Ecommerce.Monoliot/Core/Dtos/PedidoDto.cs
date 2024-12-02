namespace Ecommerce.Monolito.Core.Dtos
{
    public class PedidoDto
    {
        public int IdStatusPagamento { get; set; }
        public int IdUsuario { get; set; }
        public int IdCarrinho { get; set; }
        public DateTime? DataPagamento { get; set; }
        public DateTime DataPedido { get; set; }
        public int IdStatusPedido { get; set; }
    }
}
