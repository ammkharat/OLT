using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class ShiftHandoverConfigurationDTODao : AbstractManagedDao, IShiftHandoverConfigurationDTODao
    {
        private const string QUERY_BY_SITE = "QueryShiftHandoverConfigurationDTOBySite";

        private readonly IShiftHandoverConfigurationWorkAssignmentDao configurationWorkAssignmentDao;

        public ShiftHandoverConfigurationDTODao()
        {
            configurationWorkAssignmentDao = DaoRegistry.GetDao<IShiftHandoverConfigurationWorkAssignmentDao>();
        }

        public List<ShiftHandoverConfigurationDTO> QueryBySiteId(long siteId)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@SiteId",  siteId);

            return command.QueryForListResult<ShiftHandoverConfigurationDTO>(PopulateInstance, QUERY_BY_SITE);

        }

        private ShiftHandoverConfigurationDTO PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            string name = reader.Get<string>("Name");

            List<ShiftHandoverConfigurationWorkAssignment> configurationFlocs = configurationWorkAssignmentDao.QueryByShiftHandoverConfigurationId(id);
                        
            List<WorkAssignment> workAssignments = configurationFlocs.ConvertAll(obj => obj.WorkAssignment);

            string assignmentList = workAssignments.BuildNameStringFromWorkAssignmentList();

            ShiftHandoverConfigurationDTO configuration = new ShiftHandoverConfigurationDTO(id, assignmentList, name);
            return configuration;
        }
    }
}
