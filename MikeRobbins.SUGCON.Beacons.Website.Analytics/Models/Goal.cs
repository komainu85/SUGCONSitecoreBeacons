using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Services.Core;
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