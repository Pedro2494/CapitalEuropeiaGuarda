using System;
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

        public DbSet<CapitalEuropeiaGuarda.Models.aluguercarros> aluguercarros { get; set; }
    }
}
