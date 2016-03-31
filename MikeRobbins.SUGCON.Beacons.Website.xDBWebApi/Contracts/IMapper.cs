using MikeRobbins.SUGCON.Beacons.Website.xDB.Models;
using MikeRobbins.SUGCON.Beacons.Website.xDBWebApi.Models;
using Sitecore.Analytics.Tracking;

namespace MikeRobbins.SUGCON.Beacons.Website.xDBWebApi.Contracts
{
    public interface IMapper
    {
        Person MapContactToPerson(Contact contact);

        ContactModel MapPersonToContactModel(Person person);
    }
}
