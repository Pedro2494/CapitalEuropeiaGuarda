using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapitalEuropeiaGuarda.Models
{
    public class ReservaExcursao
    {
        public int ReservaExcursaoId { get; set; }

        // chave estrangeira IdTurista
        //public int TuristaId { get; set; }
        public Turista Turista { get; set; }

        
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public string DataReserva { get; set; }

        //falta a chave estrangeira IdExcursaoPontoInteresse

        [Required(ErrorMessage = "Introduza o numero de pessoas")]
        public int NumPessoas { get; set; }

        public bool Cancelado { get; set; }

        
       
        public DateTime? DataCancelar { get; set; }
    }
}
