using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapitalEuropeiaGuarda.Models
{
    public class Empresaaluguer

    {
        
        public int empresaaluguerId { get; set; }

        [Required(ErrorMessage = "Insira o nome da empresa")]
        public string NomeEmpresa { get; set; }

        [Required(ErrorMessage = "Insira a descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Insira o Url")]
        public string Url { get; set; }

        [Required(ErrorMessage = "Insira a morada")]
        public string Morada { get; set; }

    }
}
