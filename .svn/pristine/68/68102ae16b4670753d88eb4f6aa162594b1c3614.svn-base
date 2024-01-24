using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class RestrictionLocationDaoTest : AbstractDaoTest
    {
        private IRestrictionLocationDao dao;
        private IRestrictionReasonCodeDao reasonCodeDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IRestrictionLocationDao>();
            reasonCodeDao = DaoRegistry.GetDao<IRestrictionReasonCodeDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldInsertRestrictionLocation()
        {
            List<WorkAssignment> workAssignments = new List<WorkAssignment> {WorkAssignmentFixture.CreateShiftEngineer()};
            RestrictionLocation location = new RestrictionLocation("Test_Plant86", workAssignments, UserFixture.CreateSupervisor(SiteFixture.Oilsands()), DateTimeFixture.DateTimeNow,3);   //ayman restriction location

            RestrictionLocationItem restrictionLocationItem = RestrictionLocationItemFixture.CreateWithOneReasonCodeWithNoLimit();
            restrictionLocationItem.Id = 100000;
            location.AddLocationItem(restrictionLocationItem);

            dao.Insert(location);
            
            QueryAndAssert(location);
        }

        [Ignore] [Test]
        public void ShouldUpdateName()
        {
            List<WorkAssignment> workAssignments = WorkAssignmentFixture.GetListOfRealWorkAssignments(Site.OILSAND_ID, 2);

            RestrictionLocation location = new RestrictionLocation("Test_Plant86", workAssignments, UserFixture.CreateSupervisor(SiteFixture.Oilsands()), DateTimeFixture.DateTimeNow,3);   //ayman restriction location

            RestrictionLocationItem restrictionLocationItem = RestrictionLocationItemFixture.CreateWithOneReasonCodeWithNoLimit();
            restrictionLocationItem.Id = 100000;
            location.AddLocationItem(restrictionLocationItem);

            dao.Insert(location);

            {
                location.Name = "New Name of Location";
                dao.Update(location);

                RestrictionLocation result = dao.QueryById(location.IdValue);
                Assert.That(result, Is.Not.Null);

                Assert.AreEqual(location.IdValue, result.IdValue);
                Assert.AreEqual(location.Name, result.Name);
            }
        }

        [Ignore] [Test]
        public void ShouldAddAndDeleteWorkAssignments()
        {
            WorkAssignment shiftEngineer = WorkAssignmentFixture.CreateShiftEngineer();
            WorkAssignment consoleOperator = WorkAssignmentFixture.CreateConsoleOperator(Site.OILSAND_ID);
            List<WorkAssignment> workAssignments = new List<WorkAssignment> { shiftEngineer, consoleOperator };

            RestrictionLocation location = new RestrictionLocation("Test_Plant86", workAssignments, UserFixture.CreateSupervisor(SiteFixture.Oilsands()), DateTimeFixture.DateTimeNow,3);    //ayman restriction location

            RestrictionLocationItem restrictionLocationItem = RestrictionLocationItemFixture.CreateWithOneReasonCodeWithALimit(100);
            restrictionLocationItem.Id = 100000;
            location.AddLocationItem(restrictionLocationItem);

            dao.Insert(location);

            location.WorkAssignments.Remove(shiftEngineer);
            WorkAssignment newWorkAssignment = WorkAssignmentFixture.CreateRealExtractionWorkAssignmentInDatabase("Ext-Millennium OPP");
            location.WorkAssignments.Add(newWorkAssignment);
            dao.Update(location);

            QueryAndAssert(location);
        }

        [Ignore] [Test]
        public void ShouldAddAndDeleteLocationItems()
        {
            List<WorkAssignment> workAssignments = WorkAssignmentFixture.GetListOfRealWorkAssignments(Site.OILSAND_ID, 2);

            RestrictionLocation location = new RestrictionLocation("Test_Plant86", workAssignments, UserFixture.CreateSupervisor(SiteFixture.Oilsands()), DateTimeFixture.DateTimeNow,3);       //ayman restriction location

            List<RestrictionLocationItemReasonCodeAssociation> reasonCodes = new List<RestrictionLocationItemReasonCodeAssociation>
            {
                new RestrictionLocationItemReasonCodeAssociation(RestrictionReasonCodeFixture.GetRestrictionReasonCodeThatIsInDb(), 90)
            };

            RestrictionLocationItem locationItem1 = new RestrictionLocationItem(100000, "item1", FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI(), null, reasonCodes);
            location.AddLocationItem(locationItem1);

            dao.Insert(location);

            {

                location.AddLocationItem(new RestrictionLocationItem(100001, "item2", FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL(), null, reasonCodes));
                dao.Update(location);

                RestrictionLocation result = dao.QueryById(location.IdValue);
                Assert.That(result, Is.Not.Null);

                Assert.AreEqual(location.IdValue, result.IdValue);
                AssertLocationItemsAreSame(location, result);
            }

            {
                location.RemoveLocationItem(locationItem1);
                dao.Update(location);

                RestrictionLocation result = dao.QueryById(location.IdValue);
                Assert.That(result, Is.Not.Null);

                Assert.AreEqual(location.IdValue, result.IdValue);
                AssertLocationItemsAreSame(location, result);
            }
        }

        [Ignore] [Test]
        public void ShouldAddAndRemoveReasonCodesFromItems()
        {
            List<WorkAssignment> workAssignments = WorkAssignmentFixture.GetListOfRealWorkAssignments(Site.OILSAND_ID, 2);

            RestrictionLocation location = new RestrictionLocation("Test_Plant86", workAssignments, UserFixture.CreateSupervisor(SiteFixture.Oilsands()), DateTimeFixture.DateTimeNow,3);      //ayman restriction location

            List<RestrictionReasonCode> restrictionReasonCodes = reasonCodeDao.QueryAll(0);     //ayman restriction reason codes
            RestrictionReasonCode restrictionReasonCode1 = restrictionReasonCodes[1];
            RestrictionReasonCode restrictionReasonCode2 = restrictionReasonCodes[2];

            RestrictionLocationItem restrictionLocationItem = RestrictionLocationItemFixture.CreateWithReasonCodes(restrictionReasonCode1, restrictionReasonCode2);
            restrictionLocationItem.Id = 10000;
            location.AddLocationItem(restrictionLocationItem);

            dao.Insert(location);

            {
                location.AddLocationItem(new RestrictionLocationItem(10001, "item2", FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL(), null,
                    new List<RestrictionLocationItemReasonCodeAssociation> { new RestrictionLocationItemReasonCodeAssociation(restrictionReasonCodes[3], null) }));

                dao.Update(location);

                RestrictionLocation result = dao.QueryById(location.IdValue);
                Assert.That(result, Is.Not.Null);

                Assert.AreEqual(location.IdValue, result.IdValue);
                AssertLocationItemsAreSame(location, result);
            }

            {
                location.LocationItems[0].ReasonCodes.Add(new RestrictionLocationItemReasonCodeAssociation(restrictionReasonCodes[4], null));
                dao.Update(location);

                RestrictionLocation result = dao.QueryById(location.IdValue);
                Assert.That(result, Is.Not.Null);

                Assert.AreEqual(location.IdValue, result.IdValue);
                AssertLocationItemsAreSame(location, result);
            }
        }

        [Ignore] [Test]
        public void ShouldGetNextId()
        {
            long sequenceNumber = dao.GetNextLocationItemSequenceNumber();
            Assert.That(sequenceNumber, Is.GreaterThan(0));
        }

        private void QueryAndAssert(RestrictionLocation location)
        {
            RestrictionLocation result = dao.QueryById(location.IdValue);
            Assert.That(result, Is.Not.Null);

            Assert.AreEqual(location.IdValue, result.IdValue);
            Assert.AreEqual(location.Name, result.Name);
            CollectionAssert.AreEquivalent(location.WorkAssignments, result.WorkAssignments);

            Assert.AreEqual(location.LocationItems.Count, result.LocationItems.Count);
            AssertLocationItemsAreSame(location, result);
        }

        private static void AssertLocationItemsAreSame(RestrictionLocation location, RestrictionLocation result)
        {
            foreach (RestrictionLocationItem locationItem in location.LocationItems)
            {
                RestrictionLocationItem resultItem = result.LocationItems.Find(item => locationItem.IdValue == item.IdValue);
                Assert.That(resultItem, Is.Not.Null);
                Assert.AreEqual(locationItem.FunctionalLocation, resultItem.FunctionalLocation);
                Assert.AreEqual(locationItem.Name, resultItem.Name);
                Assert.AreEqual(locationItem.ParentItemId, resultItem.ParentItemId);
                Assert.IsTrue(
                    locationItem.ReasonCodes.TrueForAll(rc => resultItem.ReasonCodes.Exists(r => Equals(r.RestrictionReasonCodeId, rc.RestrictionReasonCodeId) && Nullable.Equals(r.Limit, rc.Limit))));
            }
        }
    }
}