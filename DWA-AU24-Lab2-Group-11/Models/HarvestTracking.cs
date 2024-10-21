using System.ComponentModel.DataAnnotations;

namespace DWA_AU24_Lab2_Group_11.Models
{
    public class HarvestTracking
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime HarvestDate { get; set; }
        public int PlantingScheduleId { get; set; }
        public PlantingSchedule PlantingSchedule { get; set; }
        public int DaysUntilHarvest
        {
            get
            {
                return (HarvestDate - DateTime.Now).Days;
            }
        }
    }
}
