using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture] [Category("Database")]
    public class DeviationAlertReportDTODaoTest : AbstractDaoTest
    {
        private IDeviationAlertReportDTODao dtoDao;
        private IDeviationAlertDao alertDao;
        private IFunctionalLocationDao flocDao;

        protected override void TestInitialize()
        {
            dtoDao = DaoRegistry.GetDao<IDeviationAlertReportDTODao>();
            alertDao = DaoRegistry.GetDao<IDeviationAlertDao>();
            flocDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
        }

        protected override void Cleanup()
        {
        }

        private static DeviationAlert CreateAlertWithTwoAssignments(FunctionalLocation floc)
        {
            DeviationAlert alert = DeviationAlertFixture.Create(
                floc,
                new DateTime(2010, 3, 1, 8, 0, 0),
                new DateTime(2010, 3, 1, 9, 0, 0));
            alert.DeviationAlertResponse = DeviationAlertResponseFixture.CreateNewResponse();

            RestrictionLocationItem restrictionLocationItem = RestrictionLocationItemFixture.CreateWithReasonCodes(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF(), RestrictionReasonCodeFixture.GetRestrictionReasonCodeThatIsInDb());
            
            alert.DeviationAlertResponse.ReasonCodeAssignments.Add(
                new DeviationAlertResponseReasonCodeAssignment(restrictionLocationItem, FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF(), RestrictionReasonCodeFixture.GetRestrictionReasonCodeThatIsInDb(), "Shutdown", 100, "Comments", UserFixture.CreateUserWithGivenId(1), DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow));
            
            alert.DeviationAlertResponse.ReasonCodeAssignments.Add(
                new DeviationAlertResponseReasonCodeAssignment(restrictionLocationItem, FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF(), RestrictionReasonCodeFixture.GetRestrictionReasonCodeThatIsInDb(), "maintenance", 200, "Comments", UserFixture.CreateUserWithGivenId(1), DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow));
            return alert;
        }

        [Ignore] [Test]
        public void ShouldFindAlertWithNoResponse()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_DN1_3003_0000();
            List<FunctionalLocation> queryFlocs = new List<FunctionalLocation> { floc };

            DeviationAlert alert = CreateAlertWithTwoAssignments(floc);
            alert.DeviationAlertResponse = null;
            alert = alertDao.Insert(alert);

            List<DeviationAlertReportDTO> dtos = dtoDao.QueryByDateRangeAndParentFunctionalLocation(
                    new Date(2010, 3, 1), new Date(2010, 3, 2), new RootFlocSet(queryFlocs));
            DeviationAlertReportDTO found = dtos.Find(obj => obj.Id == alert.Id);
            Assert.IsNotNull(found);
            Assert.IsNull(found.ReasonCode);
            Assert.IsNull(found.AssignedAmount);
            Assert.IsNull(found.ReasonCodeFlocDivision);
            Assert.IsNull(found.ReasonCodeFlocSection);
            Assert.IsNull(found.ReasonCodeFlocUnit);
            Assert.IsNull(found.ReasonCodeFlocEquipment1);
            Assert.IsNull(found.ReasonCodeFlocEquipment2);
            Assert.IsNull(found.ReasonCodeFlocDescription);
        }

        [Ignore] [Test]
        public void ShouldFindAlertWithOneResponse()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_DN1_3003_0000();
            List<FunctionalLocation> queryFlocs = new List<FunctionalLocation> { floc };

            DeviationAlert alert = CreateAlertWithTwoAssignments(floc);
            alert.DeviationAlertResponse.ReasonCodeAssignments.RemoveAt(1);
            alert = alertDao.Insert(alert);

            List<DeviationAlertReportDTO> dtos = dtoDao.QueryByDateRangeAndParentFunctionalLocation(
                new Date(2010, 3, 1), new Date(2010, 3, 2), new RootFlocSet(queryFlocs));
            List<DeviationAlertReportDTO> found = dtos.FindAll(obj => obj.Id == alert.Id);
            Assert.AreEqual(1, found.Count);
            Assert.AreEqual(100, found[0].AssignedAmount);
        }

        [Ignore] [Test]
        public void ShouldFindAlertWithMultipleResponses()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_DN1_3003_0000();
            List<FunctionalLocation> queryFlocs = new List<FunctionalLocation> { floc };

            DeviationAlert alert = CreateAlertWithTwoAssignments(floc);
            alert = alertDao.Insert(alert);

            List<DeviationAlertReportDTO> dtos = dtoDao.QueryByDateRangeAndParentFunctionalLocation(
                new Date(2010, 3, 1), new Date(2010, 3, 2), new RootFlocSet(queryFlocs));
            List<DeviationAlertReportDTO> found = dtos.FindAll(obj => obj.Id == alert.Id);
            Assert.AreEqual(2, found.Count);
            Assert.IsTrue(found.Exists(obj => obj.AssignedAmount == 100));
            Assert.IsTrue(found.Exists(obj => obj.AssignedAmount == 200));
        }

        [Ignore] [Test]
        public void ShouldFindByDayRange()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_DN1_3003_0000();
            List<FunctionalLocation> queryFlocs = new List<FunctionalLocation> { floc };
            IFlocSet flocSet = new RootFlocSet(queryFlocs);

            DeviationAlert alert1 = alertDao.Insert(DeviationAlertFixture.Create(
                floc, 
                new DateTime(2010, 3, 1, 8, 0, 0), 
                new DateTime(2010, 3, 1, 9, 0, 0)));
            DeviationAlert alert2 = alertDao.Insert(DeviationAlertFixture.Create(
                floc,
                new DateTime(2010, 3, 1, 23, 0, 0),
                new DateTime(2010, 3, 2, 0, 0, 0)));
            DeviationAlert alert3 = alertDao.Insert(DeviationAlertFixture.Create(
                floc,
                new DateTime(2010, 3, 2, 1, 0, 0),
                new DateTime(2010, 3, 2, 2, 0, 0)));

            {
                List<DeviationAlertReportDTO> dtos = dtoDao.QueryByDateRangeAndParentFunctionalLocation(
                    new Date(2010, 2, 28), new Date(2010, 3, 5), flocSet);
                Assert.IsTrue(dtos.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(dtos.Exists(obj => obj.Id == alert2.Id));
                Assert.IsTrue(dtos.Exists(obj => obj.Id == alert3.Id));
            }
            {
                List<DeviationAlertReportDTO> dtos = dtoDao.QueryByDateRangeAndParentFunctionalLocation(
                    new Date(2010, 3, 1), new Date(2010, 3, 2), flocSet);
                Assert.IsTrue(dtos.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(dtos.Exists(obj => obj.Id == alert2.Id));
                Assert.IsTrue(dtos.Exists(obj => obj.Id == alert3.Id));
            }
            {
                List<DeviationAlertReportDTO> dtos = dtoDao.QueryByDateRangeAndParentFunctionalLocation(
                    new Date(2010, 3, 1), new Date(2010, 3, 1), flocSet);
                Assert.IsTrue(dtos.Exists(obj => obj.Id == alert1.Id));
                Assert.IsTrue(dtos.Exists(obj => obj.Id == alert2.Id));
                Assert.IsFalse(dtos.Exists(obj => obj.Id == alert3.Id));
            }
            {
                List<DeviationAlertReportDTO> dtos = dtoDao.QueryByDateRangeAndParentFunctionalLocation(
                    new Date(2010, 3, 2), new Date(2010, 3, 2), flocSet);
                Assert.IsFalse(dtos.Exists(obj => obj.Id == alert1.Id));
                Assert.IsFalse(dtos.Exists(obj => obj.Id == alert2.Id));
                Assert.IsTrue(dtos.Exists(obj => obj.Id == alert3.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldFindByParentFloc()
        {
            List<FunctionalLocation> flocs = new List<FunctionalLocation>
                                                 {
                                                     InsertFunctionalLocation("A1"),
                                                     InsertFunctionalLocation("A1-B1"),
                                                     InsertFunctionalLocation("A1-B1-C1"),
                                                     InsertFunctionalLocation("A1-B2"),
                                                     InsertFunctionalLocation("A1-B2-C2"),
                                                     InsertFunctionalLocation("A1-B2-C2-D1"),
                                                     InsertFunctionalLocation("A1-B2-C2-D2"),
                                                     InsertFunctionalLocation("A1-B2-C3"),
                                                     InsertFunctionalLocation("A1-B2-C3-D3"),
                                                     InsertFunctionalLocation("A1-B2-C3-D3-E1"),
                                                     InsertFunctionalLocation("A1-B2-C3-D3-E2"),
                                                     InsertFunctionalLocation("A1-B2-C4"),
                                                     InsertFunctionalLocation("A1-B3"),
                                                     InsertFunctionalLocation("A2"),
                                                     InsertFunctionalLocation("A2-B1"),
                                                     InsertFunctionalLocation("A2-B1-C1")
                                                 };

            AssertFindByParentFloc(flocs, flocs[0], new List<int> { 0 });
            AssertFindByParentFloc(flocs, flocs[1], new List<int> { 0, 1 });
            AssertFindByParentFloc(flocs, flocs[2], new List<int> { 0, 1, 2 });
            AssertFindByParentFloc(flocs, flocs[3], new List<int> { 0, 3 });
            AssertFindByParentFloc(flocs, flocs[4], new List<int> { 0, 3, 4 });
            AssertFindByParentFloc(flocs, flocs[5], new List<int> { 0, 3, 4, 5 });
            AssertFindByParentFloc(flocs, flocs[6], new List<int> { 0, 3, 4, 6 });
            AssertFindByParentFloc(flocs, flocs[7], new List<int> { 0, 3, 7 });
            AssertFindByParentFloc(flocs, flocs[8], new List<int> { 0, 3, 7, 8 });
            AssertFindByParentFloc(flocs, flocs[9], new List<int> { 0, 3, 7, 8, 9 });
            AssertFindByParentFloc(flocs, flocs[10], new List<int> { 0, 3, 7, 8, 10 });
            AssertFindByParentFloc(flocs, flocs[11], new List<int> { 0, 3, 11 });
            AssertFindByParentFloc(flocs, flocs[12], new List<int> { 0, 12 });
            AssertFindByParentFloc(flocs, flocs[13], new List<int> { 13 });
            AssertFindByParentFloc(flocs, flocs[14], new List<int> { 13, 14 });
            AssertFindByParentFloc(flocs, flocs[15], new List<int> { 13, 14, 15 });
        }

        private void AssertFindByParentFloc(
           List<FunctionalLocation> flocs,
           FunctionalLocation flocWithAlert,
           List<int> indexOfQueryByFlocsThatShouldReturnAlert)
        {
            DeviationAlert alert = DeviationAlertFixture.Create(
                flocWithAlert, new DateTime(2010, 3, 1, 8, 0, 0), new DateTime(2010, 3, 1, 9, 0, 0));
            alert = alertDao.Insert(alert);

            for (int i = 0; i < flocs.Count; i++)
            {
                List<FunctionalLocation> queryFlocs = new List<FunctionalLocation> {flocs[i]};

                List<DeviationAlertReportDTO> dtos = dtoDao.QueryByDateRangeAndParentFunctionalLocation(
                    alert.StartDateTime.ToDate().SubtractDays(5), alert.EndDateTime.ToDate().AddDays(5), new RootFlocSet(queryFlocs));
                if (indexOfQueryByFlocsThatShouldReturnAlert.Contains(i))
                {
                    Assert.IsTrue(dtos.Exists(obj => obj.Id == alert.Id));
                }
                else
                {
                    Assert.IsFalse(dtos.Exists(obj => obj.Id == alert.Id));
                }
            }
        }

        private FunctionalLocation InsertFunctionalLocation(string fullHierarchy)
        {
            FunctionalLocation floc = FunctionalLocationFixture.CreateNew(fullHierarchy);
            flocDao.Insert(floc);
            return floc;
        }

    }
}
