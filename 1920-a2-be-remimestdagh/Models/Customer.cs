using BackEndRemiMestdagh.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackEndRemiMestdagh.Data.Models
{
    public class Customer
    {

        #region Properties
        //add extra properties if needed
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        public ICollection<CustomerFilm> FavorieteFilms { get; private set; }
        public IEnumerable<Film> Films => FavorieteFilms.Select(f => f.Film);

        #endregion

        #region Constructors
        public Customer()
        {
            FavorieteFilms = new List<CustomerFilm>();
        }
        #endregion

        #region methods
       public void AddToFavourites(Film film)
        {
            if (FavorieteFilms.Select(f => f.Film).Contains(film))
            {
                throw new ArgumentException("De film staat al in de favorieten");
            }
            FavorieteFilms.Add(new CustomerFilm() { Film = film, FilmId = film.Id, Klant = this, CustomerId = this.CustomerId });
        }
        public void RemoveFavourite(Film film)
        {
            CustomerFilm cf = FavorieteFilms.SingleOrDefault(f => f.FilmId == film.Id);
            FavorieteFilms.Remove(cf);
        }

        public List<Film> GetFavouriteFilms()
        {
            return FavorieteFilms.Select(f => f.Film).ToList();
        }
        public bool IsFavourite(Film film)
        {
            if (Films.Contains(film))
            {
                return true;
            }
            return false;
        }

        #endregion


    }
}
