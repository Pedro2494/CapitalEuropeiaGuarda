using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CapitalEuropeiaGuarda.Models
{
    public class aluguercarros
    {
        
        public int aluguercarrosId { get; set; }

        [Required(ErrorMessage = "Por favor, introduza a marca do carro")]
        public String Marca { get; set; }


        public String Modelo { get; set; }

        
        public int Lugares { get; set; }

        
        public String LinkReserva { get; set; }
    }
}
