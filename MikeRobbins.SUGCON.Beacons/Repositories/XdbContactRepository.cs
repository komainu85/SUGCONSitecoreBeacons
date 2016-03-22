using System;
using MikeRobbins.SUGCON.Beacons.Website.Contracts;
using MikeRobbins.SUGCON.Beacons.Website.Models;
using Sitecore.Analytics.Data;
using Sitecore.Analytics.DataAccess;
using Sitecore.Analytics.Model;
using Sitecore.Analytics.Tracking;
using Sitecore.Configuration;
using Sitecore.Data;

namespace MikeRobbins.SUGCON.Beacons.Website.Repositories
{
    public class XdbContactRepository : IXdbContactRepository
    {
        private readonly ContactRepository _contactRepository;
        private readonly IXdbFacetRepository _xdbFacetRepository;

        public XdbContactRepository(IXdbFacetRepository xdbFacetRepository)
        {
            _contactRepository = Factory.CreateObject("tracking/contactRepository", true) as ContactRepository;
            _xdbFacetRepository = xdbFacetRepository;
        }

        public Contact CreateContact(Person person)
        {
            var contact = _contactRepository.CreateContact(ID.NewID);
            contact.Identifiers.Identifier = person.Email;

            _xdbFacetRepository.UpdatePersonalInfo(person, ref contact);

            SaveContact(contact);

            return contact;
        }

        private void SaveContact(Contact contact)
        {
            _contactRepository.SaveContact(contact, new ContactSaveOptions(true, new LeaseOwner("Person Respository", LeaseOwnerType.OutOfRequestWorker)));
        }

        public void UpdateContact(Contact contact, Person person)
        {
            _xdbFacetRepository.UpdatePersonalInfo(person, ref contact);
            SaveContact(contact);
        }

        public Contact FindContact(string identifier, out LockAttemptStatus lockAttemptStatus)
        {
            Contact contact = null;

            var loadContact = _contactRepository.TryLoadContact(identifier,
                new LeaseOwner("XdbContactRepository", LeaseOwnerType.OutOfRequestWorker),
                TimeSpan.FromMilliseconds(1000));

            if (loadContact.Status == LockAttemptStatus.Success)
            {
                contact = loadContact.Object;
            }

            lockAttemptStatus = loadContact.Status;

            return contact;
        }
    }
}