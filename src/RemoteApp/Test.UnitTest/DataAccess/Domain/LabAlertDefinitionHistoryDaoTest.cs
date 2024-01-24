using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class LabAlertDefinitionHistoryDaoTest : AbstractDaoTest
    {
        private ILabAlertDefinitionHistoryDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ILabAlertDefinitionHistoryDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            LabAlertDefinition definition = LabAlertDefinitionFixture.CreateDefinition();
            definition.Id = 1234;
            definition.TagInfo = TagInfoFixture.CreateTagInfoWithId2FromDB();
            LabAlertDefinitionHistory history = definition.TakeSnapshot();
            dao.Insert(history);

            List<LabAlertDefinitionHistory> histories = dao.GetById(history.IdValue);
            Assert.AreEqual(1, histories.Count);

            LabAlertDefinitionHistory requeried = histories[0];
            Assert.AreEqual(definition.Id, requeried.Id);
            Assert.AreEqual(definition.Name, requeried.Name);
            Assert.AreEqual(definition.FunctionalLocation.Id, requeried.FunctionalLocation.Id);
            Assert.AreEqual(definition.Description, requeried.Description);
            Assert.AreEqual(definition.TagInfo.Id, requeried.TagInfo.Id);
            Assert.AreEqual(definition.MinimumNumberOfSamples, requeried.MinimumNumberOfSamples);
            Assert.AreEqual(definition.LabAlertTagQueryRange.ToString(), requeried.LabAlertTagQueryRange);
            Assert.AreEqual(definition.ScheduleDescription, requeried.Schedule);
            Assert.AreEqual(definition.IsActive, requeried.IsActive);
            Assert.AreEqual(definition.LastModifiedBy.Id, requeried.LastModifiedBy.Id);
            Assert.That(definition.LastModifiedDate, Is.EqualTo(requeried.LastModifiedDate).Within(TimeSpan.FromSeconds(10)));
        }
    }
}
