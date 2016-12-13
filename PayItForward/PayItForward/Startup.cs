using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PayItForward.Startup))]
namespace PayItForward
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
