using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class SiteConfigurationDefaultsDao : AbstractManagedDao, ISiteConfigurationDefaultsDao
    {
        private const string QUERY_BY_SITE_ID_STORED_PROC = "QuerySiteConfigurationDefaultsBySiteId";

        public SiteConfigurationDefaults QueryBySiteId(long siteId)
        {
            return ManagedCommand.QueryById < SiteConfigurationDefaults>(siteId, PopulateInstance, QUERY_BY_SITE_ID_STORED_PROC);
        }

        private SiteConfigurationDefaults PopulateInstance(SqlDataReader reader)
        {
            long siteId = reader.Get<long>("SiteId");
            bool copyTargetAlertResponseToLog = reader.Get<bool>("copyTargetAlertResponseToLog");

            SiteConfigurationDefaults defaults = new SiteConfigurationDefaults(siteId, copyTargetAlertResponseToLog);
            return defaults;
        }
    }
}
