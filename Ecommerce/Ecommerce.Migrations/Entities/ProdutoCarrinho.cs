namespace Ecommerce.Migrations.Entities {
    public class ProdutoCarrinho {
        public int IdCarrinho { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoVendido { get; set; }

        // Relacionamentos
        public Carrinho Carrinho { get; set; }
        public Produto Produto { get; set; }
    }
}
