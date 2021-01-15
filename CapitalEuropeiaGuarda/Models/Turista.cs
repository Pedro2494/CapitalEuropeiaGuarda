using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitalEuropeiaGuarda.Models
{
    public class Turista
    {
        public int TuristaId { get; set; }

        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public string Email { get; set; }

        public int Nif { get; set; }

        public string Telemovel { get; set; }
    }
}
