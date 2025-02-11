using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using log4net;
using Com.Suncor.Olt.Common;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class LogDTODao : AbstractManagedDao, ILogDTODao
    {
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryLogDTOById";

        private const string QUERY_BY_ACTION_ITEM = "QueryLogDTOsByActionItem";
        private const string QUERY_BY_ACTION_ITEM_DEFINITION = "QueryLogDTOsByActionItemDefinition";
        private const string QUERY_BY_WORK_PERMIT_EDMONTON = "QueryLogDTOsByWorkPermitEdmonton";
        private const string QUERY_BY_WORK_PERMIT_LUBES = "QueryLogDTOsByWorkPermitLubes";
        private const string QUERY_BY_WORK_PERMIT_MONTREAL = "QueryLogDTOsByWorkPermitMontreal";
        private const string QUERY_BY_TARGET_ALERT = "QueryLogDTOsByTargetAlert";
        private const string QUERY_BY_WORK_PERMIT_MUDS = "QueryLogDTOsByWorkPermitMuds"; //RITM0301321 mangesh

        private const string QUERY_OP_ENG_BY_CSV_FUNCTIONALLOCATIN_IDS = "QueryOpEngLogDTOsByFLOCIDs";
        
        // three different variations on the same things
        private const string QUERY_BY_FLOCS_AND_SHIFT_AND_OPERATING_ENGINEER_FLAG = "QueryLogDTOsByFlocsAndShift";     
        private const string QUERY_BY_LOGGED_DATE_OR_ACTUAL_LOGGED_DATE = "QueryLogDTOByLoggedDateOrActualLoggedDateAndShift";
        private const string QUERY_BY_PARENT_FLOC_DATE_RANGE_SHIFT_AND_ASSIGNMENT = "QueryLogDTOByFlocDateRangeShiftAndAssignment";

        
        private const string QUERY_DTO_BY_PARENT_FLOC_LIST_AND_MARKED_AS_READ = "QueryLogDTOsByParentFlocListAndMarkedAsRead";

        // two variations on the same thing.
        private const string QUERY_BY_CSV_FUNCTIONALLOCATION_IDS_AND_ASSIGNMENT = "QueryLogDTOsByFLOCIDsAndAssignment"; 
        private const string QUERY_BY_USER_ROOT_FLOC_DIRECT_ANCESTORS_AND_DESCENDANTS = "QueryLogDTOByUserRootFlocDirectAncestorsAndDescendants";

        public const long DONT_CARE_SITE_ID = 0;
        public static readonly DateTime DONT_CARE_SHIFT_CREATION_DATE = DateTime.MinValue;

        private static readonly ILog logger = GenericLogManager.GetLogger<LogDTODao>();
        

        public List<LogDTO> QueryOpEngineerLogsByFunctionalLocation(IFlocSet flocSet, DateTime? startOfRange, List<long> clientReadableVisibilityGroupIds)
        {
            if (startOfRange.HasNoValue())
            {
                startOfRange = DateTimeExtensions.CreateSQLServerFriendlyMinDate();
            }

            string csvFunctionalLocationIds =
                flocSet.FunctionalLocations.BuildIdStringFromList();

            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", csvFunctionalLocationIds);
            command.AddParameter("@StartOfDateRange", startOfRange);
            command.AddParameter("@EndOfDateRange", DateTimeExtensions.CreateSQLServerFriendlyMaxDate());
            command.AddParameter("@CsvVisibilityGroupIds", clientReadableVisibilityGroupIds == null ? null : clientReadableVisibilityGroupIds.ToCommaSeparatedString());

            List<LogDTO> result = GetDtos(command, QUERY_OP_ENG_BY_CSV_FUNCTIONALLOCATIN_IDS);

            ConvertChildrenWithoutParentsToParentsAndFlag(result);

            return result;
        }

        public List<LogDTO> QueryByFunctionalLocations(IFlocSet flocSet, DateRange range, List<long> clientReadableVisibilityGroupIds)
        {
            return QueryByRootFLOCsWithMatchingFLOCAncestorsAndDescendants(LogType.Standard,
                                                                           range.SqlFriendlyStart,
                                                                           range.SqlFriendlyEnd,
                                                                           flocSet,
                                                                           null,
                                                                           clientReadableVisibilityGroupIds);
        }

        public List<LogDTO> QueryByFunctionalLocations(IFlocSet flocSet, DateTime? startOfRange, DateTime? endOfRange, WorkAssignment assignment, List<long> clientReadableVisibilityGroupIds)
        {
            if (startOfRange.HasNoValue())
            {
                startOfRange = DateTimeExtensions.CreateSQLServerFriendlyMinDate();
            }

            if (endOfRange.HasNoValue())
            {
                endOfRange = DateTimeExtensions.CreateSQLServerFriendlyMaxDate();
            }

            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@StartOfDateRange", startOfRange);
            command.AddParameter("@EndOfDateRange", endOfRange);
            if (assignment != null)
            {
                command.AddParameter("@WorkAssignmentId", assignment.Id);
            }
            command.AddParameter("@CsvVisibilityGroupIds", clientReadableVisibilityGroupIds == null ? null : clientReadableVisibilityGroupIds.ToCommaSeparatedString());

            List<LogDTO> result = GetDtos(command, QUERY_BY_CSV_FUNCTIONALLOCATION_IDS_AND_ASSIGNMENT);

            ConvertChildrenWithoutParentsToParentsAndFlag(result);

            return result;            
        }

        public static void ConvertChildrenWithoutParentsToParentsAndFlag(List<LogDTO> logDtoList)
        {
            LogDTO.ConvertChildrenWithoutParentsToParentsAndFlag(logDtoList);
        }

        public List<LogReportDTO> QueryForLogReportDTO(IFlocSet flocSet, UserShift userShift, bool onlyReturnLogsFlaggedAsOperatingEngineerLog)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@CreatedShiftPatternId", userShift.ShiftPatternId);

            command.AddParameter("@StartOfDateRange", userShift.StartDateTimeWithPadding);
            command.AddParameter("@EndOfDateRange", userShift.EndDateTimeWithPadding);

            command.AddParameter("@OnlyReturnLogsFlaggedAsOperatingEngineerLog", onlyReturnLogsFlaggedAsOperatingEngineerLog);

            //List<LogReportDTO> queryByFunctionalLocationsAndShift = command.QueryForListResult<LogReportDTO>(
            //    PopulateInstanceForLogReportDto, QUERY_BY_FLOCS_AND_SHIFT_AND_OPERATING_ENGINEER_FLAG);

            List<LogReportDTO> queryByFunctionalLocationsAndShift = QueryForLogCustomFieldsReportDTO(flocSet, userShift, onlyReturnLogsFlaggedAsOperatingEngineerLog); //RITM0208281 -  mangesh

            return queryByFunctionalLocationsAndShift;
        }
        
        //RITM0208281 -  mangesh
        private List<LogReportDTO> QueryForLogCustomFieldsReportDTO(IFlocSet flocSet, UserShift userShift,
            bool onlyReturnLogsFlaggedAsOperatingEngineerLog)
        {
            using (SqlCommand command = ManagedCommand)
            {
                command.CommandText = "QueryCustomFieldsLogDTOsByFlocsAndShift";
                command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
                command.AddParameter("@CreatedShiftPatternId", userShift.ShiftPatternId);
                command.AddParameter("@StartOfDateRange", userShift.StartDateTimeWithPadding);
                command.AddParameter("@EndOfDateRange", userShift.EndDateTimeWithPadding);
                command.AddParameter("@OnlyReturnLogsFlaggedAsOperatingEngineerLog", onlyReturnLogsFlaggedAsOperatingEngineerLog);

                Dictionary<long, LogReportDTOContainer> result =
                    new Dictionary<long, LogReportDTOContainer>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long logId = GetId(reader);
                        if (result.ContainsKey(logId))
                        {
                            string functionalLocationNameWithDescription =
                               GetFunctionalLocationNameWithDescription(reader);
                            result[logId].Dto.AddFunctionalLocation(functionalLocationNameWithDescription);

                            CustomFieldEntry customFieldEntry = GetCustomFieldEntry(reader);
                            result[logId].Dto.AddCustomFieldEntry(customFieldEntry);

                            CustomField customField = GetCustomField(reader);
                            result[logId].AddCustomField(customField);
                        }
                        else
                        {
                            LogReportDTO logReportDto = PopulateInstanceLogCustomFieldReportDto(reader);
                            List<CustomField> customFields = new List<CustomField>();
                            CustomField customField = GetCustomField(reader);
                            if (customField != null)
                            {
                                customFields.Add(customField);
                            }

                            if (logReportDto.ShiftStartDateTime >= userShift.StartDateTime)
                            {
                                result.Add(logId, new LogReportDTOContainer(logReportDto, customFields));
                            }
                        }
                    }
                }

                List<LogReportDTO> dtos = new List<LogReportDTO>();
                foreach (LogReportDTOContainer container in result.Values)
                {
                    container.Dto.CustomFieldEntries = CustomFieldEntry.PadEntriesWithBlanks(container.CustomFields,
                        container.Dto.CustomFieldEntries);
                    dtos.Add(container.Dto);
                    container.Dto.IsOnlyReturnLogsFlaggedAsOperatingEngineerLog = onlyReturnLogsFlaggedAsOperatingEngineerLog;
                }
                
                return dtos;
            }
            //return null;
        }

        private static string GetFunctionalLocationNameWithDescription(SqlDataReader reader)
        {
            string name = GetFunctionalLocationName(reader);
            string description = reader.Get<string>("FunctionalLocationDescription");
            return FunctionalLocation.GetFullHierarchyWithDescription(name, description);
        }
        private static string GetFunctionalLocationName(SqlDataReader reader)
        {
            return reader.Get<string>("FunctionalLocationName");
        }
        private LogReportDTO PopulateInstanceLogCustomFieldReportDto(SqlDataReader reader)
        {
            long logId = GetId(reader);
            string unitFloc = reader.Get<string>("Unit");
            string flocDescription = reader.Get<string>("FunctionalLocationDescription");
            string unitFlocDescription = reader.Get<string>("UnitDescription");
            string lastModifiedByFullNameWithUserName = reader.GetUser("LastModifiedByFirstName", "LastModifiedByLastName", "LastModifiedByUserName");
            DateTime logDateTime = GetLogDateTime(reader);

            ShiftPattern logShiftPattern = GetLogShiftPattern(reader);
            UserShift userShift = new UserShift(logShiftPattern, logDateTime);
            Time shiftStartTime = new Time(userShift.StartDateTime);
            DateTime createdShiftStartDateTime = new Date(userShift.StartDateTime).CreateDateTime(shiftStartTime);

            string plainTextComments = reader.Get<string>("PlainTextComments");
            string rtfComments = reader.Get<string>("RtfComments");

            string functionalLocationName = reader.Get<string>("FunctionalLocationName");

            CustomFieldEntry customFieldEntry = GetCustomFieldEntry(reader);
            List<CustomFieldEntry> customFieldEntries = new List<CustomFieldEntry>();
            if (customFieldEntry != null)
            {
                customFieldEntries.Add(customFieldEntry);
            }
            
            return new LogReportDTO(
                logId,
                logShiftPattern.IdValue,
                logShiftPattern.Name,
                createdShiftStartDateTime,
                functionalLocationName,
                flocDescription,
                unitFloc,
                unitFlocDescription,
                lastModifiedByFullNameWithUserName,
                logDateTime,
                plainTextComments,
                rtfComments,
                customFieldEntries,
                new List<string> { GetFunctionalLocationNameWithDescription(reader) }
                );
        }

        private static LogReportDTO PopulateInstanceForLogReportDto(SqlDataReader reader)
        {
            long logId = GetId(reader);
            string unitFloc = reader.Get<string>("Unit");
            string flocDescription = reader.Get<string>("FunctionalLocationDescription");
            string unitFlocDescription = reader.Get<string>("UnitDescription");
            string lastModifiedByFullNameWithUserName = reader.GetUser("LastModifiedByFirstName", "LastModifiedByLastName", "LastModifiedByUserName");
            DateTime logDateTime = GetLogDateTime(reader);

            ShiftPattern logShiftPattern = GetLogShiftPattern(reader);
            UserShift userShift = new UserShift(logShiftPattern, logDateTime);
            Time shiftStartTime = new Time(userShift.StartDateTime);
            DateTime createdShiftStartDateTime = new Date(userShift.StartDateTime).CreateDateTime(shiftStartTime);

            string plainTextComments = reader.Get<string>("PlainTextComments");
            string rtfComments = reader.Get<string>("RtfComments");
            string functionalLocationName = reader.Get<string>("FunctionalLocationName");
            
            return new LogReportDTO(
                logId,
                logShiftPattern.IdValue,
                logShiftPattern.Name,
                createdShiftStartDateTime,
                functionalLocationName,
                flocDescription,
                unitFloc,
                unitFlocDescription,
                lastModifiedByFullNameWithUserName,
                logDateTime,
                plainTextComments,
                rtfComments
                );
        }
        
        public List<LogDTO> QueryByActionItem(long actionItemId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ActionItemId", actionItemId);
            List<LogDTO> result = GetDtos(command, QUERY_BY_ACTION_ITEM);
            ConvertChildrenWithoutParentsToParentsAndFlag(result);
            return result;
        }

        public List<LogDTO> QueryByActionItemDefinition(long actionItemDefinitionId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@ActionItemDefinitionId", actionItemDefinitionId);
            List<LogDTO> result = GetDtos(command, QUERY_BY_ACTION_ITEM_DEFINITION);
            ConvertChildrenWithoutParentsToParentsAndFlag(result);
            return result;            
        }

        public List<LogDTO> QueryByWorkPermitEdmonton(long workPermitEdmontonId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkPermitEdmontonId", workPermitEdmontonId);
            List<LogDTO> result = GetDtos(command, QUERY_BY_WORK_PERMIT_EDMONTON);
            ConvertChildrenWithoutParentsToParentsAndFlag(result);
            return result;
        }

        public List<LogDTO> QueryByWorkPermitLubes(long workPermitLubesId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkPermitLubesId", workPermitLubesId);
            List<LogDTO> result = GetDtos(command, QUERY_BY_WORK_PERMIT_LUBES);
            ConvertChildrenWithoutParentsToParentsAndFlag(result);
            return result;
        }
        public List<LogDTO> QueryByWorkPermitMontreal(long workPermitMontrealId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkPermitMontrealId", workPermitMontrealId);
            List<LogDTO> result = GetDtos(command, QUERY_BY_WORK_PERMIT_MONTREAL);
            ConvertChildrenWithoutParentsToParentsAndFlag(result);
            return result;
        }

        //RITM0301321 mangesh
        public List<LogDTO> QueryByWorkPermitMuds(long workPermitMudsId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@WorkPermitMudsId", workPermitMudsId);
            List<LogDTO> result = GetDtos(command, QUERY_BY_WORK_PERMIT_MUDS);
            ConvertChildrenWithoutParentsToParentsAndFlag(result);
            return result;
        }

        public List<LogDTO> QueryByTargetAlert(long targetAlertId)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@TargetAlertId", targetAlertId);
            List<LogDTO> result = GetDtos(command, QUERY_BY_TARGET_ALERT);
            ConvertChildrenWithoutParentsToParentsAndFlag(result);
            return result;
        }


        public List<LogDTO> QueryById(List<long> logIds)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvLogIds", logIds.BuildCommaSeparatedList(item => item.ToString(NumberFormatInfo.InvariantInfo)));

            List<LogDTO> results = GetDtos(command, QUERY_BY_ID_STORED_PROCEDURE);
            return results;
        }

        private static List<LogDTO> GetDtos(SqlCommand command, string query)
        {
            return GetDtos(command, query, null);
        }

        private static List<LogDTO> GetDtos(SqlCommand command, string query, User readByUser)
        {
            
            Dictionary<long, LogDTO> result = new Dictionary<long, LogDTO>();
            command.CommandText = query;

            command.QueryForListResult(PopulateExceptionHandler, reader =>
                {
                    long id = GetId(reader);
                    if (result.ContainsKey(id))
                    {
                        LogDTO dto = result[id];
                        dto.AddVisibilityGroup(GetVisibilityGroupName(reader));
                    }
                    else
                    {
                        result.Add(id, PopulateInstance(reader, readByUser));
                    }
                });

            List<LogDTO> logDtos = new List<LogDTO>(result.Values);
            return logDtos;
        }

        private static void PopulateExceptionHandler(OLTException ex)
        {
            logger.Error("There was an error querying a Log DTO", ex);
        }

        public List<LogDTO> QueryOpEngLogsByFunctionalLocations(IFlocSet flocSet, DateTime? startOfRange, DateTime? endOfRange, List<long> readableVisibilityGroupIds)
        {
            if (startOfRange.HasNoValue())
            {
                startOfRange = DateTimeExtensions.CreateSQLServerFriendlyMinDate();
            }

            if (endOfRange.HasNoValue())
            {
                endOfRange = DateTimeExtensions.CreateSQLServerFriendlyMaxDate();
            }

            string csvFunctionalLocationIds =
                flocSet.FunctionalLocations.BuildIdStringFromList();

            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", csvFunctionalLocationIds);
            command.AddParameter("@StartOfDateRange", startOfRange);
            command.AddParameter("@EndOfDateRange", endOfRange);
            command.AddParameter("@CsvVisibilityGroupIds", readableVisibilityGroupIds == null ? null : readableVisibilityGroupIds.ToCommaSeparatedString());

            List<LogDTO> result = GetDtos(command, QUERY_OP_ENG_BY_CSV_FUNCTIONALLOCATIN_IDS);

            ConvertChildrenWithoutParentsToParentsAndFlag(result);

            return result;
        }

        public List<LogDTO> GetLogsWhereLoggedDateOrActualLoggedDateMatchRange(IFlocSet flocSet, UserShift userShift, List<long> readableVisibilityGroupIds)
        {            
            SqlCommand command = ManagedCommand;

            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@CreatedShiftPatternId", userShift.ShiftPatternId);

            command.AddParameter("@StartOfDateRange", userShift.StartDateTimeWithPadding);
            command.AddParameter("@EndOfDateRange", userShift.EndDateTimeWithPadding);

            command.AddParameter("@CsvVisibilityGroupIds", readableVisibilityGroupIds == null ? null : readableVisibilityGroupIds.ToCommaSeparatedString());

            List<LogDTO> result = GetDtos(command, QUERY_BY_LOGGED_DATE_OR_ACTUAL_LOGGED_DATE);

            ConvertChildrenWithoutParentsToParentsAndFlag(result);

            return result;
        }

        private static LogDTO PopulateInstance(SqlDataReader reader, User readByUser)
        {
            long id = GetId(reader);
            long? rootLogId = reader.Get<long?>("RootLogId");
            long? replyToLogId = reader.Get<long?>("ReplyToLogId");
            bool environmentalHealthSafetyFollowUp = GetEnvironmentalHealthSafetyFollowUp(reader);
            bool inspectionFollowUp = GetInspectionFollowUp(reader);
            bool operationsFollowUp = GetOperationsFollowUp(reader);
            bool processControlFollowUp = GetProcessControlFollowUp(reader);
            bool supervisionFollowUp = GetSupervisionFollowUp(reader);
            bool otherFollowUp = GetOtherFollowUp(reader);
            DateTime logDateTime = GetLogDateTime(reader);

            bool isOperatingEngineerLog = reader.Get<bool>("IsOperatingEngineerLog");
            long createdByRoleId = reader.Get<long>("CreatedByRoleId");

            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");
            long createdByUserId = reader.Get<long>("CreatedByUserId");
            string lastModifiedByFullNameWithUserName = reader.GetUser("LastModifiedByFirstName", "LastModifiedByLastName", "LastModifiedByUserName");
            DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
            bool hasChildren = reader.Get<bool>("HasChildren");
            int? logTypeId = reader.Get<int?>("ScheduleTypeId");
            long? logDefinitionId = reader.Get<long?>("LogDefinitionId");
            bool? logDefinitionDeleted = reader.Get<bool?>("LogDefinitionDeleted");
            
            ShiftPattern logShiftPattern = GetLogShiftPattern(reader);
            UserShift userShift = new UserShift(logShiftPattern, logDateTime);
            Date shiftStartDate = new Date(userShift.StartDateTime);
            Time shiftStartTime = new Time(userShift.StartDateTime);
            Date shiftEndDate = new Date(userShift.EndDateTime);
            Time shiftEndTime = new Time(userShift.EndDateTime);

            int sourceId = reader.Get<int>("SourceId");

            string workAssignmentName = GetWorkAssignmentName(reader);
            string functionalLocations = reader.Get<string>("FunctionalLocations");
            string visibilityGroupName = GetVisibilityGroupName(reader);

            bool isRecurring = false;

            if (logTypeId.HasValue)
            {
                //TODO: (Performance) Why can't we check the Schedule type to determine this? Sure, we might add new schedule types...
                ISchedule schedule = ScheduleDao.PopulateScheduleInstanceForDTO(reader);
                isRecurring = schedule.IsRecurring;
            }

            bool recommendForShiftSummary = GetRecommendForShiftSummary(reader);
            string allComments = reader.Get<string>("PlainTextComments");

            bool? hasBeenReadByQueryUser = null;
            if (readByUser != null)
            {
                long? readByUserId = reader.Get<long?>("ReadByUserId");
                hasBeenReadByQueryUser = readByUserId != null;
            }

            LogDTO result = new LogDTO(id,
                                       rootLogId,
                                       replyToLogId,
                                       functionalLocations,
                                       inspectionFollowUp,
                                       processControlFollowUp,
                                       operationsFollowUp,
                                       supervisionFollowUp,
                                       environmentalHealthSafetyFollowUp,
                                       otherFollowUp,
                                       logDateTime,                                       
                                       createdByUserId,
                                       GetCreatedByFirstName(reader),
                                       GetCreatedByLastName(reader),
                                       GetCreatedByUserName(reader),
                                       lastModifiedByFullNameWithUserName,
                                       createdDateTime,
                                       lastModifiedDateTime,
                                       logShiftPattern.IdValue,
                                       shiftStartDate,
                                       shiftStartTime,
                                       shiftEndDate,
                                       shiftEndTime,
                                       logShiftPattern.Name,
                                       hasChildren,
                                       isRecurring,
                                       sourceId,
                                       isOperatingEngineerLog,
                                       createdByRoleId,
                                       logDefinitionId,
                                       logDefinitionDeleted,
                                       recommendForShiftSummary,
                                       workAssignmentName,
                                       allComments, 
                                       hasBeenReadByQueryUser,
                                       new List<string> { visibilityGroupName });

            return result;
            
        }

        private static bool GetRecommendForShiftSummary(SqlDataReader reader)
        {
            return reader.Get<bool>("RecommendForShiftSummary");
        }

        private static string GetWorkAssignmentName(SqlDataReader reader)
        {
            return reader.Get<string>("WorkAssignmentName");
        }
     
        private static DateTime GetLogDateTime(SqlDataReader reader)
        {
            return reader.Get<DateTime>("LogDateTime");
        }

        private static bool GetOtherFollowUp(SqlDataReader reader)
        {
            return reader.Get<bool>("OtherFollowUp");
        }

        private static bool GetSupervisionFollowUp(SqlDataReader reader)
        {
            return reader.Get<bool>("SupervisionFollowUp");
        }

        private static bool GetProcessControlFollowUp(SqlDataReader reader)
        {
            return reader.Get<bool>("ProcessControlFollowUp");
        }

        private static bool GetOperationsFollowUp(SqlDataReader reader)
        {
            return reader.Get<bool>("OperationsFollowUp");
        }

        private static bool GetInspectionFollowUp(SqlDataReader reader)
        {
            return reader.Get<bool>("InspectionFollowUp");
        }

        private static bool GetEnvironmentalHealthSafetyFollowUp(SqlDataReader reader)
        {
            return reader.Get<bool>("EHSFollowup");
        }

        private static string GetCreatedByUserName(SqlDataReader reader)
        {
            return reader.Get<string>("CreatedByUserName");
        }

        private static string GetCreatedByLastName(SqlDataReader reader)
        {
            return reader.Get<string>("CreatedByLastName");
        }

        private static string GetCreatedByFirstName(SqlDataReader reader)
        {
            return reader.Get<string>("CreatedByFirstName");
        }

        private static string GetVisibilityGroupName(SqlDataReader reader)
        {
            return reader.Get<string>("VisibilityGroupName");
        }

        private static long GetId(SqlDataReader reader)
        {
            return reader.Get<long>("LogId");
        }
        
        private static ShiftPattern GetLogShiftPattern(SqlDataReader reader)
        {
            long shiftPatternId = reader.Get<long>("CreatedShiftId");
            string shiftName = reader.Get<string>("CreatedShiftName");

            TimeSpan createdShiftStartDateTime = reader.Get<TimeSpan>("CreatedShiftStartDateTime");
            TimeSpan createdShiftEndDateTime = reader.Get<TimeSpan>("CreatedShiftEndDateTime");

            TimeSpan preShiftPaddingInMinutes = new TimeSpan(0, reader.Get<int>("PreShiftPaddingInMinutes"), 0);
            TimeSpan postShiftPaddingInMinutes = new TimeSpan(0, reader.Get<int>("PostShiftPaddingInMinutes"), 0);

            ShiftPattern logShiftPattern = new ShiftPattern
                (
                shiftPatternId,
                shiftName,
                new Time(createdShiftStartDateTime),
                new Time(createdShiftEndDateTime),
                DONT_CARE_SHIFT_CREATION_DATE,
                new Site(DONT_CARE_SITE_ID, string.Empty, OltTimeZoneInfo.Local, new List<Plant>(), ""),
                preShiftPaddingInMinutes, postShiftPaddingInMinutes);

            return logShiftPattern;
        }

        public List<MarkedAsReadReportLogDTO> QueryDTOByParentFlocListAndMarkedAsRead(
            DateTime startOfRange, DateTime endOfRange, IList<FunctionalLocation> parentFlocs)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@StartOfDateRange", startOfRange);
            command.AddParameter("@EndOfDateRange", endOfRange);
            command.AddParameter("@CsvFLOCIds", parentFlocs.BuildIdStringFromList());
            command.CommandText = QUERY_DTO_BY_PARENT_FLOC_LIST_AND_MARKED_AS_READ;

            Dictionary<long, MarkedAsReadReportLogDTO> result = new Dictionary<long, MarkedAsReadReportLogDTO>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = GetId(reader);
                    if (result.ContainsKey(id))
                    {
                        MarkedAsReadReportLogDTO dto = result[id];
                        dto.AddReadByUser(GetReadByUser(reader));
                    }
                    else
                    {
                        result.Add(id, PopulateMarkedAsReadDtoInstance(reader));
                    }
                }
            }

            return new List<MarkedAsReadReportLogDTO>(result.Values);
        }
     
        private static ItemReadBy GetReadByUser(SqlDataReader reader)
        {
            string first = reader.Get<string>("ReadByFirstName");
            string last = reader.Get<string>("ReadByLastName");
            string userName = reader.Get<string>("ReadByUserName");
            string fullName = User.ToFullNameWithUserName(last, first, userName);

            DateTime dateTime = reader.Get<DateTime>("ReadByDateTime");

            return new ItemReadBy(fullName, dateTime);
        }

        private static MarkedAsReadReportLogDTO PopulateMarkedAsReadDtoInstance(SqlDataReader reader)
        {
            int type = reader.Get<byte>("LogType");
            LogType logType = type.ToEnum<LogType>();
            string logTypeText = logType == LogType.DailyDirective ? MarkedAsReadReportLogDTO.DAILY_DIRECTIVE_LOG_TYPE_TEXT : MarkedAsReadReportLogDTO.STANDARD_LOG_TYPE_TEXT;
            
            DateTime logDateTime = GetLogDateTime(reader);
            string lastModifiedByFullNameWithUserName = reader.GetUser("LastModifiedByFirstName", "LastModifiedByLastName", "LastModifiedByUserName");

            ShiftPattern logShiftPattern = GetLogShiftPattern(reader);
            UserShift userShift = new UserShift(logShiftPattern, logDateTime);
            Date shiftStartDate = new Date(userShift.StartDateTime);
            string shiftDisplayName = String.Format("{0} - {1}", shiftStartDate, logShiftPattern.Name);

            string comments = reader.Get<string>("PlainTextComments");
            string functionalLocations = reader.Get<string>("FunctionalLocations");

            MarkedAsReadReportLogDTO result = new MarkedAsReadReportLogDTO(
                logTypeText,
                logDateTime,
                shiftDisplayName,
                functionalLocations,
                lastModifiedByFullNameWithUserName,
                comments,
                new List<ItemReadBy> { GetReadByUser(reader) });

            return result;
        }

        //RITM0164968-  mangesh
        public List<HasCommentsDTO> QueryByShiftHandoverQuestionnaireLogItem(long shiftHandoverQuestionnaireId)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = "QueryLogsByShiftHandoverQuestionnaireLogItem";
            command.AddParameter("@ShiftHandoverId", shiftHandoverQuestionnaireId);

            Dictionary<long, HasCommentsDTO> result = new Dictionary<long, HasCommentsDTO>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = GetId(reader);
                    if (result.ContainsKey(id))
                    {
                        HasCommentsDTO dto = result[id];
                        dto.AddCustomFieldEntry(GetCustomFieldEntry(reader));
                        dto.AddCustomField(GetCustomField(reader));
                    }
                    else
                    {
                        result.Add(id, PopulateHasCategorizedCommentsDtoInstance(reader));
                    }
                }
            }

            return new List<HasCommentsDTO>(result.Values);
        }

        public List<HasCommentsDTO> QueryByShiftHandoverQuestionnaire(long shiftHandoverQuestionnaireId,long SiteID)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = "QueryLogsByShiftHandoverQuestionnaire";
            command.AddParameter("@ShiftHandoverId", shiftHandoverQuestionnaireId);
            command.AddParameter("@SiteID",SiteID);
            
            Dictionary<long, HasCommentsDTO> result = new Dictionary<long, HasCommentsDTO>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = GetId(reader);
                    if (result.ContainsKey(id))
                    {
                        HasCommentsDTO dto = result[id];
                        dto.AddCustomFieldEntry(GetCustomFieldEntry(reader));
                        dto.AddCustomField(GetCustomField(reader));
                    }
                    else
                    {
                        //Mukesh for Log Image
                      HasCommentsDTO CommentDTO=  PopulateHasCategorizedCommentsDtoInstance(reader);
                      CommentDTO.SummaryLogImagelist = SetLogImage(id);
                      result.Add(id, CommentDTO);
                        //End Mukesh for Log Image
                        
                        //result.Add(id, PopulateHasCategorizedCommentsDtoInstance(reader));
                    }
                }
            }

                       
           


            return new List<HasCommentsDTO>(result.Values);

        }

        public List<HasCommentsDTO> QueryByParentFlocListDateRangeShiftAndWorkAssignment(DateTime startOfRange, DateTime endOfRange, IFlocSet flocSet, long shiftId, long? workAssignmentId, long userId)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = QUERY_BY_PARENT_FLOC_DATE_RANGE_SHIFT_AND_ASSIGNMENT;
            command.AddParameter("@StartOfDateRange", startOfRange);
            command.AddParameter("@EndOfDateRange", endOfRange);
            command.AddParameter("@CsvFLOCIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@ShiftId", shiftId);
            command.AddParameter("@UserId", userId);

            if (workAssignmentId.HasValue)
            {
                command.AddParameter("@WorkAssignmentId", workAssignmentId);
            }

            Dictionary<long, HasCommentsDTO> result = new Dictionary<long, HasCommentsDTO>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = GetId(reader);
                    if (result.ContainsKey(id))
                    {
                        HasCommentsDTO dto = result[id];
                        dto.AddCustomFieldEntry(GetCustomFieldEntry(reader));
                        dto.AddCustomField(GetCustomField(reader));
                    }
                    else
                    {
                        result.Add(id, PopulateHasCategorizedCommentsDtoInstance(reader));
                    }
                }
            }

            return new List<HasCommentsDTO>(result.Values);
        }

        // Flexi shift handover  amit shukla RITM0185797
        public List<HasCommentsDTO> QueryByParentFlocListDateRangeShiftAndWorkAssignment(DateTime startOfRange, DateTime endOfRange, IFlocSet flocSet, long shiftId, long? workAssignmentId, long userId, bool IsFlexibleshiftHandover)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = QUERY_BY_PARENT_FLOC_DATE_RANGE_SHIFT_AND_ASSIGNMENT;
            command.AddParameter("@StartOfDateRange", startOfRange);
            command.AddParameter("@EndOfDateRange", endOfRange);
            command.AddParameter("@CsvFLOCIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@ShiftId", shiftId);
            command.AddParameter("@UserId", userId);
            command.AddParameter("@IsFlexible", IsFlexibleshiftHandover);
            if (workAssignmentId.HasValue)
            {
                command.AddParameter("@WorkAssignmentId", workAssignmentId);
            }

            Dictionary<long, HasCommentsDTO> result = new Dictionary<long, HasCommentsDTO>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = GetId(reader);
                    if (result.ContainsKey(id))
                    {
                        HasCommentsDTO dto = result[id];
                        dto.AddCustomFieldEntry(GetCustomFieldEntry(reader));
                        dto.AddCustomField(GetCustomField(reader));
                    }
                    else
                    {
                        result.Add(id, PopulateHasCategorizedCommentsDtoInstance(reader));
                    }
                }
            }

            return new List<HasCommentsDTO>(result.Values);
        }

        public List<LogDTO> QueryByRootFLOCsWithMatchingFLOCAncestorsAndDescendants(
            LogType logType, DateTime? startOfRange, DateTime? endOfRange, IFlocSet flocSet, User readByUser, List<long> clientReadableVisibilityGroupIds)
        {
            if (!startOfRange.HasValue)
            {
                startOfRange = DateTimeExtensions.CreateSQLServerFriendlyMinDate();
            }

            if (!endOfRange.HasValue)
            {
                endOfRange = DateTimeExtensions.CreateSQLServerFriendlyMaxDate();
            }

            SqlCommand command = ManagedCommand;
            command.AddParameter("@LogType", logType);
            command.AddParameter("@StartOfDateRange", startOfRange);
            command.AddParameter("@EndOfDateRange", endOfRange);
            command.AddParameter("@CsvFLOCIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@CsvVisibilityGroupIds", clientReadableVisibilityGroupIds == null ? null : clientReadableVisibilityGroupIds.ToCommaSeparatedString());
            if (readByUser != null)
            {
                command.AddParameter("@ReadByUserId", readByUser.IdValue);
            }

            List<LogDTO> results = GetDtos(command, QUERY_BY_USER_ROOT_FLOC_DIRECT_ANCESTORS_AND_DESCENDANTS, readByUser);

            ConvertChildrenWithoutParentsToParentsAndFlag(results);

            return results;
        }


        //Added for view based on role permisiion

        public List<LogDTO> QueryByRootFLOCsWithMatchingFLOCAncestorsAndDescendants(
          LogType logType, DateTime? startOfRange, DateTime? endOfRange, IFlocSet flocSet, User readByUser, List<long> clientReadableVisibilityGroupIds,long ? RoleId)
        {
            if (!startOfRange.HasValue)
            {
                startOfRange = DateTimeExtensions.CreateSQLServerFriendlyMinDate();
            }

            if (!endOfRange.HasValue)
            {
                endOfRange = DateTimeExtensions.CreateSQLServerFriendlyMaxDate();
            }

            SqlCommand command = ManagedCommand;
            command.AddParameter("@LogType", logType);
            command.AddParameter("@StartOfDateRange", startOfRange);
            command.AddParameter("@EndOfDateRange", endOfRange);
            command.AddParameter("@CsvFLOCIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@CsvVisibilityGroupIds", clientReadableVisibilityGroupIds == null ? null : clientReadableVisibilityGroupIds.ToCommaSeparatedString());
            if (RoleId.HasValue)
            {
                command.AddParameter("@RoleId", RoleId);
            }
            if (readByUser != null)
            {
                command.AddParameter("@ReadByUserId", readByUser.IdValue);
            }

            List<LogDTO> results = GetDtos(command, QUERY_BY_USER_ROOT_FLOC_DIRECT_ANCESTORS_AND_DESCENDANTS, readByUser);

            ConvertChildrenWithoutParentsToParentsAndFlag(results);

            return results;
        }

        public List<LogDTO> QueryByFunctionalLocations(IFlocSet flocSet, DateRange range, List<long> clientReadableVisibilityGroupIds,long ? RoleId)
        {
            return QueryByRootFLOCsWithMatchingFLOCAncestorsAndDescendants(LogType.Standard,
                                                                           range.SqlFriendlyStart,
                                                                           range.SqlFriendlyEnd,
                                                                           flocSet,
                                                                           null,
                                                                           clientReadableVisibilityGroupIds,RoleId);
        }
        //End

        private static void AddCustomFieldEntry(SqlDataReader reader, HasCommentsDTO dto)
        {
            long? id = reader.Get<long?>("LogCustomFieldEntryId");

            if (id == null || dto.CustomFieldEntries.Exists(e => e.Id == id))
            {
                return;
            }
            
            dto.CustomFieldEntries.Add(GetCustomFieldEntry(reader));
        }

        private static void AddCustomField(SqlDataReader reader, HasCommentsDTO dto)
        {
            long? id = reader.Get<long?>("ActualCustomFieldId");

            if (id == null || dto.CustomFields.Exists(cf => cf.Id == id))
            {
                return;
            }

            dto.CustomFields.Add(GetCustomField(reader));
        }

        private static CustomField GetCustomField(SqlDataReader reader)
        {
            long? id = reader.Get<long?>("ActualCustomFieldId");

            if (id == null)
            {
                return null;
            }

            string name = reader.Get<string>("ActualCustomFieldName");
            int displayOrder = reader.Get<int>("ActualCustomFieldDisplayOrder");
            long customFieldGroupId = reader.Get<long>("CustomFieldGroupId");
            long originCustomFieldGroupId = reader.Get<long>("OriginCustomFieldGroupId");
            long originCustomFieldId = reader.Get<long>("OriginCustomFieldId");
            CustomFieldType type = CustomFieldType.FindById(reader.Get<byte>("ActualTypeId"));
            byte phdLinkTypeId = reader.Get<byte>("ActualPhdLinkTypeId");
            CustomFieldPhdLinkType phdLinkType = phdLinkTypeId.ToEnum<CustomFieldPhdLinkType>();

            return new CustomField(id, name, displayOrder, customFieldGroupId, originCustomFieldGroupId, originCustomFieldId, null, type, phdLinkType, null);
        }

        private static CustomFieldEntry GetCustomFieldEntry(SqlDataReader reader)
        {
            long? id = reader.Get<long?>("LogCustomFieldEntryId");

            if (id == null)
            {
                return null;
            }

            string name = reader.Get<string>("CustomFieldName");            
            string fieldEntry = reader.Get<string>("FieldEntry");
            decimal? numericFieldEntry = reader.Get<decimal?>("NumericFieldEntry");
            int displayOrder = reader.Get<int>("DisplayOrder");
            CustomFieldType type = CustomFieldType.FindById(reader.Get<byte>("TypeId"));
            long customFieldId = reader.Get<long>("CustomFieldId");
            
            byte phdLinkTypeId = reader.Get<byte>("PhdLinkTypeId");
            CustomFieldPhdLinkType phdLinkType = phdLinkTypeId.ToEnum<CustomFieldPhdLinkType>();

            //E&U Custom Field changes start by mangesh
            decimal? greaterthan = IsColumnExists(reader, "GreaterThanValue") ? reader.Get<decimal?>("GreaterThanValue") : null;
            decimal? lessthan = IsColumnExists(reader, "LessThanValue") ? reader.Get<decimal?>("LessThanValue") : null;
            decimal? maxvalue = IsColumnExists(reader, "RangeGreaterThanValue") ? reader.Get<decimal?>("RangeGreaterThanValue") : null;
            decimal? minvalue = IsColumnExists(reader, "RangeLessThanValue") ? reader.Get<decimal?>("RangeLessThanValue") : null;
            string color = IsColumnExists(reader, "COLOR") ? reader.Get<string>("COLOR") : "B";

            if (greaterthan != null && greaterthan >= numericFieldEntry)
            {
                color = "R";
            }

            if (lessthan != null && lessthan <= numericFieldEntry)
            {
                color = "R";
            }

            if (maxvalue != null && minvalue != null
                && minvalue > numericFieldEntry || maxvalue < numericFieldEntry)
            {
                color = "R";
            }
            return new CustomFieldEntry(id, customFieldId, name, fieldEntry, numericFieldEntry,null, displayOrder, type, phdLinkType, minvalue, maxvalue, greaterthan,lessthan, color,null);   //ayman action item reading

            //return new CustomFieldEntry(id, customFieldId, name, fieldEntry, numericFieldEntry, displayOrder, type, phdLinkType);
            //E&U Custom Field changes end 

            
        }

        private static HasCommentsDTO PopulateHasCategorizedCommentsDtoInstance(SqlDataReader reader)
        {
            DateTime logDateTime = GetLogDateTime(reader);

            string firstName = reader.Get<string>("CreatedByFirstName");
            string lastName = reader.Get<string>("CreatedByLastName");
            long createdByUserId = reader.Get<long>("CreatedByUserId");
            string fullName = User.ToFullName(firstName, lastName);

            string rtfComments = reader.Get<string>("RtfComments");
            string plainTextComments = reader.Get<string>("PlainTextComments");
            string functionalLocationList = reader.Get<string>("FunctionalLocations");

            //decimal? greaterthan = IsColumnExists(reader, "GreaterThanValue") ? reader.Get<decimal?>("GreaterThanValue") : null;
            //decimal? lessthan = IsColumnExists(reader, "LessThanValue") ? reader.Get<decimal?>("LessThanValue") : null;
            //decimal? maxvalue = IsColumnExists(reader, "RangeGreaterThanValue") ? reader.Get<decimal?>("RangeGreaterThanValue") : null;
            //decimal? minvalue = IsColumnExists(reader, "RangeLessThanValue") ? reader.Get<decimal?>("RangeLessThanValue") : null;

            HasCommentsDTO result = new HasCommentsDTO(
                GetId(reader),
                logDateTime,
                fullName,
                createdByUserId,
                functionalLocationList,
                null,
                null,
                rtfComments,
                plainTextComments
                //minvalue, maxvalue, greaterthan, lessthan
                );

           

            AddCustomFieldEntry(reader, result);
            AddCustomField(reader, result);

            return result;
        }

        //Mukesh for Log Image
        public List<LogImage> SetLogImage(long Id)
        {

            SqlCommand command1 = new SqlCommand();
            command1.Connection = ManagedCommand.Connection;
            command1.AddParameter("@LOGIDs", Id);
            command1.AddParameter("@RecordFor", (int)LogImage.RecordTypes.Log);
            command1.CommandText = "GetLOGImage";
            command1.CommandType = ManagedCommand.CommandType;
            SqlDataReader reader = command1.ExecuteReader();
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
          return lst;
        }

        private static bool IsColumnExists(System.Data.IDataReader dr, string columnName)
        {
            bool retVal = false;

            dr.GetSchemaTable().DefaultView.RowFilter = string.Format("ColumnName= '{0}'", columnName);
            if (dr.GetSchemaTable().DefaultView.Count > 0)
            {
                retVal = true;
            }
            return retVal;
        }

       
        //Mukesh-for Operator Round Messgae
       public List<ShiftLogMessage> QueryShiftLogMessage(IFlocSet Floc,long siteId)
        {
            List<ShiftLogMessage> Result = new List<ShiftLogMessage>();
            SqlCommand command = ManagedCommand;
            command.CommandText = "GetShiftLogMessageStaging";
            command.AddParameter("@CsvFlocIds", Floc.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@SiteId", siteId);

           return command.QueryForListResult<ShiftLogMessage>(PopulateShiftLogMessage, "GetShiftLogMessageStaging");
           
           
            
        }


       private ShiftLogMessage PopulateShiftLogMessage(SqlDataReader reader)
       {
           ShiftLogMessage objShiftLogMessage = new ShiftLogMessage();
           objShiftLogMessage.Id = reader.Get<int>("ShiftLogMessageStagingId");
           objShiftLogMessage.UserName = reader.Get<string>("UserName");
           objShiftLogMessage.Floc = reader.Get<string>("Floc");
           objShiftLogMessage.Source = reader.Get<string>("Source");
           objShiftLogMessage.MessageTimeStamp = reader.Get<DateTime>("MessageTimeStamp");
           objShiftLogMessage.Message = reader.Get<string>("Message");
            return objShiftLogMessage;
       }


    }
}