using MikeRobbins.SUGCON.Beacons.Website.Xdb.Elements;
using Sitecore.Analytics.Model.Framework;
using Sitecore.Data;

namespace MikeRobbins.SUGCON.Beacons.Website.Xdb.Facets
{
    public interface IZooVisitFacet : IFacet
    {
        IElementCollection<IVisitedAnimalElement> VisitedAnimals { get; set; }
    }
}