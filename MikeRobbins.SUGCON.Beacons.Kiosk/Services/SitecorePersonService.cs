using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Web.Http;
using Windows.Web.Http.Filters;
using MikeRobbins.SUGCON.Beacons.Kiosk.Contracts;
using MikeRobbins.SUGCON.Beacons.Kiosk.Data;
using MikeRobbins.SUGCON.Beacons.Kiosk.Entities;
using MikeRobbins.SUGCON.Beacons.Kiosk.Services.Base;

namespace MikeRobbins.SUGCON.Beacons.Kiosk.Services
{
    public class SitecorePersonService : SitecoreServiceBase, ISitecorePersonService
    {
        private readonly HttpCookie _authCookie;

        public SitecorePersonService(HttpCookie authCookie)
        {
            _authCookie = authCookie;
        }

        public async Task<Person> GetUserDetailsAsync(string userUniqueIdentifier)
        {
            var filter = new HttpBaseProtocolFilter();

            filter.CookieManager.SetCookie(_authCookie);

            using (var client = new HttpClient(filter))
            {
                var itemResult = await client.GetAsync(new Uri(BaseUrl + "/MikeRobbins-SUGCON-Beacons-Website-xDBWebApi-Controllers/person/" + userUniqueIdentifier));

                itemResult.EnsureSuccessStatusCode();

                var result = await itemResult.Content.ReadAsStringAsync();

                return _modelBuilder.CreatePersonViewModel(result);
            }
        }
    }
}
