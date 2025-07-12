using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pokecatalogo.Migrations
{
    /// <inheritdoc />
    public partial class seedtwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_AtaquePokemon_Ataques_PokemonAtaquesId",
                table: "AtaquePokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_AtaquePokemon_Pokemons_PokemonId",
                table: "AtaquePokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_Ataques_Tipos_TipoFk",
                table: "Ataques");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipas_Utilizadores_DonoFk",
                table: "Equipas");

            migrationBuilder.DropForeignKey(
                name: "FK_Evolucoes_Pokemons_PokemonFk1",
                table: "Evolucoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Habilidades_Pokemons_PokemonFk",
                table: "Habilidades");

            migrationBuilder.DropForeignKey(
                name: "FK_LocalizacaoJogos_Jogos_JogoFk",
                table: "LocalizacaoJogos");

            migrationBuilder.DropForeignKey(
                name: "FK_LocalizacaoJogos_Localizacoes_LocalizacaoFk",
                table: "LocalizacaoJogos");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonEquipas_Equipas_EquipaFk",
                table: "PokemonEquipas");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonEquipas_Pokemons_PokemonFk",
                table: "PokemonEquipas");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonHabilidades_Habilidades_HabilidadeFk",
                table: "PokemonHabilidades");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonHabilidades_Pokemons_PokemonFk",
                table: "PokemonHabilidades");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonLocalizacoes_Localizacoes_LocalizacaoFk",
                table: "PokemonLocalizacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonLocalizacoes_Pokemons_PokemonFk",
                table: "PokemonLocalizacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonStats_Pokemons_PokemonFk",
                table: "PokemonStats");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonTipo_Pokemons_PokemonsId",
                table: "PokemonTipo");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonTipo_Tipos_TiposId",
                table: "PokemonTipo");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEO/l9GgNWHNxsEmfaTQVA0vt82LmDp0YcPTFQxGRezBfrsXRCU3TWgo235PeaQG/+Q==");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtaquePokemon_Ataques_PokemonAtaquesId",
                table: "AtaquePokemon",
                column: "PokemonAtaquesId",
                principalTable: "Ataques",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AtaquePokemon_Pokemons_PokemonId",
                table: "AtaquePokemon",
                column: "PokemonId",
                principalTable: "Pokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Ataques_Tipos_TipoFk",
                table: "Ataques",
                column: "TipoFk",
                principalTable: "Tipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipas_Utilizadores_DonoFk",
                table: "Equipas",
                column: "DonoFk",
                principalTable: "Utilizadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Evolucoes_Pokemons_PokemonFk1",
                table: "Evolucoes",
                column: "PokemonFk1",
                principalTable: "Pokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Habilidades_Pokemons_PokemonFk",
                table: "Habilidades",
                column: "PokemonFk",
                principalTable: "Pokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_LocalizacaoJogos_Jogos_JogoFk",
                table: "LocalizacaoJogos",
                column: "JogoFk",
                principalTable: "Jogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_LocalizacaoJogos_Localizacoes_LocalizacaoFk",
                table: "LocalizacaoJogos",
                column: "LocalizacaoFk",
                principalTable: "Localizacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonEquipas_Equipas_EquipaFk",
                table: "PokemonEquipas",
                column: "EquipaFk",
                principalTable: "Equipas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonEquipas_Pokemons_PokemonFk",
                table: "PokemonEquipas",
                column: "PokemonFk",
                principalTable: "Pokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonHabilidades_Habilidades_HabilidadeFk",
                table: "PokemonHabilidades",
                column: "HabilidadeFk",
                principalTable: "Habilidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonHabilidades_Pokemons_PokemonFk",
                table: "PokemonHabilidades",
                column: "PokemonFk",
                principalTable: "Pokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonLocalizacoes_Localizacoes_LocalizacaoFk",
                table: "PokemonLocalizacoes",
                column: "LocalizacaoFk",
                principalTable: "Localizacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonLocalizacoes_Pokemons_PokemonFk",
                table: "PokemonLocalizacoes",
                column: "PokemonFk",
                principalTable: "Pokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonStats_Pokemons_PokemonFk",
                table: "PokemonStats",
                column: "PokemonFk",
                principalTable: "Pokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonTipo_Pokemons_PokemonsId",
                table: "PokemonTipo",
                column: "PokemonsId",
                principalTable: "Pokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonTipo_Tipos_TiposId",
                table: "PokemonTipo",
                column: "TiposId",
                principalTable: "Tipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_AtaquePokemon_Ataques_PokemonAtaquesId",
                table: "AtaquePokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_AtaquePokemon_Pokemons_PokemonId",
                table: "AtaquePokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_Ataques_Tipos_TipoFk",
                table: "Ataques");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipas_Utilizadores_DonoFk",
                table: "Equipas");

            migrationBuilder.DropForeignKey(
                name: "FK_Evolucoes_Pokemons_PokemonFk1",
                table: "Evolucoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Habilidades_Pokemons_PokemonFk",
                table: "Habilidades");

            migrationBuilder.DropForeignKey(
                name: "FK_LocalizacaoJogos_Jogos_JogoFk",
                table: "LocalizacaoJogos");

            migrationBuilder.DropForeignKey(
                name: "FK_LocalizacaoJogos_Localizacoes_LocalizacaoFk",
                table: "LocalizacaoJogos");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonEquipas_Equipas_EquipaFk",
                table: "PokemonEquipas");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonEquipas_Pokemons_PokemonFk",
                table: "PokemonEquipas");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonHabilidades_Habilidades_HabilidadeFk",
                table: "PokemonHabilidades");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonHabilidades_Pokemons_PokemonFk",
                table: "PokemonHabilidades");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonLocalizacoes_Localizacoes_LocalizacaoFk",
                table: "PokemonLocalizacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonLocalizacoes_Pokemons_PokemonFk",
                table: "PokemonLocalizacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonStats_Pokemons_PokemonFk",
                table: "PokemonStats");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonTipo_Pokemons_PokemonsId",
                table: "PokemonTipo");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonTipo_Tipos_TiposId",
                table: "PokemonTipo");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEA3YOSmqxMqTxsYdRs4kZbx7JiCOMjJy9K9VAv3iOAUEpeXEgazVkqXZYLbwyc0Khw==");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AtaquePokemon_Ataques_PokemonAtaquesId",
                table: "AtaquePokemon",
                column: "PokemonAtaquesId",
                principalTable: "Ataques",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AtaquePokemon_Pokemons_PokemonId",
                table: "AtaquePokemon",
                column: "PokemonId",
                principalTable: "Pokemons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ataques_Tipos_TipoFk",
                table: "Ataques",
                column: "TipoFk",
                principalTable: "Tipos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipas_Utilizadores_DonoFk",
                table: "Equipas",
                column: "DonoFk",
                principalTable: "Utilizadores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Evolucoes_Pokemons_PokemonFk1",
                table: "Evolucoes",
                column: "PokemonFk1",
                principalTable: "Pokemons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Habilidades_Pokemons_PokemonFk",
                table: "Habilidades",
                column: "PokemonFk",
                principalTable: "Pokemons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LocalizacaoJogos_Jogos_JogoFk",
                table: "LocalizacaoJogos",
                column: "JogoFk",
                principalTable: "Jogos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LocalizacaoJogos_Localizacoes_LocalizacaoFk",
                table: "LocalizacaoJogos",
                column: "LocalizacaoFk",
                principalTable: "Localizacoes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonEquipas_Equipas_EquipaFk",
                table: "PokemonEquipas",
                column: "EquipaFk",
                principalTable: "Equipas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonEquipas_Pokemons_PokemonFk",
                table: "PokemonEquipas",
                column: "PokemonFk",
                principalTable: "Pokemons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonHabilidades_Habilidades_HabilidadeFk",
                table: "PokemonHabilidades",
                column: "HabilidadeFk",
                principalTable: "Habilidades",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonHabilidades_Pokemons_PokemonFk",
                table: "PokemonHabilidades",
                column: "PokemonFk",
                principalTable: "Pokemons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonLocalizacoes_Localizacoes_LocalizacaoFk",
                table: "PokemonLocalizacoes",
                column: "LocalizacaoFk",
                principalTable: "Localizacoes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonLocalizacoes_Pokemons_PokemonFk",
                table: "PokemonLocalizacoes",
                column: "PokemonFk",
                principalTable: "Pokemons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonStats_Pokemons_PokemonFk",
                table: "PokemonStats",
                column: "PokemonFk",
                principalTable: "Pokemons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonTipo_Pokemons_PokemonsId",
                table: "PokemonTipo",
                column: "PokemonsId",
                principalTable: "Pokemons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonTipo_Tipos_TiposId",
                table: "PokemonTipo",
                column: "TiposId",
                principalTable: "Tipos",
                principalColumn: "Id");
        }
    }
}
