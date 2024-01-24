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
    public class DetailedLogReportDTODao : AbstractManagedDao, IDetailedLogReportDTODao
    {
        private const string QUERY_FOR_SUMMARY_LOGS = "QuerySummaryLogDTOsByFlocShiftRangeAndAssignment";
        private const string QUERY_FOR_LOGS = "QueryLogDTOByFlocShiftRangeAndAssignment";

        private const long DONT_CARE_SITE_ID = 0;
        private static readonly DateTime DONT_CARE_SHIFT_CREATION_DATE = DateTime.MinValue;

        public List<DetailedLogReportDTO> QueryForLogs(
            UserShift startUserShift,
            UserShift endUserShift,
            IFlocSet flocSet,
            List<WorkAssignment> workAssignments,
            bool includeNullWorkAssignment)
        {
            return RunQuery(
                QUERY_FOR_LOGS,
                startUserShift,
                endUserShift,
                flocSet.FunctionalLocations,
                workAssignments,
                includeNullWorkAssignment);
        }

        public List<DetailedLogReportDTO> QueryForSummaryLogs(
            UserShift startUserShift,
            UserShift endUserShift,
            IFlocSet flocSet,
            List<WorkAssignment> workAssignments,
            bool includeNullWorkAssignment)
        {
            return RunQuery(
                QUERY_FOR_SUMMARY_LOGS, 
                startUserShift, 
                endUserShift, 
                flocSet.FunctionalLocations,
                workAssignments, 
                includeNullWorkAssignment);
        }

        private List<DetailedLogReportDTO> RunQuery(
            string storedProcedure,
            UserShift startUserShift,
            UserShift endUserShift,
            List<FunctionalLocation> flocs,
            List<WorkAssignment> workAssignments,
            bool includeNullWorkAssignment)
        {
            DateTime fromDateTime = startUserShift.StartDateTimeWithPadding;
            DateTime endDateTime = endUserShift.EndDateTimeWithPadding;

           using(SqlCommand command = ManagedCommand)       //ayman log report
            {
                command.CommandText = storedProcedure;
                command.AddParameter("@CsvFlocIds", flocs.BuildIdStringFromList());
                command.AddParameter("@CsvWorkAssignmentIds", workAssignments.BuildIdStringFromList());
                command.AddParameter("@IncludeNullAssignment", includeNullWorkAssignment);
                command.AddParameter("@StartOfDateRange", fromDateTime);
                command.AddParameter("@EndOfDateRange", endDateTime);

                Dictionary<long, DetailedLogReportDTOContainer> result =
                    new Dictionary<long, DetailedLogReportDTOContainer>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long key = GetId(reader);

                        if (result.ContainsKey(key))
                        {
                            string functionalLocationNameWithDescription =
                                GetFunctionalLocationNameWithDescription(reader);
                            result[key].Dto.AddFunctionalLocation(functionalLocationNameWithDescription);

                            FunctionalLocationSegmentDTO segmentDto = GetFunctionalLocationSegmentDTO(reader);
                            result[key].Dto.AddSegmentDto(segmentDto);

                            DocumentLinkDTO documentLinkDto = GetDocumentLinkDto(reader);
                            if (documentLinkDto != null)
                            {
                                result[key].Dto.AddDocumentLinkDto(documentLinkDto);
                            }

                            CustomFieldEntry customFieldEntry = GetCustomFieldEntry(reader);
                            result[key].Dto.AddCustomFieldEntry(customFieldEntry);

                            CustomField customField = GetCustomField(reader);
                            result[key].AddCustomField(customField);
                        }
                        else
                        {
                            DetailedLogReportDTO logReportDto = PopulateInstanceForDetailedLogReportDTO(reader);

                            List<CustomField> customFields = new List<CustomField>();
                            CustomField customField = GetCustomField(reader);
                            if (customField != null)
                            {
                                customFields.Add(customField);
                            }

                            if (logReportDto.ShiftStartDateTime >= startUserShift.StartDateTime &&
                                logReportDto.ShiftEndDateTime <= endUserShift.EndDateTime)
                            {
                                result.Add(key, new DetailedLogReportDTOContainer(logReportDto, customFields));
                            }
                        }
                    }
                }

                List<DetailedLogReportDTO> dtos = new List<DetailedLogReportDTO>();

                foreach (DetailedLogReportDTOContainer container in result.Values)
                {
                    container.Dto.CustomFieldEntries = CustomFieldEntry.PadEntriesWithBlanks(container.CustomFields,
                        container.Dto.CustomFieldEntries);
                    dtos.Add(container.Dto);
                }

                return dtos;
            }
        }

        private static DetailedLogReportDTO PopulateInstanceForDetailedLogReportDTO(SqlDataReader reader)
        {
            DateTime logDateTime = reader.Get<DateTime>("LogDateTime");

            ShiftPattern shift = GetShift(reader);
            UserShift userShift = new UserShift(shift, logDateTime);

            List<DocumentLinkDTO> documentLinkDtos = new List<DocumentLinkDTO>();
            DocumentLinkDTO documentLinkDto = GetDocumentLinkDto(reader);
            if (documentLinkDto != null)
            {
                documentLinkDtos.Add(documentLinkDto);
            }

            CustomFieldEntry customFieldEntry = GetCustomFieldEntry(reader);
            List<CustomFieldEntry> customFieldEntries = new List<CustomFieldEntry>();
            if (customFieldEntry != null)
            {
                customFieldEntries.Add(customFieldEntry);
            }

            DetailedLogReportDTO result = new DetailedLogReportDTO(
                GetId(reader),
                shift.IdValue,
                shift.Name,
                userShift.StartDateTime,
                userShift.EndDateTime,
                reader.GetUser("LastModifiedByFirstName", "LastModifiedByLastName", "LastModifiedByUserName"),
                logDateTime,
                reader.Get<string>("WorkAssignmentName"),
                reader.Get<bool?>("RecommendForShiftSummary"),
                reader.Get<bool>("InspectionFollowUp"),
                reader.Get<bool>("ProcessControlFollowUp"),
                reader.Get<bool>("OperationsFollowUp"),
                reader.Get<bool>("SupervisionFollowUp"),
                reader.Get<bool>("EHSFollowup"),
                reader.Get<bool>("OtherFollowUp"),
                new List<string> { GetFunctionalLocationNameWithDescription(reader) },
                new List<FunctionalLocationSegmentDTO> { GetFunctionalLocationSegmentDTO(reader) },
                documentLinkDtos,
                customFieldEntries,
                reader.Get<string>("PlainTextComments"),
                reader.Get<string>("RtfComments"),
                reader.Get<string>("Color")
                );

            return result;
        }

        private static long GetId(SqlDataReader reader)
        {
            return reader.Get<long>("Id");
        }

        private static ShiftPattern GetShift(SqlDataReader reader)
        {
            TimeSpan preShiftPaddingInMinutes = new TimeSpan(0, reader.Get<int>("PreShiftPaddingInMinutes"), 0);
            TimeSpan postShiftPaddingInMinutes = new TimeSpan(0, reader.Get<int>("PostShiftPaddingInMinutes"), 0);

            ShiftPattern shift = new ShiftPattern(
                reader.Get<long>("ShiftId"),
                reader.Get<string>("ShiftName"),
                new Time(reader.Get<TimeSpan>("ShiftStartTime")),
                new Time(reader.Get<TimeSpan>("ShiftEndTime")),
                DONT_CARE_SHIFT_CREATION_DATE,
                new Site(DONT_CARE_SITE_ID, string.Empty, OltTimeZoneInfo.Local, new List<Plant>(), ""), preShiftPaddingInMinutes, postShiftPaddingInMinutes);

            return shift;
        }

        private static string GetFunctionalLocationNameWithDescription(SqlDataReader reader)
        {
            string name = GetFunctionalLocationName(reader);
            string description = reader.Get<string>("FunctionalLocationDescription");
            return FunctionalLocation.GetFullHierarchyWithDescription(name, description);
        }

        private static FunctionalLocationSegmentDTO GetFunctionalLocationSegmentDTO(SqlDataReader reader)
        {
            string name = GetFunctionalLocationName(reader);
            FunctionalLocationHierarchy functionalLocationHierarchy = new FunctionalLocationHierarchy(name);

            return new FunctionalLocationSegmentDTO(functionalLocationHierarchy);
        }

        private static string GetFunctionalLocationName(SqlDataReader reader)
        {
            return reader.Get<string>("FunctionalLocationName");
        }

        private static CustomFieldEntry GetCustomFieldEntry(SqlDataReader reader)
        {
            long? id = reader.Get<long?>("CustomFieldEntryId");

            if (id == null)
            {
                return null;
            }

            string name = reader.Get<string>("CustomFieldName");
            string fieldEntry = reader.Get<string>("CustomFieldEntry");
            decimal? numericFieldEntry = reader.Get<decimal?>("NumericCustomFieldEntry");
            int displayOrder = reader.Get<int>("CustomFieldDisplayOrder");
            CustomFieldType type = CustomFieldType.FindById(reader.Get<byte>("CustomFieldTypeId"));
            long customFieldId = reader.Get<long>("CustomFieldId");
            byte phdLinkTypeId = reader.Get<byte>("CustomFieldPhdLinkTypeId");
            CustomFieldPhdLinkType phdLinkType = phdLinkTypeId.ToEnum<CustomFieldPhdLinkType>();

            string color = reader.Get<string>("Color");

            //CustomFieldEntry entry = new CustomFieldEntry(id, customFieldId, name, fieldEntry, numericFieldEntry, displayOrder, type, phdLinkType);
            CustomFieldEntry entry = new CustomFieldEntry(id, customFieldId, name, fieldEntry, numericFieldEntry,null, displayOrder, type, phdLinkType          //ayman action item reading
                                                            ,null,null,null,null,color,null);

            return entry;
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
            CustomFieldType type = CustomFieldType.FindById(reader.Get<byte>("ActualCustomFieldTypeId"));
            byte phdLinkTypeId = reader.Get<byte>("ActualCustomFieldPhdLinkTypeId");
            CustomFieldPhdLinkType phdLinkType = phdLinkTypeId.ToEnum<CustomFieldPhdLinkType>();


            return new CustomField(id, name, displayOrder, customFieldGroupId, originCustomFieldGroupId, originCustomFieldId, null, type, phdLinkType, null);
        }

        private static DocumentLinkDTO GetDocumentLinkDto(SqlDataReader reader)
        {
            string url = reader.Get<string>("DocumentLinkUrl");
            string title = reader.Get<string>("DocumentLinkTitle");
            return !string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(title) ? new DocumentLinkDTO(url, title) : null;
        }
    }
}
