using MikeRobbins.SUGCON.Beacons.Website.Models;
using Sitecore.Analytics.Model.Framework;
using Sitecore.Analytics.Tracking;

namespace MikeRobbins.SUGCON.Beacons.Website.Contracts
{
    public interface IXdbFacetRepository
    {
        T GetFacet<T>(Contact contact, string name) where T : class, IFacet;
        void UpdateAnimalFacet(Contact contact, Animal animal);
        void UpdatePersonalInfo(Person person, ref Contact contact);
        void GetPersonalInfo(Contact contact, ref Person person);
    }
}
