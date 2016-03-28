using MikeRobbins.SUGCON.Beacons.Website.Models;
using Sitecore.Services.Core;
using Sitecore.Services.Infrastructure.Sitecore.Services;

namespace MikeRobbins.SUGCON.Beacons.Website.Controllers
{
    [ServicesController]
    public class PersonController :EntityService<Person>
    {
        public PersonController(IRepository<Person> repository) : base(repository)
        {
        }
    }
}