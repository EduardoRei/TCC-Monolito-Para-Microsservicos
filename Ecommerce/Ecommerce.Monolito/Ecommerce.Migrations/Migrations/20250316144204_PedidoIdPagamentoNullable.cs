using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Monolito.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class PedidoIdPagamentoNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdPagamento",
                table: "Pedido",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 42, 4, 440, DateTimeKind.Local).AddTicks(6438));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 42, 4, 442, DateTimeKind.Local).AddTicks(4734));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 42, 4, 442, DateTimeKind.Local).AddTicks(4755));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 42, 4, 442, DateTimeKind.Local).AddTicks(4759));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 42, 4, 442, DateTimeKind.Local).AddTicks(4761));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 42, 4, 442, DateTimeKind.Local).AddTicks(4764));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 42, 4, 442, DateTimeKind.Local).AddTicks(4801));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 8,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 42, 4, 442, DateTimeKind.Local).AddTicks(4804));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 9,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 42, 4, 442, DateTimeKind.Local).AddTicks(4806));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 10,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 42, 4, 442, DateTimeKind.Local).AddTicks(4809));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 11,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 42, 4, 442, DateTimeKind.Local).AddTicks(4811));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 12,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 42, 4, 442, DateTimeKind.Local).AddTicks(4814));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 13,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 42, 4, 442, DateTimeKind.Local).AddTicks(4816));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 14,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 42, 4, 442, DateTimeKind.Local).AddTicks(4818));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 15,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 42, 4, 442, DateTimeKind.Local).AddTicks(4821));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 16,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 42, 4, 442, DateTimeKind.Local).AddTicks(4823));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 17,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 42, 4, 442, DateTimeKind.Local).AddTicks(4825));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 18,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 42, 4, 442, DateTimeKind.Local).AddTicks(4828));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 19,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 42, 4, 442, DateTimeKind.Local).AddTicks(4830));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 20,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 42, 4, 442, DateTimeKind.Local).AddTicks(4833));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdPagamento",
                table: "Pedido",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 39, 53, 746, DateTimeKind.Local).AddTicks(4757));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 39, 53, 748, DateTimeKind.Local).AddTicks(2645));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 39, 53, 748, DateTimeKind.Local).AddTicks(2654));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 39, 53, 748, DateTimeKind.Local).AddTicks(2680));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 39, 53, 748, DateTimeKind.Local).AddTicks(2682));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 39, 53, 748, DateTimeKind.Local).AddTicks(2684));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 39, 53, 748, DateTimeKind.Local).AddTicks(2685));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 8,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 39, 53, 748, DateTimeKind.Local).AddTicks(2686));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 9,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 39, 53, 748, DateTimeKind.Local).AddTicks(2688));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 10,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 39, 53, 748, DateTimeKind.Local).AddTicks(2689));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 11,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 39, 53, 748, DateTimeKind.Local).AddTicks(2691));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 12,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 39, 53, 748, DateTimeKind.Local).AddTicks(2692));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 13,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 39, 53, 748, DateTimeKind.Local).AddTicks(2693));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 14,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 39, 53, 748, DateTimeKind.Local).AddTicks(2695));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 15,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 39, 53, 748, DateTimeKind.Local).AddTicks(2696));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 16,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 39, 53, 748, DateTimeKind.Local).AddTicks(2698));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 17,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 39, 53, 748, DateTimeKind.Local).AddTicks(2700));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 18,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 39, 53, 748, DateTimeKind.Local).AddTicks(2702));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 19,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 39, 53, 748, DateTimeKind.Local).AddTicks(2703));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 20,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 11, 39, 53, 748, DateTimeKind.Local).AddTicks(2704));
        }
    }
}
