using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class SummaryLogHistoryDaoTest : AbstractDaoTest
    {
        ISummaryLogHistoryDao logHistoryDao;
        IFunctionalLocationDao functionalLocationDao;
        IUserDao userDao;

        protected override void TestInitialize()
        {
            logHistoryDao = DaoRegistry.GetDao<ISummaryLogHistoryDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
        }

        protected override void Cleanup() {}
       
        [Ignore] [Test]
        public void ShouldInsertLogHistory()
        {
            SummaryLogHistory logHistory = CreateLogHistory(functionalLocationDao.QueryById(100), userDao.QueryById(1));
            logHistory.Id = 1;
            logHistoryDao.Insert(logHistory);
            List<SummaryLogHistory> logHistories = logHistoryDao.GetById(logHistory.Id.Value);
            SummaryLogHistory queriedLogHistory = logHistories[logHistories.Count - 1];
            Assert.AreEqual(logHistory, queriedLogHistory);
                                    
            Assert.IsTrue(queriedLogHistory.CustomFieldEntryHistories.Exists(entryHistory => entryHistory.Id == 1 && entryHistory.CustomFieldName == "field name one" && entryHistory.FieldEntry == "field entry one"));
            Assert.IsTrue(queriedLogHistory.CustomFieldEntryHistories.Exists(entryHistory => entryHistory.Id == 2 && entryHistory.CustomFieldName == "field name two" && entryHistory.FieldEntry == null));
            Assert.AreEqual(2, queriedLogHistory.CustomFieldEntryHistories.Count);
        }

        private static SummaryLogHistory CreateLogHistory(FunctionalLocation floc, User user)
        {
            List<FunctionalLocation> flocList = new List<FunctionalLocation> { floc };

            string flocListString = flocList.FullHierarchyListToString(false, false);
          
            List<CustomFieldEntryHistory> customFieldEntryHistories = new List<CustomFieldEntryHistory>
                {
                    new CustomFieldEntryHistory(1, 1, "field name one", "field entry one"),
                    new CustomFieldEntryHistory(1, 2, "field name two", null)
                };

            const string plainTextComments = "Comments";
            const string dorComments = "DOR Comments";

            SummaryLogHistory logHistory =
                new SummaryLogHistory(
                    5, flocListString, false, false, false, false,
                    false, false, new DateTime(2006, 05, 16, 13, 41, 00), user,
                    new DateTime(2006, 05, 16, 13, 42, 00), "livelink links", 
                    plainTextComments, dorComments, customFieldEntryHistories);
            return logHistory;
        }
    }
}
