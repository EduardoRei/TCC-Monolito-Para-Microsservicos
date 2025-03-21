﻿using Ecommerce.Commons.Dtos;
using Ecommerce.Monolito.DbMigrator.Extensions;
using Ecommerce.Monolito.DbMigrator.Context;
using Ecommerce.Commons.Core.Base;
using Ecommerce.Monolito.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Monolito.Core.Service
{
    public class ProdutoPedidoService : ServiceBase<EcommerceDbContext>, IProdutoPedidoService
    {
        public ProdutoPedidoService(EcommerceDbContext dbContext) : base(dbContext)
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
                .Include(pc => pc.Pedido)
                .Include(pc => pc.Produto)
                .Where(pc => pc.IdPedido == idPedido && pc.IdProduto == idProduto)
                .Select(pc => pc.ToDto())
                .FirstOrDefaultAsync();

        public async Task UpdateAsync(ProdutoPedidoDto produtoPedido)
        {
            var existingEntity = await DbContext.ProdutoPedido.FindAsync(produtoPedido.IdProduto, produtoPedido.IdPedido);
            if (existingEntity != null)
            {
                DbContext.Entry(existingEntity).CurrentValues.SetValues(produtoPedido.ToEntity());
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
