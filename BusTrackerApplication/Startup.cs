using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BusTrackerApplication.Startup))]
namespace BusTrackerApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
