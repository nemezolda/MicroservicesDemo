using PhoneService.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneService.Users
{
    public class UserService
    {
        private static IEnumerable<User> users = new List<User>
        {
            new User
            {
                UserId = "44D88D58-8B22-44D3-9B35-B57AE992A878",
                UserName = "Admin",
                Password = "AdminPassword",
                Roles = new string[] {"Administrator"}
            },
            new User
            {
                UserId = "4FF3D275-A3AA-4A31-B05E-F296698190CF",
                UserName = "User",
                Password = "UserPassword",
                Roles = new string[] {"User"}
            },
        };

        public User Authenticate(string userName, string password)
        {
            return users.FirstOrDefault(x => x.UserName == userName && x.Password == password);
        }
    }
}
