using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DWA_AU24_Lab2_Group_11.Migrations
{
    /// <inheritdoc />
    public partial class WeatherDataCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GrowthHistory",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2024, 12, 2, 10, 1, 45, 576, DateTimeKind.Local).AddTicks(9208), new DateTime(2024, 11, 22, 10, 1, 45, 576, DateTimeKind.Local).AddTicks(9204) });

            migrationBuilder.UpdateData(
                table: "GrowthHistory",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HarvestDate", "PlantingDate" },
                values: new object[] { new DateTime(2024, 12, 2, 10, 1, 45, 576, DateTimeKind.Local).AddTicks(9214), new DateTime(2024, 11, 22, 10, 1, 45, 576, DateTimeKind.Local).AddTicks(9211) });

            migrationBuilder.UpdateData(
                table: "HarvestTracking",
                keyColumn: "Id",
                keyValue: 1,
                column: "HarvestDate",
                value: new DateTime(2024, 12, 2, 10, 1, 45, 576, DateTimeKind.Local).AddTicks(9229));

            migrationBuilder.UpdateData(
                table: "HarvestTracking",
                keyColumn: "Id",
                keyValue: 2,
                column: "HarvestDate",
                value: new DateTime(2024, 12, 2, 10, 1, 45, 576, DateTimeKind.Local).AddTicks(9234));

            migrationBuilder.UpdateData(
                table: "PlantingSchedule",
                keyColumn: "Id",
                keyValue: 1,
                column: "PlantingDate",
                value: new DateTime(2024, 10, 23, 10, 1, 45, 576, DateTimeKind.Local).AddTicks(9136));

            migrationBuilder.UpdateData(
                table: "PlantingSchedule",
                keyColumn: "Id",
                keyValue: 2,
                column: "PlantingDate",
                value: new DateTime(2024, 9, 23, 10, 1, 45, 576, DateTimeKind.Local).AddTicks(9184));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
