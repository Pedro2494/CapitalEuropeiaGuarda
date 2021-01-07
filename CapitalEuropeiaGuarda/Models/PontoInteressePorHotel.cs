using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapitalEuropeiaGuarda.Models
{
    public class PontoInteressePorHotel
    {
        public int HotelId { get; set; }

        public Hoteis Hoteis { get; set; }

        public int PontoInteresseId { get; set; }

        public PontoInteresse PontoInteresse { get; set; }
    }
}
