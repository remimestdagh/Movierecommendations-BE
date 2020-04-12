using BackEndRemiMestdaghTest.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BackEndRemiMestdaghTest.Models
{
   public class ActeurTest
    {
        private DummyDbContext _context;
        public ActeurTest()
        {
            _context = new DummyDbContext();
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void LegeNaamGeeftException(string invalidString)
        {
            Assert.Throws<ArgumentException>(() => _context.acteur1.Naam = invalidString);

        }
    }
}
