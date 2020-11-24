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

        public async Task<List<Film>> GetAll()
        {
            List<Film> films = await _films.Include(g => g.Genres).ThenInclude(g => g.Genre).Include(g => g.Acteurs).ThenInclude(g => g.Acteur).Include(f => f.Regisseur).ToListAsync();
            if(films==null || films.Count == 0)
            {
                throw new ArgumentException("Het aantal films kon niet opgehaald worden");
            }
            return films;
        }

        public async Task<Film> GetById(int id)
        {
            return await _films.Include(g => g.Genres).ThenInclude(g => g.Genre).Include(g => g.Acteurs).ThenInclude(g => g.Acteur).Include(f => f.Regisseur).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task< List<Film>> GetSpecified(int skip)
        {
            List<Film> films = await _films.Include(g => g.Genres).ThenInclude(g => g.Genre).Include(g => g.Acteurs).ThenInclude(g => g.Acteur).Include(f => f.Regisseur).Skip(skip).Take(20).ToListAsync();
            if (films == null || films.Count == 0)
            {
                throw new ArgumentException("Het aantal films kon niet opgehaald worden");
            }
            return films;
        }

        public async Task<List<Film>> SearchFilms(string zoekString)
        {
            List<Film> films = await _films.Include(g => g.Genres).ThenInclude(g => g.Genre)
                .Include(g => g.Acteurs).ThenInclude(g => g.Acteur).Include(f => f.Regisseur).Where(a=>a.Titel.Contains(zoekString)).ToListAsync();
            if (films == null || films.Count == 0)
            {
                throw new ArgumentException("Het aantal films kon niet opgehaald worden");
            }
            return films;
        }
    } 
}
