using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Data;
using InventoryManagement.Models;

namespace InventoryManagement.Controllers
{
    public class UnitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UnitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Units
        public async Task<IActionResult> Index()
        {
              return _context.Units != null ? 
                          View(await _context.Units.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Units'  is null.");
        }

        // GET: Units/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Units == null)
            {
                return NotFound();
            }

            var unitsViewModel = await _context.Units
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unitsViewModel == null)
            {
                return NotFound();
            }

            return View(unitsViewModel);
        }

        // GET: Units/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Units/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ShortName")] UnitsViewModel unitsViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unitsViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unitsViewModel);
        }

        // GET: Units/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Units == null)
            {
                return NotFound();
            }

            var unitsViewModel = await _context.Units.FindAsync(id);
            if (unitsViewModel == null)
            {
                return NotFound();
            }
            return View(unitsViewModel);
        }

        // POST: Units/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ShortName")] UnitsViewModel unitsViewModel)
        {
            if (id != unitsViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unitsViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitsViewModelExists(unitsViewModel.Id))
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
            return View(unitsViewModel);
        }

        // GET: Units/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Units == null)
            {
                return NotFound();
            }

            var unitsViewModel = await _context.Units
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unitsViewModel == null)
            {
                return NotFound();
            }

            return View(unitsViewModel);
        }

        // POST: Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Units == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Units'  is null.");
            }
            var unitsViewModel = await _context.Units.FindAsync(id);
            if (unitsViewModel != null)
            {
                _context.Units.Remove(unitsViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnitsViewModelExists(int id)
        {
          return (_context.Units?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
