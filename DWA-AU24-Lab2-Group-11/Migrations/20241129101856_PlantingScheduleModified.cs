using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DWA_AU24_Lab2_Group_11.Migrations
{
    /// <inheritdoc />
    public partial class PlantingScheduleModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HarvestTracking",
                keyColumn: "Id",
                keyValue: 1,
                column: "HarvestDate",
                value: new DateTime(2024, 12, 9, 11, 18, 55, 236, DateTimeKind.Local).AddTicks(7048));

            migrationBuilder.UpdateData(
                table: "HarvestTracking",
                keyColumn: "Id",
                keyValue: 2,
                column: "HarvestDate",
                value: new DateTime(2024, 12, 9, 11, 18, 55, 236, DateTimeKind.Local).AddTicks(7053));

            migrationBuilder.UpdateData(
                table: "PlantingSchedule",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlantingDate",
                value: new DateTime(2024, 10, 30, 11, 18, 55, 236, DateTimeKind.Local).AddTicks(6965));

            migrationBuilder.UpdateData(
                table: "PlantingSchedule",
                keyColumn: "Id",
                keyValue: 2,
                column: "PlantingDate",
                value: new DateTime(2024, 9, 30, 11, 18, 55, 236, DateTimeKind.Local).AddTicks(7023));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HarvestTracking",
                keyColumn: "Id",
                keyValue: 1,
                column: "HarvestDate",
                value: new DateTime(2024, 12, 5, 10, 16, 48, 969, DateTimeKind.Local).AddTicks(9454));

            migrationBuilder.UpdateData(
                table: "HarvestTracking",
                keyColumn: "Id",
                keyValue: 2,
                column: "HarvestDate",
                value: new DateTime(2024, 12, 5, 10, 16, 48, 969, DateTimeKind.Local).AddTicks(9459));

            migrationBuilder.UpdateData(
                table: "PlantingSchedule",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlantingDate",
                value: new DateTime(2024, 10, 26, 10, 16, 48, 969, DateTimeKind.Local).AddTicks(9384));

            migrationBuilder.UpdateData(
                table: "PlantingSchedule",
                keyColumn: "Id",
                keyValue: 2,
                column: "PlantingDate",
                value: new DateTime(2024, 9, 26, 10, 16, 48, 969, DateTimeKind.Local).AddTicks(9427));
        }
    }
}
