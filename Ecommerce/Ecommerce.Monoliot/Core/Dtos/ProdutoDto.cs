namespace Ecommerce.Monolito.Core.Dtos
{
    public class ProdutoDto
    {
        public int? IdCategoria { get; set; }
        public string? Nome { get; set; }
        public int? QuantidadeEstoque { get; set; }
        public decimal? PrecoUnitario { get; set; }

    }
}
