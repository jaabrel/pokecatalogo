using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pokecatalogo.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLikesAndComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.AlterColumn<int>(
                name: "Resistências",
                table: "Tipos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIFBk323Mi07mGhnZ6HieD3QzXfzhn1i4inJ7CjtHM5Sw3DLcvSYxNNFrp5Aw5tMYQ==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Resistências",
                table: "Tipos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EquipaFk = table.Column<int>(type: "INTEGER", nullable: false),
                    UtilizadorFk = table.Column<int>(type: "INTEGER", nullable: false),
                    Conteudo = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    DataComentario = table.Column<DateTime>(type: "TEXT", nullable: false)
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
                    EquipaFk = table.Column<int>(type: "INTEGER", nullable: false),
                    UtilizadorFk = table.Column<int>(type: "INTEGER", nullable: false),
                    DataLike = table.Column<DateTime>(type: "TEXT", nullable: false)
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIA0h1QcKBRGBPyBH7wNwrkzG6sHzJkIY+3B0fgCymH32MENzVlqf1vq9O5NIjzcew==");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_EquipaFk",
                table: "Comentarios",
                column: "EquipaFk");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_UtilizadorFk",
                table: "Comentarios",
                column: "UtilizadorFk");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_EquipaFk",
                table: "Likes",
                column: "EquipaFk");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UtilizadorFk",
                table: "Likes",
                column: "UtilizadorFk");
        }
    }
}
