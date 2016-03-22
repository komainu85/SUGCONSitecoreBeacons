using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Services.Core.Model;

namespace MikeRobbins.SUGCON.Beacons.Website.Models
{
    public class Person : EntityIdentity
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }
    }
}
