namespace Ecommerce.Microsservico.Produto.Api.Core.Entities
{
    public class ProdutoAtualizarDto
    {
        public required int IdProduto { get; set; }
        public required int QuantidadeVendida { get; set; }
    }
}
