using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class PermitRequestMontrealDaoTest : AbstractDaoTest
    {
        private IPermitRequestMontrealDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IPermitRequestMontrealDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            PermitRequestMontreal original = PermitRequestMontrealFixture.CreateForInsert(DataSource.MANUAL);
            original.FunctionalLocations.Clear();
            original.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_MT1_A001_U010());
            original.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_MT1_A002_U430());

            PermitRequestMontreal saved = dao.Insert(original);

            PermitRequestMontreal requeried = dao.QueryById(saved.IdValue);
            Assert.IsNotNull(requeried);

            Assert.AreEqual(WorkPermitMontrealType.MODERATE_HOT.Id, requeried.WorkPermitType.Id);
            Assert.AreEqual(new Date(2001, 2, 3), requeried.StartDate);
            Assert.AreEqual(new Date(2001, 4, 5), requeried.EndDate);
            Assert.AreEqual(saved.RequestedByGroup.Id, requeried.RequestedByGroup.Id);
            Assert.AreEqual(saved.CompletionStatus, requeried.CompletionStatus);
            Assert.AreEqual("112233", requeried.WorkOrderNumber);
            Assert.AreEqual("020", requeried.OperationNumber);
            Assert.AreEqual("0110", requeried.SubOperationNumber);
            Assert.AreEqual("trade ABC", requeried.Trade);
            Assert.AreEqual("permit request description", requeried.Description);
            Assert.AreEqual("Black & McDonald", requeried.Company);
            Assert.AreEqual("Some Supervisor", requeried.Supervisor);
            Assert.AreEqual("01234", requeried.ExcavationNumber);

            Assert.AreEqual(DataSource.MANUAL, requeried.DataSource);
            Assert.AreEqual(UserFixture.CreateOperatorOltUser1InFortMcMurrySite().Id, requeried.LastImportedByUser.Id);
            Assert.AreEqual(new DateTime(2001, 10, 11), requeried.LastImportedDateTime);
            Assert.AreEqual(UserFixture.CreateAdmin().Id, requeried.LastSubmittedByUser.Id);
            Assert.AreEqual(new DateTime(2001, 12, 13), requeried.LastSubmittedDateTime);

            Assert.AreEqual(UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB().Id, requeried.CreatedBy.Id);
            Assert.AreEqual(new DateTime(2002, 6, 7), requeried.CreatedDateTime);
            Assert.AreEqual(UserFixture.CreateOperatorGoofyInFortMcMurrySite().Id, requeried.LastModifiedBy.Id);
            Assert.AreEqual(new DateTime(2002, 8, 9), requeried.LastModifiedDateTime);

            Assert.AreEqual(2, requeried.FunctionalLocations.Count);
            Assert.IsTrue(requeried.FunctionalLocations.Exists(floc => floc.FullHierarchy == FunctionalLocationFixture.GetReal_MT1_A001_U010().FullHierarchy));
            Assert.IsTrue(requeried.FunctionalLocations.Exists(floc => floc.FullHierarchy == FunctionalLocationFixture.GetReal_MT1_A002_U430().FullHierarchy));
        }

        [Ignore] [Test]
        public void ShouldInsertNullFields()
        {
            PermitRequestMontreal request = PermitRequestMontrealFixture.CreateForInsert(DataSource.MANUAL);
            request.WorkOrderNumber = null;
            request.OperationNumber = null;
            request.SubOperationNumber = null;
            request.Company = null;
            request.Supervisor = null;
            request.ExcavationNumber = null;
            request.LastImportedByUser = null;
            request.LastImportedDateTime = null;
            request.LastSubmittedByUser = null;
            request.LastSubmittedDateTime = null;
            request.SapDescription = null;
            request.RequestedByGroup = null;

            PermitRequestMontreal saved = dao.Insert(request);

            PermitRequestMontreal requeried = dao.QueryById(saved.IdValue);
            Assert.IsNotNull(requeried);
            Assert.IsNull(requeried.WorkOrderNumber);
            Assert.IsNull(requeried.OperationNumber);
            Assert.IsNull(requeried.SubOperationNumber);
            Assert.IsNull(requeried.Company);
            Assert.IsNull(requeried.Supervisor);
            Assert.IsNull(requeried.ExcavationNumber);
            Assert.IsNull(requeried.LastImportedByUser);
            Assert.IsNull(requeried.LastImportedDateTime);
            Assert.IsNull(requeried.LastSubmittedByUser);
            Assert.IsNull(requeried.LastSubmittedDateTime);
            Assert.IsNull(requeried.SapDescription);
            Assert.IsNull(requeried.RequestedByGroup);
        }

        [Ignore] [Test]
        public void ShouldUpdate()
        {
            PermitRequestMontreal request = PermitRequestMontrealFixture.CreateForInsert(DataSource.MANUAL);
            request.FunctionalLocations.Clear();
            request.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_MT1_A001_U010());
            request.LastModifiedBy = UserFixture.CreateEngineeringSupport();
            request.LastModifiedDateTime = new DateTime(2001, 1, 20);
            request = dao.Insert(request);
            long id = request.IdValue;

            {
                PermitRequestMontreal requeried = dao.QueryById(id);
                Assert.IsNotNull(requeried);
                Assert.IsFalse(requeried.IsModified);

                requeried.WorkPermitType = WorkPermitMontrealType.VEHICLE_ENTRY;
                requeried.FunctionalLocations.Clear();
                requeried.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI());
                requeried.StartDate = new Date(2010, 10, 1);
                requeried.EndDate = new Date(2010, 10, 2);
                requeried.RequestedByGroup = null;
                requeried.WorkOrderNumber = "11 new";
                requeried.OperationNumber = "22n";
                requeried.SubOperationNumber = "44j";
                requeried.Trade = "trade new";
                requeried.Description = "description new";
                requeried.Company = "company new";
                requeried.Supervisor = "supervisor new";
                requeried.ExcavationNumber = "excavation new";
                requeried.LastImportedByUser = UserFixture.CreateAdmin();
                requeried.LastImportedDateTime = new DateTime(2010, 10, 4);
                requeried.LastSubmittedByUser = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
                requeried.LastSubmittedDateTime = new DateTime(2010, 10, 5);
                requeried.LastModifiedBy = UserFixture.CreateOperatorOltUser1InFortMcMurrySite();
                requeried.LastModifiedDateTime = new DateTime(2010, 10, 3);
                requeried.IsModified = true;
                requeried.CompletionStatus = PermitRequestCompletionStatus.Incomplete;

                dao.Update(requeried);
            }
            {
                PermitRequestMontreal requeried = dao.QueryById(id);
                Assert.IsNotNull(requeried);

                Assert.AreEqual(WorkPermitMontrealType.VEHICLE_ENTRY.Id, requeried.WorkPermitType.Id);
                Assert.AreEqual(1, requeried.FunctionalLocations.Count);
                Assert.AreEqual(FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI().Id, requeried.FunctionalLocations[0].Id);
                Assert.AreEqual(new Date(2010, 10, 1), requeried.StartDate);
                Assert.AreEqual(new Date(2010, 10, 2), requeried.EndDate);
                Assert.IsNull(requeried.RequestedByGroup);
                Assert.AreEqual("11 new", requeried.WorkOrderNumber);
                Assert.AreEqual("22n", requeried.OperationNumber);
                Assert.AreEqual("44j", requeried.SubOperationNumber);
                Assert.AreEqual("trade new", requeried.Trade);
                Assert.AreEqual("description new", requeried.Description);
                Assert.AreEqual("company new", requeried.Company);
                Assert.AreEqual("supervisor new", requeried.Supervisor);
                Assert.AreEqual("excavation new", requeried.ExcavationNumber);
                Assert.AreEqual(UserFixture.CreateAdmin().Id, requeried.LastImportedByUser.Id);
                Assert.AreEqual(new DateTime(2010, 10, 4), requeried.LastImportedDateTime);
                Assert.AreEqual(UserFixture.CreateOperatorGoofyInFortMcMurrySite().Id, requeried.LastSubmittedByUser.Id);
                Assert.AreEqual(new DateTime(2010, 10, 5), requeried.LastSubmittedDateTime);
                Assert.AreEqual(UserFixture.CreateOperatorOltUser1InFortMcMurrySite().Id, requeried.LastModifiedBy.Id);
                Assert.AreEqual(new DateTime(2010, 10, 3), requeried.LastModifiedDateTime);
                Assert.IsTrue(requeried.IsModified);
                Assert.AreEqual(PermitRequestCompletionStatus.Incomplete, requeried.CompletionStatus);
            }
        }

        [Ignore] [Test]
        public void ShouldDelete()
        {
            PermitRequestMontreal request = PermitRequestMontrealFixture.CreateForInsert(DataSource.MANUAL);
            request.LastModifiedBy = UserFixture.CreateEngineeringSupport();
            request.LastModifiedDateTime = new DateTime(2001, 1, 20);
            request = dao.Insert(request);
            long id = request.IdValue;

            {
                PermitRequestMontreal requeried = dao.QueryById(id);
                Assert.IsNotNull(requeried);

                requeried.LastModifiedBy = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
                requeried.LastModifiedDateTime = new DateTime(2001, 5, 12);

                dao.Remove(requeried);
            }
            {
                PermitRequestMontreal requeried = dao.QueryById(id);
                Assert.IsNotNull(requeried);

                Assert.AreEqual(UserFixture.CreateOperatorGoofyInFortMcMurrySite().Id, requeried.LastModifiedBy.Id);
                Assert.AreEqual(new DateTime(2001, 5, 12), requeried.LastModifiedDateTime);
            }
        }

        [Ignore] [Test]
        public void ShouldInsertAndUpdateAttributes()
        {
            PermitAttribute attribute1 = PermitAttributeFixture.GetReal(Site.MONTREAL_ID)[0];
            PermitAttribute attribute2 = PermitAttributeFixture.GetReal(Site.MONTREAL_ID)[1];
            PermitAttribute attribute3 = PermitAttributeFixture.GetReal(Site.MONTREAL_ID)[2];

            PermitRequestMontreal request = PermitRequestMontrealFixture.CreateForInsert(DataSource.MANUAL);
            request.Attributes.Clear();
            request.Attributes.Add(attribute1);
            request.Attributes.Add(attribute2);
            dao.Insert(request);

            {
                PermitRequestMontreal requeried = dao.QueryById(request.IdValue);
                Assert.IsNotNull(requeried);
                Assert.AreEqual(2, requeried.Attributes.Count);
                Assert.IsTrue(requeried.Attributes.Exists(obj => obj.Id == attribute1.Id));
                Assert.IsTrue(requeried.Attributes.Exists(obj => obj.Id == attribute2.Id));
            }

            request.Attributes.Clear();
            request.Attributes.Add(attribute2);
            request.Attributes.Add(attribute3);
            dao.Update(request);

            {
                PermitRequestMontreal requeried = dao.QueryById(request.IdValue);
                Assert.IsNotNull(requeried);
                Assert.AreEqual(2, requeried.Attributes.Count);
                Assert.IsTrue(requeried.Attributes.Exists(obj => obj.Id == attribute2.Id));
                Assert.IsTrue(requeried.Attributes.Exists(obj => obj.Id == attribute3.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByWorkOrderNumberAndOperationAndSubOperationAndSource()
        {
            PermitRequestMontreal permitRequest = PermitRequestMontrealFixture.CreateForInsert(DataSource.SAP);
            permitRequest.OperationNumber = "42";
            permitRequest.SubOperationNumber = "99";
            permitRequest.WorkOrderNumber = "67";
            dao.Insert(permitRequest);

            List<PermitRequestMontreal> result = dao.QueryByWorkOrderNumberAndOperationAndSource("67", "42", "99", DataSource.SAP);

            Assert.IsTrue(result.Count > 0);

            bool found = result.Exists(
                pr =>
                pr.DataSource.IdValue == DataSource.SAP.IdValue && 
                pr.OperationNumber == "42" &&
                pr.WorkOrderNumber == "67");

            Assert.IsTrue(found);
        }

        [Ignore] [Test]
        public void ShouldQueryByWorkOrderNumberAndOperationAndSource_NullOperationNumber()
        {
            PermitRequestMontreal permitRequest = PermitRequestMontrealFixture.CreateForInsert(DataSource.SAP);
            permitRequest.OperationNumber = null;
            permitRequest.SubOperationNumber = null;
            permitRequest.WorkOrderNumber = "67";            
            dao.Insert(permitRequest);

            permitRequest = PermitRequestMontrealFixture.CreateForInsert(DataSource.SAP);
            permitRequest.OperationNumber = "12";
            permitRequest.SubOperationNumber = "98";
            permitRequest.WorkOrderNumber = "67";
            dao.Insert(permitRequest);

            List<PermitRequestMontreal> result = dao.QueryByWorkOrderNumberAndOperationAndSource("67", null, null, DataSource.SAP);

            Assert.IsTrue(result.Count > 0);

            bool withNullOperationNumberFound = result.Exists(
                pr =>
                pr.DataSource.IdValue == DataSource.SAP.IdValue && 
                pr.OperationNumber == null &&
                pr.SubOperationNumber == null &&
                pr.WorkOrderNumber == "67");

            bool withNonNullOperationNumberFound = result.Exists(
                pr =>
                pr.DataSource.IdValue == DataSource.SAP.IdValue &&
                pr.OperationNumber == "12" &&
                pr.SubOperationNumber == "98" &&
                pr.WorkOrderNumber == "67");

            Assert.IsTrue(withNullOperationNumberFound);
            Assert.IsFalse(withNonNullOperationNumberFound);
        }

        [Ignore] [Test]
        public void ShouldQueryByWorkOrderNumberAndOperationAndSource_NullWorkOrderNumber()
        {
            PermitRequestMontreal permitRequest = PermitRequestMontrealFixture.CreateForInsert(DataSource.SAP);
            permitRequest.OperationNumber = "212";
            permitRequest.SubOperationNumber = "333";
            permitRequest.WorkOrderNumber = null;            
            dao.Insert(permitRequest);

            permitRequest = PermitRequestMontrealFixture.CreateForInsert(DataSource.SAP);
            permitRequest.OperationNumber = "212";
            permitRequest.SubOperationNumber = "333";
            permitRequest.WorkOrderNumber = "513";
            dao.Insert(permitRequest);

            List<PermitRequestMontreal> result = dao.QueryByWorkOrderNumberAndOperationAndSource(null, "212", "333", DataSource.SAP);

            Assert.IsTrue(result.Count > 0);

            bool withNullWorkOrderNumberFound = result.Exists(
                pr =>
                pr.DataSource.IdValue == DataSource.SAP.IdValue && 
                pr.OperationNumber == "212" &&
                pr.SubOperationNumber == "333" &&
                pr.WorkOrderNumber == null);

            bool withNonNullWorkOrderNumberFound = result.Exists(
                pr =>
                pr.DataSource.IdValue == DataSource.SAP.IdValue &&
                pr.OperationNumber == "212" &&
                pr.SubOperationNumber == "333" &&
                pr.WorkOrderNumber == "513");

            Assert.IsTrue(withNullWorkOrderNumberFound);
            Assert.IsFalse(withNonNullWorkOrderNumberFound);
        }

        [Ignore] [Test]
        public void ShouldQueryLastImportDateTime()
        {
            PermitRequestMontreal original = PermitRequestMontrealFixture.CreateForInsert(DataSource.MANUAL);
            DateTime futureDate = new DateTime(2525, 3, 9);
            original.LastImportedDateTime = futureDate; // There will be flying cars IN THE FUTURE!
            dao.Insert(original);

            DateTime? lastImportDateTime = dao.QueryLastImportDateTime();
            Assert.IsTrue(lastImportDateTime.HasValue);
            Assert.AreEqual(futureDate, lastImportDateTime);
        }

        [Ignore] [Test]
        public void InsertShouldInsertDocumentLinks()
        {
            PermitRequestMontreal request = PermitRequestMontrealFixture.CreateForInsert(DataSource.MANUAL);
            request.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            request.DocumentLinks.Add(DocumentLinkFixture.CreateAnotherNewDocumentLink());
            dao.Insert(request);

            PermitRequestMontreal requeried = dao.QueryById(request.IdValue);

            Assert.AreEqual(request.DocumentLinks.Count, requeried.DocumentLinks.Count);
            Assert.That(requeried.DocumentLinks, Has.Some.EqualTo(request.DocumentLinks[0]));
            Assert.That(requeried.DocumentLinks, Has.Some.EqualTo(request.DocumentLinks[1]));
        }

        [Ignore] [Test]
        public void UpdateShouldRemoveDeletedDocumentLinks()
        {
            PermitRequestMontreal request = PermitRequestMontrealFixture.CreateForInsert(DataSource.MANUAL);
            request.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            request.DocumentLinks.Add(DocumentLinkFixture.CreateAnotherNewDocumentLink());
            request = dao.Insert(request);

            long removedLinkId = request.DocumentLinks[0].IdValue;
            long retainedLinkId = request.DocumentLinks[1].IdValue;

            request.DocumentLinks.Remove(request.DocumentLinks[0]);
            dao.Update(request);

            PermitRequestMontreal requeried = dao.QueryById(request.IdValue);
            Assert.AreEqual(request.DocumentLinks.Count, requeried.DocumentLinks.Count);
            Assert.That(requeried.DocumentLinks, Has.None.Property("Id").EqualTo(removedLinkId));
            Assert.That(requeried.DocumentLinks, Has.Some.Property("Id").EqualTo(retainedLinkId));
        }

        [Ignore] [Test]
        public void UpdateShouldAddNewDocumentLink()
        {
            PermitRequestMontreal request = PermitRequestMontrealFixture.CreateForInsert(DataSource.MANUAL);
            request.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            request = dao.Insert(request);

            request.DocumentLinks.Add(DocumentLinkFixture.CreateAnotherNewDocumentLink());
            dao.Update(request);

            PermitRequestMontreal requeried = dao.QueryById(request.IdValue);
            Assert.AreEqual(request.DocumentLinks.Count, requeried.DocumentLinks.Count);
            Assert.That(requeried.DocumentLinks, Has.Some.Property("Id").EqualTo(request.DocumentLinks[0].Id));
            Assert.That(requeried.DocumentLinks, Has.Some.Property("Id").EqualTo(request.DocumentLinks[1].Id));
        }
    }
}
