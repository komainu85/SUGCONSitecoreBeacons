using System;
using MikeRobbins.SUGCON.Beacons.Website.xDB.Models;
using Sitecore.Analytics.DataAccess;
using Sitecore.Analytics.Tracking;

namespace MikeRobbins.SUGCON.Beacons.Website.xDB.Contracts
{
    public interface IXdbContactRepository
    {
        Contact CreateContact(ContactModel contactModel);
        void UpdateContact(Contact contact, ContactModel contactModel);
        void GetContacts();
        Contact FindContact(string identifier, out LockAttemptStatus lockAttemptStatus);
        Contact FindContact(Guid id, out LockAttemptStatus lockAttemptStatus);
        Contact LoadContactReadOnly(Guid id);
        Contact LoadContactReadOnly(string identifier);
    }
}
