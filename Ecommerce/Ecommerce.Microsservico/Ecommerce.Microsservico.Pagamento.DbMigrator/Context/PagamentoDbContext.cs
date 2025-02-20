using PagamentoEntity = Ecommerce.Commons.Entities.Pagamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Ecommerce.Microsservico.Pagamento.DbMigrator.Context
{
    public class PagamentoDbContext : DbContext
    {
        public PagamentoDbContext(DbContextOptions<PagamentoDbContext> options)
            : base(options)
        {
        }

        public DbSet<PagamentoEntity> Pagamento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
