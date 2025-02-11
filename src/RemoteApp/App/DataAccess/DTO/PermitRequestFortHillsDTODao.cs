﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class PermitRequestFortHillsDTODao : AbstractManagedDao, IPermitRequestFortHillsDTODao
    {
        private const string QUERY_BY_COMPLETENESS_AND_GROUP_AND_DATE_STORED_PROCEDURE = "QueryPermitRequestFortHillsDTOByCompletenessAndGroupAndDateWithinRange";
        private const string QUERY_BY_FLOC_STORED_PROCEDURE = "QueryPermitRequestFortHillsDTOByDateRangeAndFlocs";

        public List<PermitRequestFortHillsDTO> QueryByDateRangeAndFlocs(IFlocSet flocSet, DateRange dateRange)
        {
            return QueryByDateRangeAndFlocs(flocSet, dateRange, null, false);
        }

        // note: when excluding priority ids, make sure to give all of the priority ids for the group you want to exclude (e.g. to exclude work permits with the Maintenance group,
        // be sure to pass in 0, 1, 2 as opposed to just one of the three
        public List<PermitRequestFortHillsDTO> QueryByDateRangeAndFlocs(
                   IFlocSet flocSet, DateRange dateRange, List<long> priorityIds, bool excludeTheGivenPriorityIds)
        {
            string flocids = flocSet.FunctionalLocations.BuildIdStringFromList();
            SqlCommand command = ManagedCommand;

            command.AddParameter("@CsvFlocIds", flocids);
            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);
            if (priorityIds != null)
            {
                command.AddParameter("@PriorityIds", priorityIds.BuildCommaSeparatedList(id => id.ToString()));
            }
            //command.AddParameter("@ExcludeTheGivenPriorityIds", excludeTheGivenPriorityIds);

            return command.QueryForListResult<PermitRequestFortHillsDTO>(PopulateInstance, QUERY_BY_FLOC_STORED_PROCEDURE);            
        }

        public List<PermitRequestFortHillsDTO> QueryByCompletenessAndGroupAndDateWithinRange(List<PermitRequestCompletionStatus> completionStatuses, long groupId, Date queryDate)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@CompletionStatusIds", completionStatuses.BuildIdStringFromList());
            command.AddParameter("@GroupId", groupId);
            command.AddParameter("@QueryDate", queryDate.ToDateTimeAtStartOfDay());

            return command.QueryForListResult<PermitRequestFortHillsDTO>(PopulateInstance , QUERY_BY_COMPLETENESS_AND_GROUP_AND_DATE_STORED_PROCEDURE);
        }

        private static PermitRequestFortHillsDTO PopulateInstance(SqlDataReader reader)
        {
            Date requestedStartDate = new Date(reader.Get<DateTime>("RequestedStartDate"));
            Time requestedStartTime = reader.Get<DateTime?>("RequestedStartDate").ToTime();
            Time requestedEndTime = reader.Get<DateTime?>("RequestedEndDate").ToTime();

            PermitRequestCompletionStatus completionStatus = PermitRequestCompletionStatus.Get(reader.Get<int>("CompletionStatusId"));

            PermitRequestFortHillsDTO permitRequest = new PermitRequestFortHillsDTO(
                reader.Get<long>("Id"),
                WorkPermitFortHillsType.Get(reader.Get<int>("WorkPermitTypeId")),
                reader.Get<string>("FunctionalLocationName"),
                completionStatus,
                requestedStartDate,
                requestedStartTime,
                new Date(reader.Get<DateTime>("RequestedEndDate")),
                requestedEndTime,
                reader.Get<string>("WorkOrderNumber"),
                reader.Get<string>("TaskDescription"),
                DataSource.GetById(reader.Get<int>("DataSourceId")),
                reader.Get<string>("GroupName"),
                reader.Get<string>("Occupation"),
                reader.GetUser("LastImportedByFirstName", "LastImportedByLastName", "LastImportedByUserName"),
                reader.Get<DateTime?>("LastImportedDateTime"),
                reader.GetUser("LastSubmittedByFirstName", "LastSubmittedByLastName", "LastSubmittedByUserName"),
                reader.Get<DateTime?>("LastSubmittedDateTime"),
                reader.Get<long>("CreatedByUserId"),
                reader.Get<DateTime>("LastModifiedDateTime"),
                reader.GetUser("LastModifiedByFirstName", "LastModifiedByLastName", "LastModifiedByUserName"),
                Priority.GetById(reader.Get<int>("PriorityId")));

            return permitRequest;
        }
    }
}
