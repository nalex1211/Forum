using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum.Migrations
{
    /// <inheritdoc />
    public partial class _2nd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Discussions_DiscussionsId",
                table: "Comments");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Discussions_DiscussionsId",
                table: "Comments",
                column: "DiscussionsId",
                principalTable: "Discussions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Discussions_DiscussionsId",
                table: "Comments");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Discussions_DiscussionsId",
                table: "Comments",
                column: "DiscussionsId",
                principalTable: "Discussions",
                principalColumn: "Id");
        }
    }
}
