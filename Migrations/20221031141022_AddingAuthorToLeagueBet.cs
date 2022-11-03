using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kyniusBETAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingAuthorToLeagueBet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "LeagueBet",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LeagueBet_UserId",
                table: "LeagueBet",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeagueBet_AspNetUsers_UserId",
                table: "LeagueBet",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeagueBet_AspNetUsers_UserId",
                table: "LeagueBet");

            migrationBuilder.DropIndex(
                name: "IX_LeagueBet_UserId",
                table: "LeagueBet");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LeagueBet");
        }
    }
}
