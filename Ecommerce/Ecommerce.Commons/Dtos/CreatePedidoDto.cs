using Ecommerce.Commons.Enums;

namespace Ecommerce.Commons.Dtos
{
    public class CreatePedidoDto
    {
        public required int IdUsuario { get; set; }
        public required FormaPagamentoEnum FormaPagamento { get; set; }

        public List<CreateProdutoPedidoDto> CreateProdutoPedido { get; set; } = new List<CreateProdutoPedidoDto>();
    }

    public class CreateProdutoPedidoDto
    {
        public int IdProduto { get; set; }
        public int QuantidadeProduto { get; set; }
    }
}
