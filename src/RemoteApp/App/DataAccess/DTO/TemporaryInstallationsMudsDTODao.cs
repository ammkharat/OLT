﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public class TemporaryInstallationsMudsDTODao : AbstractManagedDao, ITemporaryInstallationsMudsDTODao
    {
        private const string QUERY_MUDS_TemporaryInstallations_BY_FLOCS_AND_OTHER_THINGS =
            "QueryFormMudsTemporaryInstallationDTOsByFunctionalLocationsAndOtherThings";

        private const string QUERY_APPROVED_MUDS_TemporaryInstallations_BY_FLOCS =
            "QueryFormDTOsThatAreMudsTemporaryInstallationApprovedDraftExpiredByFunctionalLocations";

        public List<TemporaryInstallationsMudsDTO> QueryFormMudsTemporaryInstallations(IFlocSet flocSet, DateRange dateRange,
            List<FormStatus> formStatuses, bool includeAllDraftFormsRegardlessOfDateRange)
        {
            var command = ManagedCommand;
            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);
            var idStringFromList = flocSet.FunctionalLocations.BuildIdStringFromList();
            command.AddParameter("@CsvFlocIds", idStringFromList);
            var buildIdStringFromList = formStatuses.BuildIdStringFromList();
            command.AddParameter("@CsvFormStatusIds", buildIdStringFromList);
            command.AddParameter("@IncludeAllDraft", includeAllDraftFormsRegardlessOfDateRange);

            return GetDtos(command, QUERY_MUDS_TemporaryInstallations_BY_FLOCS_AND_OTHER_THINGS);
        }

        public List<TemporaryInstallationsMudsDTO> QueryFormMudsTemporaryInstallationsThatAreApprovedDraftExpiredByFunctionalLocations(
            IFlocSet flocSet, DateTime now)
        {
            var command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@Now", now);
            return GetDtos(command, QUERY_APPROVED_MUDS_TemporaryInstallations_BY_FLOCS);
        }

        private static List<TemporaryInstallationsMudsDTO> GetDtos(SqlCommand command, string query)
        {
            var result = new Dictionary<long, TemporaryInstallationsMudsDTO>();

            command.CommandText = query;
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var key = GetId(reader);

                    if (result.ContainsKey(key))
                    {
                        var dto = result[key];
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

            return new List<TemporaryInstallationsMudsDTO>(result.Values);
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

        private static TemporaryInstallationsMudsDTO PopulateInstance(SqlDataReader reader)
        {
            var id = GetId(reader);
            var floc = GetFunctionalLocationName(reader);

            var criticalSystemDefeated = reader.Get<string>("CriticalSystemDefeated");

            //var criticalSystemDefeated = reader.Get<string>("CsdReason");//Changed by ppanigrahi TASK0428706

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

            var remainingApprovals = new List<string>();

            if (ApprovalStillNeeded(reader))
            {
                remainingApprovals.Add(reader.Get<string>("Approver"));
            }

            var hasBeenApproved = reader.Get<bool>("HasBeenApproved");

            var formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));

            var result =
                new TemporaryInstallationsMudsDTO(id, new List<string> { floc }, criticalSystemDefeated, createdByUserId,
                    createdByFullNameWithUserName, createdDateTime, lastModifiedByUserId,
                    validFrom, validTo, formStatus, approvedDateTime, closedDateTime, remainingApprovals,
                    lastModifiedUser,hasBeenApproved);

            return result;
        }
    }
}