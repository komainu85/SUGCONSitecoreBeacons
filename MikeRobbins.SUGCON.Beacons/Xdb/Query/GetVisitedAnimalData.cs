using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MikeRobbins.SUGCON.Beacons.Website.Contracts;
using MikeRobbins.SUGCON.Beacons.Website.Repositories;
using MikeRobbins.SUGCON.Beacons.Website.Xdb.Facets;
using Sitecore.Analytics.DataAccess;
using Sitecore.Analytics.Reporting;
using Sitecore.Cintel.Reporting;
using Sitecore.Cintel.Reporting.Processors;
using Sitecore.Cintel.Reporting.ReportingServerDatasource;

namespace MikeRobbins.SUGCON.Beacons.Website.Xdb.Query
{
    public class GetVisitedAnimalData : ReportProcessorBase
    {
        public override void Process(ReportProcessorArgs args)
        {
            DataTable queryResultTable = new DataTable();

            queryResultTable.Columns.Add(new DataColumn("Id", typeof (Guid)));
            queryResultTable.Columns.Add(new DataColumn("AnimalName", typeof(string)));

            var xdbFacetRepository = new XdbFacetRepository();
            var xdbContactRepository = new XdbContactRepository(xdbFacetRepository);


            var contact = xdbContactRepository.LoadContactReadOnly(args.ReportParameters.ContactId);

            var facet = xdbFacetRepository.GetFacet<IZooVisitFacet>(contact, "ZooVisit");

            foreach (var animal in facet.VisitedAnimals)
            {
                DataRow dataRow = queryResultTable.NewRow();
                dataRow["Id"] = animal.Id.Guid;
                dataRow["AnimalName"] = animal.AnimalName;
                queryResultTable.Rows.Add(dataRow);
            }

            args.QueryResult = queryResultTable;

        }
    }
}