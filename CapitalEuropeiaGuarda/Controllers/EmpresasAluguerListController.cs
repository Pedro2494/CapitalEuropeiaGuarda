using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitalEuropeiaGuarda.Controllers
{
    public class EmpresasAluguerListController : Controller
    {
        // GET: EmpresasAluguerListController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmpresasAluguerListController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmpresasAluguerListController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpresasAluguerListController/Create
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

        // GET: EmpresasAluguerListController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmpresasAluguerListController/Edit/5
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

        // GET: EmpresasAluguerListController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmpresasAluguerListController/Delete/5
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
