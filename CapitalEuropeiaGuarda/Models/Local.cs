using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapitalEuropeiaGuarda.Models
{
    public class Local
    {
        public int localID { get; set; }

        [Required(ErrorMessage = "Insira o nome do Local")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira o concelho")]
        public string Concelho { get; set; }

        [Required(ErrorMessage = "Insira as coordenadas")]
        public string Coordenadas { get; set; }

       
    }
}
