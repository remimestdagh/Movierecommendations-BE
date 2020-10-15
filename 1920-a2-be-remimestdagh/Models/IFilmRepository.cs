using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndRemiMestdagh.Models
{
    public interface IFilmRepository
    {
        Task<List<Film>> GetAll();
        Task<List<Film>> GetSpecified(int skip);
        Task<Film> GetById(int id);
        Task<List<Film>> SearchFilms(string zoekString);

    }
}
