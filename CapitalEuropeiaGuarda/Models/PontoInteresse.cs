using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapitalEuropeiaGuarda.Models
{
    public class PontoInteresse
    {
        public int PontoInteresseId { get; set; }

        [Required(ErrorMessage = "Insira o nome do Ponto de Interesse")]
        [StringLength(50, MinimumLength = 3)]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Insira o Local")]
        public String Local { get; set; }

        [Required(ErrorMessage = "Insira uma Descrição")]
        public String DescricaoCurta { get; set; }




    }
}
