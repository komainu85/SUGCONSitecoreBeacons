using MikeRobbins.SUGCON.Beacons.Website.Models;
using Sitecore.Analytics.Tracking;

namespace MikeRobbins.SUGCON.Beacons.Website.Contracts
{
    public interface IMapper
    {
        Person MapPerson(Contact contact);
    }
}
