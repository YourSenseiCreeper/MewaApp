using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MewaAppBackend.Business.Migrations
{
    public partial class groupLvlField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupLvl",
                table: "Group",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupLvl",
                table: "Group");
        }
    }
}
