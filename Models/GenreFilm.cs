using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemiMestdagh.Models
{
    public class GenreFilm
    {
        public Genre Genre { get; set; }
        public Film Film { get; set; }
        public string GenreId { get; set; }
        public string FilmId { get; set; }
        public GenreFilm(Film film, Genre genre) : this()
        {
            Genre = genre;
            Film = film;
            GenreId = genre.Naam;
            FilmId = film.Titel;
        }
        public GenreFilm()
        {

        }
    }
}
