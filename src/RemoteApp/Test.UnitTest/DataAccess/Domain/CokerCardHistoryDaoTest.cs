using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class CokerCardHistoryDaoTest : AbstractDaoTest
    {
        private CokerCardConfiguration configuration;
        private ICokerCardDao cokerCardDao;
        private ICokerCardHistoryDao dao;

        protected override void TestInitialize()
        {
            ICokerCardConfigurationDao configurationDao = DaoRegistry.GetDao<ICokerCardConfigurationDao>();
            List<CokerCardConfiguration> configurations = configurationDao.QueryCokerCardConfigurationsBySite(SiteFixture.Oilsands().IdValue);
            configuration = configurations.Find(obj => obj.FunctionalLocation.Id == FunctionalLocationFixture.GetReal_UP1().Id);

            cokerCardDao = DaoRegistry.GetDao<ICokerCardDao>();
            dao = DaoRegistry.GetDao<ICokerCardHistoryDao>();
        }

        protected override void Cleanup()
        {
        }

        private CokerCard CreateCokerCard()
        {
            CokerCardConfigurationDrum drum1 = configuration.Drums[0];
            CokerCardConfigurationDrum drum2 = configuration.Drums[1];

            CokerCardConfigurationCycleStep step1 = configuration.Steps[0];
            CokerCardConfigurationCycleStep step2 = configuration.Steps[1];

            CokerCard card =CokerCardFixture.CreateForInsert(
                configuration, WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(), ShiftPatternFixture.CreateDayShift(), new Date(2011, 6, 10));

            card.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                null, drum1.IdValue, step1.IdValue,
                new TimeEntry(new Time(12, 0, 0), card.Shift.IdValue, card.ShiftStartDate),
                new TimeEntry(new Time(13, 0, 0), card.Shift.IdValue, card.ShiftStartDate)));
            card.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                null, drum2.IdValue, step2.IdValue,
                new TimeEntry(new Time(14, 0, 0), card.Shift.IdValue, card.ShiftStartDate),
                null));

            card.DrumEntries.Add(new CokerCardDrumEntry(null, drum1.IdValue, step2.IdValue, null, "abc"));
            card.DrumEntries.Add(new CokerCardDrumEntry(null, drum2.IdValue, null, 12.5m, "def"));

            return card;
        }

        [Ignore] [Test]
        public void ShouldInsertAndGetHistory()
        {
            CokerCard cokerCard = CreateCokerCard();
            cokerCard = cokerCardDao.Insert(cokerCard, new List<CokerCardCycleStepEntry>());

            {
                CokerCardHistory cokerCardHistory = cokerCard.TakeSnapshot(configuration, new List<CokerCardCycleStepEntry>());
                dao.Insert(cokerCardHistory);

                List<CokerCardHistory> cokerCardHistories = dao.GetById(cokerCard.IdValue);
                Assert.AreEqual(1, cokerCardHistories.Count);

                Assert.That(cokerCardHistories[0].DrumEntryHistories.Count, Is.GreaterThanOrEqualTo(2));
                {
                    CokerCardDrumEntryHistory drumHistory = cokerCardHistories[0].DrumEntryHistories.Find(
                        obj => obj.DrumConfigurationId == configuration.Drums[0].IdValue);
                    Assert.AreEqual(configuration.Steps[1].Name, drumHistory.LastCycleStep);
                    Assert.AreEqual(null, drumHistory.HoursIntoLastCycle);

                    Assert.That(drumHistory.CycleStepHistory.Count, Is.GreaterThanOrEqualTo(1));
                    CokerCardCycleStepHistory stepHistory = drumHistory.CycleStepHistory.Find(
                        obj => obj.CycleStepConfigurationId == configuration.Steps[0].IdValue);
                    Assert.AreEqual(new Time(12), stepHistory.StartTime);
                    Assert.AreEqual(new Time(13), stepHistory.EndTime);
                }
                {
                    CokerCardDrumEntryHistory drumHistory = cokerCardHistories[0].DrumEntryHistories.Find(
                        obj => obj.DrumConfigurationId == configuration.Drums[1].IdValue);
                    Assert.AreEqual(null, drumHistory.LastCycleStep);
                    Assert.AreEqual(12.5m, drumHistory.HoursIntoLastCycle);

                    Assert.That(drumHistory.CycleStepHistory.Count, Is.GreaterThanOrEqualTo(1));
                    CokerCardCycleStepHistory stepHistory = drumHistory.CycleStepHistory.Find(
                        obj => obj.CycleStepConfigurationId == configuration.Steps[1].IdValue);
                    Assert.AreEqual(new Time(14), stepHistory.StartTime);
                    Assert.IsNull(stepHistory.EndTime);
                }
            }

            {
                CokerCardHistory cokerCardHistory = cokerCard.TakeSnapshot(configuration, new List<CokerCardCycleStepEntry>());
                dao.Insert(cokerCardHistory);
                Assert.That(dao.GetById(cokerCard.IdValue).Count, Is.EqualTo(2));
            }
        }

        [Ignore] [Test]
        public void ShouldInsertHistoryWithPreviousEntries()
        {
            CokerCard cokerCard = CreateCokerCard();
            cokerCard = cokerCardDao.Insert(cokerCard, new List<CokerCardCycleStepEntry>());

            long drumId = configuration.Drums[3].IdValue;
            long stepId = configuration.Steps[3].IdValue;

            List<CokerCardCycleStepEntry> previousEntries = new List<CokerCardCycleStepEntry>();
            previousEntries.Add(new CokerCardCycleStepEntry(
                null, drumId, stepId, 
                new TimeEntry(new Time(1), 0, null), 
                new TimeEntry(new Time(2), 0, null)));

            CokerCardHistory cokerCardHistory = cokerCard.TakeSnapshot(configuration, previousEntries);
            dao.Insert(cokerCardHistory);

            List<CokerCardHistory> cokerCardHistories = dao.GetById(cokerCard.IdValue);
            Assert.AreEqual(1, cokerCardHistories.Count);

            CokerCardDrumEntryHistory drumHistory = cokerCardHistories[0].DrumEntryHistories.Find(obj => obj.DrumConfigurationId == drumId);
            Assert.IsNotNull(drumHistory);

            List<CokerCardCycleStepHistory> stepHistories = drumHistory.CycleStepHistory.FindAll(obj => obj.CycleStepConfigurationId == stepId);
            Assert.AreEqual(2, stepHistories.Count);
            Assert.IsTrue(stepHistories.Exists(obj => obj.StartTime == null && obj.EndTime == null));
            Assert.IsTrue(stepHistories.Exists(obj => obj.StartTime == new Time(1) && obj.EndTime == new Time(2)));
        }
    }
}