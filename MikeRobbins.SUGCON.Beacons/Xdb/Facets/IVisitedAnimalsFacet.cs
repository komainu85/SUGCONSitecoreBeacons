using MikeRobbins.SUGCON.Beacons.Website.Xdb.Elements;
using Sitecore.Analytics.Model.Framework;

namespace MikeRobbins.SUGCON.Beacons.Website.Xdb.Facets
{
    public interface IVisitedAnimalsFacet : IFacet
    {
        IElementCollection<IVisitedAnimalElement> VisitedAnimals { get; set; }
    }
}