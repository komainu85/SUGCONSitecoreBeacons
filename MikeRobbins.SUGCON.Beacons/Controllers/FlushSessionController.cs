using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MikeRobbins.SUGCON.Beacons.Website.Contracts;
using MikeRobbins.SUGCON.Beacons.Website.Models;
using Sitecore.Analytics;
using Sitecore.Analytics.Model.Entities;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Mvc.Controllers;
using Sitecore.Web;

namespace MikeRobbins.SUGCON.Beacons.Website.Controllers
{
    public class FlushSessionController : SitecoreController
    {
        public void FlushSession(string userName, string firstName, string surname)
        {
            Tracker.Current.Session.Identify(userName);

            var personalInfo = Tracker.Current.Contact.GetFacet<IContactPersonalInfo>("Personal");
            personalInfo.FirstName = firstName;
            personalInfo.Surname = surname;

            Session.Abandon();
        }
    }
}