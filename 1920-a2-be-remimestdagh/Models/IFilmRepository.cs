﻿using BackEndRemiMestdagh.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemiMestdagh.Models
{
    public interface IFilmRepository
    {
        IEnumerable<Film> GetAll();
        IEnumerable<Film> GetSpecified(int skip);
        Film GetById(int id);
        IEnumerable<Film> SearchFilms(string zoekString);
        
    }
}
