using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DWA_AU24_Lab2_Group_11.Models;

namespace DWA_AU24_Lab2_Group_11.Data
{
    public class FarmTrackContext : DbContext
    {
        public FarmTrackContext (DbContextOptions<FarmTrackContext> options)
            : base(options)
        {
        }

        public DbSet<DWA_AU24_Lab2_Group_11.Models.Crop> Crop { get; set; } = default!;
        public DbSet<DWA_AU24_Lab2_Group_11.Models.GrowthHistory> GrowthHistory { get; set; } = default!;
        public DbSet<DWA_AU24_Lab2_Group_11.Models.HarvestTracking> HarvestTracking { get; set; } = default!;
        public DbSet<DWA_AU24_Lab2_Group_11.Models.Notification> Notification { get; set; } = default!;
        public DbSet<DWA_AU24_Lab2_Group_11.Models.PlantingSchedule> PlantingSchedule { get; set; } = default!;
        public DbSet<DWA_AU24_Lab2_Group_11.Models.Task> Task { get; set; } = default!;
        public DbSet<DWA_AU24_Lab2_Group_11.Models.WeatherData> WeatherData { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding data for Crop model
            modelBuilder.Entity<Crop>().HasData(
                new Crop { Id = 1, Name = "Wheat", Type = CropType.Grain, GrowingDurationInDays = 90 },
                new Crop { Id = 2, Name = "Tomato", Type = CropType.Vegetable, GrowingDurationInDays = 120 },
                new Crop { Id = 3, Name = "Corn", Type = CropType.Grain, GrowingDurationInDays = 110 }
            );

            // Seeding data for PlantingSchedule model
            modelBuilder.Entity<PlantingSchedule>().HasData(
                new PlantingSchedule { Id = 1, Cropid = 1, PlantingDate = DateTime.Now.AddDays(-30), Location = "Field A" },
                new PlantingSchedule { Id = 2, Cropid = 2, PlantingDate = DateTime.Now.AddDays(-60), Location = "Greenhouse" }
            );


            // Seeding data for GrowthHistory
            modelBuilder.Entity<GrowthHistory>().HasData(
                new GrowthHistory { Id = 1, PlantingScheduleId = 1, PlantingDate = DateTime.Now, HarvestDate = DateTime.Now.AddDays(10) },
                new GrowthHistory { Id = 2, PlantingScheduleId = 2, PlantingDate = DateTime.Now, HarvestDate = DateTime.Now.AddDays(10) }
            );

            // Seeding data for HarvestTracking
            modelBuilder.Entity<HarvestTracking>().HasData(
                new HarvestTracking { Id = 1, PlantingScheduleId = 1, HarvestDate = DateTime.Now.AddDays(10)},
                new HarvestTracking { Id = 2, PlantingScheduleId = 2, HarvestDate = DateTime.Now.AddDays(10)}
            );
        }
    }
}
