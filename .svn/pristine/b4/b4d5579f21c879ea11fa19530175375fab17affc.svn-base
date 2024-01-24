using System;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Localization;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    /// <summary>
    /// Summary description for SAPNotificationTest
    /// </summary>
    [TestFixture]
    public class SAPNotificationTest
    {
        private SAPNotification sapNotification;
        private readonly User sapUser = UserFixture.CreateSupervisor();

        [SetUp]
        public void SetUp()
        {
            sapNotification = SAPNotificationFixture.GetAEmergencyIncidentFortMcMurrayNotification();
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void MustBeSerializeable()
        {
            Assert.IsTrue(typeof (SAPNotification).IsSerializable);
        }

        [Test]
        public void MustBeDerivedFromDomainObject()
        {
            Assert.IsTrue(sapNotification is DomainObject);
        }

        [Test]
        public void CreateLogFromNotificationShouldUseParameterDateTimeForTheLoggedDateTimeRatherThanTheNotificationDate()
        {
            DateTime loggedDateTime = new DateTime(2006, 04, 04 ,9, 0, 0);
            Log log = sapNotification.CreateLogFromNotification(
                sapUser, ShiftPatternFixture.CreateDayShift(), false, loggedDateTime, RoleFixture.CreateRole(), null);

            Assert.AreEqual(loggedDateTime, log.LogDateTime);
        }

        [Test]
        public void CreateLogFromNotificationShouldPopulateWorkAssignment()
        {
            DateTime loggedDateTime = new DateTime(2006, 04, 04 ,9, 0, 0);
            WorkAssignment workAssignment = WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData();

            Log log = sapNotification.CreateLogFromNotification(
                sapUser, ShiftPatternFixture.CreateDayShift(), false, loggedDateTime, RoleFixture.CreateRole(), workAssignment);

            Assert.AreEqual(workAssignment.IdValue, log.WorkAssignment.IdValue);
        }

        [Test]
        public void CreateLogFromNotificationShouldCreateWithMatchingFunctionalLocationUser()
        {
            DateTime loggedDateTime = new DateTime(2006, 04, 04, 9, 0, 0);

            Log log = sapNotification.CreateLogFromNotification(
                sapUser, ShiftPatternFixture.CreateDayShift(), false, loggedDateTime, RoleFixture.CreateRole(), null);

            Assert.AreEqual(1, log.FunctionalLocations.Count);
            Assert.AreEqual(sapNotification.FunctionalLocation, log.FunctionalLocations[0]);
            Assert.AreSame(sapUser, log.CreationUser);
            Assert.AreSame(sapUser, log.LastModifiedBy);
        }

        [Test]
        public void CreateLogFromNotificationShouldPopulateLogCommentsWithNotificationDetails()
        {
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();
            DateTime loggedDateTime = new DateTime(2006, 04, 04, 9, 0, 0);

            Log log = sapNotification.CreateLogFromNotification(
                sapUser, ShiftPatternFixture.CreateDayShift(), false, loggedDateTime, RoleFixture.CreateRole(), null);

            AssertStringContains(log.RtfComments, sapNotification.Description);
            AssertStringContains(log.RtfComments, "SAP Notification #: " + sapNotification.NotificationNumber);
            AssertStringContains(log.RtfComments, "Notification Type: " + sapNotification.NotificationType);
            AssertStringContains(log.RtfComments, "Incident Id: " + sapNotification.IncidentId);
            AssertStringContains(log.RtfComments, "Create Date/Time: Thu 02/02/2006 01:00");

            AssertStringContains(log.PlainTextComments, sapNotification.Description);
            AssertStringContains(log.PlainTextComments, "SAP Notification #: " + sapNotification.NotificationNumber);
            AssertStringContains(log.PlainTextComments, "Notification Type: " + sapNotification.NotificationType);
            AssertStringContains(log.PlainTextComments, "Incident Id: " + sapNotification.IncidentId);
            AssertStringContains(log.PlainTextComments, "Create Date/Time: Thu 02/02/2006 01:00");
        }

        private static void AssertStringContains(string s, string fragment)
        {
            StringAssert.Contains(fragment, s, "Fragment '" + fragment + "' not found in '" + s + "'");
        }
    }
}
