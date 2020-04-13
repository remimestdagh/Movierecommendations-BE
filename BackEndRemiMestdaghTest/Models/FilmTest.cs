using BackEndRemiMestdagh.Models;
using BackEndRemiMestdaghTest.Data;
using System;
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



    }
}

