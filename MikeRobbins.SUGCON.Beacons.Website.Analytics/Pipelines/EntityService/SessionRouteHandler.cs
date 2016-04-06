using System.Web;
using System.Web.Routing;

namespace MikeRobbins.SUGCON.Beacons.Website.Analytics.Pipelines.EntityService
{
    public class SessionRouteHandler : IRouteHandler
    {
        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
        {
            return new SessionControllerHandler(requestContext.RouteData);
        }
    }
}