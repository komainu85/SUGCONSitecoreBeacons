using MikeRobbins.SUGCON.Beacons.Website.xDB.Contracts;
using MikeRobbins.SUGCON.Beacons.Website.xDB.Repositories;
using MikeRobbins.SUGCON.Beacons.Website.xDBWebApi;
using MikeRobbins.SUGCON.Beacons.Website.xDBWebApi.Contracts;
using MikeRobbins.SUGCON.Beacons.Website.xDBWebApi.Models;
using MikeRobbins.SUGCON.Beacons.Website.xDBWebApi.Repositories;
using Sitecore.Services.Core;

namespace MikeRobbins.SUGCON.Beacons.Website.IoC
{
    public class Registry : StructureMap.Registry
    {
        public Registry()
        {
            For<IXdbContactRepository>().Use<XdbContactRepository>();
            For<IXdbFacetRepository>().Use<XdbFacetRepository>();
            For<IMapper>().Use<Mapper>();
            For(typeof(IRepository<Person>)).Use(typeof(PersonRepository));
        }
    }
}