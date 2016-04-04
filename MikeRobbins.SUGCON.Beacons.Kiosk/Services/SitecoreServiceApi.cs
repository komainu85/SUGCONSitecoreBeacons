using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Web.Http;
using Windows.Web.Http.Filters;
using MikeRobbins.SUGCON.Beacons.Kiosk.Data;
using MikeRobbins.SUGCON.Beacons.Kiosk.Entities;

namespace MikeRobbins.SUGCON.Beacons.Kiosk.Services
{
    public class SitecoreServiceApi: SitecoreServiceBase
    {
        public async Task<HttpCookie> Authenticate()
        {
            var filter = new HttpBaseProtocolFilter();

            using (var client = new HttpClient(filter))
            {
                var authDetails = BuildJsonAuthDetails();

                var authResult = await client.PostAsync(new Uri(BaseUrl + "/auth/login"), authDetails);

                authResult.EnsureSuccessStatusCode();

                return filter.CookieManager.GetCookies(new Uri(BaseUrl + "/auth/login")).FirstOrDefault(x => x.Name == ".ASPXAUTH");
            }
        }

        public async Task<Person> GetUserDetails(HttpCookie authCookie, string userUniqueIdentifier)
        {
            var filter = new HttpBaseProtocolFilter();

            filter.CookieManager.SetCookie(authCookie);

            using (var client = new HttpClient(filter))
            {
                var itemResult = await client.GetAsync(new Uri(BaseUrl + "/MikeRobbins-SUGCON-Beacons-Website-xDBWebApi-Controllers/person/" + userUniqueIdentifier));

                itemResult.EnsureSuccessStatusCode();

                var result = await itemResult.Content.ReadAsStringAsync();

                return _modelBuilder.CreatePersonViewModel(result);
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
