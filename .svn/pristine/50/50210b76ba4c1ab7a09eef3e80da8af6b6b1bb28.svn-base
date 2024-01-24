using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class ProcedureDeviationHistoryDaoTest : AbstractDaoTest
    {
        private IProcedureDeviationHistoryDao historyDao;
        private IProcedureDeviationDao procedureDeviationDao;

        [Ignore] [Test]
        public void ShouldInsert()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2015, 11, 5);

            var insertedProcedureDeviation = CreateAndInsertProcedureDeviation();

            var history = insertedProcedureDeviation.TakeSnapshot();

            historyDao.Insert(history);
            var histories = historyDao.GetById(history.IdValue);

            Assert.AreEqual(1, histories.Count);
            var requeried = histories[0];
            Assert.IsNotNull(requeried);

            Clock.UnFreeze();
        }

        private ProcedureDeviation CreateAndInsertProcedureDeviation()
        {
            var floc1 = FunctionalLocationFixture.GetReal_EX1_OPLT_BLDI();
            var floc2 = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL();
            var flocs = new List<FunctionalLocation> {floc1, floc2};

            var validFromDateTime = new DateTime(2015, 11, 1);
            var validToDateTime = new DateTime(2015, 11, 10);

            var procedureDeviation = ProcedureDeviationFixture.CreateForInsert(flocs, validFromDateTime, validToDateTime,
                FormStatus.Draft, UserFixture.CreateOilSandsUserWithUserPrintPreference());

            return procedureDeviationDao.Insert(procedureDeviation);
        }

        protected override void TestInitialize()
        {
            procedureDeviationDao = DaoRegistry.GetDao<IProcedureDeviationDao>();
            historyDao = DaoRegistry.GetDao<IProcedureDeviationHistoryDao>();
        }

        protected override void Cleanup()
        {
        }
    }
}