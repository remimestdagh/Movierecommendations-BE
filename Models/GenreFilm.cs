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
        public int GenreId { get; set; }
        public int FilmId { get; set; }
        public GenreFilm(Film film, Genre genre) : this()
        {
            Genre = genre;
            Film = film;
            GenreId = genre.GenreId;
            FilmId = film.FilmId;
        }
        public GenreFilm()
        {

        }
    }
}
