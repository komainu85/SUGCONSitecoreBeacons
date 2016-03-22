using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MikeRobbins.SUGCON.Beacons.Website.Contracts;
using MikeRobbins.SUGCON.Beacons.Website.Models;
using Sitecore.Analytics;
using Sitecore.Data;
using Sitecore.Mvc.Controllers;

namespace MikeRobbins.SUGCON.Beacons.Website.Controllers
{
    public class AnalyticsController : SitecoreController
    {
        private readonly IXdbFacetRepository _xdbFacetRepository;

        public AnalyticsController(IXdbFacetRepository xdbFacetRepository)
        {
            _xdbFacetRepository = xdbFacetRepository;
        }

        public void RegisterAnimalVisit()
        {
            var animalName = Sitecore.Context.Item["Title"];
            var animalId = Sitecore.Context.Item.ID;

            if (!Tracker.IsActive)
                Tracker.StartTracking();

            var animal = new Animal() { Id = animalId, Name = animalName };

            _xdbFacetRepository.UpdateAnimalFacet(Tracker.Current.Contact, animal);
        }
    }
}