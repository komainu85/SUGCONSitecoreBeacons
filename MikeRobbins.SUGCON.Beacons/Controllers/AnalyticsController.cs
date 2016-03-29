using System;
using MikeRobbins.SUGCON.Beacons.Website.Contracts;
using MikeRobbins.SUGCON.Beacons.Website.Models;
using Sitecore.Analytics;
using Sitecore.Analytics.Configuration;
using Sitecore.Configuration;
using Sitecore.Mvc.Controllers;

namespace MikeRobbins.SUGCON.Beacons.Website.Controllers
{
    public class AnalyticsController : SitecoreController
    {
        private readonly IXdbFacetRepository _xdbFacetRepository;

        private readonly Guid _animalVisit = new Guid("7C2CF41097C540F1B66D087DDDE62592");

        public Guid? CampaignCode
        {
            get
            {
                Guid camapignCode;

                if (Guid.TryParse(Request.QueryString[AnalyticsSettings.CampaignQueryStringKey], out camapignCode))
                {
                    return camapignCode;
                }

                return null;            
            }  
        } 

        public AnalyticsController(IXdbFacetRepository xdbFacetRepository)
        {
            _xdbFacetRepository = xdbFacetRepository;
        }

        public void RegisterAnimalVisit()
        {
            if (!Tracker.IsActive)
                Tracker.StartTracking();

            Tracker.Current.Session.CreateInteraction(HttpContext);

            if (CampaignCode == null) return;
            if (CampaignCode != _animalVisit) return;

            CreateAnimalFacet();
        }

        private void CreateAnimalFacet()
        {
            var animalName = Sitecore.Context.Item["Title"];
            var animalId = Sitecore.Context.Item.ID;

            var animal = new Animal() { Id = animalId, Name = animalName, Date = DateTime.Now };

            _xdbFacetRepository.UpdateAnimalFacet(Tracker.Current.Contact, animal);
        }
    }
}