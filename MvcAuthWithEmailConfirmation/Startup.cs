using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcAuthWithEmailConfirmation.Startup))]
namespace MvcAuthWithEmailConfirmation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
