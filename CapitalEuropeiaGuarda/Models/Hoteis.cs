using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapitalEuropeiaGuarda.Models
{
    public class Hoteis
    {
        public int HoteisId { get; set; }

        [Required(ErrorMessage = "Introduza um nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Introduza uma descrição")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "Introduza um URL")]
        public string HotelUrl { get; set; }

        [Required(ErrorMessage = "Introduza um local")]
        public string Local { get; set; }

        public ICollection<PontoInteressePorHotel> PontoInteressePorHoteis { get; set; }

        

    }
}
