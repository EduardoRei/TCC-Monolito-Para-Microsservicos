using Ecommerce.Commons.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Ecommerce.Monolito.DbMigrator.Context
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
                .OnDelete(DeleteBehavior.Restrict); // Evitar cascata na exclusão de pagamentos de um usuári


            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nome = "Smartphones" },
                new Categoria { Id = 2, Nome = "Tablets" },
                new Categoria { Id = 3, Nome = "TVs" },
                new Categoria { Id = 4, Nome = "Notebooks" },
                new Categoria { Id = 5, Nome = "Projetores" },
                new Categoria { Id = 6, Nome = "Periféricos" },
                new Categoria { Id = 7, Nome = "Consolers" },
                new Categoria { Id = 8, Nome = "Cameras" }
            );

            modelBuilder.Entity<Produto>().HasData(
                new Produto { Id = 1, IdCategoria = 1, Nome = "iPhone 16", Descricao = "Smartphone Apple com design avançado e desempenho aprimorado.", QuantidadeEstoque = 50, PrecoUnitario = 7999.99 },
                new Produto { Id = 2, IdCategoria = 1, Nome = "Samsung Galaxy S24", Descricao = "Novo modelo da Samsung com câmera de última geração.", QuantidadeEstoque = 40, PrecoUnitario = 7499.99 },
                new Produto { Id = 3, IdCategoria = 1, Nome = "Google Pixel 8", Descricao = "Smartphone com Android puro e excelente qualidade de câmera.", QuantidadeEstoque = 30, PrecoUnitario = 6899.99 },
                new Produto { Id = 4, IdCategoria = 1, Nome = "Xiaomi Mi 13 Pro", Descricao = "Smartphone premium com ótimo custo-benefício.", QuantidadeEstoque = 45, PrecoUnitario = 4599.99 },
                new Produto { Id = 5, IdCategoria = 2, Nome = "iPad Pro", Descricao = "Tablet de alto desempenho para uso profissional.", QuantidadeEstoque = 25, PrecoUnitario = 10999.99 },
                new Produto { Id = 6, IdCategoria = 2, Nome = "Samsung Galaxy Tab S9", Descricao = "Tablet Android avançado com tela AMOLED.", QuantidadeEstoque = 30, PrecoUnitario = 6499.99 },
                new Produto { Id = 7, IdCategoria = 2, Nome = "Lenovo Tab P11", Descricao = "Tablet com boa performance e ótimo custo-benefício.", QuantidadeEstoque = 40, PrecoUnitario = 1599.99 },
                new Produto { Id = 8, IdCategoria = 3, Nome = "Samsung Smart TV 55\"", Descricao = "TV 4K com tela QLED e conectividade inteligente.", QuantidadeEstoque = 20, PrecoUnitario = 4999.99 },
                new Produto { Id = 9, IdCategoria = 3, Nome = "LG OLED TV 65\"", Descricao = "Tela OLED para uma experiência visual superior.", QuantidadeEstoque = 15, PrecoUnitario = 9999.99 },
                new Produto { Id = 10, IdCategoria = 3, Nome = "Sony Bravia 50\"", Descricao = "Smart TV com qualidade de imagem excepcional.", QuantidadeEstoque = 25, PrecoUnitario = 5599.99 },
                new Produto { Id = 11, IdCategoria = 4, Nome = "Dell XPS 15", Descricao = "Notebook de alta performance com design elegante.", QuantidadeEstoque = 20, PrecoUnitario = 12499.99 },
                new Produto { Id = 12, IdCategoria = 4, Nome = "MacBook Pro M2", Descricao = "Notebook Apple com chip M2 para máxima eficiência.", QuantidadeEstoque = 15, PrecoUnitario = 15999.99 },
                new Produto { Id = 13, IdCategoria = 4, Nome = "Asus ROG Zephyrus", Descricao = "Notebook gamer com design compacto e poderoso.", QuantidadeEstoque = 10, PrecoUnitario = 13999.99 },
                new Produto { Id = 14, IdCategoria = 5, Nome = "Epson PowerLite", Descricao = "Projetor com alta resolução e cores vibrantes.", QuantidadeEstoque = 35, PrecoUnitario = 3499.99 },
                new Produto { Id = 15, IdCategoria = 5, Nome = "LG CineBeam", Descricao = "Projetor portátil com qualidade de cinema.", QuantidadeEstoque = 25, PrecoUnitario = 4999.99 },
                new Produto { Id = 16, IdCategoria = 6, Nome = "Mouse Logitech MX Master 3", Descricao = "Mouse ergonômico com alta precisão.", QuantidadeEstoque = 60, PrecoUnitario = 499.99 },
                new Produto { Id = 17, IdCategoria = 6, Nome = "Teclado Mecânico Razer", Descricao = "Teclado gamer com iluminação RGB personalizável.", QuantidadeEstoque = 40, PrecoUnitario = 899.99 },
                new Produto { Id = 18, IdCategoria = 6, Nome = "Monitor LG UltraGear", Descricao = "Monitor gamer com taxa de atualização de 144Hz.", QuantidadeEstoque = 30, PrecoUnitario = 1899.99 },
                new Produto { Id = 19, IdCategoria = 7, Nome = "PlayStation 5", Descricao = "Console da Sony com gráficos de última geração.", QuantidadeEstoque = 25, PrecoUnitario = 4999.99 },
                new Produto { Id = 20, IdCategoria = 7, Nome = "Xbox Series X", Descricao = "Console da Microsoft com alta capacidade de processamento.", QuantidadeEstoque = 20, PrecoUnitario = 4799.99 },
                new Produto { Id = 21, IdCategoria = 7, Nome = "Nintendo Switch OLED", Descricao = "Console híbrido com tela OLED vibrante.", QuantidadeEstoque = 30, PrecoUnitario = 2899.99 },
                new Produto { Id = 22, IdCategoria = 8, Nome = "Canon EOS R6", Descricao = "Câmera mirrorless com foco automático avançado.", QuantidadeEstoque = 15, PrecoUnitario = 15999.99 },
                new Produto { Id = 23, IdCategoria = 8, Nome = "Sony Alpha A7 III", Descricao = "Câmera versátil para fotógrafos profissionais.", QuantidadeEstoque = 20, PrecoUnitario = 12999.99 },
                new Produto { Id = 24, IdCategoria = 8, Nome = "GoPro HERO 12", Descricao = "Câmera de ação para aventuras extremas.", QuantidadeEstoque = 50, PrecoUnitario = 2599.99 },
                new Produto { Id = 25, IdCategoria = 1, Nome = "Motorola Edge 40", Descricao = "Smartphone com excelente custo-benefício e design premium.", QuantidadeEstoque = 35, PrecoUnitario = 3499.99 },
                new Produto { Id = 26, IdCategoria = 1, Nome = "OnePlus 11", Descricao = "Smartphone com desempenho rápido e carregamento super-rápido.", QuantidadeEstoque = 25, PrecoUnitario = 4999.99 },
                new Produto { Id = 27, IdCategoria = 1, Nome = "Huawei P60 Pro", Descricao = "Smartphone com foco em fotografia de altíssima qualidade.", QuantidadeEstoque = 20, PrecoUnitario = 5999.99 },
                new Produto { Id = 28, IdCategoria = 2, Nome = "Microsoft Surface Pro 9", Descricao = "Tablet híbrido com recursos avançados de produtividade.", QuantidadeEstoque = 15, PrecoUnitario = 11999.99 },
                new Produto { Id = 29, IdCategoria = 2, Nome = "Amazon Fire HD 10", Descricao = "Tablet acessível e ideal para consumo de mídia.", QuantidadeEstoque = 50, PrecoUnitario = 1299.99 },
                new Produto { Id = 30, IdCategoria = 2, Nome = "Huawei MatePad Pro", Descricao = "Tablet Android premium com foco em design e desempenho.", QuantidadeEstoque = 30, PrecoUnitario = 3599.99 },
                new Produto { Id = 31, IdCategoria = 3, Nome = "TCL 65C835", Descricao = "Smart TV Mini LED com excelente qualidade de imagem.", QuantidadeEstoque = 25, PrecoUnitario = 5999.99 },
                new Produto { Id = 32, IdCategoria = 3, Nome = "Philips Ambilight 55\"", Descricao = "TV com iluminação ambiente imersiva.", QuantidadeEstoque = 20, PrecoUnitario = 5299.99 },
                new Produto { Id = 33, IdCategoria = 3, Nome = "Hisense U8H", Descricao = "TV com excelente custo-benefício e painel ULED.", QuantidadeEstoque = 30, PrecoUnitario = 4499.99 },
                new Produto { Id = 34, IdCategoria = 4, Nome = "HP Spectre x360", Descricao = "Notebook conversível com design sofisticado.", QuantidadeEstoque = 20, PrecoUnitario = 11499.99 },
                new Produto { Id = 35, IdCategoria = 4, Nome = "Acer Aspire 5", Descricao = "Notebook versátil para trabalho e estudo.", QuantidadeEstoque = 50, PrecoUnitario = 3999.99 },
                new Produto { Id = 36, IdCategoria = 4, Nome = "Lenovo ThinkPad X1 Carbon", Descricao = "Notebook empresarial com construção leve e robusta.", QuantidadeEstoque = 15, PrecoUnitario = 13499.99 },
                new Produto { Id = 37, IdCategoria = 5, Nome = "BenQ TK850", Descricao = "Projetor 4K UHD ideal para home theater.", QuantidadeEstoque = 20, PrecoUnitario = 6499.99 },
                new Produto { Id = 38, IdCategoria = 5, Nome = "Xiaomi Mi Smart Projector 2", Descricao = "Projetor portátil com sistema Android integrado.", QuantidadeEstoque = 30, PrecoUnitario = 3999.99 },
                new Produto { Id = 39, IdCategoria = 5, Nome = "ViewSonic M1 Mini", Descricao = "Projetor ultracompacto para projeção em qualquer lugar.", QuantidadeEstoque = 40, PrecoUnitario = 1199.99 },
                new Produto { Id = 40, IdCategoria = 6, Nome = "Headset HyperX Cloud II", Descricao = "Headset gamer com som surround 7.1.", QuantidadeEstoque = 50, PrecoUnitario = 499.99 },
                new Produto { Id = 41, IdCategoria = 6, Nome = "Webcam Logitech C920", Descricao = "Webcam HD para videoconferências.", QuantidadeEstoque = 30, PrecoUnitario = 399.99 },
                new Produto { Id = 42, IdCategoria = 6, Nome = "Teclado sem fio Logitech K780", Descricao = "Teclado compacto e versátil para múltiplos dispositivos.", QuantidadeEstoque = 35, PrecoUnitario = 299.99 },
                new Produto { Id = 43, IdCategoria = 7, Nome = "Steam Deck", Descricao = "Console portátil para jogos de PC.", QuantidadeEstoque = 20, PrecoUnitario = 4999.99 },
                new Produto { Id = 44, IdCategoria = 7, Nome = "Atari VCS", Descricao = "Console retrô com funcionalidades modernas.", QuantidadeEstoque = 25, PrecoUnitario = 1999.99 },
                new Produto { Id = 45, IdCategoria = 7, Nome = "Logitech G Cloud", Descricao = "Console portátil para streaming de jogos.", QuantidadeEstoque = 20, PrecoUnitario = 2999.99 },
                new Produto { Id = 46, IdCategoria = 8, Nome = "Nikon Z7 II", Descricao = "Câmera mirrorless para fotógrafos profissionais.", QuantidadeEstoque = 10, PrecoUnitario = 17999.99 },
                new Produto { Id = 47, IdCategoria = 8, Nome = "Panasonic Lumix GH6", Descricao = "Câmera híbrida para foto e vídeo.", QuantidadeEstoque = 15, PrecoUnitario = 13999.99 },
                new Produto { Id = 48, IdCategoria = 8, Nome = "DJI Osmo Pocket 3", Descricao = "Câmera compacta com estabilização gimbal.", QuantidadeEstoque = 40, PrecoUnitario = 3499.99 },
                new Produto { Id = 49, IdCategoria = 1, Nome = "Sony Xperia 1 V", Descricao = "Smartphone com tela OLED 4K e câmera profissional.", QuantidadeEstoque = 15, PrecoUnitario = 5999.99 },
                new Produto { Id = 50, IdCategoria = 1, Nome = "Asus ROG Phone 7", Descricao = "Smartphone gamer com desempenho de alto nível.", QuantidadeEstoque = 20, PrecoUnitario = 6299.99 }

            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
