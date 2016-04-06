using Sitecore.Services.Core.Model;

namespace MikeRobbins.SUGCON.Beacons.Website.Analytics.Models
{
    public class Goal : EntityIdentity
    {
        public string Name { get; set; }

        public string ContactUniqueIdentifier { get; set; }

        public string GoalText { get; set; }

    }
}