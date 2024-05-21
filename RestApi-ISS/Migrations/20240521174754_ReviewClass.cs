using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApi_ISS.Migrations
{
    /// <inheritdoc />
    public partial class ReviewClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReviewClass",
                columns: table => new
                {
                    ReviewId = table.Column<string>("int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewClass", x => x.ReviewId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewClass");
        }
    }
}
