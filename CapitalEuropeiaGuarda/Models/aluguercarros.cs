using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitalEuropeiaGuarda.Models
{
    public class aluguercarros
    {
        public int aluguercarrosId { get; set; }


        public String Marca { get; set; }


        public String Modelo { get; set; }

        
        public int Lugares { get; set; }

        
        public String LinkReserva { get; set; }
    }
}
