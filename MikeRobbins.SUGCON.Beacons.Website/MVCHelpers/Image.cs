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
            var mediaField = (Sitecore.Data.Fields.ImageField)item.Fields[fieldName];

            return Sitecore.Resources.Media.MediaManager.GetMediaUrl(mediaField.MediaItem);
        }
    }
}