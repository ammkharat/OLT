using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    /// <summary>
    /// Summary description for ActionItemTest
    /// </summary>
    [TestFixture]
    public class ActionItemTest
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void ShouldBeSerializable()
        {
            Assert.IsTrue(typeof (ActionItem).IsSerializable);
        }

        [Test]
        public void ShouldSerializeToBinaryFormat()
        {
            ActionItem actionItem = CreateNewActionitem(ActionItemStatus.Incomplete);
            TestUtil.SerializeAndDeSerialize(actionItem);
        }

        [Test]
        public void ShouldBeEqualWhenCompareSameFixturesAlthoughTheyAreDifferentObject()
        {
            Assert.AreEqual(ActionItemFixture.CreateAPendingActionItemWithFlocListAndNoId(),
                            ActionItemFixture.CreateAPendingActionItemWithFlocListAndNoId());
        }

        [Test]
        public void ShouldNotBeEqualWhenCompareDifferentFixture()
        {
            ActionItem a = ActionItemFixture.CreateAPendingActionItemWithFlocListAndNoId();

            ActionItem b = ActionItemFixture.CreateACompleteActionItemWithFlocListAndNoId();

            Assert.That(a, Is.Not.EqualTo(b));
        }

        [Test]
        public void SetStatusForNewStatusShouldCreateNullStatusModification()
        {
            ActionItem actionItem = CreateNewActionitem(ActionItemStatus.Complete);
            Assert.IsNull(actionItem.StatusModification);
        }

        [Test]
        public void SetStatusWithNewStatusShouldSetNewStatusAndStorePreviousStatusInModification()
        {
            ActionItem actionItem = CreateNewActionitem(ActionItemStatus.Incomplete);

            User changeUser = UserFixture.CreateAdmin();
            actionItem.SetStatus(ActionItemStatus.Current, changeUser, new DateTime(2006, 06, 02));

            Assert.AreEqual(ActionItemStatus.Current, actionItem.Status);
            
            ActionItemStatusModification statusModification = actionItem.StatusModification;
            Assert.AreEqual(ActionItemStatus.Incomplete, statusModification.PreviousStatus);
            Assert.AreEqual(changeUser, statusModification.ModifiedUser);
            Assert.AreEqual(new DateTime(2006, 06, 02), statusModification.ModifiedDateTime);
        }

        [Test]
        public void SetStatusWithSameStatusShouldNotOverwriteStatusModification()
        {
            ActionItem actionItem = CreateNewActionitem(ActionItemStatus.Incomplete);

            User firstChangeUser = UserFixture.CreateAdmin();
            actionItem.SetStatus(ActionItemStatus.Current, firstChangeUser, new DateTime(2006, 06, 02));

            User secondChangeUser = UserFixture.CreateEngineeringSupport();
            actionItem.SetStatus(ActionItemStatus.Current, secondChangeUser, new DateTime(2006, 06, 05));

            ActionItemStatusModification statusModification = actionItem.StatusModification;
            Assert.AreEqual(ActionItemStatus.Incomplete, statusModification.PreviousStatus);
            Assert.AreEqual(firstChangeUser, statusModification.ModifiedUser);
            Assert.AreEqual(new DateTime(2006, 06, 02), statusModification.ModifiedDateTime);
        }

        private static ActionItem CreateNewActionitem(ActionItemStatus initialStatus)
        {
            BusinessCategory productionCategory = BusinessCategoryFixture.GetProductionCategory();

            return new ActionItem("Some Action Item", "desc", false, initialStatus, Priority.Normal, 
                                  DataSource.SAP, DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow, ScheduleType.Hourly, 
                                  null, productionCategory, UserFixture.CreateOperator(), 
                                  DateTimeFixture.DateTimeNow, new List<DocumentLink>(), null, null, null, null,null,0,null,null,null,string.Empty,null,false);    //ayman visibility groups          ayman action item definition   ayman action item reading
        }

        [Test]
        public void ShouldCheckFunctionalLocationRelevant()
        {
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Montreal());

            {
                ActionItem actionItem = CreateNewActionitem(ActionItemStatus.Current);
                actionItem.FunctionalLocations.Clear();
                FunctionalLocation unitLevelFloc = FunctionalLocationFixture.CreateNew("DIV1-SEC1-UNIT1");

                actionItem.FunctionalLocations.Add(unitLevelFloc);

                Assert.IsFalse(actionItem.IsRelevantTo(unitLevelFloc.Site.IdValue, new List<string> { "DIV1-SEC1-UNIT2" }, null,null, siteConfiguration));
                Assert.IsFalse(actionItem.IsRelevantTo(unitLevelFloc.Site.IdValue, new List<string> { "DIV1-SEC1-UNIT1-EQUIP1" },null, null, siteConfiguration));
                Assert.IsFalse(actionItem.IsRelevantTo(unitLevelFloc.Site.IdValue, new List<string> { "DIV1-SEC1-UNIT1-EQUIP1-EQUIP2" },null, null, siteConfiguration));

                Assert.IsTrue(actionItem.IsRelevantTo(unitLevelFloc.Site.IdValue, new List<string> { "DIV1-SEC1-UNIT1" }, null,null, siteConfiguration));
                Assert.IsTrue(actionItem.IsRelevantTo(unitLevelFloc.Site.IdValue, new List<string> { "DIV1-SEC1" }, null,null, siteConfiguration));
                Assert.IsTrue(actionItem.IsRelevantTo(unitLevelFloc.Site.IdValue, new List<string> { "DIV1" }, null, null,siteConfiguration));

                Assert.IsFalse(actionItem.IsRelevantTo(unitLevelFloc.Site.IdValue, new List<string> { "DIV1-SEC2" }, null,null, siteConfiguration));
                Assert.IsFalse(actionItem.IsRelevantTo(unitLevelFloc.Site.IdValue, new List<string> { "DIV2" }, null, null,siteConfiguration));

                Assert.IsFalse(actionItem.IsRelevantTo(unitLevelFloc.Site.IdValue + 1, new List<string> { "DIV1-SEC1-UNIT1" },null, null, siteConfiguration));
            }
            {
                ActionItem actionItem = CreateNewActionitem(ActionItemStatus.Current);
                actionItem.FunctionalLocations.Clear();

                FunctionalLocation unitLevelFloc = FunctionalLocationFixture.CreateNew("DIV1-SEC1-UNIT1");
                FunctionalLocation equipLevelFloc = FunctionalLocationFixture.CreateNew("DIV1-SEC1-UNIT2-EQUIP1");

                actionItem.FunctionalLocations.Add(unitLevelFloc);
                actionItem.FunctionalLocations.Add(equipLevelFloc);

                Assert.IsFalse(actionItem.IsRelevantTo(unitLevelFloc.Site.IdValue, new List<string> { "DIV1-SEC1-UNIT3" },null, null, siteConfiguration));
                Assert.IsFalse(actionItem.IsRelevantTo(unitLevelFloc.Site.IdValue, new List<string> { "DIV1-SEC1-UNIT1-EQUIP1" },null, null, siteConfiguration));
                Assert.IsFalse(actionItem.IsRelevantTo(unitLevelFloc.Site.IdValue, new List<string> { "DIV1-SEC1-UNIT1-EQUIP1-EQUIP2" },null, null, siteConfiguration));

                Assert.IsFalse(actionItem.IsRelevantTo(unitLevelFloc.Site.IdValue, new List<string> { "DIV1-SEC1-UNIT2-EQUIP1-EQUIP2" }, null,null, siteConfiguration));

                Assert.IsTrue(actionItem.IsRelevantTo(unitLevelFloc.Site.IdValue, new List<string> { "DIV1-SEC1-UNIT1" }, null,null, siteConfiguration));
                Assert.IsTrue(actionItem.IsRelevantTo(unitLevelFloc.Site.IdValue, new List<string> { "DIV1-SEC1" }, null, null,siteConfiguration));
                Assert.IsTrue(actionItem.IsRelevantTo(unitLevelFloc.Site.IdValue, new List<string> { "DIV1" }, null, null,siteConfiguration));

                Assert.IsTrue(actionItem.IsRelevantTo(unitLevelFloc.Site.IdValue, new List<string> { "DIV1-SEC1-UNIT2-EQUIP1" },null, null, siteConfiguration));

                Assert.IsFalse(actionItem.IsRelevantTo(unitLevelFloc.Site.IdValue, new List<string> { "DIV1-SEC2" }, null,null, siteConfiguration));
                Assert.IsFalse(actionItem.IsRelevantTo(unitLevelFloc.Site.IdValue, new List<string> { "DIV2" }, null,null, siteConfiguration));

                Assert.IsFalse(actionItem.IsRelevantTo(unitLevelFloc.Site.IdValue + 1, new List<string> { "DIV1-SEC1-UNIT1" },null, null, siteConfiguration));
            }
        }

    }
}