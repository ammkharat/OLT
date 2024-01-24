using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class CokerCardConfigurationWorkAssignmentDao : AbstractManagedDao, ICokerCardConfigurationWorkAssignmentDao
    {
        private const string QUERY_BY_CONFIGURATION_ID = "QueryCokerCardConfigurationWorkAssignmentByConfigurationId";
        private const string INSERT = "InsertCokerCardConfigurationWorkAssignment";
        private const string DELETE_BY_CONFIGURATION_ID = "DeleteCokerCardConfigurationWorkAssignmentByConfigurationId";

        private readonly IWorkAssignmentDao workAssignmentDao;

        public CokerCardConfigurationWorkAssignmentDao()
        {
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
        }

        public List<CokerCardConfigurationWorkAssignment> QueryByConfigurationId(long configurationId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CokerCardConfigurationId", (object) configurationId);
            return command.QueryForListResult < CokerCardConfigurationWorkAssignment>(PopulateInstance, QUERY_BY_CONFIGURATION_ID);
        }

        private CokerCardConfigurationWorkAssignment PopulateInstance(SqlDataReader reader)
        {
            long shiftHandoverConfigurationId = reader.Get<long>("CokerCardConfigurationId");
            long workAssignmentId = reader.Get<long>("WorkAssignmentId");
            WorkAssignment workAssignment = workAssignmentDao.QueryById(workAssignmentId);

            return new CokerCardConfigurationWorkAssignment(shiftHandoverConfigurationId, workAssignment);
        }

        public void Insert(CokerCardConfigurationWorkAssignment configurationWorkAssignment)
        {
            SqlCommand command = ManagedCommand;
            command.Insert(configurationWorkAssignment, AddInsertParameters, INSERT);
        }

        private static void AddInsertParameters(CokerCardConfigurationWorkAssignment configurationWorkAssignment, SqlCommand command)
        {
            command.AddParameter("@CokerCardConfigurationId", configurationWorkAssignment.CokerCardConfigurationId);
            command.AddParameter("@WorkAssignmentId", configurationWorkAssignment.WorkAssignment.IdValue);
        }

        public void DeleteByConfigurationId(long configurationId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CokerCardConfigurationId", (object) configurationId);
            command.ExecuteNonQuery(DELETE_BY_CONFIGURATION_ID);
        }
    }
}