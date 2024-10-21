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
    public class PlantingScheduleController : Controller
    {
        private readonly FarmTrackContext _context;

        public PlantingScheduleController(FarmTrackContext context)
        {
            _context = context;
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
            ViewData["Cropid"] = new SelectList(_context.Crop, "Id", "Id");
            return View();
        }

        // POST: PlantingSchedule/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cropid,PlantingDate,OptimalPlantingDate,Location")] PlantingSchedule plantingSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plantingSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cropid"] = new SelectList(_context.Crop, "Id", "Id", plantingSchedule.Cropid);
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
            ViewData["Cropid"] = new SelectList(_context.Crop, "Id", "Id", plantingSchedule.Cropid);
            return View(plantingSchedule);
        }

        // POST: PlantingSchedule/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cropid,PlantingDate,OptimalPlantingDate,Location")] PlantingSchedule plantingSchedule)
        {
            if (id != plantingSchedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
            ViewData["Cropid"] = new SelectList(_context.Crop, "Id", "Id", plantingSchedule.Cropid);
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
    }
}
