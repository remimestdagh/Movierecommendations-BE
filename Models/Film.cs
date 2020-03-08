using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemiMestdagh.Models
{
    public class Film
    {
        [Key]
        [DatabaseGenerated( DatabaseGeneratedOption.None)]
        public string ImdbId { get; set; }
        public string Titel { get; set; }
     
        public double Score { get; set; }
       
        public List<ActeurFilm> Acteurs { get; set; }
        public Regisseur Regisseur { get; set; }
        public List<GenreFilm> Genres { get; set; }
   
        public string TitleImage { get; set; }
      
        public double Runtime { get; set; }
  
        public string Year { get; set; }

        public Film()
        {
            Acteurs = new List<ActeurFilm>();
            Genres = new List<GenreFilm>();
        }
        
    }
}
