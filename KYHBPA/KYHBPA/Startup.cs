using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KYHBPA.Startup))]
namespace KYHBPA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
