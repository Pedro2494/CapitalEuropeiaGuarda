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
        public async Task<IActionResult> Index(int page = 1)
        {
            var pagination = new PagingInfo
            {
                CurrentPage = page,
                PageSize = PagingInfo.DEFAULT_PAGE_SIZE,
                TotalItems = _context.aluguercarros.Count()
            };
            return View(new aluguercarrosListViewModel
            {
                aluguercarros = _context.aluguercarros
                .Skip((page -1) * pagination.PageSize),
                Pagination = pagination
            }
            );
            //return View(await _context.aluguercarros.ToListAsync());
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
                // todo: Maybe someone delete it. Show appropriate message
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
                // todo: additional validations
                _context.Add(aluguercarros);
                await _context.SaveChangesAsync();

                ViewBag.title = "Carro adicionado com sucesso";
                ViewBag.type = "alert-sucess";
                ViewBag.redirect = "/aluguercarros/Index"; //vai para pagInicial
                // todo: inform the user that the author was successfully created
                
                return View("Criado");


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
                // todo: Maybe someone delete it. Show appropriate message
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
                        // todo: Maybe someone delete it. 
                        // Inform user and allow to insert new with same data
                        return NotFound();
                    }
                    else
                    {
                        // todo: show error and allow to try again
                        throw;
                    }
                }
                ViewBag.title = "Carro editado com sucesso";
                ViewBag.type = "alert-sucess";
                ViewBag.redirect = "/aluguercarros/Index"; //vai para pagInicial
                // todo: inform the user that the author was successfully edited
                return View("editado");

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
                // todo: Maybe someone delete it. Inform the user.
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
            
            if (aluguercarros != null) {
                _context.aluguercarros.Remove(aluguercarros);
                await _context.SaveChangesAsync();
            }
            ViewBag.title = "Carro eliminado com sucesso";
            ViewBag.type = "alert-sucess";
            ViewBag.redirect = "/aluguercarros/Index";
            // todo: inform the user that the author was successfully deleted
            return View("eliminado");

        }

        private bool aluguercarrosExists(int id)
        {
            return _context.aluguercarros.Any(e => e.aluguercarrosId == id);
        }

        
    }
}
