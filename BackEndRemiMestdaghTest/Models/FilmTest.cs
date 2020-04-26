using BackEndRemiMestdagh.Models;
using BackEndRemiMestdaghTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BackEndRemiMestdaghTest.Models
{
    public class FilmTest
    {
        private DummyDbContext _context;

        public FilmTest()
        {
            _context = new DummyDbContext();


        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void LegeTitelGeeftException(string invalidString)
        {
            Assert.Throws<ArgumentException>(() => _context.film1.Titel=invalidString);

        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void LegeTitleImageGeeftException(string invalidString)
        {
            Assert.Throws<ArgumentException>(() => _context.film1.TitleImage = invalidString);

        }
        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-1000)]
        [InlineData(101)]
        public void NegatieveOfVerkeerdeWaardeScoreGeeftException(int score)
        {
            Assert.Throws<ArgumentException>(() => _context.film1.Score = score);

        }

        [Theory]
        [InlineData(null)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1001)]
        [InlineData(-1000)]
        public void NegatieveOfVerkeerdeWaardeRuntimeGeeftException(double waarde)
        {
            Assert.Throws<ArgumentException>(() => _context.film1.Runtime = waarde);
        }
        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(2101)]
        [InlineData(1750)]
        public void NegatieveOfVerkeerdeWaardeJaartalGeeftException(int jaartal)
        {
            Assert.Throws<ArgumentException>(() => _context.film1.Year = jaartal);

        }

        [Fact]
        public void FilmAanMaken()
        {
            Film film = new Film()
            {
                Titel = "Kaasmovie",
                Score = 100,

                TitleImage = "poster.png",
                Runtime = 95,
                Year = 1997
            };
            Assert.Equal("Kaasmovie", film.Titel);
            Assert.Equal(100, film.Score);
            Assert.Equal("poster.png", film.TitleImage);
            Assert.Equal(95, film.Runtime);
            Assert.Equal(1997, film.Year);

        }
        [Fact]
        public void GetBestRecommendationsGeeftLijstTerug()
        {
            List<Film> recommendations = _context.film1.GetBestRecommendations(_context.alleFilms, _context.customer1.Films.ToList());
            Assert.NotEmpty(recommendations);

        }



    }
}

