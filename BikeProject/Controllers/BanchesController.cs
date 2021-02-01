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
    public class BanchesController : Controller
    {
        private readonly BikeProjectContext _context;

        public BanchesController(BikeProjectContext context)
        {
            _context = context;
        }

        // GET: Banches
        public async Task<IActionResult> Index()
        {
            return View(await _context.Banch.ToListAsync());
        }

        // GET: Banches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banch = await _context.Banch
                .FirstOrDefaultAsync(m => m.BranchID == id);
            if (banch == null)
            {
                return NotFound();
            }

            return View(banch);
        }
        [Authorize]
        // GET: Banches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Banches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BranchID,BranchName,Address,OpeningTime,CloseingTime")] Banch banch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(banch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(banch);
        }

        // GET: Banches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banch = await _context.Banch.FindAsync(id);
            if (banch == null)
            {
                return NotFound();
            }
            return View(banch);
        }

        // POST: Banches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BranchID,BranchName,Address,OpeningTime,CloseingTime")] Banch banch)
        {
            if (id != banch.BranchID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(banch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BanchExists(banch.BranchID))
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
            return View(banch);
        }
        [Authorize]
        // GET: Banches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banch = await _context.Banch
                .FirstOrDefaultAsync(m => m.BranchID == id);
            if (banch == null)
            {
                return NotFound();
            }

            return View(banch);
        }

        // POST: Banches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var banch = await _context.Banch.FindAsync(id);
            _context.Banch.Remove(banch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BanchExists(int id)
        {
            return _context.Banch.Any(e => e.BranchID == id);
        }
    }
}
