using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapitalEuropeiaGuarda.Data;
using CapitalEuropeiaGuarda.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

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
        [Authorize(Roles = "User")]
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

                ViewBag.title = "Excursão reservada com sucesso";
                ViewBag.type = "alert-sucess";
                ViewBag.redirect = "/reservaExcursaos/Index"; //vai para pagInicial

                return View("Confirmacao");
              
                // todo: inform the user that the author was successfully created 
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

                ViewBag.title = "Esta excursão já foi eliminada";
                ViewBag.type = "alert-sucess";
                ViewBag.redirect = "/reservaExcursaos/Index";

                return View("InfoEliminado");
                // todo: Maybe someone delete it. Show appropriate message
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

                ViewBag.title = "Excursão editada com sucesso";
                ViewBag.type = "alert-sucess";
                ViewBag.redirect = "/reservaExcursaos/Index"; //vai para pagInicial
                // todo: inform the user that the author was successfully edited
                return View("Editado");
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
                ViewBag.title = "Excursão eliminada com sucesso";
                ViewBag.type = "alert-sucess";
                ViewBag.redirect = "/reservaExcursaos/Index"; //vai para pagInicial
                // todo: inform the user that the author was successfully deleted
                return View("Eliminado");
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

            ViewBag.title = "Excursão eliminada com sucesso";
            ViewBag.type = "alert-sucess";
            ViewBag.redirect = "/reservaExcursaos/Index"; //vai para pagInicial
            // todo: inform the user that the author was successfully deleted
            return View("Eliminado");

            // todo: inform the user that the author was successfully deleted
        }

        private bool ReservaExcursaoExists(int id)
        {
            return _context.ReservaExcursao.Any(e => e.ReservaExcursaoId == id);
        }
    }
}
