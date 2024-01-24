using System;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class UserWorkPermitDefaultTimePreferencesTest
    {
        private UserShift overnight6pmTo6amShift;
        
        [SetUp]
        public void SetUp()
        {
            overnight6pmTo6amShift = UserShiftFixture.CreateUserShift(new Time(18, 00), new Time(06, 00), new DateTime(2006, 7, 1));
        }
        
        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void ConstructorShouldCreateZeroPaddingForShiftStartAndEnd()
        {
            var preferences = new UserWorkPermitDefaultTimePreferences(UserFixture.CreateOperator().IdValue);
            Assert.AreEqual(new TimeSpan(), preferences.PreShiftPadding);
            Assert.AreEqual(new TimeSpan(), preferences.PostShiftPadding);
        }

        [Test]
        public void DefaultDateTimeRangeShouldReturnGivenUserShiftWithPadding()
        {
            var preferences = new UserWorkPermitDefaultTimePreferences(UserFixture.CreateOperator().IdValue);
            Assert.AreEqual(new Range<DateTime>(new DateTime(2006, 7, 1, 18, 00, 00),
                                                new DateTime(2006, 7, 2, 06, 00, 00)),
                            preferences.DefaultDateTimeRange(overnight6pmTo6amShift));

            preferences = new UserWorkPermitDefaultTimePreferences(-99, new TimeSpan(02, 00, 00), new TimeSpan(02, 00, 00));
            Assert.AreEqual(new Range<DateTime>(new DateTime(2006, 7, 1, 20, 00, 00),
                                                new DateTime(2006, 7, 2, 04, 00, 00)),
                            preferences.DefaultDateTimeRange(overnight6pmTo6amShift));
        }

        [Test]
        public void ValidatePreShiftPaddingShouldEvaluateIfPaddingIsLessThanEqualLimit()
        {
            var preferences = new UserWorkPermitDefaultTimePreferences(UserFixture.CreateOperator().IdValue)
                                  {
                                      PreShiftPadding =
                                          Constants.WorkPermitTimePreferenceOffsetLimit.Subtract(OneMinute())
                                  };

            Assert.IsTrue(preferences.ValidatePreShiftPadding());

            preferences.PreShiftPadding = Constants.WorkPermitTimePreferenceOffsetLimit;
            Assert.IsTrue(preferences.ValidatePreShiftPadding());

            preferences.PreShiftPadding =
                Constants.WorkPermitTimePreferenceOffsetLimit.Add(OneMinute());
            Assert.IsFalse(preferences.ValidatePreShiftPadding());
        }
        
        [Test]
        public void ValidatePostShiftSubtractPaddingShouldEvaluateIfPaddingIsLessThanEqualLimit()
        {
            var preferences = new UserWorkPermitDefaultTimePreferences(UserFixture.CreateOperator().IdValue)
                                                                   {
                                                                       PostShiftPadding =
                                                                           Constants.WorkPermitTimePreferenceOffsetLimit
                                                                           .Subtract(OneMinute())
                                                                   };

            Assert.IsTrue(preferences.ValidatePostShiftPadding());

            preferences.PostShiftPadding = Constants.WorkPermitTimePreferenceOffsetLimit;
            Assert.IsTrue(preferences.ValidatePostShiftPadding());

            preferences.PostShiftPadding =
                Constants.WorkPermitTimePreferenceOffsetLimit.Add(OneMinute());
            Assert.IsFalse(preferences.ValidatePostShiftPadding());
        }

        private static TimeSpan OneMinute()
        {
            return new TimeSpan(00, 01, 00);
        }
    }
}
