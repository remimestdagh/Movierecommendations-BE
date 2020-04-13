using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemiMestdagh.Models
{
    public class ActeurFilm
    {
        public Acteur Acteur { get; set; }
        public Film Film { get; set; }
        public int ActeurId { get; set; }
        public int FilmId { get; set; }
        public ActeurFilm(Film film, Acteur acteur):this()
        {
            Acteur = acteur;
            Film = film;
            ActeurId = acteur.Id;
            FilmId = film.Id;
        }
        public ActeurFilm()
        {

        }
    }
}
