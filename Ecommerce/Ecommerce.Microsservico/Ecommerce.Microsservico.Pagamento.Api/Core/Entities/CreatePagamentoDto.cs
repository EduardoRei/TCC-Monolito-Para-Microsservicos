using Ecommerce.Commons.Enums;

namespace Ecommerce.Microsservico.Pagamento.Api.Core.Entities
{
    public class CreatePagamentoDto
    {
        public int IdPedido { get; set; }
        public FormaPagamentoEnum FormaPagamento { get; set; }
    }
}
