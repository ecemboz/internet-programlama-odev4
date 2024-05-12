using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class TblUrunsController : Controller
    {
        private readonly DbUruntakipContext _context;

        public TblUrunsController(DbUruntakipContext context)
        {
            _context = context;
        }

        // GET: TblUruns
        public async Task<IActionResult> Index()
        {
            var dbUruntakipContext = _context.TblUrun.Include(t => t.TblKategoriler);
            return View(await dbUruntakipContext.ToListAsync());
        }

        // GET: TblUruns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUrun = await _context.TblUrun
                .Include(t => t.TblKategoriler)
                .FirstOrDefaultAsync(m => m.UrunId == id);
            if (tblUrun == null)
            {
                return NotFound();
            }

            return View(tblUrun);
        }

        // GET: TblUruns/Create
        public IActionResult Create()
        {
            ViewData["KategoriId"] = new SelectList(_context.Set<TblKategoriler>(), "KategoriId", "KategoriAd");
            return View();
        }

        // POST: TblUruns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UrunId,KategoriId,UrunAd,UrunFiyat,UrunAdet,UrunPhoto")] TblUrun tblUrun)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblUrun);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriId"] = new SelectList(_context.Set<TblKategoriler>(), "KategoriId", "KategoriId", tblUrun.KategoriId);
            return View(tblUrun);
        }

        // GET: TblUruns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblUrun == null)
            {
                return NotFound();
            }

            var tblUrun = await _context.TblUrun.FindAsync(id);
            if (tblUrun == null)
            {
                return NotFound();
            }
            ViewData["KategoriId"] = new SelectList(_context.Set<TblKategoriler>(), "KategoriId", "KategoriAd", tblUrun.KategoriId);
            return View(tblUrun);
        }

        // POST: TblUruns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UrunId,KategoriId,UrunAd,UrunFiyat,UrunAdet,UrunPhoto")] TblUrun tblUrun)
        {
            if (id != tblUrun.UrunId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblUrun);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblUrunExists(tblUrun.UrunId))
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
            ViewData["KategoriId"] = new SelectList(_context.Set<TblKategoriler>(), "KategoriId", "KategoriId", tblUrun.KategoriId);
            return View(tblUrun);
        }

        // GET: TblUruns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUrun = await _context.TblUrun
                .Include(t => t.TblKategoriler)
                .FirstOrDefaultAsync(m => m.UrunId == id);
            if (tblUrun == null)
            {
                return NotFound();
            }

            return View(tblUrun);
        }

        // POST: TblUruns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblUrun = await _context.TblUrun.FindAsync(id);
            if (tblUrun != null)
            {
                _context.TblUrun.Remove(tblUrun);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblUrunExists(int id)
        {
            return _context.TblUrun.Any(e => e.UrunId == id);
        }
    }
}
