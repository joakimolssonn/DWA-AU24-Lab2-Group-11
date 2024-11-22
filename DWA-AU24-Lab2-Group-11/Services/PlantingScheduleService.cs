using DWA_AU24_Lab2_Group_11.Data;
using DWA_AU24_Lab2_Group_11.Models;
using Microsoft.EntityFrameworkCore;

namespace DWA_AU24_Lab2_Group_11.Services
{
    public class PlantingScheduleService
    {
        private readonly FarmTrackContext _context;

        public PlantingScheduleService(FarmTrackContext context)
        {
            _context = context;
        }

        public async Task<DateTime?> CalculateOptimalPlantingDateAsync(Crop crop)
        {
   
            crop.SetOptimalTemperatureRange();

            var weatherData = await _context.WeatherData.ToListAsync();

            foreach (var day in weatherData)
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
