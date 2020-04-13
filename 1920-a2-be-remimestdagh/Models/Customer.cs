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

        public CustomerFilm CustomerFilm
        {
            get => default;
            set
            {
            }
        }


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
            FavorieteFilms.Add(new CustomerFilm() { Film = film, FilmId = film.Id, Klant = this, CustomerId = this.CustomerId });
        }

        public List<Film> GetFavouriteFilms()
        {
            return FavorieteFilms.Select(f => f.Film).ToList();
        }

        #endregion


    }
}
