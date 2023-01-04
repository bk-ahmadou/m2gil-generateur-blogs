using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace m2gil_generateur_blogs.Migrations
{
    public partial class AddPublishColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Blogs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Blogs");
        }
    }
}
