using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.DTO
{
    [TestFixture]
    public class DeviationAlertDTOTest
    {
        [Test]
        public void ShouldCalculateDeviationValue()
        {
            DeviationAlertDTO dto = new DeviationAlertDTO(null, null, null, 40, 60, DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow, null, null, null, null, 
                null, 1, DeviationAlertStatus.RequiresResponse, false, 1, DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow);
            Assert.AreEqual(20, dto.DeviationValue);

            dto = new DeviationAlertDTO(null, null, null, null, null, DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow, null, null, null, null,
                null, 1, DeviationAlertStatus.RequiresResponse, false, 1, DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow);
            Assert.AreEqual(0, dto.DeviationValue);

            dto = new DeviationAlertDTO(null, null, null, null, 60, DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow, null, null, null, null,
                null, 1, DeviationAlertStatus.RequiresResponse, false, 1, DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow);
            Assert.AreEqual(60, dto.DeviationValue);

            dto = new DeviationAlertDTO(null, null, null, 40, null, DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow, null, null, null, null,
                null, 1, DeviationAlertStatus.RequiresResponse, false, 1, DateTimeFixture.DateTimeNow, DateTimeFixture.DateTimeNow);
            Assert.AreEqual(-40, dto.DeviationValue);
        }

        [Test]
        public void ShouldGetStatusBasedOnShift()
        {
            UserShift shift = UserShiftFixture.CreateUserShift(new Time(4), new Time(6));

            DateTime alertStart = shift.StartDateTime.AddYears(-10);
            DateTime shiftStart = shift.StartDateTime;
            DateTime shiftEnd = shift.EndDateTime;

            {
                AssertGetStatusBasedOnShift(DeviationAlertStatus.Responded,
                                            DeviationAlertStatus.Responded, alertStart, shiftStart, shift);
                AssertGetStatusBasedOnShift(DeviationAlertStatus.Responded,
                                            DeviationAlertStatus.Responded, alertStart, shiftStart.AddMilliseconds(-1), shift);
                AssertGetStatusBasedOnShift(DeviationAlertStatus.Responded,
                                            DeviationAlertStatus.Responded, alertStart, shiftStart.AddMilliseconds(1), shift);
                AssertGetStatusBasedOnShift(DeviationAlertStatus.Responded,
                                            DeviationAlertStatus.Responded, alertStart, shiftEnd, shift);
                AssertGetStatusBasedOnShift(DeviationAlertStatus.Responded,
                                            DeviationAlertStatus.Responded, alertStart, shiftEnd.AddMilliseconds(-1), shift);
                AssertGetStatusBasedOnShift(DeviationAlertStatus.Responded,
                                            DeviationAlertStatus.Responded, alertStart, shiftEnd.AddMilliseconds(1), shift);
            }
            {
                AssertGetStatusBasedOnShift(DeviationAlertStatus.RequiresResponseIsLate,
                                            DeviationAlertStatus.RequiresResponse, alertStart, shiftStart, shift);
                AssertGetStatusBasedOnShift(DeviationAlertStatus.RequiresResponseIsLate,
                                            DeviationAlertStatus.RequiresResponse, alertStart, shiftStart.AddMilliseconds(-1), shift);
                AssertGetStatusBasedOnShift(DeviationAlertStatus.RequiresResponse,
                                            DeviationAlertStatus.RequiresResponse, alertStart, shiftStart.AddMilliseconds(1), shift);
                AssertGetStatusBasedOnShift(DeviationAlertStatus.RequiresResponse,
                                            DeviationAlertStatus.RequiresResponse, alertStart, shiftEnd, shift);
                AssertGetStatusBasedOnShift(DeviationAlertStatus.RequiresResponse,
                                            DeviationAlertStatus.RequiresResponse, alertStart, shiftEnd.AddMilliseconds(-1), shift);
                AssertGetStatusBasedOnShift(DeviationAlertStatus.RequiresResponse,
                                            DeviationAlertStatus.RequiresResponse, alertStart, shiftEnd.AddMilliseconds(1), shift);
            }
        }

        private static void AssertGetStatusBasedOnShift(
            DeviationAlertStatus expectedStatus, DeviationAlertStatus alertStatus, DateTime alertStartTime, DateTime alertEndTime, UserShift shift)
        {
            DeviationAlertDTO dto = DeviationAlertDTOFixture.Create(alertStatus, alertStartTime, alertEndTime);
            DeviationAlertStatus status = dto.GetStatus(shift);
            Assert.AreEqual(expectedStatus, status);
        }
    }
}
