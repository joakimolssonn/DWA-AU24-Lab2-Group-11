using System.ComponentModel.DataAnnotations;

namespace DWA_AU24_Lab2_Group_11.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string? TaskDescription { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime TaskDate { get; set; }
        public bool IsCompleted { get; set; }
        public int? PlantingScheduleId { get; set; }
        public PlantingSchedule PlantingSchedule { get; set; }

    }
}
