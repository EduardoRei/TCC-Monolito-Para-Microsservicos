using Ecommerce.Commons.Core.Base;
using Ecommerce.Commons.Dtos;
using Ecommerce.Commons.Extensions;
using Ecommerce.Microsservico.Produto.Api.Core.Interface;
using Ecommerce.Microsservico.Produto.DbMigrator.Context;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Microsservico.Categoria.Api.Core.Service
{
    public class CategoriaService : ServiceBase<ProdutoDbContext>, ICategoriaService
    {
        public CategoriaService(ProdutoDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddCategoriaAsync(CategoriaDto categoria)
        {
            var entity = categoria.ToEntity();
            await DbContext.Categoria.AddAsync(entity);
            await DbContext.SaveChangesAsync();
            categoria.Id = entity.Id;
        }

        public async Task DeleteCategoriaByIdAsync(int id)
        {
            var categoriaDto = await GetCategoriaByIdAsync(id);
            if (categoriaDto != null)
            {
                var categoria = categoriaDto.ToEntity();
                DbContext.Categoria.Remove(categoria);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> ExisteCategoriaAsync(int? id)
        {
            var categoria = await GetCategoriaByIdAsync(id);
            return categoria?.Id == id;
        }

        public async Task<bool> ExisteNomeCategoriaAsync(string nome)
        {
            var categoriaExiste = await DbContext.Categoria.FirstOrDefaultAsync(x => string.Equals(x.Nome, nome, StringComparison.OrdinalIgnoreCase));

            return categoriaExiste != null;
        }

        public async Task<List<CategoriaDto>> GetAllCategoriasAsync()
            => await DbContext.Categoria
                                  .Select(categoria => categoria.ToDto())
                                  .ToListAsync();

        public async Task<CategoriaDto?> GetCategoriaByIdAsync(int? id)
            => await DbContext.Categoria
                              .Where(categoria => categoria.Id == id)
                              .Select(categoria => categoria.ToDto())
                              .FirstOrDefaultAsync();

        public async Task UpdateCategoriaAsync(CategoriaDto categoria)
        {
            var existingEntity = await DbContext.Categoria.FindAsync(categoria.Id);
            if (existingEntity != null)
            {
                DbContext.Entry(existingEntity).CurrentValues.SetValues(categoria.ToEntity());
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
