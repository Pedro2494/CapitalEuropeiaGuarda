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
    public class VerPontosController : Controller


    {
        private readonly CapitalEuropeiaGuardaContext _context;

        public VerPontosController(CapitalEuropeiaGuardaContext context)
        {
            _context = context;
        }

        // GET: VerPontosController
        public ActionResult Index()
        {
            var dadosPontos = (from b in _context.PontoInteresse
                               select new PontoInteresse
                               {
                                   Nome = b.Nome,
                                   DescricaoCurta = b.DescricaoCurta,
                                   Local = b.Local,
                                   Photo = b.Photo

                               }).ToList();
            ViewBag.dadosPontos = dadosPontos;

            return View("ViewPontos");
        }

        // GET: ViewPontosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ViewPontosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ViewPontosController/Create
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

        // GET: ViewPontosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ViewPontosController/Edit/5
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

        // GET: ViewPontosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ViewPontosController/Delete/5
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