using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAPIDispatcherClienteWeb.Startup))]
namespace WebAPIDispatcherClienteWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
