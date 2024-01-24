using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class CustomFieldDaoTest : AbstractDaoTest
    {
        private ICustomFieldDao dao;
        private ICustomFieldGroupDao groupDao;
        private IWorkAssignmentDao workAssignmentDao;
        private ITagDao tagDao;
        private ILogDao logDao;
        private ISummaryLogDao summaryLogDao;
        private ILogDefinitionDao logDefinitionDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ICustomFieldDao>();
            groupDao = DaoRegistry.GetDao<ICustomFieldGroupDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
            tagDao = DaoRegistry.GetDao<ITagDao>();
            logDao = DaoRegistry.GetDao<ILogDao>();
            summaryLogDao = DaoRegistry.GetDao<ISummaryLogDao>();
            logDefinitionDao = DaoRegistry.GetDao<ILogDefinitionDao>();
        }

        protected override void Cleanup()
        {

        }

        [Ignore] [Test]
        public void ShouldReturnFieldNamesBasedOnUsersWorkAssignments()
        {           
            WorkAssignment wa1 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA 1"));
            WorkAssignment wa2 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA 2"));
            WorkAssignment wa3 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA 3"));
            WorkAssignment wa4 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA 4"));
            WorkAssignment wa5 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA 5"));
            WorkAssignment wa6 = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA 6"));
           
            CustomFieldGroup groupOne = 
                new CustomFieldGroup(
                    "group one", new List<WorkAssignment>(), new List<CustomField>(), false, true, false,false);      //ayman custom fields DMND0010030
            groupOne.WorkAssignments.Add(wa2);
            groupOne.WorkAssignments.Add(wa4);
            groupOne.Fields.Add(CustomFieldFixture.CreateCustomField("field 1", 1));
            groupOne.Fields.Add(CustomFieldFixture.CreateCustomField("field 2", 2));
            groupDao.Insert(groupOne);

            CustomFieldGroup groupTwo = 
                new CustomFieldGroup(
                    "group two", new List<WorkAssignment>(), new List<CustomField>(), false, true, false, false);       //ayman custom fields DMND0010030
            groupTwo.WorkAssignments.Add(wa3);
            groupTwo.Fields.Add(CustomFieldFixture.CreateCustomField("field 3", 1));
            groupDao.Insert(groupTwo);

            CustomFieldGroup groupThree = 
                new CustomFieldGroup(
                    "group three", new List<WorkAssignment>(), new List<CustomField>(), false, true, false,false);           //ayman custom fields DMND0010030
            groupThree.WorkAssignments.Add(wa6);
            groupThree.Fields.Add(CustomFieldFixture.CreateCustomField("should not be returned", 1));
            groupDao.Insert(groupThree);

            CustomFieldGroup groupFour =
                new CustomFieldGroup(
                    "group four", new List<WorkAssignment>(), new List<CustomField>(), true, false, false,false);        //ayman custom fields DMND0010030
            groupFour.WorkAssignments.Add(wa5);
            groupFour.Fields.Add(CustomFieldFixture.CreateCustomField("field 4", 1));
            groupFour.Fields.Add(CustomFieldFixture.CreateCustomField("field 5", 2));
            groupDao.Insert(groupFour);

            {
                List<CustomField> fields = dao.QueryByWorkAssignmentForSummaryLogs(wa2);
                Assert.IsTrue(fields.Exists(field => field.Name == "field 1"));
                Assert.IsTrue(fields.Exists(field => field.Name == "field 2"));
                Assert.AreEqual(2, fields.Count);    
            }

            {
                List<CustomField> fields = dao.QueryByWorkAssignmentForSummaryLogs(wa3);
                Assert.IsTrue(fields.Exists(field => field.Name == "field 3"));
                Assert.AreEqual(1, fields.Count);    
            }

            {
                List<CustomField> fields = dao.QueryByWorkAssignmentForSummaryLogs(wa1);               
                Assert.AreEqual(0, fields.Count);    
            }   
         
            {
                // Doesn't show up because its applicable area is Logs, not Summary Logs
                List<CustomField> fields = dao.QueryByWorkAssignmentForSummaryLogs(wa5);               
                Assert.AreEqual(0, fields.Count); 
   
                // Doesn't show up because its applicable area is Logs, not Summary Logs
                fields = dao.QueryByWorkAssignmentForLogs(wa5);               
                Assert.AreEqual(2, fields.Count);
                Assert.IsTrue(fields.Exists(field => field.Name == "field 4"));
                Assert.IsTrue(fields.Exists(field => field.Name == "field 5"));
            }            
        }

        [Ignore] [Test]
        public void ShouldHandleNullWorkAssignment()
        {
            List<CustomField> customFields = dao.QueryByWorkAssignmentForSummaryLogs(null);

            Assert.IsNotNull(customFields);
            Assert.IsEmpty(customFields);            
        }

        [Ignore] [Test]
        public void ShouldBeAbleToInsertType()
        {
            WorkAssignment wa = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA"));

            CustomFieldGroup group = new CustomFieldGroup("group", new List<WorkAssignment>(), new List<CustomField>(), false, true, false, false);         //ayman custom fields DMND0010030
            group.WorkAssignments.Add(wa);
            group.Fields.Add(new CustomField(null, "field1", 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null));
            group.Fields.Add(new CustomField(null, "field2", 2, null, CustomFieldType.DropDownList, CustomFieldPhdLinkType.Off, null));
            groupDao.Insert(group);

            List<CustomField> fields = dao.QueryByWorkAssignmentForSummaryLogs(wa);
            CustomField field1 = fields.Find(f => f.Name == "field1");
            CustomField field2 = fields.Find(f => f.Name == "field2");

            Assert.AreEqual(CustomFieldType.GeneralText, field1.Type);
            Assert.AreEqual(CustomFieldType.DropDownList, field2.Type);
        }

        [Ignore] [Test]
        public void ShouldInsertAndUpdateDropDownValuesWhenApplicable()
        {
            WorkAssignment wa = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA"));

            CustomField generalTextCustomField = new CustomField(null, "field1", 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            CustomField dropDownListCustomField = new CustomField(null, "field2", 2, null, CustomFieldType.DropDownList, CustomFieldPhdLinkType.Off, null);

            generalTextCustomField.DropDownValues = new List<CustomFieldDropDownValue>
                                                        {
                                                            new CustomFieldDropDownValue(null, "field1_value1", 0)
                                                        };

            CustomFieldDropDownValue fieldTwoValueOne = new CustomFieldDropDownValue(null, "field2_value1", 0);
            CustomFieldDropDownValue fieldTwoValueTwo = new CustomFieldDropDownValue(null, "field2_value2", 1);
            dropDownListCustomField.DropDownValues = new List<CustomFieldDropDownValue>
                                                         {
                                                             fieldTwoValueOne,
                                                             fieldTwoValueTwo
                                                         };

            // insert case:
            CustomFieldGroup group = new CustomFieldGroup("group", new List<WorkAssignment>(), new List<CustomField>(), false, true, false,false);             //ayman custom fields DMND0010030
            group.WorkAssignments.Add(wa);            
            group.Fields.Add(generalTextCustomField);
            group.Fields.Add(dropDownListCustomField);
            groupDao.Insert(group);

            {
                List<CustomField> fields = dao.QueryByWorkAssignmentForSummaryLogs(wa);
                CustomField field1 = fields.Find(f => f.Name == "field1");
                CustomField field2 = fields.Find(f => f.Name == "field2");

                Assert.IsNull(field1.DropDownValues);
                Assert.AreEqual(2, field2.DropDownValues.Count);
                Assert.IsTrue(field2.DropDownValues.Exists(value => value.Value == "field2_value1"));
                Assert.IsTrue(field2.DropDownValues.Exists(value => value.Value == "field2_value2"));
            }


            // update case:
            fieldTwoValueOne.Value = "updatedValue";
            dropDownListCustomField.DropDownValues.Clear();
            dropDownListCustomField.DropDownValues.Add(fieldTwoValueOne);
            groupDao.Update(group);

            {
                List<CustomField> fields = dao.QueryByWorkAssignmentForSummaryLogs(wa);
                CustomField field2 = fields.Find(f => f.Name == "field2");

                Assert.AreEqual(1, field2.DropDownValues.Count);
                Assert.IsTrue(field2.DropDownValues.Exists(value => value.Value == "updatedValue"));
            }
        }

        [Ignore] [Test]
        public void ShouldBeAbleToInsertTagInfoIdIfThatsWhatYoureInto()
        {
            WorkAssignment wa = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA"));

            TagInfo tagInfo = TagInfoFixture.GetExistingSarniaTagInfoList()[0];

            CustomFieldGroup group =
                new CustomFieldGroup(
                    "group", new List<WorkAssignment>(), new List<CustomField>(), false, true, false,false);        //ayman custom fields DMND0010030
            group.WorkAssignments.Add(wa);
                    group.Fields.Add(new CustomField(null, "field1", 1, tagInfo, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null));
                    group.Fields.Add(new CustomField(null, "field2", 2, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null));
                    groupDao.Insert(group);

            List<CustomField> fields = dao.QueryByWorkAssignmentForSummaryLogs(wa);
            CustomField field1 = fields.Find(f => f.Name == "field1");
            CustomField field2 = fields.Find(f => f.Name == "field2");

            Assert.AreEqual(tagInfo.IdValue, field1.TagInfo.IdValue);
            Assert.AreEqual(null, field2.TagInfo);
        }

        [Ignore] [Test]
        public void ShouldStillPopulateWithTagEvenIfTheTagIsDeleted()
        {
            WorkAssignment wa = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA"));

            TagInfo tagInfo = TagInfoFixture.GetExistingSarniaTagInfoList()[0];
            tagDao.Remove(tagInfo);

            CustomFieldGroup group =
                new CustomFieldGroup(
                    "group", new List<WorkAssignment>(), new List<CustomField>(), false, true, false,false);         //ayman custom fields DMND0010030
            group.WorkAssignments.Add(wa);
            group.Fields.Add(new CustomField(null, "field", 1, tagInfo, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null));
            groupDao.Insert(group);

            List<CustomField> fields = dao.QueryByWorkAssignmentForSummaryLogs(wa);
            CustomField field1 = fields.Find(f => f.Name == "field");

            Assert.IsNotNull(field1.TagInfo);            
            Assert.AreEqual(tagInfo.IdValue, field1.TagInfo.IdValue);
        }

        [Ignore] [Test]
        public void ShouldSetOriginCustomFieldIdOnInsertAndNotChangeItOnUpdate()
        {
            WorkAssignment wa = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA"));
            
            CustomFieldGroup group = new CustomFieldGroup("group", new List<WorkAssignment>(), new List<CustomField>(), false, true, false,false);       //ayman custom fields DMND0010030
            group.WorkAssignments.Add(wa);
            group.Fields.Add(new CustomField(null, "field", 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null));
            groupDao.Insert(group);

            List<CustomField> fields = dao.QueryByWorkAssignmentForSummaryLogs(wa);
            CustomField field1 = fields.Find(f => f.Name == "field");
            long? originCustomFieldId = field1.OriginCustomFieldId;
            Assert.IsNotNull(originCustomFieldId);

            // make sure that changing the origin custom field id doesn't do anything
            {
                field1.OriginCustomFieldId = originCustomFieldId + 1;
                groupDao.Update(group);

                List<CustomField> requeriedFields = dao.QueryByWorkAssignmentForSummaryLogs(wa);
                CustomField requeriedField1 = requeriedFields.Find(f => f.Name == "field");
                Assert.AreEqual(originCustomFieldId, requeriedField1.OriginCustomFieldId);
            }
        }

        [Ignore] [Test]
        public void ShouldMaintainOriginCustomFieldIdAcrossMultipleFieldNameUpdates()
        {
            WorkAssignment wa = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA"));

            CustomFieldGroup group = new CustomFieldGroup("group", new List<WorkAssignment>(), new List<CustomField>(), false, true, false,false);     //ayman custom fields DMND0010030
            group.WorkAssignments.Add(wa);
            group.Fields.Add(new CustomField(null, "field", 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null));
            groupDao.Insert(group);

            group = groupDao.QueryById(group.IdValue);
            CustomField field1 = group.Fields.Find(f => f.Name == "field");
            long? originCustomFieldId = field1.OriginCustomFieldId;
            Assert.IsNotNull(originCustomFieldId);
            
            field1.Name = "new name 1";
            CustomFieldGroup newGroup = groupDao.Update(group);

            CustomField newField1 = newGroup.Fields.Find(f => f.Name == "new name 1");
            newField1.Name = "new name 2";
            groupDao.Update(newGroup);

            List<CustomField> requeriedFields = dao.QueryByWorkAssignmentForSummaryLogs(wa);
            CustomField requeriedField1 = requeriedFields.Find(f => f.Name == "new name 2");
            Assert.AreEqual(originCustomFieldId, requeriedField1.OriginCustomFieldId);
        }

        [Ignore] [Test]
        public void QueryByCustomFieldGroupsForLogShouldDoExactlyThat()
        {
            WorkAssignment wa = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA"));

            CustomFieldGroup group1 = new CustomFieldGroup("group1", new List<WorkAssignment>(), new List<CustomField>(), true, true, true,true);             //ayman custom fields DMND0010030
            group1.WorkAssignments.Add(wa);
            CustomField field1 = new CustomField(null, "field1", 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            group1.Fields.Add(field1);
            groupDao.Insert(group1);

            Log log = LogFixture.CreateLog(false);
            log.WorkAssignment = wa;
            log.CustomFieldEntries.Clear();
            CustomFieldEntry entry1 = new CustomFieldEntry(field1) {FieldEntry = "hi"};
            log.CustomFieldEntries.Add(entry1);
            log.CustomFields.Clear();
            log.CustomFields.Add(field1);
            logDao.Insert(log);

            {
                List<CustomField> customFieldsForLog = dao.QueryByCustomFieldGroupsForLogs(log.IdValue);
                Assert.AreEqual(1, customFieldsForLog.Count);
                Assert.AreEqual(field1.IdValue, customFieldsForLog[0].IdValue);
            }

            CustomFieldGroup group2 = new CustomFieldGroup("group2", new List<WorkAssignment>(), new List<CustomField>(), true, true, true,true);        //ayman custom fields DMND0010030
            group2.WorkAssignments.Add(wa);
            CustomField field2 = new CustomField(null, "field2", 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            group2.Fields.Add(field2);
            groupDao.Insert(group2);

            Log anotherLog = LogFixture.CreateLog(false);
            anotherLog.WorkAssignment = wa;
            anotherLog.CustomFieldEntries.Clear();
            CustomFieldEntry entry2 = new CustomFieldEntry(field1) {FieldEntry = "hi there"};
            anotherLog.CustomFieldEntries.Add(entry2);
            anotherLog.CustomFields.Clear();
            anotherLog.CustomFields.Add(field1);
            anotherLog.CustomFields.Add(field2);
            logDao.Insert(anotherLog);

            // the first log should still only have one custom field associated; the second log should have two
            {
                List<CustomField> customFieldsForFirstLog = dao.QueryByCustomFieldGroupsForLogs(log.IdValue);
                Assert.AreEqual(1, customFieldsForFirstLog.Count);
                Assert.AreEqual(field1.IdValue, customFieldsForFirstLog[0].IdValue);

                List<CustomField> customFieldsForSecondLog = dao.QueryByCustomFieldGroupsForLogs(anotherLog.IdValue);
                Assert.AreEqual(2, customFieldsForSecondLog.Count);
                Assert.AreEqual(field1.IdValue, customFieldsForSecondLog[0].IdValue);
                Assert.AreEqual(field2.IdValue, customFieldsForSecondLog[1].IdValue);
            }

        }

        [Ignore] [Test]
        public void QueryByCustomFieldGroupsForSummaryLogShouldDoExactlyThat()
        {
            WorkAssignment wa = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA"));

            CustomFieldGroup group1 = new CustomFieldGroup("group1", new List<WorkAssignment>(), new List<CustomField>(), true, true, true,true);            //ayman custom fields DMND0010030
            group1.WorkAssignments.Add(wa);
            CustomField field1 = new CustomField(null, "field1", 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            group1.Fields.Add(field1);
            groupDao.Insert(group1);

            CustomFieldEntry entry1 = new CustomFieldEntry(field1) {FieldEntry = "hi"};

            SummaryLog log = SummaryLogFixture.CreateSummaryLog();
            log.WorkAssignment = wa;            
            log.CustomFieldEntries.Clear();
            log.CustomFieldEntries.Add(entry1);
            log.CustomFields.Clear();
            log.CustomFields.Add(field1);
            summaryLogDao.Insert(log);

            {
                List<CustomField> customFieldsForLog = dao.QueryByCustomFieldGroupsForSummaryLogs(log.IdValue);
                Assert.AreEqual(1, customFieldsForLog.Count);
                Assert.AreEqual(field1.IdValue, customFieldsForLog[0].IdValue);
            }

            CustomFieldGroup group2 = new CustomFieldGroup("group2", new List<WorkAssignment>(), new List<CustomField>(), true, true, true,true);          //ayman custom fields DMND0010030
            group2.WorkAssignments.Add(wa);
            CustomField field2 = new CustomField(null, "field2", 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            group2.Fields.Add(field2);
            groupDao.Insert(group2);

            CustomFieldEntry entry2 = new CustomFieldEntry(field1) {FieldEntry = "hi there"};

            SummaryLog anotherLog = SummaryLogFixture.CreateSummaryLog();
            anotherLog.WorkAssignment = wa;
            anotherLog.CustomFieldEntries.Clear();
            anotherLog.CustomFieldEntries.Add(entry2);
            anotherLog.CustomFields.Clear();
            anotherLog.CustomFields.Add(field1);
            anotherLog.CustomFields.Add(field2);
            summaryLogDao.Insert(anotherLog);

            // the first log should still only have one custom field associated; the second log should have two
            {
                List<CustomField> customFieldsForFirstLog = dao.QueryByCustomFieldGroupsForSummaryLogs(log.IdValue);
                Assert.AreEqual(1, customFieldsForFirstLog.Count);
                Assert.AreEqual(field1.IdValue, customFieldsForFirstLog[0].IdValue);

                List<CustomField> customFieldsForSecondLog = dao.QueryByCustomFieldGroupsForSummaryLogs(anotherLog.IdValue);
                Assert.AreEqual(2, customFieldsForSecondLog.Count);
                Assert.AreEqual(field1.IdValue, customFieldsForSecondLog[0].IdValue);
                Assert.AreEqual(field2.IdValue, customFieldsForSecondLog[1].IdValue);
            }

        }

        [Ignore] [Test]
        public void QueryByCustomFieldGroupsForLogDefinitionShouldDoExactlyThat()
        {
            WorkAssignment wa = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA"));

            CustomFieldGroup group1 = new CustomFieldGroup("group1", new List<WorkAssignment>(), new List<CustomField>(), true, true, true,true);        //ayman custom fields DMND0010030
            group1.WorkAssignments.Add(wa);
            CustomField field1 = new CustomField(null, "field1", 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            group1.Fields.Add(field1);
            groupDao.Insert(group1);

            LogDefinition logDefinition = LogDefinitionFixture.CreateLogDefinition(null, LogType.Standard, wa);
            logDefinition.CustomFieldEntries.Clear();
            CustomFieldEntry entry1 = new CustomFieldEntry(field1) {FieldEntry = "hi"};
            logDefinition.CustomFieldEntries.Add(entry1);
            logDefinition.CustomFields.Clear();
            logDefinition.CustomFields.Add(field1);
            logDefinitionDao.Insert(logDefinition);

            {
                List<CustomField> customFieldsForLog = dao.QueryByCustomFieldGroupsForLogDefinitions(logDefinition.IdValue);
                Assert.AreEqual(1, customFieldsForLog.Count);
                Assert.AreEqual(field1.IdValue, customFieldsForLog[0].IdValue);
            }

            CustomFieldGroup group2 = new CustomFieldGroup("group2", new List<WorkAssignment>(), new List<CustomField>(), true, true, true,true);          //ayman custom fields DMND0010030
            group2.WorkAssignments.Add(wa);
            CustomField field2 = new CustomField(null, "field2", 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null, null, null, 2, null, "B",true,null);
            group2.Fields.Add(field2);
            groupDao.Insert(group2);

            LogDefinition anotherLogDefinition = LogDefinitionFixture.CreateLogDefinition(null, LogType.Standard, wa);
            anotherLogDefinition.CustomFieldEntries.Clear();
            CustomFieldEntry entry2 = new CustomFieldEntry(field1) {FieldEntry = "hi there"};
            anotherLogDefinition.CustomFieldEntries.Add(entry2);
            anotherLogDefinition.CustomFields.Clear();
            anotherLogDefinition.CustomFields.Add(field1);
            anotherLogDefinition.CustomFields.Add(field2);
            logDefinitionDao.Insert(anotherLogDefinition);

            // the first log should still only have one custom field associated; the second log should have two
            {
                List<CustomField> customFieldsForFirstLog = dao.QueryByCustomFieldGroupsForLogDefinitions(logDefinition.IdValue);
                Assert.AreEqual(1, customFieldsForFirstLog.Count);
                Assert.AreEqual(field1.IdValue, customFieldsForFirstLog[0].IdValue);

                List<CustomField> customFieldsForSecondLog = dao.QueryByCustomFieldGroupsForLogDefinitions(anotherLogDefinition.IdValue);
                Assert.AreEqual(2, customFieldsForSecondLog.Count);
                Assert.AreEqual(field1.IdValue, customFieldsForSecondLog[0].IdValue);
                Assert.AreEqual(field2.IdValue, customFieldsForSecondLog[1].IdValue);
            }

        }

        [Ignore] [Test]
        public void UpdatingACustomFieldsNameShouldCreateANewOne()
        {
            WorkAssignment wa = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA"));

            CustomFieldGroup group1 = new CustomFieldGroup("group1", new List<WorkAssignment>(), new List<CustomField>(), true, true, true,true);        //ayman custom fields DMND0010030
            group1.WorkAssignments.Add(wa);
            CustomField field1 = new CustomField(null, "field1", 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            group1.Fields.Add(field1);
            groupDao.Insert(group1);
            long field1Id = field1.IdValue;
            long field1OriginId = field1.OriginCustomFieldId.Value;

            // update name and verify that the field has a new id
            field1.Name = "new field1 name";
            group1 = groupDao.Update(group1);

            List<CustomField> customFields = dao.QueryByWorkAssignmentForLogs(wa);
            Assert.AreEqual(1, customFields.Count);
            Assert.AreNotEqual(field1Id, customFields[0].IdValue);
            Assert.AreEqual(field1OriginId, customFields[0].OriginCustomFieldId);
            long newField1Id = customFields[0].IdValue;
            long newField1OriginId = customFields[0].OriginCustomFieldId.Value;

            // update type and note that the field has the same id
            field1.Type = CustomFieldType.NumericValue;
            groupDao.Update(group1);

            customFields = dao.QueryByWorkAssignmentForLogs(wa);
            Assert.AreEqual(1, customFields.Count);
            Assert.AreEqual(newField1Id, customFields[0].IdValue);
            Assert.AreEqual(newField1OriginId, customFields[0].OriginCustomFieldId);
        }

        [Ignore] [Test]
        public void QueryByCustomFieldGroupsForLogsShouldIncludeDeletedGroups()
        {
            WorkAssignment wa = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA"));

            CustomFieldGroup group1 = new CustomFieldGroup("group1", new List<WorkAssignment>(), new List<CustomField>(), true, true, true,true);          //ayman custom fields DMND0010030
            group1.WorkAssignments.Add(wa);
            CustomField field1 = new CustomField(null, "field1", 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            group1.Fields.Add(field1);
            groupDao.Insert(group1);

            CustomFieldEntry entry1 = new CustomFieldEntry(field1) {FieldEntry = "hi"};

            Log log = LogFixture.CreateLog(false);
            log.WorkAssignment = wa;
            log.CustomFieldEntries.Clear();
            log.CustomFieldEntries.Add(entry1);
            log.CustomFields.Clear();
            log.CustomFields.Add(field1);
            logDao.Insert(log);

            field1.Name = "new field1 name";
            groupDao.Update(group1);   // updating the group will soft delete it

            List<CustomField> customFieldsForLog = dao.QueryByCustomFieldGroupsForLogs(log.IdValue);
            Assert.AreEqual(1, customFieldsForLog.Count);
            Assert.AreEqual("field1", customFieldsForLog[0].Name);
        }

        [Ignore] [Test]
        public void QueryByCustomFieldGroupsForSummaryLogsShouldIncludeDeletedGroups()
        {
            WorkAssignment wa = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA"));

            CustomFieldGroup group1 = new CustomFieldGroup("group1", new List<WorkAssignment>(), new List<CustomField>(), true, true, true,true);     //ayman custom fields DMND0010030
            group1.WorkAssignments.Add(wa);
            CustomField field1 = new CustomField(null, "field1", 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null, null, null, null, 2, "B",true,null);
            group1.Fields.Add(field1);
            groupDao.Insert(group1);

            CustomFieldEntry entry1 = new CustomFieldEntry(field1) {FieldEntry = "hi"};

            SummaryLog log = SummaryLogFixture.CreateSummaryLog();
            log.WorkAssignment = wa;
            log.CustomFieldEntries.Clear();
            log.CustomFieldEntries.Add(entry1);
            log.CustomFields.Clear();
            log.CustomFields.Add(field1);
            summaryLogDao.Insert(log);

            field1.Name = "new field1 name";
            groupDao.Update(group1);   // updating the group will soft delete it

            List<CustomField> customFieldsForLog = dao.QueryByCustomFieldGroupsForSummaryLogs(log.IdValue);
            Assert.AreEqual(1, customFieldsForLog.Count);
            Assert.AreEqual("field1", customFieldsForLog[0].Name);
        }

        [Ignore] [Test]
        public void QueryByCustomFieldGroupsForLogDefinitionsShouldIncludeDeletedGroups()
        {
            WorkAssignment wa = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA"));

            CustomFieldGroup group1 = new CustomFieldGroup("group1", new List<WorkAssignment>(), new List<CustomField>(), true, true, true,true);         //ayman custom fields DMND0010030
            group1.WorkAssignments.Add(wa);
            CustomField field1 = new CustomField(null, "field1", 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            group1.Fields.Add(field1);
            groupDao.Insert(group1);

            CustomFieldEntry entry1 = new CustomFieldEntry(field1) {FieldEntry = "hi"};

            LogDefinition logDefinition = LogDefinitionFixture.CreateLogDefinition(null, LogType.Standard, wa);
            logDefinition.CustomFieldEntries.Clear();
            logDefinition.CustomFieldEntries.Add(entry1);
            logDefinition.CustomFields.Clear();
            logDefinition.CustomFields.Add(field1);
            logDefinitionDao.Insert(logDefinition);

            field1.Name = "new field1 name";
            groupDao.Update(group1);   // updating the group will soft delete it

            List<CustomField> customFieldsForLogDefinition = dao.QueryByCustomFieldGroupsForLogDefinitions(logDefinition.IdValue);
            Assert.AreEqual(1, customFieldsForLogDefinition.Count);
            Assert.AreEqual("field1", customFieldsForLogDefinition[0].Name);
        }


    }
}
