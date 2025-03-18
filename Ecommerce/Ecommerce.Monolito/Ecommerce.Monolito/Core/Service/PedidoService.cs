﻿using Ecommerce.Commons.Dtos;
using Ecommerce.Monolito.DbMigrator.Extensions;
using Ecommerce.Monolito.DbMigrator.Context;
using Ecommerce.Commons.Core.Base;
using Ecommerce.Monolito.Core.Interface;
using Microsoft.EntityFrameworkCore;

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
                .Where(p => p.Id == id)
                .Select(p => p.ToDto())
                .FirstOrDefaultAsync();
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
            var entity = pedido.ToEntity();
            DbContext.Pedido.Add(entity);
            await DbContext.SaveChangesAsync();
            pedido.Id = entity.Id;
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
