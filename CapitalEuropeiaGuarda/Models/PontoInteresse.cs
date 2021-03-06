﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapitalEuropeiaGuarda.Models
{
    public class PontoInteresse
    {
        public int PontoInteresseId { get; set; }

        [Required(ErrorMessage = "Insira o nome do Ponto de Interesse")]
        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira o Local")]
        public string Local { get; set; }

        [Required(ErrorMessage = "Insira uma Descrição")]
        public string DescricaoCurta { get; set; }

        public byte[] Photo { get; set; }

        public byte[] Photo2 { get; set; }

        //public string Latitude { get; set; }

        //public string Longitude { get; set; }

        //public class PontoInteresseList
        //{
        //    public IEnumerable<PontoInteresse> PontoInteresseList { get; set; }
        //}
        public ICollection<PontoInteressePorHotel> HoteisPorPontoInteresse { get; set; }

    }
}
