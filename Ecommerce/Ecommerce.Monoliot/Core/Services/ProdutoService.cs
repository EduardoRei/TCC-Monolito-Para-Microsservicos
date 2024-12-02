using Ecommerce.Migrations.Context;
using Ecommerce.Migrations.Entities;
using Ecommerce.Monolito.Core.Base;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Monolito.Core.Services
{
    public class ProdutoService : ServiceBase<EcommerceDbContext>, IProdutoService
    {
        public ProdutoService(EcommerceDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddProdutoAsync(Produto produto)
        {
            await DbContext.AddAsync(produto);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteProdutoByIdAsync(int id)
        {
            var produto = await GetProdutoByIdAsync(id);
            if (produto != null)
            {
                DbContext.Produtos.Remove(produto);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> ExisteProdutoAsync(string nome, int? idCategoria)
        {
            var produto = await DbContext.Produtos.FirstOrDefaultAsync(x => x.Nome == nome && x.IdCategoria == idCategoria);
            if(produto?.Id == 0 || produto == null)
                return false;

            return true;
        }

        public async Task<List<Produto>> GetAllProdutosAsync() =>
            await DbContext.Produtos.ToListAsync();

        public async Task<Produto> GetProdutoByIdAsync(int? id)
        {
            var produto = await DbContext.Produtos.FirstOrDefaultAsync(x => x.Id == id);
            if (produto == null)
                return new Produto();

            return produto;
        }

        public async Task<int> GetQuantidadeProdutoByIdAsync(int? id)
        {
            var produto = await DbContext.Produtos.FirstOrDefaultAsync(x => x.Id == id);

            if(produto == null)
                return 0;

            return produto.QuantidadeEstoque;
        }

        public async Task UpdateProdutoAsync(Produto produto)
        {
            DbContext.Update(produto);
            await DbContext.SaveChangesAsync();
        }
    }
}
