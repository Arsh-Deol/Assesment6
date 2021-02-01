using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BikeProject.Data;
using BikeProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace BikeProject.Controllers
{
    public class SaleMenController : Controller
    {
        private readonly BikeProjectContext _context;

        public SaleMenController(BikeProjectContext context)
        {
            _context = context;
        }

        // GET: SaleMen
        public async Task<IActionResult> Index()
        {
            return View(await _context.SaleMan.ToListAsync());
        }

        // GET: SaleMen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleMan = await _context.SaleMan
                .FirstOrDefaultAsync(m => m.SaleManId == id);
            if (saleMan == null)
            {
                return NotFound();
            }

            return View(saleMan);
        }
        [Authorize]
        // GET: SaleMen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SaleMen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaleManId,SaleManName,BikeAmount,SaleDate")] SaleMan saleMan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleMan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(saleMan);
        }

        // GET: SaleMen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleMan = await _context.SaleMan.FindAsync(id);
            if (saleMan == null)
            {
                return NotFound();
            }
            return View(saleMan);
        }

        // POST: SaleMen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaleManId,SaleManName,BikeAmount,SaleDate")] SaleMan saleMan)
        {
            if (id != saleMan.SaleManId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleMan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleManExists(saleMan.SaleManId))
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
            return View(saleMan);
        }

        // GET: SaleMen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleMan = await _context.SaleMan
                .FirstOrDefaultAsync(m => m.SaleManId == id);
            if (saleMan == null)
            {
                return NotFound();
            }

            return View(saleMan);
        }
        [Authorize]
        // POST: SaleMen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleMan = await _context.SaleMan.FindAsync(id);
            _context.SaleMan.Remove(saleMan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleManExists(int id)
        {
            return _context.SaleMan.Any(e => e.SaleManId == id);
        }
    }
}
