using Ecommerce.DbMigrator.Context;
using Ecommerce.Commons.Entities;
using Ecommerce.Monolito.Core.Base;
using Ecommerce.Monolito.Core.Interface;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Monolito.Core.Dtos;
using Ecommerce.Monolito.Core.Extensions;

namespace Ecommerce.Monolito.Core.Service
{
    public class PedidoService : ServiceBase<EcommerceDbContext>, IPedidoService
    {
        public PedidoService(EcommerceDbContext dbContext) : base(dbContext)
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
