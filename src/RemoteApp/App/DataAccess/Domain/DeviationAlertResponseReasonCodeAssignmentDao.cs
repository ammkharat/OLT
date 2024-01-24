using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class DeviationAlertResponseReasonCodeAssignmentDao : AbstractManagedDao, IDeviationAlertResponseReasonCodeAssignmentDao
    {
        private const string QUERY_BY_RESPONSE_ID = "QueryDeviationAlertResponseReasonCodeAssignmentByResponseId";
        private const string INSERT_STORED_PROCEDURE = "InsertDeviationAlertResponseReasonCodeAssignment";

        private readonly IUserDao userDao;
        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly IRestrictionReasonCodeDao restrictionReasonCodeDao;
        private readonly IRestrictionLocationItemDao restrictionLocationItemDao;

        public DeviationAlertResponseReasonCodeAssignmentDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            restrictionReasonCodeDao = DaoRegistry.GetDao<IRestrictionReasonCodeDao>();
            restrictionLocationItemDao = DaoRegistry.GetDao<IRestrictionLocationItemDao>();
        }

        public List<DeviationAlertResponseReasonCodeAssignment> QueryByDeviationAlertResponseId(long responseId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ResponseId",  responseId);

            return command.QueryForListResult<DeviationAlertResponseReasonCodeAssignment>(PopulateInstance, QUERY_BY_RESPONSE_ID);
        }

        public DeviationAlertResponseReasonCodeAssignment Insert(
            DeviationAlertResponseReasonCodeAssignment assignment, long deviationAlertResponseId)
        {
            SqlCommand command = ManagedCommand;

            SqlParameter idParameter = command.AddIdOutputParameter();
            command.AddParameter("@DeviationAlertResponseId", deviationAlertResponseId);
            command.Insert(assignment, AddInsertParameters, INSERT_STORED_PROCEDURE);
            assignment.Id = (long?)idParameter.Value;
            return assignment;
        }

        private static void AddInsertParameters(DeviationAlertResponseReasonCodeAssignment alert, SqlCommand command)
        {
            if (alert.RestrictionLocationItem != null)
            {
                command.AddParameter("@RestrictionLocationItemId", alert.RestrictionLocationItem.Id);
            }
            command.AddParameter("@ReasonCodeFunctionalLocationId", alert.FunctionalLocation.Id);
            command.AddParameter("@RestrictionReasonCodeId", alert.RestrictionReasonCode.Id);
            command.AddParameter("@PlantState", alert.PlantState);
            command.AddParameter("@AssignedAmount", alert.AssignedAmount);
            command.AddParameter("@Comments", alert.Comments);

            command.AddParameter("@LastModifiedUserId", alert.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", alert.LastModifiedDateTime);
            command.AddParameter("@CreatedDateTime", alert.CreatedDateTime);
        }

        private DeviationAlertResponseReasonCodeAssignment PopulateInstance(SqlDataReader reader)
        {
            long? id = reader.Get<long?>("Id");

            FunctionalLocation floc = functionalLocationDao.QueryById(reader.Get<long>("ReasonCodeFunctionalLocationId"));
            RestrictionReasonCode code = restrictionReasonCodeDao.QueryById(reader.Get<long>("RestrictionReasonCodeId"));
            
            long? restrictionLocationItemId = reader.Get<long?>("RestrictionLocationItemId");
            RestrictionLocationItem item = null;
            if (restrictionLocationItemId.HasValue)
                item = restrictionLocationItemDao.QueryById(restrictionLocationItemId.Value);

            string plantState = reader.Get<string>("PlantState");
                       
            int assignedAmount = reader.Get<int>("AssignedAmount");
            string comments = reader.Get<string>("Comments");

            User lastModifiedUser = userDao.QueryById(reader.Get<long>("LastModifiedUserId"));
            DateTime lastModifiedDate = reader.Get<DateTime>("LastModifiedDateTime");
            DateTime createdDate = reader.Get<DateTime>("CreatedDateTime");

            DeviationAlertResponseReasonCodeAssignment assignment = 
                    new DeviationAlertResponseReasonCodeAssignment(item , floc, code, plantState, assignedAmount, comments, lastModifiedUser, lastModifiedDate, createdDate) {Id = id};

            return assignment;
        }
    }
}