using CustomerService.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IRepository repository;

        public CustomersController(IRepository repository)
        {
            this.repository = repository;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await repository.GetCustomers();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Customer> Get(string id)
        {
            return await repository.GetCustomer(id);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] Customer customer)
        {
            await repository.AddCustomer(customer);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody] Customer customer)
        {
            await repository.UpdateCustomer(customer);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(Customer customer)
        {
            await repository.DeleteCustomer(customer);
        }
    }
}
