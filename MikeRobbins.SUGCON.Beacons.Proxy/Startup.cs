using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MikeRobbins.SUGCON.Beacons.Proxy.Startup))]
namespace MikeRobbins.SUGCON.Beacons.Proxy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
