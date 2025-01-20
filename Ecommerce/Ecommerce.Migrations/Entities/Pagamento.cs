namespace Ecommerce.Migrations.Entities {
    public class Pagamento {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int IdTipoPagamento { get; set; }
        public int IdStatusPagamento { get; set; }
        public DateTime DataPagamento { get; set; }

        // Relacionamentos
        public Pedido Pedido { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public StatusPagamento StatusPagamento { get; set; }
    }
}
