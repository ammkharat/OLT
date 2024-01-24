using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;
using DayOfWeek = Com.Suncor.Olt.Common.Domain.DayOfWeek;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class LabAlertDefinitionDaoTest : AbstractDaoTest
    {
        private ILabAlertDefinitionDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ILabAlertDefinitionDao>();
        }

        protected override void Cleanup()
        {
        }

        private static void PopulateFields(LabAlertDefinition definition)
        {
            definition.Name = "this is a new name";
            definition.FunctionalLocation = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL_SWM();
            definition.Description = "this is a new desription";
            definition.TagInfo = TagInfoFixture.CreateTagInfoWithId2FromDB();
            definition.MinimumNumberOfSamples = 24;
            definition.IsActive = false;            
            definition.LastModifiedBy = UserFixture.CreateSupervisor();
            definition.LastModifiedDate = new DateTime(2010, 1, 2, 3, 4, 5);

            long? scheduleId = definition.Schedule.Id;
            definition.Schedule = RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000();
            definition.Schedule.Id = scheduleId;
        }

        private static void AssertPopulatedFieldsAreEqual(LabAlertDefinition definition)
        {
            Assert.AreEqual("this is a new name", definition.Name);
            Assert.AreEqual(FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL_SWM().Id, definition.FunctionalLocation.Id);
            Assert.AreEqual("this is a new desription", definition.Description);
            definition.TagInfo.ScadaConnectionInfoId = 1;
            Assert.AreEqual(TagInfoFixture.CreateTagInfoWithId2FromDB(), definition.TagInfo);
            Assert.AreEqual(24, definition.MinimumNumberOfSamples);
            Assert.AreEqual(RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000().ToString(), definition.Schedule.ToString());
            Assert.AreEqual(false, definition.IsActive);
            Assert.AreEqual(UserFixture.CreateSupervisor().Id, definition.LastModifiedBy.Id);
            Assert.AreEqual(new DateTime(2010, 1, 2, 3, 4, 5), definition.LastModifiedDate);
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition(
                UserFixture.CreateEngineeringSupport(), new DateTime(2011, 11, 21, 3, 41, 51));
            PopulateFields(definition);
            LabAlertDefinition saved = dao.Insert(definition);

            LabAlertDefinition requeried = dao.QueryById(saved.IdValue);
            Assert.IsNotNull(requeried);
            AssertPopulatedFieldsAreEqual(requeried);
            Assert.AreEqual(new DateTime(2011, 11, 21, 3, 41, 51), requeried.CreatedDateTime);
            Assert.AreEqual(UserFixture.CreateEngineeringSupport().Id, requeried.CreatedBy.Id);
        }

        [Ignore] [Test]
        public void ShouldUpdate()
        {
            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition();
            definition = dao.Insert(definition);
            long id = definition.IdValue;

            {
                LabAlertDefinition requeried = dao.QueryById(id);
                Assert.IsNotNull(requeried);

                PopulateFields(requeried);

                dao.Update(requeried);
            }
            {
                LabAlertDefinition requeried = dao.QueryById(id);
                Assert.IsNotNull(requeried);

                AssertPopulatedFieldsAreEqual(requeried);
                Assert.That(definition.CreatedDateTime, Is.EqualTo(requeried.CreatedDateTime).Within(TimeSpan.FromSeconds(10)));
                Assert.AreEqual(definition.CreatedBy.Id, requeried.CreatedBy.Id);
            }
        }
       
        [Ignore] [Test]
        public void ShouldInsertAndUpdateDailyCriteria()
        {
            LabAlertTagQueryRange insertRange = new LabAlertTagQueryDailyRange(new Time(5), new Time(7));
            LabAlertTagQueryRange updateRange = new LabAlertTagQueryDailyRange(new Time(6), new Time(19));
            AssertInsertAndUpdateLabAlertTagQueryRange(insertRange, updateRange);
        }

        [Ignore] [Test]
        public void ShouldInsertAndUpdateWeeklyCriteria()
        {
            LabAlertTagQueryRange insertRange = new LabAlertTagQueryWeeklyRange(new Time(8), new Time(14), DayOfWeek.Monday, DayOfWeek.Friday);
            LabAlertTagQueryRange updateRange = new LabAlertTagQueryWeeklyRange(new Time(2), new Time(15), DayOfWeek.Tuesday, DayOfWeek.Saturday);
            AssertInsertAndUpdateLabAlertTagQueryRange(insertRange, updateRange);
        }

        [Ignore] [Test]
        public void ShouldInsertAndUpdateMonthlyDayOfWeekCriteria()
        {
            LabAlertTagQueryRange insertRange = new LabAlertTagQueryMonthlyDayOfWeekRange(new Time(1), new Time(4), WeekOfMonth.First, WeekOfMonth.Second, DayOfWeek.Saturday, DayOfWeek.Thursday);
            LabAlertTagQueryRange updateRange = new LabAlertTagQueryMonthlyDayOfWeekRange(new Time(10), new Time(14), WeekOfMonth.Last, WeekOfMonth.First, DayOfWeek.Monday, DayOfWeek.Wednesday);
            AssertInsertAndUpdateLabAlertTagQueryRange(insertRange, updateRange);
        }

        [Ignore] [Test]
        public void ShouldInsertAndUpdateMonthlyDayOfMonthCriteria()
        {
            LabAlertTagQueryRange insertRange = new LabAlertTagQueryMonthlyDayOfMonthRange(new Time(1), new Time(4), DayOfMonth.Day(6), DayOfMonth.Day(20));
            LabAlertTagQueryRange updateRange = new LabAlertTagQueryMonthlyDayOfMonthRange(new Time(10), new Time(14), DayOfMonth.Day(12), DayOfMonth.Day(16));
            AssertInsertAndUpdateLabAlertTagQueryRange(insertRange, updateRange);
        }

        private void AssertInsertAndUpdateLabAlertTagQueryRange(LabAlertTagQueryRange insertRange, LabAlertTagQueryRange updateRange)
        {
            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition();
            definition.LabAlertTagQueryRange = insertRange;
            definition = dao.Insert(definition);
            long id = definition.IdValue;

            {
                LabAlertDefinition requeried = dao.QueryById(id);
                Assert.IsNotNull(requeried);
                Assert.AreEqual(insertRange.ToString(), requeried.LabAlertTagQueryRange.ToString());

                requeried.LabAlertTagQueryRange = updateRange;
                dao.Update(requeried);
            }
            {
                LabAlertDefinition requeried = dao.QueryById(id);
                Assert.IsNotNull(requeried);
                Assert.AreEqual(updateRange.ToString(), requeried.LabAlertTagQueryRange.ToString());
            }
        }
     
        [Ignore] [Test]
        public void ShouldDelete()
        {
            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition();
            LabAlertDefinition saved = dao.Insert(definition);
            long id = saved.IdValue;

            {
                LabAlertDefinition requeried = dao.QueryById(id);
                Assert.IsNotNull(requeried);
                Assert.IsFalse(requeried.Deleted);
            }

            dao.Remove(saved);
            {
                LabAlertDefinition requeried = dao.QueryById(id);
                Assert.IsNotNull(requeried);
                Assert.IsTrue(requeried.Deleted);
            }
        }

        [Ignore] [Test]
        public void ShouldGetCountByNameAndSite()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU_SMF();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_DN1_3003_0000();

            LabAlertDefinition definition1 = dao.Insert(LabAlertDefinitionFixture.CreateDefinition("same name", floc1));
            LabAlertDefinition definition2 = dao.Insert(LabAlertDefinitionFixture.CreateDefinition("same name", floc1));
            LabAlertDefinition definition3 = dao.Insert(LabAlertDefinitionFixture.CreateDefinition("same name", floc1));
            LabAlertDefinition definition4 = dao.Insert(LabAlertDefinitionFixture.CreateDefinition("same name", floc2));

            {
                List<LabAlertDefinition> results = dao.QueryByName(SiteFixture.Sarnia().IdValue, "same name");
                Assert.IsTrue(results.ExistsById(definition1));
                Assert.IsTrue(results.ExistsById(definition2));
                Assert.IsTrue(results.ExistsById(definition3));
                Assert.IsFalse(results.ExistsById(definition4));
            }
            {
                List<LabAlertDefinition> results = dao.QueryByName(SiteFixture.Denver().IdValue, "same name");
                Assert.IsFalse(results.ExistsById(definition1));
                Assert.IsFalse(results.ExistsById(definition2));
                Assert.IsFalse(results.ExistsById(definition3));
                Assert.IsTrue(results.ExistsById(definition4));
            }

            dao.Remove(definition1);

            {
                List<LabAlertDefinition> results = dao.QueryByName(SiteFixture.Sarnia().IdValue, "same name");
                Assert.IsFalse(results.ExistsById(definition1));
                Assert.IsTrue(results.ExistsById(definition2));
                Assert.IsTrue(results.ExistsById(definition3));
                Assert.IsFalse(results.ExistsById(definition4));
            }
            {
                List<LabAlertDefinition> results = dao.QueryByName(SiteFixture.Denver().IdValue, "same name");
                Assert.IsFalse(results.ExistsById(definition1));
                Assert.IsFalse(results.ExistsById(definition2));
                Assert.IsFalse(results.ExistsById(definition3));
                Assert.IsTrue(results.ExistsById(definition4));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryLabAlertDefinitionsWithValidAndInvalidTag()
        {
            TagInfo tag1 = TagInfoFixture.CreateTagInfoWithId2FromDB();
            TagInfo tag2 = TagInfoFixture.CreateTagEquipmentAWithUnitsMPHAndFortMcMurrayFLOC();

            LabAlertDefinition definition1 = dao.Insert(LabAlertDefinitionFixture.CreateDefinition(
                LabAlertDefinitionStatus.Valid, tag1));
            LabAlertDefinition definition2 = dao.Insert(LabAlertDefinitionFixture.CreateDefinition(
                LabAlertDefinitionStatus.Valid, tag1));
            LabAlertDefinition definition3 = dao.Insert(LabAlertDefinitionFixture.CreateDefinition(
                LabAlertDefinitionStatus.Valid, tag2));
            LabAlertDefinition definition4 = dao.Insert(LabAlertDefinitionFixture.CreateDefinition(
                LabAlertDefinitionStatus.InvalidTag, tag1));
            LabAlertDefinition definition5 = dao.Insert(LabAlertDefinitionFixture.CreateDefinition(
                LabAlertDefinitionStatus.InvalidTag, tag1));
            LabAlertDefinition definition6 = dao.Insert(LabAlertDefinitionFixture.CreateDefinition(
                LabAlertDefinitionStatus.InvalidTag, tag2));

            dao.Remove(definition2);
            dao.Remove(definition5);

            {
                List<LabAlertDefinition> results = dao.QueryLabAlertDefinitionsWithValidTag(tag1);
                Assert.IsTrue(results.ExistsById(definition1));
                Assert.IsFalse(results.ExistsById(definition2));
                Assert.IsFalse(results.ExistsById(definition3));
                Assert.IsFalse(results.ExistsById(definition4));
                Assert.IsFalse(results.ExistsById(definition5));
                Assert.IsFalse(results.ExistsById(definition6));
            }
            {
                List<LabAlertDefinition> results = dao.QueryLabAlertDefinitionsWithValidTag(tag2);
                Assert.IsFalse(results.ExistsById(definition1));
                Assert.IsFalse(results.ExistsById(definition2));
                Assert.IsTrue(results.ExistsById(definition3));
                Assert.IsFalse(results.ExistsById(definition4));
                Assert.IsFalse(results.ExistsById(definition5));
                Assert.IsFalse(results.ExistsById(definition6));
            }

            {
                List<LabAlertDefinition> results = dao.QueryLabAlertDefinitionsWithInvalidTag(tag1);
                Assert.IsFalse(results.ExistsById(definition1));
                Assert.IsFalse(results.ExistsById(definition2));
                Assert.IsFalse(results.ExistsById(definition3));
                Assert.IsTrue(results.ExistsById(definition4));
                Assert.IsFalse(results.ExistsById(definition5));
                Assert.IsFalse(results.ExistsById(definition6));
            }
            {
                List<LabAlertDefinition> results = dao.QueryLabAlertDefinitionsWithInvalidTag(tag2);
                Assert.IsFalse(results.ExistsById(definition1));
                Assert.IsFalse(results.ExistsById(definition2));
                Assert.IsFalse(results.ExistsById(definition3));
                Assert.IsFalse(results.ExistsById(definition4));
                Assert.IsFalse(results.ExistsById(definition5));
                Assert.IsTrue(results.ExistsById(definition6));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryLabAlertDefinitionsForScheduling()
        {
            TagInfo tag = TagInfoFixture.CreateTagInfoWithId2FromDB();
            
            LabAlertDefinition definition1 = dao.Insert(LabAlertDefinitionFixture.CreateDefinition(LabAlertDefinitionStatus.Valid, tag));
            LabAlertDefinition definition2 = dao.Insert(LabAlertDefinitionFixture.CreateDefinition(LabAlertDefinitionStatus.InvalidTag, tag));

            {
                LabAlertDefinition result = dao.QueryByScheduleId(definition1.Schedule.Id.Value);
                Assert.IsNotNull(result);
                Assert.AreEqual(definition1.IdValue, result.IdValue);
            }

            {
                LabAlertDefinition result = dao.QueryByScheduleId(definition2.Schedule.Id.Value);
                Assert.IsNotNull(result);
                Assert.AreEqual(definition2.IdValue, result.IdValue);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryLabAlertDefinitionsByScheduleId()
        {

        }
    }
}
