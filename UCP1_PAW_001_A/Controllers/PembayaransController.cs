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
    public class PembayaransController : Controller
    {
        private readonly UCPRentMoContext _context;

        public PembayaransController(UCPRentMoContext context)
        {
            _context = context;
        }

        // GET: Pembayarans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pembayarans.ToListAsync());
        }

        // GET: Pembayarans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembayaran = await _context.Pembayarans
                .FirstOrDefaultAsync(m => m.IdPembayaran == id);
            if (pembayaran == null)
            {
                return NotFound();
            }

            return View(pembayaran);
        }

        // GET: Pembayarans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pembayarans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPembayaran,TanggalPembayaran,JenisPembayaran,TotalPembayaran")] Pembayaran pembayaran)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pembayaran);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pembayaran);
        }

        // GET: Pembayarans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembayaran = await _context.Pembayarans.FindAsync(id);
            if (pembayaran == null)
            {
                return NotFound();
            }
            return View(pembayaran);
        }

        // POST: Pembayarans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPembayaran,TanggalPembayaran,JenisPembayaran,TotalPembayaran")] Pembayaran pembayaran)
        {
            if (id != pembayaran.IdPembayaran)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pembayaran);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PembayaranExists(pembayaran.IdPembayaran))
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
            return View(pembayaran);
        }

        // GET: Pembayarans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembayaran = await _context.Pembayarans
                .FirstOrDefaultAsync(m => m.IdPembayaran == id);
            if (pembayaran == null)
            {
                return NotFound();
            }

            return View(pembayaran);
        }

        // POST: Pembayarans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pembayaran = await _context.Pembayarans.FindAsync(id);
            _context.Pembayarans.Remove(pembayaran);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PembayaranExists(int id)
        {
            return _context.Pembayarans.Any(e => e.IdPembayaran == id);
        }
    }
}
