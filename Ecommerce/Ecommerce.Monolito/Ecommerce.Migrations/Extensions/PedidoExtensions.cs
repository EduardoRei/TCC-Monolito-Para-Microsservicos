using Ecommerce.Monolito.DbMigrator.Entities;
using Ecommerce.Commons.Dtos;
using Ecommerce.Commons.Enums;

namespace Ecommerce.Monolito.DbMigrator.Extensions
{
    public static class PedidoExtensions
    {
        public static PedidoDto ToDto(this Pedido pedido)
        {
            return new PedidoDto
            {
                Id = pedido.Id,
                IdPagamento = pedido.IdPagamento,
                IdUsuario = pedido.IdUsuario,
                PrecoTotal = pedido.PrecoTotal,
                ProdutoPedido = pedido.ProdutoPedido.Select(pp => pp.ToDto()).ToList(),
                StatusPedido = pedido.StatusPedido
            };
        }

        public static Pedido ToEntity(this PedidoDto pedido)
        {
            return new Pedido
            {
                Id = pedido.Id,
                IdPagamento = pedido.IdPagamento ?? 0,
                IdUsuario = (int)pedido.IdUsuario,
                PrecoTotal = (double)pedido.PrecoTotal,
                ProdutoPedido = pedido.ProdutoPedido.Select(pp => pp.ToEntity()).ToList(),
                StatusPedido = (StatusPedidoEnum)pedido.StatusPedido
            };
        }
    }
}
