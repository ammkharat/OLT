using System;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class DeviationAlertDao : AbstractManagedDao, IDeviationAlertDao
    {
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryDeviationAlertById";
        private const string QUERY_LAST_RESPONDED = "QueryDeviationAlertByLastResponded";
        private const string INSERT_STORED_PROCEDURE = "InsertDeviationAlert";
        private const string UPDATE_RESPONSE_STORED_PROCEDURE = "UpdateDeviationAlertResponseOnly";
        private const string UPDATE_COMMENT = "UpdateDeviationAlertCommentField";


        private readonly ITagDao tagDao;
        private readonly IUserDao userDao;
        private readonly IRestrictionDefinitionDao restrictionDefinitionDao;
        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly IDeviationAlertResponseDao deviationAlertResponseDao;

        public DeviationAlertDao()
        {
            tagDao = DaoRegistry.GetDao<ITagDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
            restrictionDefinitionDao = DaoRegistry.GetDao<IRestrictionDefinitionDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            deviationAlertResponseDao = DaoRegistry.GetDao<IDeviationAlertResponseDao>();
        }

        public DeviationAlert QueryById(long id)
        {
            return ManagedCommand.QueryById < DeviationAlert>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public DeviationAlert Insert(DeviationAlert alert)
        {
            SqlCommand command = ManagedCommand;

            InsertDeviationAlertResponse(alert);

            long id = command.InsertAndReturnId(alert, AddInsertParameters, INSERT_STORED_PROCEDURE);
            alert.Id = id;
            return alert;
        }

        public void UpdateDeviationAlertResponse(DeviationAlert deviationAlert)
        {
            SqlCommand command = ManagedCommand;

            if (deviationAlert.DeviationAlertResponse.IsInDatabase())
            {
                deviationAlertResponseDao.UpdateResponseCodeAssignments(deviationAlert.DeviationAlertResponse);                                
            }
            else
            {
                DeviationAlertResponse insertedResponse = deviationAlertResponseDao.Insert(deviationAlert.DeviationAlertResponse);
                deviationAlert.DeviationAlertResponse = insertedResponse;                
                command.Update(deviationAlert, AddUpdateResponseParameter, UPDATE_RESPONSE_STORED_PROCEDURE);
            }
        }

        public void UpdateDeviationAlertComment(DeviationAlert alert)
        {
            SqlCommand command = ManagedCommand;
            command.Update(alert, AddUpdateCommentParameter, UPDATE_COMMENT);
        }

        private static void AddUpdateCommentParameter(DeviationAlert alert, SqlCommand command)
        {
            command.AddParameter("@Id", alert.Id);
            command.AddParameter("@Comments", alert.Comments);
        }

        public DeviationAlert GetLastRespondedToAlert(RestrictionDefinition restrictionDefinition)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@RestrictionDefinitionId",  restrictionDefinition.Id);
            return command.QueryForSingleResult < DeviationAlert>(PopulateInstance, QUERY_LAST_RESPONDED);                        
        }

        private static void AddUpdateResponseParameter(DeviationAlert alert, SqlCommand command)
        {
            command.AddParameter("@Id", alert.Id);
            command.AddParameter("@ResponseId", alert.DeviationAlertResponse.Id);
        }

        private void InsertDeviationAlertResponse(DeviationAlert deviationAlert)
        {
            DeviationAlertResponse deviationAlertResponse = deviationAlert.DeviationAlertResponse;

            if(deviationAlertResponse != null)
            {                
                deviationAlertResponseDao.Insert(deviationAlertResponse);                                    
            }
        }

        private static void AddInsertParameters(DeviationAlert alert, SqlCommand command)
        {
            SetCommonAttributes(alert, command);
        }

        private static void SetCommonAttributes(DeviationAlert alert, SqlCommand command)
        {
            command.AddParameter("@RestrictionDefinitionID", alert.RestrictionDefinition.Id);
            command.AddParameter("@RestrictionDefinitionName", alert.RestrictionDefinitionName);
            command.AddParameter("@RestrictionDefinitionDescription", alert.RestrictionDefinitionDescription);
            command.AddParameter("@FunctionalLocationID", alert.FunctionalLocation.Id);
            command.AddParameter("@IsOnlyVisibleOnReports", alert.IsOnlyVisibleOnReports);
            command.AddParameter("@MeasurementValueTagId", alert.MeasurementTag.Id);

            if (alert.ProductionTargetTag != null)
            {
                command.AddParameter("@ProductionTargetValueTagId", alert.ProductionTargetTag.Id);
            }

            if (alert.DeviationAlertResponse != null)
            {
                command.AddParameter("@DeviationAlertResponseId", alert.DeviationAlertResponse.Id);
            }

            command.AddParameter("@Comments", alert.Comments);
            command.AddParameter("@MeasurementValue", alert.MeasurementValue);
            command.AddParameter("@ProductionTargetValue", alert.ProductionTargetValue);
            command.AddParameter("@StartDateTime", alert.StartDateTime);
            command.AddParameter("@EndDateTime", alert.EndDateTime);
            command.AddParameter("@LastModifiedUserId", alert.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", alert.LastModifiedDateTime);
            command.AddParameter("@CreatedDateTime", alert.CreatedDateTime);
        }

        private DeviationAlert PopulateInstance(SqlDataReader reader)
        {
            long? id = reader.Get<long?>("Id");

            RestrictionDefinition restrictionDefinition =
                restrictionDefinitionDao.QueryById(reader.Get<long>("RestrictionDefinitionId"));
            string restrictionDefinitionName = reader.Get<string>("RestrictionDefinitionName");
            string restrictionDefinitionDescription = reader.Get<string>("RestrictionDefinitionDescription");

            DeviationAlertResponse deviationAlertResponse = null;
            long? deviationAlertResponseId = reader.Get<long?>("DeviationAlertResponseId");            
            if (deviationAlertResponseId != null)
            {
                deviationAlertResponse = deviationAlertResponseDao.QueryById(deviationAlertResponseId.Value);
            }
            
            TagInfo measurementTag = tagDao.QueryById(reader.Get<long>("MeasurementValueTagId"));

            long? productionTargetTagId = reader.Get<long?>("ProductionTargetValueTagId");

            TagInfo productionTargetTag = productionTargetTagId.HasValue ? tagDao.QueryById(productionTargetTagId.Value) : null;

            int? productionTargetValue = reader.Get<int?>("ProductionTargetValue");
            int? measurementValue = reader.Get<int?>("MeasurementValue");

            DateTime startDateTime = reader.Get<DateTime>("StartDateTime");
            DateTime endDateTime = reader.Get<DateTime>("EndDateTime");

            FunctionalLocation floc = functionalLocationDao.QueryById(reader.Get<long>("FunctionalLocationId"));

            string comments = reader.Get<string>("Comments");

            User lastModifiedUser = userDao.QueryById(reader.Get<long>("LastModifiedUserId"));
            DateTime lastModifiedDate = reader.Get<DateTime>("LastModifiedDateTime");
            DateTime createdDate = reader.Get<DateTime>("createdDateTime");

            DeviationAlert newAlert = new DeviationAlert(
                restrictionDefinition, restrictionDefinitionName, restrictionDefinitionDescription, deviationAlertResponse, productionTargetTag, measurementTag, productionTargetValue, 
                    measurementValue, startDateTime, endDateTime, floc, lastModifiedUser, lastModifiedDate, createdDate);

            newAlert.Id = id;
            newAlert.Comments = comments;
            //Added by Mukesh for RITM0219490
            newAlert.ToleranceValue = reader.Get<int>("ToleranceValue");
            return newAlert;
        }
    }
}
