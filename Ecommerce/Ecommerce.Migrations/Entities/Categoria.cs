namespace Ecommerce.Migrations.Entities {
    public class Categoria {
        public int Id { get; set; }
        public string Nome { get; set; }

        // Relacionamentos
        public ICollection<Produto> Produtos { get; set; }
    }
}
