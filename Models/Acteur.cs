using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemiMestdagh.Models
{
    public class Acteur
    {
        public string Naam { get; set; }
        public int ActeurId { get; internal set; }


        public Acteur()
        {

        }
        public Acteur(string naam)
        {
            Naam = naam;
        }
    }
}
