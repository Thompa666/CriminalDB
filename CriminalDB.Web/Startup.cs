using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CriminalDB.Web.Startup))]
namespace CriminalDB.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            Bootstrapper.Initialise();
        }
    }
}
