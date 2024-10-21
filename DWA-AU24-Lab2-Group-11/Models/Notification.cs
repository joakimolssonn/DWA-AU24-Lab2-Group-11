using System.ComponentModel.DataAnnotations;

namespace DWA_AU24_Lab2_Group_11.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime NotificationDate { get; set; }
        public bool IsRead { get; set; }
        public int PlantingScheduleId { get; set; }
        public PlantingSchedule PlantingSchedule { get; set; }
    }
}
