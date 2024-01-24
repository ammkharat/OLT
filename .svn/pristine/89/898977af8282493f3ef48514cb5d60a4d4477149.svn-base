using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture]
    [Category("Database")]
    public class CokerCardCycleStepEntryDTODaoTest : AbstractDaoTest
    {
        private ICokerCardCycleStepEntryDTODao dtoDao;
        private ICokerCardDao cokerCardDao;        
        private CokerCardConfiguration up1Configuration;
        private CokerCardConfiguration up2Configuration;

        protected override void TestInitialize()
        {
            Clock.Freeze();
            dtoDao = DaoRegistry.GetDao<ICokerCardCycleStepEntryDTODao>();
            cokerCardDao = DaoRegistry.GetDao<ICokerCardDao>();            

            ICokerCardConfigurationDao configurationDao = DaoRegistry.GetDao<ICokerCardConfigurationDao>();

            List<CokerCardConfiguration> configurations = configurationDao.QueryCokerCardConfigurationsBySite(SiteFixture.Oilsands().IdValue);
            
            // Coker Card Configuration for UP1
            up1Configuration = configurations.Find(obj => obj.FunctionalLocation.Id == FunctionalLocationFixture.GetReal_UP1().Id);

            // Coker Card Configuration for UP2
            up2Configuration = configurations.Find(obj => obj.FunctionalLocation.Id == FunctionalLocationFixture.GetReal_UP2().Id);
        }

        protected override void Cleanup()
        {
            Clock.UnFreeze();
        }

        [Ignore] [Test]
        public void ShouldQueryByConfigurationIdsAndDateRange()
        {
            CokerCardConfigurationDrum drum1 = up1Configuration.Drums[0];
            CokerCardConfigurationDrum drum2 = up1Configuration.Drums[1];            

            CokerCardConfigurationCycleStep step1 = up1Configuration.Steps[0];
            CokerCardConfigurationCycleStep step2 = up1Configuration.Steps[1];            

            ShiftPattern dayShift = ShiftPatternFixture.CreateDayShift();

            CokerCard cokerCard1 = CokerCardFixture.CreateForInsert(
                up1Configuration, WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(), 
                dayShift, new Date(2011, 6, 10));

            cokerCard1.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                null, drum1.IdValue, step1.IdValue, 
                new TimeEntry(new Time(8, 0, 0), cokerCard1.Shift.IdValue, cokerCard1.ShiftStartDate), 
                new TimeEntry(new Time(9, 0, 0), cokerCard1.Shift.IdValue, cokerCard1.ShiftStartDate)));

            cokerCard1.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                null, drum2.IdValue, step2.IdValue,
                new TimeEntry(new Time(8, 15, 0), cokerCard1.Shift.IdValue, cokerCard1.ShiftStartDate),
                new TimeEntry(new Time(9, 15, 0), cokerCard1.Shift.IdValue, cokerCard1.ShiftStartDate)));

            cokerCard1.DrumEntries.Add(new CokerCardDrumEntry(null, drum1.IdValue, null, null, "Drum 1 Comment"));
            cokerCard1.DrumEntries.Add(new CokerCardDrumEntry(null, drum2.IdValue, null, null, "Drum 2 Comment"));

            CokerCard insertedCard = cokerCardDao.Insert(cokerCard1, new List<CokerCardCycleStepEntry>());

            Assert.IsNotNull(cokerCard1);

            List<CokerCardCycleStepEntryDTO> dtoList =
                dtoDao.QueryByConfigurationIdsAndDateRange(new List<long>{ up1Configuration.IdValue }, new Date(2011, 6, 10), new Date(2011, 6, 10));

            Assert.IsTrue(dtoList.Count >= cokerCard1.CycleStepEntries.Count);

            Assert.IsTrue(insertedCard.CycleStepEntries.Count == 2); 

            {
                CokerCardCycleStepEntry entry = insertedCard.CycleStepEntries[0];
                CokerCardCycleStepEntryDTO entryDto = dtoList.Find(d => d.IdValue == entry.IdValue);
                Assert.IsNotNull(entryDto);

                AssertDTO(drum1, step1, new Time(8, 0, 0), new Time(9, 0, 0), insertedCard.Shift.Name, cokerCard1.ShiftStartDate, "Drum 1 Comment", entryDto);               
            }              
  
            {
                CokerCardCycleStepEntry entry = insertedCard.CycleStepEntries[1];
                CokerCardCycleStepEntryDTO entryDto = dtoList.Find(d => d.IdValue == entry.IdValue);
                Assert.IsNotNull(entryDto);

                AssertDTO(drum2, step2, new Time(8, 15, 0), new Time(9, 15, 0), insertedCard.Shift.Name, cokerCard1.ShiftStartDate, "Drum 2 Comment", entryDto);
            }              
        }

        [Ignore] [Test]
        public void ShouldQueryByConfigurationAndDateRangeAndNotReturnRemovedEntries()
        {
            CokerCardConfigurationDrum drum1 = up1Configuration.Drums[0];
            CokerCardConfigurationDrum drum2 = up1Configuration.Drums[1];

            CokerCardConfigurationCycleStep step1 = up1Configuration.Steps[0];
            CokerCardConfigurationCycleStep step2 = up1Configuration.Steps[1];

            ShiftPattern dayShift = ShiftPatternFixture.CreateDayShift();

            CokerCard cokerCard1 = CokerCardFixture.CreateForInsert(
                up1Configuration, WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(),
                dayShift, new Date(2011, 6, 10));

            cokerCard1.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                null, drum1.IdValue, step1.IdValue,
                new TimeEntry(new Time(8, 0, 0), cokerCard1.Shift.IdValue, cokerCard1.ShiftStartDate),
                new TimeEntry(new Time(9, 0, 0), cokerCard1.Shift.IdValue, cokerCard1.ShiftStartDate)));

            cokerCard1.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                null, drum2.IdValue, step2.IdValue,
                new TimeEntry(new Time(8, 15, 0), cokerCard1.Shift.IdValue, cokerCard1.ShiftStartDate),
                new TimeEntry(new Time(9, 15, 0), cokerCard1.Shift.IdValue, cokerCard1.ShiftStartDate)));

            cokerCard1.DrumEntries.Add(new CokerCardDrumEntry(null, drum1.IdValue, null, null, "Drum 1 Comment"));
            cokerCard1.DrumEntries.Add(new CokerCardDrumEntry(null, drum2.IdValue, null, null, "Drum 2 Comment"));

            CokerCard insertedCard = cokerCardDao.Insert(cokerCard1, new List<CokerCardCycleStepEntry>());

            Assert.AreEqual(2, insertedCard.CycleStepEntries.Count);

            cokerCardDao.Remove(insertedCard);

            List<CokerCardCycleStepEntryDTO> dtoList =
                dtoDao.QueryByConfigurationIdsAndDateRange(new List<long> { up1Configuration.IdValue }, new Date(2011, 6, 10), new Date(2011, 6, 10));
            
            Assert.AreEqual(0, dtoList.Count);           
        }

        [Ignore] [Test]
        public void ShouldQueryByConfigurationAndDateRange_StartDateInRange()
        {
            CokerCardConfigurationDrum drum1 = up1Configuration.Drums[0];
            CokerCardConfigurationDrum drum2 = up1Configuration.Drums[1];
            CokerCardConfigurationDrum drum3 = up1Configuration.Drums[2];

            CokerCardConfigurationCycleStep step1 = up1Configuration.Steps[0];
            CokerCardConfigurationCycleStep step2 = up1Configuration.Steps[1];

            ShiftPattern dayShift = ShiftPatternFixture.CreateDayShift();

            CokerCard cokerCard1 = null;
            {
                cokerCard1 = CokerCardFixture.CreateForInsert(
                    up1Configuration, WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(),
                    dayShift, new Date(2011, 6, 10));

                cokerCard1.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                    null, drum1.IdValue, step1.IdValue,
                    new TimeEntry(new Time(8, 0, 0), cokerCard1.Shift.IdValue, cokerCard1.ShiftStartDate),
                    new TimeEntry(new Time(9, 0, 0), cokerCard1.Shift.IdValue, cokerCard1.ShiftStartDate)));

                cokerCard1.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                    null, drum2.IdValue, step2.IdValue,
                    new TimeEntry(new Time(8, 15, 0), cokerCard1.Shift.IdValue, cokerCard1.ShiftStartDate),
                    new TimeEntry(new Time(9, 15, 0), cokerCard1.Shift.IdValue, cokerCard1.ShiftStartDate)));

                cokerCard1.DrumEntries.Add(new CokerCardDrumEntry(null, drum1.IdValue, null, null, "Drum 1 Comment"));
                cokerCard1.DrumEntries.Add(new CokerCardDrumEntry(null, drum2.IdValue, null, null, "Drum 2 Comment"));
            }

            CokerCard cokerCard2 = null;
            {
                cokerCard2 = CokerCardFixture.CreateForInsert(
                    up1Configuration, WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(),
                    dayShift, new Date(2011, 6, 11));

                cokerCard2.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                    null, drum3.IdValue, step1.IdValue,
                    new TimeEntry(new Time(8, 0, 0), cokerCard2.Shift.IdValue, cokerCard2.ShiftStartDate),
                    new TimeEntry(new Time(9, 0, 0), cokerCard2.Shift.IdValue, cokerCard2.ShiftStartDate)));

                cokerCard2.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                    null, drum3.IdValue, step2.IdValue,
                    new TimeEntry(new Time(8, 15, 0), cokerCard2.Shift.IdValue, cokerCard2.ShiftStartDate),
                    new TimeEntry(new Time(9, 15, 0), cokerCard2.Shift.IdValue, cokerCard2.ShiftStartDate)));

                cokerCard2.DrumEntries.Add(new CokerCardDrumEntry(null, drum1.IdValue, null, null, "Drum 1 Comment"));
                cokerCard2.DrumEntries.Add(new CokerCardDrumEntry(null, drum2.IdValue, null, null, "Drum 2 Comment"));
            }

            cokerCardDao.Insert(cokerCard1, new List<CokerCardCycleStepEntry>());
            cokerCardDao.Insert(cokerCard2, new List<CokerCardCycleStepEntry>());
            
            List<CokerCardCycleStepEntryDTO> dtoList =
                dtoDao.QueryByConfigurationIdsAndDateRange(new List<long> { up1Configuration.IdValue }, new Date(2011, 6, 5), new Date(2011, 6, 10));

            Assert.IsTrue(dtoList.Count == 2);

            // Just using drum to check that the right one came back
            CokerCardCycleStepEntryDTO entry1 = dtoList.Find(d => d.Drum == drum1.Name);
            Assert.IsNotNull(entry1);
            CokerCardCycleStepEntryDTO entry2 = dtoList.Find(d => d.Drum == drum2.Name);
            Assert.IsNotNull(entry2);                   
        }
  
        [Ignore] [Test]
        public void ShouldQueryByConfigurationAndDateRange_EndDateInRange()
        {
            CokerCardConfigurationDrum drum1 = up1Configuration.Drums[0];
            CokerCardConfigurationDrum drum2 = up1Configuration.Drums[1];
            CokerCardConfigurationDrum drum3 = up1Configuration.Drums[2];

            CokerCardConfigurationCycleStep step1 = up1Configuration.Steps[0];
            CokerCardConfigurationCycleStep step2 = up1Configuration.Steps[1];

            ShiftPattern dayShift = ShiftPatternFixture.CreateDayShift();

            CokerCard cokerCard1 = null;
            {
                cokerCard1 = CokerCardFixture.CreateForInsert(
                    up1Configuration, WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(),
                    dayShift, new Date(2011, 6, 11));

                cokerCard1.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                    null, drum1.IdValue, step1.IdValue,
                    new TimeEntry(new Time(8, 0, 0), cokerCard1.Shift.IdValue, cokerCard1.ShiftStartDate),
                    new TimeEntry(new Time(9, 0, 0), cokerCard1.Shift.IdValue, cokerCard1.ShiftStartDate)));

                cokerCard1.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                    null, drum2.IdValue, step2.IdValue,
                    new TimeEntry(new Time(8, 15, 0), cokerCard1.Shift.IdValue, cokerCard1.ShiftStartDate),
                    new TimeEntry(new Time(9, 15, 0), cokerCard1.Shift.IdValue, cokerCard1.ShiftStartDate)));
                
                cokerCard1.DrumEntries.Add(new CokerCardDrumEntry(null, drum1.IdValue, null, null, "Drum 1 Comment"));
                cokerCard1.DrumEntries.Add(new CokerCardDrumEntry(null, drum2.IdValue, null, null, "Drum 2 Comment"));
            }

            CokerCard cokerCard2 = null;
            {
                cokerCard2 = CokerCardFixture.CreateForInsert(
                    up1Configuration, WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(),
                    dayShift, new Date(2011, 6, 10));

                cokerCard2.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                    null, drum3.IdValue, step1.IdValue,
                    new TimeEntry(new Time(8, 0, 0), cokerCard2.Shift.IdValue, cokerCard2.ShiftStartDate),
                    new TimeEntry(new Time(9, 0, 0), cokerCard2.Shift.IdValue, cokerCard2.ShiftStartDate)));

                cokerCard2.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                    null, drum3.IdValue, step2.IdValue,
                    new TimeEntry(new Time(8, 15, 0), cokerCard2.Shift.IdValue, cokerCard2.ShiftStartDate),
                    new TimeEntry(new Time(9, 15, 0), cokerCard2.Shift.IdValue, cokerCard2.ShiftStartDate)));

                cokerCard2.DrumEntries.Add(new CokerCardDrumEntry(null, drum3.IdValue, null, null, "Drum 3 Comment"));
