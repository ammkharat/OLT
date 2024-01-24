using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class TargetDefinitionHistoryDaoTest : AbstractDaoTest
    {
        ITargetDefinitionHistoryDao targetDefinitionHistoryDao;
        IUserDao userDao;
        ITagDao tagDao;
        IFunctionalLocationDao functionalLocationDao;

        protected override void TestInitialize()
        {
            targetDefinitionHistoryDao = DaoRegistry.GetDao<ITargetDefinitionHistoryDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
            tagDao = DaoRegistry.GetDao<ITagDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void GetTargetDefinitionHistoriesByIdShouldReturnMoreThanOneHistoryObject()
        {
            Assert.IsTrue(targetDefinitionHistoryDao.GetById(1).Count > 1);
        }

        [Ignore] [Test]
        public void InsertTargetDefinitionHistory()
        {
            TargetDefinitionHistory targetDefinitionHistory = TargetDefinitionHistoryFixture.CreateTargetDefinitionHistory();
            targetDefinitionHistory.Id = 5;
            targetDefinitionHistory.LastModifiedBy = userDao.QueryById(1);
            targetDefinitionHistory.TagInfo = tagDao.QueryById(1);
            targetDefinitionHistory.FunctionalLocation = functionalLocationDao.QueryById(100);
            targetDefinitionHistory.PreApprovedMinValue = 25.0m;
            targetDefinitionHistoryDao.Insert(targetDefinitionHistory);
            List<TargetDefinitionHistory> targetDefinitionHistories = targetDefinitionHistoryDao.GetById(targetDefinitionHistory.Id.Value);
            TargetDefinitionHistory queriedTargetDefinitionHistory = targetDefinitionHistories[targetDefinitionHistories.Count - 1];
            Assert.AreEqual(targetDefinitionHistory, queriedTargetDefinitionHistory);
        }

        [Ignore] [Test]
        public void ShouldRetuenTheSameAfterInsertAndQuery()
        {
            TargetDefinitionHistory history = TargetDefinitionHistoryFixture.CreateTargetDefinitionHistory();
            history.LastModifiedBy = userDao.QueryById(1);
            targetDefinitionHistoryDao.Insert(history);

            List<TargetDefinitionHistory> historyList = targetDefinitionHistoryDao.GetById(history.Id.Value);

            TargetDefinitionHistory queriedHistory = historyList[historyList.Count - 1];
            Assert.AreEqual(history, queriedHistory);
        }
    }
}
