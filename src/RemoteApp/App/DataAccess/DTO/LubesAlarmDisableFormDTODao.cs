using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class LubesAlarmDisableFormDTODao : AbstractManagedDao, ILubesAlarmDisableFormDTODao
    {
        private const string QUERY_ALARM_DISABLE_BY_FLOCS_AND_OTHER_THINGS =
            "QueryFormLubesAlarmDisableDTOsByFunctionalLocationsAndOtherThings";

        private const string QUERY_APPROVED_ALARM_DISABLE_BY_FLOCS =
            "QueryFormDTOsThatAreLubesAlarmDisableApprovedDraftExpiredByFunctionalLocations";

        private const string QUERY_APPROVED_AND_ACTIVE_ALARM_DISABLE_BY_FLOCS =
            "QueryFormDTOsThatAreLubesAlarmDisableApprovedAndActiveByFunctionalLocations";

        public List<LubesAlarmDisableFormDTO> QueryFormAlarmDisable(IFlocSet flocSet, DateRange dateRange,
            List<FormStatus> formStatuses,
            bool includeAllDraftFormsRegardlessOfDateRange)
        {
            var command = ManagedCommand;
            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@CsvFormStatusIds", formStatuses.BuildIdStringFromList());
            command.AddParameter("@IncludeAllDraft", includeAllDraftFormsRegardlessOfDateRange);

            return GetDtos(command, QUERY_ALARM_DISABLE_BY_FLOCS_AND_OTHER_THINGS);
        }

        public List<LubesAlarmDisableFormDTO> QueryFormAlarmDisableThatAreApprovedDraftExpiredByFunctionalLocations(
            IFlocSet flocSet,
            DateTime now)
        {
            var command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@Now", now);
            return GetDtos(command, QUERY_APPROVED_ALARM_DISABLE_BY_FLOCS);
        }

        public List<LubesAlarmDisableFormDTO> QueryFormAlarmDisableThatAreApprovedAndActiveByFunctionalLocations(
            IFlocSet flocSet,
            DateTime now)
        {
            var command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@Now", now);
            return GetDtos(command, QUERY_APPROVED_AND_ACTIVE_ALARM_DISABLE_BY_FLOCS);
        }

        private static List<LubesAlarmDisableFormDTO> GetDtos(SqlCommand command, string query)
        {
            var result = new Dictionary<long, LubesAlarmDisableFormDTO>();

            command.CommandText = query;
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var key = GetId(reader);

                    if (result.ContainsKey(key))
                    {
                        FormEdmontonDTO dto = result[key];
                        dto.AddFunctionalLocation(GetFunctionalLocationName(reader));

                        if (ApprovalStillNeeded(reader))
                        {
                            dto.AddRemainingApproval(reader.Get<string>("Approver"));
                        }
                    }
                    else
                    {
                        result.Add(key, PopulateInstance(reader));
                    }
                }
            }

            return new List<LubesAlarmDisableFormDTO>(result.Values);
        }

        private static long GetId(SqlDataReader reader)
        {
            return reader.Get<long>("Id");
        }

        private static bool ApprovalStillNeeded(SqlDataReader reader)
        {
            var approvedByUserId = reader.Get<long?>("ApprovedByUserId");
            return approvedByUserId == null;
        }

        private static string GetFunctionalLocationName(SqlDataReader reader)
        {
            return reader.Get<string>("FullHierarchy");
        }

        private static LubesAlarmDisableFormDTO PopulateInstance(SqlDataReader reader)
        {
            var id = GetId(reader);
            var floc = GetFunctionalLocationName(reader);

            var alarm = reader.Get<string>("Alarm");
            var criticality = reader.Get<string>("Criticality");
            var sapNotification = reader.Get<string>("SapNotification");

            var createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            var createdByUserId = reader.Get<long>("CreatedByUserId");
            var createdByFullNameWithUserName = reader.GetUser("CreatedByFirstName", "CreatedByLastName",
                "CreatedByUserName");

            var lastModifiedUser = reader.GetUser("LastModifiedByFirstName", "LastModifiedByLastName",
                "LastModifiedByUserName");

            var lastModifiedByUserId = reader.Get<long>("LastModifiedByUserId");

            var validFrom = reader.Get<DateTime>("ValidFromDateTime");
            var validTo = reader.Get<DateTime>("ValidToDateTime");
            var approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");
            var closedDateTime = reader.Get<DateTime?>("ClosedDateTime");
            var hasBeenApproved = reader.Get<bool>("HasBeenApproved");
            var remainingApprovals = new List<string>();

            if (ApprovalStillNeeded(reader))
            {
                remainingApprovals.Add(reader.Get<string>("Approver"));
            }

            var formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));

            var result =
                new LubesAlarmDisableFormDTO(id, floc, alarm, createdByUserId,
                    createdByFullNameWithUserName, createdDateTime, lastModifiedByUserId,
                    validFrom, validTo, formStatus, approvedDateTime, closedDateTime, remainingApprovals,
                    hasBeenApproved, lastModifiedUser, criticality, sapNotification);


            return result;
        }
    }
}