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
    public class HarvestTrackingController : Controller
    {
        private readonly FarmTrackContext _context;

        public HarvestTrackingController(FarmTrackContext context)
        {
            _context = context;
        }

        // GET: HarvestTracking
        public async Task<IActionResult> Index()
        {
            var farmTrackContext = _context.HarvestTracking.Include(h => h.PlantingSchedule);
            return View(await farmTrackContext.ToListAsync());
        }

        // GET: HarvestTracking/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harvestTracking = await _context.HarvestTracking
                .Include(h => h.PlantingSchedule)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (harvestTracking == null)
            {
                return NotFound();
            }

            return View(harvestTracking);
        }

        // GET: HarvestTracking/Create
        public IActionResult Create()
        {
            ViewData["PlantingScheduleId"] = new SelectList(_context.Set<PlantingSchedule>(), "Id", "Id");
            return View();
        }

        // POST: HarvestTracking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HarvestDate,PlantingScheduleId")] HarvestTracking harvestTracking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(harvestTracking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlantingScheduleId"] = new SelectList(_context.Set<PlantingSchedule>(), "Id", "Id", harvestTracking.PlantingScheduleId);
            return View(harvestTracking);
        }

        // GET: HarvestTracking/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harvestTracking = await _context.HarvestTracking.FindAsync(id);
            if (harvestTracking == null)
            {
                return NotFound();
            }
            ViewData["PlantingScheduleId"] = new SelectList(_context.Set<PlantingSchedule>(), "Id", "Id", harvestTracking.PlantingScheduleId);
            return View(harvestTracking);
        }

        // POST: HarvestTracking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HarvestDate,PlantingScheduleId")] HarvestTracking harvestTracking)
        {
            if (id != harvestTracking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(harvestTracking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HarvestTrackingExists(harvestTracking.Id))
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
            ViewData["PlantingScheduleId"] = new SelectList(_context.Set<PlantingSchedule>(), "Id", "Id", harvestTracking.PlantingScheduleId);
            return View(harvestTracking);
        }

        // GET: HarvestTracking/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var harvestTracking = await _context.HarvestTracking
                .Include(h => h.PlantingSchedule)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (harvestTracking == null)
            {
                return NotFound();
            }

            return View(harvestTracking);
        }

        // POST: HarvestTracking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var harvestTracking = await _context.HarvestTracking.FindAsync(id);
            if (harvestTracking != null)
            {
                _context.HarvestTracking.Remove(harvestTracking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HarvestTrackingExists(int id)
        {
            return _context.HarvestTracking.Any(e => e.Id == id);
        }
    }
}
