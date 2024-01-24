using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class LogDefinitionDao : AbstractManagedDao, ILogDefinitionDao
    {
        private const string QUERY_ALL_STORED_PROCEDURE = "QueryAllLogDefinitions";
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryLogDefinitionByID";
        private const string QUERY_BY_SCHEDULE_ID_STORED_PROCEDURE = "QueryLogDefinitionByScheduleId";
        private const string INSERT_STORED_PROCEDURE = "InsertLogDefinition";
        private const string UPDATE_STORED_PROCEDURE = "UpdateLogDefinition";
        private const string REMOVE_STORED_PROCEDURE = "RemoveLogDefinition";
        private const string INSERT_LOG_DEFINITION_CUSTOM_FIELD_GROUP = "InsertLogDefinitionCustomFieldGroup";

        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly ILogDefinitionFunctionalLocationDao logDefinitionFunctionalLocationDao;
        private readonly IUserDao userDao;
        private readonly IScheduleDao scheduleDao;
        private readonly IDocumentLinkDao documentLinkDao;        
        private readonly IWorkAssignmentDao workAssignmentDao;
        private readonly ILogDefinitionCustomFieldEntryDao customFieldEntryDao;
        private readonly ICustomFieldDao customFieldDao;
        private readonly IRoleDao roleDao;

        public LogDefinitionDao()
        {
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            logDefinitionFunctionalLocationDao = DaoRegistry.GetDao<ILogDefinitionFunctionalLocationDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
            scheduleDao = DaoRegistry.GetDao<IScheduleDao>();
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();            
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
            customFieldEntryDao = DaoRegistry.GetDao<ILogDefinitionCustomFieldEntryDao>();
            customFieldDao = DaoRegistry.GetDao<ICustomFieldDao>();
            roleDao = DaoRegistry.GetDao<IRoleDao>();
        }

        public List<LogDefinition> QueryAllForScheduling()
        {
            return ManagedCommand.QueryForListResult<LogDefinition>(PopulateInstance, QUERY_ALL_STORED_PROCEDURE);
        }

        public LogDefinition QueryById(long id)
        {
            return ManagedCommand.QueryById<LogDefinition>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public LogDefinition QueryByScheduleId(long scheduleId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ScheduleId", scheduleId);
            return command.QueryForSingleResult<LogDefinition>(PopulateInstance, QUERY_BY_SCHEDULE_ID_STORED_PROCEDURE);
        }

        public void Remove(LogDefinition logDefinition)
        {
            ManagedCommand.ExecuteNonQuery(logDefinition, REMOVE_STORED_PROCEDURE, AddRemoveParameters);
        }

        public void Update(LogDefinition logDefinition)
        {
            SqlCommand command = ManagedCommand;
            if (logDefinition.Schedule.Id.HasValue)
            {
                scheduleDao.Update(logDefinition.Schedule);
            }
            else
            {
                throw new AttemptedToUpdateObjectWithoutIdException(logDefinition, typeof(ISchedule));
            }
            command.Update(logDefinition, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            //RemoveDeletedDocumentLinks(logDefinition);
            InsertNewDocumentLinks(logDefinition);
            RemoveDeletedDocumentLinks(logDefinition);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            UpdateCustomFieldEntries(logDefinition);
        }

        private void UpdateCustomFieldEntries(LogDefinition logDefinition)
        {
            foreach (CustomFieldEntry entry in logDefinition.CustomFieldEntries)
            {
                if (entry.IsInDatabase())
                {
                    customFieldEntryDao.Update(entry);
                }
                else
                {
                    customFieldEntryDao.Insert(entry, logDefinition.IdValue);
                }
            }

            customFieldEntryDao.DeleteThoseNoLongerAssociatedToEntity(logDefinition.IdValue, logDefinition.CustomFieldEntries);
        }
       
        public LogDefinition Insert(LogDefinition logDefinition)
        {
            SqlCommand command = ManagedCommand;
            scheduleDao.Insert(logDefinition.Schedule);
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(logDefinition, AddInsertParameters, INSERT_STORED_PROCEDURE);
            logDefinition.Id = long.Parse(idParameter.Value.ToString());

            InsertNewDocumentLinks(logDefinition);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            RemoveDeletedDocumentLinks(logDefinition);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017

            InsertFunctionalLocations(logDefinition);

            if (!logDefinition.CustomFields.IsEmpty())
            {
                InsertCustomFieldEntries(logDefinition);
                InsertCustomFieldGroupRelationships(logDefinition, logDefinition.CustomFields.ConvertAll(field => field.GroupId.Value).Unique());
            }
            return logDefinition;
        }

        private void InsertCustomFieldEntries(LogDefinition logDefinition)
        {
            logDefinition.CustomFieldEntries.ForEach(entry => customFieldEntryDao.Insert(entry, logDefinition.IdValue));
        }

        private void InsertCustomFieldGroupRelationships(LogDefinition logDefinition, List<long> customFieldGroupIds)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = INSERT_LOG_DEFINITION_CUSTOM_FIELD_GROUP;
            command.AddParameter("@LogDefinitionId", logDefinition.IdValue);
            command.AddParameter("@CsvCustomFieldGroupIds", customFieldGroupIds.BuildCommaSeparatedList());
            command.ExecuteNonQuery();
        }
        
        private void InsertFunctionalLocations(LogDefinition logDefinition)
        {
            foreach (FunctionalLocation floc in logDefinition.FunctionalLocations)
            {
                logDefinitionFunctionalLocationDao.Insert(new LogDefinitionFunctionalLocation(logDefinition.IdValue, floc.IdValue));
            }
        }

        private void RemoveDeletedDocumentLinks(IDocumentLinksObject logDefinition)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(logDefinition, 
                                                                       documentLinkDao.QueryByLogDefinitionId);
        }
        
        private void InsertNewDocumentLinks(IDocumentLinksObject logDefinition)
        {
            documentLinkDao.InsertNewDocumentLinks(logDefinition,
                                                                       documentLinkDao.InsertForAssociatedLogDefinition);
        }

        private static void AddInsertParameters(LogDefinition logDefinition, SqlCommand command)
        {
            command.AddParameter("@CreatedBy", logDefinition.CreatedBy.Id);

            if (logDefinition.WorkAssignment != null)
            {
                command.AddParameter("@WorkAssignmentId", logDefinition.WorkAssignment.Id);
            }

            command.AddParameter("@CreateALogForEachFunctionalLocation", logDefinition.CreateALogForEachFunctionalLocation);
            command.AddParameter("@IsOperatingEngineerLog", logDefinition.IsOperatingEngineerLog);

            SetCommonAttributes(logDefinition, command);
        }

        private static void AddUpdateParameters(LogDefinition logDefinition, SqlCommand command)
        {
            command.AddParameter("@Id", logDefinition.Id);
            SetCommonAttributes(logDefinition, command);
        }

        private static void AddRemoveParameters(LogDefinition logDefinition, SqlCommand command)
        {
            command.AddParameter("@Id", logDefinition.Id);
            command.AddParameter("@LastModifiedUserId", logDefinition.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", logDefinition.LastModifiedDate);
        }

        private static void SetCommonAttributes(LogDefinition logDefinition, SqlCommand command)
        {
            command.AddParameter("@ScheduleId", logDefinition.Schedule.Id);
            command.AddParameter("@CreatedDateTime", logDefinition.CreatedDateTime);
            command.AddParameter("@InspectionFollowUp", logDefinition.InspectionFollowUp);
            command.AddParameter("@ProcessControlFollowUp", logDefinition.ProcessControlFollowUp);
            command.AddParameter("@OperationsFollowUp", logDefinition.OperationsFollowUp);
            command.AddParameter("@SupervisionFollowUp", logDefinition.SupervisionFollowUp);
            command.AddParameter("@EHSFollowUp", logDefinition.EnvironmentalHealthSafetyFollowUp);
            command.AddParameter("@OtherFollowUp", logDefinition.OtherFollowUp);
            command.AddParameter("@CreatedByRoleId", logDefinition.CreatedByRole.Id);
            command.AddParameter("@LastModifiedUserID", logDefinition.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", logDefinition.LastModifiedDate);            
            command.AddParameter("@LogType", logDefinition.LogType);
            command.AddParameter("@RtfComments", logDefinition.RtfComments);
            command.AddParameter("@PlainTextComments", logDefinition.PlainTextComments);           
            command.AddParameter("@Active", logDefinition.Active);           
        }

        private LogDefinition PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            ISchedule schedule = scheduleDao.QueryById(reader.Get<long>("ScheduleId"));
            bool environmentalHealthSafetyFollowUp = reader.Get<bool>("EHSFollowup");
            bool inspectionFollowUp = reader.Get<bool>("InspectionFollowUp");
            bool operationsFollowUp = reader.Get<bool>("OperationsFollowUp");
            bool processControlFollowUp = reader.Get<bool>("ProcessControlFollowUp");
            bool supervisionFollowUp = reader.Get<bool>("SupervisionFollowUp");
            bool otherFollowUp = reader.Get<bool>("OtherFollowUp");

            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            List<FunctionalLocation> functionalLocations = functionalLocationDao.QueryByLogDefinitionId(id);

            User createdBy = userDao.QueryById(reader.Get<long>("CreatedBy"));
            bool isOperatingEngineerLog = reader.Get<bool>("IsOperatingEngineerLog");
            Role createdByRole = roleDao.QueryById(reader.Get<long>("CreatedByRoleId"));

            User lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedUserId"));
            DateTime lastModifiedDate = reader.Get<DateTime>("LastModifiedDateTime");
            bool deleted = reader.Get<bool>("Deleted");

            List<DocumentLink> documentLinks = documentLinkDao.QueryByLogDefinitionId(id);

            string comments = reader.Get<string>("RtfComments");
            string commentsAsPlainText = reader.Get<string>("PlainTextComments");

            byte type = reader.Get<byte>("LogType");
            LogType logType = type.ToEnum<LogType>();

            WorkAssignment workAssignment = null;
            long? workAssignmentId = reader.Get<long?>("WorkAssignmentId");
            if (workAssignmentId.HasValue)
            {
                workAssignment = workAssignmentDao.QueryById(workAssignmentId.Value);
            }

            bool createALogForEachFunctionalLocation = reader.Get<bool>("CreateALogForEachFunctionalLocation");

            List<CustomFieldEntry> customFieldEntries = customFieldEntryDao.QueryByLogDefinitionId(id);
            List<CustomField> customFields = customFieldDao.QueryByCustomFieldGroupsForLogDefinitions(id);

            bool active = reader.Get<bool>("active");

            LogDefinition result
                = new LogDefinition(schedule,
                                    functionalLocations,
                                    inspectionFollowUp,
                                    processControlFollowUp,
                                    operationsFollowUp,
                                    supervisionFollowUp,
                                    environmentalHealthSafetyFollowUp,
                                    otherFollowUp,
                                    isOperatingEngineerLog,
                                    createdByRole,
                                    createdDateTime,
                                    createdBy,
                                    lastModifiedBy,
                                    lastModifiedDate,
                                    documentLinks,
                                    comments,
                                    commentsAsPlainText,
                                    logType,
                                    workAssignment,
                                    createALogForEachFunctionalLocation,
                                    customFieldEntries,
                                    customFields,
                                    active) { Id = id, Deleted = deleted };

            return result;
        }
    }
}