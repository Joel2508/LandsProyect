using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LandProyect.Backend.Startup))]
namespace LandProyect.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
