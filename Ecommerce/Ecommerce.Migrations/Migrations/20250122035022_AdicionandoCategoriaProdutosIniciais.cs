using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoCategoriaProdutosIniciais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "FormaPagamento",
                keyColumn: "Id",
                keyValue: 3,
                column: "Nome",
                value: "Cartão de Crédito");

            migrationBuilder.UpdateData(
                table: "FormaPagamento",
                keyColumn: "Id",
                keyValue: 4,
                column: "Nome",
                value: "Cartão de Débito");

            migrationBuilder.UpdateData(
                table: "StatusPagamento",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: "Aguardando Pagamento");

            migrationBuilder.UpdateData(
                table: "StatusPagamento",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: "Processando Pagamento");

            migrationBuilder.UpdateData(
                table: "StatusPagamento",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: "Pagamento Identificado");

            migrationBuilder.UpdateData(
                table: "StatusPagamento",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: "Pagamento Negado");

            migrationBuilder.UpdateData(
                table: "StatusPedido",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: "Separando Pedido");

            migrationBuilder.UpdateData(
                table: "StatusPedido",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: "Pedido Enviado");

            migrationBuilder.UpdateData(
                table: "StatusPedido",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: "Pedido Entregue");

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Descricao", "IdCategoria", "Nome", "PrecoUnitario", "QuantidadeEstoque" },
                values: new object[,]
                {
                    { 1, "Smartphone Apple com design avançado e desempenho aprimorado.", 1, "iPhone 16", 7999.99m, 50 },
                    { 2, "Novo modelo da Samsung com câmera de última geração.", 1, "Samsung Galaxy S24", 7499.99m, 40 },
                    { 3, "Smartphone com Android puro e excelente qualidade de câmera.", 1, "Google Pixel 8", 6899.99m, 30 },
                    { 4, "Smartphone premium com ótimo custo-benefício.", 1, "Xiaomi Mi 13 Pro", 4599.99m, 45 },
                    { 5, "Tablet de alto desempenho para uso profissional.", 2, "iPad Pro", 10999.99m, 25 },
                    { 6, "Tablet Android avançado com tela AMOLED.", 2, "Samsung Galaxy Tab S9", 6499.99m, 30 },
                    { 7, "Tablet com boa performance e ótimo custo-benefício.", 2, "Lenovo Tab P11", 1599.99m, 40 },
                    { 8, "TV 4K com tela QLED e conectividade inteligente.", 3, "Samsung Smart TV 55\"", 4999.99m, 20 },
                    { 9, "Tela OLED para uma experiência visual superior.", 3, "LG OLED TV 65\"", 9999.99m, 15 },
                    { 10, "Smart TV com qualidade de imagem excepcional.", 3, "Sony Bravia 50\"", 5599.99m, 25 },
                    { 11, "Notebook de alta performance com design elegante.", 4, "Dell XPS 15", 12499.99m, 20 },
                    { 12, "Notebook Apple com chip M2 para máxima eficiência.", 4, "MacBook Pro M2", 15999.99m, 15 },
                    { 13, "Notebook gamer com design compacto e poderoso.", 4, "Asus ROG Zephyrus", 13999.99m, 10 },
                    { 14, "Projetor com alta resolução e cores vibrantes.", 5, "Epson PowerLite", 3499.99m, 35 },
                    { 15, "Projetor portátil com qualidade de cinema.", 5, "LG CineBeam", 4999.99m, 25 },
                    { 16, "Mouse ergonômico com alta precisão.", 6, "Mouse Logitech MX Master 3", 499.99m, 60 },
                    { 17, "Teclado gamer com iluminação RGB personalizável.", 6, "Teclado Mecânico Razer", 899.99m, 40 },
                    { 18, "Monitor gamer com taxa de atualização de 144Hz.", 6, "Monitor LG UltraGear", 1899.99m, 30 },
                    { 19, "Console da Sony com gráficos de última geração.", 7, "PlayStation 5", 4999.99m, 25 },
                    { 20, "Console da Microsoft com alta capacidade de processamento.", 7, "Xbox Series X", 4799.99m, 20 },
                    { 21, "Console híbrido com tela OLED vibrante.", 7, "Nintendo Switch OLED", 2899.99m, 30 },
                    { 22, "Câmera mirrorless com foco automático avançado.", 8, "Canon EOS R6", 15999.99m, 15 },
                    { 23, "Câmera versátil para fotógrafos profissionais.", 8, "Sony Alpha A7 III", 12999.99m, 20 },
                    { 24, "Câmera de ação para aventuras extremas.", 8, "GoPro HERO 12", 2599.99m, 50 },
                    { 25, "Smartphone com excelente custo-benefício e design premium.", 1, "Motorola Edge 40", 3499.99m, 35 },
                    { 26, "Smartphone com desempenho rápido e carregamento super-rápido.", 1, "OnePlus 11", 4999.99m, 25 },
                    { 27, "Smartphone com foco em fotografia de altíssima qualidade.", 1, "Huawei P60 Pro", 5999.99m, 20 },
                    { 28, "Tablet híbrido com recursos avançados de produtividade.", 2, "Microsoft Surface Pro 9", 11999.99m, 15 },
                    { 29, "Tablet acessível e ideal para consumo de mídia.", 2, "Amazon Fire HD 10", 1299.99m, 50 },
                    { 30, "Tablet Android premium com foco em design e desempenho.", 2, "Huawei MatePad Pro", 3599.99m, 30 },
                    { 31, "Smart TV Mini LED com excelente qualidade de imagem.", 3, "TCL 65C835", 5999.99m, 25 },
                    { 32, "TV com iluminação ambiente imersiva.", 3, "Philips Ambilight 55\"", 5299.99m, 20 },
                    { 33, "TV com excelente custo-benefício e painel ULED.", 3, "Hisense U8H", 4499.99m, 30 },
                    { 34, "Notebook conversível com design sofisticado.", 4, "HP Spectre x360", 11499.99m, 20 },
                    { 35, "Notebook versátil para trabalho e estudo.", 4, "Acer Aspire 5", 3999.99m, 50 },
                    { 36, "Notebook empresarial com construção leve e robusta.", 4, "Lenovo ThinkPad X1 Carbon", 13499.99m, 15 },
                    { 37, "Projetor 4K UHD ideal para home theater.", 5, "BenQ TK850", 6499.99m, 20 },
                    { 38, "Projetor portátil com sistema Android integrado.", 5, "Xiaomi Mi Smart Projector 2", 3999.99m, 30 },
                    { 39, "Projetor ultracompacto para projeção em qualquer lugar.", 5, "ViewSonic M1 Mini", 1199.99m, 40 },
                    { 40, "Headset gamer com som surround 7.1.", 6, "Headset HyperX Cloud II", 499.99m, 50 },
                    { 41, "Webcam HD para videoconferências.", 6, "Webcam Logitech C920", 399.99m, 30 },
                    { 42, "Teclado compacto e versátil para múltiplos dispositivos.", 6, "Teclado sem fio Logitech K780", 299.99m, 35 },
                    { 43, "Console portátil para jogos de PC.", 7, "Steam Deck", 4999.99m, 20 },
                    { 44, "Console retrô com funcionalidades modernas.", 7, "Atari VCS", 1999.99m, 25 },
                    { 45, "Console portátil para streaming de jogos.", 7, "Logitech G Cloud", 2999.99m, 20 },
                    { 46, "Câmera mirrorless para fotógrafos profissionais.", 8, "Nikon Z7 II", 17999.99m, 10 },
                    { 47, "Câmera híbrida para foto e vídeo.", 8, "Panasonic Lumix GH6", 13999.99m, 15 },
                    { 48, "Câmera compacta com estabilização gimbal.", 8, "DJI Osmo Pocket 3", 3499.99m, 40 },
                    { 49, "Smartphone com tela OLED 4K e câmera profissional.", 1, "Sony Xperia 1 V", 5999.99m, 15 },
                    { 50, "Smartphone gamer com desempenho de alto nível.", 1, "Asus ROG Phone 7", 6299.99m, 20 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "FormaPagamento",
                keyColumn: "Id",
                keyValue: 3,
                column: "Nome",
                value: "Cartão de crédito");

            migrationBuilder.UpdateData(
                table: "FormaPagamento",
                keyColumn: "Id",
                keyValue: 4,
                column: "Nome",
                value: "Cartão de débito");

            migrationBuilder.UpdateData(
                table: "StatusPagamento",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: "Aguardando pagamento");

            migrationBuilder.UpdateData(
                table: "StatusPagamento",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: "Processando pagamento");

            migrationBuilder.UpdateData(
                table: "StatusPagamento",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: "Pagamento identificado");

            migrationBuilder.UpdateData(
                table: "StatusPagamento",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: "Pagamento negado");

            migrationBuilder.UpdateData(
                table: "StatusPedido",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: "Separando pedido");

            migrationBuilder.UpdateData(
                table: "StatusPedido",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: "Pedido enviado");

            migrationBuilder.UpdateData(
                table: "StatusPedido",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: "Pedido entregue");
        }
    }
}
