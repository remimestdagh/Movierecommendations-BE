﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemiMestdagh.Models
{
    public interface IFilmRepository
    {
        IEnumerable<Film> GetAll();
    }
}