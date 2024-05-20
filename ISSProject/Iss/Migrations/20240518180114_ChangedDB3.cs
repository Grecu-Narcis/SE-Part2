using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iss.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDB3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdAccountId",
                table: "Request",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InfluencerId",
                table: "Request",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Request_AdAccountId",
                table: "Request",
                column: "AdAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_InfluencerId",
                table: "Request",
                column: "InfluencerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_AdAccount_AdAccountId",
                table: "Request",
                column: "AdAccountId",
                principalTable: "AdAccount",
                principalColumn: "AdAccountId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Influencer_InfluencerId",
                table: "Request",
                column: "InfluencerId",
                principalTable: "Influencer",
                principalColumn: "InfluencerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_AdAccount_AdAccountId",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Influencer_InfluencerId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_AdAccountId",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_InfluencerId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "AdAccountId",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "InfluencerId",
                table: "Request");
        }
    }
}
