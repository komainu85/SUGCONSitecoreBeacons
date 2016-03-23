using System;
using MikeRobbins.SUGCON.Beacons.Website.Xdb.Elements;
using Sitecore.Analytics.Model.Framework;

namespace MikeRobbins.SUGCON.Beacons.Website.Xdb.Facets
{
    [Serializable]
    public class ZooVisitFacet : Facet, IZooVisitFacet
    {
        public const string VisitedAnimalsName = "VisitedAnimals";

        public IElementCollection<IVisitedAnimalElement> VisitedAnimals
        {
            get { return GetCollection<IVisitedAnimalElement>(VisitedAnimalsName); }
            set { SetAttribute(VisitedAnimalsName, value); }
        }

        public ZooVisitFacet()
        {
            EnsureCollection<IVisitedAnimalElement>(VisitedAnimalsName);
        }
    }
}