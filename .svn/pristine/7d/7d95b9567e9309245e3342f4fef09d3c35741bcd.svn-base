using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class CokerCardDaoTest : AbstractDaoTest
    {
        private ICokerCardDao dao;
        private ICokerCardConfigurationDao configurationDao;
        private CokerCardConfiguration configuration1;
        private CokerCardConfiguration configuration2;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ICokerCardDao>();

            configurationDao = DaoRegistry.GetDao<ICokerCardConfigurationDao>();

            List<CokerCardConfiguration> configurations = configurationDao.QueryCokerCardConfigurationsBySite(SiteFixture.Oilsands().IdValue);
            configuration1 = configurations.Find(obj => obj.FunctionalLocation.Id == FunctionalLocationFixture.GetReal_UP1().Id);
            configuration2 = configurations.Find(obj => obj.FunctionalLocation.Id == FunctionalLocationFixture.GetReal_UP2().Id);
        }

        protected override void Cleanup()
        {
        }

        private static CokerCard CreateForInsert(WorkAssignment workAssignment, CokerCardConfiguration configuration)
        {
            return CokerCardFixture.CreateForInsert(
                configuration, workAssignment, ShiftPatternFixture.CreateDayShift(), new Date(2011, 6, 10));
        }

        private CokerCard CreateForInsert(ShiftPattern shift, Date date)
        {
            return CokerCardFixture.CreateForInsert(
                configuration1, WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(), shift, date);
        }

        [Ignore] [Test]
        public void ShouldInsert()
        {
            CokerCard card = CreateForInsert(WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(), configuration1);
            CokerCard saved = dao.Insert(card, new List<CokerCardCycleStepEntry>());

            CokerCard requeried = dao.QueryById(saved.IdValue);
            Assert.IsNotNull(requeried);

            Assert.AreEqual(configuration1.IdValue, requeried.ConfigurationId);
            Assert.AreEqual(configuration1.Name, requeried.ConfigurationName);
            Assert.AreEqual(FunctionalLocationFixture.GetReal_UP1().Id, requeried.FunctionalLocation.Id);
            Assert.AreEqual(WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData().Id, requeried.WorkAssignment.Id);

            Assert.AreEqual(ShiftPatternFixture.CreateDayShift().Id, requeried.Shift.Id);
            Assert.AreEqual(new Date(2011, 6, 10), requeried.ShiftStartDate);
            Assert.AreEqual(UserFixture.CreateOperatorGoofyInFortMcMurrySite().Id, requeried.CreatedBy.Id);
            Assert.AreEqual(new DateTime(2011, 5, 9), requeried.CreatedDateTime);
            Assert.AreEqual(UserFixture.CreateEngineeringSupport().Id, requeried.LastModifiedBy.Id);
            Assert.AreEqual(new DateTime(2011, 7, 19), requeried.LastModifiedDate);
        }

        [Ignore] [Test]
        public void ShouldInsertNullWorkAssignment()
        {
            CokerCard card = CreateForInsert(null, configuration1);
            CokerCard saved = dao.Insert(card, new List<CokerCardCycleStepEntry>());

            CokerCard requeried = dao.QueryById(saved.IdValue);
            Assert.IsNotNull(requeried);

            Assert.IsNull(requeried.WorkAssignment);
        }

        [Ignore] [Test]
        public void ShouldUpdate()
        {
            CokerCard card = CreateForInsert(WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(), configuration1);
            card.LastModifiedBy = UserFixture.CreateEngineeringSupport();
            card.LastModifiedDate = new DateTime(2001, 1, 20);
            card = dao.Insert(card, new List<CokerCardCycleStepEntry>());
            long id = card.IdValue;

            {
                CokerCard requeried = dao.QueryById(id);
                Assert.IsNotNull(requeried);

                requeried.LastModifiedBy = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
                requeried.LastModifiedDate = new DateTime(2001, 5, 12);

                dao.Update(requeried, new List<CokerCardCycleStepEntry>());
            }
            {
                CokerCard requeried = dao.QueryById(id);
                Assert.IsNotNull(requeried);

                Assert.AreEqual(UserFixture.CreateOperatorGoofyInFortMcMurrySite().Id, requeried.LastModifiedBy.Id);
                Assert.AreEqual(new DateTime(2001, 5, 12), requeried.LastModifiedDate);
            }
        }

        [Ignore] [Test]
        public void ShouldDelete()
        {
            CokerCard card = CreateForInsert(WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(), configuration1);
            card.LastModifiedBy = UserFixture.CreateEngineeringSupport();
            card.LastModifiedDate = new DateTime(2001, 1, 20);
            card = dao.Insert(card, new List<CokerCardCycleStepEntry>());
            long id = card.IdValue;

            {
                CokerCard requeried = dao.QueryById(id);
                Assert.IsNotNull(requeried);
                Assert.IsFalse(requeried.Deleted);

                requeried.LastModifiedBy = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
                requeried.LastModifiedDate = new DateTime(2001, 5, 12);

                dao.Remove(requeried);
            }
            {
                CokerCard requeried = dao.QueryById(id);
                Assert.IsNotNull(requeried);

                Assert.IsTrue(requeried.Deleted);
                Assert.AreEqual(UserFixture.CreateOperatorGoofyInFortMcMurrySite().Id, requeried.LastModifiedBy.Id);
                Assert.AreEqual(new DateTime(2001, 5, 12), requeried.LastModifiedDate);
            }
        }

        [Ignore] [Test]
        public void ShouldInsertAndUpdateCycleStepEntries()
        {
            CokerCardConfigurationDrum drum1 = configuration1.Drums[0];
            CokerCardConfigurationDrum drum2 = configuration1.Drums[1];
            CokerCardConfigurationDrum drum3 = configuration1.Drums[2];

            CokerCardConfigurationCycleStep step1 = configuration1.Steps[0];
            CokerCardConfigurationCycleStep step2 = configuration1.Steps[1];
            CokerCardConfigurationCycleStep step3 = configuration1.Steps[2];

            CokerCard card = CreateForInsert(WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(), configuration1);
            card.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                null, drum1.IdValue, step1.IdValue, 
                new TimeEntry(new Time(12, 0, 0), card.Shift.IdValue, card.ShiftStartDate), 
                new TimeEntry(new Time(13, 0, 0), card.Shift.IdValue, card.ShiftStartDate)));
            card.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                null, drum2.IdValue, step2.IdValue,
                new TimeEntry(new Time(8, 0, 0), card.Shift.IdValue, card.ShiftStartDate),
                new TimeEntry(new Time(9, 0, 0), card.Shift.IdValue, card.ShiftStartDate)));
            card = dao.Insert(card, new List<CokerCardCycleStepEntry>());

            {
                CokerCard requeried = dao.QueryById(card.IdValue);
                Assert.AreEqual(2, requeried.CycleStepEntries.Count);
                {
                    CokerCardCycleStepEntry entry = requeried.CycleStepEntries.Find(obj => obj.CycleStepId == step1.IdValue);
                    Assert.AreEqual(drum1.IdValue, entry.DrumId);
                    Assert.AreEqual(new Time(12, 0, 0), entry.StartEntry.Time);
                    Assert.AreEqual(new Time(13, 0, 0), entry.EndEntry.Time);
                }
                {
                    CokerCardCycleStepEntry entry = requeried.CycleStepEntries.Find(obj => obj.CycleStepId == step2.IdValue);
                    Assert.AreEqual(drum2.IdValue, entry.DrumId);
                    Assert.AreEqual(new Time(8, 0, 0), entry.StartEntry.Time);
                    Assert.AreEqual(new Time(9, 0, 0), entry.EndEntry.Time);
                }
            }

            card.CycleStepEntries.RemoveAt(0);
            card.CycleStepEntries[0].StartEntry = new TimeEntry(new Time(6, 0, 0), card.Shift.IdValue, card.ShiftStartDate);
            card.CycleStepEntries[0].EndEntry = new TimeEntry(new Time(7, 0, 0), card.Shift.IdValue, card.ShiftStartDate);
            card.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                null, drum3.IdValue, step3.IdValue,
                new TimeEntry(new Time(1, 0, 0), card.Shift.IdValue, card.ShiftStartDate),
                new TimeEntry(new Time(2, 0, 0), card.Shift.IdValue, card.ShiftStartDate)));
            dao.Update(card, new List<CokerCardCycleStepEntry>());

            {
                CokerCard requeried = dao.QueryById(card.IdValue);
                Assert.AreEqual(2, requeried.CycleStepEntries.Count);
                {
                    CokerCardCycleStepEntry entry = requeried.CycleStepEntries.Find(obj => obj.CycleStepId == step2.IdValue);
                    Assert.AreEqual(drum2.IdValue, entry.DrumId);
                    Assert.AreEqual(new Time(6, 0, 0), entry.StartEntry.Time);
                    Assert.AreEqual(new Time(7, 0, 0), entry.EndEntry.Time);
                }
                {
                    CokerCardCycleStepEntry entry = requeried.CycleStepEntries.Find(obj => obj.CycleStepId == step3.IdValue);
                    Assert.AreEqual(drum3.IdValue, entry.DrumId);
                    Assert.AreEqual(new Time(1, 0, 0), entry.StartEntry.Time);
                    Assert.AreEqual(new Time(2, 0, 0), entry.EndEntry.Time);
                }
            }
        }

        [Ignore] [Test]
        public void ShouldInsertNullCycleStepEntryEndTime()
        {
            CokerCardConfigurationDrum drum1 = configuration1.Drums[0];
            CokerCardConfigurationCycleStep step1 = configuration1.Steps[0];

            CokerCard card = CreateForInsert(WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(), configuration1);
            card.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                null, drum1.IdValue, step1.IdValue,
                new TimeEntry(new Time(12, 0, 0), card.Shift.IdValue, card.ShiftStartDate), 
                null));
            card = dao.Insert(card, new List<CokerCardCycleStepEntry>());

            {
                CokerCard requeried = dao.QueryById(card.IdValue);
                Assert.AreEqual(1, requeried.CycleStepEntries.Count);
                Assert.IsNull(requeried.CycleStepEntries[0].EndEntry);
            }
        }

        [Ignore] [Test]
        public void ShouldUpdateNullCycleStepEntryEndTime()
        {
            CokerCardConfigurationDrum drum1 = configuration1.Drums[0];
            CokerCardConfigurationCycleStep step1 = configuration1.Steps[0];

            CokerCard card = CreateForInsert(WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(), configuration1);
            card.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                null, drum1.IdValue, step1.IdValue,
                new TimeEntry(new Time(12, 0, 0), card.Shift.IdValue, card.ShiftStartDate),
                new TimeEntry(new Time(13, 0, 0), card.Shift.IdValue, card.ShiftStartDate)));
            card = dao.Insert(card, new List<CokerCardCycleStepEntry>());

            {
                CokerCard requeried = dao.QueryById(card.IdValue);
                Assert.AreEqual(1, requeried.CycleStepEntries.Count);
                Assert.IsNotNull(requeried.CycleStepEntries[0].EndEntry);
            }

            card.CycleStepEntries[0].EndEntry = null;
            dao.Update(card, new List<CokerCardCycleStepEntry>());

            {
                CokerCard requeried = dao.QueryById(card.IdValue);
                Assert.AreEqual(1, requeried.CycleStepEntries.Count);
                Assert.IsNull(requeried.CycleStepEntries[0].EndEntry);
            }
        }

        [Ignore] [Test]
        public void ShouldInsertAndUpdateDrumEntries()
        {
            CokerCardConfigurationDrum drum1 = configuration1.Drums[0];
            CokerCardConfigurationDrum drum2 = configuration1.Drums[1];
            CokerCardConfigurationDrum drum3 = configuration1.Drums[2];

            CokerCardConfigurationCycleStep step1 = configuration1.Steps[0];
            CokerCardConfigurationCycleStep step2 = configuration1.Steps[1];
            CokerCardConfigurationCycleStep step3 = configuration1.Steps[2];

            CokerCard card = CreateForInsert(WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(), configuration1);
            card.DrumEntries.Add(new CokerCardDrumEntry(null, drum1.IdValue, null, 13.4m, "abc"));
            card.DrumEntries.Add(new CokerCardDrumEntry(null, drum2.IdValue, step1.IdValue, null, "def"));
            card = dao.Insert(card, new List<CokerCardCycleStepEntry>());

            {
                CokerCard requeried = dao.QueryById(card.IdValue);
                Assert.AreEqual(2, requeried.DrumEntries.Count);
                {
                    CokerCardDrumEntry entry = requeried.DrumEntries.Find(obj => obj.DrumId == drum1.IdValue);
                    Assert.AreEqual(null, entry.LastCycleStepId);
                    Assert.AreEqual(13.4, entry.HoursIntoLastCycle);
                    Assert.AreEqual("abc", entry.Comments);
                }
                {
                    CokerCardDrumEntry entry = requeried.DrumEntries.Find(obj => obj.DrumId == drum2.IdValue);
                    Assert.AreEqual(step1.IdValue, entry.LastCycleStepId);
                    Assert.AreEqual(null, entry.HoursIntoLastCycle);
                    Assert.AreEqual("def", entry.Comments);
                }
            }

            card.DrumEntries.RemoveAt(0);
            card.DrumEntries[0].LastCycleStepId = step3.IdValue;
            card.DrumEntries[0].HoursIntoLastCycle = 1.75m;
            card.DrumEntries[0].Comments = "mno";
            card.DrumEntries.Add(new CokerCardDrumEntry(null, drum3.IdValue, step2.IdValue, 4.25m, "pqr"));
            dao.Update(card, new List<CokerCardCycleStepEntry>());

            {
                CokerCard requeried = dao.QueryById(card.IdValue);
                Assert.AreEqual(2, requeried.DrumEntries.Count);
                {
                    CokerCardDrumEntry entry = requeried.DrumEntries.Find(obj => obj.DrumId == drum2.IdValue);
                    Assert.AreEqual("mno", entry.Comments);
                    Assert.AreEqual(step3.IdValue, entry.LastCycleStepId);
                    Assert.AreEqual(1.75, entry.HoursIntoLastCycle);
                }
                {
                    CokerCardDrumEntry entry = requeried.DrumEntries.Find(obj => obj.DrumId == drum3.IdValue);
                    Assert.AreEqual("pqr", entry.Comments);
                    Assert.AreEqual(step2.IdValue, entry.LastCycleStepId);
                    Assert.AreEqual(4.25, entry.HoursIntoLastCycle);
                }
            }
        }

        [Ignore] [Test]
        public void ShouldDeleteWithCycleStepAndDrumEntries()
        {
            CokerCardConfigurationDrum drum1 = configuration1.Drums[0];
            CokerCardConfigurationDrum drum2 = configuration1.Drums[1];

            CokerCardConfigurationCycleStep step1 = configuration1.Steps[0];
            CokerCardConfigurationCycleStep step2 = configuration1.Steps[1];

            CokerCard card = CreateForInsert(WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(), configuration1);

            card.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                null, drum1.IdValue, step1.IdValue,
                new TimeEntry(new Time(12, 0, 0), card.Shift.IdValue, card.ShiftStartDate),
                new TimeEntry(new Time(13, 0, 0), card.Shift.IdValue, card.ShiftStartDate)));
            
            card.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                null, drum2.IdValue, step2.IdValue,
                new TimeEntry(new Time(8, 0, 0), card.Shift.IdValue, card.ShiftStartDate),
                new TimeEntry(new Time(9, 0, 0), card.Shift.IdValue, card.ShiftStartDate)));
            
            card.DrumEntries.Add(new CokerCardDrumEntry(null, drum1.IdValue, null, null, "abc"));
            card.DrumEntries.Add(new CokerCardDrumEntry(null, drum2.IdValue, null, null, "def"));

            card = dao.Insert(card, new List<CokerCardCycleStepEntry>());

            {
                CokerCard requeried = dao.QueryById(card.IdValue);
                Assert.IsNotNull(requeried);
                Assert.IsFalse(requeried.Deleted);
                 
                Assert.AreEqual(2, card.CycleStepEntries.Count);
                Assert.AreEqual(2, card.DrumEntries.Count);
            }

            dao.Remove(card);

            {
                CokerCard requeried = dao.QueryById(card.IdValue);
                Assert.IsNotNull(requeried);
                Assert.IsTrue(requeried.Deleted);

                Assert.AreEqual(2, card.CycleStepEntries.Count);
                Assert.AreEqual(2, card.DrumEntries.Count);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByConfigurationAndShift_VaryConfiguration()
        {
            ShiftPattern dayShift = ShiftPatternFixture.CreateDayShift();
            CokerCard card = dao.Insert(CokerCardFixture.CreateForInsert(configuration1, null, dayShift, new Date(2011, 4, 10)), new List<CokerCardCycleStepEntry>());

            {
                CokerCard result = dao.QueryByConfigurationAndShift(
                    card.ConfigurationId, new UserShift(dayShift, new Date(2011, 4, 10)));
                Assert.IsNotNull(result);
                Assert.AreEqual(card.Id, result.Id);
            }
            {
                CokerCard result = dao.QueryByConfigurationAndShift(
                    -123, new UserShift(dayShift, new Date(2011, 4, 10)));
                Assert.IsNull(result);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByConfigurationAndShift_VaryShift()
        {
            ShiftPattern dayShift = ShiftPatternFixture.CreateDayShift();
            ShiftPattern nightShift = ShiftPatternFixture.CreateNightShift();

            CokerCard card1 = dao.Insert(CokerCardFixture.CreateForInsert(configuration1, null, dayShift, new Date(2011, 4, 10)), new List<CokerCardCycleStepEntry>());
            CokerCard card2 = dao.Insert(CokerCardFixture.CreateForInsert(configuration1, null, nightShift, new Date(2011, 4, 10)), new List<CokerCardCycleStepEntry>());
            CokerCard card3 = dao.Insert(CokerCardFixture.CreateForInsert(configuration1, null, dayShift, new Date(2011, 4, 11)), new List<CokerCardCycleStepEntry>());
            CokerCard card4 = dao.Insert(CokerCardFixture.CreateForInsert(configuration1, null, nightShift, new Date(2011, 4, 11)), new List<CokerCardCycleStepEntry>());

            {
                CokerCard result = dao.QueryByConfigurationAndShift(
                    card1.ConfigurationId, new UserShift(dayShift, new Date(2011, 4, 9)));
                Assert.IsNull(result);
            }
            {
                CokerCard result = dao.QueryByConfigurationAndShift(
                    card1.ConfigurationId, new UserShift(nightShift, new Date(2011, 4, 9)));
                Assert.IsNull(result);
            }
            {
                CokerCard result = dao.QueryByConfigurationAndShift(
                    card1.ConfigurationId, new UserShift(dayShift, new Date(2011, 4, 10)));
                Assert.IsNotNull(result);
                Assert.AreEqual(card1.Id, result.Id);
            }
            {
                CokerCard result = dao.QueryByConfigurationAndShift(
                    card1.ConfigurationId, new UserShift(nightShift, new Date(2011, 4, 10)));
                Assert.IsNotNull(result);
                Assert.AreEqual(card2.Id, result.Id);
            }
            {
                CokerCard result = dao.QueryByConfigurationAndShift(
                    card1.ConfigurationId, new UserShift(dayShift, new Date(2011, 4, 11)));
                Assert.IsNotNull(result);
                Assert.AreEqual(card3.Id, result.Id);
            }
            {
                CokerCard result = dao.QueryByConfigurationAndShift(
                    card1.ConfigurationId, new UserShift(nightShift, new Date(2011, 4, 11)));
                Assert.IsNotNull(result);
                Assert.AreEqual(card4.Id, result.Id);
            }
            {
                CokerCard result = dao.QueryByConfigurationAndShift(
                    card1.ConfigurationId, new UserShift(dayShift, new Date(2011, 4, 12)));
                Assert.IsNull(result);
            }
            {
                CokerCard result = dao.QueryByConfigurationAndShift(
                    card1.ConfigurationId, new UserShift(nightShift, new Date(2011, 4, 12)));
                Assert.IsNull(result);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByConfigurationAndShiftAndNotReturnDeleted()
        {
            ShiftPattern dayShift = ShiftPatternFixture.CreateDayShift();
            CokerCard card = dao.Insert(CokerCardFixture.CreateForInsert(configuration1, null, dayShift, new Date(2011, 4, 10)), new List<CokerCardCycleStepEntry>());

            {
                CokerCard result = dao.QueryByConfigurationAndShift(
                    card.ConfigurationId, new UserShift(dayShift, new Date(2011, 4, 10)));
                Assert.IsNotNull(result);
                Assert.AreEqual(card.Id, result.Id);
            }

            dao.Remove(card);

            {
                CokerCard result = dao.QueryByConfigurationAndShift(
                    card.ConfigurationId, new UserShift(dayShift, new Date(2011, 4, 10)));
                Assert.IsNull(result);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByIdAndOnlyBringBackCorrectCycleEntries()
        {
            CokerCard card1;
           
            {
                CokerCardConfigurationDrum drum1 = configuration1.Drums[0];
                CokerCardConfigurationDrum drum2 = configuration1.Drums[1];

                CokerCardConfigurationCycleStep step1 = configuration1.Steps[0];
                CokerCardConfigurationCycleStep step2 = configuration1.Steps[1];

                CokerCard card = CreateForInsert(WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(), configuration1);

                card.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                                              null, drum1.IdValue, step1.IdValue,
                                              new TimeEntry(new Time(12, 0, 0), card.Shift.IdValue, card.ShiftStartDate),
                                              new TimeEntry(new Time(13, 0, 0), card.Shift.IdValue, card.ShiftStartDate)));

                card.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                                              null, drum2.IdValue, step2.IdValue,
                                              new TimeEntry(new Time(8, 0, 0), card.Shift.IdValue, card.ShiftStartDate),
                                              new TimeEntry(new Time(9, 0, 0), card.Shift.IdValue, card.ShiftStartDate)));

                card.DrumEntries.Add(new CokerCardDrumEntry(null, drum1.IdValue, null, null, "abc"));
                card.DrumEntries.Add(new CokerCardDrumEntry(null, drum2.IdValue, null, null, "def"));

                card1 = dao.Insert(card, new List<CokerCardCycleStepEntry>());
            }

            {
                CokerCardConfigurationDrum drum1 = configuration2.Drums[0];
                CokerCardConfigurationDrum drum2 = configuration2.Drums[1];

                CokerCardConfigurationCycleStep step1 = configuration2.Steps[0];
                CokerCardConfigurationCycleStep step2 = configuration2.Steps[1];

                CokerCard card = CreateForInsert(WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(), configuration2);

                card.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                                              null, drum1.IdValue, step1.IdValue,
                                              new TimeEntry(new Time(12, 0, 0), card.Shift.IdValue, card.ShiftStartDate),
                                              new TimeEntry(new Time(13, 0, 0), card.Shift.IdValue, card.ShiftStartDate)));

                card.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                                              null, drum2.IdValue, step2.IdValue,
                                              new TimeEntry(new Time(8, 0, 0), card.Shift.IdValue, card.ShiftStartDate),
                                              new TimeEntry(new Time(9, 0, 0), card.Shift.IdValue, card.ShiftStartDate)));

                card.DrumEntries.Add(new CokerCardDrumEntry(null, drum1.IdValue, null, null, "abc"));
                card.DrumEntries.Add(new CokerCardDrumEntry(null, drum2.IdValue, null, null, "def"));

                dao.Insert(card, new List<CokerCardCycleStepEntry>());
            }

            CokerCard cardOneFromDatabase = dao.QueryById(card1.IdValue);

            Assert.AreEqual(2, cardOneFromDatabase.CycleStepEntries.Count);
        }

        [Ignore] [Test]
        public void ShouldQueryByIdAndNotGetRemovedEntries()
        {
            CokerCard card1;
            CokerCard card2;

            {
                CokerCardConfigurationDrum drum1 = configuration1.Drums[0];
                CokerCardConfigurationDrum drum2 = configuration1.Drums[1];

                CokerCardConfigurationCycleStep step1 = configuration1.Steps[0];
                CokerCardConfigurationCycleStep step2 = configuration1.Steps[1];

                CokerCard card = CreateForInsert(WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(), configuration1);

                card.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                                              null, drum1.IdValue, step1.IdValue,
                                              new TimeEntry(new Time(12, 0, 0), card.Shift.IdValue, card.ShiftStartDate),
                                              new TimeEntry(new Time(13, 0, 0), card.Shift.IdValue, card.ShiftStartDate)));

                card.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                                              null, drum2.IdValue, step2.IdValue,
                                              new TimeEntry(new Time(8, 0, 0), card.Shift.IdValue, card.ShiftStartDate),
                                              new TimeEntry(new Time(9, 0, 0), card.Shift.IdValue, card.ShiftStartDate)));

                card.DrumEntries.Add(new CokerCardDrumEntry(null, drum1.IdValue, null, null, "abc"));
                card.DrumEntries.Add(new CokerCardDrumEntry(null, drum2.IdValue, null, null, "def"));

                card1 = dao.Insert(card, new List<CokerCardCycleStepEntry>());
            }

            dao.Remove(card1);

            {
                CokerCardConfigurationDrum drum1 = configuration1.Drums[0];
                CokerCardConfigurationDrum drum2 = configuration1.Drums[1];

                CokerCardConfigurationCycleStep step1 = configuration1.Steps[0];
                CokerCardConfigurationCycleStep step2 = configuration1.Steps[1];

                CokerCard card = CreateForInsert(WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(), configuration1);

                card.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                                              null, drum1.IdValue, step1.IdValue,
                                              new TimeEntry(new Time(12, 0, 0), card.Shift.IdValue, card.ShiftStartDate),
                                              new TimeEntry(new Time(13, 0, 0), card.Shift.IdValue, card.ShiftStartDate)));

                card.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                                              null, drum2.IdValue, step2.IdValue,
                                              new TimeEntry(new Time(8, 0, 0), card.Shift.IdValue, card.ShiftStartDate),
                                              new TimeEntry(new Time(9, 0, 0), card.Shift.IdValue, card.ShiftStartDate)));

                card.DrumEntries.Add(new CokerCardDrumEntry(null, drum1.IdValue, null, null, "abc"));
                card.DrumEntries.Add(new CokerCardDrumEntry(null, drum2.IdValue, null, null, "def"));

                card2 = dao.Insert(card, new List<CokerCardCycleStepEntry>());
            }            
            
            CokerCard cardTwoFromDatabase = dao.QueryById(card2.IdValue);

            Assert.AreEqual(2, cardTwoFromDatabase.CycleStepEntries.Count);
        }

        [Ignore] [Test]
        public void ShouldUpdatePreviousCycleStepEntryOnInsert()
        {
            CokerCard previousCard = CreateCokerCardWithCycleStepEntries(ShiftPatternFixture.CreateNightShift(), new Date(2010, 3, 14));
            dao.Insert(previousCard, new List<CokerCardCycleStepEntry>());

            {
                CokerCard requeried = dao.QueryById(previousCard.IdValue);
                Assert.AreEqual(2, requeried.CycleStepEntries.Count);
                {
                    CokerCardCycleStepEntry entry = requeried.CycleStepEntries.Find(obj => obj.DrumId == previousCard.CycleStepEntries[0].DrumId);
                    Assert.AreEqual(new Time(12), entry.StartEntry.Time);
                    Assert.AreEqual(new Time(13), entry.EndEntry.Time);
                }
                {
                    CokerCardCycleStepEntry entry = requeried.CycleStepEntries.Find(obj => obj.DrumId == previousCard.CycleStepEntries[1].DrumId);
                    Assert.AreEqual(new Time(8), entry.StartEntry.Time);
                    Assert.AreEqual(new Time(9), entry.EndEntry.Time);
                }
            }

            previousCard.CycleStepEntries[0].StartEntry = new TimeEntry(new Time(1), previousCard.Shift.IdValue, previousCard.ShiftStartDate);
            previousCard.CycleStepEntries[0].EndEntry = new TimeEntry(new Time(2), previousCard.Shift.IdValue, previousCard.ShiftStartDate);
            previousCard.CycleStepEntries[1].StartEntry = new TimeEntry(new Time(3), previousCard.Shift.IdValue, previousCard.ShiftStartDate);
            previousCard.CycleStepEntries[1].EndEntry = null;

            CokerCard currentCard = CreateCokerCardWithCycleStepEntries(ShiftPatternFixture.CreateDayShift(), new Date(2010, 3, 15));
            dao.Insert(currentCard, previousCard.CycleStepEntries);

            {
                CokerCard requeried = dao.QueryById(previousCard.IdValue);
                Assert.AreEqual(2, requeried.CycleStepEntries.Count);
                {
                    CokerCardCycleStepEntry entry = requeried.CycleStepEntries.Find(obj => obj.DrumId == previousCard.CycleStepEntries[0].DrumId);
                    Assert.AreEqual(new Time(12), entry.StartEntry.Time);
                    Assert.AreEqual(new Time(2), entry.EndEntry.Time);
                }
                {
                    CokerCardCycleStepEntry entry = requeried.CycleStepEntries.Find(obj => obj.DrumId == previousCard.CycleStepEntries[1].DrumId);
                    Assert.AreEqual(new Time(8), entry.StartEntry.Time);
                    Assert.IsNull(entry.EndEntry);
                }
            }
        }

        [Ignore] [Test]
        public void ShouldUpdatePreviousCycleStepEntryOnUpdate()
        {
            CokerCard previousCard = CreateCokerCardWithCycleStepEntries(ShiftPatternFixture.CreateNightShift(), new Date(2010, 3, 14));
            dao.Insert(previousCard, new List<CokerCardCycleStepEntry>());

            {
                CokerCard requeried = dao.QueryById(previousCard.IdValue);
                Assert.AreEqual(2, requeried.CycleStepEntries.Count);
                {
                    CokerCardCycleStepEntry entry = requeried.CycleStepEntries.Find(obj => obj.DrumId == previousCard.CycleStepEntries[0].DrumId);
                    Assert.AreEqual(new Time(12), entry.StartEntry.Time);
                    Assert.AreEqual(new Time(13), entry.EndEntry.Time);
                }
                {
                    CokerCardCycleStepEntry entry = requeried.CycleStepEntries.Find(obj => obj.DrumId == previousCard.CycleStepEntries[1].DrumId);
                    Assert.AreEqual(new Time(8), entry.StartEntry.Time);
                    Assert.AreEqual(new Time(9), entry.EndEntry.Time);
                }
            }

            previousCard.CycleStepEntries[0].StartEntry = new TimeEntry(new Time(1), previousCard.Shift.IdValue, previousCard.ShiftStartDate);
            previousCard.CycleStepEntries[0].EndEntry = new TimeEntry(new Time(2), previousCard.Shift.IdValue, previousCard.ShiftStartDate);
            previousCard.CycleStepEntries[1].StartEntry = new TimeEntry(new Time(3), previousCard.Shift.IdValue, previousCard.ShiftStartDate);
            previousCard.CycleStepEntries[1].EndEntry = null;

            CokerCard currentCard = CreateCokerCardWithCycleStepEntries(ShiftPatternFixture.CreateDayShift(), new Date(2010, 3, 15));
            dao.Insert(currentCard, new List<CokerCardCycleStepEntry>());
            dao.Update(currentCard, previousCard.CycleStepEntries);

            {
                CokerCard requeried = dao.QueryById(previousCard.IdValue);
                Assert.AreEqual(2, requeried.CycleStepEntries.Count);
                {
                    CokerCardCycleStepEntry entry = requeried.CycleStepEntries.Find(obj => obj.DrumId == previousCard.CycleStepEntries[0].DrumId);
                    Assert.AreEqual(new Time(12), entry.StartEntry.Time);
                    Assert.AreEqual(new Time(2), entry.EndEntry.Time);
                }
                {
                    CokerCardCycleStepEntry entry = requeried.CycleStepEntries.Find(obj => obj.DrumId == previousCard.CycleStepEntries[1].DrumId);
                    Assert.AreEqual(new Time(8), entry.StartEntry.Time);
                    Assert.IsNull(entry.EndEntry);
                }
            }
        }

        private CokerCard CreateCokerCardWithCycleStepEntries(ShiftPattern shift, Date date)
        {
            CokerCardConfigurationDrum drum1 = configuration1.Drums[0];
            CokerCardConfigurationDrum drum2 = configuration1.Drums[1];

            CokerCardConfigurationCycleStep step1 = configuration1.Steps[0];
            CokerCardConfigurationCycleStep step2 = configuration1.Steps[1];

            CokerCard previousCard = CreateForInsert(shift, date);

            previousCard.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                null, drum1.IdValue, step1.IdValue,
                new TimeEntry(new Time(12, 0, 0), previousCard.Shift.IdValue, previousCard.ShiftStartDate),
                new TimeEntry(new Time(13, 0, 0), previousCard.Shift.IdValue, previousCard.ShiftStartDate)));
            previousCard.CycleStepEntries.Add(new CokerCardCycleStepEntry(
                null, drum2.IdValue, step2.IdValue,
                new TimeEntry(new Time(8, 0, 0), previousCard.Shift.IdValue, previousCard.ShiftStartDate),
                new TimeEntry(new Time(9, 0, 0), previousCard.Shift.IdValue, previousCard.ShiftStartDate)));
            return previousCard;
        }

        [Ignore] [Test]
        public void ShouldQueryCokerCardSummaries()
        {
            AssertQueryCokerCardSummaries(true, true);
        }

        [Ignore] [Test]
        public void ShouldQueryCokerCardSummaries_NullLastCycleStep()
        {
            AssertQueryCokerCardSummaries(false, true);
        }

        [Ignore] [Test]
        public void ShouldQueryCokerCardSummaries_NullHoursIn()
        {
            AssertQueryCokerCardSummaries(true, false);
        }

        private void AssertQueryCokerCardSummaries(bool includeLastCycleStep, bool includeHoursIn)
        {
            CokerCardConfiguration configuration = configuration1;
            CokerCardConfigurationDrum drum = configuration.Drums[0];
            CokerCardConfigurationCycleStep step = configuration.Steps[0];

            long? lastCycleStepId = null;
            if (includeLastCycleStep)
            {
                lastCycleStepId = step.IdValue;
            }

            decimal? hoursIntoLastCycle = null;
            if (includeHoursIn)
            {
                hoursIntoLastCycle = 2.5m;
            }

            CokerCard card = CreateForInsert(WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(), configuration);
            CokerCardDrumEntry drumEntry = new CokerCardDrumEntry(null, drum.IdValue, lastCycleStepId, hoursIntoLastCycle, "abc");
            card.DrumEntries.Add(drumEntry);
            card = dao.Insert(card, new List<CokerCardCycleStepEntry>());

            {
                List<CokerCardDrumEntryDTO> dtos = dao.QueryCokerCardSummaries(
                    card.ShiftStartDate, card.Shift.IdValue, card.WorkAssignment.IdValue, new List<long>{ configuration.IdValue});
                CokerCardDrumEntryDTO dto = dtos.Find(obj => obj.DrumName == drum.Name);
                Assert.IsNotNull(dto);
                Assert.AreEqual(configuration.IdValue, dto.CokerCardConfigurationId);
                Assert.AreEqual(configuration.Name, dto.CokerCardName);
                Assert.AreEqual(drum.Name, dto.DrumName);
                if (includeLastCycleStep)
                {
                    Assert.AreEqual(step.Name, dto.CycleStepName);
                }
                else
                {
                    Assert.AreEqual("", dto.CycleStepName);                    
                }
                Assert.AreEqual(drumEntry.HoursIntoLastCycle ?? 0m, dto.HoursIntoCycle);
                Assert.AreEqual(drumEntry.Comments, dto.Comments);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryCokerCardSummaries_ReturnDtoEvenWhenNoEntryExists()
        {
            CokerCardConfiguration configuration = configuration1;
            CokerCardConfigurationDrum drum = configuration.Drums[0];

            CokerCard card = CreateForInsert(WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(), configuration);
            card = dao.Insert(card, new List<CokerCardCycleStepEntry>());

            {
                List<CokerCardDrumEntryDTO> dtos = dao.QueryCokerCardSummaries(
                    card.ShiftStartDate, card.Shift.IdValue, card.WorkAssignment.IdValue, new List<long> { configuration.IdValue });
                CokerCardDrumEntryDTO dto = dtos.Find(obj => obj.DrumName == drum.Name);
                Assert.IsNotNull(dto);
                Assert.AreEqual(configuration.IdValue, dto.CokerCardConfigurationId);
                Assert.AreEqual(configuration.Name, dto.CokerCardName);
                Assert.AreEqual(drum.Name, dto.DrumName);
                Assert.AreEqual("", dto.CycleStepName);
                Assert.AreEqual(0, dto.HoursIntoCycle);
                Assert.AreEqual("", dto.Comments);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryCokerCardSummaries_NotReturnDeletedCokerCard()
        {
            List<long> configurationIds = new List<long> { configuration1.IdValue };
            ShiftPattern shift = ShiftPatternFixture.CreateDayShift();
            WorkAssignment workAssignment = configuration1.WorkAssignments[0];
            Date date = new Date(2009, 03, 15);

            CokerCard card = dao.Insert(CreateCokerCardWithDrums(shift, date, workAssignment, configuration1), new List<CokerCardCycleStepEntry>());

            {
                List<CokerCardDrumEntryDTO> all = dao.QueryCokerCardSummaries(date, shift.IdValue, workAssignment.IdValue, configurationIds);
                Assert.AreEqual(configuration1.Drums.Count, all.Count);
                AssertDtosExistForConfiguration(all, configuration1);
            }

            dao.Remove(card);

            {
                List<CokerCardDrumEntryDTO> all = dao.QueryCokerCardSummaries(date, shift.IdValue, workAssignment.IdValue, configurationIds);
                Assert.AreEqual(0, all.Count);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryCokerCardSummaries_VaryShiftStartDate()
        {
            List<long> configurationIds = new List<long> { configuration1.IdValue, configuration2.IdValue };
            ShiftPattern shift = ShiftPatternFixture.CreateDayShift();
            WorkAssignment workAssignment = GetWorkAssignmentForBothConfigurations(
                WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData());

            Date date1 = new Date(2009, 03, 15);
            Date date2 = new Date(2009, 03, 16);

            dao.Insert(CreateCokerCardWithDrums(shift, date1, workAssignment, configuration1), new List<CokerCardCycleStepEntry>());
            dao.Insert(CreateCokerCardWithDrums(shift, date2, workAssignment, configuration1), new List<CokerCardCycleStepEntry>());
            dao.Insert(CreateCokerCardWithDrums(shift, date2, workAssignment, configuration2), new List<CokerCardCycleStepEntry>());

            {
                List<CokerCardDrumEntryDTO> all = dao.QueryCokerCardSummaries(date1, shift.IdValue, workAssignment.IdValue, configurationIds);
                Assert.AreEqual(configuration1.Drums.Count, all.Count);
                AssertDtosExistForConfiguration(all, configuration1);
            }
            {
                List<CokerCardDrumEntryDTO> all = dao.QueryCokerCardSummaries(date2, shift.IdValue, workAssignment.IdValue, configurationIds);
                Assert.AreEqual(configuration1.Drums.Count + configuration2.Drums.Count, all.Count);
                AssertDtosExistForConfiguration(all, configuration1);
                AssertDtosExistForConfiguration(all, configuration2);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryCokerCardSummaries_VaryShift()
        {
            List<long> configurationIds = new List<long> { configuration1.IdValue, configuration2.IdValue };
            Date date = new Date(2009, 03, 15);
            WorkAssignment workAssignment = GetWorkAssignmentForBothConfigurations(
                WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData());

            ShiftPattern shift1 = ShiftPatternFixture.CreateDayShift();
            ShiftPattern shift2 = ShiftPatternFixture.CreateNightShift();

            dao.Insert(CreateCokerCardWithDrums(shift1, date, workAssignment, configuration1), new List<CokerCardCycleStepEntry>());
            dao.Insert(CreateCokerCardWithDrums(shift2, date, workAssignment, configuration1), new List<CokerCardCycleStepEntry>());
            dao.Insert(CreateCokerCardWithDrums(shift2, date, workAssignment, configuration2), new List<CokerCardCycleStepEntry>());

            {
                List<CokerCardDrumEntryDTO> all = dao.QueryCokerCardSummaries(date, shift1.IdValue, workAssignment.IdValue, configurationIds);
                Assert.AreEqual(configuration1.Drums.Count, all.Count);
                AssertDtosExistForConfiguration(all, configuration1);
            }
            {
                List<CokerCardDrumEntryDTO> all = dao.QueryCokerCardSummaries(date, shift2.IdValue, workAssignment.IdValue, configurationIds);
                Assert.AreEqual(configuration1.Drums.Count + configuration2.Drums.Count, all.Count);
                AssertDtosExistForConfiguration(all, configuration1);
                AssertDtosExistForConfiguration(all, configuration2);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryCokerCardSummaries_VaryShiftWorkAssignment()
        {
            ShiftPattern shift = ShiftPatternFixture.CreateDayShift();
            Date date = new Date(2009, 03, 15);

            WorkAssignment workAssignment1 = configuration1.WorkAssignments[0];
            WorkAssignment workAssignment2 = configuration2.WorkAssignments[0];
            WorkAssignment workAssignment3 = WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData();

            dao.Insert(CreateCokerCardWithDrums(shift, date, workAssignment1, configuration1), new List<CokerCardCycleStepEntry>());
            dao.Insert(CreateCokerCardWithDrums(shift, date, workAssignment2, configuration2), new List<CokerCardCycleStepEntry>());
            dao.Insert(CreateCokerCardWithDrums(shift, date, workAssignment3, configuration1), new List<CokerCardCycleStepEntry>());
            dao.Insert(CreateCokerCardWithDrums(shift, date, workAssignment3, configuration2), new List<CokerCardCycleStepEntry>());

            {
                List<CokerCardDrumEntryDTO> all = dao.QueryCokerCardSummaries(date, shift.IdValue, workAssignment1.IdValue, new List<long>());
                Assert.AreEqual(configuration1.Drums.Count, all.Count);
                AssertDtosExistForConfiguration(all, configuration1);
            }
            {
                List<CokerCardDrumEntryDTO> all = dao.QueryCokerCardSummaries(date, shift.IdValue, workAssignment2.IdValue, new List<long>());
                Assert.AreEqual(configuration2.Drums.Count, all.Count);
                AssertDtosExistForConfiguration(all, configuration2);
            }
            {
                List<CokerCardDrumEntryDTO> all = dao.QueryCokerCardSummaries(date, shift.IdValue, workAssignment3.IdValue, new List<long>());
                Assert.AreEqual(configuration1.Drums.Count + configuration2.Drums.Count, all.Count);
                AssertDtosExistForConfiguration(all, configuration1);
                AssertDtosExistForConfiguration(all, configuration2);
            }
        }

        [Ignore] [Test]
        public void ShouldQueryCokerCardSummaries_VaryShiftConfigurationids()
        {
            ShiftPattern shift = ShiftPatternFixture.CreateDayShift();
            Date date = new Date(2009, 03, 15);
            WorkAssignment workAssignment = GetWorkAssignmentForBothConfigurations(
                WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData());

            WorkAssignment workAssignmentThatDoesNotExist = WorkAssignmentFixture.CreateUnitLeader();
            workAssignmentThatDoesNotExist.Id = -1234;

            dao.Insert(CreateCokerCardWithDrums(shift, date, workAssignment, configuration1), new List<CokerCardCycleStepEntry>());
            dao.Insert(CreateCokerCardWithDrums(shift, date, workAssignment, configuration2), new List<CokerCardCycleStepEntry>());

            {
                List<CokerCardDrumEntryDTO> all = dao.QueryCokerCardSummaries(date, shift.IdValue, workAssignmentThatDoesNotExist.IdValue, new List<long> { configuration1.IdValue });
                Assert.AreEqual(configuration1.Drums.Count, all.Count);
                AssertDtosExistForConfiguration(all, configuration1);
            }
            {
                List<CokerCardDrumEntryDTO> all = dao.QueryCokerCardSummaries(date, shift.IdValue, workAssignmentThatDoesNotExist.IdValue, new List<long> { configuration2.IdValue });
                Assert.AreEqual(configuration2.Drums.Count, all.Count);
                AssertDtosExistForConfiguration(all, configuration2);
            }
            {
                List<CokerCardDrumEntryDTO> all = dao.QueryCokerCardSummaries(date, shift.IdValue, workAssignmentThatDoesNotExist.IdValue, new List<long> { configuration1.IdValue, configuration2.IdValue });
                Assert.AreEqual(configuration1.Drums.Count + configuration2.Drums.Count, all.Count);
                AssertDtosExistForConfiguration(all, configuration1);
                AssertDtosExistForConfiguration(all, configuration2);
            }
        }

        private static void AssertDtosExistForConfiguration(List<CokerCardDrumEntryDTO> all, CokerCardConfiguration configuration)
        {
            List<CokerCardDrumEntryDTO> dtos = all.FindAll(obj => obj.CokerCardConfigurationId == configuration.IdValue);
            Assert.AreEqual(configuration.Drums.Count, dtos.Count);
            for (int i = 0; i < configuration.Drums.Count; i++)
            {
                string expectedComments = configuration.Name + "_drum_" + i;
                Assert.IsTrue(dtos.Exists(obj => obj.Comments == expectedComments), "Should find: " + expectedComments);
            }
        }

        private static CokerCard CreateCokerCardWithDrums(ShiftPattern shift, Date date, WorkAssignment workAssignment, CokerCardConfiguration configuration)
        {
            CokerCard card = CokerCardFixture.CreateForInsert(configuration, workAssignment, shift, date);
            for (int i = 0; i < configuration.Drums.Count; i++)
            {
                CokerCardConfigurationDrum drum = configuration.Drums[i];
                card.DrumEntries.Add(new CokerCardDrumEntry(null, drum.IdValue, null, null, configuration.Name + "_drum_" + i));
            }
            return card;
        }

        private WorkAssignment GetWorkAssignmentForBothConfigurations(WorkAssignment workAssignment)
        {
            configuration1.WorkAssignments.Add(workAssignment);
            configuration2.WorkAssignments.Add(workAssignment);
            configurationDao.Update(configuration1);
            configurationDao.Update(configuration2);
            return workAssignment;
        }

    }
}
