namespace Ecommerce.Commons.Dtos
{
    public class CreatePedidoDto
    {
        public int IdUsuario { get; set; }

        public List<CreateProdutoPedidoDto> CreateProdutoPedido { get; set; } = new List<CreateProdutoPedidoDto>();
    }

    public class CreateProdutoPedidoDto
    {
        public int IdProduto { get; set; }
        public int QuantidadeProduto { get; set; }
    }
}
