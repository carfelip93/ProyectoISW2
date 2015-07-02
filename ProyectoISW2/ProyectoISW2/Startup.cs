using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoISW2.Startup))]
namespace ProyectoISW2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
