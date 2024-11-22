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
using DWA_AU24_Lab2_Group_11.Services;

namespace DWA_AU24_Lab2_Group_11.Controllers
{
    [Authorize]
    public class PlantingScheduleController : Controller
    {
        private readonly FarmTrackContext _context;
        private readonly PlantingScheduleService _plantingScheduleService;

        public PlantingScheduleController(FarmTrackContext context, PlantingScheduleService plantingScheduleService)
        {
            _context = context;
            _plantingScheduleService = plantingScheduleService;
        }

        // GET: PlantingSchedule
        public async Task<IActionResult> Index()
        {
            var farmTrackContext = _context.PlantingSchedule.Include(p => p.Crop);
            return View(await farmTrackContext.ToListAsync());
        }

        // GET: PlantingSchedule/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantingSchedule = await _context.PlantingSchedule
                .Include(p => p.Crop)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plantingSchedule == null)
            {
                return NotFound();
            }

            return View(plantingSchedule);
        }

        // GET: PlantingSchedule/Create
        public IActionResult Create()
        {
            ViewData["Cropid"] = new SelectList(_context.Crop, "Id", "Name");
            return View();
        }

        // POST: PlantingSchedule/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cropid,PlantingDate,Location")] PlantingSchedule plantingSchedule)
        {
            if (ModelState.IsValid)
            {
                // Fetch the associated crop
                var crop = await _context.Crop.FindAsync(plantingSchedule.Cropid);
                if (crop == null)
                {
                    return NotFound("Crop not found.");
                }

                // Calculate the optimal planting date
                plantingSchedule.OptimalPlantingDate = await _plantingScheduleService.CalculateOptimalPlantingDateAsync(crop);

                // Save the planting schedule with the calculated optimal planting date
                _context.Add(plantingSchedule);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["Cropid"] = new SelectList(_context.Crop, "Id", "Name", plantingSchedule.Cropid);
            return View(plantingSchedule);
        }

        // GET: PlantingSchedule/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantingSchedule = await _context.PlantingSchedule.FindAsync(id);
            if (plantingSchedule == null)
            {
                return NotFound();
            }
            ViewData["Cropid"] = new SelectList(_context.Crop, "Id", "Name", plantingSchedule.Cropid);
            return View(plantingSchedule);
        }

        // POST: PlantingSchedule/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cropid,PlantingDate,Location")] PlantingSchedule plantingSchedule)
        {
            if (id != plantingSchedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Fetch the associated crop
                    var crop = await _context.Crop.FindAsync(plantingSchedule.Cropid);
                    if (crop == null)
                    {
                        return NotFound("Crop not found.");
                    }

                    // Recalculate the optimal planting date
                    plantingSchedule.OptimalPlantingDate = await _plantingScheduleService.CalculateOptimalPlantingDateAsync(crop);

                    // Update the planting schedule
                    _context.Update(plantingSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlantingScheduleExists(plantingSchedule.Id))
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

            ViewData["Cropid"] = new SelectList(_context.Crop, "Id", "Name", plantingSchedule.Cropid);
            return View(plantingSchedule);
        }

        // GET: PlantingSchedule/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plantingSchedule = await _context.PlantingSchedule
                .Include(p => p.Crop)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plantingSchedule == null)
            {
                return NotFound();
            }

            return View(plantingSchedule);
        }

        // POST: PlantingSchedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plantingSchedule = await _context.PlantingSchedule.FindAsync(id);
            if (plantingSchedule != null)
            {
                _context.PlantingSchedule.Remove(plantingSchedule);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlantingScheduleExists(int id)
        {
            return _context.PlantingSchedule.Any(e => e.Id == id);
        }

        [HttpGet]
        public async Task<IActionResult> GetOptimalPlantingDate(int cropId)
        {
            var crop = await _context.Crop.FindAsync(cropId);
            if (crop == null)
            {
                return NotFound("Crop not found.");
            }

            var optimalPlantingDate = await _plantingScheduleService.CalculateOptimalPlantingDateAsync(crop);
            return Json(new { OptimalPlantingDate = optimalPlantingDate?.ToString("yyyy-MM-dd") });
        }

    }
}
