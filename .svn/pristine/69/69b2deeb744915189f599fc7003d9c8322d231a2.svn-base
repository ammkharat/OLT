using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture]
    [Category("Database")]
    public class DocumentSuggestionDTODaoTest : AbstractDaoTest
    {
        private IDocumentSuggestionDTODao documentSuggestionDTODao;
        private IDocumentSuggestionDao documentSuggestionDao;

        [Ignore] [Test]
        public void QueryDocumentSuggestionsByFlocShouldFullyPopulateADTO()
        {
            var floc1 = FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI();
            var floc2 = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL();

            Clock.Freeze();
            Clock.Now = new DateTime(2015, 7, 7);

            var startDate = new DateTime(2015, 7, 7);
            var endDate = new DateTime(2015, 7, 8);

            var insertedDocumentSuggestion =
                CreateAndInsertDocumentSuggestion(new List<FunctionalLocation> {floc1, floc2}, startDate,
                    endDate, FormStatus.InitialReview);

            var documentSuggestionDTO =
                documentSuggestionDTODao.QueryDocumentSuggestionDtos(new RootFlocSet(floc1, floc2),
                    new DateRange(startDate.ToDate(), endDate.ToDate()), insertedDocumentSuggestion.CreatedBy.IdValue).First();

            Assert.AreEqual(insertedDocumentSuggestion.Id, documentSuggestionDTO.Id);
            Assert.AreEqual(insertedDocumentSuggestion.FormStatus, documentSuggestionDTO.Status);

            Assert.AreEqual(insertedDocumentSuggestion.CreatedBy.IdValue, documentSuggestionDTO.CreatedByUserId);
            Assert.AreEqual(insertedDocumentSuggestion.CreatedDateTime, documentSuggestionDTO.CreatedDateTime);

            Assert.AreEqual(insertedDocumentSuggestion.LastModifiedBy.IdValue,
                documentSuggestionDTO.LastModifiedByUserId);
            Assert.AreEqual(insertedDocumentSuggestion.LastModifiedDateTime, documentSuggestionDTO.LastModified);

            Assert.AreEqual(insertedDocumentSuggestion.FromDateTime, documentSuggestionDTO.ValidFrom);
            Assert.AreEqual(insertedDocumentSuggestion.ToDateTime, documentSuggestionDTO.ValidTo);

            Assert.AreEqual(insertedDocumentSuggestion.ScheduledCompletionDateTime,
                documentSuggestionDTO.ScheduledCompletionDateTime);
            Assert.AreEqual(insertedDocumentSuggestion.NumberOfExtensions,
                documentSuggestionDTO.NumberOfExtensions);

            Assert.AreEqual(insertedDocumentSuggestion.DocumentOwner, documentSuggestionDTO.DocumentOwner);
            Assert.AreEqual(insertedDocumentSuggestion.DocumentNumber, documentSuggestionDTO.DocumentNumber);

            Assert.AreEqual(insertedDocumentSuggestion.Description, documentSuggestionDTO.Description);

            Assert.AreEqual(insertedDocumentSuggestion.InitialReviewApprovedDateTime,
                documentSuggestionDTO.InitialReviewApprovedDateTime);
            Assert.AreEqual(insertedDocumentSuggestion.OwnerReviewApprovedDateTime,
                documentSuggestionDTO.OwnerReviewApprovedDateTime);
            Assert.AreEqual(insertedDocumentSuggestion.DocumentIssuedApprovedDateTime,
                documentSuggestionDTO.DocumentIssuedApprovedDateTime);
            Assert.AreEqual(insertedDocumentSuggestion.NotApprovedDateTime, documentSuggestionDTO.NotApprovedDateTime);

            Assert.IsTrue(documentSuggestionDTO.FunctionalLocationNames.Contains(floc1.FullHierarchy));
            Assert.IsTrue(documentSuggestionDTO.FunctionalLocationNames.Contains(floc2.FullHierarchy));

            Clock.UnFreeze();
        }

        [Ignore] [Test]
        public void QueryDocumentSuggestionsByFlocShouldOnlyBringBackFormsThatAreNotDeleted()
        {
            var floc1 = FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI();
            var floc2 = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL();
            var floc3 = FunctionalLocationFixture.GetReal_UP1();
            var floc4 = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL();

            Clock.Freeze();
            Clock.Now = new DateTime(2015, 7, 7);

            var firstDocumentSuggestion = CreateAndInsertDocumentSuggestion(
                new List<FunctionalLocation> {floc1, floc2}, new DateTime(2015, 7, 7),
                new DateTime(2015, 7, 8), FormStatus.InitialReview);
            var secondDocumentSuggestion = CreateAndInsertDocumentSuggestion(floc2, new DateTime(2015, 7, 8),
                new DateTime(2015, 7, 10), FormStatus.OwnerReview);
            var thirdDocumentSuggestion = CreateAndInsertDocumentSuggestion(floc3, new DateTime(2015, 7, 12),
                new DateTime(2015, 7, 15), FormStatus.RevisionInProgress);
            var fourthDocumentSuggestion = CreateAndInsertDocumentSuggestion(floc4, new DateTime(2015, 7, 8),
                new DateTime(2015, 7, 14), FormStatus.NotApproved);

            // Delete one of the forms
            documentSuggestionDao.Remove(fourthDocumentSuggestion);

            var results =
                documentSuggestionDTODao.QueryDocumentSuggestionDtos(new RootFlocSet(floc1, floc2, floc3, floc4),
                    new DateRange(new Date(2015, 7, 7), new Date(2015, 7, 15)), firstDocumentSuggestion.CreatedBy.IdValue);

            Assert.AreEqual(3, results.Count);
            Assert.IsTrue(results.Exists(form => form.Id == firstDocumentSuggestion.Id));
            Assert.IsTrue(results.Exists(form => form.Id == secondDocumentSuggestion.Id));
            Assert.IsTrue(results.Exists(form => form.Id == thirdDocumentSuggestion.Id));
            Assert.IsFalse(results.Exists(form => form.Id == fourthDocumentSuggestion.Id));

            Clock.UnFreeze();
        }

        private DocumentSuggestion CreateAndInsertDocumentSuggestion(List<FunctionalLocation> flocs,
            DateTime validFromDateTime,
            DateTime validToDateTime, FormStatus status)
        {
            var documentSuggestion = DocumentSuggestionFixture.CreateForInsert(flocs, validFromDateTime, validToDateTime,
                FormStatus.Draft, UserFixture.CreateOilSandsUserWithUserPrintPreference());

            documentSuggestion.FormStatus = status;

            return documentSuggestionDao.Insert(documentSuggestion);
        }

        private DocumentSuggestion CreateAndInsertDocumentSuggestion(FunctionalLocation floc, DateTime validFromDateTime,
            DateTime validToDateTime, FormStatus status)
        {
            var flocs = new List<FunctionalLocation> {floc};

            return CreateAndInsertDocumentSuggestion(flocs, validFromDateTime, validToDateTime, status);
        }

        protected override void TestInitialize()
        {
            documentSuggestionDao = DaoRegistry.GetDao<IDocumentSuggestionDao>();
            documentSuggestionDTODao = DaoRegistry.GetDao<IDocumentSuggestionDTODao>();
        }

        protected override void Cleanup()
        {
        }
    }
}