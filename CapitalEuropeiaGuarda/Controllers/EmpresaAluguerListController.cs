using CapitalEuropeiaGuarda.Data;
using CapitalEuropeiaGuarda.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitalEuropeiaGuarda.Controllers
{
    public class EmpresaAluguerListController : Controller
    {
        private readonly CapitalEuropeiaGuardaContext _context;

        public EmpresaAluguerListController(CapitalEuropeiaGuardaContext context)
        {
            _context = context;
        }
        
        // GET: EmpresaAluguerListController
        public ActionResult Index()
        {
            var dadosEmpresa = (from b in _context.Empresaaluguer
                               select new Empresaaluguer
                               {
                                   NomeEmpresa = b.NomeEmpresa,
                                   Descricao = b.Descricao,
                                   Url = b.Url,
                                   Morada = b.Morada,
                                   Photo = b.Photo


                               }).ToList();
            ViewBag.dadosEmpresa = dadosEmpresa;
            return View("ViewEmpresa");
        }

        // GET: EmpresaAluguerListController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmpresaAluguerListController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpresaAluguerListController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpresaAluguerListController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmpresaAluguerListController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpresaAluguerListController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmpresaAluguerListController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
