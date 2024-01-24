using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class FunctionalLocationInfoDao : AbstractManagedDao, IFunctionalLocationInfoDao
    {
        private const string QUERY_DIVISIONS_BY_SITE_ID = "QueryFunctionalLocationInfosForDivisionsBySiteId";
        private const string QUERY_UNITS_BY_SITE_ID = "QueryFunctionalLocationInfosForUnitsBySiteId";
        private const string query_BY_PARENT_ID = "QueryFunctionalLocationInfosByParentId";

        public List<FunctionalLocationInfo> QueryFunctionalLocationDivisionInfosBySiteId(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            return
                command.QueryForListResult<FunctionalLocationInfo>(PopulateInstance, QUERY_DIVISIONS_BY_SITE_ID);
        }

        public List<FunctionalLocationInfo> QueryFunctionalLocationDivisionInfosBySiteIdForAdmin(long siteId)
        {
            return QueryFunctionalLocationDivisionInfosBySiteId(siteId);
        }

        public List<FunctionalLocationInfo> QueryFunctionalLocationInfosByParentFunctionalLocation(long functionalLocationId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ParentId", functionalLocationId);
            return
                command.QueryForListResult<FunctionalLocationInfo>(PopulateInstance, query_BY_PARENT_ID);
        }

        public List<FunctionalLocationInfo> QueryFunctionalLocationInfosByParentFunctionalLocationForAdmin(long functionalLocationId)
        {
            return QueryFunctionalLocationInfosByParentFunctionalLocation(functionalLocationId);
        }

        public List<FunctionalLocationInfo> QueryFunctionalLocationUnitInfosBySiteId(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            return
                command.QueryForListResult<FunctionalLocationInfo>(PopulateInstance, QUERY_UNITS_BY_SITE_ID);
        }

        public List<FunctionalLocationInfo> QueryFunctionalLocationUnitInfosBySiteIdForAdmin(long siteId)
        {
            return QueryFunctionalLocationDivisionInfosBySiteId(siteId);
        }

        private FunctionalLocationInfo PopulateInstance(SqlDataReader reader)
        {
            FunctionalLocation functionalLocation = FunctionalLocationDao.PopulateInstance(reader);

            bool hasChildren = (reader.Get<long>("NumChildren") > 0);

            return new FunctionalLocationInfo(functionalLocation, hasChildren);
        }
    }
}