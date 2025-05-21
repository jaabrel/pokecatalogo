using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pokecatalogo.Data.Migrations
{
    /// <inheritdoc />
    public partial class pokestats4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "189f03d9-6885-4687-a63a-4593f2ee6bbd", "AQAAAAIAAYagAAAAEB3yepphAoQsC4mMJBWi7AxrWVPxxCsGSP5BdcJAs1KgIfSD+2nch4DRzS63l6Ei+g==", "adbd7026-d210-435c-85b3-9d2373f3ec99" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1241e9da-37cb-4b6c-b5c7-79c36b062fe7", "AQAAAAIAAYagAAAAEDar2AVACl3LRjUPPTKfJJxEiUbGNfOwqMQ30+2oHaG5MixiOfTJmy5i87HWxkA1iA==", "ff55d21f-d828-49ad-8516-672eafac3e78" });
        }
    }
}
