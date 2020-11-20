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
    public class aluguercarrosController : Controller
    {
        private readonly CapitalEuropeiaGuardaContext _context;

        public aluguercarrosController(CapitalEuropeiaGuardaContext context)
        {
            _context = context;
        }

        // GET: aluguercarros
        public async Task<IActionResult> Index()
        {
            return View(await _context.aluguercarros.ToListAsync());
        }

        // GET: aluguercarros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluguercarros = await _context.aluguercarros
                .FirstOrDefaultAsync(m => m.aluguercarrosId == id);
            if (aluguercarros == null)
            {
                return NotFound();
            }

            return View(aluguercarros);
        }

        // GET: aluguercarros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: aluguercarros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("aluguercarrosId,Marca,Modelo,Lugares,LinkReserva")] aluguercarros aluguercarros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluguercarros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aluguercarros);
        }

        // GET: aluguercarros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluguercarros = await _context.aluguercarros.FindAsync(id);
            if (aluguercarros == null)
            {
                return NotFound();
            }
            return View(aluguercarros);
        }

        // POST: aluguercarros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("aluguercarrosId,Marca,Modelo,Lugares,LinkReserva")] aluguercarros aluguercarros)
        {
            if (id != aluguercarros.aluguercarrosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluguercarros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!aluguercarrosExists(aluguercarros.aluguercarrosId))
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
            return View(aluguercarros);
        }

        // GET: aluguercarros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluguercarros = await _context.aluguercarros
                .FirstOrDefaultAsync(m => m.aluguercarrosId == id);
            if (aluguercarros == null)
            {
                return NotFound();
            }

            return View(aluguercarros);
        }

        // POST: aluguercarros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluguercarros = await _context.aluguercarros.FindAsync(id);
            _context.aluguercarros.Remove(aluguercarros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool aluguercarrosExists(int id)
        {
            return _context.aluguercarros.Any(e => e.aluguercarrosId == id);
        }
    }
}
