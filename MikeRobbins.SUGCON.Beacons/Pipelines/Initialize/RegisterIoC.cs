using MikeRobbins.SUGCON.Beacons.Website.IoC;
using Sitecore.Pipelines;
using StructureMap;
using System.Web.Http;

namespace MikeRobbins.SUGCON.Beacons.Website.Pipelines.Initialize
{
    public class RegisterIoC
    {
        public void Process(PipelineArgs args)
        {
            var servicesConfig = GlobalConfiguration.Configuration;

            var container = new Container(new IoC.Registry());
            servicesConfig.DependencyResolver = new StructureMapDependencyResolver(container);
        }
    }
}