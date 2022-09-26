using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kyniusBETAPI.Migrations
{
    /// <inheritdoc />
    public partial class smallChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Winner",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "ApiId",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "ApiId",
                table: "Score");

            migrationBuilder.DropColumn(
                name: "ApiId",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "Round",
                table: "FootballLeague");

            migrationBuilder.DropColumn(
                name: "Season",
                table: "FootballLeague");

            migrationBuilder.AddColumn<bool>(
                name: "IsAwayWinnerFirstHalf",
                table: "Score",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAwayWinnerFullMatch",
                table: "Score",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAwayWinnerSecondHalf",
                table: "Score",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHomeWinnerFirstHalf",
                table: "Score",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHomeWinnerFullMatch",
                table: "Score",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHomeWinnerSecondHalf",
                table: "Score",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAwayWinnerFirstHalf",
                table: "Score");

            migrationBuilder.DropColumn(
                name: "IsAwayWinnerFullMatch",
                table: "Score");

            migrationBuilder.DropColumn(
                name: "IsAwayWinnerSecondHalf",
                table: "Score");

            migrationBuilder.DropColumn(
                name: "IsHomeWinnerFirstHalf",
                table: "Score");

            migrationBuilder.DropColumn(
                name: "IsHomeWinnerFullMatch",
                table: "Score");

            migrationBuilder.DropColumn(
                name: "IsHomeWinnerSecondHalf",
                table: "Score");

            migrationBuilder.AddColumn<bool>(
                name: "Winner",
                table: "Team",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApiId",
                table: "Status",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApiId",
                table: "Score",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApiId",
                table: "Goals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Round",
                table: "FootballLeague",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Season",
                table: "FootballLeague",
                type: "int",
                nullable: true);
        }
    }
}
