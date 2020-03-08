using BackEndRemiMestdagh.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemiMestdagh.Data
{
    
        public class FilmContext : DbContext
        {
        public DbSet<Film> Films { get; set; }
        public DbSet<Acteur> Acteurs { get; set; }
        public DbSet<Regisseur> Regisseurs { get; set; }
        public FilmContext(DbContextOptions<FilmContext> options)
                : base(options)
            {
            }

            protected override void OnModelCreating(ModelBuilder builder)
            {
            builder.Entity<Film>().Property(r => r.Titel).IsRequired().HasMaxLength(50);
            builder.Entity<Acteur>().Property(r => r.Id).IsRequired().HasMaxLength(50);
            builder.Entity<Film>().HasKey(r => r.Id);
            builder.Entity<Acteur>().HasKey(r => r.Id);
            builder.Entity<Regisseur>().HasKey(r => r.Id);
            builder.Entity<Genre>().HasKey(r => r.Id);




        }

            
        }
    }
