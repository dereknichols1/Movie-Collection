using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieCollections.DataAccess.Migrations
{
    public partial class UserMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovie_Movie_MovieId",
                table: "UserMovie");

            migrationBuilder.DropIndex(
                name: "IX_UserMovie_MovieId",
                table: "UserMovie");

            migrationBuilder.DropColumn(
                name: "MyComments",
                table: "MovieItem");

            migrationBuilder.DropColumn(
                name: "MyRating",
                table: "MovieItem");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Movie");

            migrationBuilder.AddColumn<int>(
                name: "MovieItemId",
                table: "UserMovie",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MovieItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyComments",
                table: "Movie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserMovie_MovieItemId",
                table: "UserMovie",
                column: "MovieItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovie_MovieItem_MovieItemId",
                table: "UserMovie",
                column: "MovieItemId",
                principalTable: "MovieItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovie_MovieItem_MovieItemId",
                table: "UserMovie");

            migrationBuilder.DropIndex(
                name: "IX_UserMovie_MovieItemId",
                table: "UserMovie");

            migrationBuilder.DropColumn(
                name: "MovieItemId",
                table: "UserMovie");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MovieItem");

            migrationBuilder.DropColumn(
                name: "MyComments",
                table: "Movie");

            migrationBuilder.AddColumn<int>(
                name: "MyComments",
                table: "MovieItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MyRating",
                table: "MovieItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserMovie_MovieId",
                table: "UserMovie",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovie_Movie_MovieId",
                table: "UserMovie",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
