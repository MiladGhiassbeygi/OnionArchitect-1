using Framework.Web.Settings;
using Infra.Authentication.Identity.Settings;
using Infra.Authentication.Jwt.Settings;


namespace Infra.Common.Bootstrapper.StartupSettings
{
    public class Settings
    {
        public ConnectionStringsSettings ConnectionStrings { get; set; }
        public ApiVersioningSettings ApiVertioning { get; set; }
        public SwaggerSettings Swagger { get; set; }
        public JwtSettings Jwt { get; set; }
        public IdentitySettings Identity { get; set; }
    }
}
