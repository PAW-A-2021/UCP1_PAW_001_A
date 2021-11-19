using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_001_A.Models;

namespace UCP1_PAW_001_A.Controllers
{
    public class JenisMobilsController : Controller
    {
        private readonly UCPRentMoContext _context;

        public JenisMobilsController(UCPRentMoContext context)
        {
            _context = context;
        }

        // GET: JenisMobils
        public async Task<IActionResult> Index()
        {
            return View(await _context.JenisMobils.ToListAsync());
        }

        // GET: JenisMobils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jenisMobil = await _context.JenisMobils
                .FirstOrDefaultAsync(m => m.IdJenisMobil == id);
            if (jenisMobil == null)
            {
                return NotFound();
            }

            return View(jenisMobil);
        }

        // GET: JenisMobils/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JenisMobils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdJenisMobil,NamaJenisMobil")] JenisMobil jenisMobil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jenisMobil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jenisMobil);
        }

        // GET: JenisMobils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jenisMobil = await _context.JenisMobils.FindAsync(id);
            if (jenisMobil == null)
            {
                return NotFound();
            }
            return View(jenisMobil);
        }

        // POST: JenisMobils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdJenisMobil,NamaJenisMobil")] JenisMobil jenisMobil)
        {
            if (id != jenisMobil.IdJenisMobil)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jenisMobil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JenisMobilExists(jenisMobil.IdJenisMobil))
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
            return View(jenisMobil);
        }

        // GET: JenisMobils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jenisMobil = await _context.JenisMobils
                .FirstOrDefaultAsync(m => m.IdJenisMobil == id);
            if (jenisMobil == null)
            {
                return NotFound();
            }

            return View(jenisMobil);
        }

        // POST: JenisMobils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jenisMobil = await _context.JenisMobils.FindAsync(id);
            _context.JenisMobils.Remove(jenisMobil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JenisMobilExists(int id)
        {
            return _context.JenisMobils.Any(e => e.IdJenisMobil == id);
        }
    }
}
