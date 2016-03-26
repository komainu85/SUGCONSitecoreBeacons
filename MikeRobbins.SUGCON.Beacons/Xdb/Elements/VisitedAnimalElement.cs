using System;
using Sitecore.Analytics.Model.Framework;
using Sitecore.Data;

namespace MikeRobbins.SUGCON.Beacons.Website.Xdb.Elements
{
    public class VisitedAnimalElement: Element, IVisitedAnimalElement
    {
        public string AnimalName
        {
            get
            {
                return this.GetAttribute<string>("AnimalName");
            }
            set
            {
                this.SetAttribute<string>("AnimalName", value);
            }
        }

        public ID Id {
            get
            {
                return this.GetAttribute<ID>("Id");
            }
            set
            {
                this.SetAttribute<ID>("Id", value);
            }
        }

        public DateTime Date
        {
            get
            {
                return this.GetAttribute<DateTime>("Date");
            }
            set
            {
                this.SetAttribute<DateTime>("Date", value);
            }
        }

        public VisitedAnimalElement()
        {
            this.EnsureAttribute<string>("AnimalName");
            this.EnsureAttribute<ID>("Id");
            this.EnsureAttribute<DateTime>("Date");
        }
    }
}