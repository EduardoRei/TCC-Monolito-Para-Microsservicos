using Ecommerce.Migrations.Context;
using Ecommerce.Migrations.Entities;
using Ecommerce.Monolito.Core.Base;
using Ecommerce.Monolito.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Monolito.Core.Services {
    public class ProdutoCarrinhoService : ServiceBase<EcommerceDbContext>, IProdutoCarrinhoService
    {
        public ProdutoCarrinhoService(EcommerceDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ProdutoCarrinho> GetByIdAsync(int idCarrinho, int idProduto)
        {
            var produtoCarrinho = await DbContext.ProdutoCarrinhos
                .Include(pc => pc.Carrinho)
                .Include(pc => pc.Produto)
                .FirstOrDefaultAsync(pc => pc.IdCarrinho == idCarrinho && pc.IdProduto == idProduto);

            if(produtoCarrinho?.IdCarrinho == 0 || produtoCarrinho == null)
                return new ProdutoCarrinho();

            return produtoCarrinho;
        }

        public async Task<IEnumerable<ProdutoCarrinho>> GetAllAsync()
        {
            return await DbContext.ProdutoCarrinhos.ToListAsync();
        }

        public async Task AddAsync(ProdutoCarrinho produtoCarrinho)
        {
            DbContext.ProdutoCarrinhos.Add(produtoCarrinho);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProdutoCarrinho produtoCarrinho)
        {
            DbContext.ProdutoCarrinhos.Update(produtoCarrinho);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int idCarrinho, int idProduto)
        {
            var entity = await GetByIdAsync(idCarrinho, idProduto);
            if (entity != null)
            {
                DbContext.ProdutoCarrinhos.Remove(entity);
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
