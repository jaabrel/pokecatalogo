using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pokecatalogo.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migra3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evolucoes_Pokemons_PokemonFk2",
                table: "Evolucoes");

            migrationBuilder.AddColumn<string>(
                name: "Fraquezas",
                table: "Tipos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "PokemonFk2",
                table: "Evolucoes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Ataques",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Evolucoes_Pokemons_PokemonFk2",
                table: "Evolucoes",
                column: "PokemonFk2",
                principalTable: "Pokemons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evolucoes_Pokemons_PokemonFk2",
                table: "Evolucoes");

            migrationBuilder.DropColumn(
                name: "Fraquezas",
                table: "Tipos");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Ataques");

            migrationBuilder.AlterColumn<int>(
                name: "PokemonFk2",
                table: "Evolucoes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Evolucoes_Pokemons_PokemonFk2",
                table: "Evolucoes",
                column: "PokemonFk2",
                principalTable: "Pokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
