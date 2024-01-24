using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Wcf;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Services
{
    [TestFixture]
    [Category("Integration")]
    public class CokerCardServiceClientTest
    {
        private ICokerCardService cokerCardService;

        private CokerCardConfiguration configuration1;

        private CokerCardConfigurationDrum drum1;
        private CokerCardConfigurationDrum drum2;
        private CokerCardConfigurationDrum drum3;
        private CokerCardConfigurationDrum drum4;
        private IShiftPatternService shiftPatternService;

        private CokerCardConfigurationCycleStep step1;
        private CokerCardConfigurationCycleStep step2;
        private CokerCardConfigurationCycleStep step3;
        private CokerCardConfigurationCycleStep step4;
        private WorkAssignment workAssignment;
        private IWorkAssignmentService workAssignmentService;


        [SetUp]
        public void SetUp()
        {
            cokerCardService = GenericServiceRegistry.Instance.GetService<ICokerCardService>();
            workAssignmentService = GenericServiceRegistry.Instance.GetService<IWorkAssignmentService>();
            workAssignment =
                workAssignmentService.QueryBySite(SiteFixture.Oilsands()).Find(wa => wa.Name.StartsWith("UP1 - Coker"));

            shiftPatternService = GenericServiceRegistry.Instance.GetService<IShiftPatternService>();

            var configurations = cokerCardService.QueryCokerCardConfigurationsBySite(SiteFixture.Oilsands());
            configuration1 = configurations.Find(obj => obj.Name.Contains("UP1"));

            drum1 = configuration1.Drums[0];
            drum2 = configuration1.Drums[1];
            drum3 = configuration1.Drums[2];
            drum4 = configuration1.Drums[3];

            step1 = configuration1.Steps[0];
            step2 = configuration1.Steps[1];
            step3 = configuration1.Steps[2];
            step4 = configuration1.Steps[3];
        }

        [Test][Ignore]
        public void ShouldRemoveAndDeleteEndTimeFromOverlappingCycleStep()
        {
            var shifts = shiftPatternService.QueryBySite(SiteFixture.Oilsands());

            var dayShift = shifts.Find(s => s.Name == "D");
            var nightShift = shifts.Find(s => s.Name == "N");

            var shiftStartDate = new Date(2011, 6, 10);

            var userDayShift = new UserShift(dayShift, shiftStartDate); // Day Shift: 8am to 8pm
            var userNightShift = new UserShift(nightShift, shiftStartDate); // Night Shift: 8pm to 8am

            CokerCard card1 = null;
            CokerCard card2 = null;

            // Card 1, shift 1. The end time for the second cycle is in the next shift.
            {
                var cardToInsert1 = CokerCardFixture.CreateForInsert(
                    configuration1, configuration1.FunctionalLocation, workAssignment, dayShift, shiftStartDate);

                cardToInsert1.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                    null, drum1.IdValue, step1.IdValue,
                    new TimeEntry(new Time(12, 0, 0), dayShift.IdValue, shiftStartDate),
                    new TimeEntry(new Time(13, 0, 0), dayShift.IdValue, shiftStartDate)));
                cardToInsert1.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                    null, drum1.IdValue, step2.IdValue,
                    new TimeEntry(new Time(17, 30, 0), dayShift.IdValue, shiftStartDate),
                    new TimeEntry(new Time(20, 30, 0), nightShift.IdValue, shiftStartDate)));

                card1 = InsertCokerCard(cardToInsert1);
            }

            // Card 2, shift 1. This card will be deleted, which should clear the end time above that overlaps into this shift.
            {
                var cardToInsert2 = CokerCardFixture.CreateForInsert(
                    configuration1, configuration1.FunctionalLocation, workAssignment, nightShift, shiftStartDate);

                cardToInsert2.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                    null, drum1.IdValue, step3.IdValue,
                    new TimeEntry(new Time(21, 0, 0), nightShift.IdValue, shiftStartDate),
                    new TimeEntry(new Time(21, 15, 0), nightShift.IdValue, shiftStartDate)));
                cardToInsert2.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                    null, drum1.IdValue, step4.IdValue,
                    new TimeEntry(new Time(22, 30, 0), nightShift.IdValue, shiftStartDate),
                    new TimeEntry(new Time(22, 42, 0), nightShift.IdValue, shiftStartDate)));

                card2 = InsertCokerCard(cardToInsert2);
            }


            Assert.IsNotNull(card1.Id);
            Assert.IsNotNull(card2.Id);

            // Sanity check: make sure they base shifts are in.
            {
                var returnedCard1 = cokerCardService.QueryCokerCardByConfigurationAndShift(configuration1.IdValue,
                    userDayShift);
                var returnedCard2 = cokerCardService.QueryCokerCardByConfigurationAndShift(configuration1.IdValue,
                    userNightShift);

                Assert.IsNotNull(returnedCard1);
                Assert.IsNotNull(returnedCard2);
            }

            cokerCardService.Remove(card2);

            {
                var dayShiftCard = cokerCardService.QueryCokerCardByConfigurationAndShift(configuration1.IdValue,
                    userDayShift);

                var dayShiftStep1Entry = dayShiftCard.CycleStepEntries.Find(entry => entry.CycleStepId == step1.IdValue);
                var dayShiftStep2Entry = dayShiftCard.CycleStepEntries.Find(entry => entry.CycleStepId == step2.IdValue);

                // These are the important assertions
                Assert.IsNull(dayShiftStep2Entry.EndEntry);
                Assert.IsNotNull(dayShiftStep1Entry.EndEntry);
            }

            {
                // Might as well check that the night shift card is gone
                var nightShiftCard = cokerCardService.QueryCokerCardByConfigurationAndShift(configuration1.IdValue,
                    userNightShift);

                if (nightShiftCard != null)
                {
                    Assert.AreNotEqual(card1.IdValue, nightShiftCard.IdValue);
                }
            }
        }

        private CokerCard InsertCokerCard(CokerCard card)
        {
            var notifiedEvents = cokerCardService.Insert(card, new List<CokerCardCycleStepEntry>());
            return (CokerCard) notifiedEvents[0].DomainObject;
        }
    }
}