using System.Web.Mvc;
using MikeRobbins.SUGCON.Beacons.Website.IoC;
using StructureMap;

namespace MikeRobbins.SUGCON.Beacons.Website
{
    public class StructureMapResolver
    {
        public static void Initialize()
        {
            var container = new Container(new IoC.Registry());

            DependencyResolver.SetResolver(new SitecoreDependencyResolver(new StructureMapDependencyResolver(container)));
        }
    }
}