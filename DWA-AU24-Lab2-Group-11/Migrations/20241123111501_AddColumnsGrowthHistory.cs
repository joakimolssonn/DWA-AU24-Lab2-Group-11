using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DWA_AU24_Lab2_Group_11.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnsGrowthHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CropName",
                table: "GrowthHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DaysBetween",
                table: "GrowthHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "HarvestDate",
                table: "GrowthHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PlantingDate",
                table: "GrowthHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "HarvestTracking",
                keyColumn: "Id",
                keyValue: 1,
                column: "HarvestDate",
                value: new DateTime(2024, 12, 3, 12, 15, 0, 437, DateTimeKind.Local).AddTicks(1256));

            migrationBuilder.UpdateData(
                table: "HarvestTracking",
                keyColumn: "Id",
                keyValue: 2,
                column: "HarvestDate",
                value: new DateTime(2024, 12, 3, 12, 15, 0, 437, DateTimeKind.Local).AddTicks(1263));

            migrationBuilder.UpdateData(
                table: "PlantingSchedule",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlantingDate",
                value: new DateTime(2024, 10, 24, 12, 15, 0, 437, DateTimeKind.Local).AddTicks(1169));

            migrationBuilder.UpdateData(
                table: "PlantingSchedule",
                keyColumn: "Id",
                keyValue: 2,
                column: "PlantingDate",
                value: new DateTime(2024, 9, 24, 12, 15, 0, 437, DateTimeKind.Local).AddTicks(1223));

            migrationBuilder.UpdateData(
                table: "WeatherData",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 23, 12, 15, 0, 437, DateTimeKind.Local).AddTicks(1294));

            migrationBuilder.UpdateData(
                table: "WeatherData",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 23, 12, 15, 0, 437, DateTimeKind.Local).AddTicks(1300));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CropName",
                table: "GrowthHistory");

            migrationBuilder.DropColumn(
                name: "DaysBetween",
                table: "GrowthHistory");

            migrationBuilder.DropColumn(
                name: "HarvestDate",
                table: "GrowthHistory");

            migrationBuilder.DropColumn(
                name: "PlantingDate",
                table: "GrowthHistory");

            migrationBuilder.UpdateData(
                table: "HarvestTracking",
                keyColumn: "Id",
                keyValue: 1,
                column: "HarvestDate",
                value: new DateTime(2024, 12, 2, 18, 9, 30, 72, DateTimeKind.Local).AddTicks(339));

            migrationBuilder.UpdateData(
                table: "HarvestTracking",
                keyColumn: "Id",
                keyValue: 2,
                column: "HarvestDate",
                value: new DateTime(2024, 12, 2, 18, 9, 30, 72, DateTimeKind.Local).AddTicks(345));

            migrationBuilder.UpdateData(
                table: "PlantingSchedule",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlantingDate",
                value: new DateTime(2024, 10, 23, 18, 9, 30, 72, DateTimeKind.Local).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "PlantingSchedule",
                keyColumn: "Id",
                keyValue: 2,
                column: "PlantingDate",
                value: new DateTime(2024, 9, 23, 18, 9, 30, 72, DateTimeKind.Local).AddTicks(312));

            migrationBuilder.UpdateData(
                table: "WeatherData",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 22, 18, 9, 30, 72, DateTimeKind.Local).AddTicks(371));

            migrationBuilder.UpdateData(
                table: "WeatherData",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 22, 18, 9, 30, 72, DateTimeKind.Local).AddTicks(375));
        }
    }
}
