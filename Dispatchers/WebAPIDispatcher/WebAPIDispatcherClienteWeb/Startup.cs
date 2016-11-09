using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiniAvatarClienteWeb.Startup))]
namespace MiniAvatarClienteWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
