using System;
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
    public class PermitRequestLubesDTODao : AbstractManagedDao, IPermitRequestLubesDTODao
    {
        private const string QueryByFlocStoredProcedure = "QueryPermitRequestLubesDTOByDateRangeAndFlocs";
        private const string QueryByCompletenessAndGroupAndDateStoredProcedure = "QueryPermitRequestLubesDTOByCompletenessAndGroupAndDateWithinRange";

        public List<PermitRequestLubesDTO> QueryByDateRangeAndFlocs(IFlocSet flocSet, DateRange dateRange)
        {
            string flocids = flocSet.FunctionalLocations.BuildIdStringFromList();
            SqlCommand command = ManagedCommand;

            command.AddParameter("@CsvFlocIds", flocids);
            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);

            return command.QueryForListResult<PermitRequestLubesDTO>(PopulateInstance, QueryByFlocStoredProcedure);
        }

        public List<PermitRequestLubesDTO> QueryByCompletenessAndGroupAndDateWithinRange(List<PermitRequestCompletionStatus> completionStatuses, long groupId, Date date)
        {
            SqlCommand command = ManagedCommand;

            command.AddParameter("@CompletionStatusIds", completionStatuses.BuildIdStringFromList());
            command.AddParameter("@GroupId", groupId);
            command.AddParameter("@QueryDate", date.ToDateTimeAtStartOfDay());

            return command.QueryForListResult<PermitRequestLubesDTO>(PopulateInstance , QueryByCompletenessAndGroupAndDateStoredProcedure);
        }

        private static PermitRequestLubesDTO PopulateInstance(SqlDataReader reader)
        {
            Date requestedStartDate = new Date(reader.Get<DateTime>("RequestedStartDate"));
            Time requestedStartTimeDay = reader.Get<DateTime?>("RequestedStartTimeDay").ToTime();
            Time requestedStartTimeNight = reader.Get<DateTime?>("RequestedStartTimeNight").ToTime();

            PermitRequestCompletionStatus completionStatus = PermitRequestCompletionStatus.Get(reader.Get<int>("CompletionStatusId"));

            long? createdByRoleId = reader.Get<long?>("CreatedByRoleId");

            PermitRequestLubesDTO permitRequest = new PermitRequestLubesDTO(
                reader.Get<long>("Id"),
                WorkPermitLubesType.Get(reader.Get<int>("WorkPermitTypeId")),
                reader.Get<string>("FunctionalLocationName"),
                completionStatus,
                requestedStartDate,
                requestedStartTimeDay,
                requestedStartTimeNight,
                new Date(reader.Get<DateTime>("EndDate")),
                reader.Get<string>("WorkOrderNumber"),
                reader.Get<string>("Description"),
                DataSource.GetById(reader.Get<int>("DataSourceId")),
                reader.Get<string>("Trade"),
                reader.GetUser("LastImportedByFirstName", "LastImportedByLastName", "LastImportedByUserName"),
                reader.Get<DateTime?>("LastImportedDateTime"),
                reader.GetUser("LastSubmittedByFirstName", "LastSubmittedByLastName", "LastSubmittedByUserName"),
                reader.Get<DateTime?>("LastSubmittedDateTime"),
                reader.Get<long>("CreatedByUserId"),
                reader.Get<DateTime>("LastModifiedDateTime"),
                reader.GetUser("LastModifiedByFirstName", "LastModifiedByLastName", "LastModifiedByUserName"),
                createdByRoleId != null ? createdByRoleId.Value : PermitRequestLubesDTO.CreatedByImportRoleID,
                reader.Get<string>("GroupName"));

            return permitRequest;
        }
    }
}
