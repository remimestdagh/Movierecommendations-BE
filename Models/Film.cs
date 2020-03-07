using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemiMestdagh.Models
{
    public class Film
    {
        public string Titel { get; set; }
        public IEnumerable<string> Category { get; set; }
        public double Score { get; set; }
        public string Poster { get; set; }
        public IEnumerable<string> Acteurs { get; set; }
        public IEnumerable<string> Regisseurs { get; set; }
        
        public Film()
        {

        }
    }
}
