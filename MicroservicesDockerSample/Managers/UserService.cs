using MicroservicesDockerSample.Models;
using System.Collections.Generic;
using System.Linq;

namespace MicroservicesDockerSample.Managers
{
    public class UserService : IUserService
    {
        private static List<User> users = new List<User>
        {
            new User
            {
                UserId = "44D88D58-8B22-44D3-9B35-B57AE992A878",
                UserName = "Admin",
                Password = "AdminPassword",
                Email = "admin@mysite.com",
                Roles = new string[] {"Administrator", "SuperUser"}
            },
            new User
            {
                UserId = "4FF3D275-A3AA-4A31-B05E-F296698190CF",
                UserName = "User",
                Password = "UserPassword",
                Email = "user@mysite.com",
                Roles = new string[] {"User"}
            },
        };

        public User Authenticate(string userName, string password)
        {
            return users.FirstOrDefault(x => x.UserName == userName && x.Password == password);
        }

        public void CreateUser(User user)
        {
            if(!users.Any(x=>x.UserId == user.UserId))
            {
                users.Add(user);
            }
        }
    }
}
