using Sitecore.Analytics;
using Sitecore.Analytics.Model.Entities;
using Sitecore.Mvc.Controllers;

namespace MikeRobbins.SUGCON.Beacons.Website.Analytics.Controllers
{
    public class FlushSessionController : SitecoreController
    {
        public void FlushSession(string userName, string firstName, string surname)
        {
            Tracker.Current.Session.Identify(userName);

            var personalInfo = Tracker.Current.Contact.GetFacet<IContactPersonalInfo>("Personal");
            personalInfo.FirstName = firstName;
            personalInfo.Surname = surname;

            HttpContext?.Session?.Abandon();
        }
    }
}