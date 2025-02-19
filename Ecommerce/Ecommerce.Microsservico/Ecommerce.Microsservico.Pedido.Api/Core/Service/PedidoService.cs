using Ecommerce.Commons.Core.Base;
using Ecommerce.Commons.Dtos;
using Ecommerce.Commons.Extensions;
using Ecommerce.Microsservico.Pedido.Api.Core.Interface;
using Ecommerce.Microsservico.Pedido.DbMigrator.Context;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Microsservico.Pedido.Api.Core.Service
{
    public class PedidoService : ServiceBase<PedidoDbContext>, IPedidoService
    {
        public PedidoService(PedidoDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<PedidoDto?> GetByIdAsync(int id)
        {
            return await DbContext.Pedido
                .Include(p => p.Pagamento)
                .Include(p => p.Usuario)
                .Include(p => p.ProdutoPedido)
                .Select(p => p.ToDto())
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<PedidoDto>> GetAllAsync()
            => await DbContext.Pedido
                .Include(p => p.Pagamento)
                .Include(p => p.Usuario)
                .Include(p => p.ProdutoPedido)
                .Select(p => p.ToDto())
                .ToListAsync();

        public async Task AddAsync(PedidoDto pedido)
        {
            DbContext.Pedido.Add(pedido.ToEntity());
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PedidoDto pedido)
        {
            DbContext.Pedido.Update(pedido.ToEntity());
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pedidoDto = await GetByIdAsync(id);
            if (pedidoDto != null)
            {
                var pedido = pedidoDto.ToEntity();
                DbContext.Pedido.Remove(pedido);
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
