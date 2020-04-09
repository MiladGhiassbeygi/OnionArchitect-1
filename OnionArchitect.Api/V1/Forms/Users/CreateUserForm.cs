

namespace OnionArchitect.Api.V1.Forms.Users
{
    public class CreateUserForm
    {       
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
