using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Security
{
    [TestFixture]
    public class DeviationAlertAuthorizationTest
    {
        private static void AssertCheckAuthorizedToRespond(
            bool expected,
            DeviationAlertStatus status,
            Time shiftStart,
            Time shiftEnd,
            IEnumerable<RoleElement> roleElements)
        {
            UserShift shift = UserShiftFixture.CreateUserShift(shiftStart, shiftEnd, new Date(2010, 3, 20));
            DeviationAlertDTO alert = DeviationAlertDTOFixture.Create(status, new DateTime(2010, 3, 20, 10, 0, 0));

            Authorized authorized = new Authorized();
            Assert.AreEqual(expected, authorized.ToRespondToDeviationAlerts(new UserRoleElements(RoleFixture.CreateSupervisorRole(), roleElements), shift, alert));
        }

        [Test]
        public void ShouldCheckAuthorizedToRespondToAlertInShift()
        {
            AssertCheckAuthorizedToRespond(
                true, DeviationAlertStatus.RequiresResponse,
                new Time(9), new Time(12),
                new List<RoleElement> { RoleElement.RESPOND_TO_DEVIATION_IN_SHIFT });
            AssertCheckAuthorizedToRespond(
                false, DeviationAlertStatus.Responded,
                new Time(9), new Time(12),
                new List<RoleElement> { RoleElement.RESPOND_TO_DEVIATION_IN_SHIFT });

            AssertCheckAuthorizedToRespond(
                false, DeviationAlertStatus.RequiresResponse,
                new Time(9), new Time(10),
                new List<RoleElement> { RoleElement.RESPOND_TO_DEVIATION_IN_SHIFT });
            AssertCheckAuthorizedToRespond(
                true, DeviationAlertStatus.RequiresResponse,
                new Time(9), new Time(11),
                new List<RoleElement> { RoleElement.RESPOND_TO_DEVIATION_IN_SHIFT });
            AssertCheckAuthorizedToRespond(
                true, DeviationAlertStatus.RequiresResponse,
                new Time(10), new Time(12),
                new List<RoleElement> { RoleElement.RESPOND_TO_DEVIATION_IN_SHIFT });
            AssertCheckAuthorizedToRespond(
                true, DeviationAlertStatus.RequiresResponse,
                new Time(11), new Time(12),
                new List<RoleElement> { RoleElement.RESPOND_TO_DEVIATION_IN_SHIFT });
            AssertCheckAuthorizedToRespond(
                true, DeviationAlertStatus.RequiresResponse,
                new Time(11), new Time(11),
                new List<RoleElement> { RoleElement.RESPOND_TO_DEVIATION_IN_SHIFT });
            AssertCheckAuthorizedToRespond(
                false, DeviationAlertStatus.RequiresResponse,
                new Time(12), new Time(13),
                new List<RoleElement> { RoleElement.RESPOND_TO_DEVIATION_IN_SHIFT });
        }

        [Test]
        public void ShouldCheckAuthorizedToRespondToAlertOutOfShift()
        {
            AssertCheckAuthorizedToRespond(
                true, DeviationAlertStatus.RequiresResponse,
                new Time(8), new Time(9),
                new List<RoleElement> { RoleElement.RESPOND_TO_DEVIATION_OUT_OF_SHIFT });
            AssertCheckAuthorizedToRespond(
                false, DeviationAlertStatus.Responded,
                new Time(8), new Time(9),
                new List<RoleElement> { RoleElement.RESPOND_TO_DEVIATION_OUT_OF_SHIFT });

            AssertCheckAuthorizedToRespond(
                true, DeviationAlertStatus.RequiresResponse,
                new Time(8), new Time(10),
                new List<RoleElement> { RoleElement.RESPOND_TO_DEVIATION_OUT_OF_SHIFT });
            AssertCheckAuthorizedToRespond(
                false, DeviationAlertStatus.RequiresResponse,
                new Time(8), new Time(11),
                new List<RoleElement> { RoleElement.RESPOND_TO_DEVIATION_OUT_OF_SHIFT });
            AssertCheckAuthorizedToRespond(
                false, DeviationAlertStatus.RequiresResponse,
                new Time(8), new Time(12),
                new List<RoleElement> { RoleElement.RESPOND_TO_DEVIATION_OUT_OF_SHIFT });

            AssertCheckAuthorizedToRespond(
                false, DeviationAlertStatus.RequiresResponse,
                new Time(10), new Time(14),
                new List<RoleElement> { RoleElement.RESPOND_TO_DEVIATION_OUT_OF_SHIFT });

            // This test makes no sense because the code will never check for "out of shift" Role Element in this case.
            AssertCheckAuthorizedToRespond(
                false, DeviationAlertStatus.RequiresResponse,
                new Time(11), new Time(14),
                new List<RoleElement> { RoleElement.RESPOND_TO_DEVIATION_OUT_OF_SHIFT });
            AssertCheckAuthorizedToRespond(
                true, DeviationAlertStatus.RequiresResponse,
                new Time(12), new Time(14),
                new List<RoleElement> { RoleElement.RESPOND_TO_DEVIATION_OUT_OF_SHIFT });

            // This test makes no sense because the code will never check for "out of shift" Role Element in this case.
            AssertCheckAuthorizedToRespond(
                false, DeviationAlertStatus.RequiresResponse,
                new Time(11), new Time(11),
                new List<RoleElement> { RoleElement.RESPOND_TO_DEVIATION_OUT_OF_SHIFT });
        }

        [Test]
        public void ShouldCheckAuthorizedToEditResponseInShift()
        {
            AssertCheckAuthorizedToRespond(
                true, DeviationAlertStatus.Responded,
                new Time(9), new Time(12),
                new List<RoleElement> { RoleElement.EDIT_DEVIATION_RESPONSE_FOR_ALERT_IN_SHIFT });
            AssertCheckAuthorizedToRespond(
                false, DeviationAlertStatus.RequiresResponse,
                new Time(9), new Time(12),
                new List<RoleElement> { RoleElement.EDIT_DEVIATION_RESPONSE_FOR_ALERT_IN_SHIFT });

            AssertCheckAuthorizedToRespond(
                false, DeviationAlertStatus.Responded,
                new Time(9), new Time(10),
                new List<RoleElement> { RoleElement.EDIT_DEVIATION_RESPONSE_FOR_ALERT_IN_SHIFT });
            AssertCheckAuthorizedToRespond(
                true, DeviationAlertStatus.Responded,
                new Time(9), new Time(11),
                new List<RoleElement> { RoleElement.EDIT_DEVIATION_RESPONSE_FOR_ALERT_IN_SHIFT });
            AssertCheckAuthorizedToRespond(
                true, DeviationAlertStatus.Responded,
                new Time(10), new Time(12),
                new List<RoleElement> { RoleElement.EDIT_DEVIATION_RESPONSE_FOR_ALERT_IN_SHIFT });
            AssertCheckAuthorizedToRespond(
                true, DeviationAlertStatus.Responded,
                new Time(11), new Time(12),
                new List<RoleElement> { RoleElement.EDIT_DEVIATION_RESPONSE_FOR_ALERT_IN_SHIFT });
            AssertCheckAuthorizedToRespond(
                true, DeviationAlertStatus.Responded,
                new Time(11), new Time(11),
                new List<RoleElement> { RoleElement.EDIT_DEVIATION_RESPONSE_FOR_ALERT_IN_SHIFT });
            AssertCheckAuthorizedToRespond(
                false, DeviationAlertStatus.Responded,
                new Time(12), new Time(13),
                new List<RoleElement> { RoleElement.EDIT_DEVIATION_RESPONSE_FOR_ALERT_IN_SHIFT });
        }

        [Test]
        public void ShouldCheckAuthorizedToEditResponseOutsideOfShift()
        {
            AssertCheckAuthorizedToRespond(
                true, DeviationAlertStatus.Responded,
                new Time(8), new Time(9),
                new List<RoleElement> { RoleElement.EDIT_DEVIATION_RESPONSE_FOR_ALERT_OUT_OF_SHIFT });
            AssertCheckAuthorizedToRespond(
                false, DeviationAlertStatus.RequiresResponse,
                new Time(8), new Time(9),
                new List<RoleElement> { RoleElement.EDIT_DEVIATION_RESPONSE_FOR_ALERT_OUT_OF_SHIFT });

            AssertCheckAuthorizedToRespond(
                true, DeviationAlertStatus.Responded,
                new Time(8), new Time(10),
                new List<RoleElement> { RoleElement.EDIT_DEVIATION_RESPONSE_FOR_ALERT_OUT_OF_SHIFT });
            AssertCheckAuthorizedToRespond(
                false, DeviationAlertStatus.Responded,
                new Time(8), new Time(11),
                new List<RoleElement> { RoleElement.EDIT_DEVIATION_RESPONSE_FOR_ALERT_OUT_OF_SHIFT });
            AssertCheckAuthorizedToRespond(
                false, DeviationAlertStatus.Responded,
                new Time(8), new Time(12),
                new List<RoleElement> { RoleElement.EDIT_DEVIATION_RESPONSE_FOR_ALERT_OUT_OF_SHIFT });

            // This test makes no sense because the code will never check for "out of shift" Role Element in this case.
            AssertCheckAuthorizedToRespond(
                false, DeviationAlertStatus.Responded,
                new Time(10), new Time(14),
                new List<RoleElement> { RoleElement.EDIT_DEVIATION_RESPONSE_FOR_ALERT_OUT_OF_SHIFT });

            // This test makes no sense because the code will never check for "out of shift" Role Element in this case.
            AssertCheckAuthorizedToRespond(
                false, DeviationAlertStatus.Responded,
                new Time(11), new Time(14),
                new List<RoleElement> { RoleElement.EDIT_DEVIATION_RESPONSE_FOR_ALERT_OUT_OF_SHIFT });
            AssertCheckAuthorizedToRespond(
                true, DeviationAlertStatus.Responded,
                new Time(12), new Time(14),
                new List<RoleElement> { RoleElement.EDIT_DEVIATION_RESPONSE_FOR_ALERT_OUT_OF_SHIFT });

            // This test makes no sense because the code will never check for "out of shift" Role Element in this case.
            AssertCheckAuthorizedToRespond(
                false, DeviationAlertStatus.Responded,
                new Time(11), new Time(11),
                new List<RoleElement> { RoleElement.EDIT_DEVIATION_RESPONSE_FOR_ALERT_OUT_OF_SHIFT });
        }
    }
}
