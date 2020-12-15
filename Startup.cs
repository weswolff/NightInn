using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NightInnV2.Startup))]
namespace NightInnV2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
