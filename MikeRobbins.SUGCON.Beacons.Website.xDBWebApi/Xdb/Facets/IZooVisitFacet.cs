using MikeRobbins.SUGCON.Beacons.Website.xDBWebApi.Xdb.Elements;
using Sitecore.Analytics.Model.Framework;

namespace MikeRobbins.SUGCON.Beacons.Website.xDBWebApi.Xdb.Facets
{
    public interface IZooVisitFacet : IFacet
    {
        IElementCollection<IVisitedAnimalElement> VisitedAnimals { get; set; }
    }
}