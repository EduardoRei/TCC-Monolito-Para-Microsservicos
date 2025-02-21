namespace Ecommerce.Commons.Entities
{
    public class ProdutoPedido
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade_Produto { get; set; }

        public Pedido Pedido { get; set; }
    }
}
