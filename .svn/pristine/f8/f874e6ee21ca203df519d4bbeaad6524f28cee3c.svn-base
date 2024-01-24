using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class PlantDao : AbstractManagedDao, IPlantDao
    {
        private const string QUERY_BY_ID = "QueryPlantById";
        private const string QUERY_BY_SITE_ID = "QueryPlantBySiteId";

        public List<Plant> QueryBySiteId(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@siteId", siteId);
            return command.QueryForListResult<Plant>(PopulateInstance, QUERY_BY_SITE_ID);
        }

        public Plant QueryById(long id)
        {
            return ManagedCommand.QueryById<Plant>(id, PopulateInstance, QUERY_BY_ID);
        }

        private Plant PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string name = reader.Get<string>("Name");
            long siteId = reader.Get<long>("SiteId");
            return new Plant(id, name, siteId);
        }
    }
}