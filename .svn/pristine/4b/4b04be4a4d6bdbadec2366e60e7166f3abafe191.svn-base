using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class SummaryLogDaoTest : AbstractDaoTest
    {
        private ISummaryLogDao dao;
        private IFunctionalLocationDao functionalLocationDao;
        private IShiftPatternDao shiftPatternDao;
        private IWorkAssignmentDao workAssignmentDao;
        private ICustomFieldGroupDao customFieldGroupDao;
        private ICustomFieldDao customFieldDao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ISummaryLogDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            shiftPatternDao = DaoRegistry.GetDao<IShiftPatternDao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
            customFieldGroupDao = DaoRegistry.GetDao<ICustomFieldGroupDao>();
            customFieldDao = DaoRegistry.GetDao<ICustomFieldDao>();
        }

        protected override void Cleanup()
        {
        }
        
        [Ignore] [Test]
        public void AddNewShouldReturnTheLogWithNewId()
        {
            SummaryLog logToInsert = SummaryLogFixture.CreateSummaryLog();

            logToInsert.LastModifiedDate = DateTimeFixture.DateTimeNow;
            logToInsert.LastModifiedBy = UserFixture.CreateOperatorMickeyInFortMcMurrySite(); //randomly choosing ID
            logToInsert = dao.Insert(logToInsert);
            Assert.IsNotNull(logToInsert.Id);
            Assert.IsNotNull(logToInsert.CreationUser);
            Assert.IsNotNull(logToInsert.CreatedShiftPattern);            
        }

        private static IEnumerable<FunctionalLocation> GetFlocsToInsert()
        {
            FunctionalLocation floc1 = FunctionalLocationFixture.GetReal_SR1_PLT3_GEN3();
            FunctionalLocation floc2 = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL_SWM();

            return new List<FunctionalLocation> { floc1, floc2 };
        }

        [Ignore] [Test]
        public void AddNewShouldReturnTheSameLogWhenQueried()
        {
            SummaryLog logToInsert = SummaryLogFixture.CreateSummaryLog();
                     
            logToInsert.LastModifiedDate = DateTimeFixture.DateTimeNow;
            logToInsert.LastModifiedBy = UserFixture.CreateOperatorMickeyInFortMcMurrySite(); //randomly choosing ID            
            logToInsert.WorkAssignment = new WorkAssignment(1, null, null, null, 0, null, true, true, null, null, null,true,true);

            logToInsert.FunctionalLocations.Clear();
            logToInsert.FunctionalLocations.AddRange(GetFlocsToInsert());

            logToInsert = dao.Insert(logToInsert);
            SummaryLog resultTarget = dao.QueryById(logToInsert.IdValue);          
            Assert.AreEqual(logToInsert.EnvironmentalHealthSafetyFollowUp, resultTarget.EnvironmentalHealthSafetyFollowUp);            
            Assert.AreEqual(logToInsert.InspectionFollowUp, resultTarget.InspectionFollowUp);
            Assert.AreEqual(logToInsert.LogDateTime, resultTarget.LogDateTime);
            Assert.AreEqual(logToInsert.OperationsFollowUp, resultTarget.OperationsFollowUp);
            Assert.AreEqual(logToInsert.ProcessControlFollowUp, resultTarget.ProcessControlFollowUp);
            Assert.AreEqual(logToInsert.SupervisionFollowUp, resultTarget.SupervisionFollowUp);
            Assert.AreEqual(logToInsert.CreatedByRole.Id, resultTarget.CreatedByRole.Id);
            Assert.AreEqual(logToInsert.CreationUser.Id, resultTarget.CreationUser.Id);
            Assert.AreEqual(logToInsert.CreatedShiftPattern.Id, resultTarget.CreatedShiftPattern.Id);            
            Assert.AreEqual(1, resultTarget.WorkAssignment.Id);
            Assert.AreEqual(2, resultTarget.FunctionalLocations.Count);
            Assert.AreEqual(DataSource.MANUAL, logToInsert.DataSource);
        }
       
        [Ignore] [Test]
        public void AddNewShouldReturnTheSameLogWhenQueried_ReplyFields()
        {
            SummaryLog logToReplyTo = SummaryLogFixture.CreateSummaryLog();

            logToReplyTo.LastModifiedDate = DateTimeFixture.DateTimeNow;
            logToReplyTo.LastModifiedBy = UserFixture.CreateOperatorMickeyInFortMcMurrySite(); //randomly choosing ID            
            logToReplyTo.WorkAssignment = new WorkAssignment(1, null, null, null, 0, null, true, true, null, null, null,true,true);
            logToReplyTo.FunctionalLocations.Clear();
            logToReplyTo.FunctionalLocations.AddRange(GetFlocsToInsert());

            logToReplyTo = dao.Insert(logToReplyTo);

            SummaryLog logToInsert = SummaryLogFixture.CreateSummaryLog();
         
            logToInsert.LastModifiedDate = DateTimeFixture.DateTimeNow;
            logToInsert.LastModifiedBy = UserFixture.CreateOperatorMickeyInFortMcMurrySite(); //randomly choosing ID            
            logToInsert.WorkAssignment = new WorkAssignment(1, null, null, null, 0, null, true, true, null, null, null,true,true);
            logToInsert.FunctionalLocations.Clear();
            logToInsert.FunctionalLocations.AddRange(GetFlocsToInsert());

            logToInsert.SetReplyTo(logToReplyTo);

            logToInsert = dao.Insert(logToInsert);

            {
                SummaryLog resultTarget = dao.QueryById(logToInsert.IdValue);                     
                Assert.IsNotNull(resultTarget.RootLogId);
                Assert.AreEqual(logToReplyTo.Id, resultTarget.RootLogId);
                Assert.AreEqual(logToReplyTo.Id, resultTarget.ReplyToLogId);         
            }   
        }
       
        [Ignore] [Test] 
        public void RemoveLogShouldPreformASoftDeletePreventingFurtherQueriesOnTheLog()
        {
            SummaryLog logToInsert = SummaryLogFixture.CreateSummaryLog();
            logToInsert.LastModifiedDate = DateTimeFixture.DateTimeNow;
            logToInsert.LastModifiedBy = UserFixture.CreateOperatorMickeyInFortMcMurrySite(); //randomly choosing ID
            logToInsert = dao.Insert(logToInsert);
            SummaryLog logForDeletion = dao.QueryById(logToInsert.IdValue);
            Assert.IsNotNull(logForDeletion);
            dao.Remove(logForDeletion);
            SummaryLog removedLog = dao.QueryById(logForDeletion.IdValue);
            Assert.IsTrue(removedLog.Deleted);
        }

        [Ignore] [Test]
        public void UpdatingAllFieldsInNewLogShouldUpdateAllFields()
        {
            DateTime modifiedDate = new DateTime(2005, 11, 25, 10, 0, 0);
            SummaryLog insertedLog = SummaryLogFixture.CreateSummaryLog();
            insertedLog.LastModifiedBy = UserFixture.CreateOperatorMickeyInFortMcMurrySite();
            insertedLog.LastModifiedDate = modifiedDate.SubtractDays(1);

            insertedLog.FunctionalLocations.Clear();
            insertedLog.FunctionalLocations.AddRange(GetFlocsToInsert());

            Assert.AreEqual(DataSource.MANUAL, insertedLog.DataSource);

            dao.Insert(insertedLog);
            Assert.IsNotNull(insertedLog.Id);
            SummaryLog expectedChangedLog = dao.QueryById(insertedLog.IdValue);

            expectedChangedLog.DataSource = DataSource.HANDOVER;
            expectedChangedLog.InspectionFollowUp = !expectedChangedLog.InspectionFollowUp;
            expectedChangedLog.OperationsFollowUp = !expectedChangedLog.OperationsFollowUp;
            expectedChangedLog.ProcessControlFollowUp = !expectedChangedLog.ProcessControlFollowUp;
            expectedChangedLog.SupervisionFollowUp = !expectedChangedLog.SupervisionFollowUp;
            expectedChangedLog.EnvironmentalHealthSafetyFollowUp = !expectedChangedLog.EnvironmentalHealthSafetyFollowUp;
            expectedChangedLog.LastModifiedBy = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            expectedChangedLog.LastModifiedDate = modifiedDate;
            expectedChangedLog.FunctionalLocations.RemoveAt(1);
           
            dao.Update(expectedChangedLog);
            SummaryLog actualChangedLog = dao.QueryById(expectedChangedLog.IdValue);            
            Assert.AreEqual(expectedChangedLog.CreationUser.Id, actualChangedLog.CreationUser.Id);
            Assert.AreEqual(expectedChangedLog.LastModifiedBy.Id, actualChangedLog.LastModifiedBy.Id);
            actualChangedLog.LastModifiedBy = expectedChangedLog.LastModifiedBy;
            Assert.AreEqual(actualChangedLog, expectedChangedLog);
            Assert.AreEqual(1, actualChangedLog.FunctionalLocations.Count);
            Assert.AreEqual(DataSource.HANDOVER, actualChangedLog.DataSource);
        }
        
        [Ignore] [Test]
        public void InsertShouldInsertDocumentLinks()
        {
            SummaryLog logForInsert = InsertLogWithTwoDocumentLinks();
            SummaryLog retrievedLog = dao.QueryById(logForInsert.IdValue);
            Assert.AreEqual(logForInsert.DocumentLinks.Count, retrievedLog.DocumentLinks.Count);

            Assert.That(retrievedLog.DocumentLinks, Has.Some.EqualTo(logForInsert.DocumentLinks[0]));
            Assert.That(retrievedLog.DocumentLinks, Has.Some.EqualTo(logForInsert.DocumentLinks[1]));
        }
      
        [Ignore] [Test]
        public void UpdateShouldRemoveDeletedDocumentLinks()
        {
            SummaryLog log = InsertLogWithTwoDocumentLinks();
            long removedLinkId = log.DocumentLinks[0].IdValue;
            long retainedLinkId = log.DocumentLinks[1].IdValue;
            log.DocumentLinks.Remove(log.DocumentLinks[0]);
            dao.Update(log);
            SummaryLog retrievedLog = dao.QueryById(log.IdValue);
            Assert.AreEqual(log.DocumentLinks.Count, retrievedLog.DocumentLinks.Count);

            Assert.That(retrievedLog.DocumentLinks, Has.None.Property("Id").EqualTo(removedLinkId));
            Assert.That(retrievedLog.DocumentLinks, Has.Some.Property("Id").EqualTo(retainedLinkId));

        }

        [Ignore] [Test]
        public void UpdateShouldAddNewDocumentLink()
        {
            SummaryLog log = SummaryLogFixture.CreateSummaryLog();
            log.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            dao.Insert(log);
            long existingLinkId = log.DocumentLinks[0].IdValue;
            DocumentLink newLink = DocumentLinkFixture.CreateAnotherNewDocumentLink();
            log.DocumentLinks.Add(newLink);
            dao.Update(log);
            SummaryLog retrievedLog = dao.QueryById(log.IdValue);
            Assert.AreEqual(log.DocumentLinks.Count, retrievedLog.DocumentLinks.Count);

            Assert.That(retrievedLog.DocumentLinks, Has.Some.Property("Id").EqualTo(existingLinkId));

            Assert.That(retrievedLog.DocumentLinks, Has.Some.Property("Title").EqualTo(newLink.Title));
            Assert.That(retrievedLog.DocumentLinks,
                        Has.Some.Property("TitleWithUrl").EqualTo(newLink.TitleWithUrl));                
        }

        [Ignore] [Test]
        public void ShouldFindLastSummaryLogThatUserCreated()
        {
            ShiftPattern shift = shiftPatternDao.Insert(ShiftPatternFixture.Create8HourDayShift());

            DateTime loggedDateA = DateTimeFixture.DateTimeNow.TruncateToDay().AddHours(10);
            DateTime loggedDateB = loggedDateA.AddMinutes(5);

            SummaryLog logA = SummaryLogFixture.CreateSummaryLog(loggedDateA, shift, RoleFixture.GetRealRoleA(SiteFixture.Sarnia().IdValue));
            SummaryLog logB = SummaryLogFixture.CreateSummaryLog(loggedDateB, shift, RoleFixture.GetRealRoleA(SiteFixture.Sarnia().IdValue));

            logA = dao.Insert(logA);
            logB = dao.Insert(logB);

            Assert.AreEqual(logA.CreationUser, logB.CreationUser);

            SummaryLog resultLog = dao.QueryLatestSummaryLogForUser(logA.CreationUser.IdValue);
            Assert.AreEqual(logB.Id, resultLog.Id);

            // deleted logs should be ignored
            dao.Remove(logB);
            resultLog = dao.QueryLatestSummaryLogForUser(logA.CreationUser.IdValue);
            Assert.AreEqual(logA.Id, resultLog.Id);
        }

        private SummaryLog InsertLogWithTwoDocumentLinks()
        {
            SummaryLog summaryLog = SummaryLogFixture.CreateSummaryLog();
            summaryLog.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            summaryLog.DocumentLinks.Add(DocumentLinkFixture.CreateAnotherNewDocumentLink());
            dao.Insert(summaryLog);
            return summaryLog;
        }

        [Ignore] [Test]
        public void ShouldInsertAndUpdateComments()
        {
            SummaryLog log = SummaryLogFixture.CreateSummaryLog();
            log.RtfComments = "t1-rtf";
            log.PlainTextComments = "t1-plain";
            log.DorComments = "dt1";
           
            log = dao.Insert(log);

            {
                SummaryLog requeried = dao.QueryById(log.IdValue);
                
                Assert.AreEqual("t1-rtf", requeried.RtfComments);
                Assert.AreEqual("t1-plain", requeried.PlainTextComments);
                Assert.AreEqual("dt1", requeried.DorComments);
            }

            log.RtfComments = "update 1 - rtf";
            log.PlainTextComments = "update 1 - plain";
            log.DorComments = "update dor text 1";
            
            dao.Update(log);

            {
                SummaryLog requeried = dao.QueryById(log.IdValue);

                Assert.AreEqual("update 1 - rtf", requeried.RtfComments);
                Assert.AreEqual("update 1 - plain", requeried.PlainTextComments);
                Assert.AreEqual("update dor text 1", requeried.DorComments);               
            }
        }

        [Ignore] [Test]
        public void ShouldInsertAndUpdateCustomFieldEntries()
        {
            SummaryLog log = SummaryLogFixture.CreateSummaryLog();

            log.CustomFieldEntries.Add(new CustomFieldEntry(null, CustomFieldFixture.CustomFieldExistingInDatabase1().IdValue, "field name one", "entry one", null,null, 1, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));
            log.CustomFieldEntries.Add(new CustomFieldEntry(null, CustomFieldFixture.CustomFieldExistingInDatabase2().IdValue, "field name two", null, new decimal(2.1),null, 2, CustomFieldType.NumericValue, CustomFieldPhdLinkType.Off,null));

            log.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase1());
            log.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase2());

            log = dao.Insert(log);

            {
                SummaryLog requeried = dao.QueryById(log.IdValue);
                Assert.IsTrue(requeried.CustomFieldEntries.Exists(entry => entry.CustomFieldName == "field name one" && entry.FieldEntry == "entry one"));
                Assert.IsTrue(requeried.CustomFieldEntries.Exists(entry => entry.CustomFieldName == "field name two" && entry.NumericFieldEntry == new decimal(2.1)));
                Assert.AreEqual(2, requeried.CustomFieldEntries.Count);
            }

            log.CustomFieldEntries.Find(entry => entry.Type.Equals(CustomFieldType.GeneralText)).FieldEntry = "update one";
            log.CustomFieldEntries.Find(entry => entry.Type.Equals(CustomFieldType.NumericValue)).NumericFieldEntry = new decimal(99.234);

            dao.Update(log);

            {
                SummaryLog requeried = dao.QueryById(log.IdValue);
                Assert.IsTrue(requeried.CustomFieldEntries.Exists(entry => entry.CustomFieldName == "field name one" && entry.FieldEntry == "update one"));
                Assert.IsTrue(requeried.CustomFieldEntries.Exists(entry => entry.CustomFieldName == "field name two" && entry.NumericFieldEntry == new decimal(99.234)));
                Assert.AreEqual(2, requeried.CustomFieldEntries.Count);
            }
        }

        [Ignore] [Test]
        public void ShouldInsertSummaryLogWithCustomFieldGroupsBasedOnCustomFieldsOnSummaryLog()
        {
            WorkAssignment wa = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA"));

            CustomFieldGroup group1 = new CustomFieldGroup("group1", new List<WorkAssignment>(), new List<CustomField>(), true, true, true,true);      //ayman custom fields DMND0010030
            group1.WorkAssignments.Add(wa);
            CustomField field1 = new CustomField(null, "field1", 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            group1.Fields.Add(field1);
            customFieldGroupDao.Insert(group1);

            CustomFieldGroup group2 = new CustomFieldGroup("group2", new List<WorkAssignment>(), new List<CustomField>(), true, true, true,true);          //ayman custom fields DMND0010030
            group2.WorkAssignments.Add(wa);
            CustomField field2 = new CustomField(null, "field2", 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            group2.Fields.Add(field2);
            customFieldGroupDao.Insert(group2);

            // case 1: do a regular log insert. The log should be associated with both groups because it has both fields on it.
            {
                SummaryLog log = SummaryLogFixture.CreateSummaryLog();
                log.WorkAssignment = wa;                
                CustomFieldEntry entry1 = new CustomFieldEntry(field1) {FieldEntry = "val1"};
                CustomFieldEntry entry2 = new CustomFieldEntry(field2) {FieldEntry = "val2"};
                log.CustomFieldEntries.Clear();
                log.CustomFieldEntries.Add(entry1);
                log.CustomFieldEntries.Add(entry2);
                log.CustomFields.Clear();
                log.CustomFields.Add(field1);
                log.CustomFields.Add(field2);
                dao.Insert(log);

                List<CustomField> customFields = customFieldDao.QueryByCustomFieldGroupsForSummaryLogs(log.IdValue);
                Assert.AreEqual(2, customFields.Count);
                Assert.IsTrue(customFields.Exists(field => field.Name == "field1"));
                Assert.IsTrue(customFields.Exists(field => field.Name == "field2"));
            }

            // case 2: insert the log explicitly for group1 only by only putting field1 on the log.
            {
                SummaryLog log = SummaryLogFixture.CreateSummaryLog();
                log.WorkAssignment = wa;                
                CustomFieldEntry entry1 = new CustomFieldEntry(field1) {FieldEntry = "val1"};
                CustomFieldEntry entry2 = new CustomFieldEntry(field2) {FieldEntry = "val2"};
                log.CustomFieldEntries.Clear();
                log.CustomFieldEntries.Add(entry1);
                log.CustomFieldEntries.Add(entry2);
                log.CustomFields.Clear();
                log.CustomFields.Add(field1);
                dao.Insert(log);

                List<CustomField> customFields = customFieldDao.QueryByCustomFieldGroupsForSummaryLogs(log.IdValue);
                Assert.AreEqual(1, customFields.Count);
                Assert.IsTrue(customFields.Exists(field => field.Name == "field1"));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByFlocListDateRangeShiftAndWorkAssignment_VaryFloc()
        {
            FunctionalLocation floc1 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A"));
            FunctionalLocation floc2 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A-B"));
            FunctionalLocation floc3 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A-B-C"));
            FunctionalLocation floc4 = functionalLocationDao.Insert(FunctionalLocationFixture.CreateNew("A-B-C-D"));

            User user = UserFixture.CreateOperatorGoofyInFortMcMurrySite();

            ShiftPattern shift = shiftPatternDao.Insert(ShiftPatternFixture.Create8HourDayShift());
            DateTime now = shift.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));

            WorkAssignment workAssignment = new WorkAssignment("Diet Coker Bored Man", "WA", "General", floc1.Site.IdValue, RoleFixture.GetRealRoleA(floc1.Site.IdValue));
            workAssignment = workAssignmentDao.Insert(workAssignment);

            long id1;
            {
                SummaryLog log = CreateLog(shift, floc1, now, user, workAssignment);
                log.FunctionalLocations = new List<FunctionalLocation> { floc1 };
                log = dao.Insert(log);
                id1 = log.IdValue;
            }
            long id2;
            {
                SummaryLog log = CreateLog(shift, floc2, now, user, workAssignment);
                log.FunctionalLocations = new List<FunctionalLocation> { floc2 };
                log = dao.Insert(log);
                id2 = log.IdValue;
            }
            long id3;
            {
                SummaryLog log = CreateLog(shift, floc3, now, user, workAssignment);
                log.FunctionalLocations = new List<FunctionalLocation> { floc3 };
                log = dao.Insert(log);
                id3 = log.IdValue;
            }
            long id4;
            {
                SummaryLog log = CreateLog(shift, floc4, now, user, workAssignment);
                log.FunctionalLocations = new List<FunctionalLocation> { floc4 };
                log = dao.Insert(log);
                id4 = log.IdValue;
            }

            {
                List<SummaryLog> results = dao.QueryByFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(floc1), shift.IdValue, workAssignment.Id, user.IdValue);
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
            }
            {
                List<SummaryLog> results = dao.QueryByFlocListDateRangeShiftAndWorkAssignment(
                    now.AddSeconds(-1), now.AddSeconds(1), new RootFlocSet(floc1), shift.IdValue, workAssignment.Id, user.IdValue);
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
            }
            {
                List<SummaryLog> results = dao.QueryByFlocListDateRangeShiftAndWorkAssignment(
                    now.AddSeconds(1), now.AddSeconds(1), new RootFlocSet(floc1), shift.IdValue, workAssignment.Id, user.IdValue);
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
            }
            {
                List<SummaryLog> results = dao.QueryByFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(new List<FunctionalLocation> { floc1, floc2, floc3, floc4 }), shift.IdValue, workAssignment.Id, user.IdValue);
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsTrue(results.Exists(obj => obj.Id == id2));
                Assert.IsTrue(results.Exists(obj => obj.Id == id3));
                Assert.IsTrue(results.Exists(obj => obj.Id == id4));
            }
            {
                List<SummaryLog> results = dao.QueryByFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(floc1), shift.IdValue, workAssignment.Id, user.IdValue);
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsTrue(results.Exists(obj => obj.Id == id2));
                Assert.IsTrue(results.Exists(obj => obj.Id == id3));
                Assert.IsTrue(results.Exists(obj => obj.Id == id4));
            }
            {
                List<SummaryLog> results = dao.QueryByFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(floc2), shift.IdValue, workAssignment.Id, user.IdValue);
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
                Assert.IsTrue(results.Exists(obj => obj.Id == id2));
                Assert.IsTrue(results.Exists(obj => obj.Id == id3));
                Assert.IsTrue(results.Exists(obj => obj.Id == id4));
            }
            {
                List<SummaryLog> results = dao.QueryByFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(floc3), shift.IdValue, workAssignment.Id, user.IdValue);
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
                Assert.IsTrue(results.Exists(obj => obj.Id == id3));
                Assert.IsTrue(results.Exists(obj => obj.Id == id4));
            }
            {
                List<SummaryLog> results = dao.QueryByFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(floc4), shift.IdValue, workAssignment.Id, user.IdValue);
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
                Assert.IsFalse(results.Exists(obj => obj.Id == id3));
                Assert.IsTrue(results.Exists(obj => obj.Id == id4));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByFlocListDateRangeShiftAndWorkAssignment_VaryShift()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            User user = UserFixture.CreateOperatorGoofyInFortMcMurrySite();

            ShiftPattern shift1 = shiftPatternDao.Insert(ShiftPatternFixture.Create8HourDayShift());
            ShiftPattern shift2 = shiftPatternDao.Insert(ShiftPatternFixture.Create8HourDayShift());
            DateTime now = shift1.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));

            WorkAssignment workAssignment = new WorkAssignment("Diet Coker Bored Man", "WA", "General", floc.Site.IdValue, RoleFixture.GetRealRoleA(floc.Site.IdValue));
            workAssignment = workAssignmentDao.Insert(workAssignment);

            long id1;
            {
                SummaryLog log = CreateLog(shift1, floc, now, user, workAssignment);
                log.FunctionalLocations = new List<FunctionalLocation> { floc };
                log = dao.Insert(log);
                id1 = log.IdValue;
            }
            long id2;
            {
                SummaryLog log = CreateLog(shift2, floc, now, user, workAssignment);
                log.FunctionalLocations = new List<FunctionalLocation> { floc };
                log = dao.Insert(log);
                id2 = log.IdValue;
            }

            {
                List<SummaryLog> results = dao.QueryByFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(floc), shift1.IdValue, workAssignment.Id, user.IdValue);
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
            }
            {
                List<SummaryLog> results = dao.QueryByFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(floc), shift2.IdValue, workAssignment.Id, user.IdValue);
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
                Assert.IsTrue(results.Exists(obj => obj.Id == id2));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByFlocListDateRangeShiftAndWorkAssignment_VaryDateRange()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            User user = UserFixture.CreateOperatorGoofyInFortMcMurrySite();

            ShiftPattern shift = shiftPatternDao.Insert(ShiftPatternFixture.Create8HourDayShift());
            DateTime now = shift.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));

            WorkAssignment workAssignment = new WorkAssignment("Diet Coker Bored Man", "WA", "General", floc.Site.IdValue, RoleFixture.GetRealRoleA(floc.Site.IdValue));
            workAssignment = workAssignmentDao.Insert(workAssignment);

            long id1;
            {
                SummaryLog log = CreateLog(shift, floc, now, user, workAssignment);
                log.FunctionalLocations = new List<FunctionalLocation> { floc };
                log = dao.Insert(log);
                id1 = log.IdValue;
            }

            {
                List<SummaryLog> results = dao.QueryByFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(floc), shift.IdValue, workAssignment.Id, user.IdValue);
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
            }
            {
                List<SummaryLog> results = dao.QueryByFlocListDateRangeShiftAndWorkAssignment(
                    now.AddSeconds(-1), now.AddSeconds(1), new RootFlocSet(floc), shift.IdValue, workAssignment.Id, user.IdValue);
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
            }
            {
                List<SummaryLog> results = dao.QueryByFlocListDateRangeShiftAndWorkAssignment(
                    now.AddSeconds(1), now.AddSeconds(1), new RootFlocSet(floc), shift.IdValue, workAssignment.Id, user.IdValue);
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
            }
        }

        [Ignore] [Test]
        public void ShouldQueryByFlocListDateRangeShiftAndWorkAssignment_VaryWorkAssignment()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            User user = UserFixture.CreateOperatorGoofyInFortMcMurrySite();

            ShiftPattern shift = shiftPatternDao.Insert(ShiftPatternFixture.Create8HourDayShift());
            DateTime now = shift.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));

            WorkAssignment assignment = new WorkAssignment("Diet Coker Bored Man", "WA", "General", floc.Site.IdValue, RoleFixture.GetRealRoleA(floc.Site.IdValue));
            assignment = workAssignmentDao.Insert(assignment);

            long id1;
            {
                SummaryLog log = CreateLog(shift, floc, now, user, assignment);
                log.FunctionalLocations = new List<FunctionalLocation> { floc };
                log = dao.Insert(log);
                id1 = log.IdValue;
            }

            long id2;
            {
                SummaryLog log = CreateLog(shift, floc, now, user, null);
                log.FunctionalLocations = new List<FunctionalLocation> { floc };
                log = dao.Insert(log);
                id2 = log.IdValue;
            }

            // Should get 1 and not 2
            {
                List<SummaryLog> results = dao.QueryByFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(floc), shift.IdValue, assignment.Id, user.IdValue);
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
            }     
      
            // Should get 2 and not 1
            {
                List<SummaryLog> results = dao.QueryByFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(floc), shift.IdValue, null, user.IdValue);
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
                Assert.IsTrue(results.Exists(obj => obj.Id == id2));
            }           
        }

        [Ignore] [Test]
        public void ShouldQueryByFlocListDateRangeShiftAndAssignment_RevertToUserIfAssignmentIsNull()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();

            User user1 = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            User user2 = UserFixture.CreateOperatorOltUser1InFortMcMurrySite();

            ShiftPattern shift = shiftPatternDao.Insert(ShiftPatternFixture.Create8HourDayShift());
            DateTime now = shift.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));

            WorkAssignment assignment1 = new WorkAssignment("Diet Coker Bored Man", "WA", "General", floc.Site.IdValue, RoleFixture.GetRealRoleA(floc.Site.IdValue));
            assignment1 = workAssignmentDao.Insert(assignment1);

            long id1;
            {
                SummaryLog log = CreateLog(shift, floc, now, user1, assignment1);
                log.FunctionalLocations = new List<FunctionalLocation> { floc };
                log = dao.Insert(log);
                id1 = log.IdValue;
            }

            long id2;
            {
                SummaryLog log = CreateLog(shift, floc, now, user1, null);
                log.FunctionalLocations = new List<FunctionalLocation> { floc };
                log = dao.Insert(log);
                id2 = log.IdValue;
            }

            long id3;
            {
                SummaryLog log = CreateLog(shift, floc, now, user2, assignment1);
                log.FunctionalLocations = new List<FunctionalLocation> { floc };
                log = dao.Insert(log);
                id3 = log.IdValue;
            }

            long id4;
            {
                SummaryLog log = CreateLog(shift, floc, now, user2, null);
                log.FunctionalLocations = new List<FunctionalLocation> { floc };
                log = dao.Insert(log);
                id4 = log.IdValue;
            }

            long id5;
            {
                SummaryLog log = CreateLog(shift, floc, now, user1, null);
                log.FunctionalLocations = new List<FunctionalLocation> { floc };
                log = dao.Insert(log);
                id5 = log.IdValue;
            }

            // Should Find id1, id3 because it should match the assignment
            {
                List<SummaryLog> results = dao.QueryByFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(floc), shift.IdValue, assignment1.Id, user1.IdValue);
                Assert.IsTrue(results.Exists(obj => obj.Id == id1));
                Assert.IsFalse(results.Exists(obj => obj.Id == id2));
                Assert.IsTrue(results.Exists(obj => obj.Id == id3));
                Assert.IsFalse(results.Exists(obj => obj.Id == id4));
                Assert.IsFalse(results.Exists(obj => obj.Id == id5));
            }

            // Should Find Id2, Id5 because it should look for logs with null work assignments that have a matching user.
            {
                List<SummaryLog> results = dao.QueryByFlocListDateRangeShiftAndWorkAssignment(
                    now, now, new RootFlocSet(floc), shift.IdValue, null, user1.IdValue);
                Assert.IsFalse(results.Exists(obj => obj.Id == id1));
                Assert.IsTrue(results.Exists(obj => obj.Id == id2));
                Assert.IsFalse(results.Exists(obj => obj.Id == id3));
                Assert.IsFalse(results.Exists(obj => obj.Id == id4));
                Assert.IsTrue(results.Exists(obj => obj.Id == id5));
            }
        }

        [Ignore] [Test]
        public void ShouldUpdateInsertAndDeleteCustomFieldEntries()
        {
            WorkAssignment wa = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA"));

            CustomFieldGroup group1 = new CustomFieldGroup("group1", new List<WorkAssignment>(), new List<CustomField>(), true, true, true,true);           //ayman custom fields DMND0010030
            group1.WorkAssignments.Add(wa);
            CustomField field1 = new CustomField(null, "field1", 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            CustomField field2 = new CustomField(null, "field2", 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            group1.Fields.Add(field1);
            group1.Fields.Add(field2);
            customFieldGroupDao.Insert(group1);

            SummaryLog log = SummaryLogFixture.CreateSummaryLog();            
            CustomFieldEntry entry1 = new CustomFieldEntry(field1) {FieldEntry = "val"};
            log.CustomFieldEntries.Clear();
            log.CustomFieldEntries.Add(entry1);
            log.CustomFields.Clear();
            log.CustomFields.Add(field1);
            log.CustomFields.Add(field2);
            dao.Insert(log);

            SummaryLog requeriedLog = dao.QueryById(log.IdValue);
            Assert.AreEqual(1, requeriedLog.CustomFieldEntries.Count);
            Assert.IsTrue(requeriedLog.CustomFieldEntries.Exists(entry => entry.FieldEntry == "val"));

            requeriedLog.CustomFieldEntries.Clear();
            dao.Update(requeriedLog);

            SummaryLog reRequeriedLog = dao.QueryById(log.IdValue);
            Assert.AreEqual(0, reRequeriedLog.CustomFieldEntries.Count);
        }


        private static SummaryLog CreateLog(
            ShiftPattern shiftPattern, FunctionalLocation floc, DateTime loggedDateTime, User user, WorkAssignment assignment)
        {
            return new SummaryLog(new List<FunctionalLocation>{floc},
                                  "RTF Comments",
                                  "Plain Comments",
                                  "DOR Comments",
                                  DataSource.MANUAL,
                                  false, false, false, false, false, false,
                                  loggedDateTime,
                                  loggedDateTime,
                                  shiftPattern,
                                  user,
                                  RoleFixture.GetRealRoleA(floc.Site.IdValue),
                                  user,
                                  loggedDateTime,
                                  new List<DocumentLink>(),
                                  assignment, null, null,
                                  null, null, false);
        }


    }
}
