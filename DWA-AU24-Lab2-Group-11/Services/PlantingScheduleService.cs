using DWA_AU24_Lab2_Group_11.Models;

namespace DWA_AU24_Lab2_Group_11.Services
{
    public class PlantingScheduleService
    {
        public DateTime? CalculateOptimalPlantingDate(Crop crop, WeatherData[] weatherForecast)
        {
          
            crop.SetOptimalTemperatureRange();

            foreach (var day in weatherForecast)
            {
                if (day.Temperature >= crop.OptimalTemperatureMin &&
                    day.Temperature <= crop.OptimalTemperatureMax)
                {
                    return day.Date;  
                }
            }

            return null;  
        }
    }
}
