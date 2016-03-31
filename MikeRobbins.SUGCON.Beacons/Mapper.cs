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
using Sitecore.Data;
using Sitecore.Data.Items;

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
            var zooVisit = _xdbFacetRepository.GetFacet<IZooVisitFacet>(contact, "ZooVisit");

            return zooVisit.VisitedAnimals.Select(animal => new Animal
            {
                Date = animal.Date,
                Id = animal.Id,
                Name = animal.AnimalName,
                ImageUrl = GetImageUrl(animal.Id)
            });
        }

        private string GetImageUrl(ID id)
        {
            var item = Database.GetDatabase("master").GetItem(id);

            var imageField = (Sitecore.Data.Fields.ImageField)item.Fields["Image"];

            var mediaItem = (MediaItem)imageField.MediaItem;

           return "http://SUGCON/" + Sitecore.StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl(mediaItem));
        }
    }
}