using Microsoft.Owin;
using Owin;
using PlayNow;

[assembly: OwinStartupAttribute(typeof(PlayNow.Startup))]
namespace PlayNow
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}

