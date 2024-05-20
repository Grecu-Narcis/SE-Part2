using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iss.Migrations
{
    /// <inheritdoc />
    public partial class AutoGenerateKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Influencer",
                columns: table => new
                {
                    InfluencerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InfluencerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FollowerCount = table.Column<int>(type: "int", nullable: false),
                    CollaborationPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Influencer", x => x.InfluencerId);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollaborationTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdOverview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentRequirements = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Compensation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InfluencerAccept = table.Column<bool>(type: "bit", nullable: false),
                    AdAccountAccept = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.RequestId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Influencer");

            migrationBuilder.DropTable(
                name: "Request");
        }
    }
}
