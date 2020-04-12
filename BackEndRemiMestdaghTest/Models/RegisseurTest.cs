using BackEndRemiMestdaghTest.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BackEndRemiMestdaghTest.Models
{
   public class RegisseurTest
    {
        private DummyDbContext _context;

        public RegisseurTest()
        {
            _context = new DummyDbContext();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void LegeNaamGeeftException(string invalidString)
        {
            Assert.Throws<ArgumentException>(() => _context.regisseur1.Naam = invalidString);

        }
    }
}
