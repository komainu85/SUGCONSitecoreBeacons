using System;
using System.Runtime.CompilerServices;
using Windows.Storage.Streams;
using Windows.Web.Http;


namespace MikeRobbins.SUGCON.Beacons.Kiosk.Data
{
    public class SitecoreApi
    {
        public async void Authenticate()
        {

            using (var client = new HttpClient())
            {
                var authDetails = BuildJsonAuthDetails();

                var authResult = await client.PostAsync(new Uri("https://SUGCON/sitecore/api/ssc/auth/login"), authDetails);

                authResult.EnsureSuccessStatusCode();

                string uniqueIdentifier = "test@test.com"; //Pass this in from UI

                var itemResult = await client.GetAsync(new Uri("https://sugcon/sitecore/api/ssc/MikeRobbins-SUGCON-Beacons-Website-Controllers/person/" + uniqueIdentifier));

                itemResult.EnsureSuccessStatusCode();

                var jsonContent = await itemResult.Content.ReadAsStringAsync() as dynamic;
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
