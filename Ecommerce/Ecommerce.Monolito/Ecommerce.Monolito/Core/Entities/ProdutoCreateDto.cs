namespace Ecommerce.Monolito.Core.Enity
{
    public class ProdutoCreateDto
    {
        public int IdCategoria { get; set; }
        public required string Nome { get; set; }
        public required string Descricao { get; set; }
        public int QuantidadeEstoque { get; set; }
        public double PrecoUnitario { get; set; }
    }
}
