using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DWA_AU24_Lab2_Group_11.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    GrowingDurationInDays = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crop", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    Humidity = table.Column<double>(type: "float", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantingSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cropid = table.Column<int>(type: "int", nullable: false),
                    PlantingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OptimalPlantingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantingSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantingSchedule_Crop_Cropid",
                        column: x => x.Cropid,
                        principalTable: "Crop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrowthHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantingScheduleId = table.Column<int>(type: "int", nullable: false),
                    CropName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlantingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HarvestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaysBetween = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrowthHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrowthHistory_PlantingSchedule_PlantingScheduleId",
                        column: x => x.PlantingScheduleId,
                        principalTable: "PlantingSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HarvestTracking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HarvestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlantingScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HarvestTracking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HarvestTracking_PlantingSchedule_PlantingScheduleId",
                        column: x => x.PlantingScheduleId,
                        principalTable: "PlantingSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    PlantingScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_PlantingSchedule_PlantingScheduleId",
                        column: x => x.PlantingScheduleId,
                        principalTable: "PlantingSchedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    PlantingScheduleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_PlantingSchedule_PlantingScheduleId",
                        column: x => x.PlantingScheduleId,
                        principalTable: "PlantingSchedule",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Crop",
                columns: new[] { "Id", "GrowingDurationInDays", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 90, "Wheat", 120 },
                    { 2, 120, "Tomato", 90 },
                    { 3, 110, "Corn", 120 }
                });

            migrationBuilder.InsertData(
                table: "PlantingSchedule",
                columns: new[] { "Id", "Cropid", "Location", "OptimalPlantingDate", "PlantingDate" },
                values: new object[,]
                {
                    { 1, 1, "Field A", null, new DateTime(2024, 10, 26, 10, 16, 48, 969, DateTimeKind.Local).AddTicks(9384) },
                    { 2, 2, "Greenhouse", null, new DateTime(2024, 9, 26, 10, 16, 48, 969, DateTimeKind.Local).AddTicks(9427) }
                });

            migrationBuilder.InsertData(
                table: "HarvestTracking",
                columns: new[] { "Id", "HarvestDate", "PlantingScheduleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 5, 10, 16, 48, 969, DateTimeKind.Local).AddTicks(9454), 1 },
                    { 2, new DateTime(2024, 12, 5, 10, 16, 48, 969, DateTimeKind.Local).AddTicks(9459), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrowthHistory_PlantingScheduleId",
                table: "GrowthHistory",
                column: "PlantingScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_HarvestTracking_PlantingScheduleId",
                table: "HarvestTracking",
                column: "PlantingScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_PlantingScheduleId",
                table: "Notification",
                column: "PlantingScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantingSchedule_Cropid",
                table: "PlantingSchedule",
                column: "Cropid");

            migrationBuilder.CreateIndex(
                name: "IX_Task_PlantingScheduleId",
                table: "Task",
                column: "PlantingScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrowthHistory");

            migrationBuilder.DropTable(
                name: "HarvestTracking");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "WeatherData");

            migrationBuilder.DropTable(
                name: "PlantingSchedule");

            migrationBuilder.DropTable(
                name: "Crop");
        }
    }
}
