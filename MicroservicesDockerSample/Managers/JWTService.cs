using MicroservicesDockerSample.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MicroservicesDockerSample.Managers
{
    public class JWTService : IAuthService
    {
        public string SecretKey { get; set; }

        public JWTService(string secretKey)
        {
            SecretKey = secretKey;
        }

        public string GenerateToken(IAuthContainerModel model)
        {
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "petro.com",
                Audience = "petro.com",
                Subject = new ClaimsIdentity(model.Claims),
                Expires = DateTime.UtcNow.AddSeconds(model.ExpireInterval),
                SigningCredentials = new SigningCredentials(GetSymmetricSecurityKey(), model.SecurityAlgorithm),
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            string token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return token;
        }

        public IEnumerable<Claim> GetTokenClaims(string token)
        {
            TokenValidationParameters tokenValidationParameters = GetTokenValidationParameters();
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            try
            {
                ClaimsPrincipal tokenValid = jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
                return tokenValid.Claims;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsTokenValid(string token)
        {
            if(string.IsNullOrEmpty(token))
            {
                throw new ArgumentException("Given token is null or empty");
            }

            TokenValidationParameters validationParameters = GetTokenValidationParameters();

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            try
            {
                ClaimsPrincipal tokenValid = jwtSecurityTokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = GetSymmetricSecurityKey()
            };
        }

        private SecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
        }
    }
}
