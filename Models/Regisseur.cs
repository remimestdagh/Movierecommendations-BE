using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemiMestdagh.Models
{
    public class Regisseur
    {
        public string Naam { get; set; }
        public int RegisseurId { get; internal set; }

        public Regisseur()
        {

        }
        public Regisseur(string naam)
        {
            Naam = naam;
        }
    }
}
