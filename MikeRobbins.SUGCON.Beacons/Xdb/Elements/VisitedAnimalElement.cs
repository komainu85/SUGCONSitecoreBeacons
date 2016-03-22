using Sitecore.Analytics.Model.Framework;
using Sitecore.Data;

namespace MikeRobbins.SUGCON.Beacons.Website.Xdb.Elements
{
    public class VisitedAnimalElement: Element, IVisitedAnimalElement
    {
        public string AnimalName { get; set; }
        public ID Id { get; set; }
    }
}