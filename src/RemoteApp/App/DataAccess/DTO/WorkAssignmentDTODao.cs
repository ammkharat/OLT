using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class WorkAssignmentDTODao : AbstractManagedDao, IWorkAssignmentDTODao
    {
        private const string QUERY_BY_SITE_ID = "QueryWorkAssignmentDTOBySiteId";        

        public List<WorkAssignmentDTO> QueryBySiteId(long siteId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId",  siteId);
            return command.QueryForListResult<WorkAssignmentDTO>(PopulateInstance, QUERY_BY_SITE_ID);
        }

        private WorkAssignmentDTO PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string name = reader.Get<string>("Name");
            string description = reader.Get<string>("Description");
            string category = reader.Get<string>("Category");
            string roleName = reader.Get<string>("RoleName");
            string siteName = reader.Get<string>("SiteName");

            return new WorkAssignmentDTO(id, name, description, category, roleName, siteName);
        }
    }
}
