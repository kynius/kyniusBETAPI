using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kyniusBETAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingLeague : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusLong",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "StatusShort",
                table: "Match");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusLong",
                table: "Match",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StatusShort",
                table: "Match",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
