using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripInfo.Migrations
{
    /// <inheritdoc />
    public partial class PopulateAccommodationData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExistingDatas",
                columns: table => new
                {
                    ExistingDataId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExistingDatas", x => x.ExistingDataId);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Destination = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Accommodation = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripID);
                });

            migrationBuilder.InsertData(
                table: "ExistingDatas",
                columns: new[] { "ExistingDataId", "Email", "PhoneNumber" },
                values: new object[] { 1, "harshachennoor@gmail.com", "3316660212" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExistingDatas");

            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
