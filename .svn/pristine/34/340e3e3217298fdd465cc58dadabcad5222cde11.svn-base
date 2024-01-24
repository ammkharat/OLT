using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class DocumentSuggestionHistoryDaoTest : AbstractDaoTest
    {
        private PermitAssessment assessment1;
        private IDocumentSuggestionDao documentSuggestionDao;
        private IDocumentSuggestionHistoryDao historyDao;

        [Ignore] [Test]
        public void ShouldInsert()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2012, 9, 1);

            var insertedDocumentSuggestion = CreateAndInsertDocumentSuggestion();

            var history = insertedDocumentSuggestion.TakeSnapshot();

            historyDao.Insert(history);
            var histories = historyDao.GetById(history.IdValue);

            Assert.AreEqual(1, histories.Count);
            var requeried = histories[0];
            Assert.IsNotNull(requeried);

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
            historyDao = DaoRegistry.GetDao<IDocumentSuggestionHistoryDao>();
        }

        protected override void Cleanup()
        {
        }
    }
}