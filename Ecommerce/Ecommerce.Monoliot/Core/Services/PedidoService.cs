using Ecommerce.Migrations.Context;
using Ecommerce.Migrations.Entities;
using Ecommerce.Monolito.Core.Base;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Monolito.Core.Services {
    public class PedidoService : ServiceBase<EcommerceDbContext>, IPedidoService
    {
        public PedidoService(EcommerceDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Pedido> GetByIdAsync(int id)
        {
            var pedido = await DbContext.Pedidos
                .Include(p => p.StatusPagamento)
                .Include(p => p.Usuario)
                .Include(p => p.Carrinho)
                .Include(p => p.StatusPedido)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pedido == null)
                return new Pedido(); // Retorna um pedido vazio caso não encontrado.

            // Verificar se as propriedades do pedido estão nulas e criar instâncias vazias, se necessário.
            pedido.StatusPagamento ??= new StatusPagamento();
            pedido.Usuario ??= new Usuario();
            pedido.Carrinho ??= new Carrinho();
            pedido.StatusPedido ??= new StatusPedido();

            return pedido;
        }

        public async Task<IEnumerable<Pedido>> GetAllAsync()
        {
            return await DbContext.Pedidos.ToListAsync();
        }

        public async Task AddAsync(Pedido pedido)
        {
            DbContext.Pedidos.Add(pedido);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pedido pedido)
        {
            DbContext.Pedidos.Update(pedido);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pedido = await GetByIdAsync(id);
            if (pedido != null)
            {
                DbContext.Pedidos.Remove(pedido);
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
