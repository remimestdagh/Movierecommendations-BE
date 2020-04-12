using BackEndRemiMestdaghTest.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BackEndRemiMestdaghTest.Models
{
 public   class GenreTest

    {

        private DummyDbContext _context;
        public GenreTest()
        {
            _context = new DummyDbContext();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void LegeNaamGeeftException(string invalidString)
        {
            Assert.Throws<ArgumentException>(() => _context.genre1.Naam = invalidString);

        }



    }
}
