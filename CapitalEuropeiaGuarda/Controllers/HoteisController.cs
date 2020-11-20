using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapitalEuropeiaGuarda.Data;
using CapitalEuropeiaGuarda.Models;

namespace CapitalEuropeiaGuarda.Controllers
{
    public class HoteisController : Controller
    {
        private readonly CapitalEuropeiaGuardaContext _context;

        public HoteisController(CapitalEuropeiaGuardaContext context)
        {
            _context = context;
        }

        // GET: Hoteis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hoteis.ToListAsync());
        }

        // GET: Hoteis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoteis = await _context.Hoteis
                .FirstOrDefaultAsync(m => m.HoteisId == id);
            if (hoteis == null)
            {
                return NotFound();
            }

            return View(hoteis);
        }

        // GET: Hoteis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hoteis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HoteisId,Nome,DescricaoCurta,HotelUrl,Local")] Hoteis hoteis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoteis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hoteis);
        }

        // GET: Hoteis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoteis = await _context.Hoteis.FindAsync(id);
            if (hoteis == null)
            {
                return NotFound();
            }
            return View(hoteis);
        }

        // POST: Hoteis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HoteisId,Nome,DescricaoCurta,HotelUrl,Local")] Hoteis hoteis)
        {
            if (id != hoteis.HoteisId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoteis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoteisExists(hoteis.HoteisId))
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
            return View(hoteis);
        }

        // GET: Hoteis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoteis = await _context.Hoteis
                .FirstOrDefaultAsync(m => m.HoteisId == id);
            if (hoteis == null)
            {
                return NotFound();
            }

            return View(hoteis);
        }

        // POST: Hoteis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hoteis = await _context.Hoteis.FindAsync(id);
            _context.Hoteis.Remove(hoteis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoteisExists(int id)
        {
            return _context.Hoteis.Any(e => e.HoteisId == id);
        }
    }
}
