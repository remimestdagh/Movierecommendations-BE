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
       
        #endregion
        #region get favourites
        [Fact]
        public void GetFavorites_ReturnsListOfFilms()
        {
            _customerRepository.Setup(s => s.GetByEmail("henk@kaas.be")).Returns(_context.customer1);
            var films = Assert.IsAssignableFrom<IEnumerable<Film>>(_controller.GetFavorites());
            Assert.Single(films);
        }
       
        #endregion





    }
}
