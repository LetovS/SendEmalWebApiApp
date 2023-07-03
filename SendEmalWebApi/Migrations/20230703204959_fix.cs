using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SendEmalWebApi.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipientId",
                table: "RequestModels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipientId",
                table: "RequestModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "RequestModels",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecipientId",
                value: 0);
        }
    }
}
