using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapitalEuropeiaGuarda.Models
{
    public class Veiculo
    {
        public int VeiculoId { get; set; }

        [Required(ErrorMessage = "Introduza o modelo")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Introduza a marca")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Introduza o numero maximo de lugares")]
        public int Max_lugares { get; set; }

        [Required(ErrorMessage = "Introduza o numero minimo de lugares")]
        public int Min_lugares { get; set; }


    }
}
