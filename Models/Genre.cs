using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemiMestdagh.Models
{
    public class Genre
    {
        private string _naam;
       
        public string Naam { get { return this._naam; } set {
                if(string.IsNullOrWhiteSpace(value)){
                    throw new ArgumentException("De naam van het genre moet ingevuld zijn");
                }
                _naam = value;
            } }
        public Genre()
        {

        }
        public Genre(string naam)
        {
            Naam = naam;
        }
    }
}
