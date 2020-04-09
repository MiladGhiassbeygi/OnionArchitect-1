using Infra.Authentication.Jwt.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace Infra.Authentication.Jwt.Contracts
{
    public interface ITokenFactory
    {
        public Token GenerateToken(IEnumerable<Claim> claims);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

    }
}
