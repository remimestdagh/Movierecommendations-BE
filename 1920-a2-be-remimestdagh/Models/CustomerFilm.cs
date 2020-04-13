using BackEndRemiMestdagh.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemiMestdagh.Models
{
    public class CustomerFilm
    {
        public Film Film { get; set; }
        public Customer Klant { get; set; }
        public int CustomerId { get; set; }
        public int FilmId { get; set; }
       

    }
}
