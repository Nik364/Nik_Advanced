using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nik.Advanced.Mvc.Startup))]
namespace Nik.Advanced.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
