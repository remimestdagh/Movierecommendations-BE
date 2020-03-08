using BackEndRemiMestdagh.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace BackEndRemiMestdagh.Data
{
    public class Initializer
    {
        private FilmContext _context;
        public Initializer(FilmContext context)
        {
            _context = context;

        }
        public void InitializeData()
        {

            using (StreamReader r = new StreamReader(@"C:\Users\remi\PycharmProjects\scraper2\scraper\films2000.json"))
            {
                string json = r.ReadToEnd();


                List<MockObject> films = JsonConvert.DeserializeObject<List<MockObject>>(json);
                Console.WriteLine(films[1].ToString());




                _context.Database.EnsureDeleted();
                if (_context.Database.EnsureCreated())
                {

                    foreach (MockObject m in films)
                    {
                        List<Acteur> acteurs = new List<Acteur>();

                        string[] tempact = m.stars.Split(",");
                        Regisseur regisseur = new Regisseur() { Naam = tempact[0] };
                        for (int i = 1; i < tempact.Length - 1; i++)
                        {
                            acteurs.Add(new Acteur() { Naam = tempact[i] });
                        }
                        List<Genre> genres = new List<Genre>();
                        string[] tempgenres = m.genres.Split(", ");
                        for (int i = 0; i < tempgenres.Length - 1; i++)
                        {
                            genres.Add(new Genre() { Naam = tempgenres[i] });
                        }
                        string[] tempruntime = m.runtime.Split(" ");
                        string formattedRuntime = "";

                        formattedRuntime = tempruntime[0];



                        _context.Films.Add(new Film()
                        {
                            Titel = m.titel,
                            Score = double.Parse(m.score),
                            Acteurs = acteurs,
                            Regisseur = regisseur,
                            Genres = genres,
                            TitleImage = m.titleImage,
                            Runtime = double.Parse(formattedRuntime),
                            Year = int.Parse(m.year)

                        });

                     _context.Acteurs.AddRange(acteurs);
                        _context.Regisseurs.Add(regisseur);
                    }


                }

            }
            _context.SaveChanges();

        }
    }
}
