using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerService.DAL
{
    public interface IRepository
    {
        Task<Customer> GetCustomer(string phone);
        Task<IEnumerable<Customer>> GetCustomers();
        Task AddCustomer(Customer customer);
        Task DeleteCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
    }
}
