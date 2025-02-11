using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using UsuarioEntity = Ecommerce.Commons.Entities.Usuario;


namespace Ecommerce.Microsservico.Usuario.DbMigrator.Context
{
    public class UsuarioDbContext : DbContext
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options)
            : base(options)
        {
        }

        public DbSet<UsuarioEntity> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioEntity>()
                .HasMany(pc => pc.Pedido)
                .WithOne(c => c.Usuario)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
