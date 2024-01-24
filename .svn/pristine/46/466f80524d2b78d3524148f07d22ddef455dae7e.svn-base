using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class RoleElementDao : AbstractManagedDao, IRoleElementDao
    {
        private const string QUERY_BY_ROLE_ELEMENTS_FOR_ROLE = "QueryRoleElementsByRole";
        private const string QUERY_ALL = "QueryRoleElements";
        private const string COUNT_ROLES_USING_ROLE_ELEMENT = "CountRolesUsingRoleElementInSite";

        private static RoleElement PopulateInstance(SqlDataReader reader, bool includeFunctionalArea)
        {
            RoleElement roleElement = new RoleElement(reader.Get<long>("Id"), reader.Get<string>("Name"));

            if (includeFunctionalArea)
            {
                string functionalArea = reader.Get<string>("FunctionalArea");
                roleElement.FunctionalArea = functionalArea;
            }

            return roleElement;
        }

        private static RoleElement PopulateInstanceIncludeFunctionalArea(SqlDataReader reader)
        {
            return PopulateInstance(reader, true);
        }

        private static RoleElement PopulateInstanceExcludeFunctionalArea(SqlDataReader reader)
        {
            return PopulateInstance(reader, false);
        }

        public List<RoleElement> QueryTemplate(Role role, bool includeFunctionalArea)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@RoleId",  role.IdValue);

            if (includeFunctionalArea)
            {
                return command.QueryForListResult<RoleElement>(PopulateInstanceIncludeFunctionalArea, QUERY_BY_ROLE_ELEMENTS_FOR_ROLE);                
            }
            return command.QueryForListResult<RoleElement>(PopulateInstanceExcludeFunctionalArea, QUERY_BY_ROLE_ELEMENTS_FOR_ROLE);
        }

        public List<RoleElement> QueryAll()
        {
            SqlCommand command = ManagedCommand;
            return command.QueryForListResult<RoleElement>(PopulateInstanceIncludeFunctionalArea, QUERY_ALL);
        }

        public bool IsSiteUsingRoleElement(Site site, RoleElement roleElement)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", site.IdValue);
            command.AddParameter("@RoleElementId", roleElement.IdValue);
            int count = command.GetCount(COUNT_ROLES_USING_ROLE_ELEMENT);
            return count > 0;
        }
    }
}