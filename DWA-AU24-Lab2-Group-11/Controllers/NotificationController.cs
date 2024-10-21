using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DWA_AU24_Lab2_Group_11.Data;
using DWA_AU24_Lab2_Group_11.Models;

namespace DWA_AU24_Lab2_Group_11.Controllers
{
    public class NotificationController : Controller
    {
        private readonly FarmTrackContext _context;

        public NotificationController(FarmTrackContext context)
        {
            _context = context;
        }

        // GET: Notification
        public async Task<IActionResult> Index()
        {
            var farmTrackContext = _context.Notification.Include(n => n.PlantingSchedule);
            return View(await farmTrackContext.ToListAsync());
        }

        // GET: Notification/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = await _context.Notification
                .Include(n => n.PlantingSchedule)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notification == null)
            {
                return NotFound();
            }

            return View(notification);
        }

        // GET: Notification/Create
        public IActionResult Create()
        {
            ViewData["PlantingScheduleId"] = new SelectList(_context.Set<PlantingSchedule>(), "Id", "Id");
            return View();
        }

        // POST: Notification/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Message,NotificationDate,IsRead,PlantingScheduleId")] Notification notification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlantingScheduleId"] = new SelectList(_context.Set<PlantingSchedule>(), "Id", "Id", notification.PlantingScheduleId);
            return View(notification);
        }

        // GET: Notification/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = await _context.Notification.FindAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            ViewData["PlantingScheduleId"] = new SelectList(_context.Set<PlantingSchedule>(), "Id", "Id", notification.PlantingScheduleId);
            return View(notification);
        }

        // POST: Notification/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Message,NotificationDate,IsRead,PlantingScheduleId")] Notification notification)
        {
            if (id != notification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificationExists(notification.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlantingScheduleId"] = new SelectList(_context.Set<PlantingSchedule>(), "Id", "Id", notification.PlantingScheduleId);
            return View(notification);
        }

        // GET: Notification/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notification = await _context.Notification
                .Include(n => n.PlantingSchedule)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notification == null)
            {
                return NotFound();
            }

            return View(notification);
        }

        // POST: Notification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notification = await _context.Notification.FindAsync(id);
            if (notification != null)
            {
                _context.Notification.Remove(notification);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotificationExists(int id)
        {
            return _context.Notification.Any(e => e.Id == id);
        }
    }
}
