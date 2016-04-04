using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.WebHost;
using System.Web.Routing;
using System.Web.SessionState;
using Sitecore.Pipelines;

namespace MikeRobbins.SUGCON.Beacons.Website.Analytics.Pipelines.EntityService
{
    public class MakeEntityServiceSessionAware
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

    public class SessionRouteHandler : IRouteHandler
    {
        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
        {
            return new SessionControllerHandler(requestContext.RouteData);
        }
    }

    public class SessionControllerHandler : HttpControllerHandler, IRequiresSessionState
    {
        public SessionControllerHandler(RouteData routeData) : base(routeData)
        {
        }
    }
}