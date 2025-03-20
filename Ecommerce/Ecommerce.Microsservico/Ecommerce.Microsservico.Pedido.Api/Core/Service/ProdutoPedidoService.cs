using Ecommerce.Commons.Core.Base;
using Ecommerce.Commons.Dtos;
using Ecommerce.Commons.Extensions;
using Ecommerce.Microsservico.Pedido.Api.Core.Interface;
using Ecommerce.Microsservico.Pedido.DbMigrator.Context;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Microsservico.Pedido.Api.Core.Service
{
    public class ProdutoPedidoService : ServiceBase<PedidoDbContext>, IProdutoPedidoService
    {
        public ProdutoPedidoService(PedidoDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddAsync(ProdutoPedidoDto produtoPedido)
        {
            var entity = produtoPedido.ToEntity(); 
            DbContext.ProdutoPedido.Add(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int idPedido, int idProduto)
        {
            var produtoPedidoDto = await GetByIdAsync(idPedido, idProduto);
            if (produtoPedidoDto != null)
            {
                var produtoPedido = produtoPedidoDto.ToEntity();
                DbContext.ProdutoPedido.Remove(produtoPedido);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProdutoPedidoDto>> GetAllAsync()
            => await DbContext.ProdutoPedido.Select(pp => pp.ToDto()).ToListAsync();

        public async Task<ProdutoPedidoDto?> GetByIdAsync(int idPedido, int idProduto)
            => await DbContext.ProdutoPedido
                .Include(pc => pc.  Pedido)
                .Where(pc => pc.IdPedido == idPedido && pc.IdProduto == idProduto)
                .Select(pc => pc.ToDto())
                .FirstOrDefaultAsync();

        public async Task UpdateAsync(ProdutoPedidoDto produtoPedido)
        {
            var existingEntity = await DbContext.ProdutoPedido.FindAsync(produtoPedido.IdPedido, produtoPedido.IdProduto);
            if (existingEntity != null)
            {
                DbContext.Entry(existingEntity).CurrentValues.SetValues(produtoPedido.ToEntity());
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
