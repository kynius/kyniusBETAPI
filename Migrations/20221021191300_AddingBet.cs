using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kyniusBETAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingBet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeagueUserId = table.Column<int>(type: "int", nullable: false),
                    BetType = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bet_LeagueUser_LeagueUserId",
                        column: x => x.LeagueUserId,
                        principalTable: "LeagueUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bet_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bet_LeagueUserId",
                table: "Bet",
                column: "LeagueUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_MatchId",
                table: "Bet",
                column: "MatchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bet");
        }
    }
}
