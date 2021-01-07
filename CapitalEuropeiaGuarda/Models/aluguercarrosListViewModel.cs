using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitalEuropeiaGuarda.Models
{
    public class aluguercarrosListViewModel
    {
        public IEnumerable<aluguercarros> Marca { get; set; }

        public PagingInfo Pagination { get; set; }

    }
}
