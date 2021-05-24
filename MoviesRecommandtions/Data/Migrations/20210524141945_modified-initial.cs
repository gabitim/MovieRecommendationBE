using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesRecommandtions.Data.Migrations
{
    public partial class modifiedinitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Movie");
        }
    }
}
