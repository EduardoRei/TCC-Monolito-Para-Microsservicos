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
            // Relacionamento Produto Pedido
            modelBuilder.Entity<ProdutoPedido>()
                .HasOne(pc => pc.Produto)
                .WithMany(p => p.ProdutoPedido)
                .HasForeignKey(pc => pc.IdProduto)
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascata na exclusão de produtos

            modelBuilder.Entity<ProdutoPedido>()
                .HasOne(pc => pc.Pedido)
                .WithMany(c => c.ProdutoPedido)
                .HasForeignKey(pc => pc.IdPedido)
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascata na exclusão de pedidos

            modelBuilder.Entity<ProdutoPedido>()
                .HasKey(pc => new { pc.IdProduto, pc.IdPedido }); // Chave composta com IdProduto e IdPedido

            // Relacionamento Pedido

            modelBuilder.Entity<PedidoEntity>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Pedido)
                .HasForeignKey(c => c.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascata na exclusão de carrinhos de um usuário

            modelBuilder.Entity<PedidoEntity>()
                .HasOne(p => p.Pagamento)
                .WithOne(s => s.Pedido)
                .HasForeignKey<PedidoEntity>(p => p.IdPagamento)
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascata na exclusão de pedidos de um status

            modelBuilder.Entity<PedidoEntity>()
                .HasMany(pc => pc.ProdutoPedido)
                .WithOne(c => c.Pedido)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
