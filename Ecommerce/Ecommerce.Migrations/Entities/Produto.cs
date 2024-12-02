namespace Ecommerce.Migrations.Entities {
    public class Produto {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public string Nome { get; set; }
        public int QuantidadeEstoque { get; set; }
        public decimal PrecoUnitario { get; set; }

        // Relacionamentos
        public Categoria Categoria { get; set; }
        public ICollection<ProdutoCarrinho> ProdutoCarrinhos { get; set; }
    }
}
