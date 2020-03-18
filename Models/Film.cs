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
     
        public int Score { get; set; }
       
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
        public KeyValuePair<List<String>,IEnumerable<Film>> GetRecommendations(IEnumerable<Film> films)
        {
            //teller die kijkt hoeveel overeenkomsten er zijn
            int aantalMatches = 0;
            List<String> gelijkenissen = new List<String>();
            Film dezeFilm = films.Single(f => f.ImdbId == this.ImdbId);
            films.ToList().Remove(dezeFilm);
            foreach(Film film in films)
            {
                String gemeenschappelijkeRegisseur = "";
                List<String> gemeenschappelijkeGenres = film.Genres.Intersect(this.Genres).Select(g => g.Genre.Naam).ToList();
                List<String> gemeenschappelijkeActeurs = film.Acteurs.Intersect(this.Acteurs).Select(a => a.Acteur.Naam).ToList();
                if(Regisseur == film.Regisseur)
                {
                    gemeenschappelijkeRegisseur = Regisseur.Naam;
                }
            }

        }
        
    }
}
