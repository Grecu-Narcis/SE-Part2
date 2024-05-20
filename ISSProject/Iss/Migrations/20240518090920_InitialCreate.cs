using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iss.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdAccount",
                columns: table => new
                {
                    AdAccountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameOfCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DomainOfActivity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxIdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeadquartersLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorisingInstituion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdAccount", x => x.AdAccountId);
                });

            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    CampaignId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CampaignName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.CampaignId);
                });

            migrationBuilder.CreateTable(
                name: "Collaboration",
                columns: table => new
                {
                    CollaborationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollaborationTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ContentRequirement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdOverview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollaborationFee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collaboration", x => x.CollaborationId);
                });

            migrationBuilder.CreateTable(
                name: "AdSet",
                columns: table => new
                {
                    AdSetId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetAudience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CampaignId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdSet", x => x.AdSetId);
                    table.ForeignKey(
                        name: "FK_AdSet_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "CampaignId");
                });

            migrationBuilder.CreateTable(
                name: "Ad",
                columns: table => new
                {
                    AdId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebsiteLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdSetId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ad", x => x.AdId);
                    table.ForeignKey(
                        name: "FK_Ad_AdSet_AdSetId",
                        column: x => x.AdSetId,
                        principalTable: "AdSet",
                        principalColumn: "AdSetId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ad_AdSetId",
                table: "Ad",
                column: "AdSetId");

            migrationBuilder.CreateIndex(
                name: "IX_AdSet_CampaignId",
                table: "AdSet",
                column: "CampaignId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ad");

            migrationBuilder.DropTable(
                name: "AdAccount");

            migrationBuilder.DropTable(
                name: "Collaboration");

            migrationBuilder.DropTable(
                name: "AdSet");

            migrationBuilder.DropTable(
                name: "Campaign");
        }
    }
}
