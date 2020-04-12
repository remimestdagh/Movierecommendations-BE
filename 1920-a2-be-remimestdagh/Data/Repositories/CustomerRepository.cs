using BackEndRemiMestdagh.Controllers;
using BackEndRemiMestdagh.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BackEndRemiMestdagh.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly FilmContext _context;
        private readonly DbSet<Customer> _customers;

        public CustomerRepository(FilmContext dbContext)
        {
            _context = dbContext;
            _customers = dbContext.Customers;
        }

        public Customer GetBy(string email)
        {
            return _customers.Include(c=>c.FavorieteFilms).ThenInclude(f=>f.Film).SingleOrDefault(c => c.Email == email);
        }

        public void Add(Customer customer)
        {
            _customers.Add(customer);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }


    }
}
