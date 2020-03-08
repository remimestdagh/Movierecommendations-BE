

using BackEndRemiMestdagh.Data.Models;

namespace BackEndRemiMestdagh.Controllers
{
    public interface ICustomerRepository
    {
        Customer GetBy(string email);
        void Add(Customer customer);

    }
}