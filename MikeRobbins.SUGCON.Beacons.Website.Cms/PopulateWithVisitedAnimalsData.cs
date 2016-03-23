using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Sitecore.Cintel.Reporting;
using Sitecore.Cintel.Reporting.Processors;

namespace MikeRobbins.SUGCON.Beacons.Website.Cms
{
    public class PopulateWithVisitedAnimalsData : ReportProcessorBase
    {
        public override void Process(ReportProcessorArgs args)
        {
            var result = args.QueryResult;
            var table = args.ResultTableForView;
            if (table.Columns.Contains("Id"))
            {
                foreach (DataRow row in result.AsEnumerable())
                {
                    var id = row["VisitedAnimals_Id"];
                    if (id == null || string.IsNullOrEmpty(id.ToString()))
                    {
                        continue;
                    }
                    var targetRow = table.NewRow();
                    targetRow["Id"] = id;
                    table.Rows.Add(targetRow);
                }
            }
            args.ResultSet.Data.Dataset[args.ReportParameters.ViewName] = table;
        }
    }
}