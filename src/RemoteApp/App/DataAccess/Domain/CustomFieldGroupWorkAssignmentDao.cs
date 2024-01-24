using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class CustomFieldGroupWorkAssignmentDao : AbstractManagedDao, ICustomFieldGroupWorkAssignmentDao
    {
        private const string QUERY_BY_GROUP_ID_STORED_PROCEDURE = "QueryCustomFieldGroupWorkAssignmentByGroupId";
        private const string INSERT_STORED_PROCEDURE = "InsertCustomFieldGroupWorkAssignment";

        private readonly IWorkAssignmentDao workAssignmentDao;

        public CustomFieldGroupWorkAssignmentDao()
        {
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
        }

        public List<CustomFieldGroupWorkAssignment> QueryByGroupId(long customFieldGroupId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CustomFieldGroupId",  customFieldGroupId);
            return command.QueryForListResult < CustomFieldGroupWorkAssignment>(PopulateInstance, QUERY_BY_GROUP_ID_STORED_PROCEDURE);
        }

        public CustomFieldGroupWorkAssignment Insert(
            long customFieldGroupId, CustomFieldGroupWorkAssignment groupWorkAssignment)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CustomFieldGroupId", customFieldGroupId);
            command.Insert(groupWorkAssignment, AddInsertParameters, INSERT_STORED_PROCEDURE);
            return groupWorkAssignment;
        }

        private static void AddInsertParameters(CustomFieldGroupWorkAssignment groupWorkAssignment, SqlCommand command)
        {
            command.AddParameter("@WorkAssignmentId", groupWorkAssignment.WorkAssignment.Id);
        }

        private CustomFieldGroupWorkAssignment PopulateInstance(SqlDataReader reader)
        {
            return new CustomFieldGroupWorkAssignment(workAssignmentDao.QueryById(reader.Get<long>("WorkAssignmentId")));
        }
    }
}
