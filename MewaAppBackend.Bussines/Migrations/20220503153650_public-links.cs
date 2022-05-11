using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MewaAppBackend.Business.Migrations
{
    public partial class publiclinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Link",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Link");
        }
    }
}
