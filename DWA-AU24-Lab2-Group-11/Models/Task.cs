using System.ComponentModel.DataAnnotations;

namespace DWA_AU24_Lab2_Group_11.Models
{
    public class Task
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string TaskName { get; set; }
        [Display(Name = "Description")]
        public string? TaskDescription { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Task Date")]
        public DateTime TaskDate { get; set; }
        [Display(Name = "Completed")]
        public bool IsCompleted { get; set; }
        
        public int? PlantingScheduleId { get; set; }
        [Display(Name = "Planting Schedule")]
        public PlantingSchedule? PlantingSchedule { get; set; }

    }
}
