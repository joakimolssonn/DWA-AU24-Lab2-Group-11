using System.ComponentModel.DataAnnotations;

namespace DWA_AU24_Lab2_Group_11.Models
{
    public class PlantingSchedule
    {
        public int Id { get; set; }
        public int Cropid { get; set; }
        public Crop? Crop { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime PlantingDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name="Optimal Planting Date")]
        public DateTime? OptimalPlantingDate { get; set; }
        public string? Location { get; set; }

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
