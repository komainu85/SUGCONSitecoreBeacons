using Sitecore.Data;

namespace MikeRobbins.SUGCON.Beacons.Website.ScAPI.Contracts
{
    public interface IMediaLibraryHelper
    {
        string GetImageUrl(string hostname, ID itemId);
    }
}