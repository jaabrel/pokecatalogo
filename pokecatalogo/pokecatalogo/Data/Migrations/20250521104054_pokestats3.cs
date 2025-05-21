using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pokecatalogo.Data.Migrations
{
    /// <inheritdoc />
    public partial class pokestats3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1241e9da-37cb-4b6c-b5c7-79c36b062fe7", "AQAAAAIAAYagAAAAEDar2AVACl3LRjUPPTKfJJxEiUbGNfOwqMQ30+2oHaG5MixiOfTJmy5i87HWxkA1iA==", "ff55d21f-d828-49ad-8516-672eafac3e78" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f2af9d2-56ff-4b22-bdbf-df0d3ccc387f", "AQAAAAIAAYagAAAAELTxCgG4i02P+QzLI8Qk8j6Mc2RbIsiNa3VvimvshqKzba4KqXyVzznqEVuU52ExGQ==", "3501aa93-423f-4905-8df6-b50f04f6fc2c" });
        }
    }
}
