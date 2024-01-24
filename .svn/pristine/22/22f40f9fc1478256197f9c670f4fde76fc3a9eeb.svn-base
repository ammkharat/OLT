using Com.Suncor.Olt.Integration.Handlers.Adapters;
using Com.Suncor.Olt.Integration.Handlers.Fixtures;
using Com.Suncor.Olt.Integration.Handlers.MessageObjects;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Handlers
{
    [TestFixture]
    public class MsgHandlerOtherTests
    {
        private NotificationDetails notificationDetail;
        private Tasks notificationTask;

        [SetUp]
        public void SetUp()
        {
            notificationDetail = NotificationDetailFixture.GetEmergencyIncident();
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void BuildNotificationDescriptionShouldReturnADescription()
        {
            var description = NotificationAdapter.BuildNotificationDescription(notificationDetail);

            StringAssert.Contains(notificationDetail.NotificationNumber, description);
            StringAssert.Contains(notificationDetail.ShortText, description);
            StringAssert.Contains(notificationDetail.EquipmentNumber, description);
            StringAssert.Contains(notificationDetail.CreateDate, description);
            StringAssert.Contains(notificationDetail.CreateTime, description);
            StringAssert.Contains(notificationDetail.IncidentID, description);
            StringAssert.Contains(notificationDetail.LongText, description);
        }


        [Test]
        public void BuildNotificationTaskDescriptionShouldReturnADescription()
        {
            notificationTask = NotificationDetailFixture.GetTask();
            var description = NotificationAdapter.BuildNotificationTaskDescription(notificationTask);

            StringAssert.Contains(notificationTask.TaskCode, description);
            StringAssert.Contains(notificationTask.TaskCodeText, description);
            StringAssert.Contains(notificationTask.TaskText, description);
            StringAssert.Contains(notificationTask.Creator, description);
            StringAssert.Contains(notificationTask.CreationDate, description);
            StringAssert.Contains(notificationTask.PlannedStartDate, description);
            StringAssert.Contains(notificationTask.PlannedStartTime, description);
            StringAssert.Contains(notificationTask.PlannedFinishDate, description);
            StringAssert.Contains(notificationTask.PlannedFinishTime, description);
            StringAssert.Contains(notificationTask.ExceptionText, description);
            StringAssert.Contains(notificationTask.ContactPerson, description);
        }
    }
}