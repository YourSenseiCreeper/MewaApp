using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MewaAppBackend.Business.Migrations
{
    public partial class dbimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_File_ThumbnailId",
                table: "Link");

            migrationBuilder.DropIndex(
                name: "IX_Link_ThumbnailId",
                table: "Link");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Link_LinkId",
                        column: x => x.LinkId,
                        principalTable: "Link",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_File_LinkId",
                table: "File",
                column: "LinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_LinkId",
                table: "Images",
                column: "LinkId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_File_Link_LinkId",
                table: "File",
                column: "LinkId",
                principalTable: "Link",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_File_Link_LinkId",
                table: "File");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_File_LinkId",
                table: "File");

            migrationBuilder.CreateIndex(
                name: "IX_Link_ThumbnailId",
                table: "Link",
                column: "ThumbnailId",
                unique: true,
                filter: "[ThumbnailId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Link_File_ThumbnailId",
                table: "Link",
                column: "ThumbnailId",
                principalTable: "File",
                principalColumn: "Id");
        }
    }
}
