using MikeRobbins.SUGCON.Beacons.Kiosk.Data;

namespace MikeRobbins.SUGCON.Beacons.Kiosk.Services.Base
{
    public abstract class SitecoreServiceBase
    {
        protected const string BaseUrl = "https://SUGCON/sitecore/api/ssc";

        protected readonly ModelBuilder _modelBuilder = new ModelBuilder();
    }
}
