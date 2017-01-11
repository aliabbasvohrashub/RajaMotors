using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RajaMotors.Web.Startup))]
namespace RajaMotors.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