//                cokerCard2.DrumEntries.Add(new CokerCardDrumEntry(null, drum2.IdValue, null, null, "Drum 2 Comment"));
            }

            cokerCardDao.Insert(cokerCard1, new List<CokerCardCycleStepEntry>());
            cokerCardDao.Insert(cokerCard2, new List<CokerCardCycleStepEntry>());

            List<CokerCardCycleStepEntryDTO> dtoList =
                dtoDao.QueryByConfigurationIdsAndDateRange(new List<long> { up1Configuration.IdValue }, new Date(2011, 6, 11), new Date(2011, 6, 17));

            Assert.IsTrue(dtoList.Count == 2);

            // Just using drum to check that the right one came back
            CokerCardCycleStepEntryDTO entry1 = dtoList.Find(d => d.Drum == drum1.Name);
            Assert.IsNotNull(entry1);
            CokerCardCycleStepEntryDTO entry2 = dtoList.Find(d => d.Drum == drum2.Name);
            Assert.IsNotNull(entry2);
        }

        [Ignore] [Test]
        public void ShouldQueryByConfigurationAndDateRange_NullEndDate()
        {
            CokerCardConfigurationDrum drum1 = up1Configuration.Drums[0];
            CokerCardConfigurationDrum drum2 = up1Configuration.Drums[1];
            CokerCardConfigurationDrum drum3 = up1Configuration.Drums[2];
            CokerCardConfigurationDrum drum4 = up1Configuration.Drums[3];

            CokerCardConfigurationCycleStep step1 = up1Configuration.Steps[0];
            CokerCardConfigurationCycleStep step2 = up1Configuration.Steps[1];

            ShiftPattern dayShift = ShiftPatternFixture.CreateDayShift();

            CokerCard cokerCard1 = null;
            {
                cokerCard1 = CokerCardFixture.CreateForInsert(
                    up1Configuration, WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(),
                    dayShift, new Date(2011, 6, 10));

                cokerCard1.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                    null, drum1.IdValue, step1.IdValue,
                    new TimeEntry(new Time(8, 0, 0), cokerCard1.Shift.IdValue, cokerCard1.ShiftStartDate),
                    null));

                cokerCard1.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                    null, drum2.IdValue, step2.IdValue,
                    new TimeEntry(new Time(8, 15, 0), cokerCard1.Shift.IdValue, cokerCard1.ShiftStartDate),
                    null));

                cokerCard1.DrumEntries.Add(new CokerCardDrumEntry(null, drum1.IdValue, null, null, "Drum 1 Comment"));
                cokerCard1.DrumEntries.Add(new CokerCardDrumEntry(null, drum2.IdValue, null, null, "Drum 2 Comment"));
            }

            CokerCard cokerCard2 = null;
            {
                cokerCard2 = CokerCardFixture.CreateForInsert(
                    up1Configuration, WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(),
                    dayShift, new Date(2011, 6, 11));

                cokerCard2.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                    null, drum3.IdValue, step1.IdValue,
                    new TimeEntry(new Time(8, 0, 0), cokerCard2.Shift.IdValue, cokerCard2.ShiftStartDate),
                    null));

                cokerCard2.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                    null, drum4.IdValue, step2.IdValue,
                    new TimeEntry(new Time(8, 15, 0), cokerCard2.Shift.IdValue, cokerCard2.ShiftStartDate),
                    null));

                cokerCard2.DrumEntries.Add(new CokerCardDrumEntry(null, drum3.IdValue, null, null, "Drum 3 Comment"));
                cokerCard2.DrumEntries.Add(new CokerCardDrumEntry(null, drum4.IdValue, null, null, "Drum 4 Comment"));
            }

            cokerCardDao.Insert(cokerCard1, new List<CokerCardCycleStepEntry>());
            cokerCardDao.Insert(cokerCard2, new List<CokerCardCycleStepEntry>());

            {
                List<CokerCardCycleStepEntryDTO> dtoList =
                    dtoDao.QueryByConfigurationIdsAndDateRange(new List<long> { up1Configuration.IdValue }, new Date(2011, 6, 12), new Date(2011, 6, 15));

                Assert.IsTrue(dtoList.Count == 0);
            }

            {
                List<CokerCardCycleStepEntryDTO> dtoList =
                    dtoDao.QueryByConfigurationIdsAndDateRange(new List<long> { up1Configuration.IdValue }, new Date(2011, 6, 5), new Date(2011, 6, 10));

                Assert.IsTrue(dtoList.Count == 2);

                // Just using drum to check that the right one came back
                CokerCardCycleStepEntryDTO entry1 = dtoList.Find(d => d.Drum == drum1.Name);
                Assert.IsNotNull(entry1);
                CokerCardCycleStepEntryDTO entry2 = dtoList.Find(d => d.Drum == drum2.Name);
                Assert.IsNotNull(entry2);
            }

            {
                List<CokerCardCycleStepEntryDTO> dtoList =
                    dtoDao.QueryByConfigurationIdsAndDateRange(new List<long> { up1Configuration.IdValue }, new Date(2011, 6, 11), new Date(2011, 6, 17));

                Assert.IsTrue(dtoList.Count != 0);
                Assert.IsTrue(dtoList.Count == 2);

                // Just using drum to check that the right one came back
                CokerCardCycleStepEntryDTO entry1 = dtoList.Find(d => d.Drum == drum3.Name);
                Assert.IsNotNull(entry1);
                CokerCardCycleStepEntryDTO entry2 = dtoList.Find(d => d.Drum == drum4.Name);
                Assert.IsNotNull(entry2);
            }

            {
                List<CokerCardCycleStepEntryDTO> dtoList =
                    dtoDao.QueryByConfigurationIdsAndDateRange(new List<long> { up1Configuration.IdValue }, new Date(2011, 6, 5), new Date(2011, 6, 17));

                Assert.IsTrue(dtoList.Count == 4);
            }
        }

        //[Ignore] [Test]
        //Test("Failing for some reason.")]
        //public void QueryByConfigurationAndDateRangeReturnsRowsForSelectedConfigurationOnly()
        //{
        //    CokerCardConfigurationDrum up1Drum1 = up1Configuration.Drums[0];
        //    CokerCardConfigurationDrum up1Drum2 = up1Configuration.Drums[1];

        //    CokerCardConfigurationCycleStep up1Step1 = up1Configuration.Steps[0];
        //    CokerCardConfigurationCycleStep up1Step2 = up1Configuration.Steps[1];

        //    ShiftPattern dayShift = ShiftPatternFixture.CreateDayShift();
        //    Date shiftStartDate = new Date(2012, 1, 5);

        //    // Set up Coker Card 1 with Configuration UP1   
        //    CokerCard up1CokerCard = CokerCardFixture.CreateForInsert(
        //    up1Configuration, WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(),
        //    dayShift, shiftStartDate);

        //    up1CokerCard.CycleStepEntries.Add(new CokerCardCycleStepEntry(
        //        null, up1Drum1.IdValue, up1Step1.IdValue,
        //        new TimeEntry(new Time(8, 0, 0), up1CokerCard.Shift.IdValue, up1CokerCard.ShiftStartDate),
        //        new TimeEntry(new Time(9, 0, 0), up1CokerCard.Shift.IdValue, up1CokerCard.ShiftStartDate)));

        //    up1CokerCard.CycleStepEntries.Add(new CokerCardCycleStepEntry(
        //        null, up1Drum2.IdValue, up1Step2.IdValue,
        //        new TimeEntry(new Time(8, 15, 0), up1CokerCard.Shift.IdValue, up1CokerCard.ShiftStartDate),
        //        new TimeEntry(new Time(9, 15, 0), up1CokerCard.Shift.IdValue, up1CokerCard.ShiftStartDate)));

        //    const string UP1_DRUM_1_COMMENT = "UP1 Drum 1 Comment";
        //    const string UP1_DRUM_2_COMMENT = "UP1 Drum 2 Comment";

        //    up1CokerCard.DrumEntries.Add(new CokerCardDrumEntry(null, up1Drum1.IdValue, null, null, UP1_DRUM_1_COMMENT));
        //    up1CokerCard.DrumEntries.Add(new CokerCardDrumEntry(null, up1Drum2.IdValue, null, null, UP1_DRUM_2_COMMENT));
            
        //    cokerCardDao.Insert(up1CokerCard, new List<CokerCardCycleStepEntry>());
            
        //    // Set up Coker Card 2 with Configuration UP2   
        //    CokerCardConfigurationDrum up2Drum1 = up2Configuration.Drums[0];
        //    CokerCardConfigurationDrum up2Drum2 = up2Configuration.Drums[1];

        //    CokerCardConfigurationCycleStep up2Step1 = up2Configuration.Steps[0];
        //    CokerCardConfigurationCycleStep up2Step2 = up2Configuration.Steps[1];

        //    CokerCard up2CokerCard = CokerCardFixture.CreateForInsert(
        //    up2Configuration, WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(),
        //    dayShift, shiftStartDate);

        //    up2CokerCard.CycleStepEntries.Add(new CokerCardCycleStepEntry(
        //        null, up2Drum1.IdValue, up2Step1.IdValue,
        //        new TimeEntry(new Time(8, 0, 0), up2CokerCard.Shift.IdValue, up2CokerCard.ShiftStartDate),
        //        new TimeEntry(new Time(9, 0, 0), up2CokerCard.Shift.IdValue, up2CokerCard.ShiftStartDate)));

        //    up2CokerCard.CycleStepEntries.Add(new CokerCardCycleStepEntry(
        //        null, up2Drum2.IdValue, up2Step2.IdValue,
        //        new TimeEntry(new Time(8, 15, 0), up2CokerCard.Shift.IdValue, up2CokerCard.ShiftStartDate),
        //        new TimeEntry(new Time(9, 15, 0), up2CokerCard.Shift.IdValue, up2CokerCard.ShiftStartDate)));

        //    up2CokerCard.DrumEntries.Add(new CokerCardDrumEntry(null, up2Drum1.IdValue, null, null, "UP2 Drum 1 Comment"));
        //    up2CokerCard.DrumEntries.Add(new CokerCardDrumEntry(null, up2Drum2.IdValue, null, null, "UP2 Drum 2 Comment"));

        //    cokerCardDao.Insert(up2CokerCard, new List<CokerCardCycleStepEntry>());
            
        //    // Run QueryByConfigurationIdsAndDateRange for Configuration UP1
        //    List<CokerCardCycleStepEntryDTO> dtoListForUP1 =
        //        dtoDao.QueryByConfigurationIdsAndDateRange(new List<long> {up1Configuration.IdValue},
        //                                                   new Date(2012, 1, 4), new Date(2012, 1, 6));

        //    // Ensure only entires for Configuration UP1 are returned
        //    Assert.AreEqual(2, dtoListForUP1.Count);
        //    Assert.AreEqual(UP1_DRUM_1_COMMENT, dtoListForUP1[0].Comment);
        //    Assert.AreEqual(UP1_DRUM_2_COMMENT, dtoListForUP1[1].Comment);
        //}

        private static void AssertDTO(CokerCardConfigurationDrum drum, CokerCardConfigurationCycleStep step, Time startTime,
                               Time endTime, string shiftName, Date shiftStartDate, string comment, CokerCardCycleStepEntryDTO entryDto)
        {
            Assert.AreEqual(drum.Name, entryDto.Drum);
            Assert.AreEqual(step.Name, entryDto.Cycle);
                        
            Assert.AreEqual(startTime.Hour, entryDto.Start.Hour);
            Assert.AreEqual(startTime.Minute, entryDto.Start.Minute);
            Assert.AreEqual(startTime.Second, entryDto.Start.Second);

            Assert.AreEqual(endTime.Hour, entryDto.End.Value.Hour);
            Assert.AreEqual(endTime.Minute, entryDto.End.Value.Minute);
            Assert.AreEqual(endTime.Second, entryDto.End.Value.Second);
            
            Assert.AreEqual(shiftName, entryDto.ShiftName);
            
            Assert.AreEqual(shiftStartDate.Year, entryDto.ShiftStartDate.Year);
            Assert.AreEqual(shiftStartDate.Month, entryDto.ShiftStartDate.Month);
            Assert.AreEqual(shiftStartDate.Day, entryDto.ShiftStartDate.Day);

            Assert.AreEqual(comment, entryDto.Comment);
        }
    }
}
