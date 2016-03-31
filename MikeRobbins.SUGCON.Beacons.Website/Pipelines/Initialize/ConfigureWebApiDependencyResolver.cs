using System.Web.Http;
using MikeRobbins.SUGCON.Beacons.Website.IoC.WebApi;
using Sitecore.Pipelines;
using StructureMap;

namespace MikeRobbins.SUGCON.Beacons.Website.Pipelines.Initialize
{
    public class ConfigureWebApiDependencyResolver
    {
        public void Process(PipelineArgs args)
        {
            var container = new Container(new IoC.Registry());

            var webApiResolver = new ChainedDependencyResolver(
                                        new StructureMapDependencyResolver(container), 
                                        GlobalConfiguration.Configuration.DependencyResolver);

            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;
        }
    }
}