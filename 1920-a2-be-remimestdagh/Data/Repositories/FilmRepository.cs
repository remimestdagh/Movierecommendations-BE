﻿using BackEndRemiMestdagh.Data.Models;
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
            List<Film> films = _films.Include(g => g.Genres).ThenInclude(g => g.Genre).Include(g => g.Acteurs).ThenInclude(g => g.Acteur).Include(f => f.Regisseur).ToList();
            if(films==null || films.Count == 0)
            {
                throw new ArgumentException("Het aantal films kon niet opgehaald worden");
            }
            return films;
        }
        public IEnumerable<Film> Get100()
        {
            List<Film> films = _films.Include(g => g.Genres).ThenInclude(g => g.Genre).Include(g => g.Acteurs).ThenInclude(g => g.Acteur).Include(f => f.Regisseur).Take(200).ToList();
            if (films == null || films.Count == 0)
            {
                throw new ArgumentException("Het aantal films kon niet opgehaald worden");
            }
            return films;
        }

        public Film GetById(int id)
        {
            return _films.Include(g => g.Genres).ThenInclude(g => g.Genre).Include(g => g.Acteurs).ThenInclude(g => g.Acteur).Include(f => f.Regisseur).FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Film> GetSpecified(int skip)
        {
            List<Film> films = _films.Include(g => g.Genres).ThenInclude(g => g.Genre).Include(g => g.Acteurs).ThenInclude(g => g.Acteur).Include(f => f.Regisseur).Skip(skip).Take(100).ToList();
            if (films == null || films.Count == 0)
            {
                throw new ArgumentException("Het aantal films kon niet opgehaald worden");
            }
            return films;
        }
    } 
}
