using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Sitecore.Cintel.Reporting;
using Sitecore.Cintel.Reporting.Processors;

namespace MikeRobbins.SUGCON.Beacons.Website.Cms
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