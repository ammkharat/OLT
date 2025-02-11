using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class WorkPermitDTODao : AbstractManagedDao, IWorkPermitDTODao
    {
        private const string QUERY_BY_FLOCS_START_DATE_AND_SHIFT_START_TIME = "QueryWorkPermitDTOsForThisDateByFLOCsAndShiftStartTime"; // used by old priority page
        private const string QUERY_BY_RANGE_AND_STATUS_STORED_PROC = "QueryWorkPermitDTOsByDateRangeAndStatusIds";
        private const string QUERY_BY_RANGE_AND_STATUS_STORED_PROC_FORUSPipeline = "QueryWorkPermitDTOsByDateRangeAndStatusIdsForUSPipeline";

        private const string QUERY_BY_RANGE_AND_STATUS_FOR_TEMPLATE_STORED_PROC = "QueryWorkPermitTemplateDTOs";
        private const string QUERY_BY_RANGE_AND_STATUS_STORED_PROC_FORUSPipeline_FOR_TEMPLATE = "QueryWorkPermitDTOsByDateRangeAndStatusIdsForUSPipelineForMarkedTemplate";

        public List<WorkPermitDTO> QueryByDateRangeAndStatuses(IFlocSet flocSet, IList<WorkPermitStatus> statuses, DateTime startDate, DateTime? endDate, WorkAssignment workAssignment)
        {
            string csvFlocIds = flocSet.FunctionalLocations.BuildIdStringFromList();
            string statusIds = statuses.BuildIdStringFromList();

            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", csvFlocIds);
            command.AddParameter("@CsvStatusIds", statusIds);
            command.AddParameter("@StartOfDateRange", startDate);
            command.AddParameter("@WorkAssignmentId", workAssignment == null ? null : workAssignment.Id);
            if (endDate.HasValue)
                command.AddParameter("@EndOfDateRange", endDate.Value);
            //ayman USPipeline workpermit
            if (flocSet.FunctionalLocations[0].Site.Id == Site.USPipeline_ID 
                || flocSet.FunctionalLocations[0].Site.Id == Site.SELC_ID) // mangesh uspipeline to selc
                return command.QueryForListResult<WorkPermitDTO>(PopulateInstance, QUERY_BY_RANGE_AND_STATUS_STORED_PROC_FORUSPipeline);
            return command.QueryForListResult<WorkPermitDTO>(PopulateInstance, QUERY_BY_RANGE_AND_STATUS_STORED_PROC);
        }

        public List<WorkPermitDTO> QueryByDateRangeAndStatusesForTemplate(IFlocSet flocSet, IList<WorkPermitStatus> statuses, DateTime startDate, DateTime? endDate, WorkAssignment workAssignment,
            bool template, string username)
        {
            string csvFlocIds = flocSet.FunctionalLocations.BuildIdStringFromList();
            string statusIds = statuses.BuildIdStringFromList();

            SqlCommand command = ManagedCommand;
            command.AddParameter("@SiteId", flocSet.FunctionalLocations[0].Site.Id);
            command.AddParameter("@CreatedByUser", username);

            if (flocSet.FunctionalLocations[0].Site.Id == Site.USPipeline_ID || flocSet.FunctionalLocations[0].Site.Id == Site.SELC_ID) // mangesh uspipeline to selc
                return command.QueryForListResult<WorkPermitDTO>(PopulateInstanceForTemplate, QUERY_BY_RANGE_AND_STATUS_FOR_TEMPLATE_STORED_PROC);
            return command.QueryForListResult<WorkPermitDTO>(PopulateInstanceForTemplate, QUERY_BY_RANGE_AND_STATUS_FOR_TEMPLATE_STORED_PROC);
        }

        // used by old priority page
        public List<WorkPermitDTO> QueryByFLOCsAndShiftForThisDate(IFlocSet flocSet, List<WorkPermitStatus> statuses, ShiftPattern shiftPattern, DateTime dateTime)
        {
            string csvFlocIds = flocSet.FunctionalLocations.BuildIdStringFromList();
            string statusIds = statuses.BuildIdStringFromList();
            
            SqlCommand command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", csvFlocIds);
            command.AddParameter("@CsvStatusIds", statusIds);
            
            UserShift userShift = new UserShift(shiftPattern, dateTime);
            command.AddParameter("@ShiftStartDateTime", userShift.StartDateTime);
            command.AddParameter("@ShiftEndDateTime", userShift.EndDateTime);

            //ayman USPipeline workpermit
            string spname = string.Empty;
            if (flocSet.Site.IdValue == Site.USPipeline_ID 
                || flocSet.Site.IdValue == Site.SELC_ID) // mangesh uspipeline to selc
            {
                spname = "QueryWorkPermitUSPipelineDTOsForThisDateByFLOCsAndShiftStartTime";
            }
            else
            {
                spname = "QueryWorkPermitDTOsForThisDateByFLOCsAndShiftStartTime";
            }

                return command.QueryForListResult<WorkPermitDTO>(PopulateInstance, spname); 
        }

        private WorkPermitDTO PopulateInstance(SqlDataReader reader)
        {
            long id = reader.Get<long>("Id");
            long statusId = reader.Get<long>("WorkPermitStatusId");
            string statusName = WorkPermitStatus.Get(statusId).Name;
            string functionalLocationName = reader.Get<string>("FullHierarchy");
            string permitNumber = reader.Get<string>("PermitNumber");
            DateTime startDateTime = reader.Get<DateTime>("StartDateTime");
            DateTime? endDateTime = reader.Get<DateTime?>("EndDateTime");

            string jobStepsDescription = reader.Get<string>("JobStepDescription") ?? string.Empty;
                                             
            string workOrderDescription = reader.Get<string>("WorkOrderDescription") ?? string.Empty;

            string workOrderNumber = reader.Get<string>("WorkOrderNumber");
            long workPermitTypeId = reader.Get<long>("WorkPermitTypeId");
            int dataSourceId = reader.Get<int>("SourceId");
            
            bool isOperations = reader.Get<bool>("IsOperations");
            string craftOrTradeName = reader.Get<string>("CraftOrTradeName");
            string createdByFullNameWithUserName = FullNameWithUserName(reader, "CreatedByLastName", "CreatedByFirstName", "CreatedByUserName");
            string approvedByUserFullName = FullNameWithUserName(reader, "ApprovedByLastName", "ApprovedByFirstName", "ApprovedByUserName");
            string lastModifiedByUserFullName = FullNameWithUserName(reader, "LastModifiedLastName", "LastModifiedFirstName", "LastModifiedUserName");
            long? lastModifiedByUserId = reader.Get<long?>("LastModifiedUserId");

            string workAssignmentName = reader.Get<string>("WorkAssignmentName");
            bool isConfinedSpace = reader.Get<bool>("PermitConfinedSpaceEntry"); //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
            //bool isTemplate = reader.Get<bool>("IsTemplate");

            WorkPermitDTO result = new WorkPermitDTO
                (
                id,
                statusId,
                statusName,
                functionalLocationName,
                permitNumber,
                startDateTime,
                endDateTime,
                jobStepsDescription,
                workOrderDescription,
                workOrderNumber,
                workPermitTypeId,
                dataSourceId,
                isOperations,
                craftOrTradeName,
                lastModifiedByUserId,
                createdByFullNameWithUserName ?? string.Empty,
                lastModifiedByUserFullName ?? string.Empty,
                approvedByUserFullName ?? string.Empty,
                workAssignmentName ?? string.Empty,
                isConfinedSpace //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
                //isTemplate
                );

            return result;
        }

        private WorkPermitDTO PopulateInstanceForTemplate(SqlDataReader reader)
        {

            long id = reader.Get<long>("Id");
            long temlateId = reader.Get<long>("TemplateId");
            string permitNumber = reader.Get<string>("PermitNumber");
            string templateName = reader.Get<string>("TemplateName");
            string categories = reader.Get<string>("Categories");
            string wpType = reader.Get<string>("WorkPermitType");
            string description = reader.Get<string>("Description");
            bool global = reader.Get<bool>("Global");

            WorkPermitDTO result = new WorkPermitDTO
                (
                id,
                permitNumber,
                templateName,
                 categories,
                wpType,
                description,
                global,
                temlateId

                );

            return result;
        }

        private static string FullNameWithUserName(SqlDataReader reader, string lastNameColumn,
                                                   string firstNameColumn, string userNameColumn)
        {
            return reader.GetUser(firstNameColumn, lastNameColumn, userNameColumn);
        }


        
    }
}