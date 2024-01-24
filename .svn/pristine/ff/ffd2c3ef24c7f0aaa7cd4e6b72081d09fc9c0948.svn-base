using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class LogDefinitionHistoryDaoTest : AbstractDaoTest
    {
        private ILogDefinitionHistoryDao dao;
        private LogDefinition logDefinition;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ILogDefinitionHistoryDao>();
            ILogDefinitionDao logDefinitionDao = DaoRegistry.GetDao<ILogDefinitionDao>();
            logDefinition = LogDefinitionFixture.CreateOperatingEngineerLogDefintionWithRecurringWeeklySchedule();
            logDefinition.Active = true;
                     
            logDefinitionDao.Insert(logDefinition);
            logDefinition = logDefinitionDao.QueryById(logDefinition.IdValue);
        }

        protected override void Cleanup() {}

        [Ignore] [Test]
        public void QueryByLogDefinitionIdShouldReturnHistoryObjectsInChronologicalOrder()
        {
            LogDefinitionHistory history1 = LogDefinitionHistoryFixture.Create(logDefinition, new DateTime(2006, 1, 1));
            LogDefinitionHistory history2 = LogDefinitionHistoryFixture.Create(logDefinition, new DateTime(2006, 1, 2));
            LogDefinitionHistory history3 = LogDefinitionHistoryFixture.Create(logDefinition, new DateTime(2006, 1, 3));
            var expectedHistories = new List<LogDefinitionHistory>(
                    new[] {history1, history2, history3});
            dao.Insert(history3);
            dao.Insert(history1);
            dao.Insert(history2);
            List<LogDefinitionHistory> histories = dao.QueryByLogDefinitionId(logDefinition.IdValue);
            Assert.AreEqual(expectedHistories, histories);
        }

        [Ignore] [Test]
        public void ShouldInsertCustomFieldEntryHistory()
        { 
            List<CustomFieldEntryHistory> customFieldEntryHistories = new List<CustomFieldEntryHistory>();
            customFieldEntryHistories.Add(new CustomFieldEntryHistory(null, 1, "field name one", "field entry one"));
            customFieldEntryHistories.Add(new CustomFieldEntryHistory(null, 2, "field name two", null));            

            LogDefinitionHistory history = LogDefinitionHistoryFixture.Create(logDefinition, new DateTime(2006, 1, 1));
            history.CustomFieldEntries.Clear();
            history.CustomFieldEntries.AddRange(customFieldEntryHistories);

            dao.Insert(history);                                   

            LogDefinitionHistory retrieved = dao.QueryByLogDefinitionId(logDefinition.IdValue)[0];
            Assert.AreEqual(2, retrieved.CustomFieldEntries.Count);
            Assert.IsTrue(retrieved.CustomFieldEntries.Exists(obj => obj.CustomFieldName == "field name one" && obj.FieldEntry == "field entry one"));
            Assert.IsTrue(retrieved.CustomFieldEntries.Exists(obj => obj.CustomFieldName == "field name two" && obj.FieldEntry == null));
        }

        [Ignore] [Test]
        public void ShouldSetActiveFlag()
        {
            LogDefinition directiveDefinition = null;

            {
                ILogDefinitionDao logDefinitionDao = DaoRegistry.GetDao<ILogDefinitionDao>();
                directiveDefinition = LogDefinitionFixture.CreateLogDefinition(null, LogType.DailyDirective, null, true);
                directiveDefinition.Active = true;

                logDefinitionDao.Insert(directiveDefinition);
                directiveDefinition = logDefinitionDao.QueryById(directiveDefinition.IdValue);
            }

            {
                LogDefinitionHistory history1 = LogDefinitionHistoryFixture.Create(directiveDefinition, new DateTime(2006, 1, 1));
                dao.Insert(history1);
                List<LogDefinitionHistory> list = dao.QueryByLogDefinitionId(directiveDefinition.IdValue);

                Assert.AreEqual(1, list.Count);
                Assert.IsTrue(list[0].Active);                
            }

            {
                directiveDefinition.Active = false;
                LogDefinitionHistory history2 = LogDefinitionHistoryFixture.Create(directiveDefinition, new DateTime(2006, 1, 2));
                dao.Insert(history2);
                List<LogDefinitionHistory> list = dao.QueryByLogDefinitionId(directiveDefinition.IdValue);

                Assert.AreEqual(2, list.Count);
                Assert.IsFalse(list[1].Active);
            }
        }
    }
}