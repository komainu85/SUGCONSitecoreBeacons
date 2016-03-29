using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Sitecore.Analytics.Reporting;
using Sitecore.Cintel.Reporting;
using Sitecore.Cintel.Reporting.Processors;
using Sitecore.Cintel.Reporting.ReportingServerDatasource;

namespace MikeRobbins.SUGCON.Beacons.Website.Cms
{
    public class GetVisitedAnimalData : ReportProcessorBase
    {
        public override void Process(ReportProcessorArgs args)
        {

            DataTable queryResultTable = new DataTable();

            var contact = _contactRepository.LoadContactReadOnly(args.ReportParameters.ContactId);

            IKeyInteractionsRepository keyInteractionsRepository = new KeyInteractionsRepository();

            var sampleOrders = keyInteractionsRepository.GetSampleOrders(contact);

            foreach (var sampleOrder in sampleOrders)
            {
                DataRow dataRow = queryResultTable.NewRow();
                dataRow["DecorId"] = sampleOrder.DecorId;
                dataRow["RangeId"] = sampleOrder.RangeId;
                queryResultTable.Rows.Add(dataRow);
            }

            args.QueryResult = queryResultTable;



            args.QueryResult = table;
        }
    }
}