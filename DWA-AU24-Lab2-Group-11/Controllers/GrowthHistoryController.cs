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
            var growthHistories = await _context.GrowthHistory.ToListAsync();
            return View(growthHistories);
        }

        // GET: GrowthHistory/Details/5
       

        // GET: GrowthHistory/Create
        public IActionResult Create()
        {
            var harvestedSchedules = _context.HarvestTracking
                .Where(ht => ht.HarvestDate.HasValue) // Only harvested schedules
                .Select(ht => new
                {
                    ht.PlantingScheduleId,
                    DisplayName = $"{ht.PlantingSchedule.Crop.Name} (Planted: {ht.PlantingSchedule.PlantingDate.ToShortDateString()})"
                })
                .ToList();

            ViewBag.PlantingScheduleId = new SelectList(harvestedSchedules, "PlantingScheduleId", "DisplayName");

            return View();
        }


        // POST: GrowthHistory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlantingScheduleId,Notes")] GrowthHistory growthHistory)
        {
            if (ModelState.IsValid)
            {
                // Fetch the associated PlantingSchedule and ensure it has an associated Crop and HarvestTracking with HarvestDate
                var plantingSchedule = await _context.PlantingSchedule
                    .Include(ps => ps.Crop)  // Include the Crop to avoid null reference
                    .FirstOrDefaultAsync(ps => ps.Id == growthHistory.PlantingScheduleId);

                var harvestTracking = await _context.HarvestTracking
                    .FirstOrDefaultAsync(ht => ht.PlantingScheduleId == growthHistory.PlantingScheduleId);

                if (plantingSchedule == null || harvestTracking == null || !harvestTracking.HarvestDate.HasValue)
                {
                    // If PlantingSchedule or HarvestTracking is not found, or HarvestDate is not set, return an error
                    ModelState.AddModelError("", "Invalid Planting Schedule or Harvest Date not set.");
                    return View(growthHistory);
                }

                // Populate GrowthHistory fields
                growthHistory.CropName = plantingSchedule.Crop?.Name;  // Get Crop name from the PlantingSchedule
                growthHistory.PlantingDate = plantingSchedule.PlantingDate;
                growthHistory.HarvestDate = harvestTracking.HarvestDate.Value;

                // Calculate DaysBetween as the number of days between PlantingDate and HarvestDate
                growthHistory.DaysBetween = (growthHistory.HarvestDate - growthHistory.PlantingDate).Days;

                _context.Add(growthHistory);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
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

            return View(growthHistory);
        }



        // POST: GrowthHistory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Notes")] GrowthHistory growthHistory)
        {
            if (id != growthHistory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Fetch the existing GrowthHistory entity
                    var existingGrowthHistory = await _context.GrowthHistory.FindAsync(id);
                    if (existingGrowthHistory == null)
                    {
                        return NotFound();
                    }

                    // Update only the Notes field
                    existingGrowthHistory.Notes = growthHistory.Notes;

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
