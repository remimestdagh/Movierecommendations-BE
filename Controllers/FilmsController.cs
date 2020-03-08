using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public FilmsController(IFilmRepository context)
        {
            _filmRepository = context;
        }
        [HttpGet]
        public IEnumerable<Film> GetFilms()
        {
            return _filmRepository.GetAll().OrderBy(r => r.Score);
        }

    }
}