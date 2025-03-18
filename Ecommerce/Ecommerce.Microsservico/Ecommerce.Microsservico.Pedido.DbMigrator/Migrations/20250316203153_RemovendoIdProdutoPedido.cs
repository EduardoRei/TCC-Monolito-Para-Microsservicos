using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Microsservico.Pedido.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class RemovendoIdProdutoPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutoPedido",
                table: "ProdutoPedido");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProdutoPedido");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutoPedido",
                table: "ProdutoPedido",
                columns: new[] { "IdProduto", "IdPedido" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutoPedido",
                table: "ProdutoPedido");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProdutoPedido",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutoPedido",
                table: "ProdutoPedido",
                column: "Id");
        }
    }
}
