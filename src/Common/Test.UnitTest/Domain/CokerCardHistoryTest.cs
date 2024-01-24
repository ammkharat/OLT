using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class CokerCardHistoryTest
    {
        [SetUp]
        public void Setup()
        {
            Clock.Freeze();
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        private static CokerCardConfiguration GetConfiguration()
        {
            CokerCardConfiguration cokerCardConfiguration = new CokerCardConfiguration(1, "whocares", FunctionalLocationFixture.GetReal_UP1());
            CokerCardConfigurationDrum drumConfig1 = new CokerCardConfigurationDrum(1, "Drum1", 1);
            CokerCardConfigurationCycleStep cycleStepConfig1 = new CokerCardConfigurationCycleStep(1, "Step1", 1);

            cokerCardConfiguration.Drums.Add(drumConfig1);
            cokerCardConfiguration.Steps.Add(cycleStepConfig1);

            return cokerCardConfiguration;
        }

        [Test]
        public void ShouldFindDiff()
        {
            CokerCardConfiguration cokerCardConfiguration = GetConfiguration();
            CokerCardConfigurationDrum drumConfig1 = cokerCardConfiguration.Drums[0];
            CokerCardConfigurationCycleStep cycleStepConfig1 = cokerCardConfiguration.Steps[0];

            CokerCard.CokerCard cokerCard = CokerCardFixture.Create(cokerCardConfiguration);
            cokerCard.Id = 100;
            cokerCard.LastModifiedBy = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            cokerCard.LastModifiedDate = Clock.Now;

            CokerCardHistory history1 = cokerCard.TakeSnapshot(cokerCardConfiguration, new List<CokerCardCycleStepEntry>());
            
            cokerCard.LastModifiedBy = UserFixture.CreateOperatorMickeyInFortMcMurrySite();
            cokerCard.LastModifiedDate = Clock.Now.AddHours(1);
            cokerCard.DrumEntries.Add(new CokerCardDrumEntry(200, drumConfig1.IdValue, null, null, "comments"));
            cokerCard.CycleStepEntries.Add(new CokerCardCycleStepEntry(300, drumConfig1.IdValue,
                                                                       cycleStepConfig1.IdValue,
                                                                       new TimeEntry(new Time(12, 0, 0), 1, Clock.DateNow), null));

            CokerCardHistory history2 = cokerCard.TakeSnapshot(cokerCardConfiguration, new List<CokerCardCycleStepEntry>());

            List<CokerCardHistory> cokerCardHistories = new List<CokerCardHistory> {history1, history2};
            List<DomainObjectChangeSet> domainObjectChangeSets = cokerCardHistories.ConvertToChangeSet();

            Assert.That(domainObjectChangeSets.Count, Is.EqualTo(2));
            Assert.That(domainObjectChangeSets[0].PropertyChanges.Count, Is.EqualTo(0));
            Assert.That(domainObjectChangeSets[1].PropertyChanges.Count, Is.EqualTo(2));

            PropertyChange propertyChange = new LocalizedPropertyChange(typeof(CokerCardDrumEntryHistory),"Comments", "Drum1", null, "comments");
            Assert.That(domainObjectChangeSets[1].PropertyChanges, Has.Member(propertyChange));
        }

        [Test]
        public void ShouldCreateHistoryForPreviousCycleStepEntries()
        {
            CokerCardConfiguration configuration = GetConfiguration();
            CokerCard.CokerCard cokerCard = CokerCardFixture.Create(configuration);
            cokerCard.Id = 100;

            List<CokerCardCycleStepEntry> previousEntries = new List<CokerCardCycleStepEntry>();
            previousEntries.Add(new CokerCardCycleStepEntry(
                null, configuration.Drums[0].IdValue, configuration.Steps[0].IdValue, 
                new TimeEntry(new Time(1), -999, null), 
                new TimeEntry(new Time(2), -999, null)));
            previousEntries.Add(new CokerCardCycleStepEntry(
                null, configuration.Drums[0].IdValue, configuration.Steps[0].IdValue,
                new TimeEntry(new Time(3), -999, null),
                null));
            previousEntries.Add(new CokerCardCycleStepEntry(
                null, -10, configuration.Steps[0].IdValue,
                new TimeEntry(new Time(4), -999, null),
                new TimeEntry(new Time(5), -999, null)));
            previousEntries.Add(new CokerCardCycleStepEntry(
                null, configuration.Drums[0].IdValue, -10,
                new TimeEntry(new Time(6), -999, null),
                new TimeEntry(new Time(7), -999, null)));

            CokerCardHistory history = cokerCard.TakeSnapshot(configuration, previousEntries);
            Assert.AreEqual(3 + configuration.Steps.Count, history.DrumEntryHistories[0].CycleStepHistory.Count);
            Assert.IsTrue(history.DrumEntryHistories[0].CycleStepHistory.Exists(obj => 
                obj.StartTime == new Time(1) &&
                obj.EndTime == new Time(2) &&
                obj.CycleStepName == configuration.Steps[0].Name));
            Assert.IsTrue(history.DrumEntryHistories[0].CycleStepHistory.Exists(obj =>
                obj.StartTime == new Time(3) &&
                obj.EndTime == null &&
                obj.CycleStepName == configuration.Steps[0].Name));
            Assert.IsFalse(history.DrumEntryHistories[0].CycleStepHistory.Exists(obj =>
                obj.StartTime == new Time(4) &&
                obj.EndTime == new Time(5)));
            Assert.IsTrue(history.DrumEntryHistories[0].CycleStepHistory.Exists(obj =>
                obj.StartTime == new Time(6) &&
                obj.EndTime == new Time(7) &&
                obj.CycleStepName == ""));

        }
    }
}