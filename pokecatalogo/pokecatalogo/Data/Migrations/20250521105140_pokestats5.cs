using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pokecatalogo.Data.Migrations
{
    /// <inheritdoc />
    public partial class pokestats5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95babd8f-fb88-4c33-bd75-61d8b9a7f116", "AQAAAAIAAYagAAAAEAOp1trJ8rjewaOTPFqAiA3/q/gBKgwAAmJOgcfNLv0U1BJqmXrgPW/BrQrpxOIF/g==", "6f920307-4a3a-4029-b0e4-2f1f01579efd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "189f03d9-6885-4687-a63a-4593f2ee6bbd", "AQAAAAIAAYagAAAAEB3yepphAoQsC4mMJBWi7AxrWVPxxCsGSP5BdcJAs1KgIfSD+2nch4DRzS63l6Ei+g==", "adbd7026-d210-435c-85b3-9d2373f3ec99" });
        }
    }
}
