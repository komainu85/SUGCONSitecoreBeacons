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
    public abstract class SitecoreServiceBase
    {
        private const string BaseUrl = "https://SUGCON/sitecore/api/ssc";

        private readonly ModelBuilder _modelBuilder = new ModelBuilder();
    }
}
