using System.Data.SqlClient;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess
{
    [TestFixture] [Category("Database")]
    public class VOilSandsSummaryLogsTest : AbstractDaoTest
    {
        private const string VIEW = "VOilSandsSummaryLogs";
        private const string SUMMARY_LOG_ID_COLUMN_NAME = "SummaryLog-Id";

        private ISummaryLogDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ISummaryLogDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldNotReturnDeletedSummaryLogs()
        {
            SummaryLog summaryLog = CreateSummaryLog();
            summaryLog = dao.Insert(summaryLog);

            SummaryLog deletedSummaryLog = CreateSummaryLog();
            deletedSummaryLog = dao.Insert(deletedSummaryLog);
            dao.Remove(deletedSummaryLog);

            bool hasSummaryLog = false;
            bool hasDeletedSummaryLog = false;
            SqlDataReader reader = TestDataAccessUtil.ExecuteReader("select * from " + VIEW);
            try
            {
                while (reader.Read())
                {
                    long id = reader.Get<long>(SUMMARY_LOG_ID_COLUMN_NAME);
                    if (id == summaryLog.Id)
                    {
                        hasSummaryLog = true;
                    }
                    else if (id == deletedSummaryLog.Id)
                    {
                        hasDeletedSummaryLog = true;
                    }
                }
            }
            finally 
            {
                reader.Close();
                reader.Dispose();
            }

            Assert.IsTrue(hasSummaryLog);
            Assert.IsFalse(hasDeletedSummaryLog);
        }

        private static SummaryLog CreateSummaryLog()
        {
            SummaryLog summaryLog = SummaryLogFixture.CreateSummaryLog();
            summaryLog.FunctionalLocations.Clear();
            summaryLog.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI());            
            summaryLog.RtfComments = "b";
            summaryLog.PlainTextComments = "b";
            summaryLog.DorComments = "c";
            return summaryLog;
        }
    }
}
