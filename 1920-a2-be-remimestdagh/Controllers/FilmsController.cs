using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndRemiMestdagh.Data.Models;
using BackEndRemiMestdagh.DTOs;
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
        public IEnumerable<FilmDTO> GetFilms()
        {
            Customer customer = _customerRepository.GetByEmail(User.Identity.Name);

            List<Film> films = _filmRepository.Get100().OrderByDescending(r => r.Score).ToList();
            List<FilmDTO> dtos = new List<FilmDTO>();
            foreach (Film film in films)
            {
                bool isFav = customer.IsFavourite(film);
                string[] genres = film.Genres.Select(g => g.Genre.Naam).ToArray();
                string[] acteurs = film.Acteurs.Select(g => g.Acteur.Naam).ToArray();
                dtos.Add(new FilmDTO() { Id = film.Id, Titel = film.Titel, Regisseur = film.Regisseur.Naam, TitleImage = film.TitleImage, Year = film.Year, IsFavourite = isFav });
            }
            return dtos;
            // return _filmRepository.GetAll().OrderByDescending(r => r.Score);
        }

        [AllowAnonymous] //dit moet nog veranderd worden
        [HttpGet("GetNextFilms")]
        public IEnumerable<FilmDTO> GetNextFilms(string skip)
        {
            int getal = Int32.Parse(skip);
            Customer customer = _customerRepository.GetByEmail(User.Identity.Name);

            List<Film> films = _filmRepository.GetSpecified(getal).OrderByDescending(r => r.Score).ToList();
            List<FilmDTO> dtos = new List<FilmDTO>();
            foreach (Film film in films)
            {
                bool isFav = customer.IsFavourite(film);
                string[] genres = film.Genres.Select(g => g.Genre.Naam).ToArray();
                string[] acteurs = film.Acteurs.Select(g => g.Acteur.Naam).ToArray();
                dtos.Add(new FilmDTO() { Id = film.Id, Titel = film.Titel, Regisseur = film.Regisseur.Naam, TitleImage = film.TitleImage, Year = film.Year, IsFavourite = isFav });
            }
            return dtos;
            // return _filmRepository.GetAll().OrderByDescending(r => r.Score);
        }

        [HttpGet("GetFavourites")]
        public IEnumerable<FilmDTO> GetCustomersFavourites()
        {
            Customer customer = _customerRepository.GetByEmail2(User.Identity.Name);
            List<Film> films = customer.Films.ToList();
            List<FilmDTO> dtos = new List<FilmDTO>();
            foreach (Film film in films)
            {
                string[] genres = film.Genres.Select(g => g.Genre.Naam).ToArray();
                string[] acteurs = film.Acteurs.Select(g => g.Acteur.Naam).ToArray();
                dtos.Add(new FilmDTO() { Id = film.Id, Titel = film.Titel, Regisseur = film.Regisseur.Naam, TitleImage = film.TitleImage, Year = film.Year, IsFavourite = true });
            }
            return dtos;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFavourite([FromRoute] int id)
        {
            Film film = _filmRepository.GetById(id);
            if (film == null)
            {
                return NotFound();
            }
            Customer customer = _customerRepository.GetByEmail(User.Identity.Name);
            customer.RemoveFavourite(film);
            _customerRepository.SaveChanges();
            return NoContent();

        }

        [HttpGet("GetRecommendForFilm")]
        public IEnumerable<Film> GetBestRecommendationsForFilm(Film film)
        {
            Customer customer = _customerRepository.GetByEmail(User.Identity.Name);

            return film.GetBestRecommendations(_filmRepository.GetAll(), customer.Films.ToList());

        }
        [HttpGet("GetRecommendBasedOnFavourites")]
        public IEnumerable<FilmDTO> GetRecommendationsForAllUserFavourites()
        {
            List<Film> recommendations = new List<Film>();
            Customer customer = _customerRepository.GetByEmail(User.Identity.Name);
            List<Film> favouritesCurrentUser = customer.GetFavouriteFilms();
            foreach (Film film in favouritesCurrentUser)
            {
                recommendations.AddRange(film.GetBestRecommendations(_filmRepository.GetAll(), favouritesCurrentUser));
            }
            List<FilmDTO> dtos = new List<FilmDTO>();
            foreach (Film film in recommendations)
            {
                string[] genres = film.Genres.Select(g => g.Genre.Naam).ToArray();
                string[] acteurs = film.Acteurs.Select(g => g.Acteur.Naam).ToArray();
                dtos.Add(new FilmDTO() { Id = film.Id, Titel = film.Titel, Score = film.Score, Regisseur = film.Regisseur.Naam, Genres = genres, Acteurs = acteurs, TitleImage = film.TitleImage, Runtime = film.Runtime, Year = film.Year });
            }
            return dtos;
            // return recommendations;

        }
        [HttpPost("{id}")]
        public IActionResult AddToFavourites([FromRoute] int id)
        {

            if (_filmRepository.GetById(id) == null)
            {
                return BadRequest();
            }
            Customer customer = _customerRepository.GetByEmail(User.Identity.Name);
            if (customer == null)
            {
                return BadRequest();
            }
            Film film = _filmRepository.GetById(id);
            try
            {
                customer.AddToFavourites(film);
            }
            catch (Exception e)
            {

            }

            _customerRepository.SaveChanges();
            return Ok();

        }




        [HttpGet("Favorites")]
        public IEnumerable<Film> GetFavorites()
        {
            Customer customer = _customerRepository.GetByEmail(User.Identity.Name);
            return customer.FavorieteFilms.Select(f => f.Film).ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<FilmDTO> GetFilm(int id)
        {
            Film film = _filmRepository.GetById(id);
            if (film == null)
            {
                return NotFound();
            }
            string[] genres = film.Genres.Select(g => g.Genre.Naam).ToArray();
            string[] acteurs = film.Acteurs.Select(g => g.Acteur.Naam).ToArray();
            FilmDTO dto = new FilmDTO() { Id = film.Id, Titel = film.Titel, Score = film.Score, Regisseur = film.Regisseur.Naam, Genres = genres, Acteurs = acteurs, TitleImage = film.TitleImage, Runtime = film.Runtime, Year = film.Year };
            return dto;
        }
        [HttpGet("{zoekString}/results")]
        public ActionResult<List<FilmDTO>> SearchFilm(string zoekString)
        {
            List<Film> films = new List<Film>();
            List<FilmDTO> dtos = new List<FilmDTO>();
            try
            {
              films = _filmRepository.SearchFilms(zoekString).ToList();
            }
            catch(Exception e)
            {

            }
            if (films == null | films.Count == 0)
            {
                return NotFound();
            }
            foreach (Film film in films)
            {
                string[] genres = film.Genres.Select(g => g.Genre.Naam).ToArray();
                string[] acteurs = film.Acteurs.Select(g => g.Acteur.Naam).ToArray();
                dtos.Add(new FilmDTO() { Id = film.Id, Titel = film.Titel, Score = film.Score, Regisseur = film.Regisseur.Naam, Genres = genres, Acteurs = acteurs, TitleImage = film.TitleImage, Runtime = film.Runtime, Year = film.Year });
            }
            return dtos;

        }

}
}