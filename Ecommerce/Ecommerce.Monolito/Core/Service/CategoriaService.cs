using Ecommerce.Commons.Entities;
using Ecommerce.DbMigrator.Context;
using Ecommerce.Monolito.Core.Base;
using Ecommerce.Monolito.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Monolito.Core.Service
{
    public class CategoriaService : ServiceBase<EcommerceDbContext>, ICategoriaService
    {
        public CategoriaService(EcommerceDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddCategoriaAsync(Categoria categoria)
        {
            await DbContext.AddAsync(categoria);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteCategoriaByIdAsync(int id)
        {
            var categoria = await GetCategoriaByIdAsync(id);
            if (categoria != null)
            {
                DbContext.Categoria.Remove(categoria);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> ExisteCategoriaAsync(int? id)
        {
            var categoria = await GetCategoriaByIdAsync(id);
            if(categoria.Id == id)
                return true;

            return false;
        }

        public async Task<bool> ExisteNomeCategoriaAsync(string nome)
        {
            var categoriaExiste = await DbContext.Categoria.FirstOrDefaultAsync(x => string.Equals(x.Nome, nome, StringComparison.OrdinalIgnoreCase));

            if (categoriaExiste == null || categoriaExiste.Equals(new Categoria()))
                return false;

            return true;
        }

        public async Task<List<Categoria>> GetAllCategoriasAsync() =>
            await DbContext.Categoria.ToListAsync();

        public async Task<Categoria> GetCategoriaByIdAsync(int? id)
        {
            if (id == null || id <= 0)
            {
                return new Categoria();
            }

            var categoria = await DbContext.Categoria.FirstOrDefaultAsync(x => x.Id == id);

            if (categoria == null)
            {
                return new Categoria();
            }

            return categoria;
        }

        public async Task UpdateCategoriaAsync(Categoria categoria)
        {
            DbContext.Update(categoria);
            await DbContext.SaveChangesAsync();
        }
    }
}
