

using BackEndRemiMestdagh.Data.Models;
using BackEndRemiMestdagh.Models;
using System.Collections.Generic;

namespace BackEndRemiMestdagh.Controllers
{
    public interface ICustomerRepository
    {
        Customer GetBy(string email);
        void Add(Customer customer);
      
        void SaveChanges();

    }
}