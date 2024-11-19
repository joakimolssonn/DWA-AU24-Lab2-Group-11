using System.ComponentModel.DataAnnotations;

namespace DWA_AU24_Lab2_Group_11.Models
{
    public class PlantingSchedule
    {
        [Display(Name = "Planting Schedule Id")]
        public int Id { get; set; }
        public int Cropid { get; set; }
        public Crop? Crop { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name="Planting Date")]
        public DateTime PlantingDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name="Optimal Planting Date")]
        public DateTime? OptimalPlantingDate { get; set; }
        public string? Location { get; set; }
        [Display(Name = "Expected Harvest Date")]
        public DateTime? ExpectedHarvestDate
        {
            get
            {
                if (Crop != null)
                {
                    return PlantingDate.AddDays(Crop.EffectiveGrowingDurationInDays); // Use EffectiveGrowingDurationInDays here
                }
                return null;
            }

        }

    }
}
