using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kyniusBETAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangesInScore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Score_Goals_GoalsInExtratimeId",
                table: "Score");

            migrationBuilder.DropIndex(
                name: "IX_Score_GoalsInExtratimeId",
                table: "Score");

            migrationBuilder.DropColumn(
                name: "GoalsInExtratimeId",
                table: "Score");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoalsInExtratimeId",
                table: "Score",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Score_GoalsInExtratimeId",
                table: "Score",
                column: "GoalsInExtratimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Score_Goals_GoalsInExtratimeId",
                table: "Score",
                column: "GoalsInExtratimeId",
                principalTable: "Goals",
                principalColumn: "Id");
        }
    }
}
