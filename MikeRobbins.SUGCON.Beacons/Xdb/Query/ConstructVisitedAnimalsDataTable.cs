using System;
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
            args.ResultTableForView.Columns.Add(new ViewField<Guid>("Id").ToColumn());
            args.ResultTableForView.Columns.Add(new ViewField<string>("AnimalName").ToColumn());
        }
    }
}