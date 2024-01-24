using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    [TestFixture] [Category("Database")]
    public class CokerCardDTODaoTest : AbstractDaoTest
    {
        private ICokerCardDTODao dtoDao;
        private ICokerCardDao cokerCardDao;
        private IShiftPatternDao shiftPatternDao;
        private IWorkAssignmentDao workAssignmentDao;
        private IUserDao userDao;
        private ICokerCardConfigurationDao configurationDao;

        protected override void TestInitialize()
        {
            dtoDao = DaoRegistry.GetDao<ICokerCardDTODao>();
            cokerCardDao = DaoRegistry.GetDao<ICokerCardDao>();
            shiftPatternDao = DaoRegistry.GetDao<IShiftPatternDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
            userDao = DaoRegistry.GetDao<IUserDao>();
            configurationDao = DaoRegistry.GetDao<ICokerCardConfigurationDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldReturnPopulated()
        {
            const string workAssignmentName = "coker assignment";
            WorkAssignment workAssignment = WorkAssignmentFixture.CreateOilsandsWorkAssignmentToBeInsertedInDatabase(workAssignmentName);
            workAssignment = workAssignmentDao.Insert(workAssignment);

            User user = UserFixture.CreateOperator(0, "cokername");
            user.FirstName = "CokerFirst";
            user.LastName = "CokerLast";
            user = userDao.Insert(user);

            FunctionalLocation floc = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL_SWM();
            CokerCard cokerCard = Insert(floc, workAssignment, new DateTime(2010, 3, 17), new DateTime(2010, 2, 15, 2, 3, 1), user);

            List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc };
            List<CokerCardDTO> results = dtoDao.QueryByExactFlocMatch(new ExactFlocSet(functionalLocations), new DateRange(null, null));

            CokerCardDTO result = results.Find(obj => obj.Id == cokerCard.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(cokerCard.ConfigurationName, result.Name);
            Assert.AreEqual("EX1-OPLT-TOOL-SWM", result.FunctionalLocationName);
            Assert.AreEqual(workAssignmentName, result.WorkAssignmentName);
            Assert.AreEqual(user.IdValue, result.CreatedByUserId);
            Assert.AreEqual(user.FullNameWithUserName, result.CreatedByFullnameWithUserName);
            Assert.AreEqual(cokerCard.Shift.IdValue, result.ShiftId);
            Assert.AreEqual(cokerCard.CreatedDateTime, result.CreatedDateTime);
            Assert.IsTrue(result.Shift.Contains("12e"));
            Assert.IsTrue(result.Shift.Contains("14")); // day
            Assert.IsTrue(result.Shift.Contains("2010")); // year
        }

        [Ignore] [Test]
        public void ShouldReturnNullWorkAssignment()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL_SWM();
            CokerCard cokerCard = Insert(floc, null, new DateTime(2020, 1, 1), new DateTime(2010, 1, 1), UserFixture.CreateOperatorGoofyInFortMcMurrySite());

            List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc };
            List<CokerCardDTO> results = dtoDao.QueryByExactFlocMatch(new ExactFlocSet(functionalLocations), new DateRange(null, null));

            CokerCardDTO result = results.Find(obj => obj.Id == cokerCard.Id);
            Assert.IsNotNull(result);
            Assert.IsNull(result.WorkAssignmentName);
        }

        [Ignore] [Test]
        public void ShouldNotReturnDeleted()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL_SWM();
            CokerCard cokerCard = Insert(floc, new DateTime(2020, 1, 1), new DateTime(2010, 1, 1));

            List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc };
            {
                List<CokerCardDTO> results = dtoDao.QueryByExactFlocMatch(new ExactFlocSet(functionalLocations), new DateRange(null, null));
                Assert.IsTrue(results.Exists(obj => obj.Id == cokerCard.Id));
            }

            cokerCardDao.Remove(cokerCard);

            {
                List<CokerCardDTO> results = dtoDao.QueryByExactFlocMatch(new ExactFlocSet(functionalLocations), new DateRange(null, null));
                Assert.IsFalse(results.Exists(obj => obj.Id == cokerCard.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByDateRange()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL_SWM();

            CokerCard cokerCard1 = Insert(floc, new DateTime(2020, 1, 1), new DateTime(2010, 1, 1));
            CokerCard cokerCard2 = Insert(floc, new DateTime(2020, 1, 1), new DateTime(2010, 2, 1));

            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc };
                List<CokerCardDTO> results = dtoDao.QueryByExactFlocMatch(new ExactFlocSet(functionalLocations), new DateRange(null, null));
                Assert.IsTrue(results.Exists(obj => obj.Id == cokerCard1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == cokerCard2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc };
                List<CokerCardDTO> results = dtoDao.QueryByExactFlocMatch(new ExactFlocSet(functionalLocations), new DateRange(new Date(2010, 1, 1), null));
                Assert.IsTrue(results.Exists(obj => obj.Id == cokerCard1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == cokerCard2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc };
                List<CokerCardDTO> results = dtoDao.QueryByExactFlocMatch(new ExactFlocSet(functionalLocations), new DateRange(new Date(2010, 2, 1), null));
                Assert.IsFalse(results.Exists(obj => obj.Id == cokerCard1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == cokerCard2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc };
                List<CokerCardDTO> results = dtoDao.QueryByExactFlocMatch(new ExactFlocSet(functionalLocations), new DateRange(new Date(2010, 2, 2), null));
                Assert.IsFalse(results.Exists(obj => obj.Id == cokerCard1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == cokerCard2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc };
                List<CokerCardDTO> results = dtoDao.QueryByExactFlocMatch(new ExactFlocSet(functionalLocations), new DateRange(null, new Date(2010, 2, 1)));
                Assert.IsTrue(results.Exists(obj => obj.Id == cokerCard1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == cokerCard2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc };
                List<CokerCardDTO> results = dtoDao.QueryByExactFlocMatch(new ExactFlocSet(functionalLocations), new DateRange(null, new Date(2010, 1, 1)));
                Assert.IsTrue(results.Exists(obj => obj.Id == cokerCard1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == cokerCard2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc };
                List<CokerCardDTO> results = dtoDao.QueryByExactFlocMatch(new ExactFlocSet(functionalLocations), new DateRange(null, new Date(2009, 12, 31)));
                Assert.IsFalse(results.Exists(obj => obj.Id == cokerCard1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == cokerCard2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc };
                List<CokerCardDTO> results = dtoDao.QueryByExactFlocMatch(new ExactFlocSet(functionalLocations), new DateRange(new Date(2010, 1, 1), new Date(2010, 2, 1)));
                Assert.IsTrue(results.Exists(obj => obj.Id == cokerCard1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == cokerCard2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc };
                List<CokerCardDTO> results = dtoDao.QueryByExactFlocMatch(new ExactFlocSet(functionalLocations), new DateRange(new Date(2010, 2, 2), new Date(2010, 2, 2)));
                Assert.IsFalse(results.Exists(obj => obj.Id == cokerCard1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == cokerCard2.Id));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByFloc()
        {
            DateTime someDate = new DateTime(2010, 6, 3);

            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_SR1_PLT3();
            FunctionalLocation floc3 = FunctionalLocationFixture.GetReal_SR1_PLT3_BDP3();

            CokerCard cokerCard1 = Insert(floc1, someDate, someDate);
            CokerCard cokerCard2 = Insert(floc2, someDate, someDate);

            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1 };
                List<CokerCardDTO> results = dtoDao.QueryByExactFlocMatch(new ExactFlocSet(functionalLocations), new DateRange(null, null));
                Assert.IsTrue(results.Exists(obj => obj.Id == cokerCard1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == cokerCard2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc2 };
                List<CokerCardDTO> results = dtoDao.QueryByExactFlocMatch(new ExactFlocSet(functionalLocations), new DateRange(null, null));
                Assert.IsFalse(results.Exists(obj => obj.Id == cokerCard1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == cokerCard2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc1, floc2 };
                List<CokerCardDTO> results = dtoDao.QueryByExactFlocMatch(new ExactFlocSet(functionalLocations), new DateRange(null, null));
                Assert.IsTrue(results.Exists(obj => obj.Id == cokerCard1.Id));
                Assert.IsTrue(results.Exists(obj => obj.Id == cokerCard2.Id));
            }
            {
                List<FunctionalLocation> functionalLocations = new List<FunctionalLocation> { floc3 };
                List<CokerCardDTO> results = dtoDao.QueryByExactFlocMatch(new ExactFlocSet(functionalLocations), new DateRange(null, null));
                Assert.IsFalse(results.Exists(obj => obj.Id == cokerCard1.Id));
                Assert.IsFalse(results.Exists(obj => obj.Id == cokerCard2.Id));
            }
        }

        private CokerCard Insert(
            FunctionalLocation functionalLocation, 
            DateTime lastModifiedDateTime, 
            DateTime createdDateTime)
        {
            return Insert(
                functionalLocation,
                WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData(),
                lastModifiedDateTime,
                createdDateTime,
                UserFixture.CreateOperatorGoofyInFortMcMurrySite());
        }

        private CokerCard Insert(FunctionalLocation functionalLocation, WorkAssignment workAssignmentForCokerCard,
                                 DateTime lastModifiedDateTime, DateTime createdDateTime, User createdByUser)
        {
            ShiftPattern shiftToUse = GetValidShift(createdDateTime);
            UserShift userShift = new UserShift(shiftToUse, createdDateTime);

            List<CokerCardConfiguration> configurations = configurationDao.QueryCokerCardConfigurationsBySite(SiteFixture.Oilsands().IdValue);
            CokerCardConfiguration configuration = configurations.Find(obj => obj.FunctionalLocation.Id == FunctionalLocationFixture.GetReal_UP1().Id);

            CokerCard cokerCard = new CokerCard(
                null,
                configuration.IdValue,
                configuration.Name,
                functionalLocation,
                workAssignmentForCokerCard,
                shiftToUse,
                userShift.StartDate, 
                createdByUser,
                createdDateTime,
                UserFixture.CreateEngineeringSupport(),
                lastModifiedDateTime,
                false);
            return cokerCardDao.Insert(cokerCard, new List<CokerCardCycleStepEntry>());
        }

        private ShiftPattern GetValidShift(DateTime createdDateTime)
        {
            ShiftPattern dayShift = ShiftPatternFixture.CreateDayShift();
            ShiftPattern nightShift = ShiftPatternFixture.CreateNightShift();

            ShiftPattern shiftToUse;
            if (dayShift.IsTimeInShiftIncludingPadding(new Time(createdDateTime)))
            {
                shiftToUse = dayShift;
            }
            else
            {
                shiftToUse = nightShift;
            }
            
            shiftToUse = shiftPatternDao.Insert(shiftToUse);
            return shiftToUse;
        }
    }
}
