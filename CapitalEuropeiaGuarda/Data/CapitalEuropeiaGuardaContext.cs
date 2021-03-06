﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CapitalEuropeiaGuarda.Models;

namespace CapitalEuropeiaGuarda.Data
{
    public class CapitalEuropeiaGuardaContext : DbContext
    {
        public CapitalEuropeiaGuardaContext (DbContextOptions<CapitalEuropeiaGuardaContext> options)
            : base(options)
        {
        }

        
        
        public DbSet<CapitalEuropeiaGuarda.Models.Hoteis> Hoteis { get; set; }

        public DbSet<CapitalEuropeiaGuarda.Models.PontoInteresse> PontoInteresse { get; set; }

        public DbSet<CapitalEuropeiaGuarda.Models.Veiculo> Veiculo { get; set; }

        public DbSet<CapitalEuropeiaGuarda.Models.Empresaaluguer> Empresaaluguer { get; set; }

        public DbSet<CapitalEuropeiaGuarda.Models.ReservaExcursao> ReservaExcursao { get; set; }

        public DbSet<CapitalEuropeiaGuarda.Models.Turista> Turista { get; set; }

        public DbSet<CapitalEuropeiaGuarda.Models.Local> Local { get; set; }


    }
}
