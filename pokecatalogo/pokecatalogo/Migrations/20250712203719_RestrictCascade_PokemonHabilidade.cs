using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pokecatalogo.Migrations
{
    /// <inheritdoc />
    public partial class RestrictCascade_PokemonHabilidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokemonHabilidades_Habilidades_HabilidadeFk",
                table: "PokemonHabilidades");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonHabilidades_Pokemons_PokemonFk",
                table: "PokemonHabilidades");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEP2DzIlnRWuT9HrGJVoyVXzFE84ciz20RAEdQJlV6sNp09+V4Isw0xbEkHvEDRMf9A==");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonHabilidades_Habilidades_HabilidadeFk",
                table: "PokemonHabilidades",
                column: "HabilidadeFk",
                principalTable: "Habilidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_PokemonHabilidades_Habilidades_HabilidadeFk",
                table: "PokemonHabilidades");

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
                name: "FK_PokemonHabilidades_Habilidades_HabilidadeFk",
                table: "PokemonHabilidades",
                column: "HabilidadeFk",
                principalTable: "Habilidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
