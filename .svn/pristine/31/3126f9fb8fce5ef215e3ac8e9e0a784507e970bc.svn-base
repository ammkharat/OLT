using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess
{
    [TestFixture] [Category("Database")]
    public class FunctionalLocationOperationalModeTest : AbstractDaoTest
    {
        private ILogDao dao;

        protected override void TestInitialize()
        {
            // Hack: To get proper initialization for this test.
            dao = DaoRegistry.GetDao<ILogDao>();
            dao.QueryById(1);
        }

        protected override void Cleanup()
        {
        }

        // Data integrity check. If this query is not returning zero rows there is a problem with the data.
        // This came out of the fact that we once had to manually insert Functional Locations and we forgot to put the corresponding rows in the FunctionalLocationOperationalMode
        // table (which can cause the app to error out when Action Items created at the 3rd level are generated).
        [Ignore] [Test]
        public void AllThirdLevelFunctionalLocationsMustHaveAnEntryInFunctionalLocationOperationalModeTable()
        {
            LocalDataStoreSlot dataStore = Thread.GetNamedDataSlot(AbstractManagedDao.COMMAND_STORE_NAME);
            
            SqlCommand command = Thread.GetData(dataStore) as SqlCommand;
            
            command.CommandType = CommandType.Text; // must set this since we are not calling an actual stored procedure

            string querySQL = "SELECT COUNT(*) FROM FunctionalLocation " +
                                  "WHERE [Level] = 3 " +
                                  "AND id not in " +
                                  "(" +
                                  "SELECT unitId FROM FunctionalLocationOperationalMode" +
                                  ")";
            
            int count = command.GetCount(querySQL);

            Assert.AreEqual(0, count);
        }
        
    }
}