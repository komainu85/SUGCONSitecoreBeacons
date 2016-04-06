using System;
using System.Linq;
using MikeRobbins.SUGCON.Beacons.Website.xDB.Contracts;
using MikeRobbins.SUGCON.Beacons.Website.xDBWebApi.Contracts;
using MikeRobbins.SUGCON.Beacons.Website.xDBWebApi.Models;
using Sitecore.Analytics.DataAccess;
using Sitecore.Services.Core;

namespace MikeRobbins.SUGCON.Beacons.Website.xDBWebApi.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private readonly IXdbContactRepository _xdbContactRepository;
        private readonly IMapper _mapper;

        public PersonRepository(IXdbContactRepository xdbContactRepository, IMapper mapper)
        {
            _xdbContactRepository = xdbContactRepository;
            _mapper = mapper;
        }

        public IQueryable<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public Person FindById(string id)
        {
            Person person = null;

            var contact = _xdbContactRepository.LoadContactReadOnly(id);

            if (contact != null)
            {
                person = _mapper.MapContactToPerson(contact);
            }

            return person;
        }

        public void Add(Person entity)
        {
            LockAttemptStatus status;

            _xdbContactRepository.FindContact(entity.Id, out status);

            if (status == LockAttemptStatus.NotFound)
            {
                var contactModel = _mapper.MapPersonToContactModel(entity);

                _xdbContactRepository.CreateContact(contactModel);
            }
        }

        public bool Exists(Person entity)
        {
            return FindById(entity.Id) != null;
        }

        public void Update(Person entity)
        {
            LockAttemptStatus status;
            var contact = _xdbContactRepository.FindContact(entity.Id, out status);

            if (status == LockAttemptStatus.Success)
            {
                var contactModel = _mapper.MapPersonToContactModel(entity);

                _xdbContactRepository.UpdateContact(contact, contactModel);
            }
            else
            {
                throw new ArgumentException("Person could not be updated");
            }
        }

        public void Delete(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}