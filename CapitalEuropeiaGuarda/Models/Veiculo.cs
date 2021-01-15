using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitalEuropeiaGuarda.Models
{
    public class Veiculo
    {
           public int VeiculoId { get; set; }

           
            public string Modelo { get; set; }

            public string Marca { get; set; }

            public int Max_lugares { get; set; }

            public int Min_lugares { get; set; }


    }
}
