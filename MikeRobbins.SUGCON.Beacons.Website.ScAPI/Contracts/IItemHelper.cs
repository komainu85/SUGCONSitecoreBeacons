using Sitecore.Data;

namespace MikeRobbins.SUGCON.Beacons.Website.ScAPI.Contracts
{
    public interface IItemHelper
    {
        string GetFieldText(ID id, string fieldName);
        Database GetMasterDatabase();
    }
}