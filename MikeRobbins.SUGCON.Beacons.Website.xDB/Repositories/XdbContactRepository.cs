using System;
using MikeRobbins.SUGCON.Beacons.Website.xDB.Contracts;
using MikeRobbins.SUGCON.Beacons.Website.xDB.Models;
using Sitecore.Analytics.Data;
using Sitecore.Analytics.DataAccess;
using Sitecore.Analytics.Model;
using Sitecore.Analytics.Tracking;
using Sitecore.Configuration;
using Sitecore.Data;

namespace MikeRobbins.SUGCON.Beacons.Website.xDB.Repositories
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

        public Contact CreateContact(ContactModel contactModel)
        {
            var contact = _contactRepository.CreateContact(ID.NewID);
            contact.Identifiers.Identifier = contactModel.Email;

            _xdbFacetRepository.UpdatePersonalInfo(contactModel, ref contact);

            SaveContact(contact);

            return contact;
        }

        public void UpdateContact(Contact contact, ContactModel contactModel)
        {
            _xdbFacetRepository.UpdatePersonalInfo(contactModel, ref contact);
            SaveContact(contact);
        }

        public void GetContacts()
        {

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

        public Contact FindContact(Guid id, out LockAttemptStatus lockAttemptStatus)
        {
            Contact contact = null;

            var loadContact = _contactRepository.TryLoadContact(id,
                new LeaseOwner("XdbContactRepository", LeaseOwnerType.OutOfRequestWorker),
                TimeSpan.FromMilliseconds(1000));

            if (loadContact.Status == LockAttemptStatus.Success)
            {
                contact = loadContact.Object;
            }

            lockAttemptStatus = loadContact.Status;

            return contact;
        }

        public Contact LoadContactReadOnly(Guid id)
        {
            var contact = _contactRepository.LoadContactReadOnly(id);

            return contact;
        }

        public Contact LoadContactReadOnly(string identifier)
        {
            var contact = _contactRepository.LoadContactReadOnly(identifier);

            return contact;
        }

        private void SaveContact(Contact contact)
        {
            _contactRepository.SaveContact(contact, new ContactSaveOptions(true, new LeaseOwner("Person Respository", LeaseOwnerType.OutOfRequestWorker)));
        }

    }
}