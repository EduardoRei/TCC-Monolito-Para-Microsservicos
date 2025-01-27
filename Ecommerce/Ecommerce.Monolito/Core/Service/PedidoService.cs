using Ecommerce.DbMigrator.Context;
using Ecommerce.Commons.Entities;
using Ecommerce.Monolito.Core.Base;
using Ecommerce.Monolito.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Monolito.Core.Service
{
    public class PedidoService : ServiceBase<EcommerceDbContext>, IPedidoService
    {
        public PedidoService(EcommerceDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Pedido> GetByIdAsync(int id)
        {
            var pedido = await DbContext.Pedido
                .Include(p => p.Pagamento)
                .Include(p => p.Usuario)
                .Include(p => p.ProdutoPedido)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pedido == null)
                return new Pedido(); 

            pedido.Pagamento ??= new Pagamento();
            pedido.Usuario ??= new Usuario();
            pedido.ProdutoPedido ??= [];

            return pedido;
        }

        public async Task<IEnumerable<Pedido>> GetAllAsync()
        {
            return await DbContext.Pedido.ToListAsync();
        }

        public async Task AddAsync(Pedido pedido)
        {
            DbContext.Pedido.Add(pedido);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pedido pedido)
        {
            DbContext.Pedido.Update(pedido);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pedido = await GetByIdAsync(id);
            if (pedido != null)
            {
                DbContext.Pedido.Remove(pedido);
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
