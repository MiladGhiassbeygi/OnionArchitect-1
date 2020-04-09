using AutoMapper;
using Infra.Authentication.Identity.Models;
using OnionArchitect.Api.V1.Forms.Accounts;


namespace OnionArchitect.Api.V1.Mappings
{
    public class AccountProfile:Profile
    {
        public AccountProfile()
        {
            CreateMap<SignUpForm, User>();
            CreateMap<UpdateAccountForm, User>();
            
           
        }
    }
}
