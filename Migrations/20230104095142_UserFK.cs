using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace m2gil_generateur_blogs.Migrations
{
    public partial class UserFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplcationUserId",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplcationUserId",
                table: "Blogs");
        }
    }
}
