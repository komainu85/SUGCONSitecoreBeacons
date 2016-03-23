using System;
using System.Data;
using Sitecore.Cintel.Reporting;
using Sitecore.Cintel.Reporting.Processors;

namespace MikeRobbins.SUGCON.Beacons.Website.Xdb.Query
{
    public class PopulateWithVisitedAnimalsData : ReportProcessorBase
    {
        public override void Process(ReportProcessorArgs args)
        {
            DataTable queryResult = args.QueryResult;
            DataTable resultTableForView = args.ResultTableForView;
            ProjectRawTableIntoResultTable(args, queryResult, resultTableForView);
        }

        private void ProjectRawTableIntoResultTable(ReportProcessorArgs args, DataTable rawTable, DataTable resultTable)
        {
            foreach (DataRow sourceRow in DataTableExtensions.AsEnumerable(rawTable))
            {
                DataRow dataRow = resultTable.NewRow();
                TryFillData<Guid>(dataRow, new ViewField<Guid>("Id"), sourceRow, "Id");
                TryFillData<string>(dataRow, new ViewField<string>("AnimalName"), sourceRow, "AnimalName");
           
                resultTable.Rows.Add(dataRow);
            }
        }
    }
}