using CategoriaEntity = Ecommerce.Commons.Entities.Categoria;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Ecommerce.Microsservico.Categoria.DbMigrator.Context
{
    public class CategoriaDbContext : DbContext
    {
        public CategoriaDbContext(DbContextOptions<CategoriaDbContext> options) 
            : base(options)
        {
        }

        public DbSet<CategoriaEntity> Categoria { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaEntity>().HasData(
                new CategoriaEntity { Id = 1, Nome = "Smartphones" },
                new CategoriaEntity { Id = 2, Nome = "Tablets" },
                new CategoriaEntity { Id = 3, Nome = "TVs" },
                new CategoriaEntity { Id = 4, Nome = "Notebooks" },
                new CategoriaEntity { Id = 5, Nome = "Projetores" },
                new CategoriaEntity { Id = 6, Nome = "Periféricos" },
                new CategoriaEntity { Id = 7, Nome = "Consolers" },
                new CategoriaEntity { Id = 8, Nome = "Cameras" }
            );
        }
    }
}
