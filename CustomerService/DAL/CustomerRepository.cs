using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerService.DAL
{
    public class CustomerRepository : IRepository
    {
        private static List<Customer> customerListInternal = new List<Customer>()
        {
            new Customer()
            {
                FirstName = "Ivan",
                LastName = "Dorosh",
                Phone = "380986794512"
            },
            new Customer()
            {
                FirstName = "Petro",
                LastName = "Tkach",
                Phone = "380986737635"
            },
            new Customer()
            {
                FirstName = "Vasyl",
                LastName = "Kysil",
                Phone = "380968874523"
            }
        };

        public async Task AddCustomer(Customer customer)
        {
            await Task.Factory.StartNew(()=> customerListInternal.Add(customer));
        }

        public async Task DeleteCustomer(Customer customer)
        {
            await Task.Factory.StartNew(()=>customerListInternal.Remove(customer));
        }

        public async Task<Customer> GetCustomer(string phone)
        {
            return await Task.Factory.StartNew(()=>
                customerListInternal
                .FirstOrDefault(x => string.Equals(x.Phone, phone, StringComparison.CurrentCulture)));
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await Task.Factory.StartNew(() => customerListInternal);
        }

        public async Task UpdateCustomer(Customer customer)
        {
            await Task.Factory.StartNew(() =>
            {
                var oldCustomer = customerListInternal
                    .FirstOrDefault(x => string.Equals(x.Phone, customer.Phone, StringComparison.CurrentCulture));

                if (oldCustomer != null)
                {
                    oldCustomer.FirstName = customer.FirstName;
                    oldCustomer.LastName = customer.LastName;
                }
            });
        }
    }
}
