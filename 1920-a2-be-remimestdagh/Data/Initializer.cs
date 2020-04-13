using BackEndRemiMestdagh.Data.Models;
using BackEndRemiMestdagh.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemiMestdagh.Data
{
    public class Initializer
    {
        private FilmContext _context;
        private UserManager<IdentityUser> _userManager;
        public Initializer(FilmContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public async Task InitializeData()
        {
            _context.Database.EnsureDeleted();

            if (_context.Database.EnsureCreated())
            {
                







                using (StreamReader r = new StreamReader(@"C:\Users\Remi\Source\Repos\Web-IV\1920-a2-be-remimestdagh\1920-a2-be-remimestdagh\Data\json\films2000metId.json"))
                {
                    string json = r.ReadToEnd();


                    List<MockObject> films = JsonConvert.DeserializeObject<List<MockObject>>(json);
                 

                    _context.Database.EnsureDeleted();
                    if (_context.Database.EnsureCreated())
                    {


                        HashSet<Film> deFilms = new HashSet<Film>();
                        HashSet<Regisseur> deRegisseur = new HashSet<Regisseur>();


                        HashSet<string> deRegisseursString = new HashSet<string>();
                        HashSet<string> deGenresString = new HashSet<string>();
                        HashSet<string> deActeursString = new HashSet<string>();
                        HashSet<Acteur> acteurs = new HashSet<Acteur>();
                        HashSet<Genre> genres = new HashSet<Genre>();
                        foreach (MockObject m in films)
                        {
                            HashSet<string> deGenresStringVanFilm = new HashSet<string>();
                            HashSet<string> deActeursStringFilm = new HashSet<string>();
                            HashSet<Acteur> acteursVanFilm = new HashSet<Acteur>();
                            HashSet<Genre> genresVanFilm = new HashSet<Genre>();
                            Regisseur regisseurVanFilm;
                            string[] tempact = m.stars.Split(",");
                            string regisseurString = tempact[0];
                            deRegisseursString.Add(regisseurString);
                            if (deRegisseursString.Contains(regisseurString) && deRegisseur.Select(d => d.Naam).Contains(regisseurString))
                            {
                                regisseurVanFilm = deRegisseur.First(r => r.Naam.Equals(regisseurString));
                            }
                            else
                            {
                                regisseurVanFilm = new Regisseur(regisseurString);
                                deRegisseur.Add(regisseurVanFilm);
                                _context.Regisseurs.Add(regisseurVanFilm);
                            }


                            for (int i = 1; i < tempact.Length - 2; i++)
                            {
                                deActeursString.Add(tempact[i]);

                                deActeursStringFilm.Add(tempact[i]);
                            }

                            string[] tempgenres = m.genres.Split(", ");
                            for (int i = 0; i < tempgenres.Length - 1; i++)
                            {
                                deGenresString.Add(tempact[i]);

                                deGenresStringVanFilm.Add(tempgenres[i]);
                            }
                            string[] tempruntime = m.runtime.Split(" ");
                            string formattedRuntime = "";
                            formattedRuntime = tempruntime[0];
                            double formattedScore = double.Parse(m.score, CultureInfo.InvariantCulture) * 10;
                            int formattedScore2 = Convert.ToInt32(formattedScore);
                            Film nieuweFilm = new Film()
                            {
                                Titel = m.titel,
                                Score = formattedScore2,
                                Regisseur = regisseurVanFilm,
                                TitleImage = m.titleImage,
                                Runtime = int.Parse(formattedRuntime),
                                Year = int.Parse(m.year)

                            };
                            List<ActeurFilm> acteurFilms = new List<ActeurFilm>();
                            List<GenreFilm> genreFilms = new List<GenreFilm>();
                            foreach (string acteur in deActeursStringFilm)
                            {
                                Acteur acteur1;
                                if (deActeursString.Contains(acteur) && acteurs.Select(s => s.Naam).Contains(acteur))
                                {
                                    acteur1 = acteurs.First(a => a.Naam.Equals(acteur)) ?? null;
                                }
                                else
                                {
                                    acteur1 = new Acteur(acteur);
                                    acteurs.Add(acteur1);
                                    deActeursString.Add(acteur);
                                    _context.Acteurs.Add(acteur1);
                                }
                                acteursVanFilm.Add(acteur1);
                                acteurFilms.Add(new ActeurFilm(nieuweFilm, acteur1));


                            }
                            foreach (string genre in deGenresStringVanFilm)
                            {
                                Genre saveGenre;
                                if (deGenresString.Contains(genre) && genres.Select(g => g.Naam).Contains(genre))
                                {
                                    saveGenre = genres.First(g => g.Naam.Equals(genre)) ?? null;
                                }
                                else
                                {
                                    saveGenre = new Genre(genre);
                                    genres.Add(saveGenre);
                                    deGenresString.Add(genre);
                                    _context.Genres.Add(saveGenre);
                                }

                                genresVanFilm.Add(saveGenre);
                                genreFilms.Add(new GenreFilm(nieuweFilm, saveGenre));

                            }
                            nieuweFilm.Acteurs = acteurFilms;
                            nieuweFilm.Genres = genreFilms;
                            deFilms.Add(nieuweFilm);
                            _context.Films.Add(nieuweFilm);

                        }


                        _context.SaveChanges();

                        await InitializeUsers();

                    }

                }

            }
        }

        public async Task InitializeUsers()
        {
            Customer customer = new Customer { Email = "movieking@hogent.be", FirstName = "Adam", LastName = "Master" };

            IdentityUser user = new IdentityUser() { UserName = customer.Email, Email = customer.Email };
            await _userManager.CreateAsync(user, "P@ssword123");

            Customer student = new Customer { Email = "student@hogent.be", FirstName = "Student", LastName = "Hogent" };
            user = new IdentityUser() { UserName = student.Email, Email = student.Email };
            await _userManager.CreateAsync(user, "P@ssword123");

            _context.Customers.Add(customer);
            _context.Customers.Add(student);
            _context.SaveChanges();
        }

    }
}
