﻿using Ecommerce.Commons.Entities;
using Ecommerce.DbMigrator.Context;
using Ecommerce.Monolito.Core.Base;
using Ecommerce.Monolito.Core.Dtos;
using Ecommerce.Monolito.Core.Extensions;
using Ecommerce.Monolito.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Monolito.Core.Service
{
    public class CategoriaService : ServiceBase<EcommerceDbContext>, ICategoriaService
    {
        public CategoriaService(EcommerceDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddCategoriaAsync(CategoriaDto categoria)
        {
            await DbContext.Categoria.AddAsync(categoria.ToEntity());
            await DbContext.SaveChangesAsync();
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
            DbContext.Categoria.Update(categoria.ToEntity());
            await DbContext.SaveChangesAsync();
        }
    }
}
