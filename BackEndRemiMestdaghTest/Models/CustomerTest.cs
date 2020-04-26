using BackEndRemiMestdagh.Data.Models;
using BackEndRemiMestdaghTest.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BackEndRemiMestdaghTest.Models
{
    public class CustomerTest
    {
        private DummyDbContext _context;
        public CustomerTest()
        {
            _context = new DummyDbContext();
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void LegeVoorNaamGeeftException(string invalidString)
        {
            Assert.Throws<ArgumentException>(() => _context.customer1.FirstName = invalidString);

        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void LegeAchterNaamGeeftException(string invalidString)
        {
            Assert.Throws<ArgumentException>(() => _context.customer1.LastName = invalidString);

        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void LegeEmailGeeftException(string invalidString)
        {
            Assert.Throws<ArgumentException>(() => _context.customer1.Email = invalidString);

        }
        [Fact]
        public void CorrecteParametersMaaktObject()
        {
            Customer customer = new Customer() { FirstName = "Henk", LastName = "Jamin", Email = "henk@jamin.be" };
            Assert.Equal("Henk", customer.FirstName);
            Assert.Equal("Jamin", customer.LastName);
            Assert.Equal("henk@jamin.be", customer.Email);

        }
        [Fact]
        public void AddToFavouritesVoegtFilmToe()
        {
            Customer customer = _context.customer1;
            Assert.Equal(1, customer.FavorieteFilms.Count);
            customer.AddToFavourites(_context.film2);
            Assert.Equal(2, customer.FavorieteFilms.Count);
        }
        [Fact]
        public void AddToFavouritesZelfdeFilmVoegtNietToe()
        {
            Customer customer = _context.customer1;
            Assert.Equal(1, customer.FavorieteFilms.Count);
            Assert.Throws<ArgumentException>(() => customer.AddToFavourites(_context.film1));
            Assert.Equal(1, customer.FavorieteFilms.Count);
        }
        [Fact]
        public void RemoveFromFavouritesVerwijdertFilm()
        {
            Customer customer = _context.customer1;
            Assert.Equal(1, customer.FavorieteFilms.Count);
            customer.RemoveFavourite(_context.film1);
            Assert.Equal(0, customer.FavorieteFilms.Count);
        }
        
    }
}
