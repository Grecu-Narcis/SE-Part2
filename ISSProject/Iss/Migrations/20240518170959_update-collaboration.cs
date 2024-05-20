using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iss.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCollaboration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdSet_Campaign_CampaignId",
                table: "AdSet");

            migrationBuilder.AddColumn<string>(
                name: "AdAccountId",
                table: "Collaboration",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InfluencerId",
                table: "Collaboration",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CampaignId",
                table: "AdSet",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Collaboration_AdAccountId",
                table: "Collaboration",
                column: "AdAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Collaboration_InfluencerId",
                table: "Collaboration",
                column: "InfluencerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdSet_Campaign_CampaignId",
                table: "AdSet",
                column: "CampaignId",
                principalTable: "Campaign",
                principalColumn: "CampaignId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collaboration_AdAccount_AdAccountId",
                table: "Collaboration",
                column: "AdAccountId",
                principalTable: "AdAccount",
                principalColumn: "AdAccountId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Collaboration_Influencer_InfluencerId",
                table: "Collaboration",
                column: "InfluencerId",
                principalTable: "Influencer",
                principalColumn: "InfluencerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdSet_Campaign_CampaignId",
                table: "AdSet");

            migrationBuilder.DropForeignKey(
                name: "FK_Collaboration_AdAccount_AdAccountId",
                table: "Collaboration");

            migrationBuilder.DropForeignKey(
                name: "FK_Collaboration_Influencer_InfluencerId",
                table: "Collaboration");

            migrationBuilder.DropIndex(
                name: "IX_Collaboration_AdAccountId",
                table: "Collaboration");

            migrationBuilder.DropIndex(
                name: "IX_Collaboration_InfluencerId",
                table: "Collaboration");

            migrationBuilder.DropColumn(
                name: "AdAccountId",
                table: "Collaboration");

            migrationBuilder.DropColumn(
                name: "InfluencerId",
                table: "Collaboration");

            migrationBuilder.AlterColumn<string>(
                name: "CampaignId",
                table: "AdSet",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AdSet_Campaign_CampaignId",
                table: "AdSet",
                column: "CampaignId",
                principalTable: "Campaign",
                principalColumn: "CampaignId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
