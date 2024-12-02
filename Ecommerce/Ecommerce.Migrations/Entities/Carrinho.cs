namespace Ecommerce.Migrations.Entities {
    public class Carrinho {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public int IdUsuario { get; set; }

        // Relacionamentos
        public Usuario Usuario { get; set; }
        public ICollection<ProdutoCarrinho> ProdutoCarrinhos { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
        public Pagamento Pagamento { get; set; }
    }
}
