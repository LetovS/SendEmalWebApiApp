using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SendEmalWebApi.Migrations
{
    /// <inheritdoc />
    public partial class fix3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Result",
                table: "RequestModels",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "RequestModels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Result" },
                values: new object[] { new DateTime(2023, 7, 4, 0, 0, 0, 0, DateTimeKind.Local), "OK" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Result",
                table: "RequestModels",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "RequestModels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Result" },
                values: new object[] { new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Local), 0 });
        }
    }
}
