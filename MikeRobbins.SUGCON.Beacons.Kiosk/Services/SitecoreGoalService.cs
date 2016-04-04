using System;
using Windows.Devices.Sensors;
using Windows.Storage.Streams;
using Windows.Web.Http;
using Windows.Web.Http.Filters;
using MikeRobbins.SUGCON.Beacons.Kiosk.Data;
using MikeRobbins.SUGCON.Beacons.Kiosk.Services.Base;

namespace MikeRobbins.SUGCON.Beacons.Kiosk.Services
{
    public class SitecoreGoalService : SitecoreServiceBase
    {
        private readonly HttpCookie _authCookie;

        public SitecoreGoalService(HttpCookie authCookie)
        {
            _authCookie = authCookie;
        }

        public async void RegisterGoal(Goal goal, string userUniqueIdentifier, string goalText)
        {
            var filter = new HttpBaseProtocolFilter();

            filter.CookieManager.SetCookie(_authCookie);

            using (var client = new HttpClient(filter))
            {
                var goalJson = BuildJsonGoal(goal, userUniqueIdentifier, goalText);

                var itemResult = await client.PostAsync(new Uri(BaseUrl + "/MikeRobbins-SUGCON-Beacons-Website-Analytics-Controllers/Goal/"), goalJson);

                itemResult.EnsureSuccessStatusCode();
            }
        }

        private IHttpContent BuildJsonGoal(Goal goal, string userUniqueIdentifier, string goalText)
        {
            var goalName = GetGoalName(goal);
            var goalId = GetGoalId(goal);

            IHttpContent content = new HttpStringContent(
                    "{ \"Id\": \"" + goalId +
                    "\" , \"Name\": \"" + goalName +
                    "\" , \"ContactUniqueIdentifier\": \"" + userUniqueIdentifier +
                    "\" , \"GoalText\": \"" + goalText + "\"",
                    UnicodeEncoding.Utf8,
                    "application/json");

            return content;
        }

        private static string GetGoalName(Goal goal)
        {
            var goalName = string.Empty;
            switch (goal)
            {
                case Goal.SponsorAnimal:
                    goalName = "Sponsor Animal";
                    break;
                case Goal.BuyToy:
                    goalName = "Buy Toy";
                    break;
            }

            return goalName;
        }

        private static string GetGoalId(Goal goal)
        {
            var goalId = string.Empty;
            switch (goal)
            {
                case Goal.SponsorAnimal:
                    goalId = "{94FD9EB7-1AB8-462F-A330-A784274071FB}";
                    break;
                case Goal.BuyToy:
                    goalId = "{1904F50A-8FDA-4E5E-B7EF-3916DEAADC84}";
                    break;
            }

            return goalId;
        }
    }
}
