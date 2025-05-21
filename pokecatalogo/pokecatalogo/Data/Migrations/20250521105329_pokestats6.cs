using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pokecatalogo.Data.Migrations
{
    /// <inheritdoc />
    public partial class pokestats6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e5df5c4-f37f-4224-aee6-9c7510878c6e", "AQAAAAIAAYagAAAAEOGKNwrGQm5SdyW1Vd/fK+StOPeH78eJn72QkgJOeD8vtV4ZGqXI5WYBuzKxpA4QTg==", "eb1cf1a8-9d32-420f-bee8-9c124a1a70c9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95babd8f-fb88-4c33-bd75-61d8b9a7f116", "AQAAAAIAAYagAAAAEAOp1trJ8rjewaOTPFqAiA3/q/gBKgwAAmJOgcfNLv0U1BJqmXrgPW/BrQrpxOIF/g==", "6f920307-4a3a-4029-b0e4-2f1f01579efd" });
        }
    }
}
