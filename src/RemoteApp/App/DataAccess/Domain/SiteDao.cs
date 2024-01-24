using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class SiteDao : AbstractManagedDao, ISiteDao
    {
        private const string QUERY_ALL_STORED_PROCEDURE = "QueryAllSites";
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QuerySiteById";
        private const string QUERY_BY_PLANT_ID_STORED_PROCEDURE = "QuerySiteByPlantId";
        private const string QUERY_BY_ACTIVE_DIRECTORY_KEY_STORED_PROCEDURE = "QuerySiteByActiveDirectoryKey";
        
        private readonly ITimeDao timeDao;
        private readonly IPlantDao plantDao;
        

        public SiteDao()
        {
            timeDao = DaoRegistry.GetDao<ITimeDao>();
            plantDao = DaoRegistry.GetDao<IPlantDao>();
        }
       
        public List<Site> QueryAll()
        {
            return ManagedCommand.QueryForListResult<Site>(PopulateInstance , QUERY_ALL_STORED_PROCEDURE);
        }

        public Site QueryById(long id)
        {
            return ManagedCommand.QueryById<Site>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public Site QueryByPlantId(string plantId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@PlantId", plantId);
            return command.QueryForSingleResult<Site>(PopulateInstance, QUERY_BY_PLANT_ID_STORED_PROCEDURE);
        }

        public Site QueryByActiveDirectoryKey(string siteKey)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ActiveDirectoryKey", siteKey);
            return command.QueryForSingleResult<Site>(PopulateInstance, QUERY_BY_ACTIVE_DIRECTORY_KEY_STORED_PROCEDURE);
        }

        private Site PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string name = reader.Get<string>("Name");
            OltTimeZoneInfo timeZone = timeDao.GetOltTimeZoneInfo((reader.Get<string>("TimeZone")));
            List<Plant> plants = plantDao.QueryBySiteId(id);
            string activeDirectoryKey = reader.Get<string>("ActiveDirectoryKey");

            return new Site(id, name, timeZone, plants, activeDirectoryKey);
        }
    }
}