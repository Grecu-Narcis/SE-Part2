using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iss.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCollaboration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaign_AdAccount_AdAccountId",
                table: "Campaign");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaign_AdAccount_AdAccountId",
                table: "Campaign",
                column: "AdAccountId",
                principalTable: "AdAccount",
                principalColumn: "AdAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaign_AdAccount_AdAccountId",
                table: "Campaign");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaign_AdAccount_AdAccountId",
                table: "Campaign",
                column: "AdAccountId",
                principalTable: "AdAccount",
                principalColumn: "AdAccountId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
