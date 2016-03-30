using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace MikeRobbins.SUGCON.Beacons.Website.Models
{
    public class Animal
    {
        public string Name { get; set; }

        public ID Id { get; set; }

        public DateTime Date { get; set; }

        public string ImageUrl { get; set; }
    }
}