using BackEndRemiMestdagh.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace BackEndRemiMestdagh.Data
{
    public class Initializer
    {
        public Initializer()
        {

        }
        public void InitializeData()
        {
     


                using (StreamReader r = new StreamReader(@"C:\Users\remi\PycharmProjects\scraper2\scraper\films2.json"))
                {
                    string json = r.ReadToEnd();
           
              
              List<Film2> films = JsonConvert.DeserializeObject<List<Film2>>(json);
                Console.WriteLine(films[1].titel);
                
            }
           

                // List<Film2> deFilms= stuff.ToObject<List<Film2>>();
                //Console.WriteLine(deFilms);

            

        }
    }
}
