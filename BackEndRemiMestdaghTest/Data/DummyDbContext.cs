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
        public Acteur acteur1 { get; set; }
        public Regisseur regisseur1 { get; set; }
        public Genre genre1 { get; set; }
        public Customer customer1 { get; set; }
        public Customer customer2 { get; set; }

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
            List<CustomerFilm> favorieteFilmsCustomer1 = new List<CustomerFilm>();
            
            customer1 = new Customer() { Email = "henk@kaas.be",CustomerId=1,FirstName="Henk",LastName="Kaas" };
            customer1.AddToFavourites(film1); 
            

        }
    }
}
