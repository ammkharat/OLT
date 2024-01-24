using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class LogDefinitionDaoTest : AbstractDaoTest
    {
        private ILogDefinitionDao dao;
        private IWorkAssignmentDao workAssignmentDao;
        private Role roleInDb;
        private IRoleDao roleDao;
        private ICustomFieldGroupDao customFieldGroupDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ILogDefinitionDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
            customFieldGroupDao = DaoRegistry.GetDao<ICustomFieldGroupDao>();

            // Get a Role already in the Database
            roleDao = DaoRegistry.GetDao<IRoleDao>();
            roleInDb = roleDao.QueryByActiveDirectoryKey(SiteFixture.Oilsands(), "RestrictionReportingAdmin");
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void QueryAllLogDefinitionsShouldReturnAListOfLogDefinitions()
        {
            Assert.IsTrue(dao.QueryAllForScheduling().Count > 0);
        }

        [Ignore] [Test]
        public void QueryLogDefinitionById()
        {
            WorkAssignment testWorkAssignment = new WorkAssignment("Test", "Test", "Test", 1, RoleFixture.GetRealRoleA(1));
            testWorkAssignment = workAssignmentDao.Insert(testWorkAssignment);

            LogDefinition logDefinitionToInsert = LogDefinitionFixture.CreateLogDefinitionWithRecurringWeeklySchedule(testWorkAssignment);

            SetFollowUpFlagsToTrue(logDefinitionToInsert);

            LogDefinition definitionReturnedFromInsert = dao.Insert(logDefinitionToInsert);
          
            LogDefinition actual = dao.QueryById(definitionReturnedFromInsert.IdValue);
            Assert.AreEqual(definitionReturnedFromInsert.IdValue, actual.IdValue);
            
            Assert.AreEqual(definitionReturnedFromInsert.Schedule.IdValue, actual.Schedule.IdValue);
            
            Assert.AreEqual(new DateTime(2005, 11, 15), actual.CreatedDateTime);

            Assert.AreEqual(FunctionalLocationFixture.GetAny_Unit1().FullHierarchy, actual.FunctionalLocationsAsCommaSeparatedString);
            Assert.AreEqual(logDefinitionToInsert.PlainTextComments, actual.PlainTextComments);
            Assert.AreEqual(logDefinitionToInsert.RtfComments, actual.RtfComments);
            Assert.AreEqual(true, actual.EnvironmentalHealthSafetyFollowUp);
            Assert.AreEqual(true, actual.InspectionFollowUp);
            Assert.AreEqual(true, actual.OperationsFollowUp);
            Assert.AreEqual(true, actual.OtherFollowUp);
            Assert.AreEqual(true, actual.ProcessControlFollowUp);
            Assert.AreEqual(true, actual.SupervisionFollowUp);                      
            Assert.AreEqual(logDefinitionToInsert.CreatedBy.IdValue, actual.CreatedBy.IdValue);
            Assert.AreEqual(logDefinitionToInsert.LastModifiedBy.IdValue, actual.LastModifiedBy.IdValue);
            Assert.That(logDefinitionToInsert.LastModifiedDate, Is.EqualTo(actual.LastModifiedDate).Within(TimeSpan.FromSeconds(1.0)));
            Assert.AreEqual(logDefinitionToInsert.WorkAssignment, logDefinitionToInsert.WorkAssignment);
        }

        private static void SetFollowUpFlagsToTrue(LogDefinition logDefinition)
        {
            logDefinition.EnvironmentalHealthSafetyFollowUp = true;
            logDefinition.InspectionFollowUp = true;
            logDefinition.OperationsFollowUp = true;
            logDefinition.OtherFollowUp = true;            
            logDefinition.ProcessControlFollowUp = true;            
            logDefinition.SupervisionFollowUp = true;            
        }

        [Ignore] [Test]
        public void QueryLogDefinitionByScheduleId()
        {
            LogDefinition result = dao.QueryByScheduleId(3);            
            Assert.AreEqual(2, result.IdValue);                        
        }

        [Ignore] [Test]
        public void ShouldInsertLogDefinition()
        {
            WorkAssignment testWorkAssignment = new WorkAssignment("Test", "Test", "Test", 1, RoleFixture.GetRealRoleA(1));
            testWorkAssignment = workAssignmentDao.Insert(testWorkAssignment);

            LogDefinition expectedLogDefinition = LogDefinitionFixture.CreateLogDefinitionWithRecurringWeeklySchedule(testWorkAssignment);            

            LogDefinition result = dao.Insert(expectedLogDefinition);
            Assert.IsTrue(result.IsInDatabase());
            Assert.IsTrue(expectedLogDefinition.Equals(result));
            LogDefinition retrievedLogDefinition = dao.QueryById(result.IdValue);
            AssertLogDefinitionAreEqual(expectedLogDefinition, retrievedLogDefinition);
        }

        [Ignore] [Test]
        public void ShouldInsertLogDefinition_NullWorkAssignment()
        {
            LogDefinition expectedLogDefinition = InsertLogDefinition();
            expectedLogDefinition.Schedule =
                RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000();
            expectedLogDefinition.Schedule.Id = 1;

            LogDefinition result = dao.Insert(expectedLogDefinition);
            Assert.IsTrue(result.IsInDatabase());
            Assert.IsTrue(expectedLogDefinition.Equals(result));
            LogDefinition retrievedLogDefinition = dao.QueryById(result.IdValue);
            AssertLogDefinitionAreEqual(expectedLogDefinition, retrievedLogDefinition);
        }

        [Ignore] [Test]
        public void ShouldInsertLogDefinition_Active()
        {
            {
                LogDefinition logDefinition = BuildInsertableStandingOrder();                
                logDefinition.Active = true;
                LogDefinition activeDefinition = dao.Insert(logDefinition);
                Assert.IsTrue(dao.QueryById(activeDefinition.IdValue).Active);
            }

            {
                LogDefinition logDefinition = BuildInsertableStandingOrder();
                logDefinition.Active = false;
                LogDefinition activeDefinition = dao.Insert(logDefinition);
                Assert.IsFalse(dao.QueryById(activeDefinition.IdValue).Active);
            }           
        }

        private static void AssertLogDefinitionAreEqual(LogDefinition expectedLogDefinition, LogDefinition actualLogDefinition)
        {
            Assert.AreEqual(expectedLogDefinition.Schedule.Id, actualLogDefinition.Schedule.Id);
            Assert.AreEqual(expectedLogDefinition.FunctionalLocationsAsCommaSeparatedString, actualLogDefinition.FunctionalLocationsAsCommaSeparatedString);
            Assert.AreEqual(expectedLogDefinition.InspectionFollowUp, actualLogDefinition.InspectionFollowUp);
            Assert.AreEqual(expectedLogDefinition.OperationsFollowUp, actualLogDefinition.OperationsFollowUp);
            Assert.AreEqual(expectedLogDefinition.SupervisionFollowUp, actualLogDefinition.SupervisionFollowUp);
            Assert.AreEqual(expectedLogDefinition.EnvironmentalHealthSafetyFollowUp,
                            actualLogDefinition.EnvironmentalHealthSafetyFollowUp);
            Assert.AreEqual(expectedLogDefinition.OtherFollowUp, actualLogDefinition.OtherFollowUp);
            Assert.AreEqual(expectedLogDefinition.RtfComments, actualLogDefinition.RtfComments);
            Assert.AreEqual(expectedLogDefinition.PlainTextComments, actualLogDefinition.PlainTextComments);
            Assert.That(expectedLogDefinition.CreatedDateTime, Is.EqualTo(actualLogDefinition.CreatedDateTime).Within(TimeSpan.FromSeconds(10)));
            Assert.AreEqual(expectedLogDefinition.CreatedBy.Id, actualLogDefinition.CreatedBy.Id);
            Assert.AreEqual(expectedLogDefinition.LastModifiedBy.Id, actualLogDefinition.LastModifiedBy.Id);
            Assert.AreEqual(expectedLogDefinition.LastModifiedDate.Date, actualLogDefinition.LastModifiedDate.Date);
            Assert.AreEqual(expectedLogDefinition.WorkAssignment, actualLogDefinition.WorkAssignment);
            Assert.AreEqual(expectedLogDefinition.Active, actualLogDefinition.Active);
        }

        [Ignore] [Test]
        public void ShouldUpdateChangedValuesForLogDefinition()
        {
            LogDefinition logDefinitonToInsert = BuildInsertableStandingOrder();

            logDefinitonToInsert.Schedule =
                RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000();
            logDefinitonToInsert.Schedule.Id = 1;

            dao.Insert(logDefinitonToInsert);
            Assert.IsNotNull(logDefinitonToInsert.Id);
            LogDefinition logDefinitionToChange = dao.QueryById(logDefinitonToInsert.IdValue);

            Assert.IsTrue(logDefinitionToChange.Active);

            logDefinitionToChange.Active = false;

            logDefinitionToChange.InspectionFollowUp = !logDefinitonToInsert.InspectionFollowUp;
            logDefinitionToChange.OperationsFollowUp = !logDefinitonToInsert.OperationsFollowUp;
            logDefinitionToChange.ProcessControlFollowUp = !logDefinitonToInsert.ProcessControlFollowUp;
            logDefinitionToChange.SupervisionFollowUp = !logDefinitonToInsert.SupervisionFollowUp;
            logDefinitionToChange.EnvironmentalHealthSafetyFollowUp =
                    !logDefinitonToInsert.EnvironmentalHealthSafetyFollowUp;
            logDefinitionToChange.OtherFollowUp = !logDefinitonToInsert.OtherFollowUp;
            logDefinitionToChange.RtfComments = "New comments";
            logDefinitionToChange.PlainTextComments = "New comments";
            logDefinitionToChange.LastModifiedBy = DaoRegistry.GetDao<IUserDao>().QueryById(2);
            
            dao.Update(logDefinitionToChange);
            LogDefinition logDefinitionChangedLogDefinition = dao.QueryById(logDefinitionToChange.IdValue);
            AssertLogDefinitionAreEqual(logDefinitionToChange, logDefinitionChangedLogDefinition);
        }

        [Ignore] [Test]
        public void ShouldUpdateSchedule()
        {

            LogDefinition logDefinitonToInsert = InsertLogDefinition();
            logDefinitonToInsert.Schedule =
                RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000();
            logDefinitonToInsert.Schedule.Id = 1;

            dao.Insert(logDefinitonToInsert);
            Assert.IsNotNull(logDefinitonToInsert.Id);
            LogDefinition logDefinitionToChange = dao.QueryById(logDefinitonToInsert.IdValue);
            logDefinitionToChange.Schedule.Id = 2;
            dao.Update(logDefinitionToChange);
            Assert.AreNotEqual(logDefinitonToInsert.Schedule.Id, logDefinitionToChange.Schedule.Id);
        }

        [Ignore] [Test]
        public void ShouldNotUpdateCreatedBy()
        {
            const long expectedUserId = 1;
            const long newUserId = 2;
            LogDefinition logDefiniton = LogDefinitionFixture.CreateLogDefintionWithRecurringWeeklySchedule();
            User expectedCreatedByUser = DaoRegistry.GetDao<IUserDao>().QueryById(expectedUserId);
            logDefiniton.CreatedBy = expectedCreatedByUser;
            Assert.AreNotEqual(expectedCreatedByUser.IdValue, newUserId);
            dao.Insert(logDefiniton);
            logDefiniton.CreatedBy = DaoRegistry.GetDao<IUserDao>().QueryById(2);
            dao.Update(logDefiniton);
            LogDefinition resultlogDefintion = dao.QueryById(logDefiniton.IdValue);
            Assert.AreEqual(expectedCreatedByUser, resultlogDefintion.CreatedBy);
        }

        [Ignore] [Test]
        public void ShouldMarkLogDefinitionAsDeleted()
        {
            const string sqlTestStatement = "SELECT count(*) FROM LogDefinition";
            int initialRowCount = TestDataAccessUtil.ExecuteScalarExpression<int>(sqlTestStatement);
            LogDefinition logDefiniton = LogDefinitionFixture.CreateLogDefintionWithRecurringWeeklySchedule();
            dao.Insert(logDefiniton);
            int afterInsertCount = TestDataAccessUtil.ExecuteScalarExpression<int>(sqlTestStatement);
            Assert.AreEqual(initialRowCount + 1, afterInsertCount);
            dao.Remove(logDefiniton);
            int afterRemoveCount = TestDataAccessUtil.ExecuteScalarExpression<int>(sqlTestStatement);
            Assert.AreEqual(afterInsertCount, afterRemoveCount);
        }

        [Ignore] [Test]
        public void ShouldReturnNullWhenQueringDeletedLogDefinition()
        {
            LogDefinition logDefiniton = LogDefinitionFixture.CreateLogDefintionWithRecurringWeeklySchedule();
            dao.Insert(logDefiniton);
            dao.Remove(logDefiniton);
            LogDefinition deletedLogDefiniton = dao.QueryById(logDefiniton.IdValue);
            Assert.IsTrue(deletedLogDefiniton.Deleted);
        }

        [Ignore] [Test]
        public void InsertShouldInsertDocumentLinks()
        {
            LogDefinition logDefinitionForInsert = InsertLogDefinitionWithTwoDocumentLinks();
            LogDefinition retrievedLogDefinition = dao.QueryById(logDefinitionForInsert.IdValue);
            Assert.AreEqual(logDefinitionForInsert.DocumentLinks.Count, retrievedLogDefinition.DocumentLinks.Count);

            Assert.That(retrievedLogDefinition.DocumentLinks,
                        Has.Some.EqualTo(logDefinitionForInsert.DocumentLinks[0]));
            Assert.That(retrievedLogDefinition.DocumentLinks,
                        Has.Some.EqualTo(logDefinitionForInsert.DocumentLinks[1]));

        }

        [Ignore] [Test]
        public void UpdateShouldRemoveDeletedDocumentLinks()
        {
            LogDefinition logDefinition = InsertLogDefinitionWithTwoDocumentLinks();
            long removedLinkId = logDefinition.DocumentLinks[0].IdValue;
            long retainedLinkId = logDefinition.DocumentLinks[1].IdValue;
            logDefinition.DocumentLinks.Remove(logDefinition.DocumentLinks[0]);
            dao.Update(logDefinition);
            LogDefinition retrievedLog = dao.QueryById(logDefinition.IdValue);
            Assert.AreEqual(logDefinition.DocumentLinks.Count, retrievedLog.DocumentLinks.Count);

            Assert.That(retrievedLog.DocumentLinks, Has.None.Property("Id").EqualTo(removedLinkId));
            Assert.That(retrievedLog.DocumentLinks, Has.Some.Property("Id").EqualTo(retainedLinkId));

        }

        [Ignore] [Test]
        public void ShouldInsertCustomFieldEntries()
        {         
            LogDefinition logDefinition = BuildInsertableLogDefinition();
            logDefinition = dao.Insert(logDefinition);

            logDefinition.CustomFieldEntries.Clear();
            logDefinition.CustomFieldEntries.Add(new CustomFieldEntry(null, CustomFieldFixture.CustomFieldExistingInDatabase1().IdValue, "Field Name 1", "Field Entry 1", null,null, 1, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));
            logDefinition.CustomFieldEntries.Add(new CustomFieldEntry(null, CustomFieldFixture.CustomFieldExistingInDatabase2().IdValue, "Field Name 2", null, new decimal(5.32),null, 2, CustomFieldType.NumericValue, CustomFieldPhdLinkType.Off,null));
            logDefinition.CustomFieldEntries.Add(new CustomFieldEntry(null, CustomFieldFixture.CustomFieldExistingInDatabase3().IdValue, "Field Name 3", "Field Entry 3", null,null, 3, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));

            logDefinition.CustomFields.Clear();
            logDefinition.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase1());
            logDefinition.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase2());
            logDefinition.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase3());

            LogDefinition definitionReturnedFromInsert = dao.Insert(logDefinition);

            LogDefinition queriedDefinition = dao.QueryById(definitionReturnedFromInsert.IdValue);

            Assert.AreEqual(3, queriedDefinition.CustomFieldEntries.Count);
            Assert.IsTrue(queriedDefinition.CustomFieldEntries.Exists(
                e => e.CustomFieldName.Equals("Field Name 1") && e.FieldEntry.Equals("Field Entry 1") && e.DisplayOrder == 1));
            Assert.IsTrue(queriedDefinition.CustomFieldEntries.Exists(
                e => e.CustomFieldName.Equals("Field Name 2") && e.NumericFieldEntry.Equals(new decimal(5.32)) && e.DisplayOrder == 2));
            Assert.IsTrue(queriedDefinition.CustomFieldEntries.Exists(
                e => e.CustomFieldName.Equals("Field Name 3") && e.FieldEntry.Equals("Field Entry 3") && e.DisplayOrder == 3));           
        }

        [Ignore] [Test]
        public void ShouldUpdateCustomFieldEntries()
        {
            LogDefinition logDefinition = BuildInsertableLogDefinition();
            logDefinition.CustomFieldEntries.Clear();
            logDefinition.CustomFieldEntries.Add(new CustomFieldEntry(null, CustomFieldFixture.CustomFieldExistingInDatabase1().IdValue, "Field Name 1", "Field Entry 1", null,null, 1, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));
            logDefinition.CustomFields.Clear();
            logDefinition.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase1());
            LogDefinition definitionReturnedFromInsert = dao.Insert(logDefinition);

            LogDefinition queriedDefinition = dao.QueryById(definitionReturnedFromInsert.IdValue);
            CustomFieldEntry customFieldEntry = queriedDefinition.CustomFieldEntries[0];
            customFieldEntry.FieldEntry = "Updated field entry";
            dao.Update(queriedDefinition);

            queriedDefinition = dao.QueryById(queriedDefinition.IdValue);
            Assert.AreEqual(1, queriedDefinition.CustomFieldEntries.Count);
            Assert.IsTrue(queriedDefinition.CustomFieldEntries.Exists(
                e => e.CustomFieldName.Equals("Field Name 1") && e.FieldEntry.Equals("Updated field entry") && e.DisplayOrder == 1));
        }

        [Ignore] [Test]
        public void UpdateShouldAddNewDocumentLink()
        {
            LogDefinition logDefinition = LogDefinitionFixture.CreateLogDefintionWithRecurringWeeklySchedule();
            logDefinition.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            dao.Insert(logDefinition);
            long existingLinkId = logDefinition.DocumentLinks[0].IdValue;
            DocumentLink newLink = DocumentLinkFixture.CreateAnotherNewDocumentLink();
            logDefinition.DocumentLinks.Add(newLink);
            dao.Update(logDefinition);
            LogDefinition retrievedLog = dao.QueryById(logDefinition.IdValue);
            Assert.AreEqual(logDefinition.DocumentLinks.Count, retrievedLog.DocumentLinks.Count);

            Assert.That(retrievedLog.DocumentLinks, Has.Some.Property("Id").EqualTo( existingLinkId));

            Assert.That(retrievedLog.DocumentLinks, Has.Some.Property("Title").EqualTo(newLink.Title));
            Assert.That(retrievedLog.DocumentLinks,
                        Has.Some.Property("TitleWithUrl").EqualTo(newLink.TitleWithUrl));
        }

        [Ignore] [Test]
        public void ShouldBeAbleToInsertAndQueryLogDefinitionsWithMultipleFunctionalLocations()
        {
            LogDefinition logDefinition = LogDefinitionFixture.CreateOperatingEngineerLogDefintionWithRecurringWeeklySchedule();
            logDefinition.FunctionalLocations = new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF(), FunctionalLocationFixture.GetReal_SR1_PLT3_BDP3() };
            logDefinition = dao.Insert(logDefinition);

            LogDefinition retrievedLogDefinition = dao.QueryById(logDefinition.IdValue);
            AssertLogDefinitionAreEqual(logDefinition, retrievedLogDefinition);
        }


        [Ignore] [Test]
        public void ShouldInsertOperatingEngineerLogDefinition_False()
        {
            LogDefinition logDefinition = LogDefinitionFixture.CreateLogDefintionWithRecurringWeeklySchedule();
            dao.Insert(logDefinition);

            LogDefinition inserted = dao.QueryById(logDefinition.IdValue);
            Assert.IsFalse(inserted.IsOperatingEngineerLog);
        }

        [Ignore] [Test]
        public void ShouldInsertOperatingEngineerLogDefinition_True()
        {
            LogDefinition logDefinition = LogDefinitionFixture.CreateOperatingEngineerLogDefintionWithRecurringWeeklySchedule();
            dao.Insert(logDefinition);

            LogDefinition inserted = dao.QueryById(logDefinition.IdValue);
            Assert.IsTrue(inserted.IsOperatingEngineerLog);
        }

        [Ignore] [Test]
        public void ShouldUpdateInsertAndDeleteCustomFieldEntries()
        {
            WorkAssignment wa = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA"));

            CustomFieldGroup group1 = new CustomFieldGroup("group1", new List<WorkAssignment>(), new List<CustomField>(), true, true, true,true);       //ayman custom fields DMND0010030
            group1.WorkAssignments.Add(wa);
            CustomField field1 = new CustomField(null, "field1", 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            CustomField field2 = new CustomField(null, "field2", 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            group1.Fields.Add(field1);
            group1.Fields.Add(field2);
            customFieldGroupDao.Insert(group1);

            LogDefinition logDefinition = LogDefinitionFixture.CreateLogDefinition(null, LogType.Standard, wa);            
            CustomFieldEntry entry1 = new CustomFieldEntry(field1) {FieldEntry = "val"};
            CustomFieldEntry entry2 = new CustomFieldEntry(field2) {FieldEntry = null};
            logDefinition.CustomFieldEntries.Clear();
            logDefinition.CustomFieldEntries.Add(entry1);
            logDefinition.CustomFields.Clear();
            logDefinition.CustomFields.Add(field1);
            logDefinition.CustomFields.Add(field2);
            dao.Insert(logDefinition);

            LogDefinition requeriedLogDefinition = dao.QueryById(logDefinition.IdValue);
            Assert.AreEqual(1, requeriedLogDefinition.CustomFieldEntries.Count);
            Assert.IsTrue(requeriedLogDefinition.CustomFieldEntries.Exists(entry => entry.FieldEntry == "val"));

            requeriedLogDefinition.CustomFieldEntries.Clear();
            dao.Update(requeriedLogDefinition);

            LogDefinition reRequeriedLogDefinition = dao.QueryById(logDefinition.IdValue);
            Assert.AreEqual(0, reRequeriedLogDefinition.CustomFieldEntries.Count);
        }

        private LogDefinition InsertLogDefinition()
        {
            LogDefinition logDefinition = BuildInsertableLogDefinition();
            return dao.Insert(logDefinition);
        }

        private LogDefinition BuildInsertableLogDefinition()
        {
            WorkAssignment newWorkAssignment = new WorkAssignment("Fake WA", "Fake WA", "General", 1, RoleFixture.GetRealRoleA(1));
            newWorkAssignment = workAssignmentDao.Insert(newWorkAssignment);

            LogDefinition logDefinition =
                new LogDefinition(RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11FromJan10Onward(),
                                  new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_PLT3_BDP3() },
                                  false, false, false, false, false, false, false, roleInDb,
                                  DateTimeFixture.DateTimeNow, UserFixture.CreateUserWithGivenId(1), UserFixture.CreateUserWithGivenId(1),
                                  DateTimeFixture.DateTimeNow, new List<DocumentLink>(),                                  
                                  "comments", "comments",                            
                                  LogType.Standard, newWorkAssignment, false, null, null, true);

            return logDefinition;
        }

        private LogDefinition BuildInsertableStandingOrder()
        {
            WorkAssignment newWorkAssignment = new WorkAssignment("Fake WA", "Fake WA", "General", 1, RoleFixture.GetRealRoleA(1));
            newWorkAssignment = workAssignmentDao.Insert(newWorkAssignment);

            LogDefinition logDefinition =
                new LogDefinition(RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11FromJan10Onward(),
                                  new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_PLT3_BDP3() },
                                  false, false, false, false, false, false, false, roleInDb,
                                  DateTimeFixture.DateTimeNow, UserFixture.CreateUserWithGivenId(1), UserFixture.CreateUserWithGivenId(1),
                                  DateTimeFixture.DateTimeNow, new List<DocumentLink>(),                                  
                                  "comments", "comments",                            
                                  LogType.DailyDirective, newWorkAssignment, false, null, null, true);

            return logDefinition;
        }

        private LogDefinition InsertLogDefinitionWithTwoDocumentLinks()
        {
            LogDefinition logDefinition = LogDefinitionFixture.CreateLogDefintionWithRecurringWeeklySchedule();
            logDefinition.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            logDefinition.DocumentLinks.Add(DocumentLinkFixture.CreateAnotherNewDocumentLink());
            dao.Insert(logDefinition);
            return logDefinition;
        }
    }
}