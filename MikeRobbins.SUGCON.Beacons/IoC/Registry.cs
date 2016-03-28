using MikeRobbins.SUGCON.Beacons.Website.Contracts;
using MikeRobbins.SUGCON.Beacons.Website.Models;
using MikeRobbins.SUGCON.Beacons.Website.Repositories;
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