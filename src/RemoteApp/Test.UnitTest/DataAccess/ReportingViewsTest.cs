using System.Data.SqlClient;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess
{
    // This test is just to make sure that things haven't changed and that the views still run.
    [TestFixture] [Category("Database")]
    public class ReportingViewsTest : AbstractDaoTest
    {
        
        protected override void TestInitialize()
        {           
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldWork()
        {
            CheckView("VReportingActionItems", "FunctionalLocation");
            CheckView("VReportingDailyDirectives", "FunctionalLocation");
            CheckView("VReportingFormOP14", "FunctionalLocation");
            CheckView("VReportingLogs", "FunctionalLocation");
            CheckView("VReportingSummaryLogs", "FunctionalLocation");
            CheckView("VReportingShiftHandoverAnswers", "QuestionnaireCreatedByUserId");
            CheckView("VReportingTargetAlerts", "FunctionalLocation");            
            CheckView("VReportingTargetDefinitions", "FunctionalLocation");            
        }

        private static void CheckView(string view, string columnToCheck)
        {
            using(SqlDataReader reader = TestDataAccessUtil.ExecuteReader("select top 10 * from " + view))
            {
                Assert.IsTrue(reader.HasRows);
                reader.Read();
                string value = reader.Get<string>(columnToCheck); // Just wanted to make sure that everything's working up to the point of getting a value back
                string site = reader.Get<string>("Site"); // These all have a requirement of being queried by site
                long siteId = reader.Get<long>("SiteId"); // These all have a requirement of being queried by site

                reader.Close();                
            }           
        }      
    }
}
