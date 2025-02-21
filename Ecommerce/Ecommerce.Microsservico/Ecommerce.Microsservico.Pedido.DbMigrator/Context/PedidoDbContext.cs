using Ecommerce.Commons.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PedidoEntity = Ecommerce.Commons.Entities.Pedido;


namespace Ecommerce.Microsservico.Pedido.DbMigrator.Context
{
    public class PedidoDbContext : DbContext
    {
        public PedidoDbContext(DbContextOptions<PedidoDbContext> options)
            : base(options)
        {
        }

        public DbSet<PedidoEntity> Pedido { get; set; }
        public DbSet<ProdutoPedido> ProdutoPedido { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProdutoPedido>()
                .HasOne(pc => pc.Pedido)
                .WithMany(c => c.ProdutoPedido)
                .HasForeignKey(pc => pc.IdPedido)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProdutoPedido>()
                .HasKey(pc => new { pc.IdProduto, pc.IdPedido }); 

            modelBuilder.Entity<PedidoEntity>()
                .HasMany(pc => pc.ProdutoPedido)
                .WithOne(c => c.Pedido)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
