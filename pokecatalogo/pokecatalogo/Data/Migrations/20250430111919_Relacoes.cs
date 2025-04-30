using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pokecatalogo.Data.Migrations
{
    /// <inheritdoc />
    public partial class Relacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localizacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocalizacaoJogos",
                columns: table => new
                {
                    JogoFk = table.Column<int>(type: "INTEGER", nullable: false),
                    LocalizacaoFk = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizacaoJogos", x => new { x.LocalizacaoFk, x.JogoFk });
                    table.ForeignKey(
                        name: "FK_LocalizacaoJogos_Jogos_JogoFk",
                        column: x => x.JogoFk,
                        principalTable: "Jogos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocalizacaoJogos_Localizacoes_LocalizacaoFk",
                        column: x => x.LocalizacaoFk,
                        principalTable: "Localizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ataques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    TipoFk = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ataques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ataques_Tipos_TipoFk",
                        column: x => x.TipoFk,
                        principalTable: "Tipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Tipo1Fk = table.Column<int>(type: "INTEGER", nullable: false),
                    Tipo2Fk = table.Column<int>(type: "INTEGER", nullable: true),
                    LocalizacaoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pokemons_Localizacoes_LocalizacaoId",
                        column: x => x.LocalizacaoId,
                        principalTable: "Localizacoes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pokemons_Tipos_Tipo1Fk",
                        column: x => x.Tipo1Fk,
                        principalTable: "Tipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pokemons_Tipos_Tipo2Fk",
                        column: x => x.Tipo2Fk,
                        principalTable: "Tipos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Evolucoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    PokemonFk1 = table.Column<int>(type: "INTEGER", nullable: false),
                    PokemonFk2 = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evolucoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evolucoes_Pokemons_PokemonFk1",
                        column: x => x.PokemonFk1,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evolucoes_Pokemons_PokemonFk2",
                        column: x => x.PokemonFk2,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Habilidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: false),
                    PokemonFk = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Habilidades_Pokemons_PokemonFk",
                        column: x => x.PokemonFk,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonAtaques",
                columns: table => new
                {
                    PokemonFk = table.Column<int>(type: "INTEGER", nullable: false),
                    AtaqueFk = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonAtaques", x => new { x.PokemonFk, x.AtaqueFk });
                    table.ForeignKey(
                        name: "FK_PokemonAtaques_Ataques_AtaqueFk",
                        column: x => x.AtaqueFk,
                        principalTable: "Ataques",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonAtaques_Pokemons_PokemonFk",
                        column: x => x.PokemonFk,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonLocalizacoes",
                columns: table => new
                {
                    PokemonFk = table.Column<int>(type: "INTEGER", nullable: false),
                    LocalizacaoFk = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonLocalizacoes", x => new { x.PokemonFk, x.LocalizacaoFk });
                    table.ForeignKey(
                        name: "FK_PokemonLocalizacoes_Localizacoes_LocalizacaoFk",
                        column: x => x.LocalizacaoFk,
                        principalTable: "Localizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonLocalizacoes_Pokemons_PokemonFk",
                        column: x => x.PokemonFk,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonHabilidades",
                columns: table => new
                {
                    PokemonFk = table.Column<int>(type: "INTEGER", nullable: false),
                    HabilidadeFk = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonHabilidades", x => new { x.PokemonFk, x.HabilidadeFk });
                    table.ForeignKey(
                        name: "FK_PokemonHabilidades_Habilidades_HabilidadeFk",
                        column: x => x.HabilidadeFk,
                        principalTable: "Habilidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonHabilidades_Pokemons_PokemonFk",
                        column: x => x.PokemonFk,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ataques_TipoFk",
                table: "Ataques",
                column: "TipoFk");

            migrationBuilder.CreateIndex(
                name: "IX_Evolucoes_PokemonFk1",
                table: "Evolucoes",
                column: "PokemonFk1");

            migrationBuilder.CreateIndex(
                name: "IX_Evolucoes_PokemonFk2",
                table: "Evolucoes",
                column: "PokemonFk2");

            migrationBuilder.CreateIndex(
                name: "IX_Habilidades_PokemonFk",
                table: "Habilidades",
                column: "PokemonFk");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizacaoJogos_JogoFk",
                table: "LocalizacaoJogos",
                column: "JogoFk");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonAtaques_AtaqueFk",
                table: "PokemonAtaques",
                column: "AtaqueFk");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonHabilidades_HabilidadeFk",
                table: "PokemonHabilidades",
                column: "HabilidadeFk");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonLocalizacoes_LocalizacaoFk",
                table: "PokemonLocalizacoes",
                column: "LocalizacaoFk");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_LocalizacaoId",
                table: "Pokemons",
                column: "LocalizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_Tipo1Fk",
                table: "Pokemons",
                column: "Tipo1Fk");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_Tipo2Fk",
                table: "Pokemons",
                column: "Tipo2Fk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evolucoes");

            migrationBuilder.DropTable(
                name: "LocalizacaoJogos");

            migrationBuilder.DropTable(
                name: "PokemonAtaques");

            migrationBuilder.DropTable(
                name: "PokemonHabilidades");

            migrationBuilder.DropTable(
                name: "PokemonLocalizacoes");

            migrationBuilder.DropTable(
                name: "Utilizadores");

            migrationBuilder.DropTable(
                name: "Jogos");

            migrationBuilder.DropTable(
                name: "Ataques");

            migrationBuilder.DropTable(
                name: "Habilidades");

            migrationBuilder.DropTable(
                name: "Pokemons");

            migrationBuilder.DropTable(
                name: "Localizacoes");

            migrationBuilder.DropTable(
                name: "Tipos");
        }
    }
}
