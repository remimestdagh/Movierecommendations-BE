using BackEndRemiMestdagh.Data.Models;
using BackEndRemiMestdagh.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackEndRemiMestdagh.Data
{

    public class FilmContext : IdentityDbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Acteur> Acteurs { get; set; }
        public DbSet<Regisseur> Regisseurs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public FilmContext(DbContextOptions<FilmContext> options)
                : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Film>().Property(r => r.Titel).IsRequired();
            builder.Entity<Film>().HasKey(r => r.Id);
            builder.Entity<Acteur>().HasKey(r => r.Id);
            builder.Entity<Regisseur>().HasKey(r => r.Naam);
            builder.Entity<Genre>().HasKey(r => r.Id);
            builder.Entity<ActeurFilm>().ToTable("ActeurFilms");
            builder.Entity<ActeurFilm>().HasKey(t => new { t.ActeurId, t.FilmId });
            builder.Entity<ActeurFilm>().HasOne(t => t.Film).WithMany(t => t.Acteurs).HasForeignKey(t => t.FilmId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ActeurFilm>().HasOne(t => t.Acteur).WithMany().HasForeignKey(t => t.ActeurId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<GenreFilm>().ToTable("GenreFilm");
            builder.Entity<GenreFilm>().HasKey(t => new { t.GenreId, t.FilmId });
            builder.Entity<GenreFilm>().HasOne(t => t.Film).WithMany(t => t.Genres).HasForeignKey(t => t.FilmId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<GenreFilm>().HasOne(t => t.Genre).WithMany().HasForeignKey(t => t.GenreId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CustomerFilm>().HasKey(t => new { t.CustomerId, t.FilmId });
            builder.Entity<CustomerFilm>().HasOne(t => t.Film).WithMany().HasForeignKey(t=>t.FilmId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<CustomerFilm>().HasOne(t => t.Klant).WithMany(t => t.FavorieteFilms).HasForeignKey(t=>t.CustomerId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Customer>().Ignore(c => c.Films);
            builder.Entity<Customer>().Ignore(c => c.Watchlist);




        }


    }
}
