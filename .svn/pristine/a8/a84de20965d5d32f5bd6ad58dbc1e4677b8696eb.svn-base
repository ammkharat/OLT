using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class PriorityPageSectionConfigurationDaoTest : AbstractDaoTest
    {
        private IPriorityPageSectionConfigurationDao configurationDao;                
        private IWorkAssignmentDao workAssignmentDao;


        protected override void TestInitialize()
        {
            configurationDao = DaoRegistry.GetDao<IPriorityPageSectionConfigurationDao>();            
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
        }

        protected override void Cleanup()
        {
        
        }

        [Ignore] [Test]
        public void ShouldInsertAndFindAgain()
        {
            WorkAssignment wa1 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateEdmontonWorkAssignmentToBeInsertedInDatabase("WA 1"));
            WorkAssignment wa2 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateEdmontonWorkAssignmentToBeInsertedInDatabase("WA 2"));
            WorkAssignment wa3 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateEdmontonWorkAssignmentToBeInsertedInDatabase("WA 3"));

            List<WorkAssignment> assignments = new List<WorkAssignment> { wa1, wa2, wa3 };

            User createUser = UserFixture.CreateUserWithGivenId(1);            
            DateTime modifiedDateTime = new DateTime(2014, 1, 27);

            PriorityPageSectionConfiguration sectionConfiguration = new PriorityPageSectionConfiguration(PriorityPageSectionKey.Directive, createUser, true, assignments, modifiedDateTime);

            configurationDao.Insert(sectionConfiguration);

            {
                List<PriorityPageSectionConfiguration> retrivedConfigurations = configurationDao.QueryByUserId(createUser.IdValue);

                PriorityPageSectionConfiguration retrievedConfiguration = retrivedConfigurations.Find(c => c.SectionKey.Equals(PriorityPageSectionKey.Directive) && c.User.IdValue == createUser.IdValue);
                Assert.IsNotNull(retrievedConfiguration);  

                Assert.AreEqual(3, retrievedConfiguration.WorkAssignments.Count);
                Assert.IsTrue(retrievedConfiguration.WorkAssignments.Exists(wa => wa.Name.Equals("WA 1")));
                Assert.IsTrue(retrievedConfiguration.WorkAssignments.Exists(wa => wa.Name.Equals("WA 2")));
                Assert.IsTrue(retrievedConfiguration.WorkAssignments.Exists(wa => wa.Name.Equals("WA 3")));                
            }           
        }

        [Ignore] [Test]        
        public void ShouldQueryBySectionKeyAndUserId()
        {
            User createUser = UserFixture.CreateUserWithGivenId(1);
            DateTime modifiedDateTime = new DateTime(2014, 1, 27);

            PriorityPageSectionConfiguration sectionConfiguration = new PriorityPageSectionConfiguration(PriorityPageSectionKey.TargetAlert, createUser, true, null, modifiedDateTime);
            configurationDao.Insert(sectionConfiguration);

            {
                PriorityPageSectionConfiguration result = configurationDao.QueryBySectionKeyAndUserId(PriorityPageSectionKey.TargetAlert, 1);
                Assert.NotNull(result);
            }
        }

        [Ignore] [Test]
        public void ShouldUpdate()
        {
            User createUser = UserFixture.CreateUserWithGivenId(1);
            DateTime modifiedDateTime = new DateTime(2014, 1, 27);

            PriorityPageSectionConfiguration sectionConfiguration = new PriorityPageSectionConfiguration(PriorityPageSectionKey.TargetAlert, createUser, true, null, modifiedDateTime);
            configurationDao.Insert(sectionConfiguration);

            {
                PriorityPageSectionConfiguration configToUpdate = configurationDao.QueryBySectionKeyAndUserId(PriorityPageSectionKey.TargetAlert, createUser.IdValue);
                Assert.IsTrue(configToUpdate.SectionExpandedByDefault);

                configToUpdate.SectionExpandedByDefault = false;
                configurationDao.Update(configToUpdate);
            }

            {
                PriorityPageSectionConfiguration updatedResult = configurationDao.QueryBySectionKeyAndUserId(PriorityPageSectionKey.TargetAlert, createUser.IdValue);
                Assert.IsFalse(updatedResult.SectionExpandedByDefault);
            }
        }

        [Ignore] [Test]
        public void ShouldDelete()
        {
            User createUser = UserFixture.CreateUserWithGivenId(1);
            DateTime modifiedDateTime = new DateTime(2014, 1, 27);

            PriorityPageSectionConfiguration sectionConfiguration = new PriorityPageSectionConfiguration(PriorityPageSectionKey.TargetAlert, createUser, true, null, modifiedDateTime);
            configurationDao.Insert(sectionConfiguration);

            {
                PriorityPageSectionConfiguration configToUpdate = configurationDao.QueryBySectionKeyAndUserId(PriorityPageSectionKey.TargetAlert, createUser.IdValue);
                Assert.IsTrue(configToUpdate.SectionExpandedByDefault);
                
                configurationDao.Delete(configToUpdate.IdValue);
            }

            //{
            //    PriorityPageSectionConfiguration updatedResult = configurationDao.QueryBySectionKeyAndUserId(PriorityPageSectionKey.TargetAlert, createUser.IdValue);
                
            //}
        }
    }
}
