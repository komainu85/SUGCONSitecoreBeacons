using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MikeRobbins.SUGCON.Beacons.Website.Contracts;
using MikeRobbins.SUGCON.Beacons.Website.Models;
using MikeRobbins.SUGCON.Beacons.Website.Xdb;
using MikeRobbins.SUGCON.Beacons.Website.Xdb.Elements;
using MikeRobbins.SUGCON.Beacons.Website.Xdb.Facets;
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
            var person = new Person();

            _xdbFacetRepository.GetPersonalInfo(contact, ref person);

            person.Id = contact.Identifiers.Identifier;

            person.Animals.AddRange(GetVisitedAnimals(contact));

            return person;
        }

        private IEnumerable<Animal> GetVisitedAnimals(Contact contact)
        {
            var zooVisit = contact.GetFacet<IZooVisitFacet>("ZooVisit");

            return zooVisit.VisitedAnimals.Select(visitedAnimal => new Animal { Date = visitedAnimal.Date, Id = visitedAnimal.Id, Name = visitedAnimal.AnimalName});
        }
    }
}