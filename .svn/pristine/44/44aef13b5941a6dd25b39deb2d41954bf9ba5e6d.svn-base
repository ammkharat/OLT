using System;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [TestFixture]
    public class TargetAlertResponseTest
    {
        private User currentUser;
        private Role currentRole;
        private string responseText;
        private TargetAlert alert;
        private ShiftPattern targetResponseShiftPattern;

        [SetUp]
        public void SetUp()
        {
            currentUser = UserFixture.CreateUser();
            currentRole = RoleFixture.CreateRole();
            responseText = TestUtil.RandomString();
            targetResponseShiftPattern = ShiftPatternFixture.Create6am_8hour_DayShift();
            
            alert = CreateTargetAlertRequiringResponse();
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void ShouldcreateCommentWhenCreatingResponse()
        {
            DateTime now = DateTimeFixture.DateTimeNow;
            TargetAlertResponse response = alert.CreateResponse(currentUser, responseText, now, targetResponseShiftPattern);
            Assert.AreEqual(currentUser, response.ResponseComment.CreatedBy);
            Assert.AreEqual(now, response.ResponseComment.CreatedDate);
            Assert.AreEqual(responseText, response.ResponseComment.Text);
        }

        [Test]
        public void ShouldCreateLogForResponseWithReason()
        {
            DateTime now = new DateTime(2006, 1, 20, 5, 0, 0);

            ShiftPattern shiftPattern = ShiftPatternFixture.CreateShiftPattern(new Time(1, 0, 0), new Time(6, 0, 0));
            WorkAssignment workAssignment = WorkAssignmentFixture.CreateConsoleOperator(1);

            // Execute:
            TargetAlertResponse response = alert.CreateResponse(currentUser, responseText, now, targetResponseShiftPattern);
            TargetGapReason gapReason = TargetGapReason.EquipmentFailure;
            response.GapReason = gapReason;
            Log log = response.CreateLog(currentUser, false, shiftPattern, now, currentRole, workAssignment);

            StringAssert.Contains(gapReason.Name, log.RtfComments);
            StringAssert.Contains(alert.Id.ToString(), log.RtfComments);
            StringAssert.Contains(responseText, log.RtfComments);

            StringAssert.Contains(gapReason.Name, log.PlainTextComments);
            StringAssert.Contains(alert.Id.ToString(), log.PlainTextComments);
            StringAssert.Contains(responseText, log.PlainTextComments);

            Assert.AreEqual(1, log.FunctionalLocations.Count);
            Assert.AreEqual(alert.FunctionalLocation.Id, log.FunctionalLocations[0].Id);

            Assert.AreEqual(currentUser, log.CreationUser);
            Assert.AreEqual(now, log.LogDateTime);
            Assert.AreEqual(currentUser, log.LastModifiedBy);
            Assert.AreEqual(now, log.LastModifiedDate);
            Assert.AreEqual(workAssignment, log.WorkAssignment);
        }

        [Test]
        public void ShouldCreateLogForResponseWithNoReason()
        {
            DateTime now = new DateTime(2006, 1, 20, 5, 0, 0);
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateShiftPattern(new Time(1, 0, 0), new Time(6, 0, 0), now);
            // Execute:
            TargetAlertResponse response = alert.CreateResponse(currentUser, responseText, now, targetResponseShiftPattern);
            response.GapReason = null;
            Log log = response.CreateLog(currentUser, false, shiftPattern, now, currentRole, null);

            StringAssert.Contains(alert.Id.ToString(), log.RtfComments);
            StringAssert.Contains(responseText, log.RtfComments);

            StringAssert.Contains(alert.Id.ToString(), log.PlainTextComments);
            StringAssert.Contains(responseText, log.PlainTextComments);
        }

        private static TargetAlert CreateTargetAlertRequiringResponse()
        {
            TargetAlert targetAlert = TargetAlertFixture.CreateATargetAlert();
            targetAlert.RequiresResponse = true;
            targetAlert.Status = TargetAlertStatus.StandardAlert;
            return targetAlert;
        }
    }
}
