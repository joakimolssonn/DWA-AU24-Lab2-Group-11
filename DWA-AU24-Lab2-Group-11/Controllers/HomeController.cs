using DWA_AU24_Lab2_Group_11.Data;
using DWA_AU24_Lab2_Group_11.Models;
using DWA_AU24_Lab2_Group_11.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace DWA_AU24_Lab2_Group_11.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FarmTrackContext _context;
        private readonly WeatherApiService _weatherApiService;
        private readonly UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger, FarmTrackContext context, WeatherApiService weatherApiService, UserManager<User> userManager)
        {
            _logger = logger;
            _context = context;
            _weatherApiService = weatherApiService;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            // Fetch all unread notifications (ensure it's not null)
            var notifications = _context.Notification
                                         .Where(n => !n.IsRead)
                                         .ToList();

            if (notifications == null || !notifications.Any())
            {
                _logger.LogWarning("No unread notifications found.");
            }

            // Fetch Tasks where the date has passed or is now and IsCompleted is false
            var tasks = _context.Task
                                .Where(t => t.TaskDate <= DateTime.Now && !t.IsCompleted)
                                .ToList();

            if (tasks == null || !tasks.Any())
            {
                _logger.LogWarning("No tasks found for reminder.");
            }

            var user = await _userManager.GetUserAsync(User);
            WeatherData weatherData = null;

            if (user != null)
            {
                try
                {
                    // Fetch weather data using user's coordinates
                    weatherData = await _weatherApiService.FetchWeatherAsync(user.Latitude, user.Longitude);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to fetch weather data.");
                }
            }


            // Pass data to the view using ViewBag
            ViewBag.Notifications = notifications;
            ViewBag.Tasks = tasks;
            ViewBag.WeatherData = weatherData;

            return View(); // Notifications as the main model
        }

        // Mark notification as read
        [HttpPost]
        public IActionResult MarkAsRead(int id)
        {
            var notification = _context.Notification.Find(id);
            if (notification != null)
            {
                notification.IsRead = true; // Mark the notification as read
                _context.SaveChanges(); // Save changes to the database
            }

            return RedirectToAction("Index"); // Redirect to the Index page after marking as read
        }

        [HttpPost]
        public IActionResult MarkTaskAsCompleted(int id)
        {
            var task = _context.Task.Find(id);
            if (task != null)
            {
                task.IsCompleted = true;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}