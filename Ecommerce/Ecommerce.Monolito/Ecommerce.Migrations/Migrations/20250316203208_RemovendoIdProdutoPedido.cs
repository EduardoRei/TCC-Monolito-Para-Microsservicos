using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Monolito.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class RemovendoIdProdutoPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 17, 32, 7, 626, DateTimeKind.Local).AddTicks(6284));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 2,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 17, 32, 7, 628, DateTimeKind.Local).AddTicks(456));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 17, 32, 7, 628, DateTimeKind.Local).AddTicks(465));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 4,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 17, 32, 7, 628, DateTimeKind.Local).AddTicks(467));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 17, 32, 7, 628, DateTimeKind.Local).AddTicks(468));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 17, 32, 7, 628, DateTimeKind.Local).AddTicks(470));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 17, 32, 7, 628, DateTimeKind.Local).AddTicks(495));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 8,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 17, 32, 7, 628, DateTimeKind.Local).AddTicks(497));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 9,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 17, 32, 7, 628, DateTimeKind.Local).AddTicks(498));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 10,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 17, 32, 7, 628, DateTimeKind.Local).AddTicks(499));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 11,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 17, 32, 7, 628, DateTimeKind.Local).AddTicks(501));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 12,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 17, 32, 7, 628, DateTimeKind.Local).AddTicks(502));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 13,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 17, 32, 7, 628, DateTimeKind.Local).AddTicks(504));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 14,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 17, 32, 7, 628, DateTimeKind.Local).AddTicks(505));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 15,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 17, 32, 7, 628, DateTimeKind.Local).AddTicks(506));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 16,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 17, 32, 7, 628, DateTimeKind.Local).AddTicks(508));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 17,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 17, 32, 7, 628, DateTimeKind.Local).AddTicks(509));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 18,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 17, 32, 7, 628, DateTimeKind.Local).AddTicks(511));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 19,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 17, 32, 7, 628, DateTimeKind.Local).AddTicks(512));

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 20,
                column: "DataCriacaoUsuario",
                value: new DateTime(2025, 3, 16, 17, 32, 7, 628, DateTimeKind.Local).AddTicks(514));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
