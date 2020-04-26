using BackEndRemiMestdagh.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackEndRemiMestdagh.Data.Models
{
    public class Customer
    {
        private string _firstName;
        private string _lastName;
        private string _email;

        #region Properties
        //add extra properties if needed
        public int CustomerId { get; set; }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Firstname can't be empty");
                }
                else
                {
                    this._firstName = value;
                }
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Lastname can't be empty");
                }
                else
                {
                    this._lastName = value;
                }
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Lastname can't be empty");
                }
                else
                {
                    this._email = value;
                }
            }
        }
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
