using DWA_AU24_Lab2_Group_11.Data;
using DWA_AU24_Lab2_Group_11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace DWA_AU24_Lab2_Group_11.Services
{
    public class NotificationService : IHostedService, IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<NotificationService> _logger;
        private Timer _timer;

        public NotificationService(IServiceProvider serviceProvider, ILogger<NotificationService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Log the start of the service
            _logger.LogInformation("Notification service started at: {Time}", DateTime.Now);

            // Start the timer to check for notifications every 1 minute (for testing purposes)
            _timer = new Timer(HandleNotifications, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }

        public void HandleNotifications(object state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<FarmTrackContext>();
                var plantingSchedules = _context.PlantingSchedule.Include(p => p.Crop).ToList();

                foreach (var schedule in plantingSchedules)
                {
                    var expectedHarvestDate = schedule.PlantingDate.AddDays(schedule.Crop.EffectiveGrowingDurationInDays);
                    var daysRemaining = (expectedHarvestDate - DateTime.Now.Date).Days;

                    // Log the status of the planting schedules being checked
                    _logger.LogInformation("Checking schedule ID: {ScheduleId} with {DaysRemaining} days until harvest", schedule.Id, daysRemaining);

                    // Create a notification for 7 days before the expected harvest date
                    if (daysRemaining == 7)
                    {
                        var existingNotification = _context.Notification
                            .Any(n => n.PlantingScheduleId == schedule.Id && n.NotificationDate == DateTime.Now.Date);
                        if (!existingNotification)
                        {
                            _context.Notification.Add(new Notification
                            {
                                Message = $"Your {schedule.Crop.Name} crop planted on {schedule.PlantingDate.ToShortDateString()} is due for harvest in 7 days at {schedule.Location}.",
                                NotificationDate = DateTime.Now.Date,
                                IsRead = false,
                                PlantingScheduleId = schedule.Id
                            });

                            _logger.LogInformation("Notification created for 7 days before harvest for schedule ID: {ScheduleId}", schedule.Id);
                        }
                    }

                    // Create a notification for 1 day before the expected harvest date
                    if (daysRemaining == 1)
                    {
                        var existingNotification = _context.Notification
                            .Any(n => n.PlantingScheduleId == schedule.Id && n.NotificationDate == DateTime.Now.Date);
                        if (!existingNotification)
                        {
                            _context.Notification.Add(new Notification
                            {
                                Message = $"Your {schedule.Crop.Name} crop planted on {schedule.PlantingDate.ToShortDateString()} is due to be harvested tomorrow at {schedule.Location}!",
                                NotificationDate = DateTime.Now.Date,
                                IsRead = false,
                                PlantingScheduleId = schedule.Id
                            });

                            _logger.LogInformation("Notification created for 1 day before harvest for schedule ID: {ScheduleId}", schedule.Id);
                        }
                    }
                }

                _context.SaveChanges();
                _logger.LogInformation("Notifications have been checked and saved to the database.");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

       
    }
}