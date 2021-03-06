﻿using System;

namespace BackEndRemiMestdagh.Models
{
    public class Genre
    {
        private string _naam;
       
        public string Naam { get { return this._naam; }
            set 
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("De naam van het genre moet ingevuld zijn");
                }
                this._naam = value;
            } }
        public int Id { get; set; }
        public Genre()
        {

        }
        public Genre(string naam)
        {
            Naam = naam;
        }
    }
}
