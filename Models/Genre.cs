using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemiMestdagh.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
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
