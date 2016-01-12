using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcRequireConfirmBeforeLogin.Startup))]
namespace MvcRequireConfirmBeforeLogin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
