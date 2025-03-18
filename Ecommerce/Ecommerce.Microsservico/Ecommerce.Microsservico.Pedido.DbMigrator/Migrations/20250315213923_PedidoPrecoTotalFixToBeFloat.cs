using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Microsservico.Pedido.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class PedidoPrecoTotalFixToBeFloat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PrecoTotal",
                table: "Pedido",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "PrecoTotal",
                table: "Pedido",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
