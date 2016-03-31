using MikeRobbins.SUGCON.Beacons.Website.xDB.Models;
using Sitecore.Analytics.Model.Framework;
using Sitecore.Analytics.Tracking;

namespace MikeRobbins.SUGCON.Beacons.Website.xDB.Contracts
{
    public interface IXdbFacetRepository
    {
        T GetFacet<T>(Contact contact, string name) where T : class, IFacet;
        void UpdatePersonalInfo(ContactModel contactModel, ref Contact contact);
        void GetPersonalInfo(Contact contact, ref ContactModel contactModel);
    }
}
