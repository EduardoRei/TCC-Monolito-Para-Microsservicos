namespace Ecommerce.Monolito.Core.Dtos
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public int? IdCategoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int? QuantidadeEstoque { get; set; }
        public double? PrecoUnitario { get; set; }
    }
}
