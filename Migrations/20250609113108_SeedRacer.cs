using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaceParticipationAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedRacer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Racers",
                columns: new[] { "RacerId", "FirstName", "LastName" },
                values: new object[] { 1, "Lewis", "Hamilton" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Racers",
                keyColumn: "RacerId",
                keyValue: 1);
        }
    }
}
