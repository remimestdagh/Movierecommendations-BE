using BackEndRemiMestdagh.Data.Models;
using BackEndRemiMestdagh.DTOs;
using BackEndRemiMestdagh.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemiMestdagh.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmRepository _filmRepository;
        private readonly ICustomerRepository _customerRepository;
        public FilmsController(IFilmRepository context, ICustomerRepository customerRepository)
        {
            _filmRepository = context;
            _customerRepository = customerRepository;
        }

        [HttpGet("GetNextFilms")]
        public async Task<IEnumerable<FilmDTO>> GetNextFilms(string skip)
        {
            int getal = Int32.Parse(skip);
            Customer customer = _customerRepository.GetByEmail(User.Identity.Name);

            List<Film> films = await _filmRepository.GetSpecified(getal);
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
        public async Task<IActionResult> DeleteFavourite([FromRoute] int id)
        {
            Film film = await _filmRepository.GetById(id);
            if (film == null)
            {
                return NotFound();
            }
            Customer customer = _customerRepository.GetByEmail(User.Identity.Name);
            customer.RemoveFavourite(film);
            _customerRepository.SaveChanges();
            return NoContent();

        }

        [HttpGet("GetRecommendBasedOnFavourites")]
        public async Task<IEnumerable<FilmDTO>> GetRecommendationsForAllUserFavouritesAsync()
        {
            List<Film> recommendations = new List<Film>();
            Customer customer = _customerRepository.GetByEmail(User.Identity.Name);
            List<Film> favouritesCurrentUser = customer.GetFavouriteFilms();
            foreach (Film film in favouritesCurrentUser)
            {
                recommendations.AddRange(film.GetBestRecommendations(await _filmRepository.GetAll(), favouritesCurrentUser));
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
        public async Task<IActionResult> AddToFavourites([FromRoute] int id)
        {

            if (await _filmRepository.GetById(id) == null)
            {
                return BadRequest();
            }
            Customer customer = _customerRepository.GetByEmail(User.Identity.Name);
            if (customer == null)
            {
                return BadRequest();
            }
            Film film = await _filmRepository.GetById(id);
            try
            {
                customer.AddToFavourites(film);
            }
            catch (Exception e)
            {
                Console.WriteLine("Add to fav mislukt.");

            }

            _customerRepository.SaveChanges();
            return Ok();

        }




        [HttpGet("Favorites")]
        public IEnumerable<Film> GetFavorites()
        {
            Customer customer = null;
            try
            {
                customer = _customerRepository.GetByEmail(User.Identity.Name);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return customer.FavorieteFilms.Select(f => f.Film).ToList();
        }


        [HttpGet("{id}")]
        public  async Task<ActionResult<FilmDTO>> GetFilm(int id)
        {
            Film film = await _filmRepository.GetById(id);
            if (film is null)
            {
                return NotFound();
            }
            string[] genres = film.Genres.Select(g => g.Genre.Naam).ToArray();
            string[] acteurs = film.Acteurs.Select(g => g.Acteur.Naam).ToArray();
            FilmDTO dto = new FilmDTO() { Id = film.Id, Titel = film.Titel, Score = film.Score, Regisseur = film.Regisseur.Naam, Genres = genres, Acteurs = acteurs, TitleImage = film.TitleImage, Runtime = film.Runtime, Year = film.Year };
            return dto;
        }
        [HttpGet("{zoekString}/results")]
        public async Task<ActionResult<List<FilmDTO>>> SearchFilmAsync(string zoekString)
        {
            List<Film> films = new List<Film>();
            List<FilmDTO> dtos = new List<FilmDTO>();
            try
            {
                films = await _filmRepository.SearchFilms(zoekString);
            }
            catch (Exception e)
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