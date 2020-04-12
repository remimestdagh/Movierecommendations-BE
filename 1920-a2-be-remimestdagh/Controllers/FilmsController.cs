using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemiMestdagh.Data.Models;
using BackEndRemiMestdagh.Models;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous] //dit moet nog veranderd worden
        [HttpGet("GetFilms")]
        public IEnumerable<Film> GetFilms()
        {
            return _filmRepository.GetAll().OrderBy(r => r.Score);
        }

        [HttpGet("GetFavourites")]
        public IEnumerable<Film> GetCustomersFavourites()
        {
            Customer customer = _customerRepository.GetBy(User.Identity.Name);
            return _filmRepository.GetFavourites(customer);
        }
        [HttpGet("GetRecommendForFilm")]
        public IEnumerable<Film> GetBestRecommendationsForFilm(Film film)
        {
            Customer customer = _customerRepository.GetBy(User.Identity.Name);
            return film.GetBestRecommendations(_filmRepository.GetAll());
            
        }
        [HttpGet("GetRecommendBasedOnFavourites")]
        public IEnumerable<Film> GetRecommendationsForAllUserFavourites()
        {
            List<Film> recommendations = new List<Film>();
            Customer customer = _customerRepository.GetBy(User.Identity.Name);
            List<Film> favouritesCurrentUser = customer.GetFavouriteFilms();
            foreach(Film film in favouritesCurrentUser)
            {
                recommendations.AddRange(film.GetBestRecommendations(_filmRepository.GetAll()));
            }
            return recommendations;
          
        }

    }
}