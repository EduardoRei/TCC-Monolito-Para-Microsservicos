using Ecommerce.Migrations.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Ecommerce.Migrations.Context
{

    public class EcommerceDbContext : DbContext
    {

        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options)
            : base(options) // Passa as opções para o construtor base
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }
        public DbSet<ProdutoCarrinho> ProdutoCarrinhos { get; set; }
        public DbSet<TipoPagamento> TiposPagamento { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<StatusPagamento> StatusPagamentos { get; set; }
        public DbSet<StatusPedido> StatusPedidos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacionamento entre Produto e Categoria
            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.IdCategoria)
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascata na exclusão de categorias

            // Relacionamento entre Produto e Carrinho
            modelBuilder.Entity<ProdutoCarrinho>()
                .HasOne(pc => pc.Produto)
                .WithMany(p => p.ProdutoCarrinhos)
                .HasForeignKey(pc => pc.IdProduto)
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascata na exclusão de produtos

            modelBuilder.Entity<ProdutoCarrinho>()
                .HasOne(pc => pc.Carrinho)
                .WithMany(c => c.ProdutoCarrinhos)
                .HasForeignKey(pc => pc.IdCarrinho)
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascata na exclusão de carrinhos

            // Relacionamento entre Carrinho e Usuario
            modelBuilder.Entity<Carrinho>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Carrinhos)
                .HasForeignKey(c => c.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascata na exclusão de carrinhos de um usuário

            // Relacionamento entre Pagamento e Usuario
            modelBuilder.Entity<Pagamento>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Pagamentos)
                .HasForeignKey(p => p.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascata na exclusão de pagamentos de um usuário

            // Relacionamento entre Pagamento e TipoPagamento
            modelBuilder.Entity<Pagamento>()
                .HasOne(p => p.TipoPagamento)
                .WithMany(t => t.Pagamentos)
                .HasForeignKey(p => p.IdTipoPagamento)
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascata na exclusão de pagamentos com tipos

            // Relacionamento entre Pedido e Usuario
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Pedidos)
                .HasForeignKey(p => p.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascata na exclusão de pedidos de um usuário

            // Relacionamento entre Pedido e Carrinho
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Carrinho)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(p => p.IdCarrinho)
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascata na exclusão de pedidos de um carrinho

            // Relacionamento entre Pedido e StatusPedido
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.StatusPedido)
                .WithMany(s => s.Pedidos)
                .HasForeignKey(p => p.IdStatusPedido)
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascata na exclusão de pedidos de um status

            modelBuilder.Entity<Pagamento>()
            .HasOne(p => p.Carrinho) // Um pagamento tem um carrinho
            .WithOne(c => c.Pagamento) // Um carrinho tem um pagamento
            .HasForeignKey<Pagamento>(p => p.IdCarrinho) // A chave estrangeira está em Pagamento
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pagamento>()
            .HasOne(p => p.StatusPagamento) // Um pagamento tem um status de pagamento
            .WithMany(s => s.Pagamentos)
            .HasForeignKey(p => p.IdStatusPagamento) // A chave estrangeira está na tabela Pagamento
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProdutoCarrinho>()
                .HasKey(pc => new { pc.IdProduto, pc.IdCarrinho }); // Chave composta com IdProduto e IdCarrinho

            // Configuração de relacionamentos
            modelBuilder.Entity<ProdutoCarrinho>()
                .HasOne(pc => pc.Produto)
                .WithMany(p => p.ProdutoCarrinhos)
                .HasForeignKey(pc => pc.IdProduto)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProdutoCarrinho>()
                .HasOne(pc => pc.Carrinho)
                .WithMany(c => c.ProdutoCarrinhos)
                .HasForeignKey(pc => pc.IdCarrinho)
                .OnDelete(DeleteBehavior.Cascade);

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
            modelBuilder.Entity<TipoPagamento>().HasData(
                new TipoPagamento { Id = 1, Tipo = "Boleto" },
                new TipoPagamento { Id = 2, Tipo = "Pix" },
                new TipoPagamento { Id = 3, Tipo = "Cartão de crédito" },
                new TipoPagamento { Id = 4, Tipo = "Cartão de débito" }
);

            base.OnModelCreating(modelBuilder);
        }
    }
}
