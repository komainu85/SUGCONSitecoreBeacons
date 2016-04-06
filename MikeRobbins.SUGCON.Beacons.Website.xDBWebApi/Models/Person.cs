using System.Collections.Generic;
using Sitecore.Services.Core.Model;

namespace MikeRobbins.SUGCON.Beacons.Website.xDBWebApi.Models
{
    public class Person : EntityIdentity
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public List<Animal> Animals { get; set; } = new List<Animal>();

    }
}
