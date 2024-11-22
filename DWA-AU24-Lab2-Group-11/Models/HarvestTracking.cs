using System.ComponentModel.DataAnnotations;

namespace DWA_AU24_Lab2_Group_11.Models
{
    public class HarvestTracking
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime? HarvestDate { get; set; } 
        public int PlantingScheduleId { get; set; }
        public PlantingSchedule? PlantingSchedule { get; set; }
        public string HarvestStatus
        {
            get
            {
                return HarvestDate.HasValue
                    ? HarvestDate.Value.ToShortDateString()
                    : "Not harvested yet";
            }
        }
        public string? DaysUntilHarvest
        {
            get
            {
                if (PlantingSchedule?.ExpectedHarvestDate.HasValue == true)
                {
                    var timeSpan = PlantingSchedule.ExpectedHarvestDate.Value - DateTime.Now;

                    // Check if the harvest date has passed
                    if (timeSpan.TotalSeconds <= 0)
                    {
                        return "Harvest time has passed!";
                    }

                    // Calculate days and hours
                    int remainingDays = timeSpan.Days;
                    int remainingHours = timeSpan.Hours;

                    if (remainingDays > 0)
                    {
                        return $"{remainingDays} days, {remainingHours} hours";
                    }
                    else
                    {
                        return $"{remainingHours} hours remaining";
                    }
                }
                return null;
            }
        }
    }
}
