using System.ComponentModel.DataAnnotations;

namespace DWA_AU24_Lab2_Group_11.Models
{
    public class Crop
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The crop name is required")]
        [StringLength(100, ErrorMessage = "The crop name cannot exceed 100 characters.")]
        [Display(Name = "Crop Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please select a crop type.")]
        public CropType Type { get; set; }
        [Range(1, 365, ErrorMessage = "Growing duration must be between 1 and 365 days.")]
        [Display(Name = "Growing Duration (Days)")]
        public int? GrowingDurationInDays { get; set; }
        public int EffectiveGrowingDurationInDays
        {
            get
            {
                return GrowingDurationInDays ?? (int)Type;
            }
        }

        [StringLength(100)]
        [Display(Name = "Optimal Climate")]
        public string? OptimalClimate { get; set; }
        public ICollection<PlantingSchedule>? PlantingSchedules { get; set; }
    }
}