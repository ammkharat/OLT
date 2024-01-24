using System;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [TestFixture]
    public class OnPremiseContractorTest
    {
        [Test]
        public void ShouldValidateShiftWithStartAndEndDates()
        {
            DateTime startDateTime;
            DateTime endDateTime;
            bool isDayShift;
            bool isNightShift;

            { // 1
                startDateTime = new DateTime(2013, 06, 20, 06, 30, 0);
                endDateTime = new DateTime(2013, 06, 20, 18, 30, 0);
                isDayShift = false;
                isNightShift = true;
                OnPremiseContractor onPremiseContractor = new OnPremiseContractor(null, null, string.Empty, string.Empty, startDateTime, endDateTime, isDayShift, isNightShift, string.Empty, string.Empty, String.Empty,
                    string.Empty, String.Empty, 0);

                bool datesContainsRequestedShifts = onPremiseContractor.DatesContainsRequestedShifts();
                Assert.That(datesContainsRequestedShifts, Is.False);
            }

            { // 2
                startDateTime = new DateTime(2013, 06, 20, 06, 30, 0);
                endDateTime = new DateTime(2013, 06, 20, 18, 30, 0);
                isDayShift = true;
                isNightShift = true;
                OnPremiseContractor onPremiseContractor = new OnPremiseContractor(null, null, string.Empty, string.Empty, startDateTime, endDateTime, isDayShift, isNightShift, string.Empty, string.Empty, String.Empty,
                    string.Empty, String.Empty, 0);

                bool datesContainsRequestedShifts = onPremiseContractor.DatesContainsRequestedShifts();
                Assert.That(datesContainsRequestedShifts, Is.False);
            }

            { // 3
                startDateTime = new DateTime(2013, 06, 20, 18, 30, 0);
                endDateTime = new DateTime(2013, 06, 21, 06, 30, 0);
                isDayShift = true;
                isNightShift = false;
                OnPremiseContractor onPremiseContractor = new OnPremiseContractor(null, null, string.Empty, string.Empty, startDateTime, endDateTime, isDayShift, isNightShift, string.Empty, string.Empty, String.Empty,
                    string.Empty, String.Empty, 0);

                bool datesContainsRequestedShifts = onPremiseContractor.DatesContainsRequestedShifts();
                Assert.That(datesContainsRequestedShifts, Is.False);
            }

            { // 4
                startDateTime = new DateTime(2013, 06, 20, 18, 30, 0);
                endDateTime = new DateTime(2013, 06, 21, 06, 30, 0);
                isDayShift = true;
                isNightShift = true;
                OnPremiseContractor onPremiseContractor = new OnPremiseContractor(null, null, string.Empty, string.Empty, startDateTime, endDateTime, isDayShift, isNightShift, string.Empty, string.Empty, String.Empty,
                    string.Empty, String.Empty, 0);

                bool datesContainsRequestedShifts = onPremiseContractor.DatesContainsRequestedShifts();
                Assert.That(datesContainsRequestedShifts, Is.False);
            }

            { // 5
                startDateTime = new DateTime(2013, 06, 20, 06, 30, 0);
                endDateTime = new DateTime(2013, 06, 21, 06, 30, 0);
                isDayShift = true;
                isNightShift = true;
                OnPremiseContractor onPremiseContractor = new OnPremiseContractor(null, null, string.Empty, string.Empty, startDateTime, endDateTime, isDayShift, isNightShift, string.Empty, string.Empty, String.Empty,
                    string.Empty, String.Empty, 0);

                bool datesContainsRequestedShifts = onPremiseContractor.DatesContainsRequestedShifts();
                Assert.That(datesContainsRequestedShifts, Is.True);
            }

            { // 6 
                startDateTime = new DateTime(2013, 06, 20, 18, 30, 0);
                endDateTime = new DateTime(2013, 06, 21, 05, 30, 0);
                isDayShift = false;
                isNightShift = true;
                OnPremiseContractor onPremiseContractor = new OnPremiseContractor(null, null, string.Empty, string.Empty, startDateTime, endDateTime, isDayShift, isNightShift, string.Empty, string.Empty, String.Empty,
                    string.Empty, String.Empty, 0);

                bool datesContainsRequestedShifts = onPremiseContractor.DatesContainsRequestedShifts();
                Assert.That(datesContainsRequestedShifts, Is.True);
            }

            { // 7
                startDateTime = new DateTime(2013, 06, 20, 20, 00, 0);
                endDateTime = new DateTime(2013, 06, 21, 05, 30, 0);
                isDayShift = false;
                isNightShift = true;
                OnPremiseContractor onPremiseContractor = new OnPremiseContractor(null, null, string.Empty, string.Empty, startDateTime, endDateTime, isDayShift, isNightShift, string.Empty, string.Empty, String.Empty,
                    string.Empty, String.Empty, 0);

                bool datesContainsRequestedShifts = onPremiseContractor.DatesContainsRequestedShifts();
                Assert.That(datesContainsRequestedShifts, Is.True);
            }

            { // 8
                startDateTime = new DateTime(2013, 06, 20, 11, 00, 0);
                endDateTime = new DateTime(2013, 06, 20, 17, 00, 0);
                isDayShift = true;
                isNightShift = false;
                OnPremiseContractor onPremiseContractor = new OnPremiseContractor(null, null, string.Empty, string.Empty, startDateTime, endDateTime, isDayShift, isNightShift, string.Empty, string.Empty, String.Empty,
                    string.Empty, String.Empty, 0);

                bool datesContainsRequestedShifts = onPremiseContractor.DatesContainsRequestedShifts();
                Assert.That(datesContainsRequestedShifts, Is.True);
            }

            { // 9
                startDateTime = new DateTime(2013, 06, 20, 20, 00, 0);
                endDateTime = new DateTime(2013, 06, 21, 16, 00, 0);
                isDayShift = true;
                isNightShift = true;
                OnPremiseContractor onPremiseContractor = new OnPremiseContractor(null, null, string.Empty, string.Empty, startDateTime, endDateTime, isDayShift, isNightShift, string.Empty, string.Empty, String.Empty,
                    string.Empty, String.Empty, 0);

                bool datesContainsRequestedShifts = onPremiseContractor.DatesContainsRequestedShifts();
                Assert.That(datesContainsRequestedShifts, Is.True);
            }

            { // 10
                startDateTime = new DateTime(2013, 06, 20, 05, 30, 0);
                endDateTime = new DateTime(2013, 06, 20, 18, 30, 0);
                isDayShift = true;
                isNightShift = true;
                OnPremiseContractor onPremiseContractor = new OnPremiseContractor(null, null, string.Empty, string.Empty, startDateTime, endDateTime, isDayShift, isNightShift, string.Empty, string.Empty, String.Empty,
                    string.Empty, String.Empty, 0);

                bool datesContainsRequestedShifts = onPremiseContractor.DatesContainsRequestedShifts();
                Assert.That(datesContainsRequestedShifts, Is.True);
            }
        }

        [Test]
        public void ShouldBeAbleToFigureOutIfUserCameFromCardSystemBasedOnFormat()
        {
            EdmontonPerson edmontonPerson = new EdmontonPerson(100, "Tommy", "John", "1000", Clock.Now, BadgeScanStatus.In);
            OnPremiseContractor onPremiseContractor = new OnPremiseContractor(1000, 100, edmontonPerson.DisplayString, string.Empty, Clock.Now, Clock.Now, true, false, string.Empty, string.Empty,
                string.Empty, string.Empty, string.Empty, 1);
            Assert.True(onPremiseContractor.IsFromCardSystem);
        }

        [Test]
        public void ShouldBeAbleToFigureOutThatUserDidNotComeFromCardSystem()
        {
            OnPremiseContractor onPremiseContractor = new OnPremiseContractor(1000, 100, "Tommy John", string.Empty, Clock.Now, Clock.Now, true, false, string.Empty, string.Empty,
                string.Empty, string.Empty, string.Empty, 1);
            Assert.False(onPremiseContractor.IsFromCardSystem);
        }
    }
}