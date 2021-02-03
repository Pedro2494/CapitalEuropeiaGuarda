using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapitalEuropeiaGuarda.Data;
using CapitalEuropeiaGuarda.Models;
using PagedList;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(string sortOrder,
        string currentFilter,
        string searchString,
        int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;

            ViewData["NomeSortParm"] = String.IsNullOrEmpty(sortOrder) ? "nome_desc" : "";
            ViewData["LocalSortParm"] = String.IsNullOrEmpty(sortOrder) ? "local_desc" : "";
            ViewData["DescricaoCurtaSortParm"] = String.IsNullOrEmpty(sortOrder) ? "descricaocurta_desc" : "";

            ViewData["CurrentFilter"] = searchString;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var pontointeresse = from s in _context.PontoInteresse
                         select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                pontointeresse = pontointeresse.Where(s => s.Nome.Contains(searchString)
                                || s.DescricaoCurta.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "nome_desc":
                    pontointeresse = pontointeresse.OrderByDescending(s => s.Nome);
                    break;
                case "descricaocurta_desc":
                    pontointeresse = pontointeresse.OrderByDescending(s => s.DescricaoCurta);
                    break;
                case "local_desc":
                    pontointeresse = pontointeresse.OrderByDescending(s => s.Local);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<PontoInteresse>.CreateAsync(pontointeresse.AsNoTracking(), pageNumber ?? 1, pageSize));


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
        public async Task<IActionResult> Create([Bind("PontoInteresseId,Nome,Local,DescricaoCurta")] PontoInteresse pontoInteresse, IFormFile photoFile, IFormFile photoFile2)
        {
            if (ModelState.IsValid)
            {
                if (photoFile != null && photoFile.Length > 0)
                {
                    using (var memFile = new MemoryStream())
                    {
                        photoFile.CopyTo(memFile);
                        //photoFile2.CopyTo(memFile);
                        pontoInteresse.Photo = memFile.ToArray();
                        //pontoInteresse.Photo2 = memFile.ToArray();
                    }   
                }

             if (ModelState.IsValid)
                {
                 if (photoFile2 != null && photoFile2.Length > 0)
                 {
                     using (var memFile2 = new MemoryStream())
                     {
                       photoFile2.CopyTo(memFile2);
                       //pontoInteresse.Photo = memFile2.ToArray();
                       pontoInteresse.Photo2 = memFile2.ToArray();

                     }

                 }
             }
                    //else if (photoFile != null && photoFileMap.Length > 0)
                    //{
                    //    using (var memFile = new MemoryStream())
                    //    {
                    //        photoFileMap.CopyTo(memFile);
                    //        pontoInteresse.Photo2 = memFile.ToArray();
                    //    }
                    //}

                    _context.Add(pontoInteresse);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));

                ViewBag.message = "Ponto de Interesse adicionado com sucesso!";
                ViewBag.type = "alert-sucess";
                //Volta para a página de Pontos de Interesse
                ViewBag.redirect = "/pontoInteresses/Index"; 

                // todo: inform the user that the author was successfully created              
                return View("ConfirmaInserir");
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
                ViewBag.message = "Ponto de Interesse alterado com sucesso!";
                ViewBag.type = "alert-sucess";
                // Volta para a página de Pontos de Interesse
                ViewBag.redirect = "/pontoInteresses/Index"; 
                // todo: inform the user that the author was successfully edited
                return View("ConfirmaEditar");
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
            

            ViewBag.message = "Ponto de Interesse eliminado!";
            ViewBag.type = "alert-sucess";
            ViewBag.redirect = "/pontoInteresses/Index"; //vai para pagInicial
            // todo: inform the user that the author was successfully deleted
            return View("ConfirmaEliminar");
        }

        private bool PontoInteresseExists(int id)
        {
            return _context.PontoInteresse.Any(e => e.PontoInteresseId == id);
        }
    }
}
