using System.Web.Http;
using System.Web.Mvc;
using StructureMap;

namespace MikeRobbins.SUGCON.Beacons.Website
{
    public class IoCContainerSetup
    {
        public static void Initialize()
        {
            var container = new Container(new IoC.Registry());

            AddMvcResolver(container);
            AddWebApiResolver(container);
        }

        private static void AddMvcResolver(IContainer container)
        {
            DependencyResolver.SetResolver(new IoC.Mvc.ChainedDependencyResolver(new IoC.Mvc.StructureMapDependencyResolver(container)));
        }

        private static void AddWebApiResolver(IContainer container)
        {
            var webApiResolver = new IoC.WebApi.ChainedDependencyResolver(
                new IoC.WebApi.StructureMapDependencyResolver(container), 
                GlobalConfiguration.Configuration.DependencyResolver);

            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;
        }
    }
}