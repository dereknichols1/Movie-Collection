using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieCollections.DataAccess.Migrations
{
    public partial class DisplayOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "MovieItem");

            migrationBuilder.DropColumn(
                name: "ItemCondition",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "MyComments",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "MyRating",
                table: "Collections");

            migrationBuilder.AddColumn<int>(
                name: "ItemCondition",
                table: "MovieItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MyComments",
                table: "MovieItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MyRating",
                table: "MovieItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Collections",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemCondition",
                table: "MovieItem");

            migrationBuilder.DropColumn(
                name: "MyComments",
                table: "MovieItem");

            migrationBuilder.DropColumn(
                name: "MyRating",
                table: "MovieItem");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Collections");

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "MovieItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ItemCondition",
                table: "Collections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MyComments",
                table: "Collections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MyRating",
                table: "Collections",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
