using MikeRobbins.SUGCON.Beacons.Website.ScAPI.Contracts;
using Sitecore.Data;

namespace MikeRobbins.SUGCON.Beacons.Website.ScAPI
{
    public class ItemHelper : IItemHelper
    {
        private const string MasterDatabaseName = "master";

        public Database GetMasterDatabase()
        {
            return Database.GetDatabase(MasterDatabaseName);
        }

        public string GetFieldText(ID id, string fieldName)
        {
            var item = GetMasterDatabase().GetItem(id);

            return item[fieldName];
        }
    }
}