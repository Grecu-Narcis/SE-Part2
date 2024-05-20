using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iss.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCollaboration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collaboration_AdAccount_AdAccountId",
                table: "Collaboration");

            migrationBuilder.AlterColumn<string>(
                name: "AdAccountId",
                table: "Collaboration",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Collaboration_AdAccount_AdAccountId",
                table: "Collaboration",
                column: "AdAccountId",
                principalTable: "AdAccount",
                principalColumn: "AdAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collaboration_AdAccount_AdAccountId",
                table: "Collaboration");

            migrationBuilder.AlterColumn<string>(
                name: "AdAccountId",
                table: "Collaboration",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Collaboration_AdAccount_AdAccountId",
                table: "Collaboration",
                column: "AdAccountId",
                principalTable: "AdAccount",
                principalColumn: "AdAccountId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
