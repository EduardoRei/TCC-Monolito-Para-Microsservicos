using Ecommerce.DbMigrator.Context;
using Ecommerce.Commons.Entities;
using Ecommerce.Monolito.Core.Base;
using Ecommerce.Monolito.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Monolito.Core.Service
{
    public class ProdutoPedidoService : ServiceBase<EcommerceDbContext>, IProdutoPedidoService
    {
        public ProdutoPedidoService(EcommerceDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddAsync(ProdutoPedido produtoPedido)
        {
            DbContext.ProdutoPedido.Add(produtoPedido);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int idPedido, int idProduto)
        {
            var entity = await GetByIdAsync(idPedido, idProduto);
            if (entity != null)
            {
                DbContext.ProdutoPedido.Remove(entity);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProdutoPedido>> GetAllAsync()
            => await DbContext.ProdutoPedido.ToListAsync();

        public async Task<ProdutoPedido> GetByIdAsync(int idPedido, int idProduto)
        {
            var produtoPedido = await DbContext.ProdutoPedido
                .Include(pc => pc.Pedido)
                .Include(pc => pc.Produto)
                .FirstOrDefaultAsync(pc => pc.IdPedido == idPedido && pc.IdProduto == idProduto);

            if (produtoPedido?.IdPedido == 0 || produtoPedido == null)
                return new ProdutoPedido();

            return produtoPedido;
        }

        public async Task UpdateAsync(ProdutoPedido produtoPedido)
        {
            DbContext.ProdutoPedido.Update(produtoPedido);
            await DbContext.SaveChangesAsync();
        }
    }
}
