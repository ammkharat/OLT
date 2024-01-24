using System;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class DocumentSuggestionDao : AbstractManagedDao, IDocumentSuggestionDao
    {
        private const string QUERY_BY_ID_STORED_PROCEDURE = "QueryDocumentSuggestionById";
        private const string INSERT_STORED_PROCEDURE = "InsertDocumentSuggestion";
        private const string UPDATE_STORED_PROCEDURE = "UpdateDocumentSuggestion";
        private const string INSERT_FORM_FUNCTIONAL_LOCATION = "InsertDocumentSuggestionFunctionalLocation";
        private const string DELETE_FORM_FUNCTIONAL_LOCATION = "DeleteDocumentSuggestionFunctionalLocationsByDocumentSuggestionId";
        private const string REMOVE_STORED_PROCEDURE = "RemoveDocumentSuggestion";

        private readonly ICommentDao commentDao;
        private readonly IDocumentLinkDao documentLinkDao;
        private readonly IFunctionalLocationDao flocDao;
        private readonly IUserDao userDao;

        public DocumentSuggestionDao()
        {
            commentDao = DaoRegistry.GetDao<ICommentDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            documentLinkDao = DaoRegistry.GetDao<IDocumentLinkDao>();
        }

        public DocumentSuggestion Insert(DocumentSuggestion form)
        {
            var command = ManagedCommand;
            var idParameter = command.AddIdOutputParameter();
            command.Insert(form, AddInsertParameters, INSERT_STORED_PROCEDURE);
            form.Id = long.Parse(idParameter.Value.ToString());
            InsertFunctionalLocations(command, form);
            InsertNewDocumentLinks(form);
            //Dharmesh  --  start -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            RemoveDeletedDocumentLinks(form);
            //Dharmesh  --  end -- INC0155499 (OLT losing Documents link - Daily Directive & Form 14) -- 15JUN2017
            InsertNewComments(form);
            return form;
        }

        //ayman generic forms
        public DocumentSuggestion QueryByIdAndSiteId(long id,long siteid)
        {
            var command = ManagedCommand;
            return command.QueryByIdAndSiteId(id, siteid, PopulateInstance, "QueryDocumentSuggestionByIdAndSiteId");
        }
        
        public DocumentSuggestion QueryById(long id)
        {
            var command = ManagedCommand;
            return command.QueryById(id, PopulateInstance, QUERY_BY_ID_STORED_PROCEDURE);
        }

        public void Update(DocumentSuggestion form)
        {
            var command = ManagedCommand;

            command.Update(form, AddUpdateParameters, UPDATE_STORED_PROCEDURE);
            UpdateFunctionalLocations(command, form);
            InsertNewDocumentLinks(form);
            RemoveDeletedDocumentLinks(form);
            InsertNewComments(form);
        }

        public void Remove(DocumentSuggestion form)
        {
            var command = ManagedCommand;
            command.Remove(form, REMOVE_STORED_PROCEDURE);
        }

        private void RemoveDeletedDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.RemoveDeletedDocumentLinks(obj, documentLinkDao.QueryByFormOP14Id);
        }

        private void InsertNewDocumentLinks(IDocumentLinksObject obj)
        {
            documentLinkDao.InsertNewDocumentLinks(obj, documentLinkDao.InsertForAssociatedFormDocumentSuggestion);
        }

        private void AddUpdateParameters(DocumentSuggestion form, SqlCommand command)
        {
            command.AddParameter("@Id", form.Id);
            SetCommonAttributes(form, command);
        }

        private void UpdateFunctionalLocations(SqlCommand command, DocumentSuggestion form)
        {
            command.CommandText = DELETE_FORM_FUNCTIONAL_LOCATION;
            command.Parameters.Clear();
            command.AddParameter("@DocumentSuggestionId", form.Id);
            command.ExecuteNonQuery();

            InsertFunctionalLocations(command, form);
        }

        private void InsertFunctionalLocations(SqlCommand command, DocumentSuggestion form)
        {
            if (!form.FunctionalLocations.IsEmpty())
            {
                command.CommandText = INSERT_FORM_FUNCTIONAL_LOCATION;
                foreach (var functionalLocation in form.FunctionalLocations)
                {
                    command.Parameters.Clear();
                    command.AddParameter("@DocumentSuggestionId", form.Id);
                    command.AddParameter("@FunctionalLocationId", functionalLocation.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void AddInsertParameters(DocumentSuggestion form, SqlCommand command)
        {
            SetCommonAttributes(form, command);
        }

        private void SetCommonAttributes(DocumentSuggestion form, SqlCommand command)
        {
            command.AddParameter("@ApprovedDateTime", form.ApprovedDateTime);
            
            command.AddParameter("@FormStatusId", form.FormStatus.Id);
            command.AddParameter("@SiteId", form.SiteId);

            command.AddParameter("@ValidFromDateTime", form.FromDateTime);
            command.AddParameter("@ValidToDateTime", form.ToDateTime);

            command.AddParameter("@ScheduledCompletionDateTime", form.ScheduledCompletionDateTime);
            command.AddParameter("@LocationEquipmentNumber", form.LocationEquipmentNumber);

            command.AddParameter("@CreatedByUserId", form.CreatedBy.Id);
            command.AddParameter("@CreatedDateTime", form.CreatedDateTime);

            command.AddParameter("@LastModifiedByUserId", form.LastModifiedBy.Id);
            command.AddParameter("@LastModifiedDateTime", form.LastModifiedDateTime);

            command.AddParameter("@NumberOfExtensions", form.NumberOfExtensions);
            command.AddParameter("@IsExistingDocument", form.IsExistingDocument);

            command.AddParameter("@DocumentOwner", form.DocumentOwner);
            command.AddParameter("@DocumentNumber", form.DocumentNumber);
            command.AddParameter("@DocumentTitle", form.DocumentTitle);

            command.AddParameter("@OriginalMarkedUp", form.OriginalMarkedUp);
            command.AddParameter("@HardCopySubmittedTo", form.HardCopySubmittedTo);

            command.AddParameter("@RecommendedToBeArchived", form.RecommendedToBeArchived);
            command.AddParameter("@Description", form.Description);
            command.AddParameter("@RichTextDescription", form.RichTextDescription);

            command.AddParameter("@InitialReviewApprovedBy", form.InitialReviewApprovedBy);
            command.AddParameter("@InitialReviewApprovedDateTime", form.InitialReviewApprovedDateTime);

            command.AddParameter("@OwnerReviewApprovedBy", form.OwnerReviewApprovedBy);
            command.AddParameter("@OwnerReviewApprovedDateTime", form.OwnerReviewApprovedDateTime);

            command.AddParameter("@DocumentIssuedApprovedBy", form.DocumentIssuedApprovedBy);
            command.AddParameter("@DocumentIssuedApprovedDateTime", form.DocumentIssuedApprovedDateTime);

            command.AddParameter("@DocumentArchivedApprovedBy", form.DocumentArchivedApprovedBy);
            command.AddParameter("@DocumentArchivedApprovedDateTime", form.DocumentArchivedApprovedDateTime);

            command.AddParameter("@NotApprovedBy", form.NotApprovedBy);
            command.AddParameter("@NotApprovedDateTime", form.NotApprovedDateTime);
            command.AddParameter("@NotApprovedReason", form.NotApprovedReason);
        }

        private DocumentSuggestion PopulateInstance(SqlDataReader reader)
        {
            var id = reader.Get<long>("Id");
            var formStatus = FormStatus.GetById(reader.Get<int>("FormStatusId"));

            var startDateTime = reader.Get<DateTime>("ValidFromDateTime");
            var suggestedCompletionDateTime = reader.Get<DateTime>("ValidToDateTime");
            var scheduledCompletionDateTime = reader.Get<DateTime?>("ScheduledCompletionDateTime");

            var createdBy = userDao.QueryById(reader.Get<long>("CreatedByUserId"));
            var createdDateTime = reader.Get<DateTime>("CreatedDateTime");

            var lastModifiedBy = userDao.QueryById(reader.Get<long>("LastModifiedByUserId"));
            var lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");

            var documentLinks = documentLinkDao.QueryByFormDocumentSuggestionId(id);
            var functionalLocations = flocDao.QueryByFormDocumentSuggestionId(id);

            var siteid = reader.Get<long>("SiteId");    //ayman generic forms

            var form = new DocumentSuggestion(id, startDateTime, suggestedCompletionDateTime, formStatus, createdBy,
                createdDateTime, lastModifiedBy, lastModifiedDateTime, siteid)   //ayman generic forms
            {
                ApprovedDateTime = reader.Get<DateTime?>("ApprovedDateTime"),
                IsDeleted = reader.Get<Boolean>("Deleted"),
                SiteId = reader.Get<long>("SiteId"),
                LocationEquipmentNumber = reader.Get<String>("LocationEquipmentNumber"),
                ScheduledCompletionDateTime = scheduledCompletionDateTime,
                NumberOfExtensions = reader.Get<int>("NumberOfExtensions"),
                IsExistingDocument = reader.Get<Boolean>("IsExistingDocument"),
                DocumentOwner = reader.Get<String>("DocumentOwner"),
                DocumentNumber = reader.Get<String>("DocumentNumber"),
                DocumentTitle = reader.Get<String>("DocumentTitle"),
                OriginalMarkedUp = reader.Get<Boolean>("OriginalMarkedUp"),
                HardCopySubmittedTo = reader.Get<String>("HardCopySubmittedTo"),
                RecommendedToBeArchived = reader.Get<Boolean>("RecommendedToBeArchived"),
                Description = reader.Get<String>("Description"),
                RichTextDescription = reader.Get<String>("RichTextDescription"),
                InitialReviewApprovedBy = reader.Get<String>("InitialReviewApprovedBy"),
                InitialReviewApprovedDateTime = reader.Get<DateTime?>("InitialReviewApprovedDateTime"),
                OwnerReviewApprovedBy = reader.Get<String>("OwnerReviewApprovedBy"),
                OwnerReviewApprovedDateTime = reader.Get<DateTime?>("OwnerReviewApprovedDateTime"),
                DocumentIssuedApprovedBy = reader.Get<String>("DocumentIssuedApprovedBy"),
                DocumentIssuedApprovedDateTime = reader.Get<DateTime?>("DocumentIssuedApprovedDateTime"),
                DocumentArchivedApprovedBy = reader.Get<String>("DocumentArchivedApprovedBy"),
                DocumentArchivedApprovedDateTime = reader.Get<DateTime?>("DocumentArchivedApprovedDateTime"),
                NotApprovedBy = reader.Get<String>("NotApprovedBy"),
                NotApprovedDateTime = reader.Get<DateTime?>("NotApprovedDateTime"),
                NotApprovedReason = reader.Get<String>("NotApprovedReason"),
                DocumentLinks = documentLinks,
                FunctionalLocations = functionalLocations,
                ReasonsForExtension = commentDao.QueryByDocumentSuggestionId(id),
            };

            return form;
        }

        private void InsertNewComments(DocumentSuggestion documentSuggestion)
        {
            if (!documentSuggestion.ReasonsForExtension.IsEmpty())
            {
                foreach (var comment in documentSuggestion.ReasonsForExtension)
                {
                    if (comment.Id.HasNoValue())
                    {
                        commentDao.InsertDocumentSuggestionComment(documentSuggestion.IdValue, comment);
                    }
                }
            }
        }
    }
}