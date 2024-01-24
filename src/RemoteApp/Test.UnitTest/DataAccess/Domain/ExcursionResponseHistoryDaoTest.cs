using System;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class ExcursionResponseHistoryDaoTest : AbstractDaoTest
    {
        private IExcursionResponseHistoryDao dao;

        [Ignore] [Test]
        public void ShoudInsert()
        {
            var excursionResponse = OpmExcursionResponseFixture.CreateForInsert();
            excursionResponse.Id = -999;
            excursionResponse.LastModifiedDateTime = new DateTime(2013, 12, 5);
            var excursionResponseHistory = excursionResponse.TakeSnapshot();

            dao.Insert(excursionResponseHistory);

            var excursionResponseHistories = dao.GetById(excursionResponse.OltExcursionId);
            Assert.IsTrue(excursionResponseHistories.Count > 0);
            Assert.AreEqual(excursionResponse.Response, excursionResponseHistories[0].Response);
            Assert.AreEqual(excursionResponse.LastModifiedBy.IdValue,
                excursionResponseHistories[0].LastModifiedBy.IdValue);
            Assert.AreEqual(excursionResponse.LastModifiedDateTime, excursionResponseHistories[0].LastModifiedDate);
        }

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IExcursionResponseHistoryDao>();
        }

        protected override void Cleanup()
        {
        }
    }
}