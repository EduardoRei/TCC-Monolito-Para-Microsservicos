namespace Ecommerce.Microsservico.Produto.Api.Core.Entities
{
    public class ProdutoCreateDto
    {
        public required int IdCategoria { get; set; }
        public required string Nome { get; set; }
        public required string Descricao { get; set; }
        public required int QuantidadeEstoque { get; set; }
        public required double PrecoUnitario { get; set; }
    }
}
