using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pokecatalogo.Migrations
{
    /// <inheritdoc />
    public partial class FixCascadePaths_PokemonHabilidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonHabilidades_Pokemons_PokemonFk",
                table: "PokemonHabilidades");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENPOYyNhQAIczj+xfJzVJtLRen0Qix0Vlwcag2GRohXaYXEw4qXLXe2DkgnMG9y/lQ==");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonHabilidades_Pokemons_PokemonFk",
                table: "PokemonHabilidades",
                column: "PokemonFk",
                principalTable: "Pokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonHabilidades_Pokemons_PokemonFk",
                table: "PokemonHabilidades");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKq4ZSSQ4EB0ZVqgh8rHr/9Mpb8xcCD7Oxk/Zv4AnpxXxQFK3P9XFNfAtUz1sTBOLw==");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonHabilidades_Pokemons_PokemonFk",
                table: "PokemonHabilidades",
                column: "PokemonFk",
                principalTable: "Pokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
