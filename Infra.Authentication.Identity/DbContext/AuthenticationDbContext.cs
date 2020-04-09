using Infra.Authentication.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Infra.Authentication.Identity.DbContext
{
    public class AuthenticationDbContext: IdentityDbContext<User, Role, int>
    {
        public AuthenticationDbContext(DbContextOptions options)
            : base(options)
        {

        }
    }


}
