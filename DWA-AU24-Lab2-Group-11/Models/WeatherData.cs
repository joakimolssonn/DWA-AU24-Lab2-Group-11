namespace DWA_AU24_Lab2_Group_11.Models
{
    public class WeatherData
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public string Location { get; set; }
        public string Icon { get; set; } // Add this property
    }

}
