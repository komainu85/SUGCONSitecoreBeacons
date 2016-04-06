using System.Web.Http.WebHost;
using System.Web.Routing;
using System.Web.SessionState;

namespace MikeRobbins.SUGCON.Beacons.Website.Analytics.Pipelines.EntityService
{
    public class SessionControllerHandler : HttpControllerHandler, IRequiresSessionState
    {
        public SessionControllerHandler(RouteData routeData) : base(routeData)
        {
        }
    }
}