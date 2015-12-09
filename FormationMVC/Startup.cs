using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FormationMVC.Startup))]
namespace FormationMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
