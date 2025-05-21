using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pokecatalogo.Data.Migrations
{
    /// <inheritdoc />
    public partial class pokestats1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f2af9d2-56ff-4b22-bdbf-df0d3ccc387f", "AQAAAAIAAYagAAAAELTxCgG4i02P+QzLI8Qk8j6Mc2RbIsiNa3VvimvshqKzba4KqXyVzznqEVuU52ExGQ==", "3501aa93-423f-4905-8df6-b50f04f6fc2c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b0b608b-212b-4ceb-a26f-7ce8b37f116e", "AQAAAAIAAYagAAAAEEBMTtSgeXLtNN/a5jOickDK7uYASnI8rbtABR8rXvMsVNR3Hq1hsP5M3R8Mfk9XvQ==", "fb0f9624-4cdf-41bc-982a-782c56eaf5e0" });
        }
    }
}
