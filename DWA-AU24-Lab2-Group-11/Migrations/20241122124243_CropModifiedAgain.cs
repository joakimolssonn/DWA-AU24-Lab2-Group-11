using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DWA_AU24_Lab2_Group_11.Migrations
{
    /// <inheritdoc />
    public partial class CropModifiedAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OptimalTemperatureMax",
                table: "Crop");

            migrationBuilder.DropColumn(
                name: "OptimalTemperatureMin",
                table: "Crop");

            migrationBuilder.UpdateData(
                table: "GrowthHistory",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2024, 12, 2, 13, 42, 42, 832, DateTimeKind.Local).AddTicks(621), new DateTime(2024, 11, 22, 13, 42, 42, 832, DateTimeKind.Local).AddTicks(616) });

            migrationBuilder.UpdateData(
                table: "GrowthHistory",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2024, 12, 2, 13, 42, 42, 832, DateTimeKind.Local).AddTicks(627), new DateTime(2024, 11, 22, 13, 42, 42, 832, DateTimeKind.Local).AddTicks(624) });

            migrationBuilder.UpdateData(
                table: "HarvestTracking",
                keyColumn: "Id",
                keyValue: 1,
                column: "HarvestDate",
                value: new DateTime(2024, 12, 2, 13, 42, 42, 832, DateTimeKind.Local).AddTicks(643));

            migrationBuilder.UpdateData(
                table: "HarvestTracking",
                keyColumn: "Id",
                keyValue: 2,
                column: "HarvestDate",
                value: new DateTime(2024, 12, 2, 13, 42, 42, 832, DateTimeKind.Local).AddTicks(647));

            migrationBuilder.UpdateData(
                table: "PlantingSchedule",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlantingDate",
                value: new DateTime(2024, 10, 23, 13, 42, 42, 832, DateTimeKind.Local).AddTicks(551));

            migrationBuilder.UpdateData(
                table: "PlantingSchedule",
                keyColumn: "Id",
                keyValue: 2,
                column: "PlantingDate",
                value: new DateTime(2024, 9, 23, 13, 42, 42, 832, DateTimeKind.Local).AddTicks(599));

            migrationBuilder.UpdateData(
                table: "WeatherData",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 22, 13, 42, 42, 832, DateTimeKind.Local).AddTicks(664));

            migrationBuilder.UpdateData(
                table: "WeatherData",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 22, 13, 42, 42, 832, DateTimeKind.Local).AddTicks(669));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OptimalTemperatureMax",
                table: "Crop",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OptimalTemperatureMin",
                table: "Crop",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Crop",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "OptimalTemperatureMax", "OptimalTemperatureMin" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Crop",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "OptimalTemperatureMax", "OptimalTemperatureMin" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Crop",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "OptimalTemperatureMax", "OptimalTemperatureMin" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "GrowthHistory",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2024, 12, 2, 10, 25, 55, 702, DateTimeKind.Local).AddTicks(6822), new DateTime(2024, 11, 22, 10, 25, 55, 702, DateTimeKind.Local).AddTicks(6815) });

            migrationBuilder.UpdateData(
                table: "GrowthHistory",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2024, 12, 2, 10, 25, 55, 702, DateTimeKind.Local).AddTicks(6828), new DateTime(2024, 11, 22, 10, 25, 55, 702, DateTimeKind.Local).AddTicks(6826) });

            migrationBuilder.UpdateData(
                table: "HarvestTracking",
                keyColumn: "Id",
                keyValue: 1,
                column: "HarvestDate",
                value: new DateTime(2024, 12, 2, 10, 25, 55, 702, DateTimeKind.Local).AddTicks(6844));

            migrationBuilder.UpdateData(
                table: "HarvestTracking",
                keyColumn: "Id",
                keyValue: 2,
                column: "HarvestDate",
                value: new DateTime(2024, 12, 2, 10, 25, 55, 702, DateTimeKind.Local).AddTicks(6848));

            migrationBuilder.UpdateData(
                table: "PlantingSchedule",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlantingDate",
                value: new DateTime(2024, 10, 23, 10, 25, 55, 702, DateTimeKind.Local).AddTicks(6752));

            migrationBuilder.UpdateData(
                table: "PlantingSchedule",
                keyColumn: "Id",
                keyValue: 2,
                column: "PlantingDate",
                value: new DateTime(2024, 9, 23, 10, 25, 55, 702, DateTimeKind.Local).AddTicks(6799));

            migrationBuilder.UpdateData(
                table: "WeatherData",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 11, 22, 10, 25, 55, 702, DateTimeKind.Local).AddTicks(6864));

            migrationBuilder.UpdateData(
                table: "WeatherData",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 11, 22, 10, 25, 55, 702, DateTimeKind.Local).AddTicks(6869));
        }
    }
}
