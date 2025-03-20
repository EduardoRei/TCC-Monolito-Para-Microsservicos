using Ecommerce.Monolito.DbMigrator.Context;
using Ecommerce.Commons.Core.Base;
using Ecommerce.Commons.Dtos;
using Ecommerce.Monolito.DbMigrator.Extensions;
using Ecommerce.Monolito.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Monolito.Core.Service
{
    public class ProdutoService : ServiceBase<EcommerceDbContext>, IProdutoService
    {

        public ProdutoService(EcommerceDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddProdutoAsync(ProdutoDto produto)
        {
            var entity = produto.ToEntity();
            await DbContext.Produto.AddAsync(entity);
            await DbContext.SaveChangesAsync();
            produto.Id = entity.Id;
        }

        public async Task DeleteProdutoByIdAsync(int id)
        {
            var produtoDto = await GetProdutoByIdAsync(id);
            if (produtoDto != null)
            {
                var produto = produtoDto.ToEntity();
                DbContext.Produto.Remove(produto);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> ExisteProdutoAsync(string nome, int? idCategoria)
        {
            var produto = await DbContext.Produto.FirstOrDefaultAsync(x => x.Nome == nome && x.IdCategoria == idCategoria);
            return produto?.Id != 0;
        }

        public async Task<List<ProdutoDto>> GetAllProdutosAsync() =>
            await DbContext.Produto.Select(p => p.ToDto()).ToListAsync();

        public async Task<List<ProdutoDto>> GetListaProdutosByIdListAsync(List<int> listaIds) =>
            await DbContext.Produto.Where(x => listaIds.Contains(x.Id)).Select(p => p.ToDto()).ToListAsync();
        
        public async Task<ProdutoDto?> GetProdutoByIdAsync(int? id) =>
            await DbContext.Produto.Where(x => x.Id == id).Select(p => p.ToDto()).FirstOrDefaultAsync();

        public async Task<int> GetQuantidadeProdutoByIdAsync(int? id)
        {
            var produto = await DbContext.Produto.FirstOrDefaultAsync(x => x.Id == id);
            return produto?.QuantidadeEstoque ?? 0;
        }

        public async Task UpdateProdutoAsync(ProdutoDto produto)
        {
            var existingEntity = await DbContext.Produto.FindAsync(produto.Id);
            if (existingEntity != null)
            {
                DbContext.Entry(existingEntity).CurrentValues.SetValues(produto.ToEntity());
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task RemoverQuantidadeProdutoAsync(int id, int quantidade)
        {
            var produto = await DbContext.Produto.FirstOrDefaultAsync(x => x.Id == id);
            if (produto != null)
            {
                produto.QuantidadeEstoque -= quantidade;
                DbContext.Produto.Update(produto);
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
