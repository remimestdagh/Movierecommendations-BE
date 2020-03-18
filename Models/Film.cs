using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BackEndRemiMestdagh.Models
{
    public class Film
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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
        /*
        public List<KeyValuePair<List<String>, Film>> GetRecommendations(IEnumerable<Film> films)
        {
            //teller die kijkt hoeveel overeenkomsten er zijn

            List<KeyValuePair<List<String>, Film>> gelijkenissen = new List<KeyValuePair<List<String>, Film>>();
            List<String> gelijkenissenStrings = new List<String>();
            Film dezeFilm = films.Single(f => f.ImdbId == this.ImdbId);
            films.ToList().Remove(dezeFilm);
            foreach (Film film in films)
            {


                List<String> gelijkenissenString = new List<String>();
                String gemeenschappelijkeRegisseur = "";
                List<String> gemeenschappelijkeGenres = film.Genres.Intersect(this.Genres).Select(g => g.Genre.Naam).ToList();
                List<String> gemeenschappelijkeActeurs = film.Acteurs.Intersect(this.Acteurs).Select(a => a.Acteur.Naam).ToList();
                if (Regisseur == film.Regisseur)
                {
                    gemeenschappelijkeRegisseur = Regisseur.Naam;
                }
                foreach (String genre in gemeenschappelijkeGenres)
                {

                    gelijkenissenString.Add(genre);
                }
                foreach (String acteur in gemeenschappelijkeActeurs)
                {

                    gelijkenissenString.Add(acteur);
                }
                if (String.IsNullOrWhiteSpace(gemeenschappelijkeRegisseur))
                {

                    gelijkenissenString.Add(gemeenschappelijkeRegisseur);
                }
                KeyValuePair<List<String>, Film> filmMetGelijkenissen = new KeyValuePair<List<string>, Film>(gelijkenissenString, film);
                gelijkenissen.Add(filmMetGelijkenissen);
            }
            return gelijkenissen;
        }*/
        
        public List<Film> GetBestRecommendations(IEnumerable<Film> films)
        {
            List<KeyValuePair<int, Film>> filmMatches = new List<KeyValuePair<int, Film>>();
            foreach (Film film in films)
            {
                int aantalMatches = 0;
                List<String> gelijkenissenString = new List<String>();
                String gemeenschappelijkeRegisseur = "";
                List<String> gemeenschappelijkeGenres = film.Genres.Intersect(this.Genres).Select(g => g.Genre.Naam).ToList();
                List<String> gemeenschappelijkeActeurs = film.Acteurs.Intersect(this.Acteurs).Select(a => a.Acteur.Naam).ToList();
                if (Regisseur == film.Regisseur)
                {
                    gemeenschappelijkeRegisseur = Regisseur.Naam;
                }
                foreach (String genre in gemeenschappelijkeGenres)
                {
                    aantalMatches++;
                }
                foreach (String acteur in gemeenschappelijkeActeurs)
                {
                    aantalMatches++;
                }
                if (String.IsNullOrWhiteSpace(gemeenschappelijkeRegisseur))
                {
                    aantalMatches++;
                }
                filmMatches.Add(new KeyValuePair<int, Film>(aantalMatches, film));
            }
            int meesteMatches = filmMatches.Select(s => s.Key).Max();
            List<Film> besteMatches = filmMatches.Where(s => s.Key == meesteMatches).Select(s => s.Value).ToList();
            return besteMatches;
        }
    }

}

