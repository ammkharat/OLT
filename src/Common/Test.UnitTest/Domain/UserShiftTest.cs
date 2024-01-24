using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class UserShiftTest
    {
        
        [Test]
        public void TestStartDateSetupCorrectlyForNotOverlappingDay()
        {
            DateTime now = new DateTime(2006, 1, 1, 15, 0, 0);
            ShiftPattern pattern = ShiftPatternFixture.CreateShiftPattern(new Time(4, 0), new Time(20, 0), now);

            DateTime startDateTime = new UserShift(pattern, now).StartDateTime;
            Assert.AreEqual(new DateTime(2006, 1, 1, 4, 0, 0), startDateTime);
        }

        [Test]
        public void TestStartDateCorrectlyForOverlappingDayWhereClockIsOnTheFirstDay()
        {
            DateTime now = new DateTime(2006, 1, 1, 21, 0, 0);
            ShiftPattern pattern = ShiftPatternFixture.CreateShiftPattern(new Time(20, 0), new Time(3, 0), now);

            DateTime startDateTime = new UserShift(pattern, now).StartDateTime;
            Assert.AreEqual(new DateTime(2006, 1, 1, 20, 0, 0), startDateTime);
        }

        [Test]
        public void TestStartDateSetupCorrectlyForOverlappingDayAndClockOnSecondDay()
        {
            DateTime now = new DateTime(2006, 1, 2, 2, 0, 0);
            ShiftPattern pattern = ShiftPatternFixture.CreateShiftPattern(new Time(20, 0), new Time(3, 0), now);

            DateTime startDateTime = new UserShift(pattern, now).StartDateTime;
            Assert.AreEqual(new DateTime(2006, 1, 1, 20, 0, 0), startDateTime);
        }

        [Test]
        public void TestStartDateSetupCorrectlyForNonOverlappingDayButLoggedInOnPreviousDayInGracePeriod()
        {
            DateTime now = new DateTime(2006, 1, 1, 23, 58, 0);
            ShiftPattern pattern = ShiftPatternFixture.CreateShiftPattern(new Time(0, 5), new Time(12, 0), now);

            DateTime startDateTime = new UserShift(pattern, now).StartDateTime;
            
            Assert.AreEqual(new DateTime(2006, 1, 2, 0, 5, 0), startDateTime);
        }

        [Test]
        public void TestEndDateSetupCorrectlyForNotOverlappingDay()
        {
            DateTime now = new DateTime(2006, 1, 1, 15, 0, 0);
            ShiftPattern pattern = ShiftPatternFixture.CreateShiftPattern(new Time(4, 0), new Time(20, 0), now);

            UserShift userShift = new UserShift(pattern, now);
            Assert.AreEqual(new DateTime(2006, 1, 1, 20, 0, 0), userShift.EndDateTime);
        }

        [Test]
        public void TestEndDateSetupCorrectlyForOverlappingDay()
        {
            DateTime now = new DateTime(2006, 1, 2, 2, 0, 0);
            ShiftPattern pattern = ShiftPatternFixture.CreateShiftPattern(new Time(20, 0), new Time(3, 0), now);

            UserShift userShift = new UserShift(pattern, now);
            Assert.AreEqual(new DateTime(2006, 1, 2, 3, 0, 0), userShift.EndDateTime);
        }

        [Test]
        public void TestOverlappingDayWithLogCreatedAtMidnight()
        {
            DateTime now = new DateTime(2006, 1, 2, 0, 0, 0);
            ShiftPattern pattern = ShiftPatternFixture.CreateShiftPattern(new Time(20, 0), new Time(3, 0), now);
            UserShift userShift = new UserShift(pattern, now);
            Assert.AreEqual(new DateTime(2006, 1, 1, 20, 0, 0), userShift.StartDateTime);
        }

        [Test]
        public void CreateWithShiftPatternAndStartDateShouldCreateUserShiftWithStartDateTimeOnStartDate()
        {
            ShiftPattern shiftPattern = 
                ShiftPatternFixture.CreateShiftPattern(new Time(22, 00), new Time(04, 00));
            Date startDate = new Date(2006, 7, 1);
            UserShift userShift = new UserShift(shiftPattern, startDate);
            Assert.AreEqual(new DateTime(2006, 7, 1, 22, 00, 00), userShift.StartDateTime);
        }

        [Test]
        public void ShouldGetLatestCompletedShift()
        {
            {
                ShiftPattern shiftPatternA = ShiftPatternFixture.CreateShiftPattern(new Time(4), new Time(16));
                ShiftPattern shiftPatternB = ShiftPatternFixture.CreateShiftPattern(new Time(16), new Time(4));
                DateTime now = new DateTime(2010, 12, 2, 18, 0, 0);
                List<ShiftPattern> patterns = new List<ShiftPattern> {shiftPatternA, shiftPatternB};

                UserShift latestCompletedUserShift = UserShift.GetLatestCompletedUserShift(patterns, now);
                Assert.AreEqual(new DateTime(2010, 12, 2, 4, 0, 0), latestCompletedUserShift.StartDateTime);
                Assert.AreEqual(new DateTime(2010, 12, 2, 16, 0, 0), latestCompletedUserShift.EndDateTime);
            }
            {
                ShiftPattern shiftPatternA = ShiftPatternFixture.CreateShiftPattern(new Time(7), new Time(19));
                ShiftPattern shiftPatternB = ShiftPatternFixture.CreateShiftPattern(new Time(19), new Time(7));
                DateTime now = new DateTime(2010, 12, 2, 18, 0, 0);
                List<ShiftPattern> patterns = new List<ShiftPattern> { shiftPatternA, shiftPatternB };

                UserShift latestCompletedUserShift = UserShift.GetLatestCompletedUserShift(patterns, now);
                Assert.AreEqual(new DateTime(2010, 12, 1, 19, 0, 0), latestCompletedUserShift.StartDateTime);
                Assert.AreEqual(new DateTime(2010, 12, 2, 7, 0, 0), latestCompletedUserShift.EndDateTime);
            }
        }

        [Test]
        public void ShouldChooseNextShiftAsTheOneBeginningSoonestAfterEndOfCurrentShift()
        {
            UserShift userShift = UserShiftFixture.CreateUserShift(new Time(6), new Time(18), new Date(2010, 12, 20));

            ShiftPattern sevenPmShift = ShiftPatternFixture.CreateShiftPattern(new Time(19), new Time(7));
            ShiftPattern eightPmShift = ShiftPatternFixture.CreateShiftPattern(new Time(20), new Time(8));

            UserShift nextShift = userShift.ChooseNextShift(new List<ShiftPattern> { sevenPmShift, eightPmShift });

            Assert.AreEqual(new DateTime(2010, 12, 20, 19, 0, 0), nextShift.StartDateTime);
            Assert.AreEqual(new DateTime(2010, 12, 21, 7, 0, 0), nextShift.EndDateTime);
            Assert.AreEqual(sevenPmShift.IdValue, nextShift.ShiftPatternId);
        }

        [Test]
        public void ShouldChooseNextShiftAsTheLongestOneBeginningSoonestAfterEndOfCurrentShift()
        {
            UserShift userShift = UserShiftFixture.CreateUserShift(new Time(18), new Time(6), new Date(2010, 12, 20));

            ShiftPattern shorterShift = ShiftPatternFixture.CreateShiftPattern(new Time(6), new Time(16));
            ShiftPattern longerShift = ShiftPatternFixture.CreateShiftPattern(new Time(6), new Time(18));

            UserShift nextShift = userShift.ChooseNextShift(new List<ShiftPattern> { shorterShift, longerShift });

            Assert.AreEqual(new DateTime(2010, 12, 21, 6, 0, 0), nextShift.StartDateTime);
            Assert.AreEqual(new DateTime(2010, 12, 21, 18, 0, 0), nextShift.EndDateTime);
            Assert.AreEqual(longerShift.IdValue, nextShift.ShiftPatternId);
        }

        [Test]
        public void ShouldChoosePreviousShiftToADayShift()
        {
            ShiftPattern dayShift = ShiftPatternFixture.CreateShiftPattern(new Time(6), new Time(18), 1);
            ShiftPattern nightShift = ShiftPatternFixture.CreateShiftPattern(new Time(18), new Time(6), 2);

            UserShift userShift = new UserShift(dayShift, new DateTime(2010, 12, 20, 10, 0, 0));

            UserShift previousShift = userShift.ChoosePreviousShift(new List<ShiftPattern> { dayShift, nightShift });

            Assert.AreEqual(new DateTime(2010, 12, 19, 18, 0, 0), previousShift.StartDateTime);
            Assert.AreEqual(new DateTime(2010, 12, 20, 6, 0, 0), previousShift.EndDateTime);
            Assert.AreEqual(nightShift.IdValue, previousShift.ShiftPatternId);
        }

        [Test]
        public void ShouldChoosePreviousShiftToANightShiftWhenNowIsNight()
        {
            ShiftPattern dayShift = ShiftPatternFixture.CreateShiftPattern(new Time(6), new Time(18), 1);
            ShiftPattern nightShift = ShiftPatternFixture.CreateShiftPattern(new Time(18), new Time(6), 2);

            UserShift userShift = new UserShift(nightShift, new DateTime(2010, 12, 20, 19, 0, 0));

            UserShift previousShift = userShift.ChoosePreviousShift(new List<ShiftPattern> { dayShift, nightShift });

            Assert.AreEqual(new DateTime(2010, 12, 20, 6, 0, 0), previousShift.StartDateTime);
            Assert.AreEqual(new DateTime(2010, 12, 20, 18, 0, 0), previousShift.EndDateTime);
            Assert.AreEqual(dayShift.IdValue, previousShift.ShiftPatternId);
        }

        [Test]
        public void ShouldChoosePreviousShiftToANightShiftWhenNowIsMorning()
        {
            ShiftPattern dayShift = ShiftPatternFixture.CreateShiftPattern(new Time(6), new Time(18), 1);
            ShiftPattern nightShift = ShiftPatternFixture.CreateShiftPattern(new Time(18), new Time(6), 2);

            UserShift userShift = new UserShift(nightShift, new DateTime(2010, 12, 21, 3, 0, 0));

            UserShift previousShift = userShift.ChoosePreviousShift(new List<ShiftPattern> { dayShift, nightShift });

            Assert.AreEqual(new DateTime(2010, 12, 20, 6, 0, 0), previousShift.StartDateTime);
            Assert.AreEqual(new DateTime(2010, 12, 20, 18, 0, 0), previousShift.EndDateTime);
            Assert.AreEqual(dayShift.IdValue, previousShift.ShiftPatternId);
        }

        [Test]
        public void ShouldChoosePreviousShiftAsTheLongestOneIfMoreThanOneStartsAtTheSameTime()
        {
            ShiftPattern shorterShift = ShiftPatternFixture.CreateShiftPattern(new Time(6), new Time(16), 1);
            ShiftPattern longerShift = ShiftPatternFixture.CreateShiftPattern(new Time(6), new Time(18), 2);
            ShiftPattern currentShift = ShiftPatternFixture.CreateShiftPattern(new Time(18), new Time(6), 3);

            UserShift userShift = new UserShift(currentShift, new DateTime(2010, 12, 20, 19, 0, 9));

            UserShift previousShift = userShift.ChoosePreviousShift(new List<ShiftPattern> { shorterShift, longerShift });

            Assert.AreEqual(new DateTime(2010, 12, 20, 6, 0, 0), previousShift.StartDateTime);
            Assert.AreEqual(new DateTime(2010, 12, 20, 18, 0, 0), previousShift.EndDateTime);
            Assert.AreEqual(longerShift.IdValue, previousShift.ShiftPatternId);
        }
    }
}
