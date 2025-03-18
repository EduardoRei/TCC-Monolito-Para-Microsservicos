namespace Ecommerce.Commons.Entities
{
    public class ProdutoPedido
    {
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public int QuantidadeProduto { get; set; }

        public Pedido Pedido { get; set; }
    }
}
