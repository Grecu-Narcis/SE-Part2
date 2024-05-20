using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iss.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ad_AdAccount_AdAccountId",
                table: "Ad");

            migrationBuilder.AddColumn<string>(
                name: "AdAccountId",
                table: "AdSet",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdAccountId",
                table: "Ad",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdSet_AdAccountId",
                table: "AdSet",
                column: "AdAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ad_AdAccount_AdAccountId",
                table: "Ad",
                column: "AdAccountId",
                principalTable: "AdAccount",
                principalColumn: "AdAccountId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdSet_AdAccount_AdAccountId",
                table: "AdSet",
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

            migrationBuilder.DropForeignKey(
                name: "FK_AdSet_AdAccount_AdAccountId",
                table: "AdSet");

            migrationBuilder.DropIndex(
                name: "IX_AdSet_AdAccountId",
                table: "AdSet");

            migrationBuilder.DropColumn(
                name: "AdAccountId",
                table: "AdSet");

            migrationBuilder.AlterColumn<string>(
                name: "AdAccountId",
                table: "Ad",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Ad_AdAccount_AdAccountId",
                table: "Ad",
                column: "AdAccountId",
                principalTable: "AdAccount",
                principalColumn: "AdAccountId");
        }
    }
}
