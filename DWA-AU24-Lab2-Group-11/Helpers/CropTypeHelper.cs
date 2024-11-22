using DWA_AU24_Lab2_Group_11.Models;

namespace DWA_AU24_Lab2_Group_11.Helpers
{
    public static class CropTypeHelper
    {
        public static (DateTime Start, DateTime End) GetOptimalPlantingRange(CropType cropType)
        {
            return cropType switch
            {
                CropType.Grain => (new DateTime(2024, 5, 1), new DateTime(2024, 9, 30)),
                CropType.Vegetable => (new DateTime(2024, 8, 1), new DateTime(2024, 10, 31)),
                CropType.Fruit => (new DateTime(2024, 4, 1), new DateTime(2024, 7, 31)),
                CropType.Herb => (new DateTime(2024, 3, 1), new DateTime(2024, 6, 30)),
                CropType.Legume => (new DateTime(2024, 5, 1), new DateTime(2024, 7, 31)),
                CropType.Root => (new DateTime(2024, 4, 1), new DateTime(2024, 6, 30)),
                CropType.Tuber => (new DateTime(2024, 4, 1), new DateTime(2024, 6, 30)),
                CropType.Nut => (new DateTime(2024, 3, 1), new DateTime(2024, 6, 30)),
                CropType.Cereal => (new DateTime(2024, 5, 1), new DateTime(2024, 9, 30)),
                _ => throw new ArgumentException("Unknown CropType")
            };
        }

        public static DateTime GetOptimalPlantingDate(CropType cropType)
        {
            var (start, end) = GetOptimalPlantingRange(cropType);
            return start.AddDays((end - start).Days / 2); // Return midpoint as optimal date
        }
    }
}
