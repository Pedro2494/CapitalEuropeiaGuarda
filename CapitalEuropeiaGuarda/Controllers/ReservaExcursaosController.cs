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
    public class ReservaExcursaosController : Controller
    {
        private readonly CapitalEuropeiaGuardaContext _context;

        public ReservaExcursaosController(CapitalEuropeiaGuardaContext context)
        {
            _context = context;
        }

        // GET: ReservaExcursaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReservaExcursao.ToListAsync());
        }

        // GET: ReservaExcursaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaExcursao = await _context.ReservaExcursao
                .FirstOrDefaultAsync(m => m.ReservaExcursaoId == id);
            if (reservaExcursao == null)
            {
                return NotFound();
            }

            return View(reservaExcursao);
        }

        // GET: ReservaExcursaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReservaExcursaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservaExcursaoId,DataReserva,NumPessoas,Cancelado,DataCancelar")] ReservaExcursao reservaExcursao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservaExcursao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservaExcursao);
        }

        // GET: ReservaExcursaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaExcursao = await _context.ReservaExcursao.FindAsync(id);
            if (reservaExcursao == null)
            {
                return NotFound();
            }
            return View(reservaExcursao);
        }

        // POST: ReservaExcursaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservaExcursaoId,DataReserva,NumPessoas,Cancelado,DataCancelar")] ReservaExcursao reservaExcursao)
        {
            if (id != reservaExcursao.ReservaExcursaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservaExcursao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExcursaoExists(reservaExcursao.ReservaExcursaoId))
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
            return View(reservaExcursao);
        }

        // GET: ReservaExcursaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaExcursao = await _context.ReservaExcursao
                .FirstOrDefaultAsync(m => m.ReservaExcursaoId == id);
            if (reservaExcursao == null)
            {
                return NotFound();
            }

            return View(reservaExcursao);
        }

        // POST: ReservaExcursaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservaExcursao = await _context.ReservaExcursao.FindAsync(id);
            _context.ReservaExcursao.Remove(reservaExcursao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExcursaoExists(int id)
        {
            return _context.ReservaExcursao.Any(e => e.ReservaExcursaoId == id);
        }
    }
}
