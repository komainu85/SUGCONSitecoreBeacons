using System.ComponentModel.DataAnnotations;
using Sitecore.Services.Core.Model;

namespace MikeRobbins.SUGCON.Beacons.Website.Analytics.Models
{
    public class Goal : EntityIdentity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string ContactUniqueIdentifier { get; set; }

        [Required]
        public string GoalText { get; set; }
    }
}