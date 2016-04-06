using MikeRobbins.SUGCON.Beacons.Website.Analytics.Models;
using Sitecore.Services.Core;
using Sitecore.Services.Infrastructure.Sitecore.Services;

namespace MikeRobbins.SUGCON.Beacons.Website.Analytics.Controllers
{
    [ServicesController]
    public class GoalController: EntityService<Goal>
    {
        public GoalController(IRepository<Goal> repository) : base(repository)
        {
        }
    }
}