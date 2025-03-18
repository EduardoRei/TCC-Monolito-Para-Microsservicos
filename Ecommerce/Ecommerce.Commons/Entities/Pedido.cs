using Ecommerce.Commons.Enums;

namespace Ecommerce.Commons.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int? IdPagamento { get; set; }
        public StatusPedidoEnum StatusPedido { get; set; }
        public double PrecoTotal { get; set; }

        public ICollection<ProdutoPedido> ProdutoPedido { get; set; }
    }
}
