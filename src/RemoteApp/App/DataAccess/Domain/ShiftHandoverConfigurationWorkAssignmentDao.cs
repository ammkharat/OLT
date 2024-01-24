using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class ShiftHandoverConfigurationWorkAssignmentDao : AbstractManagedDao, IShiftHandoverConfigurationWorkAssignmentDao
    {
        private readonly IWorkAssignmentDao workAssignmentDao;
        private const string DELETE_BY_CONFIGURATION_ID = "DeleteShiftHandoverConfigurationWorkAssignmentByShiftHandoverConfigurationId";
        private const string INSERT = "InsertShiftHandoverConfigurationWorkAssignment";
        private const string QUERY_BY_CONFIGURATION_ID = "QueryShiftHandoverWorkAssignmentByShiftHandoverConfigurationId";

        public ShiftHandoverConfigurationWorkAssignmentDao()
        {
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
        }

        public ShiftHandoverConfigurationWorkAssignment Insert(
                ShiftHandoverConfigurationWorkAssignment shiftHandoverConfigurationWorkAssignment)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(shiftHandoverConfigurationWorkAssignment, AddInsertParameters, INSERT);
            return shiftHandoverConfigurationWorkAssignment;
        }

        private void AddInsertParameters(
            ShiftHandoverConfigurationWorkAssignment shiftHandoverConfigurationFunctionalLocation, SqlCommand command)
        {
            command.AddParameter("@ShiftHandoverConfigurationId",  shiftHandoverConfigurationFunctionalLocation.ShiftHandoverConfigurationId);
            command.AddParameter("@WorkAssignmentId",  shiftHandoverConfigurationFunctionalLocation.WorkAssignment.Id);
        }

        public List<ShiftHandoverConfigurationWorkAssignment> QueryByShiftHandoverConfigurationId(long shiftHandoverConfigurationId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ShiftHandoverConfigurationId",  shiftHandoverConfigurationId);
            return command.QueryForListResult<ShiftHandoverConfigurationWorkAssignment>(PopulateInstance , QUERY_BY_CONFIGURATION_ID);
        }

        public void DeleteByShiftHandoverConfigurationId(long? configurationId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ShiftHandoverConfigurationId",  configurationId);
            command.ExecuteNonQuery(DELETE_BY_CONFIGURATION_ID);
        }

        private ShiftHandoverConfigurationWorkAssignment PopulateInstance(SqlDataReader reader)
        {
            long workAssignmentId = reader.Get<long>("WorkAssignmentId");
            WorkAssignment workAssignment = workAssignmentDao.QueryById(workAssignmentId);

            long shiftHandoverConfigurationId = reader.Get<long>("ShiftHandoverConfigurationId");

            return new ShiftHandoverConfigurationWorkAssignment(shiftHandoverConfigurationId, workAssignment);
        }
    }
}
