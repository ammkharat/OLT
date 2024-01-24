using System.Collections.Generic;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class LogHistoryDaoTest : AbstractDaoTest
    {
        ILogHistoryDao logHistoryDao;
        IFunctionalLocationDao functionalLocationDao;
        IUserDao userDao;

        private long logId;

        protected override void TestInitialize()
        {
            logHistoryDao = DaoRegistry.GetDao<ILogHistoryDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();

            const string sqlTestStatement = "SELECT LogHistory.Id FROM LogHistory where LogHistoryId = 100"; // test data gets inserted with LogHistoryId of 100.
            logId = TestDataAccessUtil.ExecuteScalarExpression<long>(sqlTestStatement);
        }

        protected override void Cleanup() {}
        
        [Ignore] [Test]
        public void GetLogHistoriesByIdShouldReturnMoreThanOneHistoryObject()
        {
            Assert.IsTrue(logHistoryDao.GetById(logId).Count > 1);
        }

        [Ignore] [Test]
        public void InsertLogHistory()
        {
            LogHistory logHistory = LogHistoryFixture.CreateLogHistory(functionalLocationDao.QueryById(100), userDao.QueryById(1), "some comments");
            logHistory.Id = logId;
            logHistoryDao.Insert(logHistory);
            List<LogHistory> logHistories = logHistoryDao.GetById(logHistory.Id.Value);
            LogHistory queriedLogHistory = logHistories.Last();
            Assert.AreEqual(logId, queriedLogHistory.Id);
            Assert.AreEqual(logHistory, queriedLogHistory);            
        }

        [Ignore] [Test]
        public void ShouldInsertCommentHistory()
        {
            LogHistory logHistory = LogHistoryFixture.CreateLogHistory(functionalLocationDao.QueryById(100), userDao.QueryById(1), "text1");
            logHistory.Id = logId;            
            
            logHistoryDao.Insert(logHistory);

            List<LogHistory> logHistories = logHistoryDao.GetById(logHistory.Id.Value);
            LogHistory retrieved = logHistories.Last();
            Assert.AreEqual("text1", retrieved.PlainTextComments);
        }

        [Ignore] [Test]
        public void ShouldInsertCustomFieldEntryHistory()
        {
            List<CustomFieldEntryHistory> customFieldEntryHistories = new List<CustomFieldEntryHistory>();
            customFieldEntryHistories.Add(new CustomFieldEntryHistory(null, 1, "field name one", "field entry one"));
            customFieldEntryHistories.Add(new CustomFieldEntryHistory(null, 2, "field name two", null));

            LogHistory logHistory = LogHistoryFixture.CreateLogHistory(functionalLocationDao.QueryById(100), userDao.QueryById(1), "comments");
            logHistory.Id = logId;            
            logHistory.CustomFieldEntryHistories.AddRange(customFieldEntryHistories);

            logHistoryDao.Insert(logHistory);

            List<LogHistory> logHistories = logHistoryDao.GetById(logHistory.Id.Value);
            LogHistory retrieved = logHistories.Last();
            Assert.AreEqual(2, retrieved.CustomFieldEntryHistories.Count);
            Assert.IsTrue(retrieved.CustomFieldEntryHistories.Exists(obj => obj.CustomFieldName == "field name one" && obj.FieldEntry == "field entry one"));
            Assert.IsTrue(retrieved.CustomFieldEntryHistories.Exists(obj => obj.CustomFieldName == "field name two" && obj.FieldEntry == null));
        }

        [Ignore] [Test]
        public void ShouldInsertIsOperatingEngineerLog()
        {
            LogHistory history = LogHistoryFixture.CreateLogHistory(functionalLocationDao.QueryById(100), userDao.QueryById(1), "comments", true);
            history.Id = logId;
            logHistoryDao.Insert(history);

            {
                List<LogHistory> results = logHistoryDao.GetById(history.IdValue);
                LogHistory logHistory = results.Last();
                Assert.IsTrue(logHistory.IsOperatingEngineerLog);
            }
        }
    }
}
