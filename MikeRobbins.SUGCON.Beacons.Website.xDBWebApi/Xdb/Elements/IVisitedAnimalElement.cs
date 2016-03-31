using System;
using Sitecore.Analytics.Model.Framework;
using Sitecore.Data;

namespace MikeRobbins.SUGCON.Beacons.Website.xDBWebApi.Xdb.Elements
{
    public interface IVisitedAnimalElement : IElement
    {
        string AnimalName { get; set; }

        ID Id { get; set; }

        DateTime Date { get; set; }
    }
}
