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
    public class DocumentSuggestionDTODao : AbstractManagedDao, IDocumentSuggestionDTODao
    {
        private const string QUERY_DOCUMENT_SUGGESTION_DTOS_BY_FLOCS =
            "QueryFormDocumentSuggestionByFunctionalLocations";

        private const string QUERY_NON_DRAFT_DOCUMENT_SUGGESTION_DTOS_BY_FLOCS =
            "QueryFormDocumentSuggestionThatAreNonDraftByFunctionalLocations";

        public List<DocumentSuggestionDTO> QueryDocumentSuggestionDtos(IFlocSet flocSet, DateRange dateRange,
            long userId)
        {
            var command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@CreatedByUserId", userId);
            command.AddParameter("@StartOfDateRange", dateRange.SqlFriendlyStart);
            command.AddParameter("@EndOfDateRange", dateRange.SqlFriendlyEnd);
            return GetDtos(command, QUERY_DOCUMENT_SUGGESTION_DTOS_BY_FLOCS);
        }

        public List<DocumentSuggestionDTO> QueryDocumentSuggestionDtosThatAreNonDraftByFunctionalLocations(IFlocSet flocSet,
            DateTime now, long userId)
        {
            var command = ManagedCommand;
            command.AddParameter("@CsvFlocIds", flocSet.FunctionalLocations.BuildIdStringFromList());
            command.AddParameter("@CreatedByUserId", userId);
            command.AddParameter("@Now", now);
            return GetDtos(command, QUERY_NON_DRAFT_DOCUMENT_SUGGESTION_DTOS_BY_FLOCS);
        }

        private static List<DocumentSuggestionDTO> GetDtos(SqlCommand command, string query)
        {
            var result = new Dictionary<long, DocumentSuggestionDTO>();

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

            return new List<DocumentSuggestionDTO>(result.Values);
        }

        private static long GetId(SqlDataReader reader)
        {
            return reader.Get<long>("Id");
        }

        private static string GetFunctionalLocationName(SqlDataReader reader)
        {
            return reader.Get<string>("FullHierarchy");
        }

        private static DocumentSuggestionDTO PopulateInstance(SqlDataReader reader)
        {
            var id = GetId(reader);
            var formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));
            var approvedDateTime = reader.Get<DateTime?>("ApprovedDateTime");

            var validFrom = reader.Get<DateTime>("ValidFromDateTime");
            var validTo = reader.Get<DateTime>("ValidToDateTime");
            var scheduleCompletionDateTime = reader.Get<DateTime?>("ScheduledCompletionDateTime");

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

            var numberOfExtensions = reader.Get<int>("NumberOfExtensions");

            var documentOwner = reader.Get<String>("DocumentOwner");
            var documentNumber = reader.Get<String>("DocumentNumber");
            var documentTitle = reader.Get<String>("DocumentTitle");

            var description = reader.Get<String>("Description");

            var initialReviewApprovedDateTime = reader.Get<DateTime?>("InitialReviewApprovedDateTime");
            var ownerReviewApprovedDateTime = reader.Get<DateTime?>("OwnerReviewApprovedDateTime");
            var documentIssuedApprovedDateTime = reader.Get<DateTime?>("DocumentIssuedApprovedDateTime");
            var documentArchivedApprovedDateTime = reader.Get<DateTime?>("DocumentArchivedApprovedDateTime");
            var notApprovedDateTime = reader.Get<DateTime?>("NotApprovedDateTime");
            var notApprovedReason = reader.Get<String>("NotApprovedReason");

            var floc = GetFunctionalLocationName(reader);

            return new DocumentSuggestionDTO(id,
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
                scheduleCompletionDateTime,
                numberOfExtensions,
                documentOwner,
                documentNumber,
                documentTitle,
                description,
                initialReviewApprovedDateTime,
                ownerReviewApprovedDateTime,
                documentIssuedApprovedDateTime,
                documentArchivedApprovedDateTime,
                notApprovedDateTime,
                notApprovedReason);
        }
    }
}