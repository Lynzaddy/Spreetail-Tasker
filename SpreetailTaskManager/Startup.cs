using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpreetailTaskManager.Startup))]
namespace SpreetailTaskManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
