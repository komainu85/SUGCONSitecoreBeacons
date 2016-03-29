using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.Storage.Streams;
using Windows.Web.Http;
using Windows.Web.Http.Filters;


namespace MikeRobbins.SUGCON.Beacons.Kiosk.Data
{
    public class SitecoreApi
    {
        public HttpCookie Authenticate()
        {
            var filter = new HttpBaseProtocolFilter();

            using (var client = new HttpClient(filter))
            {
                var authDetails = BuildJsonAuthDetails();

                var authResult = client.PostAsync(new Uri("https://SUGCON/sitecore/api/ssc/auth/login"), authDetails).GetResults();

                authResult.EnsureSuccessStatusCode();

                return filter.CookieManager.GetCookies(new Uri("https://SUGCON/sitecore/api/ssc/auth/login")).FirstOrDefault(x => x.Name == ".ASPXAUTH");
            }
        }

        public dynamic GetUserDetails(HttpCookie authCookie, string userUniqueIdentifier)
        {
            var filter = new HttpBaseProtocolFilter();

            filter.CookieManager.SetCookie(authCookie);

            using (var client = new HttpClient(filter))
            {
                var itemResult = client.GetAsync(new Uri("https://sugcon/sitecore/api/ssc/MikeRobbins-SUGCON-Beacons-Website-Controllers/person/" + userUniqueIdentifier)).GetResults();

                itemResult.EnsureSuccessStatusCode();

                return itemResult.Content.ReadAsStringAsync();

            }
        }

        private IHttpContent BuildJsonAuthDetails()
        {
            IHttpContent content = new HttpStringContent(
                    "{ \"domain\": \"" + "sitecore" +
                    "\" , \"username\": \"admin" +
                    " \", \"password\": \"b\"}",
                    UnicodeEncoding.Utf8,
                    "application/json");

            return content;
        }
    }
}
