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
    public class EmpresaaluguersController : Controller
    {
        private readonly CapitalEuropeiaGuardaContext _context;

        public EmpresaaluguersController(CapitalEuropeiaGuardaContext context)
        {
            _context = context;
        }

        // GET: Empresaaluguers
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NomeEmpresaSortParm"] = String.IsNullOrEmpty(sortOrder) ? "nomeempresa_desc" : "";
            ViewData["DescricaoSortParm"] = String.IsNullOrEmpty(sortOrder) ? "descricao_desc" : "";
            ViewData["UrlSortParm"] = String.IsNullOrEmpty(sortOrder) ? "url_desc" : "";
            ViewData["MoradaSortParm"] = String.IsNullOrEmpty(sortOrder) ? "morada_desc" : "";
            ViewData["CurrentFilter"] = searchString;


            var empresaaluguer = from s in _context.Empresaaluguer
                                 select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                empresaaluguer = empresaaluguer.Where(s => s.NomeEmpresa.Contains(searchString) || s.Descricao.Contains(searchString)
                                                        || s.Url.Contains(searchString) || s.Morada.Contains(searchString));
            }
            switch(sortOrder)
            {
                case "nomeempresa_desc":
                    empresaaluguer = empresaaluguer.OrderByDescending(s => s.NomeEmpresa);
                    break;
                case "descricao_desc":
                    empresaaluguer = empresaaluguer.OrderByDescending(s => s.Descricao);
                    break;
                case "url_desc":
                    empresaaluguer = empresaaluguer.OrderByDescending(s => s.Url);
                    break;
                case "morada_desc":
                    empresaaluguer = empresaaluguer.OrderByDescending(s => s.Morada);
                    break;
            }
            return View(await empresaaluguer.AsNoTracking().ToListAsync());
        }

        // GET: Empresaaluguers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresaaluguer = await _context.Empresaaluguer
                .FirstOrDefaultAsync(m => m.empresaaluguerId == id);
            if (empresaaluguer == null)
            {
                return NotFound();
            }

            return View(empresaaluguer);
        }

        // GET: Empresaaluguers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empresaaluguers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("empresaaluguerId,NomeEmpresa,Descricao,Url,Morada")] Empresaaluguer empresaaluguer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empresaaluguer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empresaaluguer);
        }

        // GET: Empresaaluguers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresaaluguer = await _context.Empresaaluguer.FindAsync(id);
            if (empresaaluguer == null)
            {
                return NotFound();
            }
            return View(empresaaluguer);
        }

        // POST: Empresaaluguers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("empresaaluguerId,NomeEmpresa,Descricao,Url,Morada")] Empresaaluguer empresaaluguer)
        {
            if (id != empresaaluguer.empresaaluguerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresaaluguer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaaluguerExists(empresaaluguer.empresaaluguerId))
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
            return View(empresaaluguer);
        }

        // GET: Empresaaluguers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresaaluguer = await _context.Empresaaluguer
                .FirstOrDefaultAsync(m => m.empresaaluguerId == id);
            if (empresaaluguer == null)
            {
                return NotFound();
            }

            return View(empresaaluguer);
        }

        // POST: Empresaaluguers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empresaaluguer = await _context.Empresaaluguer.FindAsync(id);
            _context.Empresaaluguer.Remove(empresaaluguer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpresaaluguerExists(int id)
        {
            return _context.Empresaaluguer.Any(e => e.empresaaluguerId == id);
        }
    }

    
}
