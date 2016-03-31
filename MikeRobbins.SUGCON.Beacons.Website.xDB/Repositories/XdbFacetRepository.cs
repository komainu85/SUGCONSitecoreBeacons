using MikeRobbins.SUGCON.Beacons.Website.xDB.Contracts;
using MikeRobbins.SUGCON.Beacons.Website.xDB.Models;
using Sitecore.Analytics.Model.Entities;
using Sitecore.Analytics.Model.Framework;
using Sitecore.Analytics.Tracking;

namespace MikeRobbins.SUGCON.Beacons.Website.xDB.Repositories
{
    public class XdbFacetRepository : IXdbFacetRepository
    {
        public T GetFacet<T>(Contact contact, string name) where T : class, IFacet
        {
            return contact.GetFacet<T>(name);
        }

        public void UpdatePersonalInfo(ContactModel contactModel, ref Contact contact)
        {
            var facet = GetFacet<IContactPersonalInfo>(contact, "Personal");

            facet.FirstName = contactModel.FirstName;
            facet.Surname = contactModel.Surname;
        }

        public void GetPersonalInfo(Contact contact, ref ContactModel contactModel)
        {
            var facet = GetFacet<IContactPersonalInfo>(contact, "Personal");

            contactModel.FirstName = facet.FirstName;
            contactModel.Surname = facet.Surname;
        }

    }
}