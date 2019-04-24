using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneService.DAL
{
    public class PhoneRepository : IRepository
    {
        private static List<Phone> phoneListInternal = new List<Phone>()
        {
            new Phone()
            {
                Brand = "Xiaomi",
                Model = "Redmi Note 7",
                Emei = "emNote1",
                Emei2 = "emNote1",
                Price = 160
            },
            new Phone()
            {
                Brand = "Honor",
                Model = "8X",
                Emei = "emHonor1",
                Emei2 = "emHonor21",
                Price = 190
            },
            new Phone()
            {
                Brand = "Samsung",
                Model = "Galaxy S9+",
                Emei = "emSams1",
                Emei2 = "emSams1",
                Price = 620
            },
        };

        public async Task AddPhone(Phone phone)
        {
            await Task.Factory.StartNew(() => phoneListInternal.Add(phone));
        }

        public async Task DeletePhone(Phone phone)
        {
            await Task.Factory.StartNew(() => phoneListInternal.Remove(phone));
        }

        public async Task<Phone> GetPhone(string emei)
        {
            return await Task.Factory.StartNew(() =>
                phoneListInternal
                .FirstOrDefault(x => string.Equals(x.Emei, emei, StringComparison.CurrentCulture)));
        }

        public async Task<IEnumerable<Phone>> GetPhones()
        {
            return await Task.Factory.StartNew(() => phoneListInternal);
        }

        public async Task UpdatePhone(Phone phone)
        {
            await Task.Factory.StartNew(() =>
            {
                var oldPhone = phoneListInternal
                    .FirstOrDefault(x => string.Equals(x.Emei, phone.Emei, StringComparison.CurrentCulture));

                if (oldPhone != null)
                {
                    oldPhone.Price = phone.Price;
                }
            });
        }
    }
}
