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

       
        public List<Film> GetBestRecommendations(IEnumerable<Film> films, List<Film> favorieten)
        {
            List<KeyValuePair<Film, int>> filmMatches = new List<KeyValuePair<Film, int>>();
            foreach (Film film in films)
            {
                int aantalMatches = 0;
                if (Regisseur.Naam.Equals(film.Regisseur.Naam))
                {
                    aantalMatches++;
                }
                
                foreach(Genre genre in Genres.Select(m=>m.Genre))
                {
                    if (genre.Naam.Equals(film.Genres.Select(g => g.Genre.Naam)))
                    {
                        aantalMatches++;
                    }
                }
                foreach (Acteur acteur in Acteurs.Select(m => m.Acteur))
                {
                    if (acteur.Naam.Equals(film.Acteurs.Select(g => g.Acteur.Naam)))
                    {
                        aantalMatches++;
                    }
                }



                filmMatches.Add(new KeyValuePair<Film, int>(film, aantalMatches));


            }
            int meesteMatches = filmMatches.Select(s => s.Value).Max();
            List<Film> besteMatches = filmMatches.Where(s => s.Value == meesteMatches |s.Value == meesteMatches-1).Select(s => s.Key).ToList();
            return besteMatches.Except(favorieten).ToHashSet().ToList();
        }
    }

}

