using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class ActionItemDefinitionHistoryDaoTest : AbstractDaoTest
    {
        private IActionItemDefinitionHistoryDao actionItemDefinitionHistoryDao;
        private IUserDao userDao;
        private IBusinessCategoryDao businessCategoryDao;

        protected override void TestInitialize()
        {
            actionItemDefinitionHistoryDao = DaoRegistry.GetDao<IActionItemDefinitionHistoryDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
            businessCategoryDao = DaoRegistry.GetDao<IBusinessCategoryDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void GetActionItemDefinitionHistoriesByIdShouldReturnMoreThanOneHistoryObject()
        {
            const long id = 1;

            {
                ActionItemDefinitionHistory history = ActionItemDefinitionHistoryFixture.CreateActionItemDefinitionHistory("assignment 1");
                history.Id = id;
                actionItemDefinitionHistoryDao.Insert(history);
            }
            {
                ActionItemDefinitionHistory history = ActionItemDefinitionHistoryFixture.CreateActionItemDefinitionHistory("assignment 2");
                history.Id = id;
                actionItemDefinitionHistoryDao.Insert(history);
            }

            List<ActionItemDefinitionHistory> results = actionItemDefinitionHistoryDao.GetById(id);
            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results.Exists(obj => obj.WorkAssignment == "assignment 1"));
            Assert.IsTrue(results.Exists(obj => obj.WorkAssignment == "assignment 2"));
        }

        [Ignore] [Test]
        public void InsertActionItemDefinitionHistory()
        {
            BusinessCategory businessCategory = businessCategoryDao.QueryById(5);

            ActionItemDefinitionHistory actionItemDefinitionHistory = ActionItemDefinitionHistoryFixture.CreateActionItemDefinitionHistory();
            actionItemDefinitionHistory.Category = businessCategory;
            actionItemDefinitionHistory.Id = 1;
            actionItemDefinitionHistory.LastModifiedBy = userDao.QueryById(1);
            actionItemDefinitionHistoryDao.Insert(actionItemDefinitionHistory);
            List<ActionItemDefinitionHistory> actionItemDefinitionHistories = actionItemDefinitionHistoryDao.GetById(actionItemDefinitionHistory.Id.Value);
            ActionItemDefinitionHistory queriedActionItemDefinitionHistory = actionItemDefinitionHistories[actionItemDefinitionHistories.Count - 1];
            Assert.AreEqual(actionItemDefinitionHistory, queriedActionItemDefinitionHistory);
        }

        [Ignore] [Test]
        public void ShouldInsertNullWorkAssignmentName()
        {
            ActionItemDefinitionHistory actionItemDefinitionHistory = ActionItemDefinitionHistoryFixture.CreateActionItemDefinitionHistory(null);
            actionItemDefinitionHistoryDao.Insert(actionItemDefinitionHistory);
            List<ActionItemDefinitionHistory> actionItemDefinitionHistories = actionItemDefinitionHistoryDao.GetById(actionItemDefinitionHistory.IdValue);
            ActionItemDefinitionHistory queriedActionItemDefinitionHistory = actionItemDefinitionHistories[actionItemDefinitionHistories.Count - 1];
            Assert.IsNull(queriedActionItemDefinitionHistory.WorkAssignment);
        }
    }
}