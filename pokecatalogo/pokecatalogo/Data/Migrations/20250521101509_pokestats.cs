using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pokecatalogo.Data.Migrations
{
    /// <inheritdoc />
    public partial class pokestats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Habilidades",
                newName: "Nome");

            migrationBuilder.AlterColumn<int>(
                name: "Nome",
                table: "Tipos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Fraquezas",
                table: "Tipos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cor",
                table: "Tipos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Efetivo",
                table: "Tipos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Imunidades",
                table: "Tipos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Resistências",
                table: "Tipos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Altura",
                table: "Pokemons",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "DescricaoPokedex",
                table: "Pokemons",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Especie",
                table: "Pokemons",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Pokemons",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagemShiny",
                table: "Pokemons",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Peso",
                table: "Pokemons",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Jogos",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataLancamento",
                table: "Jogos",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Habilidades",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Dano",
                table: "Ataques",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Ataques",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PP",
                table: "Ataques",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Precisao",
                table: "Ataques",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Prioridade",
                table: "Ataques",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b0b608b-212b-4ceb-a26f-7ce8b37f116e", "AQAAAAIAAYagAAAAEEBMTtSgeXLtNN/a5jOickDK7uYASnI8rbtABR8rXvMsVNR3Hq1hsP5M3R8Mfk9XvQ==", "fb0f9624-4cdf-41bc-982a-782c56eaf5e0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cor",
                table: "Tipos");

            migrationBuilder.DropColumn(
                name: "Efetivo",
                table: "Tipos");

            migrationBuilder.DropColumn(
                name: "Imunidades",
                table: "Tipos");

            migrationBuilder.DropColumn(
                name: "Resistências",
                table: "Tipos");

            migrationBuilder.DropColumn(
                name: "Altura",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "DescricaoPokedex",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "Especie",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "ImagemShiny",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "DataLancamento",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Habilidades");

            migrationBuilder.DropColumn(
                name: "Dano",
                table: "Ataques");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Ataques");

            migrationBuilder.DropColumn(
                name: "PP",
                table: "Ataques");

            migrationBuilder.DropColumn(
                name: "Precisao",
                table: "Ataques");

            migrationBuilder.DropColumn(
                name: "Prioridade",
                table: "Ataques");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Habilidades",
                newName: "nome");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Tipos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Fraquezas",
                table: "Tipos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Jogos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9b5647d-e552-47c6-8bc9-a13f4f442293", "AQAAAAIAAYagAAAAEP4SkmPxrpLaIlDUVcGOfbH6mKX/JA+MJ+c0zyNUGPvkm1uG9Ll9iQBxoEXU5U2cJw==", "e3379938-ad6c-4865-9a74-feb17f7e92a6" });
        }
    }
}
