using BackEndRemiMestdagh.Data.Models;
using BackEndRemiMestdagh.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemiMestdagh.Data.Repositories
{
    public class FilmRepository : IFilmRepository
    {

        private readonly FilmContext _context;
        private readonly DbSet<Film> _films;

        public FilmRepository(FilmContext dbContext)
        {
            _context = dbContext;
            _films = dbContext.Films;
        }

        public IEnumerable<Film> GetAll()
        {
            return _films.Include(f=>f.Regisseur).ToList();
        }

        public Film GetById(int id)
        {
            return _films.FirstOrDefault(f => f.Id == id);
        }


    } 
}
