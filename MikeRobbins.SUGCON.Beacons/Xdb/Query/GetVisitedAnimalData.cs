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
        private readonly IXdbFacetRepository _xdbFacetRepository;
        private readonly IXdbContactRepository _xdbContactRepository;

        public GetVisitedAnimalData()
        {
            _xdbFacetRepository = new XdbFacetRepository();
            _xdbContactRepository = new XdbContactRepository(_xdbFacetRepository);
        }

        public override void Process(ReportProcessorArgs args)
        {
            var queryResultTable = CreateDataTable();

            var contact = _xdbContactRepository.LoadContactReadOnly(args.ReportParameters.ContactId);
            var facet = _xdbFacetRepository.GetFacet<IZooVisitFacet>(contact, "ZooVisit");

            foreach (var animal in facet.VisitedAnimals)
            {
                DataRow dataRow = queryResultTable.NewRow();
                dataRow["Id"] = animal.Id.Guid;
                dataRow["AnimalName"] = animal.AnimalName;
                dataRow["Date"] = animal.Date;

                queryResultTable.Rows.Add(dataRow);
            }

            args.QueryResult = queryResultTable;
        }

        private DataTable CreateDataTable()
        {
            var queryResultTable = new DataTable();

            queryResultTable.Columns.Add(new DataColumn("Id", typeof (Guid)));
            queryResultTable.Columns.Add(new DataColumn("AnimalName", typeof (string)));
            queryResultTable.Columns.Add(new DataColumn("Date", typeof (DateTime)));
            return queryResultTable;
        }
    }
}