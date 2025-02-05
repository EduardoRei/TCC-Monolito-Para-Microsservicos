namespace Ecommerce.Commons.Dtos
{
    public class ProdutoPedidoDto
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade_Produto { get; set; }
    }
}
