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
    public class PontoInteressesController : Controller
    {
        private readonly CapitalEuropeiaGuardaContext _context;

        public PontoInteressesController(CapitalEuropeiaGuardaContext context)
        {
            _context = context;
        }

        // GET: PontoInteresses
        public async Task<IActionResult> Index()
        {
            return View(await _context.PontoInteresse.ToListAsync());

        }

        // GET: PontoInteresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontoInteresse = await _context.PontoInteresse
                .FirstOrDefaultAsync(m => m.PontoInteresseId == id);
            if (pontoInteresse == null)
            {
                return NotFound();
            }

            return View(pontoInteresse);
        }

        // GET: PontoInteresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PontoInteresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PontoInteresseId,Nome,Local,DescricaoCurta")] PontoInteresse pontoInteresse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pontoInteresse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pontoInteresse);
        }

        // GET: PontoInteresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontoInteresse = await _context.PontoInteresse.FindAsync(id);
            if (pontoInteresse == null)
            {
                return NotFound();
            }
            return View(pontoInteresse);
        }

        // POST: PontoInteresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PontoInteresseId,Nome,Local,DescricaoCurta")] PontoInteresse pontoInteresse)
        {
            if (id != pontoInteresse.PontoInteresseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pontoInteresse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PontoInteresseExists(pontoInteresse.PontoInteresseId))
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
            return View(pontoInteresse);
        }

        // GET: PontoInteresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontoInteresse = await _context.PontoInteresse
                .FirstOrDefaultAsync(m => m.PontoInteresseId == id);
            if (pontoInteresse == null)
            {
                return NotFound();
            }

            return View(pontoInteresse);
        }

        // POST: PontoInteresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pontoInteresse = await _context.PontoInteresse.FindAsync(id);
            _context.PontoInteresse.Remove(pontoInteresse);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Added Successfully!";
            return RedirectToAction(nameof(Index));
        }

        private bool PontoInteresseExists(int id)
        {
            return _context.PontoInteresse.Any(e => e.PontoInteresseId == id);
        }
    }
}
