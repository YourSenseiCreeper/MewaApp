using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MewaAppBackend.Business.Migrations
{
    public partial class modeltweaks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_AspNetUsers_UserId",
                table: "Link");

            migrationBuilder.DropForeignKey(
                name: "FK_Link_File_FileId",
                table: "Link");

            migrationBuilder.DropIndex(
                name: "IX_Link_FileId",
                table: "Link");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Link",
                newName: "OwnerId");

            migrationBuilder.RenameColumn(
                name: "FileId",
                table: "Link",
                newName: "ThumbnailId");

            migrationBuilder.RenameIndex(
                name: "IX_Link_UserId",
                table: "Link",
                newName: "IX_Link_OwnerId");

            migrationBuilder.AddColumn<int>(
                name: "LinkId",
                table: "Tag",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Link",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "SYSDATETIME()");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Link",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_LinkId",
                table: "Tag",
                column: "LinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_ThumbnailId",
                table: "Link",
                column: "ThumbnailId",
                unique: true,
                filter: "[ThumbnailId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Link_AspNetUsers_OwnerId",
                table: "Link",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Link_File_ThumbnailId",
                table: "Link",
                column: "ThumbnailId",
                principalTable: "File",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Link_LinkId",
                table: "Tag",
                column: "LinkId",
                principalTable: "Link",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Link_AspNetUsers_OwnerId",
                table: "Link");

            migrationBuilder.DropForeignKey(
                name: "FK_Link_File_ThumbnailId",
                table: "Link");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Link_LinkId",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Tag_LinkId",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Link_ThumbnailId",
                table: "Link");

            migrationBuilder.DropColumn(
                name: "LinkId",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Link");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Link");

            migrationBuilder.RenameColumn(
                name: "ThumbnailId",
                table: "Link",
                newName: "FileId");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Link",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Link_OwnerId",
                table: "Link",
                newName: "IX_Link_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_FileId",
                table: "Link",
                column: "FileId",
                unique: true,
                filter: "[FileId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Link_AspNetUsers_UserId",
                table: "Link",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Link_File_FileId",
                table: "Link",
                column: "FileId",
                principalTable: "File",
                principalColumn: "Id");
        }
    }
}
