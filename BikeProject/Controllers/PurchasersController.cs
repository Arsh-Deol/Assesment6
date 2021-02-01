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
    public class PurchasersController : Controller
    {
        private readonly BikeProjectContext _context;

        public PurchasersController(BikeProjectContext context)
        {
            _context = context;
        }

        // GET: Purchasers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Purchaser.ToListAsync());
        }

        // GET: Purchasers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaser = await _context.Purchaser
                .FirstOrDefaultAsync(m => m.PurchaserID == id);
            if (purchaser == null)
            {
                return NotFound();
            }

            return View(purchaser);
        }

        // GET: Purchasers/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: Purchasers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchaserID,FirstName,LastName,Address,Phone,DOB")] Purchaser purchaser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(purchaser);
        }

        // GET: Purchasers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaser = await _context.Purchaser.FindAsync(id);
            if (purchaser == null)
            {
                return NotFound();
            }
            return View(purchaser);
        }

        // POST: Purchasers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchaserID,FirstName,LastName,Address,Phone,DOB")] Purchaser purchaser)
        {
            if (id != purchaser.PurchaserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaserExists(purchaser.PurchaserID))
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
            return View(purchaser);
        }

        // GET: Purchasers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaser = await _context.Purchaser
                .FirstOrDefaultAsync(m => m.PurchaserID == id);
            if (purchaser == null)
            {
                return NotFound();
            }

            return View(purchaser);
        }
        [Authorize]
        // POST: Purchasers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaser = await _context.Purchaser.FindAsync(id);
            _context.Purchaser.Remove(purchaser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaserExists(int id)
        {
            return _context.Purchaser.Any(e => e.PurchaserID == id);
        }
    }
}
