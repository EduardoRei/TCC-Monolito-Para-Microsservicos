using Ecommerce.Migrations.Context;
using Ecommerce.Migrations.Entities;
using Ecommerce.Monolito.Core.Base;
using Ecommerce.Monolito.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Monolito.Core.Services {
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
                DbContext.Categorias.Remove(categoria);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> ExisteCategoriaAsync(string nome)
        {
            var categoriaExiste = await DbContext.Categorias.FirstOrDefaultAsync(x => string.Equals(x.Nome, nome, StringComparison.OrdinalIgnoreCase));

            if (categoriaExiste == null || categoriaExiste.Equals(new Categoria()))
                return false;

            return true;
        }

        public async Task<List<Categoria>> GetAllCategoriasAsync() =>
            await DbContext.Categorias.ToListAsync();

        public async Task<Categoria> GetCategoriaByIdAsync(int? id)
        {
            if (id == null || id <= 0)
            {
                return new Categoria();
            }

            var categoria = await DbContext.Categorias.FirstOrDefaultAsync(x => x.Id == id);

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
