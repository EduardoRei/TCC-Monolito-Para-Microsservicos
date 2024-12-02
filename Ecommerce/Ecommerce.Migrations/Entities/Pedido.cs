namespace Ecommerce.Migrations.Entities {
    public class Pedido {
        public int Id { get; set; }
        public int IdStatusPagamento { get; set; }
        public int IdUsuario { get; set; }
        public int IdCarrinho { get; set; }
        public DateTime? DataPagamento { get; set; }
        public DateTime DataPedido { get; set; }
        public int IdStatusPedido { get; set; }

        // Relacionamentos
        public StatusPagamento StatusPagamento { get; set; }
        public Usuario Usuario { get; set; }
        public Carrinho Carrinho { get; set; }
        public StatusPedido StatusPedido { get; set; }
    }
}
