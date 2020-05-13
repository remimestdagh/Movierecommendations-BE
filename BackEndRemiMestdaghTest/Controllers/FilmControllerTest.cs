using BackEndRemiMestdagh.Controllers;
using BackEndRemiMestdagh.DTOs;
using BackEndRemiMestdagh.Models;
using BackEndRemiMestdaghTest.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using Xunit;

namespace BackEndRemiMestdaghTest.Controllers
{
    public class FilmControllerTest
    {
        private readonly FilmsController _controller;
        private readonly DummyDbContext _context;
        private readonly Mock<IFilmRepository> _filmRepository;
        private readonly Mock<ICustomerRepository> _customerRepository;
        private readonly DefaultHttpContext _controllerContext;

        public FilmControllerTest()
        {
            _context = new DummyDbContext();
            _filmRepository = new Mock<IFilmRepository>();
            _customerRepository = new Mock<ICustomerRepository>();
            _controller = new FilmsController(_filmRepository.Object, _customerRepository.Object);
            //deze zijn nodig om User.Identity.Name correct te mocken
            var identity = new GenericIdentity("henk@kaas.be");
            var principal = new ClaimsPrincipal(identity);
            _controllerContext = new DefaultHttpContext() { 
            User=principal};
            _controller.ControllerContext = new ControllerContext()
            {
                HttpContext = _controllerContext
            };
        }
        #region get id
        [Fact]
        public void GetFilm_GeeftFilmTerugAlsCorrectIdWordtGebruikt()
        {
            _filmRepository.Setup(s => s.GetById(1)).Returns(_context.film1);
            var actionResult = Assert.IsType<ActionResult<FilmDTO>>(_controller.GetFilm(1));
            var film = Assert.IsAssignableFrom<FilmDTO>(actionResult.Value);
        }
        #endregion
        #region get favourites
        [Fact]
        public void GetFavorites_ReturnsListOfFilms()
        {
            _customerRepository.Setup(s => s.GetByEmail("henk@kaas.be")).Returns(_context.customer1);
            var films = Assert.IsAssignableFrom<IEnumerable<Film>>(_controller.GetFavorites());
            Assert.Single(films);
        }
        [Fact]
        public void AddToFavourites_AddsNewFilmToList()
        {
            _filmRepository.Setup(s => s.GetById(69)).Returns(_context.film7);
            _customerRepository.Setup(s => s.GetByEmail("henk@kaas.be")).Returns(_context.customer1);
            Assert.Single(_context.customer1.FavorieteFilms);
            _controller.AddToFavourites(69);
            Assert.Equal(2, _context.customer1.FavorieteFilms.ToList().Count);
        }
        [Fact]
        public void DeleteFavourite_DeletesFilm()
        {
            _filmRepository.Setup(s => s.GetById(1)).Returns(_context.film1);
            _customerRepository.Setup(s => s.GetByEmail("henk@kaas.be")).Returns(_context.customer1);
            Assert.Single(_context.customer1.FavorieteFilms);
            _controller.DeleteFavourite(1);
            Assert.Empty(_context.customer1.FavorieteFilms.ToList());
        }

        [Fact]
        public void GetNextFilms_ReturnsListOfFilms()
        {
            _customerRepository.Setup(s => s.GetByEmail("henk@kaas.be")).Returns(_context.customer1);
            _filmRepository.Setup(s => s.GetSpecified(0)).Returns(_context.alleFilms);
            var films = Assert.IsAssignableFrom<List<FilmDTO>>(_controller.GetNextFilms("0"));
            Assert.Equal(6,films.Count);

        }
        [Fact]
        public void GetRecommendations_ReturnsListOfFilms()
        {
            _filmRepository.Setup(s => s.GetAll()).Returns(_context.alleFilms);
            _customerRepository.Setup(s => s.GetByEmail("henk@kaas.be")).Returns(_context.customer1);
            var films = Assert.IsAssignableFrom<IEnumerable<FilmDTO>>(_controller.GetRecommendationsForAllUserFavourites());
            Assert.Equal(5,films.ToList().Count);
        }
        [Fact]
        public void SearchFilm_ReturnsListOfFilms()
        {
            _filmRepository.Setup(s => s.SearchFilms("bill")).Returns(_context.zoekResult);
            _customerRepository.Setup(s => s.GetByEmail("henk@kaas.be")).Returns(_context.customer1);
            var result = Assert.IsAssignableFrom<ActionResult<List<FilmDTO>>>(_controller.SearchFilm("bill"));
            var films = result.Value;
            Assert.Equal(3, films.Count);
        }
        #endregion





    }
}
