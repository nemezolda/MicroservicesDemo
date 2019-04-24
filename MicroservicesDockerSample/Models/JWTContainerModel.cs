using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Security.Claims;

namespace MicroservicesDockerSample.Models
{
    public class JWTContainerModel : IAuthContainerModel
    {
        private readonly User user;
        private List<Claim> claims;

        public JWTContainerModel(User user)
        {
            this.user = user;
        }

        public string Secretkey { get; set; } = "adfklnjasdn2!#3joie2maksdmkMD#I@PD";
        public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256Signature;
        public int ExpireInterval { get; set; } = 3600;

        public IEnumerable<Claim> Claims
        {
            get
            {
                if (claims == null)
                {
                    claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                    claims.Add(new Claim(ClaimTypes.Email, user.Email));
                    claims.Add(new Claim("UserId", user.UserId));
                    foreach (var role in user.Roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }
                }

                return claims;
            }
        }
    }
}
