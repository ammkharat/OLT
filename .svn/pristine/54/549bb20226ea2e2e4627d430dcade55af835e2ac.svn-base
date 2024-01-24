using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class ShiftHandoverEmailConfigurationDaoTest : AbstractDaoTest
    {
        IShiftHandoverEmailConfigurationDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IShiftHandoverEmailConfigurationDao>();
        }

        protected override void Cleanup()
        {
            
        }

        [Ignore] [Test]
        public void ShouldInsertAndQueryBySiteId()
        {
            WorkAssignment workAssignment1 = WorkAssignmentFixture.GetEdmontonAssignmentThatIsReallyInTheDatabaseTestData();
            WorkAssignment workAssignment2 = WorkAssignmentFixture.GetAnotherEdmontonAssignmentThatIsReallyInTheDatabaseTestData();

            long assignmentId1 = workAssignment1.IdValue;
            long assignmentId2 = workAssignment2.IdValue;

            long? configurationId;

            Time sendTime = new Time(4, 30);

            {
                List<EmailAddress> emails = new List<EmailAddress> { new EmailAddress("ricky@silverspoons.com"), new EmailAddress("bill@cosbyshow.com"), new EmailAddress("punky@punkybrewster.biz")};
                List<WorkAssignment> assignments = new List<WorkAssignment> { workAssignment1, workAssignment2 };

                ShiftHandoverEmailConfiguration configuration = GetConfiguration(sendTime, emails, assignments);
                dao.Insert(configuration);
                configurationId = configuration.IdValue;
            }

            List<ShiftHandoverEmailConfiguration> configurations = dao.QueryBySiteId(SiteFixture.Edmonton().IdValue);

            ShiftHandoverEmailConfiguration requeriedConfiguration = configurations.FindById(configurationId);
            Assert.IsNotNull(requeriedConfiguration);
            Assert.IsTrue(requeriedConfiguration.WorkAssignments.Exists(wa => wa.IdValue == assignmentId1));
            Assert.IsTrue(requeriedConfiguration.WorkAssignments.Exists(wa => wa.IdValue == assignmentId2));            

            Assert.IsNotNull(requeriedConfiguration.Schedule.Id);
            Assert.AreEqual(sendTime, requeriedConfiguration.Schedule.StartTime);
        }

        [Ignore] [Test]
        public void ShouldUpdate()
        {
            WorkAssignment workAssignment1 = WorkAssignmentFixture.GetEdmontonAssignmentThatIsReallyInTheDatabaseTestData();
            WorkAssignment workAssignment2 = WorkAssignmentFixture.GetAnotherEdmontonAssignmentThatIsReallyInTheDatabaseTestData();

            long? configurationId;

            Time sendTime = new Time(4, 30);

            {
                List<EmailAddress> emails = new List<EmailAddress> { new EmailAddress("ricky@silverspoons.com"), new EmailAddress("bill@cosbyshow.com"), new EmailAddress("punky@punkybrewster.biz") };
                List<WorkAssignment> assignments = new List<WorkAssignment> { workAssignment1, workAssignment2 };

                ShiftHandoverEmailConfiguration configuration = GetConfiguration(sendTime, emails, assignments);
                dao.Insert(configuration);
                configurationId = configuration.IdValue;
            }

            {
                ShiftHandoverEmailConfiguration configuration = dao.QueryBySiteId(Site.EDMONTON_ID).Find(j => j.IdValue == configurationId);
                Time newSendTime = configuration.EmailSendTime.AddHours(2);
                ShiftPattern newShift = ShiftPatternFixture.CreateEdmontonNightShift();
                List<EmailAddress> newEmails = new List<EmailAddress> { new EmailAddress("ricky@silverspoons.com"), new EmailAddress("punky@punkybrewster.biz"), new EmailAddress("deedee@theramones.ny") };
                List<WorkAssignment> newAssignments = new List<WorkAssignment> { WorkAssignmentFixture.GetYetAnotherEdmontonAssignmentThatIsReallyInTheDatabaseTestData() };

                configuration.ShiftPattern = newShift;
                configuration.EmailSendTime = newSendTime;
                configuration.EmailAddresses = newEmails;
                configuration.WorkAssignments = newAssignments;

                dao.Update(configuration);

                ShiftHandoverEmailConfiguration updatedConfiguration = dao.QueryBySiteId(Site.EDMONTON_ID).Find(j => j.IdValue == configurationId);
                Assert.AreEqual(newShift.IdValue, updatedConfiguration.ShiftPattern.IdValue);
                Assert.AreEqual(newSendTime, updatedConfiguration.EmailSendTime);
                AssertEmailListIsSame(newEmails, updatedConfiguration.EmailAddresses);
                AssertWorkAssignmentListIsSame(newAssignments, updatedConfiguration.WorkAssignments);
            }
           
        }

        private void AssertWorkAssignmentListIsSame(List<WorkAssignment> newAssignments, List<WorkAssignment> workAssignments)
        {
            Assert.AreEqual(newAssignments.Count, workAssignments.Count);

            foreach (WorkAssignment workAssignment in newAssignments)
            {
                Assert.IsTrue(workAssignments.Exists(wa => wa.IdValue == workAssignment.IdValue));
            }
        }

        private void AssertEmailListIsSame(List<EmailAddress> newEmails, List<EmailAddress> emailAddresses)
        {
            Assert.AreEqual(newEmails.Count, emailAddresses.Count);

            foreach (EmailAddress emailAddress in newEmails)
            {
                Assert.IsTrue(emailAddresses.Exists(e => e.ToString().Equals(emailAddress.ToString())));
            }
        }

        [Ignore] [Test]
        public void ShouldDelete()
        {
            WorkAssignment workAssignment1 = WorkAssignmentFixture.GetEdmontonAssignmentThatIsReallyInTheDatabaseTestData();
            WorkAssignment workAssignment2 = WorkAssignmentFixture.GetAnotherEdmontonAssignmentThatIsReallyInTheDatabaseTestData();

            long? configurationId;

            ShiftHandoverEmailConfiguration configuration;
            Time sendTime = new Time(4, 30);

            {
                List<EmailAddress> emails = new List<EmailAddress> { new EmailAddress("ricky@silverspoons.com"), new EmailAddress("bill@cosbyshow.com"), new EmailAddress("punky@punkybrewster.biz") };
                List<WorkAssignment> assignments = new List<WorkAssignment> { workAssignment1, workAssignment2 };

                configuration = GetConfiguration(sendTime, emails, assignments);
                dao.Insert(configuration);
                configurationId = configuration.IdValue;
            }

            dao.Delete(configuration);

            List<ShiftHandoverEmailConfiguration> configurations = dao.QueryBySiteId(Site.EDMONTON_ID);
            Assert.IsFalse(configurations.Exists(c => c.IdValue == configurationId));
        }

        [Ignore] [Test]
        public void ShouldQueryById()
        {
            WorkAssignment workAssignment = WorkAssignmentFixture.GetEdmontonAssignmentThatIsReallyInTheDatabaseTestData();

            List<EmailAddress> emails = new List<EmailAddress> { new EmailAddress("ricky@silverspoons.com") };
            List<WorkAssignment> assignments = new List<WorkAssignment> { workAssignment };
            Time sendTime = new Time(4, 30);

            ShiftHandoverEmailConfiguration configuration = GetConfiguration(sendTime, emails, assignments);
            dao.Insert(configuration);

            ShiftHandoverEmailConfiguration requeriedConfiguration = dao.QueryById(configuration.IdValue);
            Assert.AreEqual(configuration.IdValue, requeriedConfiguration.IdValue);
            Assert.AreEqual(configuration.EmailSendTime, requeriedConfiguration.EmailSendTime);
            Assert.AreEqual(configuration.EmailAddressesAsDelimitedString, requeriedConfiguration.EmailAddressesAsDelimitedString);
        }

        private ShiftHandoverEmailConfiguration GetConfiguration(Time sendTime, List<EmailAddress> emails, List<WorkAssignment> assignments)
        {
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateEdmontonDayShift();
            return new ShiftHandoverEmailConfiguration(shiftPattern, sendTime, emails, assignments, SiteFixture.Edmonton());
        }
    }
}
