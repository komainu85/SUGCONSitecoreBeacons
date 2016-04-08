using System.Collections.Generic;
using System.Linq;
using MikeRobbins.SUGCON.Beacons.Website.ScAPI.Contracts;
using MikeRobbins.SUGCON.Beacons.Website.xDB.Contracts;
using MikeRobbins.SUGCON.Beacons.Website.xDB.Models;
using MikeRobbins.SUGCON.Beacons.Website.xDBWebApi.Contracts;
using MikeRobbins.SUGCON.Beacons.Website.xDBWebApi.Models;
using MikeRobbins.SUGCON.Beacons.Website.xDBWebApi.Xdb.Facets;
using Sitecore.Analytics.Tracking;

namespace MikeRobbins.SUGCON.Beacons.Website.xDBWebApi
{
    public class Mapper : IMapper
    {
        private readonly IXdbFacetRepository _xdbFacetRepository;
        private readonly IMediaLibraryHelper _mediaLibraryHelper;
        private readonly IItemHelper _itemHelper;

        public Mapper(IXdbFacetRepository iXdbFacetRepository, IMediaLibraryHelper mediaLibraryHelper, IItemHelper itemHelper)
        {
            _xdbFacetRepository = iXdbFacetRepository;
            _mediaLibraryHelper = mediaLibraryHelper;
            _itemHelper = itemHelper;
        }

        public Person MapContactToPerson(Contact contact)
        {
            var contactModel = new ContactModel();

            _xdbFacetRepository.GetPersonalInfo(contact, ref contactModel);

            var person = MapContactModelToPerson(contactModel);

            person.Id = contact.Identifiers.Identifier;
            person.Animals.AddRange(GetVisitedAnimals(contact));

            return person;
        }

        public Person MapContactModelToPerson(ContactModel contactModel)
        {
            return new Person
            {
                Email = contactModel.Email,
                FirstName = contactModel.FirstName,
                Surname = contactModel.Surname
            };
        }

        public ContactModel MapPersonToContactModel(Person person)
        {
            return new ContactModel
            {
                Email = person.Email,
                FirstName = person.FirstName,
                Surname = person.Surname
            };
        }

        private IEnumerable<Animal> GetVisitedAnimals(Contact contact)
        {
            var zooVisit = _xdbFacetRepository.GetFacet<IZooVisitFacet>(contact, "ZooVisit");

            return zooVisit.VisitedAnimals.Select(animal => new Animal
            {
                Id = animal.Id,
                Name = animal.AnimalName,
                Date = animal.Date,

                Description = _itemHelper.GetFieldText(animal.Id, "Body"),
                ImageUrl = _mediaLibraryHelper.GetImageUrl("http://SUGCON/", animal.Id)
            });
        }
    }
}