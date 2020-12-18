using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitalEuropeiaGuarda.Models
{
    public class HoteisListViewModel
    {
        public IEnumerable<Hoteis> Hoteis { get; set; }

        public PagingInfo Pagination { get; set; }
    }
}
