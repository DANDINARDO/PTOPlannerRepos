using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PTOPlanner.Web.Startup))]
namespace PTOPlanner.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
