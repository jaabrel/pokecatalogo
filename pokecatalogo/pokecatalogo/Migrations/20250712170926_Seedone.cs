using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace pokecatalogo.Migrations
{
    /// <inheritdoc />
    public partial class Seedone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "ImagemShiny",
                table: "Pokemons");

            migrationBuilder.AlterColumn<string>(
                name: "Resistências",
                table: "Tipos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Imunidades",
                table: "Tipos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Fraquezas",
                table: "Tipos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Efetivo",
                table: "Tipos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Especie",
                table: "Pokemons",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PokeApiId",
                table: "Pokemons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEA3YOSmqxMqTxsYdRs4kZbx7JiCOMjJy9K9VAv3iOAUEpeXEgazVkqXZYLbwyc0Khw==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PokeApiId",
                table: "Pokemons");

            migrationBuilder.AlterColumn<int>(
                name: "Resistências",
                table: "Tipos",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Imunidades",
                table: "Tipos",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Fraquezas",
                table: "Tipos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Efetivo",
                table: "Tipos",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Especie",
                table: "Pokemons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Pokemons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagemShiny",
                table: "Pokemons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKldZ7+5+z8CcQT1Ympxy7ULMdLOs5NtCJ/dbxxUnMU2fA/weIwvm8HieQ+2xKFLJg==");

            migrationBuilder.InsertData(
                table: "Tipos",
                columns: new[] { "Id", "Cor", "Efetivo", "Fraquezas", "Imunidades", "Nome", "Resistências" },
                values: new object[,]
                {
                    { 1, "#A8A878", null, 6, 13, 0, null },
                    { 2, "#F08030", 4, 2, null, 1, 16 },
                    { 3, "#6890F0", 12, 4, null, 2, 1 },
                    { 4, "#F8D030", 2, 8, null, 3, 9 },
                    { 5, "#78C850", 8, 1, null, 4, 2 },
                    { 6, "#98D8D8", 9, 1, null, 5, 5 },
                    { 7, "#C03028", 0, 10, null, 6, 12 },
                    { 8, "#A040A0", 17, 8, null, 7, 4 },
                    { 9, "#E0C068", 16, 2, 3, 8, 7 },
                    { 10, "#A890F0", 6, 3, 8, 9, 4 },
                    { 11, "#F85888", 7, 15, null, 10, 6 },
                    { 12, "#A8B820", 10, 1, null, 11, 4 },
                    { 13, "#B8A038", 11, 2, null, 12, 0 },
                    { 14, "#705898", 10, 15, 0, 13, 7 },
                    { 15, "#7038F8", 14, 17, null, 14, 1 },
                    { 16, "#705848", 13, 6, 10, 15, 13 },
                    { 17, "#B8B8D0", 12, 1, 7, 16, 17 },
                    { 18, "#EE99AC", 15, 16, 14, 17, 6 }
                });
        }
    }
}
