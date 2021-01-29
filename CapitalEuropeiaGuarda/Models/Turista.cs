using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapitalEuropeiaGuarda.Models
{
    public class Turista
    {
        public int TuristaId { get; set; }

        [Required(ErrorMessage = "Introduza o nome")]
        public string Nome { get; set; }

        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Introduza um email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Introduza o NIF")]
        public int Nif { get; set; }

        [Required(ErrorMessage = "Introduza o numero de telemovel")]
        public string Telemovel { get; set; }

        public ICollection<ReservaExcursao> reservaexcursoes { get; set; }
    }
}
