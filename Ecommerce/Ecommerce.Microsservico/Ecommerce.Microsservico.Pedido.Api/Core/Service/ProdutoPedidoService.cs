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
            DbContext.ProdutoPedido.Add(produtoPedido.ToEntity());
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
                .Include(pc => pc.Pedido)
                .Include(pc => pc.Produto)
                .Select(pc => pc.ToDto())
                .FirstOrDefaultAsync(pc => pc.IdPedido == idPedido && pc.IdProduto == idProduto);

        public async Task UpdateAsync(ProdutoPedidoDto produtoPedido)
        {
            DbContext.ProdutoPedido.Update(produtoPedido.ToEntity());
            await DbContext.SaveChangesAsync();
        }
    }
}
