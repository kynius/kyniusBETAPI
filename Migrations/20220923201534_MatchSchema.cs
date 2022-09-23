using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kyniusBETAPI.Migrations
{
    /// <inheritdoc />
    public partial class MatchSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FootballLeague",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Flag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Season = table.Column<int>(type: "int", nullable: true),
                    Round = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballLeague", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiId = table.Column<int>(type: "int", nullable: false),
                    Home = table.Column<int>(type: "int", nullable: true),
                    Away = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiId = table.Column<int>(type: "int", nullable: false),
                    Long = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Short = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Elapsed = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Winner = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Score",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiId = table.Column<int>(type: "int", nullable: false),
                    HalftimeId = table.Column<int>(type: "int", nullable: true),
                    FulltimeId = table.Column<int>(type: "int", nullable: true),
                    ExtratimeId = table.Column<int>(type: "int", nullable: true),
                    PenaltyId = table.Column<int>(type: "int", nullable: true),
                    GoalsInFirsthalfId = table.Column<int>(type: "int", nullable: true),
                    GoalsInSecondhalfId = table.Column<int>(type: "int", nullable: true),
                    GoalsInExtratimeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Score", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Score_Goals_ExtratimeId",
                        column: x => x.ExtratimeId,
                        principalTable: "Goals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Score_Goals_FulltimeId",
                        column: x => x.FulltimeId,
                        principalTable: "Goals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Score_Goals_GoalsInExtratimeId",
                        column: x => x.GoalsInExtratimeId,
                        principalTable: "Goals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Score_Goals_GoalsInFirsthalfId",
                        column: x => x.GoalsInFirsthalfId,
                        principalTable: "Goals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Score_Goals_GoalsInSecondhalfId",
                        column: x => x.GoalsInSecondhalfId,
                        principalTable: "Goals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Score_Goals_HalftimeId",
                        column: x => x.HalftimeId,
                        principalTable: "Goals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Score_Goals_PenaltyId",
                        column: x => x.PenaltyId,
                        principalTable: "Goals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiId = table.Column<int>(type: "int", nullable: false),
                    Referee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Timestamp = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    FootballLeagueId = table.Column<int>(type: "int", nullable: true),
                    HomeId = table.Column<int>(type: "int", nullable: true),
                    AwayId = table.Column<int>(type: "int", nullable: true),
                    GoalsId = table.Column<int>(type: "int", nullable: true),
                    ScoreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_FootballLeague_FootballLeagueId",
                        column: x => x.FootballLeagueId,
                        principalTable: "FootballLeague",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Match_Goals_GoalsId",
                        column: x => x.GoalsId,
                        principalTable: "Goals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Match_Score_ScoreId",
                        column: x => x.ScoreId,
                        principalTable: "Score",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Match_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Match_Team_AwayId",
                        column: x => x.AwayId,
                        principalTable: "Team",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Match_Team_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Team",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Match_AwayId",
                table: "Match",
                column: "AwayId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_FootballLeagueId",
                table: "Match",
                column: "FootballLeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_GoalsId",
                table: "Match",
                column: "GoalsId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_HomeId",
                table: "Match",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_ScoreId",
                table: "Match",
                column: "ScoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_StatusId",
                table: "Match",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Score_ExtratimeId",
                table: "Score",
                column: "ExtratimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Score_FulltimeId",
                table: "Score",
                column: "FulltimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Score_GoalsInExtratimeId",
                table: "Score",
                column: "GoalsInExtratimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Score_GoalsInFirsthalfId",
                table: "Score",
                column: "GoalsInFirsthalfId");

            migrationBuilder.CreateIndex(
                name: "IX_Score_GoalsInSecondhalfId",
                table: "Score",
                column: "GoalsInSecondhalfId");

            migrationBuilder.CreateIndex(
                name: "IX_Score_HalftimeId",
                table: "Score",
                column: "HalftimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Score_PenaltyId",
                table: "Score",
                column: "PenaltyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "FootballLeague");

            migrationBuilder.DropTable(
                name: "Score");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Goals");
        }
    }
}
