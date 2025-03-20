using Ecommerce.Commons.Enums;

namespace Ecommerce.Microsservico.Pedido.Api.Core.Entities
{
    public class AtualizarPagamentoDto
    {
        public int IdPedido { get; set; }
        public int IdPagamento { get; set; }
        public StatusPagamentoEnum? StatusPagamento { get; set; }
    }
}
