using System.Web.Routing;
using Sitecore.Pipelines;

namespace MikeRobbins.SUGCON.Beacons.Website.Analytics.Pipelines.EntityService
{
    public class EntityServiceSession
    {
        public void Process(PipelineArgs args)
        {
            var route = RouteTable.Routes["EntityService"] as Route;

            if (route != null)
            {
                route.RouteHandler = new SessionRouteHandler();
            }
        }
    }
}