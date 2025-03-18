using Ecommerce.Commons.Core.Base;
using Ecommerce.Commons.Extensions;
using Ecommerce.Commons.Dtos;
using Ecommerce.Microsservico.Produto.Api.Core.Interface;
using Ecommerce.Microsservico.Produto.DbMigrator.Context;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Microsservico.Produto.Api.Core.Service
{
    public class ProdutoService : ServiceBase<ProdutoDbContext>, IProdutoService
    {

        public ProdutoService(ProdutoDbContext dbContext) : base(dbContext)
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
            await DbContext.Produto
                .Where(p => p.Id == id)
                .Select(p => p.ToDto())
                .FirstOrDefaultAsync();

        public async Task<int> GetQuantidadeProdutoByIdAsync(int? id)
        {
            var produto = await DbContext.Produto.FirstOrDefaultAsync(x => x.Id == id);
            return produto?.QuantidadeEstoque ?? 0;
        }

        public async Task UpdateProdutoAsync(ProdutoDto produto)
        {
            DbContext.Produto.Update(produto.ToEntity());
            await DbContext.SaveChangesAsync();
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
