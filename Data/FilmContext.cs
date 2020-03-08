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
        public DbSet<Genre> Genres { get; set; }
        public FilmContext(DbContextOptions<FilmContext> options)
                : base(options)
            {

            }

            protected override void OnModelCreating(ModelBuilder builder)
            {
            builder.Entity<Film>().Property(r => r.Titel).IsRequired().HasMaxLength(50);
            builder.Entity<Acteur>().Property(r => r.ActeurId).IsRequired().HasMaxLength(50);
            builder.Entity<Film>().HasKey(r => r.FilmId);
            builder.Entity<Acteur>().HasKey(r => r.ActeurId);
            builder.Entity<Regisseur>().HasKey(r => r.RegisseurId);
            builder.Entity<Genre>().HasKey(r => r.GenreId);
            builder.Entity<ActeurFilm>().HasKey(t => new { t.ActeurId, t.FilmId });
            builder.Entity<ActeurFilm>().HasOne(t => t.Film).WithMany(t=>t.Acteurs).HasForeignKey(t => t.FilmId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ActeurFilm>().HasOne(t => t.Acteur).WithMany().HasForeignKey(t => t.ActeurId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<GenreFilm>().HasKey(t => new { t.GenreId, t.FilmId });
            builder.Entity<GenreFilm>().HasOne(t => t.Film).WithMany(t=>t.Genres).HasForeignKey(t => t.FilmId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<GenreFilm>().HasOne(t => t.Genre).WithMany().HasForeignKey(t => t.GenreId).IsRequired().OnDelete(DeleteBehavior.Cascade);





        }

            
        }
    }
