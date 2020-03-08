using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemiMestdagh.Models
{
    public class Regisseur
    {
        public string Naam { get; set; }
    

        public Regisseur()
        {

        }
        public Regisseur(string naam)
        {
            Naam = naam;
        }
    }
}
