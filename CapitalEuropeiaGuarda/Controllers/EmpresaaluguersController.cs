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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;


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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["NomeEmpresaSortParm"] = String.IsNullOrEmpty(sortOrder) ? "nomeempresa_desc" : "";
            ViewData["DescricaoSortParm"] = String.IsNullOrEmpty(sortOrder) ? "descricao_desc" : "";
            ViewData["UrlSortParm"] = String.IsNullOrEmpty(sortOrder) ? "url_desc" : "";
            ViewData["MoradaSortParm"] = String.IsNullOrEmpty(sortOrder) ? "morada_desc" : "";
            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;

            var empresaaluguer = from s in _context.Empresaaluguer
                                 select s;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

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
            int pageSize = 3;
            return View(await PaginatedList<Empresaaluguer>.CreateAsync(empresaaluguer.AsNoTracking(), pageNumber ?? 1, pageSize));
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
        public async Task<IActionResult> Create([Bind("empresaaluguerId,NomeEmpresa,Descricao,Url,Morada,Photo")] Empresaaluguer empresaaluguer, IFormFile photoFile)
        
        {
            if (ModelState.IsValid)
            {
                if (photoFile != null && photoFile.Length > 0)
                {
                    using (var memFile = new MemoryStream())
                    {
                        photoFile.CopyTo(memFile);
                        empresaaluguer.Photo = memFile.ToArray();
                    }
                }
                
                _context.Add(empresaaluguer);
                await _context.SaveChangesAsync();
                ViewBag.title = "Empresa adicionada com sucesso";
                ViewBag.type = "alert-sucess";
                ViewBag.redirect = "/empresaaluguers/Index"; //vai para pagInicial

                // todo: inform the user that the author was successfully created              
                return View("ConfirmaCriar");
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
                ViewBag.message = "Empresa de aluguer alterada com sucesso!";
                ViewBag.type = "alert-sucess";
                // Volta para a página de Aluguer de Empresa
                ViewBag.redirect = "/empresaaluguers/Index";
                // todo: inform the user that the author was successfully edited
                return View("ConfirmaEditar");
                
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

            ViewBag.message = "Empresa de aluguer eliminado!";
            ViewBag.type = "alert-sucess";
            ViewBag.redirect = "/empresaaluguers/Index"; //vai para pagInicial
            // todo: inform the user that the author was successfully deleted
            return View("ConfirmaEliminar");
        }

        private bool EmpresaaluguerExists(int id)
        {
            return _context.Empresaaluguer.Any(e => e.empresaaluguerId == id);
        }
    }

    
}
