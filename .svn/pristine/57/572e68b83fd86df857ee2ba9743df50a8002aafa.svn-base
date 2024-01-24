using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class PermitRequestMontrealHistoryDaoTest : AbstractDaoTest
    {
        private IPermitRequestMontrealHistoryDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IPermitRequestMontrealHistoryDao>();
        }

        protected override void Cleanup()
        {
        }

        private static PermitRequestMontreal CreateForInsert()
        {
            PermitRequestMontreal permitRequest = new PermitRequestMontreal(
                null,
                WorkPermitMontrealType.MODERATE_HOT,                 
                new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_MT1_A001_U010() },
                new Date(2001, 2, 3),
                new Date(2001, 4, 5),
                "112233",
                "020",
                "0110",                
                "trade ABC",
                "permit request description",
                "permit request description (SAP)",
                "Black & McDonald",
                "Some Supervisor",
                "01234",
                DataSource.MANUAL,
                UserFixture.CreateOperatorOltUser1InFortMcMurrySite(),
                new DateTime(2001, 10, 11),
                UserFixture.CreateAdmin(),
                new DateTime(2001, 12, 13),
                UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB(),
                new DateTime(2002, 6, 7),
                UserFixture.CreateOperatorGoofyInFortMcMurrySite(),
                new DateTime(2002, 8, 9),
                WorkPermitMontrealGroupFixture.CreateForInsert(),
                PermitRequestCompletionStatus.Complete);

            permitRequest.Attributes.Clear();
            permitRequest.Attributes.Add(new PermitAttribute(0, "att2", "", Site.MONTREAL_ID));
            permitRequest.Attributes.Add(new PermitAttribute(0, "att1", "", Site.MONTREAL_ID));

            permitRequest.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());

            return permitRequest;
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            PermitRequestMontreal request = CreateForInsert();
            request.Id = 1234;
            PermitRequestMontrealHistory history = request.TakeSnapshot();
            dao.Insert(history);

            List<PermitRequestMontrealHistory> histories = dao.GetById(history.IdValue);
            Assert.AreEqual(1, histories.Count);

            PermitRequestMontrealHistory requeried = histories[0];

            Assert.AreEqual(request.Id, requeried.Id);
            Assert.AreEqual(request.WorkPermitType.Id, requeried.WorkPermitType.Id);
            Assert.AreEqual(request.FunctionalLocationsAsCommaSeparatedFullHierarchyList, requeried.FunctionalLocations);
            Assert.AreEqual(request.StartDate, requeried.StartDate);
            Assert.AreEqual(request.EndDate, requeried.EndDate);
            Assert.AreEqual(request.WorkOrderNumber, requeried.WorkOrderNumber);
            Assert.AreEqual(request.OperationNumber, requeried.OperationNumber);
            Assert.AreEqual(request.Trade, requeried.Trade);
            Assert.AreEqual(request.Description, requeried.Description);
            Assert.AreEqual(request.SapDescription, requeried.SapDescription);
            Assert.AreEqual(request.Company, requeried.Company);
            Assert.AreEqual(request.Supervisor, requeried.Supervisor);
            Assert.AreEqual(request.ExcavationNumber, requeried.ExcavationNumber);
            Assert.AreEqual("att1, att2", requeried.Attributes);
            Assert.AreEqual(request.DocumentLinks[0].TitleWithUrl, requeried.DocumentLinks);
            Assert.AreEqual(request.RequestedByGroup.Name, requeried.RequestedByGroup);
            Assert.AreEqual(request.CompletionStatus, requeried.CompletionStatus);

            Assert.AreEqual(UserFixture.CreateOperatorOltUser1InFortMcMurrySite().Id, requeried.LastImportedByUser.Id);
            Assert.AreEqual(new DateTime(2001, 10, 11), requeried.LastImportedDateTime);
            Assert.AreEqual(UserFixture.CreateAdmin().Id, requeried.LastSubmittedByUser.Id);
            Assert.AreEqual(new DateTime(2001, 12, 13), requeried.LastSubmittedDateTime);

            Assert.AreEqual(request.LastModifiedBy.Id, requeried.LastModifiedBy.Id);
            Assert.That(request.LastModifiedDateTime, Is.EqualTo(requeried.LastModifiedDate).Within(TimeSpan.FromSeconds(10)));
        }

        [Ignore] [Test]
        public void ShouldInsertNullFields()
        {
            PermitRequestMontreal request = CreateForInsert();
            request.Id = 1234;
            request.WorkOrderNumber = null;
            request.OperationNumber = null;
            request.Company = null;
            request.Supervisor = null;
            request.ExcavationNumber = null;
            request.Attributes.Clear();
            request.LastImportedByUser = null;
            request.LastImportedDateTime = null;
            request.LastSubmittedByUser = null;
            request.LastSubmittedDateTime = null;
            request.SapDescription = null;
            PermitRequestMontrealHistory history = request.TakeSnapshot();
            dao.Insert(history);

            List<PermitRequestMontrealHistory> histories = dao.GetById(history.IdValue);
            Assert.AreEqual(1, histories.Count);

            PermitRequestMontrealHistory requeried = histories[0];

            Assert.AreEqual(request.Id, requeried.Id);
            Assert.IsNull(requeried.WorkOrderNumber);
            Assert.IsNull(requeried.OperationNumber);
            Assert.IsNull(requeried.Company);
            Assert.IsNull(requeried.Supervisor);
            Assert.IsNull(requeried.ExcavationNumber);
            Assert.IsEmpty(requeried.Attributes);
            Assert.IsNull(requeried.LastImportedByUser);
            Assert.IsNull(requeried.LastImportedDateTime);
            Assert.IsNull(requeried.LastSubmittedByUser);
            Assert.IsNull(requeried.LastSubmittedDateTime);
            Assert.IsNull(requeried.SapDescription);
        }
    }
}

