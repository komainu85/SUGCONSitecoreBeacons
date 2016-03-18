using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;

namespace MikeRobbins.SUGCON.Beacons.Website.MVCHelpers
{
    public static class Image
    {
        public static string GetMediaUrl(this Sitecore.Mvc.Helpers.SitecoreHelper sitecoreHelper, string fieldName)
        {
            return GetMediaUrl(sitecoreHelper, fieldName, sitecoreHelper.CurrentItem);
        }

        public static string GetMediaUrl(this Sitecore.Mvc.Helpers.SitecoreHelper sitecoreHelper, string fieldName, Item item)
        {
            MediaItem mediaItem = item.Fields[fieldName].Item;
            return Sitecore.Resources.Media.MediaManager.GetMediaUrl(mediaItem);
        }
    }
}