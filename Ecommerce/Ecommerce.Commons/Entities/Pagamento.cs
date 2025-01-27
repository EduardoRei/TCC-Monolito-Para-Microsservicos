using Ecommerce.Commons.Enums;

namespace Ecommerce.Commons.Entities {
    public class Pagamento {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public StatusPagamentoEnum StatusPagamento { get; set; }
        public FormaPagamentoEnum FormaPagamento { get; set; }
        public DateTime? DataPagamento { get; set; }

        // Relacionamentos
        public Pedido Pedido { get; set; }
    }
}
