using System.Collections.Generic;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Fixtures;
using NMock2;
using NUnit.Framework;
using Has = NUnit.Framework.Has;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class DocumentLinkDaoTest : AbstractDaoTest
    {
        private IDocumentLinkDao dao;
        private ITargetDefinitionDao targetDefinitionDao;
        private ILogDao logDao;
        private Mockery mockery;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IDocumentLinkDao>();
            targetDefinitionDao = DaoRegistry.GetDao<ITargetDefinitionDao>();
            logDao = DaoRegistry.GetDao<ILogDao>();
            mockery = new Mockery();
        }

        protected override void Cleanup() {}

        [Ignore] [Test]
        public void QueryByIdWithKnownIdReturnsADocumentLink()
        {
            DocumentLink result = dao.QueryById(1);
            Assert.IsNotNull(result);
        }

        [Ignore] [Test]
        public void InsertForActionItemDefinitionShouldReturnTheDocumentLinkWithNewID()
        {
            DocumentLink itemToInsert = DocumentLinkFixture.CreateNewDocumentLink();
            const long actionItemDefinitionID = 1;
            dao.InsertForAssociatedActionItemDefinition(itemToInsert, actionItemDefinitionID);
            Assert.IsNotNull(itemToInsert.Id);
        }

        [Ignore] [Test]
        public void InsertForWorkPermitShouldReturnTheDocumentLinkWithNewID()
        {
            DocumentLink itemToInsert = DocumentLinkFixture.CreateNewDocumentLink();
            const long workPermitId = 1;
            dao.InsertForAssociatedWorkPermit(itemToInsert, workPermitId);
            Assert.IsNotNull(itemToInsert.Id);
        }

        [Ignore] [Test]
        public void InsertForActionItemShouldReturnTheDocumentLinkWithNewID()
        {
            DocumentLink itemToInsert = DocumentLinkFixture.CreateNewDocumentLink();
            long actionItemId = TestDataAccessUtil.ExecuteScalarExpression<long>("SELECT Id FROM ActionItem");
            dao.InsertForAssociatedActionItem(itemToInsert, actionItemId);
            Assert.IsNotNull(itemToInsert.Id);
        }

        [Ignore] [Test]
        public void InsertForShiftLogShouldReturnDocumentLinkWithNewId()
        {
            DocumentLink itemToInsert = DocumentLinkFixture.CreateNewDocumentLink();
            Log log = logDao.Insert(LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp());
            dao.InsertForAssociatedLog(itemToInsert, log.IdValue);
            Assert.IsNotNull(itemToInsert.Id);
        }

        [Ignore] [Test]
        public void InsertForLogDefinitionShouldReturnDocumentLinkWithNewId()
        {
            DocumentLink itemToInsert = DocumentLinkFixture.CreateNewDocumentLink();
            const long logDefinitionId = 1;
            dao.InsertForAssociatedLogDefinition(itemToInsert, logDefinitionId);
            Assert.IsNotNull(itemToInsert.Id);
        }

        [Ignore] [Test]
        public void InsertForTargetDefinitionShouldReturnDocumentLinkWithNewId()
        {
            DocumentLink itemToInsert = DocumentLinkFixture.CreateNewDocumentLink();
            const long targetDefinitionId = 1;
            dao.InsertForAssociatedTargetDefinition(itemToInsert, targetDefinitionId);
            Assert.IsNotNull(itemToInsert.Id);
        }

        [Ignore] [Test]
        public void InsertForTargetAlertShouldReturnDocumentLinkWithNewId()
        {
            DocumentLink itemToInsert = DocumentLinkFixture.CreateNewDocumentLink();
            const long targetAlertId = 1;
            dao.InsertForAssociatedTargetAlert(itemToInsert, targetAlertId);
            Assert.IsNotNull(itemToInsert.Id);
        }

        [Ignore] [Test]
        public void QueryForActionItemDefinitionIDShouldReturnListOfDocumentLinks()
        {
            const long actionItemDefinitionID = 1;
            DocumentLink itemToInsert = DocumentLinkFixture.CreateNewDocumentLink();
            dao.InsertForAssociatedActionItemDefinition(itemToInsert, actionItemDefinitionID);
            List<DocumentLink> documentLinks = dao.QueryByActionItemDefinitionId(actionItemDefinitionID);
            Assert.IsNotNull(documentLinks);
            Assert.IsTrue(documentLinks.Count > 0);
            Assert.IsNotNull(documentLinks[0]);
        }

        [Ignore] [Test]
        public void QueryForWorkPermitIDShouldReturnListOfDocumentLinks()
        {
            const long workPermitID = 1;
            DocumentLink itemToInsert = DocumentLinkFixture.CreateNewDocumentLink();
            dao.InsertForAssociatedWorkPermit(itemToInsert, workPermitID);
            List<DocumentLink> documentLinks = dao.QueryByWorkPermitId(workPermitID);
            Assert.IsNotNull(documentLinks);
            Assert.IsTrue(documentLinks.Count > 0);
            Assert.IsNotNull(documentLinks[0]);
        }

        [Ignore] [Test]
        public void QueryForActionItemIDShouldReturnListOfDocumentLinks()
        {
            long actionItemId = TestDataAccessUtil.ExecuteScalarExpression<long>("SELECT Id From ActionItem");
            DocumentLink itemToInsert = DocumentLinkFixture.CreateNewDocumentLink();
            dao.InsertForAssociatedActionItem(itemToInsert, actionItemId);
            List<DocumentLink> documentLinks = dao.QueryByActionItemId(actionItemId);
            Assert.IsNotNull(documentLinks);
            Assert.IsTrue(documentLinks.Count > 0);
            Assert.IsNotNull(documentLinks[0]);
        }

        [Ignore] [Test]
        public void QueryForLogIdShouldReturnListOfDocumentLinks()
        {
            Log log = logDao.Insert(LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp());
            long logId = log.IdValue;

            List<DocumentLink> insertedDocumentLinks = DocumentLinkFixture.CreateDocumentListOfTwo();
            foreach(DocumentLink documentLink in insertedDocumentLinks)
            {
                dao.InsertForAssociatedLog(documentLink, logId);
            }
            List<DocumentLink> retrievedDocumentLinks = dao.QueryByLogId(logId);
            Assert.IsNotNull(retrievedDocumentLinks);

            Assert.That(retrievedDocumentLinks, Has.Some.EqualTo(insertedDocumentLinks[0]));
            Assert.That(retrievedDocumentLinks, Has.Some.EqualTo(insertedDocumentLinks[1]));

        }

        [Ignore] [Test]
        public void QueryForLogDefinitionIdShouldReturnListOfDocumentLinks()
        {
            const long logDefinitionId = 1;
            List<DocumentLink> insertedDocumentLinks = DocumentLinkFixture.CreateDocumentListOfTwo();
            foreach(DocumentLink documentLink in insertedDocumentLinks)
            {
                dao.InsertForAssociatedLogDefinition(documentLink, logDefinitionId);
            }
            List<DocumentLink> retrievedDocumentLinks = dao.QueryByLogDefinitionId(logDefinitionId);
            Assert.IsNotNull(retrievedDocumentLinks);

            Assert.That(retrievedDocumentLinks, Has.Some.EqualTo(insertedDocumentLinks[0]));
            Assert.That(retrievedDocumentLinks, Has.Some.EqualTo(insertedDocumentLinks[1]));

        }

        [Ignore] [Test]
        public void QueryForTargetDefinitionIdShouldReturnListOfDocumentLinks()
        {
            const long targetDefinitionId = 1;
            List<DocumentLink> insertedDocumentLinks = DocumentLinkFixture.CreateDocumentListOfTwo();
            foreach(DocumentLink documentLink in insertedDocumentLinks)
            {
                dao.InsertForAssociatedTargetDefinition(documentLink, targetDefinitionId);
            }
            List<DocumentLink> retrievedDocumentLinks = dao.QueryByTargetDefinitionId(targetDefinitionId);
            Assert.IsNotNull(retrievedDocumentLinks);

            Assert.That(retrievedDocumentLinks, Has.Some.EqualTo(insertedDocumentLinks[0]));
            Assert.That(retrievedDocumentLinks, Has.Some.EqualTo(insertedDocumentLinks[1]));
        }

        [Ignore] [Test]
        public void QueryForTargetAlertIdShouldReturnListOfDocumentLinks()
        {
            const long targetAlertId = 1;
            List<DocumentLink> insertedDocumentLinks = DocumentLinkFixture.CreateDocumentListOfTwo();
            foreach(DocumentLink documentLink in insertedDocumentLinks)
            {
                dao.InsertForAssociatedTargetAlert(documentLink, targetAlertId);
            }
            List<DocumentLink> retrievedDocumentLinks = dao.QueryByTargetAlertId(targetAlertId);
            Assert.IsNotNull(retrievedDocumentLinks);

            Assert.That(retrievedDocumentLinks, Has.Some.EqualTo(insertedDocumentLinks[0]));
            Assert.That(retrievedDocumentLinks, Has.Some.EqualTo(insertedDocumentLinks[1]));

        }

        [Ignore] [Test]
        public void ShouldRemoveDeletedDocumentLinks()
        {
            var queryDelegateMock = mockery.NewMock<IQueryDocumentLinksByDomainObjectId>();
            TargetDefinition targetDefinition = InsertTargetDefinitionWithTwoDocumentLinks();
            IDocumentLinksObject documentLinksObject = targetDefinition;
            List<DocumentLink> previousDocumentLinks = targetDefinition.DocumentLinks;
            DocumentLink firstLink = previousDocumentLinks[0];
            DocumentLink secondLink = previousDocumentLinks[1];
            // Simulate second link has been deleted.
            var currentDocumentLinks = new List<DocumentLink>{firstLink};
            targetDefinition.DocumentLinks = currentDocumentLinks;
            Expect.Once.On(queryDelegateMock).Method("QueryByDomainObjectId").With(documentLinksObject.IdValue).
                    Will(Return.Value(previousDocumentLinks));
            dao.RemoveDeletedDocumentLinks(documentLinksObject,
                                                   queryDelegateMock.QueryByDomainObjectId);
            List<DocumentLink> retrievedDocumentLinks = dao.QueryByTargetDefinitionId(targetDefinition.IdValue);
            Assert.IsTrue(retrievedDocumentLinks.Contains(firstLink));
            Assert.IsFalse(retrievedDocumentLinks.Contains(secondLink));
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void RemoveDeletedDocumentLinksShouldRemoveAllDocumentLinksWhenAllDeleted()
        {
            var queryDelegateMock = mockery.NewMock<IQueryDocumentLinksByDomainObjectId>();
            TargetDefinition targetDefinition = InsertTargetDefinitionWithTwoDocumentLinks();
            IDocumentLinksObject documentLinksObject = targetDefinition;
            List<DocumentLink> previousDocumentLinks = targetDefinition.DocumentLinks;
            // Simulate all links have been deleted.
            var currentDocumentLinks = new List<DocumentLink>();
            targetDefinition.DocumentLinks = currentDocumentLinks;
            Expect.Once.On(queryDelegateMock).Method("QueryByDomainObjectId").With(documentLinksObject.IdValue).
                    Will(Return.Value(previousDocumentLinks));
            dao.RemoveDeletedDocumentLinks(documentLinksObject,
                                                   queryDelegateMock.QueryByDomainObjectId);
            List<DocumentLink> retrievedDocumentLinks = dao.QueryByTargetDefinitionId(targetDefinition.IdValue);
            Assert.AreEqual(0, retrievedDocumentLinks.Count);
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldInsertNewDocumentLinks()
        {
            var insertDelegateMock =
                    mockery.NewMock<IInsertDocumentLinkForAssociatedDomainObjectId>();
            var definition = TargetDefinitionFixture.CreateTargetDefinition();
            definition.Assignment = null;
            TargetDefinition targetDefinition = targetDefinitionDao.Insert(definition);
            DocumentLink documentLink = DocumentLinkFixture.CreateNewDocumentLink();
            targetDefinition.DocumentLinks.Add(documentLink);
            IDocumentLinksObject documentLinksObject = targetDefinition;
            Expect.Once.On(insertDelegateMock).Method("InsertForAssociatedDomainObjectId").
                    With(documentLink, documentLinksObject.IdValue);
            dao.InsertNewDocumentLinks(documentLinksObject,
                                               insertDelegateMock.InsertForAssociatedDomainObjectId);
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void InsertNewDocumentLinksShouldNotInsertDocumentLinkAlreadyInDatabase()
        {
            var insertDelegateMock =
                    mockery.NewMock<IInsertDocumentLinkForAssociatedDomainObjectId>();
            TargetDefinition targetDefinition = TargetDefinitionFixture.CreateTargetDefinition();
            targetDefinition.Assignment = null;
            DocumentLink documentLink = DocumentLinkFixture.CreateNewDocumentLink();
            targetDefinition.DocumentLinks.Add(documentLink);
            targetDefinition = targetDefinitionDao.Insert(targetDefinition);
            IDocumentLinksObject documentLinksObject = targetDefinition;
            Expect.Never.On(insertDelegateMock).Method("InsertForAssociatedDomainObjectId").
                    With(documentLink, documentLinksObject.IdValue);
            dao.InsertNewDocumentLinks(documentLinksObject,
                                               insertDelegateMock.InsertForAssociatedDomainObjectId);
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        private TargetDefinition InsertTargetDefinitionWithTwoDocumentLinks()
        {
            TargetDefinition targetDefinition = TargetDefinitionFixture.CreateTargetDefinition();
            targetDefinition.Assignment = null;
            List<DocumentLink> documentLinks = DocumentLinkFixture.CreateDocumentListOfTwo();
            targetDefinition.DocumentLinks.AddRange(documentLinks);
            return targetDefinitionDao.Insert(targetDefinition);
        }

        public interface IQueryDocumentLinksByDomainObjectId
        {
            List<DocumentLink> QueryByDomainObjectId(long id);
        }

        public interface IInsertDocumentLinkForAssociatedDomainObjectId
        {
            void InsertForAssociatedDomainObjectId(DocumentLink documentLink, long id);
        }
    }
}