using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Messenger_King_Courier.Startup))]
namespace Messenger_King_Courier
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
