using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitalEuropeiaGuarda.Models
{
    public class ReservaExcursao
    {
        public int ReservaExcursaoId { get; set; }

        //falta a chave estrangeira IdTurista

        //verificar o tipo de dados da data
        public string DataReserva { get; set; }

        //falta a chave estrangeira IdExcursaoPontoInteresse

        public int NumPessoas { get; set; }

        public bool Cancelado { get; set; }

        //verificar o tipo de dados da data
        public string DataCancelar { get; set; }
    }
}
