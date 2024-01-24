using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class DocumentSuggestionHistoryDao : AbstractManagedDao, IDocumentSuggestionHistoryDao
    {
        private const string QUERY_HISTORIES_BY_ID = "QueryDocumentSuggestionHistoryById";
        private const string INSERT = "InsertDocumentSuggestionHistory";

        private readonly IUserDao userDao;

        public DocumentSuggestionHistoryDao()
        {
            userDao = DaoRegistry.GetDao<IUserDao>();
        }

        public List<DocumentSuggestionHistory> GetById(long id)
        {
            var command = ManagedCommand;
            command.AddParameter("@Id", id);
            return command.QueryForListResult(PopulateInstance, QUERY_HISTORIES_BY_ID);
        }

        public void Insert(DocumentSuggestionHistory history)
        {
            var command = ManagedCommand;

            var idParameter = command.Parameters.Add("@DocumentSuggestionHistoryId", SqlDbType.BigInt);
            idParameter.Direction = ParameterDirection.Output;

            command.Insert(history, AddInsertParameters, INSERT);
        }

        private void AddInsertParameters(DocumentSuggestionHistory history, SqlCommand command)
        {
            command.AddParameter("Id", history.Id);
            command.AddParameter("FormStatusId", history.FormStatus.IdValue);

            command.AddParameter("FunctionalLocations", history.FunctionalLocations);
            command.AddParameter("DocumentLinks", history.DocumentLinks);

            command.AddParameter("ValidFromDateTime", history.ValidFromDateTime);
            command.AddParameter("ValidToDateTime", history.ValidToDateTime);

            command.AddParameter("LastModifiedByUserId", history.LastModifiedBy.IdValue);
            command.AddParameter("LastModifiedDateTime", history.LastModifiedDate);

            command.AddParameter("@LocationEquipmentNumber", history.LocationEquipmentNumber);
            command.AddParameter("@ScheduledCompletionDateTime", history.ScheduledCompletionDateTime);
            command.AddParameter("@NumberOfExtensions", history.NumberOfExtensions);
            command.AddParameter("@ReasonsForExtension", history.ReasonsForExtension);

            command.AddParameter("@IsExistingDocument", history.IsExistingDocument);
            command.AddParameter("@DocumentOwner", history.DocumentOwner);
            command.AddParameter("@DocumentNumber", history.DocumentNumber);
            command.AddParameter("@DocumentTitle", history.DocumentTitle);

            command.AddParameter("@OriginalMarkedUp", history.OriginalMarkedUp);
            command.AddParameter("@HardCopySubmittedTo", history.HardCopySubmittedTo);

            command.AddParameter("@RecommendedToBeArchived", history.RecommendedToBeArchived);
            command.AddParameter("@Description", history.Description);

            command.AddParameter("@InitialReviewApprovedBy", history.InitialReviewApprovedBy);
            command.AddParameter("@InitialReviewApprovedDateTime", history.InitialReviewApprovedDateTime);

            command.AddParameter("@OwnerReviewApprovedBy", history.OwnerReviewApprovedBy);
            command.AddParameter("@OwnerReviewApprovedDateTime", history.OwnerReviewApprovedDateTime);

            command.AddParameter("@DocumentIssuedApprovedBy", history.DocumentIssuedApprovedBy);
            command.AddParameter("@DocumentIssuedApprovedDateTime", history.DocumentIssuedApprovedDateTime);

            command.AddParameter("@DocumentArchivedApprovedBy", history.DocumentArchivedApprovedBy);
            command.AddParameter("@DocumentArchivedApprovedDateTime", history.DocumentArchivedApprovedDateTime);

            command.AddParameter("@NotApprovedBy", history.NotApprovedBy);
            command.AddParameter("@NotApprovedDateTime", history.NotApprovedDateTime);
            command.AddParameter("@NotApprovedReason", history.NotApprovedReason);
        }

        private DocumentSuggestionHistory PopulateInstance(SqlDataReader reader)
        {
            var id = reader.Get<long>("Id");
            var formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));

            var functionalLocations = reader.Get<string>("FunctionalLocations");
            var documentLinks = reader.Get<string>("DocumentLinks");

            var startDateTime = reader.Get<DateTime>("ValidFromDateTime");
            var suggestedCompletionDateTime = reader.Get<DateTime>("ValidToDateTime");
            var scheduledCompletionDateTime = reader.Get<DateTime?>("ScheduledCompletionDateTime");

            var lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            var lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            var locationEquipmentNumber = reader.Get<String>("LocationEquipmentNumber");

            var numberOfExtensions = reader.Get<int>("NumberOfExtensions");
            var reasonsForExtension = reader.Get<String>("ReasonsForExtension");

            var isExistingDocument = reader.Get<Boolean>("IsExistingDocument");
            var documentOwner = reader.Get<String>("DocumentOwner");
            var documentNumber = reader.Get<String>("DocumentNumber");
            var documentTitle = reader.Get<String>("DocumentTitle");

            var originalMarkedUp = reader.Get<Boolean>("OriginalMarkedUp");
            var hardCopySubmittedTo = reader.Get<String>("HardCopySubmittedTo");

            var recommendedToBeArchived = reader.Get<Boolean>("RecommendedToBeArchived");
            var description = reader.Get<String>("Description");

            var initialReviewApprovedBy = reader.Get<String>("InitialReviewApprovedBy");
            var initialReviewApprovedDateTime = reader.Get<DateTime?>("InitialReviewApprovedDateTime");

            var ownerReviewApprovedBy = reader.Get<String>("OwnerReviewApprovedBy");
            var ownerReviewApprovedDateTime = reader.Get<DateTime?>("OwnerReviewApprovedDateTime");

            var documentIssuedApprovedBy = reader.Get<String>("DocumentIssuedApprovedBy");
            var documentIssuedApprovedDateTime = reader.Get<DateTime?>("DocumentIssuedApprovedDateTime");

            var documentArchivedApprovedBy = reader.Get<String>("DocumentArchivedApprovedBy");
            var documentArchivedApprovedDateTime = reader.Get<DateTime?>("DocumentArchivedApprovedDateTime");

            var notApprovedBy = reader.Get<String>("NotApprovedBy");
            var notApprovedDateTime = reader.Get<DateTime?>("NotApprovedDateTime");
            var notApprovedReason = reader.Get<String>("NotApprovedReason");

            var form = new DocumentSuggestionHistory(id,
                startDateTime,
                suggestedCompletionDateTime,
                formStatus,
                lastModifiedBy,
                lastModifiedDateTime,
                functionalLocations,
                locationEquipmentNumber,
                documentLinks,
                scheduledCompletionDateTime,
                numberOfExtensions,
                reasonsForExtension,
                isExistingDocument,
                documentOwner,
                documentNumber,
                documentTitle,
                originalMarkedUp,
                hardCopySubmittedTo,
                recommendedToBeArchived,
                description,
                initialReviewApprovedBy,
                initialReviewApprovedDateTime,
                ownerReviewApprovedBy,
                ownerReviewApprovedDateTime,
                documentIssuedApprovedBy,
                documentIssuedApprovedDateTime,
                documentArchivedApprovedBy,
                documentArchivedApprovedDateTime,
                notApprovedBy,
                notApprovedDateTime,
                notApprovedReason);

            return form;
        }
    }
}