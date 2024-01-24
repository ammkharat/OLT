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
    public class ProcedureDeviationDTODao : AbstractManagedDao, IProcedureDeviationDTODao
    {
        private const string QUERY_PROCEDURE_DEVIATION_DTOS_BY_FLOCS =
            "QueryFormProcedureDeviationByFunctionalLocations";

        private const string QUERY_NON_DRAFT_PROCEDURE_DEVIATION_DTOS_BY_FLOCS =
            "QueryFormProcedureDeviationThatAreNonDraftByFunctionalLocations";

        public List<ProcedureDeviationDTO> QueryProcedureDeviationDtos(IFlocSet flocSet, DateRange dateRange,
            long userId)
        {
            var command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@CreatedByUserId", userId);
            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);
            return GetDtos(command, QUERY_PROCEDURE_DEVIATION_DTOS_BY_FLOCS);
        }

        public List<ProcedureDeviationDTO> QueryProcedureDeviationDtosThatAreNonDraftByFunctionalLocations(
            IFlocSet flocSet,
            DateTime now, long userId)
        {
            var command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@CreatedByUserId", userId);
            command.AddParameter("@Now", now);
            return GetDtos(command, QUERY_NON_DRAFT_PROCEDURE_DEVIATION_DTOS_BY_FLOCS);
        }

        private static List<ProcedureDeviationDTO> GetDtos(SqlCommand command, string query)
        {
            var result = new Dictionary<long, ProcedureDeviationDTO>();

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
                    }
                    else
                    {
                        result.Add(key, PopulateInstance(reader));
                    }
                }
            }

            return new List<ProcedureDeviationDTO>(result.Values);
        }

        private static long GetId(SqlDataReader reader)
        {
            return reader.Get<long>("Id");
        }

        private static string GetFunctionalLocationName(SqlDataReader reader)
        {
            return reader.Get<string>("FullHierarchy");
        }

        private static ProcedureDeviationDTO PopulateInstance(SqlDataReader reader)
        {
            var id = GetId(reader);
            var deviationType = ProcedureDeviationType.GetById(reader.Get<int>("DeviationType"));
            var formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));

            var validFrom = reader.Get<DateTime>("ValidFromDateTime");
            var validTo = reader.Get<DateTime>("ValidToDateTime");

            var createdByUserId = reader.Get<long>("CreatedByUserId");
            var createdByFullName = reader.GetUserFullName("CreatedByFirstName", "CreatedByLastName");
            var createdByFullNameWithUserName = reader.GetUser("CreatedByFirstName", "CreatedByLastName",
                "CreatedByUserName");
            var createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            var lastModifiedByUserId = reader.Get<long>("LastModifiedByUserId");
            var lastModifiedUserFullNameWithUserName = reader.GetUser("LastModifiedByFirstName",
                "LastModifiedByLastName",
                "LastModifiedByUserName");
            var lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            var floc = GetFunctionalLocationName(reader);

            var permanentRevisionRequired = reader.Get<bool>("PermanentRevisionRequired");
            var revertedBackToOriginal = reader.Get<bool>("RevertedBackToOriginal");

            var numberOfExtensions = reader.Get<int>("NumberOfExtensions");

            var operatingProcedureNumber = reader.Get<string>("OperatingProcedureNumber");
            var operatingProcedureTitle = reader.Get<string>("OperatingProcedureTitle");
            var operatingProcedureLevel = OperatingProcedureLevel.GetById(reader.Get<int>("OperatingProcedureLevel"));

            var description = reader.Get<String>("Description");

            var causeDeterminationCategory = reader.Get<string>("CauseDeterminationCategory");

            var cancelledBy = reader.Get<String>("CancelledBy");
            var cancelledDateTime = reader.Get<DateTime?>("CancelledDateTime");
            var cancelledReason = reader.Get<String>("CancelledReason");

            return new ProcedureDeviationDTO(id,
                deviationType,
                permanentRevisionRequired,
                revertedBackToOriginal,
                new List<string> {floc},
                createdByUserId,
                createdByFullName,
                createdByFullNameWithUserName,
                createdDateTime,
                lastModifiedByUserId,
                validFrom,
                validTo,
                formStatus,
                lastModifiedUserFullNameWithUserName,
                lastModifiedDateTime,
                numberOfExtensions,
                operatingProcedureNumber,
                operatingProcedureTitle,
                operatingProcedureLevel,
                description,
                causeDeterminationCategory,
                cancelledBy,
                cancelledDateTime,
                cancelledReason);
        }
    }
}