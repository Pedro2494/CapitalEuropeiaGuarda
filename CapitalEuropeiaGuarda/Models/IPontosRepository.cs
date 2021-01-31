using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitalEuropeiaGuarda.Models
{
    public interface IPontosRepository
    {
        public IEnumerable<PontoInteresse> PontosInteresse { get; }
    }
}
