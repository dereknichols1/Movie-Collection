using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieCollections.DataAccess.Migrations
{
    public partial class Collections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_MovieItem_MovieItemId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Collections_MovieItemId",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "MovieItemId",
                table: "Collections");

            migrationBuilder.AddColumn<int>(
                name: "CollectionsId",
                table: "MovieItem",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieItem_Collections_CollectionsId",
                table: "MovieItem");

            migrationBuilder.DropIndex(
                name: "IX_MovieItem_CollectionsId",
                table: "MovieItem");

            migrationBuilder.DropColumn(
                name: "CollectionsId",
                table: "MovieItem");

            migrationBuilder.AddColumn<int>(
                name: "MovieItemId",
                table: "Collections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Collections_MovieItemId",
                table: "Collections",
                column: "MovieItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_MovieItem_MovieItemId",
                table: "Collections",
                column: "MovieItemId",
                principalTable: "MovieItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
