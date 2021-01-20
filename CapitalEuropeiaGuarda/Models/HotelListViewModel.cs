using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitalEuropeiaGuarda.Models
{
    public class HotelListViewModel
    {
       public IEnumerable<Hoteis> hotel { get; set; }

        //public PaginatedList Pagination { get; set; }

        public string SearchName { get; set; }
    }
}
