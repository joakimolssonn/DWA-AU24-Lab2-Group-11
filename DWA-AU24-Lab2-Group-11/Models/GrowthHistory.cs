using System.ComponentModel.DataAnnotations;

namespace DWA_AU24_Lab2_Group_11.Models
{
    public class GrowthHistory
    {
        public int Id { get; set; }
        public int PlantingScheduleId { get; set; }
        public PlantingSchedule? PlantingSchedule { get; set; }

        public string? Notes { get; set; }

    }
}
