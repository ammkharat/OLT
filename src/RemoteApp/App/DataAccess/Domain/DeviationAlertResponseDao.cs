using System;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class DeviationAlertResponseDao : AbstractManagedDao, IDeviationAlertResponseDao
    {
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryDeviationAlertResponseById";
        private const string UPDATE_STORED_PROCEDURE = "UpdateDeviationAlertResponse";
        private const string INSERT_STORED_PROCEDURE = "InsertDeviationAlertResponse";

        private const string DELETE_REASON_CODE_ASSIGNMENTS_BY_RESPONSE_ID
            = "DeleteDeviationAlertResponseReasonCodeAssignmentsByResponseId";

        private readonly IDeviationAlertResponseReasonCodeAssignmentDao assignmentDao;
        private readonly IUserDao userDao;

        public DeviationAlertResponseDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            assignmentDao =
                DaoRegistry.GetDao<IDeviationAlertResponseReasonCodeAssignmentDao>();
        }

        public DeviationAlertResponse Insert(DeviationAlertResponse deviationAlertResponse)
        {
            var command = ManagedCommand;
            var idParameter = command.AddIdOutputParameter();

            command.Insert(deviationAlertResponse, AddInsertParameters, INSERT_STORED_PROCEDURE);
            deviationAlertResponse.Id = (long?) idParameter.Value;

            InsertResponseReasonCodeAssignments(deviationAlertResponse);

            return deviationAlertResponse;
        }

        public DeviationAlertResponse QueryById(long id)
        {
            return ManagedCommand.QueryById(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public void UpdateResponseCodeAssignments(DeviationAlertResponse deviationAlertResponse)
        {
            var command = ManagedCommand;

            command.Update(deviationAlertResponse, AddUpdateParameters, UPDATE_STORED_PROCEDURE);

            command.Parameters.Clear();
            command.AddParameter("@ResponseId", deviationAlertResponse.Id);
            command.ExecuteNonQuery(DELETE_REASON_CODE_ASSIGNMENTS_BY_RESPONSE_ID);
            InsertResponseReasonCodeAssignments(deviationAlertResponse);
        }

        private void InsertResponseReasonCodeAssignments(DeviationAlertResponse response)
        {
            var assignments = response.ReasonCodeAssignments;

            foreach (var assignment in assignments)
            {
                assignmentDao.Insert(assignment, response.IdValue);
            }
        }

        private static void AddInsertParameters(DeviationAlertResponse response, SqlCommand command)
        {
            command.AddParameter("@CreatedDateTime", response.CreatedDateTime);
            SetCommonAttributes(response, command);
        }

        private static void SetCommonAttributes(DeviationAlertResponse response, SqlCommand command)
        {
            command.AddParameter("@LastModifiedDateTime", response.LastModifiedDateTime);
            command.AddParameter("@LastModifiedUserId", response.LastModifiedBy.Id);
            command.AddParameter("@Comments", response.Comments);
        }

        private DeviationAlertResponse PopulateInstance(SqlDataReader reader)
        {
            var id = reader.Get<long>("Id");

            var lastModifiedUser = userDao.QueryById(reader.Get<long>("LastModifiedUserId"));
            var lastModifiedDate = reader.Get<DateTime>("LastModifiedDateTime");
            var createdDate = reader.Get<DateTime>("CreatedDateTime");
            var comments = reader.Get<string>("Comments");

            var assignments =
                assignmentDao.QueryByDeviationAlertResponseId(id);

            var response = new DeviationAlertResponse(comments, lastModifiedUser, lastModifiedDate, createdDate);
            response.ReasonCodeAssignments.AddRange(assignments);

            response.Id = id;

            return response;
        }

        private static void AddUpdateParameters(DeviationAlertResponse response, SqlCommand command)
        {
            command.AddParameter("@Id", response.Id);
            SetCommonAttributes(response, command);
        }
    }
}