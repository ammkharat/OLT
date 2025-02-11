using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Integration.Handlers;
using Com.Suncor.Olt.Integration.HTTPHandlers.Fixtures;
using Com.Suncor.Olt.Integration.HTTPHandlers.Utilities;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.HTTPHandlers
{
    [TestFixture]
    [Category("Integration")]
    public class NotificationFunctionalTest
    {
        [Test][Ignore]
        public void SendActionItemNotification()
        {
            var msg = NotificationFixture.CreateNotificationThatBecomesAnActionItem().CreateMessage();
            var sender = new MessageSender();

            var response = sender.SyncSubmit(msg, Constants.NOTIFICATION_URL);
            Assert.AreEqual("<OK/>", response);
        }

        [Test][Ignore]
        public void SendActionItemNotificationAgainstFirstLevelFloc()
        {
            var msg = NotificationFixture.CreateNotificationThatBecomesAnActionItem("SR1").CreateMessage();
            var sender = new MessageSender();

            var response = sender.SyncSubmit(msg, Constants.NOTIFICATION_URL);
            Assert.AreEqual("<OK/>", response);
        }

        [Test][Ignore]
        public void SendAmNotification()
        {
            var msg = NotificationFixture.CreateAMNotification().CreateMessage();
            var sender = new MessageSender();

            var response = sender.SyncSubmit(msg, Constants.NOTIFICATION_URL);
            Assert.AreEqual("<OK/>", response);
        }

        [Test][Ignore]
        public void SendEINotificationForDenver()
        {
            var functionalLocation = FunctionalLocationFixture.CreateNew("DN1-3003-0000");
            functionalLocation.Site = SiteFixture.Denver();
            var msg = NotificationFixture.CreateEINotification(functionalLocation, "7000").CreateMessage();
            var sender = new MessageSender();

            var response = sender.SyncSubmit(msg, Constants.NOTIFICATION_URL);
            Assert.AreEqual("<OK/>", response);
        }

        [Test][Ignore]
        public void SendEINotificationForSarnia()
        {
            var msg = NotificationFixture.CreateEINotification().CreateMessage();
            var sender = new MessageSender();

            var response = sender.SyncSubmit(msg, Constants.NOTIFICATION_URL);
            Assert.AreEqual("<OK/>", response);
        }

        [Test][Ignore]
        public void SendValidAmNotification()
        {
            var msg = NotificationFixture.CreateAMNotification().CreateMessage();
            var sender = new MessageSender();

            var response = sender.SyncSubmit(msg, Constants.NOTIFICATION_URL);
            Assert.AreEqual("<OK/>", response);
        }

        [Test][Ignore]
        public void ShouldAcceptFrenchCharacters()
        {
            var notificationSapData = NotificationFixture.CreateEINotification();
            notificationSapData.LongText = "CONTRÔLE-KN1 ÇĈâďèéàáŌ";
            var message = notificationSapData.CreateMessage();

            var sender = new MessageSender();
            var response = sender.SyncSubmit(message, Constants.NOTIFICATION_URL);

            Assert.AreEqual("<OK/>", response);
        }
    }
}