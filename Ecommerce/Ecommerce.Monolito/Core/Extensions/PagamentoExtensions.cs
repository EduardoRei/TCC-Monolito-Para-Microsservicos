using Ecommerce.Commons.Entities;
using Ecommerce.Monolito.Core.Dtos;

namespace Ecommerce.Monolito.Core.Extensions
{
    public static class PagamentoExtensions
    {
        public static PagamentoDto ToDto(this Pagamento pagamento)
            => new PagamentoDto
            {
                Id = pagamento.Id,
                IdPedido = pagamento.IdPedido,
                DataPagamento = pagamento.DataPagamento,
                FormaPagamento = pagamento.FormaPagamento,
                StatusPagamento = pagamento.StatusPagamento
            };

        public static Pagamento ToEntity(this PagamentoDto pagamento)
            => new Pagamento
            {
                Id = pagamento.Id,
                IdPedido = pagamento.IdPedido,
                DataPagamento = pagamento.DataPagamento,
                FormaPagamento = pagamento.FormaPagamento,
                StatusPagamento = pagamento.StatusPagamento
            };
    }
}
