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
    public class HoteisController : Controller
    {
        private readonly CapitalEuropeiaGuardaContext _context;

        public HoteisController(CapitalEuropeiaGuardaContext context)
        {
            _context = context;
        }

        //// GET: Hoteis
        //public async Task<IActionResult> Index()
        //{

        //     return View(await _context.Hoteis.ToListAsync());
        //}

        // GET: Hoteis
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(string sortOrder,
        string currentFilter,
        string searchString,
        int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;

            ViewData["NomeSortParm"] = String.IsNullOrEmpty(sortOrder) ? "nome_desc" : "";
            ViewData["DescricaoCurtaSortParm"] = String.IsNullOrEmpty(sortOrder) ? "descricaocurta_desc" : "";
            ViewData["HotelUrlSortParm"] = String.IsNullOrEmpty(sortOrder) ? "hotelurl_desc" : "";
            ViewData["LocalSortParm"] = String.IsNullOrEmpty(sortOrder) ? "local_desc" : "";

            ViewData["CurrentFilter"] = searchString;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var hoteis = from s in _context.Hoteis
                         select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                hoteis = hoteis.Where(s => s.Nome.Contains(searchString)
                                || s.DescricaoCurta.Contains(searchString));
            }

                switch (sortOrder)
            {
                case "nome_desc":
                    hoteis = hoteis.OrderByDescending(s => s.Nome);
                    break;
                case "descricaocurta_desc":
                    hoteis = hoteis.OrderByDescending(s => s.DescricaoCurta);
                    break;
                case "hotelurl_desc":
                    hoteis = hoteis.OrderByDescending(s => s.HotelUrl);
                    break;
                case "local_desc":
                    hoteis = hoteis.OrderByDescending(s => s.Local);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<Hoteis>.CreateAsync(hoteis.AsNoTracking(), pageNumber ?? 1, pageSize));

            //return View(hoteis.ToList());
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
                // todo: Maybe someone delete it. Show appropriate message
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
        public async Task<IActionResult> Create([Bind("HoteisId,Nome,DescricaoCurta,HotelUrl,Local")] Hoteis hoteis, IFormFile photoFile)
        {
            if (ModelState.IsValid)
            {
                if (photoFile != null && photoFile.Length > 0)
                {
                    using (var memFile = new MemoryStream())
                    {
                        photoFile.CopyTo(memFile);
                        hoteis.Photo = memFile.ToArray();
                    }
                }

                // todo: additional validations

                _context.Add(hoteis);
                await _context.SaveChangesAsync();


                ViewBag.title = "Hotel adicionado com sucesso";
                ViewBag.type = "alert-sucess";
                ViewBag.redirect = "/hoteis/Index"; //vai para pagInicial

                // todo: inform the user that the author was successfully created              
               return View("Confirmacao");
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

                ViewBag.title = "Este hotel já foi eliminado";
                ViewBag.type = "alert-sucess";
                ViewBag.redirect = "/hoteis/Index";
                // todo: Maybe someone delete it. Show appropriate message
                return View("infoEliminado");
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
                ViewBag.title = "Hotel editado com sucesso";
                ViewBag.type = "alert-sucess";
                ViewBag.redirect = "/hoteis/Index"; //vai para pagInicial
                // todo: inform the user that the author was successfully edited
                return View("editado");
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

                ViewBag.title = "Este hotel já foi eliminado";
                ViewBag.type = "alert-sucess";
                ViewBag.redirect = "/hoteis/Index";
                // todo: Maybe someone delete it. Inform the user.
                return View("infoEliminado");
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


            ViewBag.title = "Hotel eliminado com sucesso";
            ViewBag.type = "alert-sucess";
            ViewBag.redirect = "/hoteis/Index"; //vai para pagInicial
            // todo: inform the user that the author was successfully deleted
            return View("eliminado");
        }

        private bool HoteisExists(int id)
        {
            return _context.Hoteis.Any(e => e.HoteisId == id);
        }

    }
}
