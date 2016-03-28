using System;
using MikeRobbins.SUGCON.Beacons.Website.Models;
using Sitecore.Analytics.DataAccess;
using Sitecore.Analytics.Tracking;

namespace MikeRobbins.SUGCON.Beacons.Website.Contracts
{
    public interface IXdbContactRepository
    {
        Contact CreateContact(Person person);
        void UpdateContact(Contact contact, Person person);
        void GetContacts();
        Contact FindContact(string identifier, out LockAttemptStatus lockAttemptStatus);
        Contact FindContact(Guid id, out LockAttemptStatus lockAttemptStatus);
        Contact LoadContactReadOnly(Guid id);
        Contact LoadContactReadOnly(string identifier);
    }
}
