using System;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Integration.Handlers.MessageObjects;
using log4net;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Integration.Handlers.Validators
{
    [TestFixture]
    public class NotificationValidatorTest
    {
        private NotificationDetails[] details;

        private ILog mockLogger;
        private NotificationValidator validator;

        [SetUp]
        public void SetUp()
        {
            mockLogger = MockRepository.GenerateStub<ILog>();

            validator = new NotificationValidator(mockLogger);
            details = new NotificationDetails[1];
            details[0] = new NotificationDetails();
        }

        [Test]
        public void ShouldParseNotificationFromXML()
        {
            const string testXml = @"<NotificationOLTData>
                <NotificationRecord>
                    <NotificationDetails>
                        <NotificationNumber>notification#</NotificationNumber>
                        <NotificationType>notification type</NotificationType>
                        <ShortText>short text</ShortText>
                        <FunctionalLocation>floc</FunctionalLocation>
                        <EquipmentNumber>equip</EquipmentNumber>
                        <CreateDate>2005-01-23</CreateDate>
                        <CreateTime>01:30:59</CreateTime>
                        <IncidentID>incidentid</IncidentID>
                        <LongText>long text</LongText>
                        <PlantID>4000</PlantID>
                        <Tasks>
                            <TaskCode>tcode</TaskCode>
                            <TaskCodeText>task code text</TaskCodeText>
                            <TaskText>task text</TaskText>
                            <Creator>creator</Creator>
                            <CreationDate>2005-01-24</CreationDate>
                            <PlannedStartDate>2005-01-25</PlannedStartDate>
                            <PlannedStartTime>02:30:59</PlannedStartTime>
                            <PlannedFinishDate>2005-01-26</PlannedFinishDate>
                            <PlannedFinishTime>03:30:59</PlannedFinishTime>
                            <ExceptionText>exception text</ExceptionText>
                            <ContactPerson>Contact Person</ContactPerson>
                        </Tasks>
                    </NotificationDetails>
                </NotificationRecord>
            </NotificationOLTData>";

            using (var memoryStream = testXml.CreateMemoryStream())
            {
                var notification = validator.Parse(memoryStream);
                var noficationDetails = notification.NotificationRecord.NotificationDetails;

                Assert.AreEqual(1, noficationDetails.Length);

                var detail = noficationDetails[0];
                Assert.AreEqual("notification#", detail.NotificationNumber);
                Assert.AreEqual("notification type", detail.NotificationType);
                Assert.AreEqual("short text", detail.ShortText);
                Assert.AreEqual("floc", detail.FunctionalLocation);
                Assert.AreEqual("equip", detail.EquipmentNumber);
                Assert.AreEqual("2005-01-23", detail.CreateDate);
                Assert.AreEqual("01:30:59", detail.CreateTime);
                Assert.AreEqual("incidentid", detail.IncidentID);
                Assert.AreEqual("long text", detail.LongText);
                Assert.AreEqual("4000", detail.PlantID);

                Assert.AreEqual(1, detail.Tasks.Length);
                var task = detail.Tasks[0];
                Assert.AreEqual("tcode", task.TaskCode);
                Assert.AreEqual("task code text", task.TaskCodeText);
                Assert.AreEqual("task text", task.TaskText);
                Assert.AreEqual("creator", task.Creator);
                Assert.AreEqual("2005-01-24", task.CreationDate);
                Assert.AreEqual("2005-01-25", task.PlannedStartDate);
                Assert.AreEqual("02:30:59", task.PlannedStartTime);
                Assert.AreEqual("2005-01-26", task.PlannedFinishDate);
                Assert.AreEqual("03:30:59", task.PlannedFinishTime);
                Assert.AreEqual("exception text", task.ExceptionText);
                Assert.AreEqual("Contact Person", task.ContactPerson);
            }
        }

        [Test]
        public void ShouldReturnFalseWithInvalidCreatedDate()
        {
            details[0].NotificationNumber = Constants.NOTIFICATION_NUMBER_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].NotificationType = Constants.NOTIFICATION_TYPE_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].ShortText = Constants.SHORT_TEXT_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].PlantID = Constants.PLANT_ID_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].FunctionalLocation = Constants.FLOC_FULL_HIERARCHY_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].EquipmentNumber = Constants.EQUIPMENT_NUMBER_MAX_LENGTH.CreateStringOfConsecutiveDigits();

            details[0].CreateDate = String.Empty;
            var result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);

            details[0].CreateDate = null;
            result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);

            details[0].CreateDate = (Constants.DATE_MAX_LENGTH + 1).CreateStringOfConsecutiveDigits();
            result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldReturnFalseWithInvalidCreatedTime()
        {
            details[0].NotificationNumber = Constants.NOTIFICATION_NUMBER_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].NotificationType = Constants.NOTIFICATION_TYPE_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].ShortText = Constants.SHORT_TEXT_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].PlantID = Constants.PLANT_ID_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].FunctionalLocation = Constants.FLOC_FULL_HIERARCHY_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].EquipmentNumber = Constants.EQUIPMENT_NUMBER_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].CreateDate = Constants.DATE_MAX_LENGTH.CreateStringOfConsecutiveDigits();

            details[0].CreateTime = String.Empty;
            var result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);

            details[0].CreateTime = null;
            result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);

            details[0].CreateTime = (Constants.TIME_MAX_LENGTH + 1).CreateStringOfConsecutiveDigits();
            result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldReturnFalseWithInvalidEquipmentNumber()
        {
            details[0].NotificationNumber = Constants.NOTIFICATION_NUMBER_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].NotificationType = Constants.NOTIFICATION_TYPE_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].ShortText = Constants.SHORT_TEXT_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].PlantID = Constants.PLANT_ID_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].FunctionalLocation = Constants.FLOC_FULL_HIERARCHY_MAX_LENGTH.CreateStringOfConsecutiveDigits();

            details[0].EquipmentNumber = String.Empty;
            var result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);

            details[0].EquipmentNumber = null;
            result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);

            details[0].EquipmentNumber = (Constants.EQUIPMENT_NUMBER_MAX_LENGTH + 1).CreateStringOfConsecutiveDigits();
            result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldReturnFalseWithInvalidFunctionalLocation()
        {
            details[0].NotificationNumber = Constants.NOTIFICATION_NUMBER_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].NotificationType = Constants.NOTIFICATION_TYPE_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].ShortText = Constants.SHORT_TEXT_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].PlantID = Constants.PLANT_ID_MAX_LENGTH.CreateStringOfConsecutiveDigits();

            details[0].FunctionalLocation = String.Empty;
            var result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);

            details[0].FunctionalLocation = null;
            result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);

            details[0].FunctionalLocation =
                (Constants.FLOC_FULL_HIERARCHY_MAX_LENGTH + 1).CreateStringOfConsecutiveDigits();
            result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldReturnFalseWithInvalidIncidentId()
        {
            details[0].NotificationNumber = Constants.NOTIFICATION_NUMBER_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].NotificationType = Constants.NOTIFICATION_TYPE_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].ShortText = Constants.SHORT_TEXT_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].PlantID = Constants.PLANT_ID_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].FunctionalLocation = Constants.FLOC_FULL_HIERARCHY_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].EquipmentNumber = Constants.EQUIPMENT_NUMBER_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].CreateDate = Constants.DATE_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].CreateTime = Constants.TIME_MAX_LENGTH.CreateStringOfConsecutiveDigits();

            details[0].IncidentID = String.Empty;
            var result = validator.DoesPassRequirementsCheck(details);
            Assert.IsTrue(result);

            details[0].IncidentID = null;
            result = validator.DoesPassRequirementsCheck(details);
            Assert.IsTrue(result);

            details[0].IncidentID = (Constants.INCIDENT_ID_MAX_LENGTH + 1).CreateStringOfConsecutiveDigits();
            result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldReturnFalseWithInvalidLongText()
        {
            details[0].NotificationNumber = Constants.NOTIFICATION_NUMBER_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].NotificationType = Constants.NOTIFICATION_TYPE_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].ShortText = Constants.SHORT_TEXT_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].PlantID = Constants.PLANT_ID_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].FunctionalLocation = Constants.FLOC_FULL_HIERARCHY_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].EquipmentNumber = Constants.EQUIPMENT_NUMBER_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].CreateDate = Constants.DATE_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].CreateTime = Constants.TIME_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].IncidentID = Constants.INCIDENT_ID_MAX_LENGTH.CreateStringOfConsecutiveDigits();

            details[0].LongText = String.Empty;
            var result = validator.DoesPassRequirementsCheck(details);
            Assert.IsTrue(result);

            details[0].LongText = null;
            result = validator.DoesPassRequirementsCheck(details);
            Assert.IsTrue(result);

            details[0].LongText = (Constants.LONG_TEXT_MAX_LENGTH + 1).CreateStringOfConsecutiveDigits();
            result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldReturnFalseWithInvalidNotificationNumber()
        {
            details[0].NotificationNumber = String.Empty;

            var result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);
            //string[] validatorErrors = validator.DoesPassRequirementsCheck(details);
            //Assert.IsTrue(validatorErrors.Length == 1);

            //details[0].NotificationNumber = null;
            //string[] validatorErrors = validator.DoesPassRequirementsCheck(details);
            //Assert.IsTrue(validatorErrors.Length == 1);
            result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);

            details[0].NotificationNumber =
                (Constants.NOTIFICATION_NUMBER_MAX_LENGTH + 1).CreateStringOfConsecutiveDigits();
            //string[] validatorErrors = validator.DoesPassRequirementsCheck(details);
            //Assert.IsTrue(validatorErrors.Length == 1);
            result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldReturnFalseWithInvalidNotificationType()
        {
            details[0].NotificationNumber = Constants.NOTIFICATION_NUMBER_MAX_LENGTH.CreateStringOfConsecutiveDigits();

            details[0].NotificationType = String.Empty;
            var result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);

            details[0].NotificationType = null;
            result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);

            details[0].NotificationType = (Constants.NOTIFICATION_TYPE_MAX_LENGTH + 1).CreateStringOfConsecutiveDigits();
            result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldReturnFalseWithInvalidPlantId()
        {
            details[0].NotificationNumber = Constants.NOTIFICATION_NUMBER_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].NotificationType = Constants.NOTIFICATION_TYPE_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].ShortText = Constants.SHORT_TEXT_MAX_LENGTH.CreateStringOfConsecutiveDigits();

            details[0].PlantID = String.Empty;
            var result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);

            details[0].PlantID = null;
            result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);

            details[0].PlantID = (Constants.PLANT_ID_MAX_LENGTH + 1).CreateStringOfConsecutiveDigits();
            result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldReturnFalseWithInvalidShortText()
        {
            details[0].NotificationNumber = Constants.NOTIFICATION_NUMBER_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].NotificationType = Constants.NOTIFICATION_TYPE_MAX_LENGTH.CreateStringOfConsecutiveDigits();

            details[0].ShortText = String.Empty;
            var result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);

            details[0].ShortText = null;
            result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);

            details[0].ShortText = (Constants.SHORT_TEXT_MAX_LENGTH + 1).CreateStringOfConsecutiveDigits();
            result = validator.DoesPassRequirementsCheck(details);
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldReturnTrue()
        {
            details[0].NotificationNumber = Constants.NOTIFICATION_NUMBER_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].NotificationType = Constants.NOTIFICATION_TYPE_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].ShortText = Constants.SHORT_TEXT_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].PlantID = Constants.PLANT_ID_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].FunctionalLocation = Constants.FLOC_FULL_HIERARCHY_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].EquipmentNumber = Constants.EQUIPMENT_NUMBER_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].CreateDate = Constants.DATE_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].CreateTime = Constants.TIME_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].IncidentID = Constants.INCIDENT_ID_MAX_LENGTH.CreateStringOfConsecutiveDigits();
            details[0].LongText = Constants.LONG_TEXT_MAX_LENGTH.CreateStringOfConsecutiveDigits();

            var result = validator.DoesPassRequirementsCheck(details);
            Assert.IsTrue(result);
        }
    }
}