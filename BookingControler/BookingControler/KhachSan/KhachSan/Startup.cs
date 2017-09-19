using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KhachSan.Startup))]
namespace KhachSan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
