using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemiMestdagh.Models
{
    public class Film
    {
       public int Id { get; set; }
        public string Titel { get; set; }
     
        public double Score { get; set; }
       
        public List<Acteur> Acteurs { get; set; }
        public Regisseur Regisseur { get; set; }
        public List<Genre> Genres { get; set; }
   
        public string TitleImage { get; set; }
      
        public double Runtime { get; set; }
  
        public int Year { get; set; }
    }
}
