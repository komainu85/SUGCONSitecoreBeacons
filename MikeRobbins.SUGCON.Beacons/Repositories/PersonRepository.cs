using System;
using System.Linq;
using MikeRobbins.SUGCON.Beacons.Website.Contracts;
using MikeRobbins.SUGCON.Beacons.Website.Models;
using Sitecore.Analytics.DataAccess;
using Sitecore.Services.Core;

namespace MikeRobbins.SUGCON.Beacons.Website.Repositories
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

            person = _mapper.MapPerson(contact);

            return person;
        }

        public void Add(Person entity)
        {
            LockAttemptStatus status;

            _xdbContactRepository.FindContact(entity.Id, out status);

            if (status == LockAttemptStatus.NotFound)
            {
                _xdbContactRepository.CreateContact(entity);
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
                _xdbContactRepository.UpdateContact(contact, entity);
            }
            else if (status == LockAttemptStatus.NotFound)
            {
                //Handle not found reporting
            }
            else
            {
                //Handle access errors
            }
        }

        public void Delete(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}