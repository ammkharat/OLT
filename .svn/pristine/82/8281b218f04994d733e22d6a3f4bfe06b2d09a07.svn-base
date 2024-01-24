using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class SummaryLogDTODao : AbstractManagedDao, ISummaryLogDTODao
    {
        private const string QUERY_DTO_BY_PARENT_FLOC_LIST = "QuerySummaryLogDTOsByParentFlocList";
        private const string QUERY_DTO_BY_PARENT_FLOC_LIST_AND_MARKED_AS_READ = "QuerySummaryLogDTOsByParentFlocListAndMarkedAsRead";

        public List<SummaryLogDTO> QueryDTOsByParentFlocList(
            DateTime? startOfRange, DateTime? endOfRange, IFlocSet flocSet, List<long> clientReadableVisibilityGroupIds)
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
            command.AddParameter("@StartOfDateRange", startOfRange);
            command.AddParameter("@EndOfDateRange", endOfRange);
            command.AddParameter("@CsvFLOCIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@CsvVisibilityGroupIds", clientReadableVisibilityGroupIds == null ? null : clientReadableVisibilityGroupIds.ToCommaSeparatedString());

            List<SummaryLogDTO> result = GetDtos(command, QUERY_DTO_BY_PARENT_FLOC_LIST);
            
            return result;
        }

        //Function added to view based on rolepermission
        public List<SummaryLogDTO> QueryDTOsByParentFlocList(
           DateTime? startOfRange, DateTime? endOfRange, IFlocSet flocSet, List<long> clientReadableVisibilityGroupIds,long? RoleId)
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
            command.AddParameter("@StartOfDateRange", startOfRange);
            command.AddParameter("@EndOfDateRange", endOfRange);
            command.AddParameter("@CsvFLOCIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@CsvVisibilityGroupIds", clientReadableVisibilityGroupIds == null ? null : clientReadableVisibilityGroupIds.ToCommaSeparatedString());
            command.AddParameter("@RoleId", RoleId);

            List<SummaryLogDTO> result = GetDtos(command, QUERY_DTO_BY_PARENT_FLOC_LIST);

            return result;
        }


        private static List<SummaryLogDTO> GetDtos(SqlCommand command, string query)
        {
            Dictionary<long, SummaryLogDTO> result = new Dictionary<long, SummaryLogDTO>();

            command.CommandText = query;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long id = GetId(reader);
                    if (result.ContainsKey(id))
                    {
                        SummaryLogDTO dto = result[id];
                        dto.AddVisibilityGroup(GetVisibilityGroupName(reader));
                    }
                    else
                    {
                        result.Add(id, PopulateInstance(reader));
                    }
                }
            }

            return new List<SummaryLogDTO>(result.Values);
        }

        private static SummaryLogDTO PopulateInstance(SqlDataReader reader)
        {
            long id = GetId(reader);   
            string flocList = GetFunctionalLocationName(reader);
            string visibilityGroupName = GetVisibilityGroupName(reader);

            bool environmentalHealthSafetyFollowUp = reader.Get<bool>("EHSFollowup");
            bool inspectionFollowUp = reader.Get<bool>("InspectionFollowUp");
            bool operationsFollowUp = reader.Get<bool>("OperationsFollowUp");
            bool processControlFollowUp = reader.Get<bool>("ProcessControlFollowUp");
            bool supervisionFollowUp = reader.Get<bool>("SupervisionFollowUp");
            bool otherFollowUp = reader.Get<bool>("OtherFollowUp");
            DateTime logDateTime = reader.Get<DateTime>("LogDateTime");                                        
            DateTime createdDateTime = reader.Get<DateTime>("CreatedDateTime");                                        

            long createdByUserId = reader.Get<long>("CreatedByUserId");
            long createdByRoleId = reader.Get<long>("CreatedByRoleId");

            string lastModifiedByFirstName = reader.Get<string>("LastModifiedByFirstName");
            string lastModifiedByLastName = reader.Get<string>("LastModifiedByLastName");
            string lastModifiedByUserName = reader.Get<string>("LastModifiedByUserName");
            string lastModifiedByFullNameWithUserName =
                User.ToFullNameWithUserName(lastModifiedByLastName, lastModifiedByFirstName, lastModifiedByUserName);

            string createdByFirstName = reader.Get<string>("CreatedByFirstName");
            string createdByLastName = reader.Get<string>("CreatedByLastName");
            string createdByUserName =  reader.Get<string>("CreatedByUserName");
            string createdByFullNameWithUserName =
                User.ToFullNameWithUserName(createdByLastName, createdByFirstName, createdByUserName);

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
                LogDTODao.DONT_CARE_SHIFT_CREATION_DATE,
                new Site(LogDTODao.DONT_CARE_SITE_ID, string.Empty, OltTimeZoneInfo.Local, new List<Plant>(), string.Empty),
                preShiftPaddingInMinutes, postShiftPaddingInMinutes);

            var userShift = new UserShift(logShiftPattern, logDateTime);

            Date shiftStartDate = new Date(userShift.StartDateTime);
            Time shiftStartTime = new Time(userShift.StartDateTime);

            Date shiftEndDate = new Date(userShift.EndDateTime);
            Time shiftEndTime = new Time(userShift.EndDateTime);
           
            string workAssignmentName = reader.Get<string>("WorkAssignmentName");

            string comments = reader.Get<string>("Comments");

            long? rootLogId = reader.Get<long?>("RootLogId");
            long? replyToLogId = reader.Get<long?>("ReplyToLogId");
            bool hasChildren = reader.Get<bool>("HasChildren");

            DataSource dataSource = DataSource.GetById(reader.Get<int>("DataSourceId"));

            SummaryLogDTO result = new SummaryLogDTO(id,   
                                       dataSource,                   
                                       flocList,
                                       inspectionFollowUp,
                                       processControlFollowUp,
                                       operationsFollowUp,
                                       supervisionFollowUp,
                                       environmentalHealthSafetyFollowUp,
                                       otherFollowUp,
                                       logDateTime, 
                                       createdDateTime,
                                       createdByUserId,
                                       createdByRoleId,
                                       lastModifiedByFullNameWithUserName,
                                       createdByFullNameWithUserName,
                                       shiftPatternId,
                                       shiftStartDate,
                                       shiftStartTime,
                                       shiftEndDate,
                                       shiftEndTime,
                                       shiftName,                                                                              
                                       workAssignmentName,
                                       comments,
                                       rootLogId,
                                       replyToLogId,
                                       hasChildren,
                                       new List<string> { visibilityGroupName });

            return result;
        }

        private static long GetId(SqlDataReader reader)
        {
            return reader.Get<long>("SummaryLogId");
        }

        private static string GetFunctionalLocationName(SqlDataReader reader)
        {
            return reader.Get<string>("FullHierarchy");
        }

        private static string GetVisibilityGroupName(SqlDataReader reader)
        {
            return reader.Get<string>("VisibilityGroupName");
        }

        public List<MarkedAsReadReportLogDTO> QueryDTOByParentFlocListAndMarkedAsRead(
            DateTime startOfRange, DateTime endOfRange, IFlocSet flocSet)
        {
            SqlCommand command = ManagedCommand;
            command.AddParameter("@StartOfDateRange", startOfRange);
            command.AddParameter("@EndOfDateRange", endOfRange);
            command.AddParameter("@CsvFLOCIds", flocSet.FunctionalLocations.BuildIdStringFromList());
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
            DateTime loggedDate = reader.Get<DateTime>("LogDateTime");

            string lastModifiedByFirstName = reader.Get<string>("LastModifiedByFirstName");
            string lastModifiedByLastName = reader.Get<string>("LastModifiedByLastName");
            string lastModifiedByUserName = reader.Get<string>("LastModifiedByUserName");
            string lastModifiedByFullNameWithUserName =
                User.ToFullNameWithUserName(lastModifiedByLastName, lastModifiedByFirstName, lastModifiedByUserName);

            string comments = reader.Get<string>("PlainTextComments");

            long shiftPatternId = reader.Get<long>("CreatedShiftId");
            string shiftName = reader.Get<string>("CreatedShiftName");

            TimeSpan createdShiftStartDateTime = reader.Get<TimeSpan>("CreatedShiftStartDateTime");
            TimeSpan createdShiftEndDateTime = reader.Get<TimeSpan>("CreatedShiftEndDateTime");

            TimeSpan preShiftPaddingInMinutes = new TimeSpan(0, reader.Get<int>("PreShiftPaddingInMinutes"), 0);
            TimeSpan postShiftPaddingInMinutes = new TimeSpan(0, reader.Get<int>("PostShiftPaddingInMinutes"), 0);

            string functionalLocations = reader.Get<string>("FunctionalLocations");

            ShiftPattern logShiftPattern = new ShiftPattern
                (
                shiftPatternId,
                shiftName,
                new Time(createdShiftStartDateTime),
                new Time(createdShiftEndDateTime),
                LogDTODao.DONT_CARE_SHIFT_CREATION_DATE,
                new Site(LogDTODao.DONT_CARE_SITE_ID, string.Empty, OltTimeZoneInfo.Local, new List<Plant>(), ""),
                preShiftPaddingInMinutes, postShiftPaddingInMinutes);

            UserShift userShift = new UserShift(logShiftPattern, loggedDate);
            Date shiftStartDate = new Date(userShift.StartDateTime);

            MarkedAsReadReportLogDTO result = new MarkedAsReadReportLogDTO(
                MarkedAsReadReportLogDTO.SUMMARY_LOG_TYPE_TEXT,
                loggedDate,
                String.Format("{0} - {1}", shiftStartDate, shiftName),
                functionalLocations,
                lastModifiedByFullNameWithUserName,
                comments,
                new List<ItemReadBy> {GetReadByUser(reader)});

            return result;
        }
    }
}
