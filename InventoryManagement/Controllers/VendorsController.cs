using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Data;
using InventoryManagement.Models;
using Microsoft.AspNetCore.Authorization;

namespace InventoryManagement.Controllers
{
    [Authorize]
    public class VendorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VendorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vendors
        public async Task<IActionResult> Index()
        {
              return _context.Vendors != null ? 
                          View(await _context.Vendors.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Vendors'  is null.");
        }

        // GET: Vendors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vendors == null)
            {
                return NotFound();
            }

            var vendorViewModel = await _context.Vendors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendorViewModel == null)
            {
                return NotFound();
            }

            return View(vendorViewModel);
        }

        // GET: Vendors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vendors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] VendorViewModel vendorViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendorViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendorViewModel);
        }

        // GET: Vendors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vendors == null)
            {
                return NotFound();
            }

            var vendorViewModel = await _context.Vendors.FindAsync(id);
            if (vendorViewModel == null)
            {
                return NotFound();
            }
            return View(vendorViewModel);
        }

        // POST: Vendors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] VendorViewModel vendorViewModel)
        {
            if (id != vendorViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendorViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendorViewModelExists(vendorViewModel.Id))
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
            return View(vendorViewModel);
        }

        // GET: Vendors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vendors == null)
            {
                return NotFound();
            }

            var vendorViewModel = await _context.Vendors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendorViewModel == null)
            {
                return NotFound();
            }

            return View(vendorViewModel);
        }

        // POST: Vendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vendors == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Vendors'  is null.");
            }
            var vendorViewModel = await _context.Vendors.FindAsync(id);
            if (vendorViewModel != null)
            {
                _context.Vendors.Remove(vendorViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendorViewModelExists(int id)
        {
          return (_context.Vendors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
