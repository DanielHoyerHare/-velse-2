using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Øvelse_2.Data;
using Øvelse_2.Models;

namespace Øvelse_2.Controllers
{
    public class KagesController : Controller
    {
        private readonly Øvelse_2Context _context;

        public KagesController(Øvelse_2Context context)
        {
            _context = context;
        }

        // GET: Kages
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kage.ToListAsync());
        }

        // GET: Kages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kage = await _context.Kage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kage == null)
            {
                return NotFound();
            }

            return View(kage);
        }

        // GET: Kages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CakeName,BestBefore,Price")] Kage kage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kage);
        }

        // GET: Kages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kage = await _context.Kage.FindAsync(id);
            if (kage == null)
            {
                return NotFound();
            }
            return View(kage);
        }

        // POST: Kages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CakeName,BestBefore,Price")] Kage kage)
        {
            if (id != kage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KageExists(kage.Id))
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
            return View(kage);
        }

        // GET: Kages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kage = await _context.Kage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kage == null)
            {
                return NotFound();
            }

            return View(kage);
        }

        // POST: Kages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kage = await _context.Kage.FindAsync(id);
            _context.Kage.Remove(kage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KageExists(int id)
        {
            return _context.Kage.Any(e => e.Id == id);
        }
    }
}
