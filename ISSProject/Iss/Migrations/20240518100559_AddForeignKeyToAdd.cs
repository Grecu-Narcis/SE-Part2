using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iss.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdAccountId",
                table: "Ad",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ad_AdAccountId",
                table: "Ad",
                column: "AdAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ad_AdAccount_AdAccountId",
                table: "Ad",
                column: "AdAccountId",
                principalTable: "AdAccount",
                principalColumn: "AdAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ad_AdAccount_AdAccountId",
                table: "Ad");

            migrationBuilder.DropIndex(
                name: "IX_Ad_AdAccountId",
                table: "Ad");

            migrationBuilder.DropColumn(
                name: "AdAccountId",
                table: "Ad");
        }
    }
}
