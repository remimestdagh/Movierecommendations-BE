using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRemiMestdagh.DTOs
{
    public class FilmDTO
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public int Score { get; set; }
        public string Regisseur { get; set; }
        public string[] Genres { get; set; }
        public string[] Acteurs { get; set; }
        public string TitleImage { get; set; }
        public double Runtime { get; set; }
        public int Year { get; set; }
    }
}
