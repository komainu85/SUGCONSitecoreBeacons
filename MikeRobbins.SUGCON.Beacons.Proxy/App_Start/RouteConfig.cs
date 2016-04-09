using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MikeRobbins.SUGCON.Beacons.Proxy
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

       

            routes.MapRoute(
                "Animal",
                "animal/{animalId}",
                new { controller = "Home", action = "Index" },
                new { animalId = @"\w+" }
             );
        }
    }
}
