using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Microsservico.Usuario.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "CPF", "DataCriacaoUsuario", "DataNascimento", "Email", "Endereco", "Nome", "Senha" },
                values: new object[,]
                {
                    { 1, "12345678901", new DateTime(2025, 3, 15, 19, 24, 14, 399, DateTimeKind.Local).AddTicks(3761), new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "joao.silva@example.com", "Rua A, 123", "João Silva", "senha123" },
                    { 2, "23456789012", new DateTime(2025, 3, 15, 19, 24, 14, 400, DateTimeKind.Local).AddTicks(9264), new DateTime(1992, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "maria.souza@example.com", "Rua B, 456", "Maria Souza", "senha123" },
                    { 3, "34567890123", new DateTime(2025, 3, 15, 19, 24, 14, 400, DateTimeKind.Local).AddTicks(9302), new DateTime(1985, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "carlos.pereira@example.com", "Rua C, 789", "Carlos Pereira", "senha123" },
                    { 4, "45678901234", new DateTime(2025, 3, 15, 19, 24, 14, 400, DateTimeKind.Local).AddTicks(9305), new DateTime(1988, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "ana.costa@example.com", "Rua D, 101", "Ana Costa", "senha123" },
                    { 5, "56789012345", new DateTime(2025, 3, 15, 19, 24, 14, 400, DateTimeKind.Local).AddTicks(9308), new DateTime(1995, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "pedro.almeida@example.com", "Rua E, 202", "Pedro Almeida", "senha123" },
                    { 6, "67890123456", new DateTime(2025, 3, 15, 19, 24, 14, 400, DateTimeKind.Local).AddTicks(9311), new DateTime(1993, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "juliana.santos@example.com", "Rua F, 303", "Juliana Santos", "senha123" },
                    { 7, "78901234567", new DateTime(2025, 3, 15, 19, 24, 14, 400, DateTimeKind.Local).AddTicks(9376), new DateTime(1987, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "rafael.oliveira@example.com", "Rua G, 404", "Rafael Oliveira", "senha123" },
                    { 8, "89012345678", new DateTime(2025, 3, 15, 19, 24, 14, 400, DateTimeKind.Local).AddTicks(9379), new DateTime(1991, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "fernanda.lima@example.com", "Rua H, 505", "Fernanda Lima", "senha123" },
                    { 9, "90123456789", new DateTime(2025, 3, 15, 19, 24, 14, 400, DateTimeKind.Local).AddTicks(9382), new DateTime(1994, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "lucas.rocha@example.com", "Rua I, 606", "Lucas Rocha", "senha123" },
                    { 10, "01234567890", new DateTime(2025, 3, 15, 19, 24, 14, 400, DateTimeKind.Local).AddTicks(9385), new DateTime(1989, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "mariana.ribeiro@example.com", "Rua J, 707", "Mariana Ribeiro", "senha123" },
                    { 11, "11234567890", new DateTime(2025, 3, 15, 19, 24, 14, 400, DateTimeKind.Local).AddTicks(9387), new DateTime(1996, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "bruno.fernandes@example.com", "Rua K, 808", "Bruno Fernandes", "senha123" },
                    { 12, "12234567890", new DateTime(2025, 3, 15, 19, 24, 14, 400, DateTimeKind.Local).AddTicks(9390), new DateTime(1997, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "patricia.gomes@example.com", "Rua L, 909", "Patricia Gomes", "senha123" },
                    { 13, "13234567890", new DateTime(2025, 3, 15, 19, 24, 14, 400, DateTimeKind.Local).AddTicks(9392), new DateTime(1986, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "rodrigo.martins@example.com", "Rua M, 1010", "Rodrigo Martins", "senha123" },
                    { 14, "14234567890", new DateTime(2025, 3, 15, 19, 24, 14, 400, DateTimeKind.Local).AddTicks(9394), new DateTime(1998, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "aline.ferreira@example.com", "Rua N, 1111", "Aline Ferreira", "senha123" },
                    { 15, "15234567890", new DateTime(2025, 3, 15, 19, 24, 14, 400, DateTimeKind.Local).AddTicks(9397), new DateTime(1990, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "thiago.barbosa@example.com", "Rua O, 1212", "Thiago Barbosa", "senha123" },
                    { 16, "16234567890", new DateTime(2025, 3, 15, 19, 24, 14, 400, DateTimeKind.Local).AddTicks(9399), new DateTime(1992, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "camila.araujo@example.com", "Rua P, 1313", "Camila Araujo", "senha123" },
                    { 17, "17234567890", new DateTime(2025, 3, 15, 19, 24, 14, 400, DateTimeKind.Local).AddTicks(9401), new DateTime(1985, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "felipe.mendes@example.com", "Rua Q, 1414", "Felipe Mendes", "senha123" },
                    { 18, "18234567890", new DateTime(2025, 3, 15, 19, 24, 14, 400, DateTimeKind.Local).AddTicks(9404), new DateTime(1988, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "renata.carvalho@example.com", "Rua R, 1515", "Renata Carvalho", "senha123" },
                    { 19, "19234567890", new DateTime(2025, 3, 15, 19, 24, 14, 400, DateTimeKind.Local).AddTicks(9406), new DateTime(1995, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "gustavo.lima@example.com", "Rua S, 1616", "Gustavo Lima", "senha123" },
                    { 20, "20234567890", new DateTime(2025, 3, 15, 19, 24, 14, 400, DateTimeKind.Local).AddTicks(9409), new DateTime(1993, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "isabela.souza@example.com", "Rua T, 1717", "Isabela Souza", "senha123" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
