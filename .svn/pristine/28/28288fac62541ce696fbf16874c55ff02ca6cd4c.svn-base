using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;
using Is = NMock2.Is;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class DeviationAlertResponseHistoryDaoTest : AbstractDaoTest
    {
        private IDeviationAlertResponseDao responseDao;
        private IDeviationAlertResponseHistoryDao historyDao;

        protected override void TestInitialize()
        {
            responseDao = DaoRegistry.GetDao<IDeviationAlertResponseDao>();
            historyDao = DaoRegistry.GetDao<IDeviationAlertResponseHistoryDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            DeviationAlertResponse response = responseDao.QueryById(DeviationAlertResponseFixture.CreateResponseWithId1FromDB().IdValue);
            DeviationAlertResponseHistory history = new DeviationAlertResponseHistory(
                response.IdValue,
                "here are some codes",
                "this is a comment",
                response.LastModifiedBy,
                response.LastModifiedDateTime);
            historyDao.Insert(history);

            List<DeviationAlertResponseHistory> histories = historyDao.GetById(history.IdValue);
            Assert.AreEqual(1, histories.Count);

            DeviationAlertResponseHistory requeried = histories[0];
            Assert.AreEqual(response.Id, requeried.Id);
            Assert.IsTrue(Is.StringContaining("here are some codes").Matches(requeried.ReasonCodes));
            Assert.IsTrue(Is.StringContaining("this is a comment").Matches(requeried.Comments));
            Assert.AreEqual(response.LastModifiedBy.Id, requeried.LastModifiedBy.Id);
            Assert.AreEqual(response.LastModifiedDateTime, requeried.LastModifiedDate);

        }
    }
}