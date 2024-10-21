namespace DWA_AU24_Lab2_Group_11.Models
{
    public class Crop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CropType Type { get; set; }
        public int? GrowingDurationInDays { get; set; }
        public string? OptimalClimate { get; set; }
        public ICollection<PlantingSchedule> PlantingSchedules { get; set; }


    }
}
