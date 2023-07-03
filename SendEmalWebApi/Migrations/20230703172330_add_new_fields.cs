using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SendEmalWebApi.Migrations
{
    /// <inheritdoc />
    public partial class add_new_fields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "RequestModels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FieledMessage",
                table: "RequestModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Result",
                table: "RequestModels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "RequestModels");

            migrationBuilder.DropColumn(
                name: "FieledMessage",
                table: "RequestModels");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "RequestModels");
        }
    }
}
