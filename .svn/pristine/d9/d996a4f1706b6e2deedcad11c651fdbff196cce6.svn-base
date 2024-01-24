using System;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class FunctionalLocationOperationalModeHistoryDaoTest : AbstractDaoTest
    {
        private IFunctionalLocationOperationalModeHistoryDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IFunctionalLocationOperationalModeHistoryDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldInsertFunctionalLocationOperationalMode()
        {
            User lastModifiedBy = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
            FunctionalLocationOperationalModeHistory expected = new FunctionalLocationOperationalModeHistory(100,
                                                                                                             OperationalMode.Normal,
                                                                                                             AvailabilityReason.Other,
                                                                                                             DateTimeFixture.DateTimeNow,
                                                                                                             lastModifiedBy);
            dao.Insert(expected);
            Assert.IsTrue(expected.Id.HasValue);
            FunctionalLocationOperationalModeHistory actual = QueryByFLOCOpModeHistoryById(expected.IdValue);
            Assert.AreEqual(expected.LastModifiedBy.Id, actual.LastModifiedBy.Id);
            Assert.AreEqual(expected.OperationalMode, actual.OperationalMode);
            Assert.AreEqual(expected.AvailabilityReason, actual.AvailabilityReason);
            Assert.AreEqual(expected.UnitId, actual.UnitId);
        }

        private static FunctionalLocationOperationalModeHistory QueryByFLOCOpModeHistoryById(long id)
        {
            const string QUERY_TEMPLATE = "SELECT * FROM FunctionalLocationOperationalModeHistory WHERE Id = {0} ";
            string sqlStatement = string.Format(QUERY_TEMPLATE, id);
            FunctionalLocationOperationalModeHistory ret = null;
            using(SqlDataReader reader = TestDataAccessUtil.ExecuteReader(sqlStatement))
            {
                if(reader.Read())
                {
                    long flocUnitId = reader.Get<long>("UnitId");
                    long operationalModeId = reader.Get<long>("OperationalModeId");
                    OperationalMode operationalMode = OperationalMode.GetById(operationalModeId);
                    long availabilityReasonId = reader.Get<long>("AvailabilityReasonId");
                    AvailabilityReason availabilityReason = AvailabilityReason.GetById(availabilityReasonId);
                    DateTime lastModifiedDateTime = reader.Get<DateTime>("LastModifiedDateTime");
                    long lastModifiedByUserId = reader.Get<long>("LastModifiedUserId");
                    User lastMOdifiedByUser = UserFixture.CreateUser();
                    lastMOdifiedByUser.Id = lastModifiedByUserId;
                    ret = new FunctionalLocationOperationalModeHistory(flocUnitId, operationalMode, availabilityReason, lastModifiedDateTime, lastMOdifiedByUser);
                    ret.Id = reader.Get<long?>("Id");
                }
            }
            return ret;
        }
    }
}