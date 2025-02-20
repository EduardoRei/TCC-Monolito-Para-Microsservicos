using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Monolito.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCriacaoUsuario = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantidadeEstoque = table.Column<int>(type: "int", nullable: false),
                    PrecoUnitario = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Categoria_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdPagamento = table.Column<int>(type: "int", nullable: false),
                    StatusPedido = table.Column<int>(type: "int", nullable: false),
                    PrecoTotal = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPedido = table.Column<int>(type: "int", nullable: false),
                    StatusPagamento = table.Column<int>(type: "int", nullable: false),
                    FormaPagamento = table.Column<int>(type: "int", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamento_Pedido_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoPedido",
                columns: table => new
                {
                    IdPedido = table.Column<int>(type: "int", nullable: false),
                    IdProduto = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Quantidade_Produto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoPedido", x => new { x.IdProduto, x.IdPedido });
                    table.ForeignKey(
                        name: "FK_ProdutoPedido_Pedido_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProdutoPedido_Produto_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Smartphones" },
                    { 2, "Tablets" },
                    { 3, "TVs" },
                    { 4, "Notebooks" },
                    { 5, "Projetores" },
                    { 6, "Periféricos" },
                    { 7, "Consolers" },
                    { 8, "Cameras" }
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Descricao", "IdCategoria", "Nome", "PrecoUnitario", "QuantidadeEstoque" },
                values: new object[,]
                {
                    { 1, "Smartphone Apple com design avançado e desempenho aprimorado.", 1, "iPhone 16", 7999.9899999999998, 50 },
                    { 2, "Novo modelo da Samsung com câmera de última geração.", 1, "Samsung Galaxy S24", 7499.9899999999998, 40 },
                    { 3, "Smartphone com Android puro e excelente qualidade de câmera.", 1, "Google Pixel 8", 6899.9899999999998, 30 },
                    { 4, "Smartphone premium com ótimo custo-benefício.", 1, "Xiaomi Mi 13 Pro", 4599.9899999999998, 45 },
                    { 5, "Tablet de alto desempenho para uso profissional.", 2, "iPad Pro", 10999.99, 25 },
                    { 6, "Tablet Android avançado com tela AMOLED.", 2, "Samsung Galaxy Tab S9", 6499.9899999999998, 30 },
                    { 7, "Tablet com boa performance e ótimo custo-benefício.", 2, "Lenovo Tab P11", 1599.99, 40 },
                    { 8, "TV 4K com tela QLED e conectividade inteligente.", 3, "Samsung Smart TV 55\"", 4999.9899999999998, 20 },
                    { 9, "Tela OLED para uma experiência visual superior.", 3, "LG OLED TV 65\"", 9999.9899999999998, 15 },
                    { 10, "Smart TV com qualidade de imagem excepcional.", 3, "Sony Bravia 50\"", 5599.9899999999998, 25 },
                    { 11, "Notebook de alta performance com design elegante.", 4, "Dell XPS 15", 12499.99, 20 },
                    { 12, "Notebook Apple com chip M2 para máxima eficiência.", 4, "MacBook Pro M2", 15999.99, 15 },
                    { 13, "Notebook gamer com design compacto e poderoso.", 4, "Asus ROG Zephyrus", 13999.99, 10 },
                    { 14, "Projetor com alta resolução e cores vibrantes.", 5, "Epson PowerLite", 3499.9899999999998, 35 },
                    { 15, "Projetor portátil com qualidade de cinema.", 5, "LG CineBeam", 4999.9899999999998, 25 },
                    { 16, "Mouse ergonômico com alta precisão.", 6, "Mouse Logitech MX Master 3", 499.99000000000001, 60 },
                    { 17, "Teclado gamer com iluminação RGB personalizável.", 6, "Teclado Mecânico Razer", 899.99000000000001, 40 },
                    { 18, "Monitor gamer com taxa de atualização de 144Hz.", 6, "Monitor LG UltraGear", 1899.99, 30 },
                    { 19, "Console da Sony com gráficos de última geração.", 7, "PlayStation 5", 4999.9899999999998, 25 },
                    { 20, "Console da Microsoft com alta capacidade de processamento.", 7, "Xbox Series X", 4799.9899999999998, 20 },
                    { 21, "Console híbrido com tela OLED vibrante.", 7, "Nintendo Switch OLED", 2899.9899999999998, 30 },
                    { 22, "Câmera mirrorless com foco automático avançado.", 8, "Canon EOS R6", 15999.99, 15 },
                    { 23, "Câmera versátil para fotógrafos profissionais.", 8, "Sony Alpha A7 III", 12999.99, 20 },
                    { 24, "Câmera de ação para aventuras extremas.", 8, "GoPro HERO 12", 2599.9899999999998, 50 },
                    { 25, "Smartphone com excelente custo-benefício e design premium.", 1, "Motorola Edge 40", 3499.9899999999998, 35 },
                    { 26, "Smartphone com desempenho rápido e carregamento super-rápido.", 1, "OnePlus 11", 4999.9899999999998, 25 },
                    { 27, "Smartphone com foco em fotografia de altíssima qualidade.", 1, "Huawei P60 Pro", 5999.9899999999998, 20 },
                    { 28, "Tablet híbrido com recursos avançados de produtividade.", 2, "Microsoft Surface Pro 9", 11999.99, 15 },
                    { 29, "Tablet acessível e ideal para consumo de mídia.", 2, "Amazon Fire HD 10", 1299.99, 50 },
                    { 30, "Tablet Android premium com foco em design e desempenho.", 2, "Huawei MatePad Pro", 3599.9899999999998, 30 },
                    { 31, "Smart TV Mini LED com excelente qualidade de imagem.", 3, "TCL 65C835", 5999.9899999999998, 25 },
                    { 32, "TV com iluminação ambiente imersiva.", 3, "Philips Ambilight 55\"", 5299.9899999999998, 20 },
                    { 33, "TV com excelente custo-benefício e painel ULED.", 3, "Hisense U8H", 4499.9899999999998, 30 },
                    { 34, "Notebook conversível com design sofisticado.", 4, "HP Spectre x360", 11499.99, 20 },
                    { 35, "Notebook versátil para trabalho e estudo.", 4, "Acer Aspire 5", 3999.9899999999998, 50 },
                    { 36, "Notebook empresarial com construção leve e robusta.", 4, "Lenovo ThinkPad X1 Carbon", 13499.99, 15 },
                    { 37, "Projetor 4K UHD ideal para home theater.", 5, "BenQ TK850", 6499.9899999999998, 20 },
                    { 38, "Projetor portátil com sistema Android integrado.", 5, "Xiaomi Mi Smart Projector 2", 3999.9899999999998, 30 },
                    { 39, "Projetor ultracompacto para projeção em qualquer lugar.", 5, "ViewSonic M1 Mini", 1199.99, 40 },
                    { 40, "Headset gamer com som surround 7.1.", 6, "Headset HyperX Cloud II", 499.99000000000001, 50 },
                    { 41, "Webcam HD para videoconferências.", 6, "Webcam Logitech C920", 399.99000000000001, 30 },
                    { 42, "Teclado compacto e versátil para múltiplos dispositivos.", 6, "Teclado sem fio Logitech K780", 299.99000000000001, 35 },
                    { 43, "Console portátil para jogos de PC.", 7, "Steam Deck", 4999.9899999999998, 20 },
                    { 44, "Console retrô com funcionalidades modernas.", 7, "Atari VCS", 1999.99, 25 },
                    { 45, "Console portátil para streaming de jogos.", 7, "Logitech G Cloud", 2999.9899999999998, 20 },
                    { 46, "Câmera mirrorless para fotógrafos profissionais.", 8, "Nikon Z7 II", 17999.990000000002, 10 },
                    { 47, "Câmera híbrida para foto e vídeo.", 8, "Panasonic Lumix GH6", 13999.99, 15 },
                    { 48, "Câmera compacta com estabilização gimbal.", 8, "DJI Osmo Pocket 3", 3499.9899999999998, 40 },
                    { 49, "Smartphone com tela OLED 4K e câmera profissional.", 1, "Sony Xperia 1 V", 5999.9899999999998, 15 },
                    { 50, "Smartphone gamer com desempenho de alto nível.", 1, "Asus ROG Phone 7", 6299.9899999999998, 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_IdPedido",
                table: "Pagamento",
                column: "IdPedido",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdUsuario",
                table: "Pedido",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_IdCategoria",
                table: "Produto",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoPedido_IdPedido",
                table: "ProdutoPedido",
                column: "IdPedido");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "ProdutoPedido");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
