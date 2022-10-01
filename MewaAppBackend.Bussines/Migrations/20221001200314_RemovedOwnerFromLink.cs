using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MewaAppBackend.Business.Migrations
{
    public partial class RemovedOwnerFromLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_AspNetUsers_OwnerId",
                table: "Link");

            migrationBuilder.DropIndex(
                name: "IX_Link_OwnerId",
                table: "Link");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Link");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Link",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Link_OwnerId",
                table: "Link",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Link_AspNetUsers_OwnerId",
                table: "Link",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
