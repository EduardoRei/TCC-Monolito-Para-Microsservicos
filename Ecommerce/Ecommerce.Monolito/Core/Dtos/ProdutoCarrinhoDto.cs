namespace Ecommerce.Monolito.Core.Dtos
{
    public class ProdutoCarrinhoDto
    {
        public int IdCarrinho { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoVendido { get; set; }
    }
}
