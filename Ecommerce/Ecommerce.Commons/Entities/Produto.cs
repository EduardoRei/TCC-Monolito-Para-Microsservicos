
namespace Ecommerce.Commons.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeEstoque { get; set; }
        public double PrecoUnitario { get; set; }

        public Categoria Categoria { get; set; }
    }
}
