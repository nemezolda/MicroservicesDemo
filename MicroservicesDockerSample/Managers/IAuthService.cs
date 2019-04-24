using MicroservicesDockerSample.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace MicroservicesDockerSample.Managers
{
    public interface IAuthService
    {
        string SecretKey { get; set; }
        string GenerateToken(IAuthContainerModel model);
        IEnumerable<Claim> GetTokenClaims(string token);
    }
}
