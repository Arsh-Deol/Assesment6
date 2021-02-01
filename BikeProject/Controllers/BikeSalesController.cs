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
    public class BikeSalesController : Controller
    {
        private readonly BikeProjectContext _context;

        public BikeSalesController(BikeProjectContext context)
        {
            _context = context;
        }

        // GET: BikeSales
        public async Task<IActionResult> Index()
        {
            var bikeProjectContext = _context.BikeSale.Include(b => b.Banch).Include(b => b.Purchaser);
            return View(await bikeProjectContext.ToListAsync());
        }

        // GET: BikeSales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bikeSale = await _context.BikeSale
                .Include(b => b.Banch)
                .Include(b => b.Purchaser)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bikeSale == null)
            {
                return NotFound();
            }

            return View(bikeSale);
        }
        [Authorize]
        // GET: BikeSales/Create
        public IActionResult Create()
        {
            ViewData["BanchID"] = new SelectList(_context.Banch, "BranchID", "BranchName");
            ViewData["PurchaserID"] = new SelectList(_context.Purchaser, "PurchaserID", "FirstName");
            return View();
        }

        // POST: BikeSales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PurchaserID,BanchID")] BikeSale bikeSale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bikeSale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BanchID"] = new SelectList(_context.Banch, "BranchID", "BranchID", bikeSale.BanchID);
            ViewData["PurchaserID"] = new SelectList(_context.Purchaser, "PurchaserID", "PurchaserID", bikeSale.PurchaserID);
            return View(bikeSale);
        }

        // GET: BikeSales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bikeSale = await _context.BikeSale.FindAsync(id);
            if (bikeSale == null)
            {
                return NotFound();
            }
            ViewData["BanchID"] = new SelectList(_context.Banch, "BranchID", "BranchID", bikeSale.BanchID);
            ViewData["PurchaserID"] = new SelectList(_context.Purchaser, "PurchaserID", "PurchaserID", bikeSale.PurchaserID);
            return View(bikeSale);
        }

        // POST: BikeSales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PurchaserID,BanchID")] BikeSale bikeSale)
        {
            if (id != bikeSale.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bikeSale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BikeSaleExists(bikeSale.ID))
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
            ViewData["BanchID"] = new SelectList(_context.Banch, "BranchID", "BranchName", bikeSale.BanchID);
            ViewData["PurchaserID"] = new SelectList(_context.Purchaser, "PurchaserID", "FirstName", bikeSale.PurchaserID);
            return View(bikeSale);
        }
        [Authorize]
        // GET: BikeSales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bikeSale = await _context.BikeSale
                .Include(b => b.Banch)
                .Include(b => b.Purchaser)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bikeSale == null)
            {
                return NotFound();
            }

            return View(bikeSale);
        }

        // POST: BikeSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bikeSale = await _context.BikeSale.FindAsync(id);
            _context.BikeSale.Remove(bikeSale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BikeSaleExists(int id)
        {
            return _context.BikeSale.Any(e => e.ID == id);
        }
    }
}
