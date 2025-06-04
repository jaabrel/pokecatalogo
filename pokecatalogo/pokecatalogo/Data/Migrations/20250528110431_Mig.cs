using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pokecatalogo.Data.Migrations
{
    /// <inheritdoc />
    public partial class Mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54f83cad-29fd-46bd-a6b0-f4585a476f7a", "AQAAAAIAAYagAAAAEF47pqNwdp5OxiKoka72yU+OjgM9xGXupn9aNBSTSPWEpL/wDUwPS1iGYIj1rYqCGg==", "b67f5257-f96f-4259-801a-ba261937cee2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e5df5c4-f37f-4224-aee6-9c7510878c6e", "AQAAAAIAAYagAAAAEOGKNwrGQm5SdyW1Vd/fK+StOPeH78eJn72QkgJOeD8vtV4ZGqXI5WYBuzKxpA4QTg==", "eb1cf1a8-9d32-420f-bee8-9c124a1a70c9" });
        }
    }
}
