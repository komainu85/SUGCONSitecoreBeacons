using MikeRobbins.SUGCON.Beacons.Website.Models;
using Sitecore.Analytics.DataAccess;
using Sitecore.Analytics.Tracking;

namespace MikeRobbins.SUGCON.Beacons.Website.Contracts
{
    public interface IXdbContactRepository
    {
        Contact CreateContact(Person person);
        void UpdateContact(Contact contact, Person person);
        Contact FindContact(string identifier, out LockAttemptStatus lockAttemptStatus);
    }
}
