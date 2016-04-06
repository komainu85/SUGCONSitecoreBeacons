using System;
using Sitecore.Data;

namespace MikeRobbins.SUGCON.Beacons.Website.xDBWebApi.Models
{
    public class Animal
    {
        public ID Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string ImageUrl { get; set; }
    }
}