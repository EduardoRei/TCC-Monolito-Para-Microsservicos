using Ecommerce.Commons.Enums;

namespace Ecommerce.Commons.Dtos
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int? IdPagamento { get; set; }
        public StatusPedidoEnum StatusPedido { get; set; }
        public long PrecoTotal { get; set; }

        public List<ProdutoPedidoDto> ProdutoPedido { get; set; }
    }
}
