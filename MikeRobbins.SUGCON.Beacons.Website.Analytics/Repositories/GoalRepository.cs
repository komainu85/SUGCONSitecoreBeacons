using System;
using System.Linq;
using System.Web;
using MikeRobbins.SUGCON.Beacons.Website.Analytics.Models;
using Sitecore.Analytics;
using Sitecore.Analytics.Data;
using Sitecore.Services.Core;

namespace MikeRobbins.SUGCON.Beacons.Website.Analytics.Repositories
{
    public class GoalRepository : IRepository<Goal>
    {
        private readonly Guid _kiosk = new Guid("{EC85FBDA-5A9A-48CB-8DE5-73A3FA9C2935}");

        public void Add(Goal entity)
        {
            var pageEventId = Guid.Parse(entity.Id);

            var pageEventData = new PageEventData(entity.Name, pageEventId)
            {
                ItemId = new Guid(),
                DataKey = entity.Name,
                Data = "/ZooKiosk",
                Text = entity.GoalText
            };

            if (!Tracker.IsActive)
            {
                Tracker.StartTracking();
            }

            var currentInteraction = Tracker.Current.Session.CreateInteraction();

            currentInteraction.ChannelId = _kiosk;

            Tracker.Current.Session.Identify(entity.ContactUniqueIdentifier);

            var pageContext = currentInteraction.CreatePage();

            pageContext.Register(pageEventData);
        }

        public void Delete(Goal entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Goal entity)
        {
            return false;
        }

        public Goal FindById(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Goal> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Goal entity)
        {
            throw new NotImplementedException();
        }
    }
}