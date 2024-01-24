using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class LogDao : AbstractManagedDao, ILogDao
    {
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryLogByID";

        private const string INSERT_STORED_PROCEDURE = "InsertLog";
        private const string REMOVE_STORED_PROCEDURE = "RemoveLog";
        private const string UPDATE_STORED_PROCEDURE = "UpdateLog";
        private const string INSERT_LOG_ACTION_ITEM_ASSOCIATION = "InsertLogActionItemAssociation";
        private const string INSERT_LOG_ACTION_ITEM_DEFINITION_ASSOCIATION = "InsertLogActionItemDefinitionAssociation";
        private const string INSERT_LOG_WORK_PERMIT_EDMONTON_ASSOCIATION = "InsertLogWorkPermitEdmontonAssociation";
        private const string INSERT_LOG_WORK_PERMIT_LUBES_ASSOCIATION = "InsertLogWorkPermitLubesAssociation";
        private const string INSERT_LOG_WORK_PERMIT_MONTREAL_ASSOCIATION = "InsertLogWorkPermitMontrealAssociation";
        private const string INSERT_LOG_TARGET_ALERT_ASSOCIATION = "InsertLogTargetAlertAssociation";
        private const string COUNT_LOGS_ASSOCIATED_TO_ACTION_ITEM_STORED_PROCEDURE = "CountLogsAssociatedToActionItem";
        private const string COUNT_LOGS_ASSOCIATED_TO_ACTION_ITEM_DEFINITION_STORED_PROCEDURE = "CountLogsAssociatedToActionItemDefinition";
        private const string COUNT_LOGS_ASSOCIATED_TO_WORK_PERMIT_EDMONTON_STORED_PROCEDURE = "CountLogsAssociatedToWorkPermitEdmonton";
        private const string COUNT_LOGS_ASSOCIATED_TO_WORK_PERMIT_LUBES_STORED_PROCEDURE = "CountLogsAssociatedToWorkPermitLubes";
        private const string COUNT_LOGS_ASSOCIATED_TO_WORK_PERMIT_MONTREAL_STORED_PROCEDURE = "CountLogsAssociatedToWorkPermitMontreal";
        private const string COUNT_LOGS_ASSOCIATED_TO_TARGET_ALERT_STORED_PROCEDURE = "CountLogsAssociatedToTargetAlert";
        private const string QUERY_BY_LOG_DEFINITION_AND_DATE = "QueryLogForSameDay";
        private const string INSERT_OR_UPDATE_FUNCTIONAL_LOCATION_LIST = "InsertOrUpdateLogFunctionalLocationList";
        private const string INSERT_LOG_CUSTOM_FIELD_GROUP = "InsertLogCustomFieldGroups";
        private const string QUERY_IN_BATCHES = "QueryLogInBatches";
        private const string QUERY_COUNT = "CountLogs";

        private const string QUERY_COUNT_BY_FUNCTIONAL_LOCATION = "CountLogsByFunctionalLocationList";
        private const string QUERY_IN_BATCHES_BY_FUNCTIONAL_LOCATION = "QueryLogInBatchesByFunctionalLocationList";

        //RITM0301321 mangesh
        private const string COUNT_LOGS_ASSOCIATED_TO_WORK_PERMIT_MUDS_STORED_PROCEDURE = "CountLogsAssociatedToWorkPermitMuds";
        private const string INSERT_LOG_WORK_PERMIT_MUDS_ASSOCIATION = "InsertLogWorkPermitMudsAssociation";

        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly IUserDao userDao;
        private readonly IShiftPatternDao shiftPatternDao;
        private readonly ILogDefinitionDao logDefinitionDao;
        private readonly IDocumentLinkDao documentLinkDao;
        private readonly IWorkAssignmentDao workAssignmentDao;        
        private readonly ILogFunctionalLocationDao logFunctionalLocationDao;
        private readonly ILogCustomFieldEntryDao customFieldEntryDao;
        private readonly IRoleDao roleDao;
        private readonly ICustomFieldDao customFieldDao;
        private static readonly ILog logger = GenericLogManager.GetLogger<LogDao>();
        


        public LogDao()
        {
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
            shiftPatternDao = DaoRegistry.GetDao<IShiftPatternDao>();
            logDefinitionDao = DaoRegistry.GetDao<ILogDefinitionDao>();
            logFunctionalLocationDao = DaoRegistry.GetDao<ILogFunctionalLocationDao>();
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();            
            customFieldEntryDao = DaoRegistry.GetDao<ILogCustomFieldEntryDao>();
            customFieldDao = DaoRegistry.GetDao<ICustomFieldDao>();
            roleDao = DaoRegistry.GetDao<IRoleDao>();
        }

        public Log QueryById(long id)
        {
            //Mukesh for Log Image
            Log log = ManagedCommand.QueryById<Log>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
            SetLogImage(log);
            return log;
            //return ManagedCommand.QueryById<Log>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public List<Log> QueryLogsInBatches(long siteId, int batchNumber, int batchSize, LogType logType)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            command.AddParameter("@Limit", batchSize);
            command.AddParameter("@Offset", (batchNumber * batchSize) + 1);
            command.AddParameter("@LogType", logType);
            return command.QueryForListResult<Log>(PopulateInstance, QUERY_IN_BATCHES);
        }
        
        public int QueryCountOfLogs(long siteId, LogType logType)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            command.AddParameter("@LogType", logType);
            return command.GetCount(QUERY_COUNT);
        }

        public int QueryCountOfLogsByFunctionalLocation(long siteId, LogType logType, List<FunctionalLocation> flocs)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            command.AddParameter("@LogType", logType);
            command.AddParameter("@CsvFlocIds", flocs.BuildIdStringFromList());
            return command.GetCount(QUERY_COUNT_BY_FUNCTIONAL_LOCATION);
        }

        public List<Log> QueryLogsInBatchesByFunctionalLocation(long siteId, int batchNumber, int batchSize, LogType logType, List<FunctionalLocation> flocs)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            command.AddParameter("@Limit", batchSize);
            command.AddParameter("@Offset", (batchNumber * batchSize) + 1);
            command.AddParameter("@LogType", logType);
            command.AddParameter("@CsvFlocIds", flocs.BuildIdStringFromList());
            return command.QueryForListResult<Log>(PopulateInstance, QUERY_IN_BATCHES_BY_FUNCTIONAL_LOCATION);
        }

        public int QueryCountOfLogsAssociatedToActionItem(long actionItemId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ActionItemId", actionItemId);
            return command.GetCount(COUNT_LOGS_ASSOCIATED_TO_ACTION_ITEM_STORED_PROCEDURE);
        }

        public int QueryCountOfLogsAssociatedToActionItemDefinition(long actionItemDefinitionId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ActionItemDefinitionId", actionItemDefinitionId);
            return command.GetCount(COUNT_LOGS_ASSOCIATED_TO_ACTION_ITEM_DEFINITION_STORED_PROCEDURE);
        }

        public int QueryCountOfLogsAssociatedToWorkPermitEdmonton(long workPermitEdmontonId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkPermitEdmontonId", workPermitEdmontonId);
            return command.GetCount(COUNT_LOGS_ASSOCIATED_TO_WORK_PERMIT_EDMONTON_STORED_PROCEDURE);
        }

        public int QueryCountOfLogsAssociatedToWorkPermitLubes(long workPermitLubesId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkPermitLubesId", workPermitLubesId);
            return command.GetCount(COUNT_LOGS_ASSOCIATED_TO_WORK_PERMIT_LUBES_STORED_PROCEDURE);
        }

        public int QueryCountOfLogsAssociatedToTargetAlert(long targetAlertId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@TargetAlertId", targetAlertId);
            return command.GetCount(COUNT_LOGS_ASSOCIATED_TO_TARGET_ALERT_STORED_PROCEDURE);
        }

        public bool HasChildren(Log log)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@LogId", log.Id);
            return command.GetCount("CountLogChildren") > 0;
        }

        public void Remove(Log log)
        {
            ManagedCommand.ExecuteNonQuery(log, REMOVE_STORED_PROCEDURE, AddRemoveParameters);
        }

        private static void AddRemoveParameters(Log log, SqlCommand command)
        {
            command.AddParameter("@Id", log.Id);
            command.AddParameter("@LastModifiedUserId", log.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", log.LastModifiedDate);
        }

        public void Update(Log log)
        {
            // By Vibhor : RITM0272920
           if(!log.isAdminRole)               
            CheckThatShiftPatternIsValid(log);
           //END
            ManagedCommand.Update(log, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            //RemoveDeletedDocumentLinks(log);
            InsertNewDocumentLinks(log);
            RemoveDeletedDocumentLinks(log);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            UpdateCustomFieldEntries(log);

            //Mukesh for Log Image
            if (log.Imagelist != null)
            {
                InsertLogImage(log);
            }
        }

        private void UpdateCustomFieldEntries(Log log)
        {
            foreach (CustomFieldEntry entry in log.CustomFieldEntries)
            {
                if (entry.IsInDatabase())
                {
                    customFieldEntryDao.Update(entry);
                }
                else
                {
                    customFieldEntryDao.Insert(entry, log.IdValue);
                }                
            }

            customFieldEntryDao.DeleteThoseNoLongerAssociatedToEntity(log.IdValue, log.CustomFieldEntries);
        }
        
        public Log Insert(Log log)
        {
            CheckThatShiftPatternIsValid(log);
            SqlCommand command = ManagedCommand;
            long id = command.InsertAndReturnId(log, AddInsertParameters, INSERT_STORED_PROCEDURE);
            log.Id = id;
            InsertFunctionalLocations(log);
            InsertNewDocumentLinks(log);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            RemoveDeletedDocumentLinks(log);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017

            if (!log.CustomFields.IsEmpty())
            {
                InsertCustomFieldEntries(log);
                InsertCustomFieldGroupRelationships(log, log.CustomFields.ConvertAll(field => field.GroupId.Value).Unique());
            }

              //Mukesh for Log Image
            if(log.Imagelist!=null)
            {
                InsertLogImage(log);
            }



            return log;
        }

        private void InsertCustomFieldGroupRelationships(Log log, List<long> customFieldGroupIds)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = INSERT_LOG_CUSTOM_FIELD_GROUP;
            command.AddParameter("@LogId", log.IdValue);
            command.AddParameter("@CsvCustomFieldGroupIds", customFieldGroupIds.BuildCommaSeparatedList());
            command.ExecuteNonQuery();
        }

        private void InsertCustomFieldEntries(Log log)
        {
            log.CustomFieldEntries.ForEach(entry => customFieldEntryDao.Insert(entry, log.IdValue));
        }

        private void InsertFunctionalLocations(Log log)
        {
            foreach (FunctionalLocation functionalLocation in log.FunctionalLocations)
            {
                logFunctionalLocationDao.Insert(new LogFunctionalLocation(log.IdValue, functionalLocation.IdValue));
            }

            InsertOrUpdateFunctionalLocationList(log);
        }

        private void InsertOrUpdateFunctionalLocationList(Log log)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = INSERT_OR_UPDATE_FUNCTIONAL_LOCATION_LIST;
            command.AddParameter("@LogId", log.IdValue);
            command.ExecuteNonQuery();
        }

        public Log Insert(Log log, ActionItem associatedActionItem)
        {
            // Added by Vibhor DMND0010736  : OLT - Adding Pictures on Action item Response
            if (associatedActionItem.Imagelist_Response.Count != 0)
            {
                log.Imagelist = associatedActionItem.Imagelist_Response;
            }

            Log savedLog = Insert(log);
            InsertAssociationToActionItem(log, associatedActionItem.IdValue);
            return savedLog;
        }

        public Log Insert(Log log, ActionItemDefinition associatedActionItemDefinition)
        {
            Log insertedLog = Insert(log);
            InsertAssociationToActionItemDefinition(log, associatedActionItemDefinition.IdValue);
            return insertedLog;
        }

        public Log Insert(Log log, WorkPermitEdmonton associatedWorkPermit)
        {
            Log insertedLog = Insert(log);
            InsertAssociationToWorkPermitEdmonton(log, associatedWorkPermit.IdValue);
            return insertedLog;
        }

        public Log Insert(Log log, WorkPermitLubes associatedWorkPermit)
        {
            Log insertedLog = Insert(log);
            InsertAssociationToWorkPermitLubes(log, associatedWorkPermit.IdValue);
            return insertedLog;

        }
        public Log Insert(Log log, WorkPermitMontreal associatedWorkPermit)
        {
            Log insertedLog = Insert(log);
            InsertAssociationToWorkPermitMontreal(log, associatedWorkPermit.IdValue);
            return insertedLog;
        }

        //RITM0301321 mangesh
        public Log Insert(Log log, WorkPermitMuds associatedWorkPermit)
        {
            Log insertedLog = Insert(log);
            InsertAssociationToWorkPermitMuds(log, associatedWorkPermit.IdValue);
            return insertedLog;
        }

        public int QueryCountOfLogsAssociatedToWorkPermitMontreal(long workPermitMontrealId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkPermitMontrealId", workPermitMontrealId);
            return command.GetCount(COUNT_LOGS_ASSOCIATED_TO_WORK_PERMIT_MONTREAL_STORED_PROCEDURE);
        }

        //RITM0301321 mangesh
        public int QueryCountOfLogsAssociatedToWorkPermitMuds(long workPermitMudsId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkPermitMudsId", workPermitMudsId);
            return command.GetCount(COUNT_LOGS_ASSOCIATED_TO_WORK_PERMIT_MUDS_STORED_PROCEDURE);
        }

        public Log Insert(Log log, TargetAlert associatedTargetAlert)
        {
            Log insertedLog = Insert(log);
            InsertAssociationToTargetAlert(log, associatedTargetAlert.IdValue);
            return insertedLog;
        }

        private void InsertAssociationToTargetAlert(Log log, long targetAlertId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@TargetAlertId", targetAlertId);
            command.AddParameter("@LogId", log.IdValue);

            command.ExecuteNonQuery(INSERT_LOG_TARGET_ALERT_ASSOCIATION);
        }

        private void InsertAssociationToWorkPermitEdmonton(Log log, long workPermitEdmontonId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkPermitEdmontonId", workPermitEdmontonId);
            command.AddParameter("@LogId", log.IdValue);

            command.ExecuteNonQuery(INSERT_LOG_WORK_PERMIT_EDMONTON_ASSOCIATION);
        }

        private void InsertAssociationToWorkPermitLubes(Log log, long workPermitLubesId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkPermitLubesId", workPermitLubesId);
            command.AddParameter("@LogId", log.IdValue);

            command.ExecuteNonQuery(INSERT_LOG_WORK_PERMIT_LUBES_ASSOCIATION);
        }

        private void InsertAssociationToWorkPermitMontreal(Log log, long workPermitMontrealId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkPermitMontrealId", workPermitMontrealId);
            command.AddParameter("@LogId", log.IdValue);

            command.ExecuteNonQuery(INSERT_LOG_WORK_PERMIT_MONTREAL_ASSOCIATION);
        }

        //RITM0301321 mangesh
        private void InsertAssociationToWorkPermitMuds(Log log, long workPermitMudsId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkPermitMudsId", workPermitMudsId);
            command.AddParameter("@LogId", log.IdValue);

            command.ExecuteNonQuery(INSERT_LOG_WORK_PERMIT_MUDS_ASSOCIATION);
        }

        public void InsertAssociationToActionItem(Log log, long actionItemId)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = INSERT_LOG_ACTION_ITEM_ASSOCIATION;
            command.AddParameter("@ActionItemId",  actionItemId);
            command.AddParameter("@LogId",  log.IdValue);
            command.ExecuteNonQuery();
        }

        public void InsertAssociationToActionItemDefinition(Log log, long actionItemDefinitionId)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = INSERT_LOG_ACTION_ITEM_DEFINITION_ASSOCIATION;
            command.AddParameter("@ActionItemDefinitionId",  actionItemDefinitionId);
            command.AddParameter("@LogId",  log.IdValue);
            command.ExecuteNonQuery();
        }

        public bool HasLogForDefinitionSameDayAndAtLeastOneOfTheQueriedFlocs(LogDefinition definition, DateTime check, ExactFlocSet flocSet)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = QUERY_BY_LOG_DEFINITION_AND_DATE;
            command.AddParameter("@LogDefinitionId",  definition.Id);
            command.AddParameter("@DateToCheck",  check);
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            return command.ExecuteScalar() != null;
        }

        private void RemoveDeletedDocumentLinks(IDocumentLinksObject log)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(log, documentLinkDao.QueryByLogId);
        }

        private void InsertNewDocumentLinks(IDocumentLinksObject log)
        {
            documentLinkDao.InsertNewDocumentLinks(log, documentLinkDao.InsertForAssociatedLog);
        }

        private static void CheckThatShiftPatternIsValid(Log log)
        {
            ShiftPattern shiftPattern = log.CreatedShiftPattern;

            bool isValid = shiftPattern.IsDateTimeInShiftIncludingPadding(log.LogDateTime);
            if (!isValid)
            {
                string site = shiftPattern.Site != null ? shiftPattern.Site.Name : null;
                string shiftName = shiftPattern.DisplayName;
                throw new ShiftOutOfBoundsException(
                    string.Format("DateTime {0} Time portion does not fall within {1} and {2}. Site: {3}. Shift: {4}", log.LogDateTime, shiftPattern.StartTime,
                                  shiftPattern.EndTime, site, shiftName));
            }

            isValid = shiftPattern.IsDateTimeInShiftIncludingPadding(log.CreatedDateTime);
            if (!isValid)
            {
                string site = shiftPattern.Site != null ? shiftPattern.Site.Name : null;
                string shiftName = shiftPattern.DisplayName;
                throw new ShiftOutOfBoundsException(
                    string.Format("DateTime {0} Time portion does not fall within {1} and {2}. Site: {3}. Shift: {4}", log.CreatedDateTime, shiftPattern.StartTime,
                                  shiftPattern.EndTime, site, shiftName));
            }
        }

        private static void AddUpdateParameters(Log log, SqlCommand command)
        {
            command.AddParameter("@Id", log.Id);
            SetCommonAttributes(log, command);
        }

        private static void AddInsertParameters(Log log, SqlCommand command)
        {
            SetCommonAttributes(log, command);
        }

        private Log PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            bool isOperatingEngineerLog = reader.Get<bool>("IsOperatingEngineerLog");
            Role createdByRole = roleDao.QueryById(reader.Get<long>("CreatedByRoleId"));

            long? rootLogId = reader.Get<long?>("RootLogId");
            long? replayToLogId = reader.Get<long?>("ReplyToLogId");
            LogDefinition logDefinition = GetLogDefinition(reader.Get<long?>("LogDefinitionId"));
            DataSource dataSource = DataSource.GetById(reader.Get<int>("SourceId"));
            bool inspectionFollowUp = reader.Get<bool>("InspectionFollowUp");
            bool processControlFollowUp = reader.Get<bool>("ProcessControlFollowUp");
            bool operationsFollowUp = reader.Get<bool>("OperationsFollowUp");
            bool supervisionFollowUp = reader.Get<bool>("SupervisionFollowUp");
            bool ehsFollowUp = reader.Get<bool>("EHSFollowup");
            bool otherFollowUp = reader.Get<bool>("OtherFollowUp");
            DateTime loggedDate = reader.Get<DateTime>("LogDateTime");            
            ShiftPattern shiftPattern = shiftPatternDao.QueryById(reader.Get<long>("CreationUserShiftPatternId"));
            User createdByUser = userDao.QueryById(reader.Get<long>("UserId"));
            User lastModifiedByUser = userDao.QueryById(reader.Get<long>("LastModifiedUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");
            bool hasChildren = reader.Get<bool>("HasChildren");
            List<DocumentLink> documentLinks = documentLinkDao.QueryByLogId(id);
            byte type = reader.Get<byte>("LogType");
            LogType logType = type.ToEnum<LogType>();
            bool recommendForShiftSummary = reader.Get<bool>("RecommendForShiftSummary");
            string comments = reader.Get<string>("RtfComments");
            string commentsAsPlainText = reader.Get<string>("PlainTextComments");

            long? workAssignmentId = reader.Get<long?>("WorkAssignmentId");
            WorkAssignment assignment = !workAssignmentId.HasValue
                                                                 ? null
                                                                 : workAssignmentDao.QueryById(workAssignmentId.Value);
            
            List<FunctionalLocation> flocs = functionalLocationDao.QueryByLogId(id);

            List<CustomFieldEntry> customFieldEntries = customFieldEntryDao.QueryByLogId(id);
            List<CustomField> customFields = customFieldDao.QueryByCustomFieldGroupsForLogs(id);

            Log result = new Log(rootLogId,
                                 replayToLogId,
                                 logDefinition,
                                 dataSource,
                                 flocs,
                                 inspectionFollowUp,
                                 processControlFollowUp,
                                 operationsFollowUp,
                                 supervisionFollowUp,
                                 ehsFollowUp,
                                 otherFollowUp,                                 
                                 comments,
                                 commentsAsPlainText,
                                 loggedDate,                                 
                                 shiftPattern,
                                 createdByUser,
                                 lastModifiedByUser,
                                 lastModifiedDateTime,
                                 createdDateTime,
                                 hasChildren,
                                 isOperatingEngineerLog,
                                 createdByRole,
                                 documentLinks,
                                 logType,
                                 recommendForShiftSummary,
                                 assignment,
                                 customFieldEntries,
                                 customFields) { Id = id, Deleted = (reader.Get<bool>("Deleted")) };
            
            return result;
        }

        private LogDefinition GetLogDefinition(long? logDefId)
        {
            return !logDefId.HasValue ? null : logDefinitionDao.QueryById(logDefId.Value);
        }

        private static void SetCommonAttributes(Log log, SqlCommand command)
        {
            command.AddParameter("@RootLogId",  log.RootLogId);
            command.AddParameter("@ReplyToLogId",  log.ReplyToLogId);
            command.AddParameter("@HasChildren", log.HasChildren);
            command.AddParameter("@LogDefinitionId",  (log.LogDefinition == null ? null : log.LogDefinition.Id));
            command.AddParameter("@SourceId", log.Source.Id);
            command.AddParameter("@LastModifiedUserID", log.LastModifiedBy.Id);

            command.AddParameter("@LastModifiedDateTime", log.LastModifiedDate);
            command.AddParameter("@CreatedDateTime", log.CreatedDateTime);
            command.AddParameter("@LogDateTime", log.LogDateTime);       
               
            command.AddParameter("@UserID", log.CreationUser.Id);
            command.AddParameter("@InspectionFollowUp", log.InspectionFollowUp);
            command.AddParameter("@ProcessControlFollowUp", log.ProcessControlFollowUp);
            command.AddParameter("@OperationsFollowUp", log.OperationsFollowUp);
            command.AddParameter("@SupervisionFollowUp", log.SupervisionFollowUp);
            command.AddParameter("@OtherFollowUp", log.OtherFollowUp);
            command.AddParameter("@IsOperatingEngineerLog", log.IsOperatingEngineerLog);
            command.AddParameter("@CreatedByRoleId", log.CreatedByRole.Id);
            command.AddParameter("@EHSFollowUp", log.EnvironmentalHealthSafetyFollowUp);
            command.AddParameter("@LogType", log.LogType);
            command.AddParameter("@RecommendForShiftSummary", log.RecommendForShiftSummary);
            command.AddParameter("@WorkAssignmentId", log.WorkAssignment != null ? log.WorkAssignment.Id : null);            
            command.AddParameter("@RtfComments", log.RtfComments);
            command.AddParameter("@PlainTextComments", log.PlainTextComments);


            // NOTE: this property should not be null, but I don't want to take this code
            // out since I'm not sure what effect it will have. Logging. (Dustin)
            if(log.CreatedShiftPattern == null)
            {
                logger.Warn(String.Format("The CreatedShiftPattern is null when inserting a log. This value should not be null. The output of the log being inserted is: {0}",log));
                command.AddParameter("@CreationUserShiftPatternId",  null);
            }
            else
            {
                command.AddParameter("@CreationUserShiftPatternId", log.CreatedShiftPattern.Id);
            }
        }



        //Mukesh for Log Image
        private void InsertLogImage(Log Logs)
        {

            foreach (LogImage Img in Logs.Imagelist)
            {
                if (Img.Id == 0 && Img.Action!="Remove")
                {
                    SqlCommand command = ManagedCommand;
                    command.CommandText = "InsertLOGImage";
                    command.AddParameter("@LOGID", Logs.IdValue);
                    command.AddParameter("@Name", Img.Name);
                    command.AddParameter("@Description", Img.Description);
                    command.AddParameter("@ImagePath", Img.ImagePath);
                    command.AddParameter("@Createdby", Logs.CreationUser.Id);
                    command.AddParameter("@CreatedDate", Logs.CreatedDateTime);
                    command.AddParameter("@RecordType",(int) Img.Types);
                    command.AddParameter("@RecordFor ", (int)Img.RecordType);
                    command.ExecuteNonQuery();
                }
                else if(Convert.ToString(Img.Action).ToUpper()=="Remove".ToUpper())
                {
                    SqlCommand command = ManagedCommand;
                    command.CommandText = "RemoveLOGImage";
                    command.AddParameter("@Id", Img.Id);
                   
                    command.ExecuteNonQuery();

                }
                else if (Img.Id > 0)
                {
                    SqlCommand command = ManagedCommand;
                    command.CommandText = "UpdateLOGImage";
                    command.AddParameter("@ID", Img.IdValue);
                    command.AddParameter("@Name", Img.Name);
                    command.AddParameter("@Description", Img.Description);
                    command.ExecuteNonQuery();
                }
            }
           
        }

        private void SetLogImage(Log Logs)
        {
            
            SqlCommand command = ManagedCommand;
            command.AddParameter("@LOGIDs", Logs.IdValue);
            command.AddParameter("@RecordFor", (int)LogImage.RecordTypes.Log);
            command.CommandText = "GetLOGImage";
            SqlDataReader reader = command.ExecuteReader();
            List<LogImage> lst = new List<LogImage>();
            while (reader.Read())
            {
                LogImage Img = new LogImage();
                Img.Id =reader.Get<long>("Id");
                Img.Name = reader.Get<string>("Name");
                Img.Description = reader.Get<string>("Description");
                Img.ImagePath = reader.Get<string>("ImagePath");
                Img.Action = "";
                if (reader.Get("RecordType")!=null && reader.Get<int>("RecordType") == 0)
                {
                    Img.Types = LogImage.Type.Title;
                }
                else
                {
                    Img.Types = LogImage.Type.Image;
                }
                if (reader.Get("RecordFor") != null && reader.Get<int>("RecordFor") == 1)
                {
                    Img.RecordType = LogImage.RecordTypes.Summary;
                }
                else
                {
                    Img.RecordType = LogImage.RecordTypes.Log;
                }
               
                lst.Add(Img);


            }
            reader.Dispose();
            Logs.Imagelist= lst;
        }

       
        //End  for Log Image




    }
}