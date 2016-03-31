using MikeRobbins.SUGCON.Beacons.Website.xDB.Models;
using MikeRobbins.SUGCON.Beacons.Website.xDBWebApi.Models;
using Sitecore.Services.Core;
using Sitecore.Services.Infrastructure.Sitecore.Services;

namespace MikeRobbins.SUGCON.Beacons.Website.xDBWebApi.Controllers
{
    [ServicesController]
    public class PersonController :EntityService<Person>
    {
        public PersonController(IRepository<Person> repository) : base(repository)
        {
        }
    }
}