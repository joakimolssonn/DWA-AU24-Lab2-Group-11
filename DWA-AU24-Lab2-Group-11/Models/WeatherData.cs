namespace DWA_AU24_Lab2_Group_11.Models
{
    public class WeatherData
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Rainfall { get; set; }
        public string? Location { get; set; }

        // Navigation property to PlantingSchedule
        public int PlantingScheduleId { get; set; }
        public PlantingSchedule PlantingSchedule { get; set; }

    }
}
