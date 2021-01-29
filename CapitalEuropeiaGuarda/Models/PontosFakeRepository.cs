using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitalEuropeiaGuarda.Models
{
    public class PontosFakeRepository: IPontosRepository
    {
        public IEnumerable<PontoInteresse> PontosInteresse =>
               new List<PontoInteresse>
               {
                new PontoInteresse {
                    PontoInteresseId = 1,
                    Nome = "Sé Catedral da Guarda",
                    Local = "Guarda",
                    DescricaoCurta = "Sé Catedral"
                },
                new PontoInteresse {
                    PontoInteresseId = 2,
                    Nome = "Sortelha",
                    Local = "Sabugal",
                    DescricaoCurta = "Aldeia Histórica"
                },
                new PontoInteresse {
                    PontoInteresseId = 3,
                    Nome = "Igreja da Misericórdia",
                    Local = "Guarda",
                    DescricaoCurta = "Igreja"
                }
               };
    }
}
