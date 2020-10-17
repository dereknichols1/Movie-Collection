using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieCollections.DataAccess.Migrations
{
    public partial class MovieItemIDsToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieItem_Collections_CollectionsId",
                table: "MovieItem");

            migrationBuilder.DropIndex(
                name: "IX_MovieItem_CollectionsId",
                table: "MovieItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MovieItem_CollectionsId",
                table: "MovieItem",
                column: "CollectionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieItem_Collections_CollectionsId",
                table: "MovieItem",
                column: "CollectionsId",
                principalTable: "Collections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
