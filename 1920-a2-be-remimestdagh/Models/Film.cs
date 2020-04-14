using System;
using System.Collections.Generic;
using System.Linq;

namespace BackEndRemiMestdagh.Models
{
    public class Film
    {
        private string _titel;
        private int _score;
        private string _titleImage;
        private double _runtime;
        private int _year;

        public int Id { get; set; }
        public string Titel
        {
            get
            {
                return this._titel;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("De titel is leeg");
                }
                this._titel = value;
            }
        }

        public int Score
        {
            get { return this._score; }
            set
            {
                if (value <= 0 || value > 100)
                {
                    throw new ArgumentException("De score is niet ingevuld");
                }
                this._score = value;
            }
        }

        public List<ActeurFilm> Acteurs { get; set; }
        public Regisseur Regisseur { get; set; }
        public List<GenreFilm> Genres { get; set; }

        public string TitleImage
        {
            get { return this._titleImage; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("De foto is niet ingevuld");
                }
                this._titleImage = value;
            }
        }

        public double Runtime
        {
            get { return this._runtime; }
            set
            {
                if (value <= 0 || value > 1000)
                {
                    throw new ArgumentException("De duur van de film moet groter dan 0 zijn");
                }
                this._runtime = value;
            }
        }

        public int Year
        {
            get { return this._year; }
            set
            {
                if (value <= 1800 || value > 2100)
                {
                    throw new ArgumentException("Het jaar moet groter dan 0 zijn");
                }
                this._year = value;
            }
        }

        public Film()
        {
            Acteurs = new List<ActeurFilm>();
            Genres = new List<GenreFilm>();
        }
        public Film(string titel, int score, List<ActeurFilm> acteurs, Regisseur regisseur, List<GenreFilm> genres, string titleimage, double runtime, int year) : this()
        {

            Titel = titel;
            Score = score;
            Acteurs = acteurs;
            Regisseur = regisseur;
            Genres = genres;
            TitleImage = titleimage;
            Runtime = runtime;
            Year = year;
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


        //todo sorteren zodat de beste match eerst komt
        public List<Film> GetBestRecommendations(IEnumerable<Film> films,List<Film>favorieten)
        {
            List<KeyValuePair<int, Film>> filmMatches = new List<KeyValuePair<int, Film>>();
            foreach (Film film in films)
            {
                int aantalMatches = 0;
                List<String> gemeenschappelijkeGenres = film.Genres.Intersect(this.Genres).Select(g => g.Genre.Naam).ToList();

                if (Regisseur.Naam.Equals(film.Regisseur.Naam))
                {
                    aantalMatches++;
                }
    
                aantalMatches = aantalMatches + gemeenschappelijkeGenres.Count;

                filmMatches.Add(new KeyValuePair<int, Film>(aantalMatches, film));


            }
            int meesteMatches = filmMatches.Select(s => s.Key).Max();
            List<Film> besteMatches = filmMatches.Where(s => s.Key == meesteMatches).Select(s => s.Value).ToList();
            return besteMatches.Except(favorieten).ToList();
        }
    }

}

