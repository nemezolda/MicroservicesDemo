using System.Collections.Generic;
using System.Security.Claims;

namespace MicroservicesDockerSample.Models
{
    public interface IAuthContainerModel
    {
        string Secretkey { get; set; }
        string SecurityAlgorithm { get; set; }
        int ExpireInterval { get; set; }
        IEnumerable<Claim> Claims { get; }
    }
}
