using BackEndRemiMestdagh.Data.Models;
using BackEndRemiMestdagh.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace BackEndRemiMestdaghTest.Data
{
    public class DummyDbContext
    {
        public Film film1 { get; set; }
        public Film film2 { get; set; }
        public Film film4 { get; set; }
        public Film film5 { get; set; }
        public Film film6 { get; set; }
        public Film film3 { get; set; }
        public Film film7 { get; set; }
        public List<Film> alleFilms { get; set; }
        public Acteur acteur1 { get; set; }
        public Regisseur regisseur1 { get; set; }
        public Genre genre1 { get; set; }
        public Customer customer1 { get; set; }
        public Customer customer2 { get; set; }
        public List<Film> zoekResult { get; set; }

        public DummyDbContext()
        {
    
            regisseur1 = new Regisseur() { Naam = "Henk Horses" };
            acteur1 = new Acteur("Roderick Kaas");
            genre1 = new Genre("thriller");

            film1 = new Film()
            {
                Titel = "Kill Bill",
                Id = 2,
                Score = 90,
                Regisseur = regisseur1,
                TitleImage = "foto.png",
                Runtime = 200,
                Year = 1997
                
            };
            film2 = new Film()
            {
                Titel = "Kill Bill 2",
                Id = 2,
                Score = 90,
                Regisseur = regisseur1,
                TitleImage = "foto.png",
                Runtime = 200,
                Year = 1999
            };
            film3 = new Film()
            {
                Titel = "Kill Bill 3",
                Id = 3,
                Score = 90,
                Regisseur = regisseur1,
                TitleImage = "foto.png",
                Runtime = 200,
                Year = 1999
            };
            film4 = new Film()
            {
                Titel = "Leopold Henkst",
                Id = 4,
                Score = 90,
                Regisseur = regisseur1,
                TitleImage = "foto.png",
                Runtime = 200,
                Year = 1989
            };
            film5 = new Film()
            {
                Titel = "Joost Jamin",
                Id = 5,
                Score = 83,
                Regisseur = regisseur1,
                TitleImage = "foto.png",
                Runtime = 200,
                Year = 1999
            };
            film6 = new Film()
            {
                Titel = "Quite Frankly",
                Id = 6,
                Score = 67,
                Regisseur = regisseur1,
                TitleImage = "foto.png",
                Runtime = 200,
                Year = 1998
            };
            film7 = new Film()
            {
                Titel = "Big Animals",
                Id = 69,
                Score = 67,
                Regisseur = regisseur1,
                TitleImage = "foto.png",
                Runtime = 200,
                Year = 1998
            };
            alleFilms = new List<Film>();
            alleFilms.AddRange(new Film[] {film1,film2,film3,film4,film5,film6 });
            List<CustomerFilm> favorieteFilmsCustomer1 = new List<CustomerFilm>();
            zoekResult = new List<Film>();
            zoekResult.AddRange(new Film[] { film1, film2, film3 });
            
            customer1 = new Customer() { Email = "henk@kaas.be",CustomerId=1,FirstName="Henk",LastName="Kaas" };
            customer1.AddToFavourites(film1); 
            

        }
    }
}
