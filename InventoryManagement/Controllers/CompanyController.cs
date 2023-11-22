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
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Company
        public async Task<IActionResult> Index()
        {
              return _context.CompanyViewModel != null ? 
                          View(await _context.CompanyViewModel.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CompanyViewModel'  is null.");
        }

        // GET: Company/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CompanyViewModel == null)
            {
                return NotFound();
            }

            var companyViewModel = await _context.CompanyViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyViewModel == null)
            {
                return NotFound();
            }

            return View(companyViewModel);
        }

        // GET: Company/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyName,transportName,Address,City,State,Country,PhoneNo,Mobile,EmailId,ZipCode,GstNo")] CompanyViewModel companyViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companyViewModel);
        }

        // GET: Company/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CompanyViewModel == null)
            {
                return NotFound();
            }

            var companyViewModel = await _context.CompanyViewModel.FindAsync(id);
            if (companyViewModel == null)
            {
                return NotFound();
            }
            return View(companyViewModel);
        }

        // POST: Company/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyName,transportName,Address,City,State,Country,PhoneNo,Mobile,EmailId,ZipCode,GstNo")] CompanyViewModel companyViewModel)
        {
            if (id != companyViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyViewModelExists(companyViewModel.Id))
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
            return View(companyViewModel);
        }

        // GET: Company/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CompanyViewModel == null)
            {
                return NotFound();
            }

            var companyViewModel = await _context.CompanyViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyViewModel == null)
            {
                return NotFound();
            }

            return View(companyViewModel);
        }

        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CompanyViewModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CompanyViewModel'  is null.");
            }
            var companyViewModel = await _context.CompanyViewModel.FindAsync(id);
            if (companyViewModel != null)
            {
                _context.CompanyViewModel.Remove(companyViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyViewModelExists(int id)
        {
          return (_context.CompanyViewModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
