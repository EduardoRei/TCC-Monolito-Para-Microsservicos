using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Microsservico.Pedido.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class CriandoPedidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoPedido_IdPedido",
                table: "ProdutoPedido",
                column: "IdPedido");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoPedido");

            migrationBuilder.DropTable(
                name: "Pedido");
        }
    }
}
