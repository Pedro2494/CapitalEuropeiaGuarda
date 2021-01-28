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
    public class HoteisListController : Controller


    {

        private readonly CapitalEuropeiaGuardaContext _context;

        public HoteisListController(CapitalEuropeiaGuardaContext context)
        {
            _context = context;
        }

        // GET: HoteisListController
        public ActionResult Index()
        {
            //aqui
            var dadosHoteis = (from b in _context.Hoteis
                               select new Hoteis
                               {
                                   Nome = b.Nome,
                                   DescricaoCurta = b.DescricaoCurta,
                                   HotelUrl = b.HotelUrl,
                                   Local = b.Local,
                                   Photo = b.Photo

                               }).ToList();
            ViewBag.dadosHoteis = dadosHoteis;
            //acaba aqui

            return View("HoteisList");
        }

        // GET: HoteisListController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HoteisListController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HoteisListController/Create
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

        // GET: HoteisListController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HoteisListController/Edit/5
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

        // GET: HoteisListController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HoteisListController/Delete/5
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
