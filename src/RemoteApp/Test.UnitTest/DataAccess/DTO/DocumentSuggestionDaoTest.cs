using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture]
    [Category("Database")]
    public class DocumentSuggestionDaoTest : AbstractDaoTest
    {
        private IDocumentSuggestionDao documentSuggestionDao;

        [Ignore] [Test]
        public void QueryByIdShouldBringBackAnInsertedDocumentSuggestion()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2012, 9, 1);

            var insertedDocumentSuggestion = CreateAndInsertDocumentSuggestion();
            var retrievedDocumentSuggestion = documentSuggestionDao.QueryById(insertedDocumentSuggestion.IdValue);

            Assert.AreEqual(insertedDocumentSuggestion.Id, retrievedDocumentSuggestion.Id);
            Assert.AreEqual(insertedDocumentSuggestion.FormStatus, retrievedDocumentSuggestion.FormStatus);

            Assert.AreEqual(insertedDocumentSuggestion.CreatedBy.IdValue, retrievedDocumentSuggestion.CreatedBy.IdValue);
            Assert.AreEqual(insertedDocumentSuggestion.CreatedDateTime, retrievedDocumentSuggestion.CreatedDateTime);

            Assert.AreEqual(insertedDocumentSuggestion.LastModifiedBy.IdValue, retrievedDocumentSuggestion.LastModifiedBy.IdValue);
            Assert.AreEqual(insertedDocumentSuggestion.LastModifiedDateTime,
                retrievedDocumentSuggestion.LastModifiedDateTime);

            Assert.AreEqual(insertedDocumentSuggestion.FunctionalLocations.Count,
                retrievedDocumentSuggestion.FunctionalLocations.Count);
            Assert.AreEqual(insertedDocumentSuggestion.LocationEquipmentNumber,
                retrievedDocumentSuggestion.LocationEquipmentNumber);
            Assert.AreEqual(insertedDocumentSuggestion.DocumentLinks.Count,
                retrievedDocumentSuggestion.DocumentLinks.Count);

            Assert.AreEqual(insertedDocumentSuggestion.FromDateTime, retrievedDocumentSuggestion.FromDateTime);
            Assert.AreEqual(insertedDocumentSuggestion.ToDateTime, retrievedDocumentSuggestion.ToDateTime);

            Assert.AreEqual(insertedDocumentSuggestion.ScheduledCompletionDateTime,
                retrievedDocumentSuggestion.ScheduledCompletionDateTime);
            Assert.AreEqual(insertedDocumentSuggestion.NumberOfExtensions,
                retrievedDocumentSuggestion.NumberOfExtensions);
            Assert.AreEqual(insertedDocumentSuggestion.ReasonsForExtension.Count,
                retrievedDocumentSuggestion.ReasonsForExtension.Count);

            Assert.AreEqual(insertedDocumentSuggestion.IsExistingDocument,
                retrievedDocumentSuggestion.IsExistingDocument);
            Assert.AreEqual(insertedDocumentSuggestion.DocumentOwner, retrievedDocumentSuggestion.DocumentOwner);
            Assert.AreEqual(insertedDocumentSuggestion.DocumentNumber, retrievedDocumentSuggestion.DocumentNumber);
            Assert.AreEqual(insertedDocumentSuggestion.DocumentTitle, retrievedDocumentSuggestion.DocumentTitle);

            Assert.AreEqual(insertedDocumentSuggestion.OriginalMarkedUp, retrievedDocumentSuggestion.OriginalMarkedUp);
            Assert.AreEqual(insertedDocumentSuggestion.HardCopySubmittedTo,
                retrievedDocumentSuggestion.HardCopySubmittedTo);

            Assert.AreEqual(insertedDocumentSuggestion.RecommendedToBeArchived,
                retrievedDocumentSuggestion.RecommendedToBeArchived);
            Assert.AreEqual(insertedDocumentSuggestion.Description, retrievedDocumentSuggestion.Description);

            Assert.AreEqual(insertedDocumentSuggestion.InitialReviewApprovedBy,
                retrievedDocumentSuggestion.InitialReviewApprovedBy);
            Assert.AreEqual(insertedDocumentSuggestion.InitialReviewApprovedDateTime,
                retrievedDocumentSuggestion.InitialReviewApprovedDateTime);

            Assert.AreEqual(insertedDocumentSuggestion.OwnerReviewApprovedBy,
                retrievedDocumentSuggestion.OwnerReviewApprovedBy);
            Assert.AreEqual(insertedDocumentSuggestion.OwnerReviewApprovedDateTime,
                retrievedDocumentSuggestion.OwnerReviewApprovedDateTime);

            Assert.AreEqual(insertedDocumentSuggestion.DocumentIssuedApprovedBy,
                retrievedDocumentSuggestion.DocumentIssuedApprovedBy);
            Assert.AreEqual(insertedDocumentSuggestion.DocumentIssuedApprovedDateTime,
                retrievedDocumentSuggestion.DocumentIssuedApprovedDateTime);

            Assert.AreEqual(insertedDocumentSuggestion.NotApprovedBy, retrievedDocumentSuggestion.NotApprovedBy);
            Assert.AreEqual(insertedDocumentSuggestion.NotApprovedDateTime,
                retrievedDocumentSuggestion.NotApprovedDateTime);
            Assert.AreEqual(insertedDocumentSuggestion.NotApprovedReason,
                retrievedDocumentSuggestion.NotApprovedReason);

            Clock.UnFreeze();
        }

        [Ignore] [Test]
        public void ShouldUpdateDocumentSuggestion()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2012, 9, 1);

            var floc = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL_SWM();

            var documentSuggestionToUpdate = CreateAndInsertDocumentSuggestion();

            var user = documentSuggestionToUpdate.CreatedBy;

            documentSuggestionToUpdate.LastModifiedBy = user;
            documentSuggestionToUpdate.LastModifiedDateTime = Clock.Now;

            documentSuggestionToUpdate.FormStatus = FormStatus.OwnerReview;
            documentSuggestionToUpdate.InitialReviewApprovedBy = "Initial approver name";
            documentSuggestionToUpdate.InitialReviewApprovedDateTime = Clock.Now;

            documentSuggestionToUpdate.FunctionalLocations.Add(floc);
            documentSuggestionToUpdate.LocationEquipmentNumber = "NEWLOCEQNUM";

            documentSuggestionToUpdate.ScheduledCompletionDateTime =
                documentSuggestionToUpdate.ScheduledCompletionDateTime.Value.AddDays(5);
            documentSuggestionToUpdate.NumberOfExtensions++;
            documentSuggestionToUpdate.ReasonsForExtension.Add(new Comment(user, Clock.Now, "Yet another extension"));

            documentSuggestionToUpdate.DocumentOwner = "New Doc Owner";
            documentSuggestionToUpdate.DocumentNumber = "New Doc Number";
            documentSuggestionToUpdate.DocumentTitle = "New Doc Title";

            documentSuggestionToUpdate.OriginalMarkedUp = !documentSuggestionToUpdate.OriginalMarkedUp;
            documentSuggestionToUpdate.HardCopySubmittedTo = string.Empty;

            documentSuggestionToUpdate.RecommendedToBeArchived = !documentSuggestionToUpdate.RecommendedToBeArchived;
            documentSuggestionToUpdate.Description = "New Description";

            documentSuggestionDao.Update(documentSuggestionToUpdate);
            var retrievedDocumentSuggestion = documentSuggestionDao.QueryById(documentSuggestionToUpdate.IdValue);

            Assert.AreEqual(documentSuggestionToUpdate.Id, retrievedDocumentSuggestion.Id);
            Assert.AreEqual(documentSuggestionToUpdate.FormStatus, retrievedDocumentSuggestion.FormStatus);

            Assert.AreEqual(documentSuggestionToUpdate.CreatedBy.IdValue, retrievedDocumentSuggestion.CreatedBy.IdValue);
            Assert.AreEqual(documentSuggestionToUpdate.CreatedDateTime, retrievedDocumentSuggestion.CreatedDateTime);

            Assert.AreEqual(documentSuggestionToUpdate.LastModifiedBy.IdValue, retrievedDocumentSuggestion.LastModifiedBy.IdValue);
            Assert.AreEqual(documentSuggestionToUpdate.LastModifiedDateTime,
                retrievedDocumentSuggestion.LastModifiedDateTime);

            Assert.AreEqual(documentSuggestionToUpdate.FunctionalLocations.Count,
                retrievedDocumentSuggestion.FunctionalLocations.Count);
            Assert.AreEqual(documentSuggestionToUpdate.LocationEquipmentNumber,
                retrievedDocumentSuggestion.LocationEquipmentNumber);
            Assert.AreEqual(documentSuggestionToUpdate.DocumentLinks.Count,
                retrievedDocumentSuggestion.DocumentLinks.Count);

            Assert.AreEqual(documentSuggestionToUpdate.FromDateTime, retrievedDocumentSuggestion.FromDateTime);
            Assert.AreEqual(documentSuggestionToUpdate.ToDateTime, retrievedDocumentSuggestion.ToDateTime);

            Assert.AreEqual(documentSuggestionToUpdate.ScheduledCompletionDateTime,
                retrievedDocumentSuggestion.ScheduledCompletionDateTime);
            Assert.AreEqual(documentSuggestionToUpdate.NumberOfExtensions,
                retrievedDocumentSuggestion.NumberOfExtensions);
            Assert.AreEqual(documentSuggestionToUpdate.ReasonsForExtension.Count,
                retrievedDocumentSuggestion.ReasonsForExtension.Count);

            Assert.AreEqual(documentSuggestionToUpdate.IsExistingDocument,
                retrievedDocumentSuggestion.IsExistingDocument);
            Assert.AreEqual(documentSuggestionToUpdate.DocumentOwner, retrievedDocumentSuggestion.DocumentOwner);
            Assert.AreEqual(documentSuggestionToUpdate.DocumentNumber, retrievedDocumentSuggestion.DocumentNumber);
            Assert.AreEqual(documentSuggestionToUpdate.DocumentTitle, retrievedDocumentSuggestion.DocumentTitle);

            Assert.AreEqual(documentSuggestionToUpdate.OriginalMarkedUp, retrievedDocumentSuggestion.OriginalMarkedUp);
            Assert.AreEqual(documentSuggestionToUpdate.HardCopySubmittedTo,
                retrievedDocumentSuggestion.HardCopySubmittedTo);

            Assert.AreEqual(documentSuggestionToUpdate.RecommendedToBeArchived,
                retrievedDocumentSuggestion.RecommendedToBeArchived);
            Assert.AreEqual(documentSuggestionToUpdate.Description, retrievedDocumentSuggestion.Description);

            Assert.AreEqual(documentSuggestionToUpdate.InitialReviewApprovedBy,
                retrievedDocumentSuggestion.InitialReviewApprovedBy);
            Assert.AreEqual(documentSuggestionToUpdate.InitialReviewApprovedDateTime,
                retrievedDocumentSuggestion.InitialReviewApprovedDateTime);

            Assert.AreEqual(documentSuggestionToUpdate.OwnerReviewApprovedBy,
                retrievedDocumentSuggestion.OwnerReviewApprovedBy);
            Assert.AreEqual(documentSuggestionToUpdate.OwnerReviewApprovedDateTime,
                retrievedDocumentSuggestion.OwnerReviewApprovedDateTime);

            Assert.AreEqual(documentSuggestionToUpdate.DocumentIssuedApprovedBy,
                retrievedDocumentSuggestion.DocumentIssuedApprovedBy);
            Assert.AreEqual(documentSuggestionToUpdate.DocumentIssuedApprovedDateTime,
                retrievedDocumentSuggestion.DocumentIssuedApprovedDateTime);

            Assert.AreEqual(documentSuggestionToUpdate.NotApprovedBy, retrievedDocumentSuggestion.NotApprovedBy);
            Assert.AreEqual(documentSuggestionToUpdate.NotApprovedDateTime,
                retrievedDocumentSuggestion.NotApprovedDateTime);
            Assert.AreEqual(documentSuggestionToUpdate.NotApprovedReason,
                retrievedDocumentSuggestion.NotApprovedReason);

            Clock.UnFreeze();
        }

        private DocumentSuggestion CreateAndInsertDocumentSuggestion()
        {
            var floc1 = FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI();
            var floc2 = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL();
            var flocs = new List<FunctionalLocation> {floc1, floc2};

            var validFromDateTime = new DateTime(2012, 9, 1);
            var validToDateTime = new DateTime(2012, 9, 2);

            var documentSuggestion = DocumentSuggestionFixture.CreateForInsert(flocs, validFromDateTime, validToDateTime,
                FormStatus.Draft, UserFixture.CreateOilSandsUserWithUserPrintPreference());

            return documentSuggestionDao.Insert(documentSuggestion);
        }

        protected override void TestInitialize()
        {
            documentSuggestionDao = DaoRegistry.GetDao<IDocumentSuggestionDao>();
        }

        protected override void Cleanup()
        {
        }
    }
}