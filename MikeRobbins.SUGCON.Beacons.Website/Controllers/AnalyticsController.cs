using System;
using System.Web;
using MikeRobbins.SUGCON.Beacons.Website.xDB.Contracts;
using MikeRobbins.SUGCON.Beacons.Website.xDBWebApi.Xdb.Elements;
using MikeRobbins.SUGCON.Beacons.Website.xDBWebApi.Xdb.Facets;
using Sitecore.Analytics;
using Sitecore.Analytics.Configuration;
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

            if (CampaignCode == null) return;
            if (CampaignCode != _animalVisit) return;

            CreateAnimalFacet();
        }

        private void CreateAnimalFacet()
        {
            //Refactor this
            var facet = _xdbFacetRepository.GetFacet<IZooVisitFacet>(Tracker.Current.Contact, "ZooVisit");

            var visitedAnimalElement = facet.VisitedAnimals.Create();

            visitedAnimalElement.Id = Sitecore.Context.Item.ID;
            visitedAnimalElement.AnimalName = Sitecore.Context.Item["Title"];
            visitedAnimalElement.Date = DateTime.Now;

        }
    }
}