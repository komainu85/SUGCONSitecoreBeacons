using MikeRobbins.SUGCON.Beacons.Website.ScAPI.Contracts;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace MikeRobbins.SUGCON.Beacons.Website.ScAPI
{
    public class MediaLibraryHelper : IMediaLibraryHelper
    {
        private readonly IItemHelper _itemHelper;

        public MediaLibraryHelper(IItemHelper itemHelper)
        {
            _itemHelper = itemHelper;
        }

        public string GetImageUrl(string hostname, ID itemId)
        {
            var imageUrl = string.Empty;

            var item = _itemHelper.GetMasterDatabase().GetItem(itemId);

            if (item != null)
            {
                var imageField = (Sitecore.Data.Fields.ImageField)item.Fields["Image"];

                var mediaItem = (MediaItem)imageField.MediaItem;

                imageUrl = hostname + Sitecore.StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl(mediaItem));
            }

            return imageUrl;
        }
    }
}