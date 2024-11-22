using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DWA_AU24_Lab2_Group_11.Data;
using DWA_AU24_Lab2_Group_11.Models;
using Microsoft.AspNetCore.Authorization;

namespace DWA_AU24_Lab2_Group_11.Controllers
{
    [Authorize]
    public class GrowthHistoryController : Controller
    {
        private readonly FarmTrackContext _context;

        public GrowthHistoryController(FarmTrackContext context)
        {
            _context = context;
        }

        // GET: GrowthHistory 
        public async Task<IActionResult> Index()
        {
            var farmTrackContext = _context.GrowthHistory.Include(g => g.PlantingSchedule);
            return View(await farmTrackContext.ToListAsync());
        }

        // GET: GrowthHistory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var growthHistory = await _context.GrowthHistory
                .Include(g => g.PlantingSchedule)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (growthHistory == null)
            {
                return NotFound();
            }

            return View(growthHistory);
        }

        // GET: GrowthHistory/Create
        public IActionResult Create()
        {
            ViewData["PlantingScheduleId"] = new SelectList(_context.Set<PlantingSchedule>(), "Id", "Id");
            return View();
        }

        // POST: GrowthHistory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlantingScheduleId,PlantingDate,HarvestDate,Notes")] GrowthHistory growthHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(growthHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlantingScheduleId"] = new SelectList(_context.Set<PlantingSchedule>(), "Id", "Id", growthHistory.PlantingScheduleId);
            return View(growthHistory);
        }

        // GET: GrowthHistory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var growthHistory = await _context.GrowthHistory.FindAsync(id);
            if (growthHistory == null)
            {
                return NotFound();
            }
            ViewData["PlantingScheduleId"] = new SelectList(_context.Set<PlantingSchedule>(), "Id", "Id", growthHistory.PlantingScheduleId);
            return View(growthHistory);
        }

        // POST: GrowthHistory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PlantingScheduleId,PlantingDate,HarvestDate,Notes")] GrowthHistory growthHistory)
        {
            if (id != growthHistory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(growthHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrowthHistoryExists(growthHistory.Id))
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
            ViewData["PlantingScheduleId"] = new SelectList(_context.Set<PlantingSchedule>(), "Id", "Id", growthHistory.PlantingScheduleId);
            return View(growthHistory);
        }

        // GET: GrowthHistory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var growthHistory = await _context.GrowthHistory
                .Include(g => g.PlantingSchedule)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (growthHistory == null)
            {
                return NotFound();
            }

            return View(growthHistory);
        }

        // POST: GrowthHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var growthHistory = await _context.GrowthHistory.FindAsync(id);
            if (growthHistory != null)
            {
                _context.GrowthHistory.Remove(growthHistory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrowthHistoryExists(int id)
        {
            return _context.GrowthHistory.Any(e => e.Id == id);
        }
    }
}
