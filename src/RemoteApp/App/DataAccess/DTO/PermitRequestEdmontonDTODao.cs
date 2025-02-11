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
    public class PermitRequestEdmontonDTODao : AbstractManagedDao, IPermitRequestEdmontonDTODao
    {
        private const string QUERY_BY_COMPLETENESS_AND_GROUP_AND_DATE_STORED_PROCEDURE = "QueryPermitRequestEdmontonDTOByCompletenessAndGroupAndDateWithinRange";
        private const string QUERY_BY_FLOC_STORED_PROCEDURE = "QueryPermitRequestEdmontonDTOByDateRangeAndFlocs";
        private const string QUERY_BY_FLOC__FOR_TEMPLATE_STORED_PROCEDURE = "QueryPermitRequestTemplateDto";

        public List<PermitRequestEdmontonDTO> QueryByDateRangeAndFlocs(IFlocSet flocSet, DateRange dateRange)
        {
            return QueryByDateRangeAndFlocs(flocSet, dateRange, null, false);
        }

        // note: when excluding priority ids, make sure to give all of the priority ids for the group you want to exclude (e.g. to exclude work permits with the Maintenance group,
        // be sure to pass in 0, 1, 2 as opposed to just one of the three
        public List<PermitRequestEdmontonDTO> QueryByDateRangeAndFlocs(
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
            command.AddParameter("@ExcludeTheGivenPriorityIds", excludeTheGivenPriorityIds);

            return command.QueryForListResult<PermitRequestEdmontonDTO>(PopulateInstance, QUERY_BY_FLOC_STORED_PROCEDURE);            
        }

        public List<PermitRequestEdmontonDTO> QueryByDateRangeAndFlocsForTemplate(
                  IFlocSet flocSet, DateRange dateRange, List<long> priorityIds, bool excludeTheGivenPriorityIds, string username)
        {
            string flocids = flocSet.FunctionalLocations.BuildIdStringFromList();
            
            SqlCommand command = ManagedCommand;

            //command.AddParameter("@CsvFlocIds", flocids);
            command.AddParameter("@SiteId", flocSet.FunctionalLocations[0].Site.Id);
            command.AddParameter("@CreatedByUser", username);

            return command.QueryForListResult<PermitRequestEdmontonDTO>(PopulateInstanceForTemplate, QUERY_BY_FLOC__FOR_TEMPLATE_STORED_PROCEDURE);
        }

        private PermitRequestEdmontonDTO PopulateInstanceForTemplate(SqlDataReader reader)
        {

            long id = reader.Get<long>("Id");
            //string templateName = "VIBHOR SINGH PARMAR"; //reader.Get<string>("TemplateName");
            string templateName = reader.Get<string>("TemplateName");
            string categories = reader.Get<string>("Categories");
            string wpType = reader.Get<string>("WorkPermitType");
            string description = reader.Get<string>("Description");
            //string functionalLocationFullHierarchy = reader.Get<string>("FullHierarchy");
            bool global = reader.Get<bool>("Global");
            long temlateId = reader.Get<long>("TemplateId");

            PermitRequestEdmontonDTO result = new PermitRequestEdmontonDTO
                (
                id,
                templateName,
                categories,
                wpType,
                description,
                global,
                temlateId
                //functionalLocationFullHierarchy

                );

            return result;
        }

        public List<PermitRequestEdmontonDTO> QueryByCompletenessAndGroupAndDateWithinRange(List<PermitRequestCompletionStatus> completionStatuses, long groupId, Date queryDate)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@CompletionStatusIds", completionStatuses.BuildIdStringFromList());
            command.AddParameter("@GroupId", groupId);
            command.AddParameter("@QueryDate", queryDate.ToDateTimeAtStartOfDay());

            return command.QueryForListResult<PermitRequestEdmontonDTO>(PopulateInstance , QUERY_BY_COMPLETENESS_AND_GROUP_AND_DATE_STORED_PROCEDURE);
        }

        private static PermitRequestEdmontonDTO PopulateInstance(SqlDataReader reader)
        {
            Date requestedStartDate = new Date(reader.Get<DateTime>("RequestedStartDate"));
            Time requestedStartTimeDay = reader.Get<DateTime?>("RequestedStartTimeDay").ToTime();
            Time requestedStartTimeNight = reader.Get<DateTime?>("RequestedStartTimeNight").ToTime();

            PermitRequestCompletionStatus completionStatus = PermitRequestCompletionStatus.Get(reader.Get<int>("CompletionStatusId"));

            PermitRequestEdmontonDTO permitRequest = new PermitRequestEdmontonDTO(
                reader.Get<long>("Id"),
                WorkPermitEdmontonType.Get(reader.Get<int>("WorkPermitTypeId")),
                reader.Get<string>("FunctionalLocationName"),
                completionStatus,
                requestedStartDate,
                requestedStartTimeDay,
                requestedStartTimeNight,
                new Date(reader.Get<DateTime>("EndDate")),
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
                Priority.GetById(reader.Get<int>("PriorityId")),
                reader.Get<string>("AreaLabelName"));

            return permitRequest;
        }
    }
}
