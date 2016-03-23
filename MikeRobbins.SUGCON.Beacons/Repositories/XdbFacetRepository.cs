using MikeRobbins.SUGCON.Beacons.Website.Contracts;
using MikeRobbins.SUGCON.Beacons.Website.Models;
using MikeRobbins.SUGCON.Beacons.Website.Xdb.Elements;
using MikeRobbins.SUGCON.Beacons.Website.Xdb.Facets;
using Sitecore.Analytics.Model.Entities;
using Sitecore.Analytics.Model.Framework;
using Sitecore.Analytics.Tracking;

namespace MikeRobbins.SUGCON.Beacons.Website.Repositories
{
    public class XdbFacetRepository : IXdbFacetRepository
    {
        public T GetFacet<T>(Contact contact, string name) where T : class, IFacet
        {
            return contact.GetFacet<T>(name);
        }

        public void UpdateAnimalFacet(Contact contact, Animal animal)
        {
            var zooVisitFacet = GetFacet<IZooVisitFacet>(contact, "ZooVisit");

            var visitedAnimal = zooVisitFacet.VisitedAnimals.Create();

            visitedAnimal.AnimalName = animal.Name;
            visitedAnimal.Id = animal.Id;
        }

        public void UpdatePersonalInfo(Person person, ref Contact contact)
        {
            var facet = GetFacet<IContactPersonalInfo>(contact, "Personal");

            facet.FirstName = person.FirstName;
            facet.Surname = person.Surname;
        }

        public void GetPersonalInfo(Contact contact, ref Person person)
        {
            var facet = GetFacet<IContactPersonalInfo>(contact, "Personal");

            person.FirstName = facet.FirstName;
            person.Surname = facet.Surname;
        }

    }
}