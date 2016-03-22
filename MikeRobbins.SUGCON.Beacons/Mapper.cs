using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MikeRobbins.SUGCON.Beacons.Website.Contracts;
using MikeRobbins.SUGCON.Beacons.Website.Models;
using MikeRobbins.SUGCON.Beacons.Website.Xdb;
using Sitecore.Analytics.Tracking;

namespace MikeRobbins.SUGCON.Beacons.Website
{
    public class Mapper : IMapper
    {
        private readonly IXdbFacetRepository _xdbFacetRepository;

        public Mapper(IXdbFacetRepository iXdbFacetRepository)
        {
            _xdbFacetRepository = iXdbFacetRepository;
        }

        public Person MapPerson(Contact contact)
        {
            Person person = new Person();

            _xdbFacetRepository.GetPersonalInfo(contact, ref person);

            person.Id = contact.Identifiers.Identifier;

            return person;
        }

    }
}