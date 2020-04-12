using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemiMestdagh.Models
{
    public class Regisseur
    {
        private string _naam;
        public string Naam { get { return this._naam; } set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("De naam van de regisseur moet ingevuld zijn");
                }
                this._naam = value;
            } }
    

        public Regisseur()
        {

        }
        public Regisseur(string naam)
        {
            Naam = naam;
        }
    }
}
