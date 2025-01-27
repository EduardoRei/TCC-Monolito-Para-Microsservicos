using Ecommerce.Commons.Enums;

namespace Ecommerce.Commons.Entities {
    public class Pedido {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdPagamento { get; set; }
        public StatusPedidoEnum StatusPedido { get; set; }
        public decimal PrecoTotal {  get; set; }

        // Relacionamentos
        public Usuario Usuario { get; set; }
        public Pagamento Pagamento { get; set; }
        public ICollection<ProdutoPedido> ProdutoPedido { get; set; }
    }
}
