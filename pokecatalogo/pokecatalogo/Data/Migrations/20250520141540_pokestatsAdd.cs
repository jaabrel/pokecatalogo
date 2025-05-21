using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pokecatalogo.Data.Migrations
{
    /// <inheritdoc />
    public partial class pokestatsAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PokemonStats",
                columns: table => new
                {
                    PokemonFk = table.Column<int>(type: "INTEGER", nullable: false),
                    Hp = table.Column<int>(type: "INTEGER", nullable: false),
                    Atk = table.Column<int>(type: "INTEGER", nullable: false),
                    Def = table.Column<int>(type: "INTEGER", nullable: false),
                    SpA = table.Column<int>(type: "INTEGER", nullable: false),
                    SpD = table.Column<int>(type: "INTEGER", nullable: false),
                    Speed = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonStats", x => x.PokemonFk);
                    table.ForeignKey(
                        name: "FK_PokemonStats_Pokemons_PokemonFk",
                        column: x => x.PokemonFk,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9b5647d-e552-47c6-8bc9-a13f4f442293", "AQAAAAIAAYagAAAAEP4SkmPxrpLaIlDUVcGOfbH6mKX/JA+MJ+c0zyNUGPvkm1uG9Ll9iQBxoEXU5U2cJw==", "e3379938-ad6c-4865-9a74-feb17f7e92a6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonStats");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e5b09c0-155a-4646-a0d1-467098cbe431", "AQAAAAIAAYagAAAAEN2mzHYdgesYdNI5fPQ8my6CN2jPW46r7oVTI04RYgdQg7Sh721My2ZEyYabHYWF7w==", "47dbedeb-a15f-4825-8eed-6f92f943382c" });
        }
    }
}
