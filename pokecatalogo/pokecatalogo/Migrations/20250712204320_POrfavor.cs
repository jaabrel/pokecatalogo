using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pokecatalogo.Migrations
{
    /// <inheritdoc />
    public partial class POrfavor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGPPR20vQZcx38TKJaFciJaXJ09uTj7c0Ng4+WYNlxiYniroKKufWmUme5oLm/InBw==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEP2DzIlnRWuT9HrGJVoyVXzFE84ciz20RAEdQJlV6sNp09+V4Isw0xbEkHvEDRMf9A==");
        }
    }
}
