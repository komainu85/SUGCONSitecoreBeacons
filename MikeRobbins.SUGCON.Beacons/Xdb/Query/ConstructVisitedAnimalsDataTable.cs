using System.Data;
using Sitecore.Cintel.Reporting;
using Sitecore.Cintel.Reporting.Processors;

namespace MikeRobbins.SUGCON.Beacons.Website.Xdb.Query
{
    public class ConstructVisitedAnimalsDataTable : ReportProcessorBase
    {
        public override void Process(ReportProcessorArgs args)
        {
            args.ResultTableForView = new DataTable();
            var viewField = new ViewField<string>("Id");
            var firstName = new ViewField<string>("FirstName");
            args.ResultTableForView.Columns.Add(viewField.ToColumn());
            args.ResultTableForView.Columns.Add(firstName.ToColumn());
        }
    }
}