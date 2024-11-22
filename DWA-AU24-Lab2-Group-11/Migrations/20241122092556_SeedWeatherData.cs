using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DWA_AU24_Lab2_Group_11.Migrations
{
    /// <inheritdoc />
    public partial class SeedWeatherData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    Humidity = table.Column<double>(type: "float", nullable: false),
                    Rainfall = table.Column<double>(type: "float", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantingScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherData_PlantingSchedule_PlantingScheduleId",
                        column: x => x.PlantingScheduleId,
                        principalTable: "PlantingSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "WeatherData",
                columns: new[] { "Id", "Date", "Humidity", "Location", "PlantingScheduleId", "Rainfall", "Temperature" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 22, 10, 25, 55, 702, DateTimeKind.Local).AddTicks(6864), 60.0, "Field A", 1, 5.0, 25.0 },
                    { 2, new DateTime(2024, 11, 22, 10, 25, 55, 702, DateTimeKind.Local).AddTicks(6869), 70.0, "Greenhouse", 2, 10.0, 30.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeatherData_PlantingScheduleId",
                table: "WeatherData",
                column: "PlantingScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherData");

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
    }
}
