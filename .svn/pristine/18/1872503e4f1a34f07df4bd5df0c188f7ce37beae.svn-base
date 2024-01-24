using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class CustomFieldTrendReportDTODao : AbstractManagedDao, ICustomFieldTrendReportDTODao
    {
        private const string QUERY_FOR_CUSTOM_FIELD_TREND_REPORT_LOGS = "QueryCustomFieldTrendReportDTOsForLogsByFlocDateRangeAndAssignment";
        private const string QUERY_FOR_CUSTOM_FIELD_TREND_REPORT_SUMMARY_LOGS = "QueryCustomFieldTrendReportDTOsForSummaryLogsByFlocDateRangeAndAssignment";
        private static readonly DateTime DONT_CARE_SHIFT_CREATION_DATE = DateTime.MinValue;
        private const long DONT_CARE_SITE_ID = 0;

        public List<CustomFieldTrendReportDTO> QueryCustomFieldTrendReportDataForSummaryLogs(IFlocSet flocSet, DateTime startDateTime, DateTime endDateTime, List<WorkAssignment> workAssignments, bool includeNullAssignment)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = QUERY_FOR_CUSTOM_FIELD_TREND_REPORT_SUMMARY_LOGS;

            AddCommonParameters(flocSet, startDateTime, endDateTime, workAssignments, includeNullAssignment, command);

            return ReadResults(command, CustomFieldTrendReportDTO.LogType.SummaryLog);
        }

        private List<CustomFieldTrendReportDTO> ReadResults(SqlCommand command, CustomFieldTrendReportDTO.LogType logType)
        {
            Dictionary<long, CustomFieldTrendReportDTO> result = new Dictionary<long, CustomFieldTrendReportDTO>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    long key = GetId(reader);

                    if (result.ContainsKey(key))
                    {
                        CustomFieldTrendReportDTO dto = result[key];

                        CustomFieldEntry customFieldEntry = GetCustomFieldEntry(reader);
                        dto.AddCustomFieldEntry(customFieldEntry);

                        CustomField customField = GetCustomField(reader);
                        dto.AddCustomField(customField);
                    }
                    else
                    {
                        CustomFieldTrendReportDTO dto = PopulateInstanceForCustomFieldTrendReportDTO(reader, logType);
                        result.Add(key, dto);
                    }
                }
            }

            return new List<CustomFieldTrendReportDTO>(result.Values);
        }

        private static void AddCommonParameters(IFlocSet flocSet, DateTime startDateTime, DateTime endDateTime,
                                                List<WorkAssignment> workAssignments, bool includeNullAssignment, SqlCommand command)
        {
            command.AddParameter("@CsvFLOCIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@CsvAssignmentIds", workAssignments.BuildIdStringFromList());
            command.AddParameter("@IncludeNullAssignment", includeNullAssignment);
            command.AddParameter("@StartOfDateRange", startDateTime);
            command.AddParameter("@EndOfDateRange", endDateTime);
        }

        public List<CustomFieldTrendReportDTO> QueryCustomFieldTrendReportDataForLogs(IFlocSet flocSet, DateTime startDateTime, DateTime endDateTime, List<WorkAssignment> workAssignments, bool includeNullAssignment, LogType logType)
        {
            SqlCommand command = ManagedCommand;
            command.CommandText = QUERY_FOR_CUSTOM_FIELD_TREND_REPORT_LOGS;

            AddCommonParameters(flocSet, startDateTime, endDateTime, workAssignments, includeNullAssignment, command);
            command.AddParameter("@LogType", logType);

            if (logType.Equals(LogType.Standard))
            {
                return ReadResults(command, CustomFieldTrendReportDTO.LogType.Standard);
            }

            if (logType.Equals(LogType.DailyDirective))
            {
                return ReadResults(command, CustomFieldTrendReportDTO.LogType.DailyDirective);
            }

            return new List<CustomFieldTrendReportDTO>();
        }

        private CustomFieldTrendReportDTO PopulateInstanceForCustomFieldTrendReportDTO(SqlDataReader reader, CustomFieldTrendReportDTO.LogType logType)
        {
            DateTime logDateTime = reader.Get<DateTime>("LogDateTime");
            string functionalLocations = reader.Get<String>("FunctionalLocations");
            string workAssignmentName = reader.Get<String>("WorkAssignmentName");

            CustomFieldEntry customFieldEntry = GetCustomFieldEntry(reader);
            CustomField customField = GetCustomField(reader);

            List<CustomFieldEntry> customFieldEntries = new List<CustomFieldEntry>();
            if (customFieldEntry != null)
            {
                customFieldEntries.Add(customFieldEntry);
            }

            List<CustomField> customFields = new List<CustomField>();
            if (customField != null)
            {
                customFields.Add(customField);
            }

            ShiftPattern shiftPattern = GetShiftPattern(reader);
            UserShift userShift = new UserShift(shiftPattern, logDateTime);
            Date shiftStartDate = new Date(userShift.StartDateTime);

            CustomFieldTrendReportDTO result = new CustomFieldTrendReportDTO(
                GetId(reader),
                logType,
                reader.GetUser("LastModifiedByFirstName", "LastModifiedByLastName", "LastModifiedByUserName"),
                logDateTime,
                shiftPattern.Name,
                shiftStartDate,
                functionalLocations,
                customFieldEntries,
                workAssignmentName,
                customFields);

            return result;
        }

        private static CustomFieldEntry GetCustomFieldEntry(SqlDataReader reader)
        {
            long? id = reader.Get<long?>("CustomFieldEntryId");

            if (id == null)
            {
                return null;
            }

            string name = reader.Get<string>("CustomFieldName");
            long customFieldId = reader.Get<long>("CustomFieldId");
            string fieldEntry = reader.Get<string>("FieldEntry");
            decimal? numericFieldEntry = reader.Get<decimal?>("NumericFieldEntry");
            int displayOrder = reader.Get<int>("DisplayOrder");
            CustomFieldType type = CustomFieldType.FindById(reader.Get<byte>("TypeId"));
            byte phdLinkTypeId = reader.Get<byte>("PhdLinkTypeId");
            CustomFieldPhdLinkType phdLinkType = phdLinkTypeId.ToEnum<CustomFieldPhdLinkType>();

            return new CustomFieldEntry(id, customFieldId, name, fieldEntry, numericFieldEntry,null, displayOrder, type, phdLinkType,null);      //ayman action item reading
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

        private static long GetId(SqlDataReader reader)
        {
            return reader.Get<long>("Id");
        }

        private static ShiftPattern GetShiftPattern(SqlDataReader reader)
        {
            long shiftPatternId = reader.Get<long>("ShiftId");
            string shiftName = reader.Get<string>("ShiftName");

            TimeSpan shiftStartDateTime = reader.Get<TimeSpan>("ShiftStartDateTime");
            TimeSpan shiftEndDateTime = reader.Get<TimeSpan>("ShiftEndDateTime");

            TimeSpan preShiftPaddingInMinutes = new TimeSpan(0, reader.Get<int>("PreShiftPaddingInMinutes"), 0);
            TimeSpan postShiftPaddingInMinutes = new TimeSpan(0, reader.Get<int>("PostShiftPaddingInMinutes"), 0);

            return new ShiftPattern
                (
                shiftPatternId,
                shiftName,
                new Time(shiftStartDateTime),
                new Time(shiftEndDateTime),
                DONT_CARE_SHIFT_CREATION_DATE,
                new Site(DONT_CARE_SITE_ID, string.Empty, OltTimeZoneInfo.Local, new List<Plant>(), ""),
                preShiftPaddingInMinutes, postShiftPaddingInMinutes);
        }
    }
}
