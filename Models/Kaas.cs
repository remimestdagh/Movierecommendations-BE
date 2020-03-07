using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Kaas
    {
        public string KaasNaam { get; set; }
        public double KaasPrijs { get; set; }
        public KaasCategorie KaasCategorie { get; set; }
        public KaasLand KaasLand { get; set; }
    }
}