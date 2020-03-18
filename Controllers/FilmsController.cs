using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemiMestdagh.Data.Models;
using BackEndRemiMestdagh.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndRemiMestdagh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmRepository _filmRepository;
        private readonly ICustomerRepository _customerRepository;
        public FilmsController(IFilmRepository context, ICustomerRepository customerRepository)
        {
            _filmRepository = context;
            _customerRepository = customerRepository;
        }
        [HttpGet]
        public IEnumerable<Film> GetFilms()
        {
            return _filmRepository.GetAll().OrderBy(r => r.Score);
        }

        [HttpGet]
        public IEnumerable<Film> GetCustomersFavourites()
        {
            Customer customer = _customerRepository.GetBy(User.Identity.Name);
            return _filmRepository.GetFavourites(customer);
        }
        [HttpGet]
        public IEnumerable<Film> GetBestRecommendationsForFilm(Film film)
        {
            Customer customer = _customerRepository.GetBy(User.Identity.Name);
            return film.GetBestRecommendations(_filmRepository.GetAll());
            
        }

    }
}