using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CapitalEuropeiaGuarda.Models;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace CapitalEuropeiaGuarda.Controllers
{
    public class HomeController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        List<PontoInteresse> pontosinteresse = new List<PontoInteresse>();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            con.ConnectionString = CapitalEuropeiaGuarda.Properties.Resources.ConnectionString;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        
        public IActionResult Manteigas()
        {
            return View();
        }

        public IActionResult ViewPontos()
        {
            FetchData();
            return View(pontosinteresse);
        }

        private void FetchData()
        {
            if(pontosinteresse.Count > 0)
            {
                pontosinteresse.Clear();
            }

            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (1000) [PontoInteresseId],[Nome],[Local],[DescricaoCurta]FROM[CapitalEuropeiaGuardaContext - 72c4669e - 817d - 4406 - 991a - a042364a82b4].[dbo].[PontoInteresse]";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    pontosinteresse.Add(new PontoInteresse() { 
                        Nome = dr ["Nome"].ToString()
                        ,Local = dr ["Local"].ToString()
                        ,DescricaoCurta = dr["DescricaoCurta"].ToString()
                    });
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Register()
        {
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
