using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class ActionItemDTODao : AbstractManagedDao, IActionItemDTODao
    {
        private const string QUERY_BY_PARENT_FLOCS_AND_ASSIGNMENT_AND_DATE_RANGE = "QueryActionItemDTOsByParentFlocsAndAssignmentAndDateRange";
        private const string QUERY_BY_FLOCS_AND_STATUSES_AND_DATE_RANGE_AND_ASSIGNMENT = "QueryActionItemDTOsByFlocsAndStatusesAndDateRange";
        private const string QUERY_BY_FLOCS_FOR_SHIFT_OR_RESPONSE_REQUIRED = "QueryActionItemDTOsByFlocsForShiftOrResponseRequired"; // used by old priority page
        private const string QUERY_BY_PRIORITY_PAGE_CRITERIA = "QueryActionItemDTOsByPriorityPageCriteria";
        
        public List<ActionItemDTO> QueryByFunctionalLocationsAndStatusAndDateRange(
            IFlocSet flocSet, ActionItemStatus[] actionItemStatuses, DateTime dateRangeBegin,
            DateTime? dateRangeEnd, List<long> readableVisibilityGroupIds)
        {
            string flocIds = flocSet.FunctionalLocations.BuildIdStringFromList();
            var domainObjects = new List<ActionItemStatus>(actionItemStatuses);
            string statusIds = domainObjects.BuildIdStringFromList();
           
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", flocIds);
            command.AddParameter("@CsvStatusIds", statusIds);
            AddDateParameter(command,"@StartOfDateRange", dateRangeBegin);
            AddDateParameter(command,"@EndOfDateRange", dateRangeEnd);
            command.AddParameter("@IncludeWorkAssignmentInCondition", false);
            command.AddParameter("@WorkAssignmentId", null);
            command.AddParameter("@CsvVisibilityGroupIds", readableVisibilityGroupIds == null ? null : readableVisibilityGroupIds.ToCommaSeparatedString());

            return QueryForList(command, QUERY_BY_FLOCS_AND_STATUSES_AND_DATE_RANGE_AND_ASSIGNMENT);
        }

        public List<ActionItemDTO> QueryByFunctionalLocationsAndStatusAndDateRangeAndWorkAssignment(
                IFlocSet flocSet, ActionItemStatus[] actionItemStatuses,
                    DateTime dateRangeBegin, DateTime? dateRangeEnd, WorkAssignment workAssignment, List<long> readableVisibilityGroupIds)
        {
            string flocIds = flocSet.FunctionalLocations.BuildIdStringFromList();
            var domainObjects = new List<ActionItemStatus>(actionItemStatuses);
            string statusIds = domainObjects.BuildIdStringFromList();

            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", flocIds);
            command.AddParameter("@CsvStatusIds", statusIds);
            AddDateParameter(command, "@StartOfDateRange", dateRangeBegin);
            AddDateParameter(command, "@EndOfDateRange", dateRangeEnd);
            command.AddParameter("@IncludeWorkAssignmentInCondition", true);
            command.AddParameter("@WorkAssignmentId", workAssignment != null ? workAssignment.Id : null);
            command.AddParameter("@CsvVisibilityGroupIds", readableVisibilityGroupIds == null ? null : readableVisibilityGroupIds.ToCommaSeparatedString());

            return QueryForList(command, QUERY_BY_FLOCS_AND_STATUSES_AND_DATE_RANGE_AND_ASSIGNMENT);                        
        }

        public List<ActionItemDTO> QueryByPriorityPageCriteria(
            IFlocSet flocSet,
            List<ActionItemStatus> actionItemStatuses,
            DateTime dateRangeBegin,
            DateTime dateRangeEnd,
            DateTime noEndDateFrom,
            bool includeWorkAssignmentInCondition,
            WorkAssignment workAssignment,
            List<long> readableVisibilityGroupIds)
        {
            string flocIds = flocSet.FunctionalLocations.BuildIdStringFromList();

            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", flocIds);
            command.AddParameter("@CsvStatusIds", actionItemStatuses.BuildIdStringFromList());
            command.AddParameter("@StartOfDateRange", dateRangeBegin);
            command.AddParameter("@EndOfDateRange", dateRangeEnd);
            command.AddParameter("@DateThatMeansNoEndDate", DateTime.MaxValue);
            command.AddParameter("@NoEndDateFrom", noEndDateFrom);
            command.AddParameter("@IncludeWorkAssignmentInCondition", includeWorkAssignmentInCondition);
            command.AddParameter("@WorkAssignmentId", workAssignment != null ? workAssignment.Id : null);
            command.AddParameter("@CsvVisibilityGroupIds", readableVisibilityGroupIds == null ? null : readableVisibilityGroupIds.ToCommaSeparatedString());

            return QueryForList(command, QUERY_BY_PRIORITY_PAGE_CRITERIA);
        }

        public List<ActionItemDTO> QueryByParentFunctionalLocationsAndWorkAssignmentAndDateRange(IFlocSet flocSet, WorkAssignment assignment, DateTime startDateTime, DateTime endDateTime, List<long> readableVisibilityGroupIds)
        {
            return QueryByParentFunctionalLocationsAndWorkAssignmentAndDateRange(flocSet, assignment, startDateTime, endDateTime, true, readableVisibilityGroupIds);
        }

        public List<ActionItemDTO> QueryByParentFunctionalLocationsAndDateRange(IFlocSet flocSet, DateTime startDateTime, DateTime endDateTime, List<long> readableVisibilityGroupIds)
        {
            return QueryByParentFunctionalLocationsAndWorkAssignmentAndDateRange(flocSet, null, startDateTime, endDateTime, false, readableVisibilityGroupIds);
        }

        private List<ActionItemDTO> QueryByParentFunctionalLocationsAndWorkAssignmentAndDateRange(IFlocSet flocSet, WorkAssignment assignment, DateTime startDateTime, DateTime endDateTime, bool useAssignment, List<long> readableVisibilityGroupIds)
        {
            string csvFlocIds = flocSet.FunctionalLocations.BuildIdStringFromList();

            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", csvFlocIds);
            command.AddParameter("@UseWorkAssignment", useAssignment);

            if (assignment != null)
            {
                command.AddParameter("@WorkAssignmentId", assignment.IdValue);
            }
            command.AddParameter("@StartOfDateRange", startDateTime);
            command.AddParameter("@EndOfDateRange", endDateTime);
            command.AddParameter("@CsvVisibilityGroupIds", readableVisibilityGroupIds == null ? null : readableVisibilityGroupIds.ToCommaSeparatedString());

            return QueryForList(command, QUERY_BY_PARENT_FLOCS_AND_ASSIGNMENT_AND_DATE_RANGE);
        }

        public List<ActionItemDTO> QueryByFunctionalLocationForShiftOrResponseRequiredAndDisplayLimits(
            IFlocSet flocSet, DateTime dateRangeBegin, UserShift userShift, List<long> readableVisibilityGroupIds)
        {
            string csvFlocIds = flocSet.FunctionalLocations.BuildIdStringFromList();

            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", csvFlocIds);

            command.AddParameter("@ShiftStartDateTime", userShift.StartDateTime);
            command.AddParameter("@ShiftEndDateTime", userShift.EndDateTime);
            command.AddParameter("@DateRangeBegin", dateRangeBegin);
            command.AddParameter("@IncludeAssignmentInCondition", false);
            command.AddParameter("@AssignmentId", null);
            command.AddParameter("@CsvVisibilityGroupIds", readableVisibilityGroupIds == null ? null : readableVisibilityGroupIds.ToCommaSeparatedString());

            return QueryForList(command, QUERY_BY_FLOCS_FOR_SHIFT_OR_RESPONSE_REQUIRED); 
        }

        public List<ActionItemDTO> QueryByFunctionalLocationAndWorkAssignmentForShiftOrResponseRequiredAndDisplayLimits(
            IFlocSet flocSet, DateTime dateRangeBegin, UserShift userShift, WorkAssignment workAssignment, List<long> readableVisibilityGroupIds)
        {
            string csvFlocIds = flocSet.FunctionalLocations.BuildIdStringFromList();

            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", csvFlocIds);

            command.AddParameter("@ShiftStartDateTime", userShift.StartDateTime);
            command.AddParameter("@ShiftEndDateTime", userShift.EndDateTime);
            command.AddParameter("@DateRangeBegin", dateRangeBegin);
            command.AddParameter("@IncludeAssignmentInCondition", true);
            command.AddParameter("@AssignmentId", workAssignment != null ? workAssignment.Id : null);
            command.AddParameter("@CsvVisibilityGroupIds", readableVisibilityGroupIds == null ? null : readableVisibilityGroupIds.ToCommaSeparatedString());

            return QueryForList(command, QUERY_BY_FLOCS_FOR_SHIFT_OR_RESPONSE_REQUIRED); 
        }

        private static List<ActionItemDTO> QueryForList(SqlCommand command, string query)
        {
            Dictionary<long, ActionItemDTO> result = new Dictionary<long, ActionItemDTO>();

            command.CommandText = query;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                
                while (reader.Read())
                {
                    long id = GetId(reader);
                    if (result.ContainsKey(id))
                    {
                        ActionItemDTO dto = result[id];
                        string functionalLocationName = GetFunctionalLocationName(reader);
                        string functionalLocationDescription = GetFunctionalLocationDescription(reader);
                        dto.AddFunctionalLocation(functionalLocationName);
                        dto.AddFunctionalLocationWithDescription(FunctionalLocation.GetFullHierarchyWithDescription(functionalLocationName, functionalLocationDescription));
                        dto.AddVisibilityGroupName(GetVisibiliyGroupName(reader));
                        dto.AddVisibilityGroupStartingWith(GetVisibiliyGroupStartingWith(reader));
                    }
                    else
                    {
                        result.Add(id, PopulateInstance(reader));
                    }
                }
            }

            return new List<ActionItemDTO>(result.Values);
        }

            public bool GetReadingByActionItemDefId(long definitionid)
            {
                var command = ManagedCommand;
                command.AddParameter("@ActionItemDefinitionId", definitionid);
                return command.QueryForSingleResult(PopulateInstanceForReading, "QueryReadingByActionItemDefinitionId");
            }
        
        //ayman action item reading
        private static bool PopulateInstanceForReading(SqlDataReader reader)
        {
            var readingvalue = reader.Get<bool>("Reading");
            return readingvalue;
        }

        private static ActionItemDTO PopulateInstance(SqlDataReader reader)
        {
            long id = GetId(reader);
            DateTime startDateTime = reader.Get<DateTime>("StartDateTime");
            DateTime? endDateTime = reader.Get<DateTime?>("EndDateTime");

            DateTime startDate = startDateTime.Date;
            DateTime startTime = startDateTime;
            DateTime endDate = DateTime.MaxValue;
            DateTime endTime = DateTime.MaxValue;

            if (endDateTime.HasValue)
            {
                endDate = endDateTime.Value.Date;
                endTime = endDateTime.Value;
            }

            string name = reader.Get<string>("Name");
            long statusId = reader.Get<long>("ActionItemStatusId");
            Priority priority = Priority.GetById(reader.Get<long>("PriorityId"));
            int sourceId = reader.Get<int>("SourceId");
            string categoryName = reader.Get<string>("BusinessCategoryName");
            string description = reader.Get<string>("Description");
            string scheduleTypeName = ScheduleType.GetById(reader.Get<int>("createdByScheduleTypeId")).Name;
            string functionalLocationName = GetFunctionalLocationName(reader);
            string functionalLocationDescription = GetFunctionalLocationDescription(reader);
            bool responseRequired = reader.Get<bool>("ResponseRequired");

            long? lastModifiedByUserId = reader.Get<long?>("LastModifiedUserId");

            string workAssignment = reader.Get<string>("WorkAssignmentName");
            long? workAssignmentId = reader.Get<long?>("WorkAssignmentId");
            string visGroupsStartingWith = reader.Get<string>("VisibilityGroupIDs");            //ayman visibility group

            //ayman action item definition
            long definitionid = reader.Get<long>("definitionid");

            bool Reading = reader.Get<bool>("Reading");
          


            var result = new ActionItemDTO(id,
                                                     startDate,
                                                     startTime,
                                                     endDate,
                                                     endTime,
                                                     statusId,
                                                     priority,
                                                     categoryName,
                                                     sourceId,
                                                     description,
                                                     scheduleTypeName,
                                                     new List<string> { functionalLocationName },
                                                     new List<string> { FunctionalLocation.GetFullHierarchyWithDescription(functionalLocationName, functionalLocationDescription) },
                                                     responseRequired,
                                                     lastModifiedByUserId,
                                                     name, 
                                                     workAssignment,
                                                     workAssignmentId,
                                                     new List<string> { GetVisibiliyGroupName(reader) }, visGroupsStartingWith, definitionid, Reading);    //ayman action item definition   

            return result;
        }

        private static long GetId(SqlDataReader reader)
        {
            return reader.Get<long>("Id");
        }

        private static string GetFunctionalLocationName(SqlDataReader reader)
        {
            return reader.Get<string>("FullHierarchy");
        }

        private static string GetFunctionalLocationDescription(SqlDataReader reader)
        {
            return reader.Get<string>("FunctionalLocationDescription");
        }

        private static string GetVisibiliyGroupName(SqlDataReader reader)
        {
            return reader.Get<string>("VisibilityGroupName");
        }


        //ayman visibility group
        private static string GetVisibiliyGroupStartingWith(SqlDataReader reader)
        {
            return reader.Get<string>("VisibilityGroupIDs");
        }



        private static void AddDateParameter(SqlCommand command, string parameterName, DateTime? date)
        {            
            if (date.HasValue)
            {
                command.AddParameter(parameterName, date);
            }
        }
    }
}