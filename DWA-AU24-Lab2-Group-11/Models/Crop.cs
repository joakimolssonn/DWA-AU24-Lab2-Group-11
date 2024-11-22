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

        public int OptimalTemperatureMin { get; set; }
        public int OptimalTemperatureMax { get; set; }

        public void SetOptimalTemperatureRange()
        {
            var (min, max) = GetOptimalTemperatureRange(Type);
            OptimalTemperatureMin = min;
            OptimalTemperatureMax = max;
        }

        private (int min, int max) GetOptimalTemperatureRange(CropType cropType)
        {
            return cropType switch
            {
                CropType.Grain => (15, 25),
                CropType.Vegetable => (18, 30),
                CropType.Fruit => (15, 24),
                CropType.Herb => (18, 30),
                CropType.Legume => (15, 30),
                CropType.Root => (10, 22),
                CropType.Tuber => (15, 22),
                CropType.Nut => (17, 29),
                CropType.Cereal => (15, 25),
                _ => throw new ArgumentException("Unknown crop type")
            };
        }

        public ICollection<PlantingSchedule>? PlantingSchedules { get; set; }
    }
}