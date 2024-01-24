using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class SummaryLogDao : AbstractManagedDao, ISummaryLogDao
    {
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QuerySummaryLogByID";
        private const string INSERT_STORED_PROCEDURE = "InsertSummaryLog";
        private const string REMOVE_STORED_PROCEDURE = "RemoveSummaryLog";
        private const string UPDATE_STORED_PROCEDURE = "UpdateSummaryLog";
        private const string QUERY_LAST_CREATED_BY_USER_STORED_PROCEDURE = "QuerySummaryLogLastCreatedByUserId";
        private const string QUERY_BY_FLOC_DATE_RANGE_SHIFT_AND_WORK_ASSIGNMENT = "QuerySummaryLogByFlocDateRangeShiftAndWorkAssignment";

        private const string INSERT_SUMMARY_LOG_FUNCTIONAL_LOCATION = "InsertSummaryLogFunctionalLocation";
        private const string DELETE_SUMMARY_LOG_FUNCTIONAL_LOCATION_BY_SUMMARY_LOG_ID = "DeleteSummaryLogFunctionalLocationsBySummaryLogId";
        private const string INSERT_OR_UPDATE_FUNCTIONAL_LOCATION_LIST = "InsertOrUpdateSummaryLogFunctionalLocationList";
        private const string INSERT_SUMMARY_LOG_CUSTOM_FIELD_GROUPS = "InsertSummaryLogCustomFieldGroups";

        private readonly IFunctionalLocationDao flocDao;        
        private readonly IUserDao userDao;
        private readonly IRoleDao roleDao;
        private readonly IShiftPatternDao shiftPatternDao;
        private readonly IDocumentLinkDao documentLinkDao;
        private readonly IWorkAssignmentDao workAssignmentDao;
        private readonly ISummaryLogCustomFieldEntryDao customFieldEntryDao;
        private readonly ICustomFieldDao customFieldDao;
        private static readonly ILog logger = GenericLogManager.GetLogger<LogDao>();

        public SummaryLogDao()
        {
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();            
            userDao = DaoRegistry.GetDao<IUserDao>();
            roleDao = DaoRegistry.GetDao<IRoleDao>();
            shiftPatternDao = DaoRegistry.GetDao<IShiftPatternDao>();
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
            customFieldEntryDao = DaoRegistry.GetDao<ISummaryLogCustomFieldEntryDao>();
            customFieldDao = DaoRegistry.GetDao<ICustomFieldDao>();
        }

        public SummaryLog QueryById(long id)
        {
            //Mukesh for Log Image
            SummaryLog log = ManagedCommand.QueryById<SummaryLog>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
            SetLogImage(log);
            return log;
           // return ManagedCommand.QueryById<SummaryLog>(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public void Remove(SummaryLog log)
        {
            ManagedCommand.ExecuteNonQuery(log, REMOVE_STORED_PROCEDURE, AddRemoveParameters);
        }

        private static void AddRemoveParameters(SummaryLog log, SqlCommand command)
        {
            command.AddParameter("@Id", log.Id);
            command.AddParameter("@LastModifiedUserId", log.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", log.LastModifiedDate);
        }

        public void Update(SummaryLog log)
        {
            SummaryLog previousVersion = QueryById(log.IdValue);

            SqlCommand command = ManagedCommand;
            command.ClearParameters();

            CheckThatShiftPatternIsValid(log);
            command.Update(log, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
            RemoveDeletedDocumentLinks(log);
            InsertNewDocumentLinks(log);
            if (!previousVersion.FunctionalLocations.EqualsById(log.FunctionalLocations))
            {
                UpdateFunctionalLocations(command, log);
            }
            UpdateCustomFieldEntries(log);
            MapShiftLogToSummaryLog(command, log);//RITM0164968- mangesh

            //Mukesh for Log Image
            if (log.Imagelist != null)
            {
                InsertLogImage(log);
            }
        }

        private void UpdateCustomFieldEntries(SummaryLog log)
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

        private void UpdateFunctionalLocations(SqlCommand command, SummaryLog log)
        {
            command.CommandText = DELETE_SUMMARY_LOG_FUNCTIONAL_LOCATION_BY_SUMMARY_LOG_ID;
            command.Parameters.Clear();
            command.AddParameter("@SummaryLogId",  log.Id);
            command.ExecuteNonQuery();

            InsertFunctionalLocations(command, log);
            InsertOrUpdateFunctionalLocationList(command, log);
        }
       
        public SummaryLog Insert(SummaryLog log)
        {
            CheckThatShiftPatternIsValid(log);
            SqlCommand command = ManagedCommand;
            SqlParameter idParameter = command.AddIdOutputParameter();
            command.Insert(log, AddInsertParameters, INSERT_STORED_PROCEDURE);
            log.Id = long.Parse(idParameter.Value.ToString());
            InsertNewDocumentLinks(log);
            InsertFunctionalLocations(command, log);
            if (!log.CustomFields.IsEmpty())
            {
                InsertCustomFieldEntries(log);
                InsertCustomFieldGroupRelationships(log, log.CustomFields.ConvertAll(field => field.GroupId.Value).Unique());
            }
            MapShiftLogToSummaryLog(command, log);//RITM0164968- mangesh
            //Mukesh for Log Image
            if (log.Imagelist != null)
            {
                InsertLogImage(log);
            }

            return log;
        }

        //RITM0164968- mangesh
        private void MapShiftLogToSummaryLog(SqlCommand command, SummaryLog log)
        {  
            command.CommandText = "MapShiftLogToSummaryLog";
            command.Parameters.Clear();
            command.AddParameter("@SummaryLogId", log.Id);
            command.AddParameter("@LogId", log.SelectLogIDsForSummaryPresenter);
            command.ExecuteNonQuery();
        }

        private void InsertCustomFieldEntries(SummaryLog log)
        {
            log.CustomFieldEntries.ForEach(entry => customFieldEntryDao.Insert(entry, log.IdValue));
        }

        private void InsertCustomFieldGroupRelationships(SummaryLog log, List<long> customFieldGroupIds)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = INSERT_SUMMARY_LOG_CUSTOM_FIELD_GROUPS;
            command.AddParameter("@SummaryLogId", log.IdValue);
            command.AddParameter("@CsvCustomFieldGroupIds", customFieldGroupIds.BuildCommaSeparatedList());
            command.ExecuteNonQuery();
        }
       
        private static void InsertFunctionalLocations(SqlCommand command, SummaryLog log)
        {
            if (!log.FunctionalLocations.IsEmpty())
            {
                command.CommandText = INSERT_SUMMARY_LOG_FUNCTIONAL_LOCATION;
                foreach (FunctionalLocation functionalLocation in log.FunctionalLocations)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@SummaryLogId",  log.Id);
                    command.AddParameter("@FunctionalLocationId",  functionalLocation.Id);
                    command.ExecuteNonQuery();
                }

                InsertOrUpdateFunctionalLocationList(command, log);
            }
        }

        public SummaryLog QueryLatestSummaryLogForUser(long userId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@UserId",  userId);
            return command.QueryForSingleResult<SummaryLog>(PopulateInstance , QUERY_LAST_CREATED_BY_USER_STORED_PROCEDURE);
        }

        public List<SummaryLog> QueryByFlocListDateRangeShiftAndWorkAssignment(DateTime startOfRange, DateTime endOfRange, IFlocSet flocSet, long shiftId, long? workAssignmentId, long userId)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@StartOfDateRange", startOfRange);
            command.AddParameter("@EndOfDateRange", endOfRange);
            command.AddParameter("@CsvFLOCIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@ShiftId", shiftId);
            command.AddParameter("@UserId", userId);

            if (workAssignmentId.HasValue)
            {
                command.AddParameter("@WorkAssignmentId", workAssignmentId);
            }
            
            return command.QueryForListResult<SummaryLog>(PopulateInstance, QUERY_BY_FLOC_DATE_RANGE_SHIFT_AND_WORK_ASSIGNMENT);
        }
        // amit shukla Flexi shift handover RITM0185797
        public List<SummaryLog> QueryByFlocListDateRangeShiftAndWorkAssignment(DateTime startOfRange, DateTime endOfRange, IFlocSet flocSet, long shiftId, long? workAssignmentId, long userId, bool isFlexible)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@StartOfDateRange", startOfRange);
            command.AddParameter("@EndOfDateRange", endOfRange);
            command.AddParameter("@CsvFLOCIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@ShiftId", shiftId);
            command.AddParameter("@UserId", userId);
            command.AddParameter("@IsFlexible", isFlexible);

            if (workAssignmentId.HasValue)
            {
                command.AddParameter("@WorkAssignmentId", workAssignmentId);
            }

            return command.QueryForListResult<SummaryLog>(PopulateInstance, QUERY_BY_FLOC_DATE_RANGE_SHIFT_AND_WORK_ASSIGNMENT);
        }

        public bool HasChildren(SummaryLog summaryLog)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@SummaryLogId", summaryLog.Id);
            return command.GetCount("CountSummaryLogChildren") > 0;
        }

        public List<SummaryLog> QueryByShiftHandover(long shiftHandoverId)
        {
            List<SummaryLog> lstSummary = new List<SummaryLog>();
            using (SqlCommand command = ManagedCommand)
            {

                command.AddParameter("@ShiftHandoverId", shiftHandoverId);
                // return command.QueryForListResult<SummaryLog>(PopulateInstance, "QuerySummaryLogByShiftHandover");
               lstSummary = command.QueryForListResult<SummaryLog>(PopulateInstance, "QuerySummaryLogByShiftHandover");
            }
            //Mukesh for Log Image
            foreach(SummaryLog Log in lstSummary)
            {
                SetLogImage(Log);
            }
            return lstSummary;
        }

        private void RemoveDeletedDocumentLinks(IDocumentLinksObject log)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(log, documentLinkDao.QueryBySummaryLogId);
        }

        private void InsertNewDocumentLinks(IDocumentLinksObject log)
        {
            documentLinkDao.InsertNewDocumentLinks(log, documentLinkDao.InsertForAssociatedSummaryLog);
        }

        private static void CheckThatShiftPatternIsValid(SummaryLog log)
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
        }

        private static void InsertOrUpdateFunctionalLocationList(SqlCommand command, SummaryLog log)
        {
            command.Parameters.Clear();
            command.CommandText = INSERT_OR_UPDATE_FUNCTIONAL_LOCATION_LIST;
            command.AddParameter("@SummaryLogId", log.IdValue);
            command.ExecuteNonQuery();
        }

        private static void AddUpdateParameters(SummaryLog log, SqlCommand command)
        {
            command.AddParameter("@Id", log.Id);
            command.AddParameter("@HasChildren", log.HasChildren);
            SetCommonAttributes(log, command);
        }

        private static void AddInsertParameters(SummaryLog log, SqlCommand command)
        {
            command.AddParameter("@CreatedByRoleId", log.CreatedByRole.Id);
            command.AddParameter("@RootLogId", log.RootLogId);
            command.AddParameter("@ReplyToLogId", log.ReplyToLogId);            

            SetCommonAttributes(log, command);
        }

        private SummaryLog PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");           
                              
            bool inspectionFollowUp = reader.Get<bool>("InspectionFollowUp");
            bool processControlFollowUp = reader.Get<bool>("ProcessControlFollowUp");
            bool operationsFollowUp = reader.Get<bool>("OperationsFollowUp");
            bool supervisionFollowUp = reader.Get<bool>("SupervisionFollowUp");
            bool ehsFollowUp = reader.Get<bool>("EHSFollowup");
            bool otherFollowUp = reader.Get<bool>("OtherFollowUp");
            DateTime logDateTime = reader.Get<DateTime>("LogDateTime");            
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");
            ShiftPattern shiftPattern = shiftPatternDao.QueryById(reader.Get<long>("CreationUserShiftPatternId"));
            User createdByUser = userDao.QueryById(reader.Get<long>("CreatedByUserId"));
            Role createdByRole = roleDao.QueryById(reader.Get<long>("CreatedByRoleId"));
            User lastModifiedByUser = userDao.QueryById(reader.Get<long>("LastModifiedUserId"));
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
            DataSource dataSource = DataSource.GetById(reader.Get<int>("DataSourceId"));

            List<DocumentLink> documentLinks = documentLinkDao.QueryBySummaryLogId(id);


            long? workAssignmentId = reader.Get<long?>("WorkAssignmentId");
            WorkAssignment workAssignment = !workAssignmentId.HasValue
                                                                 ? null
                                                                 : workAssignmentDao.QueryById(workAssignmentId.Value);


            string rtfComments = reader.Get<string>("RtfComments");
            string plainTextComments = reader.Get<string>("PlainTextComments");
            string dorComments = reader.Get<string>("DorComments");

            List<FunctionalLocation> functionalLocations = flocDao.QueryBySummaryLogId(id);
            
            List<CustomFieldEntry> customFieldEntries = customFieldEntryDao.QueryBySummaryLogId(id);
            List<CustomField> customFields = customFieldDao.QueryByCustomFieldGroupsForSummaryLogs(id);

            long? rootLogId = reader.Get<long?>("RootLogId");
            long? replyToLogId = reader.Get<long?>("ReplyToLogId");
            bool hasChildren = reader.Get<bool>("HasChildren");

            bool deleted = reader.Get<bool>("Deleted");

            SummaryLog result = new SummaryLog(                                
                                 functionalLocations,                                  
                                 rtfComments,
                                 plainTextComments,
                                 dorComments,
                                 dataSource,
                                 inspectionFollowUp,
                                 processControlFollowUp,
                                 operationsFollowUp,
                                 supervisionFollowUp,
                                 ehsFollowUp,
                                 otherFollowUp,
                                 logDateTime,  
                                 createdDateTime,
                                 shiftPattern,
                                 createdByUser,
                                 createdByRole,
                                 lastModifiedByUser,
                                 lastModifiedDateTime,                                 
                                 documentLinks,                                                                  
                                 workAssignment, 
                                 customFieldEntries,
                                 customFields,
                                 rootLogId, replyToLogId, hasChildren) { Id = id, Deleted = deleted };
                       
            return result;
        }
       
        private static void SetCommonAttributes(SummaryLog log, SqlCommand command)
        {                                   
            command.AddParameter("@LastModifiedUserID", log.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", log.LastModifiedDate);            
            command.AddParameter("@LogDateTime", log.LogDateTime);            
            command.AddParameter("@CreatedDateTime", log.CreatedDateTime);            
            command.AddParameter("@CreatedByUserID", log.CreationUser.Id);
            command.AddParameter("@InspectionFollowUp", log.InspectionFollowUp);
            command.AddParameter("@ProcessControlFollowUp", log.ProcessControlFollowUp);
            command.AddParameter("@OperationsFollowUp", log.OperationsFollowUp);
            command.AddParameter("@SupervisionFollowUp", log.SupervisionFollowUp);
            command.AddParameter("@OtherFollowUp", log.OtherFollowUp);
            command.AddParameter("@EHSFollowUp", log.EnvironmentalHealthSafetyFollowUp);            
            command.AddParameter("@WorkAssignmentId",
                        log.WorkAssignment != null ? log.WorkAssignment.Id : null);

            command.AddParameter("@RtfComments", log.RtfComments);            
            command.AddParameter("@PlainTextComments", log.PlainTextComments);            
            command.AddParameter("@DorComments", log.DorComments);            
            command.AddParameter("@DataSourceId", log.DataSource.IdValue);            

            // NOTE: this property should not be null, but I don't want to take this code
            // out since I'm not sure what effect it will have. Logging. (Dustin)
            if(log.CreatedShiftPattern == null)
            {
                logger.Warn(
                        String.Format(
                                "The CreatedShiftPattern is null when inserting a log. This value should not be null. The output of the log being inserted is: {0}",
                                log));
                command.AddParameter("@CreationUserShiftPatternId",  null);
            }
            else
            {
                command.AddParameter("@CreationUserShiftPatternId", log.CreatedShiftPattern.Id);
            }
        }


        //Mukesh for Log Image
        private void InsertLogImage(SummaryLog Logs)
        {

            foreach (LogImage Img in Logs.Imagelist)
            {
                if (Img.Id == 0 && Img.Action.ToUpper() == "INSERT")
                {
                    SqlCommand command = ManagedCommand;
                    command.CommandText = "InsertLOGImage";
                    command.AddParameter("@LOGID", Logs.IdValue);
                    command.AddParameter("@Name", Img.Name);
                    command.AddParameter("@Description", Img.Description);
                    command.AddParameter("@ImagePath", Img.ImagePath);
                    command.AddParameter("@Createdby", Logs.CreationUser.Id);
                    command.AddParameter("@CreatedDate", Logs.CreatedDateTime);
                    command.AddParameter("@RecordType", (int)Img.Types);
                    command.AddParameter("@RecordFor ", (int)Img.RecordType);
                    command.ExecuteNonQuery();
                }
                else if (Convert.ToString(Img.Action).ToUpper() == "Remove".ToUpper())
                {
                    SqlCommand command = ManagedCommand;
                    command.CommandText = "RemoveLOGImage";
                    command.AddParameter("@Id", Img.Id);

                    command.ExecuteNonQuery();

                }
                else if (Img.Id>0)
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

        private void SetLogImage(SummaryLog Logs)
        {

            SqlCommand command = ManagedCommand;
            command.AddParameter("@LOGIDs", Logs.IdValue);
            command.AddParameter("@RecordFor", LogImage.RecordTypes.Summary);
            command.CommandText = "GetLOGImage";
            SqlDataReader reader = command.ExecuteReader();
            List<LogImage> lst = new List<LogImage>();
            while (reader.Read())
            {
                LogImage Img = new LogImage();
                Img.Id = reader.Get<long>("Id");
                Img.Name = reader.Get<string>("Name");
                Img.Description = reader.Get<string>("Description");
                Img.ImagePath = reader.Get<string>("ImagePath");
                Img.Action = "";
                if (reader.Get("RecordType") != null && reader.Get<int>("RecordType") == 0)
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
            Logs.Imagelist = lst;
        }


        //End  for Log Image
    }
}