﻿// <auto-generated />
using System;
using Ecommerce.Monolito.DbMigrator.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ecommerce.Monolito.DbMigrator.Migrations
{
    [DbContext(typeof(EcommerceDbContext))]
    partial class EcommerceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ecommerce.Monolito.DbMigrator.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categoria");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Smartphones"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Tablets"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "TVs"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Notebooks"
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Projetores"
                        },
                        new
                        {
                            Id = 6,
                            Nome = "Periféricos"
                        },
                        new
                        {
                            Id = 7,
                            Nome = "Consolers"
                        },
                        new
                        {
                            Id = 8,
                            Nome = "Cameras"
                        });
                });

            modelBuilder.Entity("Ecommerce.Monolito.DbMigrator.Entities.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataPagamento")
                        .HasColumnType("datetime2");

                    b.Property<int>("FormaPagamento")
                        .HasColumnType("int");

                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.Property<int>("StatusPagamento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdPedido")
                        .IsUnique();

                    b.ToTable("Pagamento");
                });

            modelBuilder.Entity("Ecommerce.Monolito.DbMigrator.Entities.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdPagamento")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<long>("PrecoTotal")
                        .HasColumnType("bigint");

                    b.Property<int>("StatusPedido")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("Ecommerce.Monolito.DbMigrator.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PrecoUnitario")
                        .HasColumnType("float");

                    b.Property<int>("QuantidadeEstoque")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Produto");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Smartphone Apple com design avançado e desempenho aprimorado.",
                            IdCategoria = 1,
                            Nome = "iPhone 16",
                            PrecoUnitario = 7999.9899999999998,
                            QuantidadeEstoque = 50
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Novo modelo da Samsung com câmera de última geração.",
                            IdCategoria = 1,
                            Nome = "Samsung Galaxy S24",
                            PrecoUnitario = 7499.9899999999998,
                            QuantidadeEstoque = 40
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "Smartphone com Android puro e excelente qualidade de câmera.",
                            IdCategoria = 1,
                            Nome = "Google Pixel 8",
                            PrecoUnitario = 6899.9899999999998,
                            QuantidadeEstoque = 30
                        },
                        new
                        {
                            Id = 4,
                            Descricao = "Smartphone premium com ótimo custo-benefício.",
                            IdCategoria = 1,
                            Nome = "Xiaomi Mi 13 Pro",
                            PrecoUnitario = 4599.9899999999998,
                            QuantidadeEstoque = 45
                        },
                        new
                        {
                            Id = 5,
                            Descricao = "Tablet de alto desempenho para uso profissional.",
                            IdCategoria = 2,
                            Nome = "iPad Pro",
                            PrecoUnitario = 10999.99,
                            QuantidadeEstoque = 25
                        },
                        new
                        {
                            Id = 6,
                            Descricao = "Tablet Android avançado com tela AMOLED.",
                            IdCategoria = 2,
                            Nome = "Samsung Galaxy Tab S9",
                            PrecoUnitario = 6499.9899999999998,
                            QuantidadeEstoque = 30
                        },
                        new
                        {
                            Id = 7,
                            Descricao = "Tablet com boa performance e ótimo custo-benefício.",
                            IdCategoria = 2,
                            Nome = "Lenovo Tab P11",
                            PrecoUnitario = 1599.99,
                            QuantidadeEstoque = 40
                        },
                        new
                        {
                            Id = 8,
                            Descricao = "TV 4K com tela QLED e conectividade inteligente.",
                            IdCategoria = 3,
                            Nome = "Samsung Smart TV 55\"",
                            PrecoUnitario = 4999.9899999999998,
                            QuantidadeEstoque = 20
                        },
                        new
                        {
                            Id = 9,
                            Descricao = "Tela OLED para uma experiência visual superior.",
                            IdCategoria = 3,
                            Nome = "LG OLED TV 65\"",
                            PrecoUnitario = 9999.9899999999998,
                            QuantidadeEstoque = 15
                        },
                        new
                        {
                            Id = 10,
                            Descricao = "Smart TV com qualidade de imagem excepcional.",
                            IdCategoria = 3,
                            Nome = "Sony Bravia 50\"",
                            PrecoUnitario = 5599.9899999999998,
                            QuantidadeEstoque = 25
                        },
                        new
                        {
                            Id = 11,
                            Descricao = "Notebook de alta performance com design elegante.",
                            IdCategoria = 4,
                            Nome = "Dell XPS 15",
                            PrecoUnitario = 12499.99,
                            QuantidadeEstoque = 20
                        },
                        new
                        {
                            Id = 12,
                            Descricao = "Notebook Apple com chip M2 para máxima eficiência.",
                            IdCategoria = 4,
                            Nome = "MacBook Pro M2",
                            PrecoUnitario = 15999.99,
                            QuantidadeEstoque = 15
                        },
                        new
                        {
                            Id = 13,
                            Descricao = "Notebook gamer com design compacto e poderoso.",
                            IdCategoria = 4,
                            Nome = "Asus ROG Zephyrus",
                            PrecoUnitario = 13999.99,
                            QuantidadeEstoque = 10
                        },
                        new
                        {
                            Id = 14,
                            Descricao = "Projetor com alta resolução e cores vibrantes.",
                            IdCategoria = 5,
                            Nome = "Epson PowerLite",
                            PrecoUnitario = 3499.9899999999998,
                            QuantidadeEstoque = 35
                        },
                        new
                        {
                            Id = 15,
                            Descricao = "Projetor portátil com qualidade de cinema.",
                            IdCategoria = 5,
                            Nome = "LG CineBeam",
                            PrecoUnitario = 4999.9899999999998,
                            QuantidadeEstoque = 25
                        },
                        new
                        {
                            Id = 16,
                            Descricao = "Mouse ergonômico com alta precisão.",
                            IdCategoria = 6,
                            Nome = "Mouse Logitech MX Master 3",
                            PrecoUnitario = 499.99000000000001,
                            QuantidadeEstoque = 60
                        },
                        new
                        {
                            Id = 17,
                            Descricao = "Teclado gamer com iluminação RGB personalizável.",
                            IdCategoria = 6,
                            Nome = "Teclado Mecânico Razer",
                            PrecoUnitario = 899.99000000000001,
                            QuantidadeEstoque = 40
                        },
                        new
                        {
                            Id = 18,
                            Descricao = "Monitor gamer com taxa de atualização de 144Hz.",
                            IdCategoria = 6,
                            Nome = "Monitor LG UltraGear",
                            PrecoUnitario = 1899.99,
                            QuantidadeEstoque = 30
                        },
                        new
                        {
                            Id = 19,
                            Descricao = "Console da Sony com gráficos de última geração.",
                            IdCategoria = 7,
                            Nome = "PlayStation 5",
                            PrecoUnitario = 4999.9899999999998,
                            QuantidadeEstoque = 25
                        },
                        new
                        {
                            Id = 20,
                            Descricao = "Console da Microsoft com alta capacidade de processamento.",
                            IdCategoria = 7,
                            Nome = "Xbox Series X",
                            PrecoUnitario = 4799.9899999999998,
                            QuantidadeEstoque = 20
                        },
                        new
                        {
                            Id = 21,
                            Descricao = "Console híbrido com tela OLED vibrante.",
                            IdCategoria = 7,
                            Nome = "Nintendo Switch OLED",
                            PrecoUnitario = 2899.9899999999998,
                            QuantidadeEstoque = 30
                        },
                        new
                        {
                            Id = 22,
                            Descricao = "Câmera mirrorless com foco automático avançado.",
                            IdCategoria = 8,
                            Nome = "Canon EOS R6",
                            PrecoUnitario = 15999.99,
                            QuantidadeEstoque = 15
                        },
                        new
                        {
                            Id = 23,
                            Descricao = "Câmera versátil para fotógrafos profissionais.",
                            IdCategoria = 8,
                            Nome = "Sony Alpha A7 III",
                            PrecoUnitario = 12999.99,
                            QuantidadeEstoque = 20
                        },
                        new
                        {
                            Id = 24,
                            Descricao = "Câmera de ação para aventuras extremas.",
                            IdCategoria = 8,
                            Nome = "GoPro HERO 12",
                            PrecoUnitario = 2599.9899999999998,
                            QuantidadeEstoque = 50
                        },
                        new
                        {
                            Id = 25,
                            Descricao = "Smartphone com excelente custo-benefício e design premium.",
                            IdCategoria = 1,
                            Nome = "Motorola Edge 40",
                            PrecoUnitario = 3499.9899999999998,
                            QuantidadeEstoque = 35
                        },
                        new
                        {
                            Id = 26,
                            Descricao = "Smartphone com desempenho rápido e carregamento super-rápido.",
                            IdCategoria = 1,
                            Nome = "OnePlus 11",
                            PrecoUnitario = 4999.9899999999998,
                            QuantidadeEstoque = 25
                        },
                        new
                        {
                            Id = 27,
                            Descricao = "Smartphone com foco em fotografia de altíssima qualidade.",
                            IdCategoria = 1,
                            Nome = "Huawei P60 Pro",
                            PrecoUnitario = 5999.9899999999998,
                            QuantidadeEstoque = 20
                        },
                        new
                        {
                            Id = 28,
                            Descricao = "Tablet híbrido com recursos avançados de produtividade.",
                            IdCategoria = 2,
                            Nome = "Microsoft Surface Pro 9",
                            PrecoUnitario = 11999.99,
                            QuantidadeEstoque = 15
                        },
                        new
                        {
                            Id = 29,
                            Descricao = "Tablet acessível e ideal para consumo de mídia.",
                            IdCategoria = 2,
                            Nome = "Amazon Fire HD 10",
                            PrecoUnitario = 1299.99,
                            QuantidadeEstoque = 50
                        },
                        new
                        {
                            Id = 30,
                            Descricao = "Tablet Android premium com foco em design e desempenho.",
                            IdCategoria = 2,
                            Nome = "Huawei MatePad Pro",
                            PrecoUnitario = 3599.9899999999998,
                            QuantidadeEstoque = 30
                        },
                        new
                        {
                            Id = 31,
                            Descricao = "Smart TV Mini LED com excelente qualidade de imagem.",
                            IdCategoria = 3,
                            Nome = "TCL 65C835",
                            PrecoUnitario = 5999.9899999999998,
                            QuantidadeEstoque = 25
                        },
                        new
                        {
                            Id = 32,
                            Descricao = "TV com iluminação ambiente imersiva.",
                            IdCategoria = 3,
                            Nome = "Philips Ambilight 55\"",
                            PrecoUnitario = 5299.9899999999998,
                            QuantidadeEstoque = 20
                        },
                        new
                        {
                            Id = 33,
                            Descricao = "TV com excelente custo-benefício e painel ULED.",
                            IdCategoria = 3,
                            Nome = "Hisense U8H",
                            PrecoUnitario = 4499.9899999999998,
                            QuantidadeEstoque = 30
                        },
                        new
                        {
                            Id = 34,
                            Descricao = "Notebook conversível com design sofisticado.",
                            IdCategoria = 4,
                            Nome = "HP Spectre x360",
                            PrecoUnitario = 11499.99,
                            QuantidadeEstoque = 20
                        },
                        new
                        {
                            Id = 35,
                            Descricao = "Notebook versátil para trabalho e estudo.",
                            IdCategoria = 4,
                            Nome = "Acer Aspire 5",
                            PrecoUnitario = 3999.9899999999998,
                            QuantidadeEstoque = 50
                        },
                        new
                        {
                            Id = 36,
                            Descricao = "Notebook empresarial com construção leve e robusta.",
                            IdCategoria = 4,
                            Nome = "Lenovo ThinkPad X1 Carbon",
                            PrecoUnitario = 13499.99,
                            QuantidadeEstoque = 15
                        },
                        new
                        {
                            Id = 37,
                            Descricao = "Projetor 4K UHD ideal para home theater.",
                            IdCategoria = 5,
                            Nome = "BenQ TK850",
                            PrecoUnitario = 6499.9899999999998,
                            QuantidadeEstoque = 20
                        },
                        new
                        {
                            Id = 38,
                            Descricao = "Projetor portátil com sistema Android integrado.",
                            IdCategoria = 5,
                            Nome = "Xiaomi Mi Smart Projector 2",
                            PrecoUnitario = 3999.9899999999998,
                            QuantidadeEstoque = 30
                        },
                        new
                        {
                            Id = 39,
                            Descricao = "Projetor ultracompacto para projeção em qualquer lugar.",
                            IdCategoria = 5,
                            Nome = "ViewSonic M1 Mini",
                            PrecoUnitario = 1199.99,
                            QuantidadeEstoque = 40
                        },
                        new
                        {
                            Id = 40,
                            Descricao = "Headset gamer com som surround 7.1.",
                            IdCategoria = 6,
                            Nome = "Headset HyperX Cloud II",
                            PrecoUnitario = 499.99000000000001,
                            QuantidadeEstoque = 50
                        },
                        new
                        {
                            Id = 41,
                            Descricao = "Webcam HD para videoconferências.",
                            IdCategoria = 6,
                            Nome = "Webcam Logitech C920",
                            PrecoUnitario = 399.99000000000001,
                            QuantidadeEstoque = 30
                        },
                        new
                        {
                            Id = 42,
                            Descricao = "Teclado compacto e versátil para múltiplos dispositivos.",
                            IdCategoria = 6,
                            Nome = "Teclado sem fio Logitech K780",
                            PrecoUnitario = 299.99000000000001,
                            QuantidadeEstoque = 35
                        },
                        new
                        {
                            Id = 43,
                            Descricao = "Console portátil para jogos de PC.",
                            IdCategoria = 7,
                            Nome = "Steam Deck",
                            PrecoUnitario = 4999.9899999999998,
                            QuantidadeEstoque = 20
                        },
                        new
                        {
                            Id = 44,
                            Descricao = "Console retrô com funcionalidades modernas.",
                            IdCategoria = 7,
                            Nome = "Atari VCS",
                            PrecoUnitario = 1999.99,
                            QuantidadeEstoque = 25
                        },
                        new
                        {
                            Id = 45,
                            Descricao = "Console portátil para streaming de jogos.",
                            IdCategoria = 7,
                            Nome = "Logitech G Cloud",
                            PrecoUnitario = 2999.9899999999998,
                            QuantidadeEstoque = 20
                        },
                        new
                        {
                            Id = 46,
                            Descricao = "Câmera mirrorless para fotógrafos profissionais.",
                            IdCategoria = 8,
                            Nome = "Nikon Z7 II",
                            PrecoUnitario = 17999.990000000002,
                            QuantidadeEstoque = 10
                        },
                        new
                        {
                            Id = 47,
                            Descricao = "Câmera híbrida para foto e vídeo.",
                            IdCategoria = 8,
                            Nome = "Panasonic Lumix GH6",
                            PrecoUnitario = 13999.99,
                            QuantidadeEstoque = 15
                        },
                        new
                        {
                            Id = 48,
                            Descricao = "Câmera compacta com estabilização gimbal.",
                            IdCategoria = 8,
                            Nome = "DJI Osmo Pocket 3",
                            PrecoUnitario = 3499.9899999999998,
                            QuantidadeEstoque = 40
                        },
                        new
                        {
                            Id = 49,
                            Descricao = "Smartphone com tela OLED 4K e câmera profissional.",
                            IdCategoria = 1,
                            Nome = "Sony Xperia 1 V",
                            PrecoUnitario = 5999.9899999999998,
                            QuantidadeEstoque = 15
                        },
                        new
                        {
                            Id = 50,
                            Descricao = "Smartphone gamer com desempenho de alto nível.",
                            IdCategoria = 1,
                            Nome = "Asus ROG Phone 7",
                            PrecoUnitario = 6299.9899999999998,
                            QuantidadeEstoque = 20
                        });
                });

            modelBuilder.Entity("Ecommerce.Monolito.DbMigrator.Entities.ProdutoPedido", b =>
                {
                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade_Produto")
                        .HasColumnType("int");

                    b.HasKey("IdProduto", "IdPedido");

                    b.HasIndex("IdPedido");

                    b.ToTable("ProdutoPedido");
                });

            modelBuilder.Entity("Ecommerce.Monolito.DbMigrator.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCriacaoUsuario")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Ecommerce.Monolito.DbMigrator.Entities.Pagamento", b =>
                {
                    b.HasOne("Ecommerce.Monolito.DbMigrator.Entities.Pedido", "Pedido")
                        .WithOne("Pagamento")
                        .HasForeignKey("Ecommerce.Monolito.DbMigrator.Entities.Pagamento", "IdPedido")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("Ecommerce.Monolito.DbMigrator.Entities.Pedido", b =>
                {
                    b.HasOne("Ecommerce.Monolito.DbMigrator.Entities.Usuario", "Usuario")
                        .WithMany("Pedido")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Ecommerce.Monolito.DbMigrator.Entities.Produto", b =>
                {
                    b.HasOne("Ecommerce.Monolito.DbMigrator.Entities.Categoria", "Categoria")
                        .WithMany("Produto")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Ecommerce.Monolito.DbMigrator.Entities.ProdutoPedido", b =>
                {
                    b.HasOne("Ecommerce.Monolito.DbMigrator.Entities.Pedido", "Pedido")
                        .WithMany("ProdutoPedido")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Ecommerce.Monolito.DbMigrator.Entities.Produto", "Produto")
                        .WithMany("ProdutoPedido")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Ecommerce.Monolito.DbMigrator.Entities.Categoria", b =>
                {
                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Ecommerce.Monolito.DbMigrator.Entities.Pedido", b =>
                {
                    b.Navigation("Pagamento")
                        .IsRequired();

                    b.Navigation("ProdutoPedido");
                });

            modelBuilder.Entity("Ecommerce.Monolito.DbMigrator.Entities.Produto", b =>
                {
                    b.Navigation("ProdutoPedido");
                });

            modelBuilder.Entity("Ecommerce.Monolito.DbMigrator.Entities.Usuario", b =>
                {
                    b.Navigation("Pedido");
                });
#pragma warning restore 612, 618
        }
    }
}
