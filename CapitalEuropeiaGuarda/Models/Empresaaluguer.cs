using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitalEuropeiaGuarda.Models
{
    public class Empresaaluguer

    {
        
        public int empresaaluguerId { get; set; }

        public string NomeEmpresa { get; set; }

        public string Descricao { get; set; }

        public string Url { get; set; }

        public string Morada { get; set; }

        public byte[] Photo { get; set; }

        public ICollection<Veiculo> Veiculo { get; set; } 


    }
}
