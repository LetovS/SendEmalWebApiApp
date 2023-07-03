using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SendEmalWebApi.Migrations
{
    /// <inheritdoc />
    public partial class fix5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Email_RequestModels_EntityDBId",
                table: "Email");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Email",
                table: "Email");

            migrationBuilder.RenameTable(
                name: "Email",
                newName: "Emails");

            migrationBuilder.RenameIndex(
                name: "IX_Email_EntityDBId",
                table: "Emails",
                newName: "IX_Emails_EntityDBId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emails",
                table: "Emails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_RequestModels_EntityDBId",
                table: "Emails",
                column: "EntityDBId",
                principalTable: "RequestModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_RequestModels_EntityDBId",
                table: "Emails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Emails",
                table: "Emails");

            migrationBuilder.RenameTable(
                name: "Emails",
                newName: "Email");

            migrationBuilder.RenameIndex(
                name: "IX_Emails_EntityDBId",
                table: "Email",
                newName: "IX_Email_EntityDBId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Email",
                table: "Email",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Email_RequestModels_EntityDBId",
                table: "Email",
                column: "EntityDBId",
                principalTable: "RequestModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
