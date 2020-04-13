using System;

namespace BackEndRemiMestdagh.Models
{
    public class Acteur
    {
        private string _naam;
        public string Naam
        {
            get { return this._naam; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("De naam van de acteur dient ingevuld te worden.");
                }
                this._naam = value;
            }
        }

        public int Id { get; set; }

        public Acteur()
        {

        }
        public Acteur(string naam)
        {
            Naam = naam;
        }
    }
}
