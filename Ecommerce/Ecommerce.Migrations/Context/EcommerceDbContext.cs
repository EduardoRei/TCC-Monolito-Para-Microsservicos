using Ecommerce.Migrations.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Ecommerce.Migrations.Context
{

    public class EcommerceDbContext : DbContext
    {

        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<ProdutoPedido> ProdutoPedido { get; set; }
        public DbSet<FormaPagamento> FormaPagamento { get; set; }
        public DbSet<StatusPagamento> StatusPagamento { get; set; }
        public DbSet<StatusPedido> StatusPedido { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacionamento entre Produto
            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Produto)
                .HasForeignKey(p => p.IdCategoria)
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascata na exclusão de categorias

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

            modelBuilder.Entity<Pedido>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Pedido)
                .HasForeignKey(c => c.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascata na exclusão de carrinhos de um usuário

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.StatusPedido)
                .WithMany(s => s.Pedido)
                .HasForeignKey(p => p.IdStatusPedido)
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascata na exclusão de pedidos de um status

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Pagamento)
                .WithOne(s => s.Pedido)
                .HasForeignKey<Pedido>(p => p.IdPagamento)
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascata na exclusão de pedidos de um status

            modelBuilder.Entity<Pedido>()
                .HasMany(pc => pc.ProdutoPedido)
                .WithOne(c => c.Pedido)
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento Usuario
            modelBuilder.Entity<Usuario>()
                .HasMany(pc => pc.Pedido)
                .WithOne(c => c.Usuario)
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento entre Pagamento
            modelBuilder.Entity<Pagamento>()
                .HasOne(p => p.Pedido)
                .WithOne(u => u.Pagamento)
                .HasForeignKey<Pagamento>(p => p.IdPedido)
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascata na exclusão de pagamentos de um usuário

            modelBuilder.Entity<Pagamento>()
                .HasOne(p => p.FormaPagamento)
                .WithMany(t => t.Pagamento)
                .HasForeignKey(p => p.IdTipoPagamento)
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascata na exclusão de pagamentos com tipos

            modelBuilder.Entity<Pagamento>()
            .HasOne(p => p.StatusPagamento) // Um pagamento tem um status de pagamento
            .WithMany(s => s.Pagamento)
            .HasForeignKey(p => p.IdStatusPagamento) // A chave estrangeira está na tabela Pagamento
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StatusPagamento>().HasData(
                new StatusPagamento { Id = 1, Status = "Aguardando pagamento" },
                new StatusPagamento { Id = 2, Status = "Processando pagamento" },
                new StatusPagamento { Id = 3, Status = "Pagamento identificado" },
                new StatusPagamento { Id = 4, Status = "Pagamento negado" }
            );

            // Seeding StatusPedido
            modelBuilder.Entity<StatusPedido>().HasData(
                new StatusPedido { Id = 1, Status = "Separando pedido" },
                new StatusPedido { Id = 2, Status = "Pedido enviado" },
                new StatusPedido { Id = 3, Status = "Pedido entregue" }
            );

            // Seeding TipoPagamento
            modelBuilder.Entity<FormaPagamento>().HasData(
                new FormaPagamento { Id = 1, Nome = "Boleto" },
                new FormaPagamento { Id = 2, Nome = "Pix" },
                new FormaPagamento { Id = 3, Nome = "Cartão de crédito" },
                new FormaPagamento { Id = 4, Nome = "Cartão de débito" }
);

            base.OnModelCreating(modelBuilder);
        }
    }
}
