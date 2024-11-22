﻿// <auto-generated />
using System;
using DWA_AU24_Lab2_Group_11.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DWA_AU24_Lab2_Group_11.Migrations
{
    [DbContext(typeof(FarmTrackContext))]
    partial class FarmTrackContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DWA_AU24_Lab2_Group_11.Models.Crop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("GrowingDurationInDays")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Crop");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GrowingDurationInDays = 90,
                            Name = "Wheat",
                            Type = 120
                        },
                        new
                        {
                            Id = 2,
                            GrowingDurationInDays = 120,
                            Name = "Tomato",
                            Type = 90
                        },
                        new
                        {
                            Id = 3,
                            GrowingDurationInDays = 110,
                            Name = "Corn",
                            Type = 120
                        });
                });

            modelBuilder.Entity("DWA_AU24_Lab2_Group_11.Models.GrowthHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("HarvestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PlantingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlantingScheduleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlantingScheduleId");

                    b.ToTable("GrowthHistory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HarvestDate = new DateTime(2024, 12, 2, 13, 42, 42, 832, DateTimeKind.Local).AddTicks(621),
                            PlantingDate = new DateTime(2024, 11, 22, 13, 42, 42, 832, DateTimeKind.Local).AddTicks(616),
                            PlantingScheduleId = 1
                        },
                        new
                        {
                            Id = 2,
                            HarvestDate = new DateTime(2024, 12, 2, 13, 42, 42, 832, DateTimeKind.Local).AddTicks(627),
                            PlantingDate = new DateTime(2024, 11, 22, 13, 42, 42, 832, DateTimeKind.Local).AddTicks(624),
                            PlantingScheduleId = 2
                        });
                });

            modelBuilder.Entity("DWA_AU24_Lab2_Group_11.Models.HarvestTracking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("HarvestDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlantingScheduleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlantingScheduleId");

                    b.ToTable("HarvestTracking");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HarvestDate = new DateTime(2024, 12, 2, 13, 42, 42, 832, DateTimeKind.Local).AddTicks(643),
                            PlantingScheduleId = 1
                        },
                        new
                        {
                            Id = 2,
                            HarvestDate = new DateTime(2024, 12, 2, 13, 42, 42, 832, DateTimeKind.Local).AddTicks(647),
                            PlantingScheduleId = 2
                        });
                });

            modelBuilder.Entity("DWA_AU24_Lab2_Group_11.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NotificationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PlantingScheduleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlantingScheduleId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("DWA_AU24_Lab2_Group_11.Models.PlantingSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cropid")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OptimalPlantingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PlantingDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Cropid");

                    b.ToTable("PlantingSchedule");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cropid = 1,
                            Location = "Field A",
                            PlantingDate = new DateTime(2024, 10, 23, 13, 42, 42, 832, DateTimeKind.Local).AddTicks(551)
                        },
                        new
                        {
                            Id = 2,
                            Cropid = 2,
                            Location = "Greenhouse",
                            PlantingDate = new DateTime(2024, 9, 23, 13, 42, 42, 832, DateTimeKind.Local).AddTicks(599)
                        });
                });

            modelBuilder.Entity("DWA_AU24_Lab2_Group_11.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<int?>("PlantingScheduleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TaskDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TaskDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlantingScheduleId");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("DWA_AU24_Lab2_Group_11.Models.WeatherData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("Humidity")
                        .HasColumnType("float");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlantingScheduleId")
                        .HasColumnType("int");

                    b.Property<double>("Rainfall")
                        .HasColumnType("float");

                    b.Property<double>("Temperature")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PlantingScheduleId");

                    b.ToTable("WeatherData");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2024, 11, 22, 13, 42, 42, 832, DateTimeKind.Local).AddTicks(664),
                            Humidity = 60.0,
                            Location = "Field A",
                            PlantingScheduleId = 1,
                            Rainfall = 5.0,
                            Temperature = 25.0
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2024, 11, 22, 13, 42, 42, 832, DateTimeKind.Local).AddTicks(669),
                            Humidity = 70.0,
                            Location = "Greenhouse",
                            PlantingScheduleId = 2,
                            Rainfall = 10.0,
                            Temperature = 30.0
                        });
                });

            modelBuilder.Entity("DWA_AU24_Lab2_Group_11.Models.GrowthHistory", b =>
                {
                    b.HasOne("DWA_AU24_Lab2_Group_11.Models.PlantingSchedule", "PlantingSchedule")
                        .WithMany()
                        .HasForeignKey("PlantingScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlantingSchedule");
                });

            modelBuilder.Entity("DWA_AU24_Lab2_Group_11.Models.HarvestTracking", b =>
                {
                    b.HasOne("DWA_AU24_Lab2_Group_11.Models.PlantingSchedule", "PlantingSchedule")
                        .WithMany()
                        .HasForeignKey("PlantingScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlantingSchedule");
                });

            modelBuilder.Entity("DWA_AU24_Lab2_Group_11.Models.Notification", b =>
                {
                    b.HasOne("DWA_AU24_Lab2_Group_11.Models.PlantingSchedule", "PlantingSchedule")
                        .WithMany()
                        .HasForeignKey("PlantingScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlantingSchedule");
                });

            modelBuilder.Entity("DWA_AU24_Lab2_Group_11.Models.PlantingSchedule", b =>
                {
                    b.HasOne("DWA_AU24_Lab2_Group_11.Models.Crop", "Crop")
                        .WithMany("PlantingSchedules")
                        .HasForeignKey("Cropid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crop");
                });

            modelBuilder.Entity("DWA_AU24_Lab2_Group_11.Models.Task", b =>
                {
                    b.HasOne("DWA_AU24_Lab2_Group_11.Models.PlantingSchedule", "PlantingSchedule")
                        .WithMany()
                        .HasForeignKey("PlantingScheduleId");

                    b.Navigation("PlantingSchedule");
                });

            modelBuilder.Entity("DWA_AU24_Lab2_Group_11.Models.WeatherData", b =>
                {
                    b.HasOne("DWA_AU24_Lab2_Group_11.Models.PlantingSchedule", "PlantingSchedule")
                        .WithMany()
                        .HasForeignKey("PlantingScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlantingSchedule");
                });

            modelBuilder.Entity("DWA_AU24_Lab2_Group_11.Models.Crop", b =>
                {
                    b.Navigation("PlantingSchedules");
                });
#pragma warning restore 612, 618
        }
    }
}
