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
            if (FavorieteFilms.Select(s => s.Film).Contains(film))
            {
                throw new ArgumentException("This movie is already part of your favourites");
            }
            FavorieteFilms.ToList().Add(new CustomerFilm(this, film));
        }

        public List<Film> GetFavouriteFilms()
        {
            return FavorieteFilms.Select(f => f.Film).ToList();
        }

        #endregion


    }
}
