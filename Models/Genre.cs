using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemiMestdagh.Models
{
    public class Genre
    {
       
        public string Naam { get; set; }
        public Genre()
        {

        }
        public Genre(string naam)
        {
            Naam = naam;
        }
    }
}
