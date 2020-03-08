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
                    HashSet<Acteur> acteurs = new HashSet<Acteur>();
                    HashSet<Genre> genres = new HashSet<Genre>();
                   
                    HashSet<Film> deFilms = new HashSet<Film>();
                    HashSet<Regisseur> deRegisseur = new HashSet<Regisseur>();


                    HashSet<string> deRegisseursString = new HashSet<string>();
                    HashSet<string> deGenresString = new HashSet<string>();
                    HashSet<string> deActeursString = new HashSet<string>();

                    foreach (MockObject m in films)
                    {
                        

                        string[] tempact = m.stars.Split(",");

                        string regisseurString = tempact[0];
                        deRegisseursString.Add(regisseurString);
                        Regisseur saveRegi = new Regisseur(regisseurString);
                        for (int i = 1; i < tempact.Length - 2; i++)
                        {
                            
                            deActeursString.Add(tempact[i]);
                        }

                        string[] tempgenres = m.genres.Split(", ");
                        for (int i = 0; i < tempgenres.Length - 1; i++)
                        {
                            deGenresString.Add(tempgenres[i]);
                        }
                        string[] tempruntime = m.runtime.Split(" ");
                        string formattedRuntime = "";

                        formattedRuntime = tempruntime[0];




                        Film nieuweFilm = new Film()
                        {
                            Titel = m.titel,
                            Score = double.Parse(m.score),
                            Regisseur = saveRegi,
                            TitleImage = m.titleImage,
                            Runtime = double.Parse(formattedRuntime),
                            Year = int.Parse(m.year)

                        };
                        

                        foreach (string acteur in deActeursString)
                        {
                            Acteur saveAct = new Acteur(acteur);
                            acteurs.Add(saveAct);
                            _context.Acteurs.Add(saveAct);

                        }
                        foreach (string genre in deGenresString)
                        {
                            Genre saveGenre = new Genre(genre);
                            genres.Add(saveGenre);
                            _context.Genres.Add(saveGenre);
                        }
                        foreach (string regisseur in deRegisseursString)
                        {
                            deRegisseur.Add(saveRegi);
                            _context.Regisseurs.Add(saveRegi);
                        }
                        List<ActeurFilm> acteurFilms = new List<ActeurFilm>();
                        List<GenreFilm> genreFilms = new List<GenreFilm>();
                        foreach (Acteur acteur in acteurs)
                        {
                            acteurFilms.Add(new ActeurFilm(nieuweFilm, acteur));
                        }
                        foreach (Genre genre in genres)
                        {
                            genreFilms.Add(new GenreFilm(nieuweFilm, genre));
                        }
                        nieuweFilm.Acteurs = acteurFilms;
                        nieuweFilm.Genres = genreFilms;
                        deFilms.Add(nieuweFilm);
                    }



                    Console.WriteLine(deFilms.Count);
                    Console.WriteLine(acteurs.Count);
                    Console.WriteLine(deRegisseur.Count);
                    Console.WriteLine(genres.Count);

                    _context.Films.AddRange(deFilms);
                }

            }
            _context.SaveChanges();

        }
    }
}
