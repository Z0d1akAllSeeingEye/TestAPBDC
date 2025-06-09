using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaceParticipationAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedLewisHamilton : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RaceParticipations",
                table: "RaceParticipations");

            migrationBuilder.DropIndex(
                name: "IX_RaceParticipations_RacerId",
                table: "RaceParticipations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RaceParticipations",
                table: "RaceParticipations",
                columns: new[] { "RacerId", "TrackRaceId" });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "RaceId", "Date", "Location", "Name" },
                values: new object[] { 2, new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monte Carlo, Monaco", "Monaco Grand Prix" });

            migrationBuilder.InsertData(
                table: "TrackRaces",
                columns: new[] { "TrackRaceId", "BestTimeInSeconds", "Laps", "RaceId", "TrackId" },
                values: new object[] { 1, 5460, 52, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "TrackId",
                keyValue: 1,
                column: "Name",
                value: "Silverstone Circuit");

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "TrackId", "LengthInKm", "Name" },
                values: new object[] { 2, 3.34m, "Monaco Circuit" });

            migrationBuilder.InsertData(
                table: "RaceParticipations",
                columns: new[] { "RacerId", "TrackRaceId", "FinishTimeInSeconds", "Position" },
                values: new object[] { 1, 1, 5460, 1 });

            migrationBuilder.InsertData(
                table: "TrackRaces",
                columns: new[] { "TrackRaceId", "BestTimeInSeconds", "Laps", "RaceId", "TrackId" },
                values: new object[] { 2, 6300, 78, 2, 2 });

            migrationBuilder.InsertData(
                table: "RaceParticipations",
                columns: new[] { "RacerId", "TrackRaceId", "FinishTimeInSeconds", "Position" },
                values: new object[] { 1, 2, 6300, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_RaceParticipations_TrackRaceId",
                table: "RaceParticipations",
                column: "TrackRaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RaceParticipations",
                table: "RaceParticipations");

            migrationBuilder.DropIndex(
                name: "IX_RaceParticipations_TrackRaceId",
                table: "RaceParticipations");

            migrationBuilder.DeleteData(
                table: "RaceParticipations",
                keyColumns: new[] { "RacerId", "TrackRaceId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RaceParticipations",
                keyColumns: new[] { "RacerId", "TrackRaceId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "TrackRaces",
                keyColumn: "TrackRaceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TrackRaces",
                keyColumn: "TrackRaceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Races",
                keyColumn: "RaceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "TrackId",
                keyValue: 2);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RaceParticipations",
                table: "RaceParticipations",
                columns: new[] { "TrackRaceId", "RacerId" });

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "TrackId",
                keyValue: 1,
                column: "Name",
                value: "British Grand Prix");

            migrationBuilder.CreateIndex(
                name: "IX_RaceParticipations_RacerId",
                table: "RaceParticipations",
                column: "RacerId");
        }
    }
}
