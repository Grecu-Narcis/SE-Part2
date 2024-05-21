using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApi_ISS.Migrations
{
    /// <inheritdoc />
    public partial class ReviewClassOk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Review",
                newName: "ReviewClass");

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "ReviewClass",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReviewClass",
                table: "ReviewClass",
                column: "ReviewId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReviewClass",
                table: "ReviewClass");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "ReviewClass");

            migrationBuilder.RenameTable(
                name: "ReviewClass",
                newName: "Review");
        }
    }
}
