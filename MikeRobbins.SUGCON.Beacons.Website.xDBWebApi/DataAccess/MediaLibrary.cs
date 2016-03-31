using Sitecore.Data;
using Sitecore.Data.Items;

namespace MikeRobbins.SUGCON.Beacons.Website.xDBWebApi.DataAccess
{
    public class MediaLibrary
    {
        public string GetImageUrl(ID id)
        {
            var item = Database.GetDatabase("master").GetItem(id);

            var imageField = (Sitecore.Data.Fields.ImageField)item.Fields["Image"];

            var mediaItem = (MediaItem)imageField.MediaItem;

            return "http://SUGCON/" + Sitecore.StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl(mediaItem));
        }
    }
}