using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class RoleDisplayConfigurationDao : AbstractManagedDao, IRoleDisplayConfigurationDao
    {
        private const string QUERY_BY_SITE_AND_ROLE_STORED_PROCEDURE = "QueryRoleDisplayConfigurationBySiteAndRole";
        private const string DELETE_BY_SITE_STORED_PROCEDURE = "DeleteRoleDisplayConfigurationBySite";
        private const string INSERT_STORED_PROCEDURE = "InsertRoleDisplayConfiguration";

        private readonly IRoleDao roleDao;

        public RoleDisplayConfigurationDao()
        {
            roleDao = DaoRegistry.GetDao<IRoleDao>();
        }

        public List<RoleDisplayConfiguration> QueryBySiteAndRole(Site site, Role role)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@SiteId", site.IdValue);
            command.AddParameter("@RoleId", role.IdValue);
            return command.QueryForListResult<RoleDisplayConfiguration>(PopulateInstance, QUERY_BY_SITE_AND_ROLE_STORED_PROCEDURE);
        }

        public List<RoleDisplayConfiguration> QueryBySite(Site site)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@SiteId", site.IdValue);
            command.AddParameter("@RoleId", null);
            return command.QueryForListResult<RoleDisplayConfiguration>(PopulateInstance, QUERY_BY_SITE_AND_ROLE_STORED_PROCEDURE);
        }

        private RoleDisplayConfiguration PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            Role role = roleDao.QueryById(reader.Get<long>("RoleId"));
            SectionKey sectionKey = SectionKey.GetById(reader.Get<int>("SectionId"));
            PageKey primaryPageKey = GetPageKey(reader, "PrimaryDefaultPageId");
            PageKey secondaryPageKey = GetPageKey(reader, "SecondaryDefaultPageId");

            RoleDisplayConfiguration definition = new RoleDisplayConfiguration(
                id,
                role,
                sectionKey,
                primaryPageKey,
                secondaryPageKey);

            return definition;
        }

        private static PageKey GetPageKey(SqlDataReader reader, string columnName)
        {
            PageKey pageKey = null;
            int? pageKeyId = reader.Get<int?>(columnName);
            if (pageKeyId.HasValue)
            {
                pageKey = PageKey.GetById(pageKeyId.Value);
            }
            return pageKey;
        }

        public void DeleteAllAndInsertNew(Site site, IList<RoleDisplayConfiguration> configurations)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", site.IdValue);
            command.ExecuteNonQuery(DELETE_BY_SITE_STORED_PROCEDURE);

            foreach (RoleDisplayConfiguration configuration in configurations)
            {
                if (configuration.PrimaryPageKey != null || configuration.SecondaryPageKey != null)
                {
                    command.Parameters.Clear();
                    SqlParameter idParameter = command.AddIdOutputParameter();
                    command.Insert(configuration, AddInsertParameters, INSERT_STORED_PROCEDURE);
                    configuration.Id = (long?)idParameter.Value;
                }
            }
        }

        private static void AddInsertParameters(RoleDisplayConfiguration configuration, SqlCommand command)
        {
            command.AddParameter("@RoleId", configuration.Role.IdValue);            
            command.AddParameter("@SectionId", configuration.SectionKey.Id);
            command.AddParameter("@PrimaryDefaultPageId", configuration.PrimaryPageKey.Id);
            if (configuration.SecondaryPageKey != null)
            {
                command.AddParameter("@SecondaryDefaultPageId", configuration.SecondaryPageKey.Id);
            }
        }
    }
}
