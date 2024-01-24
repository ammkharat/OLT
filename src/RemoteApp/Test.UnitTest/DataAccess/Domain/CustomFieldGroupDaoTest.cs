using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{    
    [TestFixture]
    [Category("Database")]
    public class CustomFieldGroupDaoTest : AbstractDaoTest
    {
        private ICustomFieldGroupDao dao;
        private IWorkAssignmentDao workAssignmentDao;
        private ILogDefinitionDao logDefinitionDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ICustomFieldGroupDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
            logDefinitionDao = DaoRegistry.GetDao<ILogDefinitionDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldInsertUpdateDelete()
        { 
            WorkAssignment wa1 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA 1")); // SMF
            WorkAssignment wa2 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA 2")); // TKFM
            WorkAssignment wa3 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA 3")); // BDOF

            CustomFieldGroup group = 
                new CustomFieldGroup("group name", new List<WorkAssignment>(), new List<CustomField>(), true, true, true,true);       //ayman custom fields DMND0010030
            group.WorkAssignments.Add(wa1);
            group.WorkAssignments.Add(wa2);
            group.Fields.Add(CustomFieldFixture.CreateCustomField("field 1", 1));
            group.Fields.Add(CustomFieldFixture.CreateCustomField("field 2", 2));

            group = dao.Insert(group);

            CustomFieldGroup requeriedAfterInsert = dao.QueryBySite(SiteFixture.Sarnia()).FindById(group);
            Assert.IsNotNull(requeriedAfterInsert);
            Assert.AreEqual("group name", requeriedAfterInsert.Name);
            Assert.AreEqual(2, requeriedAfterInsert.WorkAssignments.Count);
            Assert.IsTrue(requeriedAfterInsert.AppliesToLogs);
            Assert.IsTrue(requeriedAfterInsert.AppliesToSummaryLogs);
            Assert.IsTrue(requeriedAfterInsert.AppliesToDailyDirectives);
            Assert.IsTrue(requeriedAfterInsert.WorkAssignments.ExistsById(wa1));
            Assert.IsTrue(requeriedAfterInsert.WorkAssignments.ExistsById(wa2));
            Assert.AreEqual(2, requeriedAfterInsert.Fields.Count);
            Assert.IsTrue(requeriedAfterInsert.Fields.Exists(obj => obj.Name == "field 1" && obj.DisplayOrder == 1));
            Assert.IsTrue(requeriedAfterInsert.Fields.Exists(obj => obj.Name == "field 2" && obj.DisplayOrder == 2));

            requeriedAfterInsert.Name = "some new name";
            requeriedAfterInsert.AppliesToLogs = false;
            requeriedAfterInsert.AppliesToDailyDirectives = false;
            requeriedAfterInsert.WorkAssignments.Clear();
            requeriedAfterInsert.WorkAssignments.Add(wa3);
            requeriedAfterInsert.Fields.RemoveAt(0);
            requeriedAfterInsert.Fields.Add(CustomFieldFixture.CreateCustomField("field 3", 3));
            
            dao.Update(requeriedAfterInsert);

            // first make sure that the Update method doesn't wreck the passed in object (I don't want it to clear its fields)
            Assert.AreEqual(2, requeriedAfterInsert.Fields.Count);

            CustomFieldGroup requeriedAfterUpdate = dao.QueryBySite(SiteFixture.Sarnia()).Find(g => g.Name == requeriedAfterInsert.Name);
            Assert.IsNotNull(requeriedAfterUpdate);
            Assert.AreEqual("some new name", requeriedAfterUpdate.Name);
            Assert.IsFalse(requeriedAfterUpdate.AppliesToLogs);
            Assert.IsTrue(requeriedAfterUpdate.AppliesToSummaryLogs);
            Assert.IsFalse(requeriedAfterUpdate.AppliesToDailyDirectives);

            Assert.AreEqual(1, requeriedAfterUpdate.WorkAssignments.Count);
            Assert.IsTrue(requeriedAfterUpdate.WorkAssignments.ExistsById(wa3));
            Assert.AreEqual(2, requeriedAfterUpdate.Fields.Count);
            Assert.IsTrue(requeriedAfterUpdate.Fields.Exists(obj => obj.Name == "field 2" && obj.DisplayOrder == 2));
            Assert.IsTrue(requeriedAfterUpdate.Fields.Exists(obj => obj.Name == "field 3" && obj.DisplayOrder == 3));

            dao.Remove(group);

            CustomFieldGroup requeriedAfterDelete = dao.QueryBySite(SiteFixture.Sarnia()).FindById(group);
            Assert.IsNull(requeriedAfterDelete);
        }

        [Ignore] [Test]
        public void ShouldReturnGroupIfAllWorkAssignmentsAreDeleted()
        {
            WorkAssignment wa = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA 1"));            

            CustomFieldGroup group = 
                new CustomFieldGroup("group name", new List<WorkAssignment>(), new List<CustomField>(), true, false, false, false);           //ayman custom fields DMND0010030

            group.WorkAssignments.Add(wa);
            group = dao.Insert(group);

            {
                CustomFieldGroup requeried = dao.QueryBySite(SiteFixture.Sarnia()).FindById(group);
                Assert.IsNotNull(requeried);                
                Assert.AreEqual(1, requeried.WorkAssignments.Count);
            }

            workAssignmentDao.Remove(wa);

            {
                CustomFieldGroup requeried = dao.QueryBySite(SiteFixture.Sarnia()).FindById(group);
                Assert.IsNotNull(requeried);
                Assert.AreEqual(0, requeried.WorkAssignments.Count);
            }
        }

        [Ignore] [Test]
        public void ShouldReturnGroupWithoutDeletedAssignment()
        {            
            WorkAssignment wa1 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA 1"));        
            WorkAssignment wa2 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA 2"));      

            CustomFieldGroup group = 
                new CustomFieldGroup("group name", new List<WorkAssignment>(), new List<CustomField>(), true, false, false, false);            //ayman custom fields DMND0010030

            group.WorkAssignments.Add(wa2);
            group.WorkAssignments.Add(wa1);
            group = dao.Insert(group);

            {
                CustomFieldGroup requeried = dao.QueryBySite(SiteFixture.Sarnia()).FindById(group);
                Assert.IsNotNull(requeried);
                Assert.AreEqual(2, requeried.WorkAssignments.Count);
            }

            workAssignmentDao.Remove(wa1);

            {
                CustomFieldGroup requeried = dao.QueryBySite(SiteFixture.Sarnia()).FindById(group);
                Assert.IsNotNull(requeried);
                Assert.AreEqual(1, requeried.WorkAssignments.Count);
            }
        }   

        [Ignore] [Test]
        public void ShouldQueryGroupsByLogDefinitionId()
        {
            WorkAssignment wa = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA"));

            CustomFieldGroup group1 = new CustomFieldGroup("group1", new List<WorkAssignment>(), new List<CustomField>(), true, true, true, true);       //ayman custom fields DMND0010030
            group1.WorkAssignments.Add(wa);
            CustomField field1 = new CustomField(null, "field1", 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            group1.Fields.Add(field1);
            dao.Insert(group1);

            CustomFieldEntry entry1 = new CustomFieldEntry(field1) {FieldEntry = "hi"};

            LogDefinition logDefinition = LogDefinitionFixture.CreateLogDefinition(null, LogType.Standard, wa);
            logDefinition.CustomFieldEntries.Clear();
            logDefinition.CustomFieldEntries.Add(entry1);
            logDefinition.CustomFields.Clear();
            logDefinition.CustomFields.Add(field1);
            logDefinitionDao.Insert(logDefinition);

            List<CustomFieldGroup> customFieldGroups = dao.QueryByLogDefinitionId(logDefinition.IdValue);
            Assert.AreEqual(1, customFieldGroups.Count);
            Assert.AreEqual("group1", customFieldGroups[0].Name);
        }

        [Ignore] [Test]
        public void ShouldSetOriginIdOnInsertAndNotChangeItOnUpdate()
        {
            Site site = SiteFixture.Sarnia();
            WorkAssignment wa1 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA 1"));

            CustomFieldGroup group = new CustomFieldGroup("group name", new List<WorkAssignment> { wa1 }, new List<CustomField>(), true, true, true, true);      //ayman custom fields DMND0010030
            group.Fields.Add(CustomFieldFixture.CreateCustomField("field 1", 1));

            dao.Insert(group);

            CustomFieldGroup requeriedAfterInsert = dao.QueryBySite(site).FindById(group);
            Assert.IsNotNull(requeriedAfterInsert);
            Assert.IsNotNull(requeriedAfterInsert.OriginCustomFieldGroupId);
            Assert.AreEqual(group.IdValue, requeriedAfterInsert.OriginCustomFieldGroupId);

            {
                requeriedAfterInsert.AppliesToDailyDirectives = false;
                dao.Update(requeriedAfterInsert);

                CustomFieldGroup requeriedAfterUpdate = dao.QueryBySite(site).Find(g => g.Name == requeriedAfterInsert.Name);
                Assert.IsNotNull(requeriedAfterUpdate);
                Assert.IsFalse(requeriedAfterInsert.AppliesToDailyDirectives);
                Assert.AreEqual(group.IdValue, requeriedAfterUpdate.OriginCustomFieldGroupId);
            }
        }
    }
}
