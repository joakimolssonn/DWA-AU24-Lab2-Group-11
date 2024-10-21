using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DWA_AU24_Lab2_Group_11.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Crop",
                columns: new[] { "Id", "GrowingDurationInDays", "Name", "OptimalClimate", "Type" },
                values: new object[,]
                {
                    { 1, 90, "Wheat", null, 0 },
                    { 2, 120, "Tomato", null, 1 },
                    { 3, 110, "Corn", null, 0 }
                });

            migrationBuilder.InsertData(
                table: "PlantingSchedule",
                columns: new[] { "Id", "Cropid", "Location", "OptimalPlantingDate", "PlantingDate" },
                values: new object[,]
                {
                    { 1, 1, "Field A", null, new DateTime(2024, 9, 21, 17, 39, 21, 771, DateTimeKind.Local).AddTicks(7410) },
                    { 2, 2, "Greenhouse", null, new DateTime(2024, 8, 22, 17, 39, 21, 771, DateTimeKind.Local).AddTicks(7459) }
                });

            migrationBuilder.InsertData(
                table: "GrowthHistory",
                columns: new[] { "Id", "HarvestDate", "Notes", "PlantingDate", "PlantingScheduleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 31, 17, 39, 21, 771, DateTimeKind.Local).AddTicks(7484), null, new DateTime(2024, 10, 21, 17, 39, 21, 771, DateTimeKind.Local).AddTicks(7480), 1 },
                    { 2, new DateTime(2024, 10, 31, 17, 39, 21, 771, DateTimeKind.Local).AddTicks(7494), null, new DateTime(2024, 10, 21, 17, 39, 21, 771, DateTimeKind.Local).AddTicks(7491), 2 }
                });

            migrationBuilder.InsertData(
                table: "HarvestTracking",
                columns: new[] { "Id", "HarvestDate", "PlantingScheduleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 31, 17, 39, 21, 771, DateTimeKind.Local).AddTicks(7512), 1 },
                    { 2, new DateTime(2024, 10, 31, 17, 39, 21, 771, DateTimeKind.Local).AddTicks(7517), 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Crop",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GrowthHistory",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GrowthHistory",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HarvestTracking",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HarvestTracking",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlantingSchedule",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlantingSchedule",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Crop",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Crop",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
