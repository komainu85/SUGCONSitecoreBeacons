using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Web.Http;
using Windows.Web.Http.Filters;
using MikeRobbins.SUGCON.Beacons.Kiosk.Services.Base;

namespace MikeRobbins.SUGCON.Beacons.Kiosk.Services
{
    public class SitecoreAuthenticationService: SitecoreServiceBase
    {
        public async Task<HttpCookie> AuthenticateAsync()
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
