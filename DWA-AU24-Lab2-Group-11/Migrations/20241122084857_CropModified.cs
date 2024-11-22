using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DWA_AU24_Lab2_Group_11.Migrations
{
    /// <inheritdoc />
    public partial class CropModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OptimalClimate",
                table: "Crop");

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
                values: new object[] { new DateTime(2024, 12, 2, 9, 48, 56, 692, DateTimeKind.Local).AddTicks(7908), new DateTime(2024, 11, 22, 9, 48, 56, 692, DateTimeKind.Local).AddTicks(7905) });

            migrationBuilder.UpdateData(
                table: "GrowthHistory",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2024, 12, 2, 9, 48, 56, 692, DateTimeKind.Local).AddTicks(7915), new DateTime(2024, 11, 22, 9, 48, 56, 692, DateTimeKind.Local).AddTicks(7912) });

            migrationBuilder.UpdateData(
                table: "HarvestTracking",
                keyColumn: "Id",
                keyValue: 1,
                column: "HarvestDate",
                value: new DateTime(2024, 12, 2, 9, 48, 56, 692, DateTimeKind.Local).AddTicks(7931));

            migrationBuilder.UpdateData(
                table: "HarvestTracking",
                keyColumn: "Id",
                keyValue: 2,
                column: "HarvestDate",
                value: new DateTime(2024, 12, 2, 9, 48, 56, 692, DateTimeKind.Local).AddTicks(7935));

            migrationBuilder.UpdateData(
                table: "PlantingSchedule",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlantingDate",
                value: new DateTime(2024, 10, 23, 9, 48, 56, 692, DateTimeKind.Local).AddTicks(7843));

            migrationBuilder.UpdateData(
                table: "PlantingSchedule",
                keyColumn: "Id",
                keyValue: 2,
                column: "PlantingDate",
                value: new DateTime(2024, 9, 23, 9, 48, 56, 692, DateTimeKind.Local).AddTicks(7888));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OptimalTemperatureMax",
                table: "Crop");

            migrationBuilder.DropColumn(
                name: "OptimalTemperatureMin",
                table: "Crop");

            migrationBuilder.AddColumn<string>(
                name: "OptimalClimate",
                table: "Crop",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Crop",
                keyColumn: "Id",
                keyValue: 1,
                column: "OptimalClimate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Crop",
                keyColumn: "Id",
                keyValue: 2,
                column: "OptimalClimate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Crop",
                keyColumn: "Id",
                keyValue: 3,
                column: "OptimalClimate",
                value: null);

            migrationBuilder.UpdateData(
                table: "GrowthHistory",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2024, 12, 1, 14, 29, 10, 33, DateTimeKind.Local).AddTicks(3619), new DateTime(2024, 11, 21, 14, 29, 10, 33, DateTimeKind.Local).AddTicks(3615) });

            migrationBuilder.UpdateData(
                table: "GrowthHistory",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2024, 12, 1, 14, 29, 10, 33, DateTimeKind.Local).AddTicks(3626), new DateTime(2024, 11, 21, 14, 29, 10, 33, DateTimeKind.Local).AddTicks(3623) });

            migrationBuilder.UpdateData(
                table: "HarvestTracking",
                keyColumn: "Id",
                keyValue: 1,
                column: "HarvestDate",
                value: new DateTime(2024, 12, 1, 14, 29, 10, 33, DateTimeKind.Local).AddTicks(3645));

            migrationBuilder.UpdateData(
                table: "HarvestTracking",
                keyColumn: "Id",
                keyValue: 2,
                column: "HarvestDate",
                value: new DateTime(2024, 12, 1, 14, 29, 10, 33, DateTimeKind.Local).AddTicks(3649));

            migrationBuilder.UpdateData(
                table: "PlantingSchedule",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlantingDate",
                value: new DateTime(2024, 10, 22, 14, 29, 10, 33, DateTimeKind.Local).AddTicks(3540));

            migrationBuilder.UpdateData(
                table: "PlantingSchedule",
                keyColumn: "Id",
                keyValue: 2,
                column: "PlantingDate",
                value: new DateTime(2024, 9, 22, 14, 29, 10, 33, DateTimeKind.Local).AddTicks(3597));
        }
    }
}
