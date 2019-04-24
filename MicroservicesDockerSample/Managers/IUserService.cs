using MicroservicesDockerSample.Models;

namespace MicroservicesDockerSample.Managers
{
    public interface IUserService
    {
        void CreateUser(User user);
        User Authenticate(string userName, string password);
    }
}
