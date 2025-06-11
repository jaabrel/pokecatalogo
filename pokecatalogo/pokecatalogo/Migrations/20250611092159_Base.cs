using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pokecatalogo.Migrations
{
    /// <inheritdoc />
    public partial class Base : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "TEXT", nullable: false)
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
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
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
                    Nome = table.Column<int>(type: "INTEGER", nullable: false),
                    Cor = table.Column<string>(type: "TEXT", nullable: false),
                    Fraquezas = table.Column<int>(type: "INTEGER", nullable: false),
                    Resistências = table.Column<int>(type: "INTEGER", nullable: false),
                    Imunidades = table.Column<int>(type: "INTEGER", nullable: true),
                    Efetivo = table.Column<int>(type: "INTEGER", nullable: true)
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
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    IdentityUserName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocalizacaoJogos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JogoFk = table.Column<int>(type: "INTEGER", nullable: false),
                    LocalizacaoFk = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizacaoJogos", x => x.Id);
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
                name: "Pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    DescricaoPokedex = table.Column<string>(type: "TEXT", nullable: false),
                    Altura = table.Column<float>(type: "REAL", nullable: false),
                    Peso = table.Column<float>(type: "REAL", nullable: false),
                    Especie = table.Column<string>(type: "TEXT", nullable: true),
                    Imagem = table.Column<string>(type: "TEXT", nullable: true),
                    ImagemShiny = table.Column<string>(type: "TEXT", nullable: true),
                    EvolucaoAnteriorFk = table.Column<int>(type: "INTEGER", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "Evolucoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    PokemonFk1 = table.Column<int>(type: "INTEGER", nullable: false),
                    PokemonFk2 = table.Column<int>(type: "INTEGER", nullable: true)
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
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Habilidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
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
                name: "PokemonLocalizacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PokemonFk = table.Column<int>(type: "INTEGER", nullable: false),
                    LocalizacaoFk = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonLocalizacoes", x => x.Id);
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
                name: "PokemonStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Hp = table.Column<int>(type: "INTEGER", nullable: false),
                    Atk = table.Column<int>(type: "INTEGER", nullable: false),
                    Def = table.Column<int>(type: "INTEGER", nullable: false),
                    SpA = table.Column<int>(type: "INTEGER", nullable: false),
                    SpD = table.Column<int>(type: "INTEGER", nullable: false),
                    Speed = table.Column<int>(type: "INTEGER", nullable: false),
                    PokemonFk = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PokemonStats_Pokemons_PokemonFk",
                        column: x => x.PokemonFk,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonTipo",
                columns: table => new
                {
                    PokemonsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TiposId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonTipo", x => new { x.PokemonsId, x.TiposId });
                    table.ForeignKey(
                        name: "FK_PokemonTipo_Pokemons_PokemonsId",
                        column: x => x.PokemonsId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonTipo_Tipos_TiposId",
                        column: x => x.TiposId,
                        principalTable: "Tipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonHabilidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PokemonFk = table.Column<int>(type: "INTEGER", nullable: false),
                    HabilidadeFk = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonHabilidades", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "AtaquePokemon",
                columns: table => new
                {
                    PokemonAtaquesId = table.Column<int>(type: "INTEGER", nullable: false),
                    PokemonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtaquePokemon", x => new { x.PokemonAtaquesId, x.PokemonId });
                    table.ForeignKey(
                        name: "FK_AtaquePokemon_Pokemons_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ataques",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Categoria = table.Column<string>(type: "TEXT", nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    Dano = table.Column<int>(type: "INTEGER", nullable: false),
                    Precisao = table.Column<int>(type: "INTEGER", nullable: false),
                    PP = table.Column<int>(type: "INTEGER", nullable: false),
                    Prioridade = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoFk = table.Column<int>(type: "INTEGER", nullable: false),
                    PokemonEquipaId = table.Column<int>(type: "INTEGER", nullable: true)
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
                name: "Equipas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeEquipa = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DonoFk = table.Column<int>(type: "INTEGER", nullable: false),
                    AtaqueId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipas_Ataques_AtaqueId",
                        column: x => x.AtaqueId,
                        principalTable: "Ataques",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipas_Utilizadores_DonoFk",
                        column: x => x.DonoFk,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Conteudo = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    DataComentario = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UtilizadorFk = table.Column<int>(type: "INTEGER", nullable: false),
                    EquipaFk = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentarios_Equipas_EquipaFk",
                        column: x => x.EquipaFk,
                        principalTable: "Equipas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentarios_Utilizadores_UtilizadorFk",
                        column: x => x.UtilizadorFk,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataLike = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UtilizadorFk = table.Column<int>(type: "INTEGER", nullable: false),
                    EquipaFk = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Equipas_EquipaFk",
                        column: x => x.EquipaFk,
                        principalTable: "Equipas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Utilizadores_UtilizadorFk",
                        column: x => x.UtilizadorFk,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonEquipas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EquipaFk = table.Column<int>(type: "INTEGER", nullable: false),
                    PokemonFk = table.Column<int>(type: "INTEGER", nullable: false),
                    Nivel = table.Column<int>(type: "INTEGER", nullable: false),
                    Alcunha = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    PosicaoNaEquipa = table.Column<int>(type: "INTEGER", nullable: false),
                    HabilidadeFk = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonEquipas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PokemonEquipas_Equipas_EquipaFk",
                        column: x => x.EquipaFk,
                        principalTable: "Equipas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonEquipas_Habilidades_HabilidadeFk",
                        column: x => x.HabilidadeFk,
                        principalTable: "Habilidades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PokemonEquipas_Pokemons_PokemonFk",
                        column: x => x.PokemonFk,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a", null, "Administrador", "ADMINISTRADOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "admin", 0, "fe626d10-17f8-4768-8818-895627758300", "admin@mail.pt", true, false, null, "ADMIN@MAIL.PT", "ADMIN@MAIL.PT", "AQAAAAIAAYagAAAAEIA0h1QcKBRGBPyBH7wNwrkzG6sHzJkIY+3B0fgCymH32MENzVlqf1vq9O5NIjzcew==", null, false, "1bcbd0a7-5c9d-4510-811a-cd5eee6c0dbe", false, "admin@mail.pt" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AtaquePokemon_PokemonId",
                table: "AtaquePokemon",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_Ataques_PokemonEquipaId",
                table: "Ataques",
                column: "PokemonEquipaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ataques_TipoFk",
                table: "Ataques",
                column: "TipoFk");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_EquipaFk",
                table: "Comentarios",
                column: "EquipaFk");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_UtilizadorFk",
                table: "Comentarios",
                column: "UtilizadorFk");

            migrationBuilder.CreateIndex(
                name: "IX_Equipas_AtaqueId",
                table: "Equipas",
                column: "AtaqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipas_DonoFk",
                table: "Equipas",
                column: "DonoFk");

            migrationBuilder.CreateIndex(
                name: "IX_Evolucoes_PokemonFk1",
                table: "Evolucoes",
                column: "PokemonFk1");

            migrationBuilder.CreateIndex(
                name: "IX_Evolucoes_PokemonFk2",
                table: "Evolucoes",
                column: "PokemonFk2",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Habilidades_PokemonFk",
                table: "Habilidades",
                column: "PokemonFk");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_EquipaFk",
                table: "Likes",
                column: "EquipaFk");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UtilizadorFk",
                table: "Likes",
                column: "UtilizadorFk");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizacaoJogos_JogoFk",
                table: "LocalizacaoJogos",
                column: "JogoFk");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizacaoJogos_LocalizacaoFk",
                table: "LocalizacaoJogos",
                column: "LocalizacaoFk");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonEquipas_EquipaFk",
                table: "PokemonEquipas",
                column: "EquipaFk");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonEquipas_HabilidadeFk",
                table: "PokemonEquipas",
                column: "HabilidadeFk");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonEquipas_PokemonFk",
                table: "PokemonEquipas",
                column: "PokemonFk");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonHabilidades_HabilidadeFk",
                table: "PokemonHabilidades",
                column: "HabilidadeFk");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonHabilidades_PokemonFk",
                table: "PokemonHabilidades",
                column: "PokemonFk");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonLocalizacoes_LocalizacaoFk",
                table: "PokemonLocalizacoes",
                column: "LocalizacaoFk");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonLocalizacoes_PokemonFk",
                table: "PokemonLocalizacoes",
                column: "PokemonFk");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_LocalizacaoId",
                table: "Pokemons",
                column: "LocalizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonStats_PokemonFk",
                table: "PokemonStats",
                column: "PokemonFk");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonTipo_TiposId",
                table: "PokemonTipo",
                column: "TiposId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtaquePokemon_Ataques_PokemonAtaquesId",
                table: "AtaquePokemon",
                column: "PokemonAtaquesId",
                principalTable: "Ataques",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ataques_PokemonEquipas_PokemonEquipaId",
                table: "Ataques",
                column: "PokemonEquipaId",
                principalTable: "PokemonEquipas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipas_Ataques_AtaqueId",
                table: "Equipas");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AtaquePokemon");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Evolucoes");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "LocalizacaoJogos");

            migrationBuilder.DropTable(
                name: "PokemonHabilidades");

            migrationBuilder.DropTable(
                name: "PokemonLocalizacoes");

            migrationBuilder.DropTable(
                name: "PokemonStats");

            migrationBuilder.DropTable(
                name: "PokemonTipo");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Jogos");

            migrationBuilder.DropTable(
                name: "Ataques");

            migrationBuilder.DropTable(
                name: "PokemonEquipas");

            migrationBuilder.DropTable(
                name: "Tipos");

            migrationBuilder.DropTable(
                name: "Equipas");

            migrationBuilder.DropTable(
                name: "Habilidades");

            migrationBuilder.DropTable(
                name: "Utilizadores");

            migrationBuilder.DropTable(
                name: "Pokemons");

            migrationBuilder.DropTable(
                name: "Localizacoes");
        }
    }
}
