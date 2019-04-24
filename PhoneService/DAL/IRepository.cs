using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneService.DAL
{
    public interface IRepository
    {
        Task<Phone> GetPhone(string phone);
        Task<IEnumerable<Phone>> GetPhones();
        Task AddPhone(Phone customer);
        Task DeletePhone(Phone customer);
        Task UpdatePhone(Phone customer);
    }
}
