namespace Ecommerce.Migrations.Entities {
    public class Pagamento {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdCarrinho { get; set; }
        public DateTime Data { get; set; }
        public int IdTipoPagamento { get; set; }
        public int IdStatusPagamento { get; set; }
        public decimal ValorCarrinho { get; set; }

        // Relacionamentos
        public Usuario Usuario { get; set; }
        public Carrinho Carrinho { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
        public StatusPagamento StatusPagamento { get; set; }
    }
}
