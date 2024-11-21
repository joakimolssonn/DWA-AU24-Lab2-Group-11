using DWA_AU24_Lab2_Group_11.Data;
using DWA_AU24_Lab2_Group_11.Models;
using DWA_AU24_Lab2_Group_11.Services;
using Microsoft.AspNetCore.Authorization;
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

        public HomeController(ILogger<HomeController> logger, FarmTrackContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            // Fetch all unread notifications (you can modify this to show only unread ones)
            var notifications = _context.Notification
                                         .Where(n => !n.IsRead)  // Optionally filter for unread notifications
                                         .ToList();
            return View(notifications); // Pass notifications to the view
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