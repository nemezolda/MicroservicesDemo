using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneService.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PhonesController : ControllerBase
    {
        private readonly IRepository repository;

        public PhonesController(IRepository repository)
        {
            this.repository = repository;
        }

        // GET api/values
        [HttpGet]
        [Authorize(Roles = "Administrator, User444")]
        public async Task<IEnumerable<Phone>> Get()
        {
            return await repository.GetPhones();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Phone> Get(string id)
        {
            return await repository.GetPhone(id);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] Phone phone)
        {
            await repository.AddPhone(phone);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody] Phone phone)
        {
            await repository.UpdatePhone(phone);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(Phone phone)
        {
            await repository.DeletePhone(phone);
        }
    }
}
