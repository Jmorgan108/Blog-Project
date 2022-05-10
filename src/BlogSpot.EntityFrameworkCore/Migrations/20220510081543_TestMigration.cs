using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSpot.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AppPosts_AuthorId",
                table: "AppPosts",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppPosts_AppAuthors_AuthorId",
                table: "AppPosts",
                column: "AuthorId",
                principalTable: "AppAuthors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppPosts_AppAuthors_AuthorId",
                table: "AppPosts");

            migrationBuilder.DropIndex(
                name: "IX_AppPosts_AuthorId",
                table: "AppPosts");
        }
    }
}
