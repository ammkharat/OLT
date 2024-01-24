using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class LogDaoTest : AbstractDaoTest
    {
        private ILogDao dao;
        private ILogDefinitionDao definitionDao;
        private ILogDTODao dtoDao;
        private IWorkAssignmentDao workAssignmentDao;
        private ICustomFieldGroupDao customFieldGroupDao;
        private ICustomFieldDao customFieldDao;

        private IRoleDao roleDao;
        private Role roleInDb;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ILogDao>();
            definitionDao = DaoRegistry.GetDao<ILogDefinitionDao>();
            dtoDao = DaoRegistry.GetDao<ILogDTODao>();
            workAssignmentDao = DaoRegistry.GetDao<IWorkAssignmentDao>();
            customFieldGroupDao = DaoRegistry.GetDao<ICustomFieldGroupDao>();
            customFieldDao = DaoRegistry.GetDao<ICustomFieldDao>();

            roleDao = DaoRegistry.GetDao<IRoleDao>();
            roleInDb = roleDao.QueryByActiveDirectoryKey(SiteFixture.Oilsands(), "RestrictionReportingAdmin");
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void ShouldInsertLogAndQueryById()
        {
            Log insertedLog = dao.Insert(GetLogToInsert());
            Assert.IsNotNull(insertedLog.Id);

            Log result = dao.QueryById(insertedLog.IdValue);
            Assert.IsNotNull(result.CreationUser);
            Assert.IsNotNull(result.CreatedShiftPattern);
            Assert.IsNotNull(result.WorkAssignment);
        }

        [Ignore] [Test]
        public void ShouldReturnALogWithNullRootLogIdAndNullReplyToId()
        {
            Log rootLog = dao.Insert(GetLogToInsert());
            rootLog.RootLogId = null;
            rootLog.ReplyToLogId = null;
            Assert.IsNull(rootLog.RootLogId);
            Assert.IsNull(rootLog.ReplyToLogId);
            Assert.IsTrue(rootLog.IsRoot());
        }

        [Ignore] [Test]
        public void ShouldReturnALogWithRootLogIdAndReplyToIdPopulated()
        {
            Log rootLog = dao.Insert(GetLogToInsert());
            Log replyToLog  = dao.Insert(GetLogToInsert());

            Log log = GetLogToInsert();
            log.RootLogId = rootLog.IdValue;
            log.ReplyToLogId = replyToLog.IdValue;
            log = dao.Insert(log);

            Log requeried = dao.QueryById(log.IdValue);
            Assert.IsNotNull(requeried.RootLogId);
            Assert.IsNotNull(requeried.ReplyToLogId);
            Assert.AreEqual(rootLog.IdValue, requeried.RootLogId.Value);
            Assert.AreEqual(replyToLog.IdValue, requeried.ReplyToLogId.Value);
            Assert.IsTrue(requeried.IsPartOfThread);
            Assert.IsFalse(requeried.IsRoot());
        }

        [Ignore] [Test]
        public void ShouldReturnALogWithALogDefinitionPopulated()
        {            
            LogDefinition definition = definitionDao.QueryById(2);

            Log log = GetLogToInsert();
            log.LogDefinition = definition;
            log = dao.Insert(log);

            Log requeried = dao.QueryById(log.IdValue);
            Assert.IsNotNull(requeried.LogDefinition);
            Assert.AreEqual(2, requeried.LogDefinition.IdValue);
            Assert.AreEqual(definition.PlainTextComments, requeried.LogDefinition.PlainTextComments);                        
        }

        [Ignore] [Test]
        public void ShouldInsertLog()
        {
            Log logToInsert = GetLogToInsert();

            logToInsert.RtfComments = "Rich Text Comment";            
            logToInsert.PlainTextComments = "Plain Text Comment";                      

            logToInsert.CustomFieldEntries.Clear();
            logToInsert.CustomFieldEntries.Add(new CustomFieldEntry(null, CustomFieldFixture.CustomFieldExistingInDatabase1().IdValue, "Field Name 1", "Field Entry 1", null,null, 1, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));
            logToInsert.CustomFieldEntries.Add(new CustomFieldEntry(null, CustomFieldFixture.CustomFieldExistingInDatabase2().IdValue, "Field Name 2", "Field Entry 2", null,null, 2, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));
            logToInsert.CustomFieldEntries.Add(new CustomFieldEntry(null, CustomFieldFixture.CustomFieldExistingInDatabase3().IdValue, "Field Name 3", "Field Entry 3", null,null, 3, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));

            logToInsert.CustomFields.Clear();
            logToInsert.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase1());
            logToInsert.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase2());
            logToInsert.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase3());

            logToInsert = dao.Insert(logToInsert);
            Log resultTarget = dao.QueryById(logToInsert.IdValue);

            Assert.AreEqual(logToInsert.RootLogId, resultTarget.RootLogId);
            Assert.AreEqual(logToInsert.ReplyToLogId, resultTarget.ReplyToLogId);
            Assert.AreEqual(logToInsert.EnvironmentalHealthSafetyFollowUp, resultTarget.EnvironmentalHealthSafetyFollowUp);

            Assert.AreEqual(logToInsert.FunctionalLocations.Count, resultTarget.FunctionalLocations.Count);
            foreach (FunctionalLocation floc in logToInsert.FunctionalLocations)
            {
                Assert.IsTrue(resultTarget.FunctionalLocations.ExistsById(floc));
            }

            Assert.AreEqual(logToInsert.InspectionFollowUp, resultTarget.InspectionFollowUp);
            Assert.AreEqual(logToInsert.LogDateTime, resultTarget.LogDateTime);
            Assert.AreEqual(logToInsert.OperationsFollowUp, resultTarget.OperationsFollowUp);
            Assert.AreEqual(logToInsert.ProcessControlFollowUp, resultTarget.ProcessControlFollowUp);
            Assert.AreEqual(logToInsert.SupervisionFollowUp, resultTarget.SupervisionFollowUp);
            Assert.AreEqual(logToInsert.CreationUser.Id, resultTarget.CreationUser.Id);
            Assert.AreEqual(logToInsert.CreatedShiftPattern.Id, resultTarget.CreatedShiftPattern.Id);
            Assert.AreEqual(logToInsert.CreatedByRole, resultTarget.CreatedByRole);
            Assert.AreEqual(logToInsert.LogType, resultTarget.LogType);
            Assert.AreEqual(logToInsert.RecommendForShiftSummary, resultTarget.RecommendForShiftSummary);
            Assert.AreEqual(1, resultTarget.WorkAssignment.Id);

            Assert.AreEqual(logToInsert.RtfComments, resultTarget.RtfComments);
            Assert.AreEqual(logToInsert.PlainTextComments, resultTarget.PlainTextComments);
        
            Assert.AreEqual(3, resultTarget.CustomFieldEntries.Count);
            Assert.IsTrue(resultTarget.CustomFieldEntries.Exists(
                e => e.CustomFieldName.Equals("Field Name 1") && e.FieldEntry.Equals("Field Entry 1") && e.DisplayOrder == 1));
            Assert.IsTrue(resultTarget.CustomFieldEntries.Exists(
                e => e.CustomFieldName.Equals("Field Name 2") && e.FieldEntry.Equals("Field Entry 2") && e.DisplayOrder == 2));
            Assert.IsTrue(resultTarget.CustomFieldEntries.Exists(
                e => e.CustomFieldName.Equals("Field Name 3") && e.FieldEntry.Equals("Field Entry 3") && e.DisplayOrder == 3));
        }

        [Ignore] [Test]
        public void ShouldHandle40CharacterFieldNames()
        {
            Log logToInsert = GetLogToInsert();

            logToInsert.CustomFieldEntries.Clear();
            logToInsert.CustomFieldEntries.Add(new CustomFieldEntry(null, CustomFieldFixture.CustomFieldExistingInDatabase1().IdValue, "1111111111222222222233333333334444444444", "Field Entry 1", null,null, 1, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));
            dao.Insert(logToInsert);
        }

        [Ignore] [Test]
        public void ShouldRemoveLogByPerformingASoftDeletePreventingFurtherQueriesOnTheLog()
        {
            Log logToInsert = dao.Insert(GetLogToInsert());
            Log logForDeletion = dao.QueryById(logToInsert.IdValue);
            Assert.IsNotNull(logForDeletion);
            dao.Remove(logForDeletion);
            Log removedLog = dao.QueryById(logForDeletion.IdValue);
            Assert.IsTrue(removedLog.Deleted);
        }

        [Ignore] [Test]
        public void ShouldUpdateLog()
        {
            DateTime modifiedDate = new DateTime(2005, 11, 25, 10, 0, 0);
            Log insertedLog = GetLogToInsert();
            insertedLog.OtherFollowUp = false;
            insertedLog.LastModifiedBy = UserFixture.CreateOperatorMickeyInFortMcMurrySite();
            insertedLog.LastModifiedDate = modifiedDate.SubtractDays(1);

            insertedLog.RtfComments = "RTF";
            insertedLog.PlainTextComments = "Plain Text";

            insertedLog.CustomFieldEntries.Add(new CustomFieldEntry(null, CustomFieldFixture.CustomFieldExistingInDatabase1().IdValue, "Field Name 1", "Field Entry 1", null,null, 1, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));
            insertedLog.CustomFieldEntries.Add(new CustomFieldEntry(null, CustomFieldFixture.CustomFieldExistingInDatabase2().IdValue, "Field Name 2", "Field Entry 2", null,null, 2, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));
            insertedLog.CustomFieldEntries.Add(new CustomFieldEntry(null, CustomFieldFixture.CustomFieldExistingInDatabase3().IdValue, "Field Name 3", "Field Entry 3", null,null, 3, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));

            insertedLog.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase1());
            insertedLog.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase2());
            insertedLog.CustomFields.Add(CustomFieldFixture.CustomFieldExistingInDatabase3());

            dao.Insert(insertedLog);
            Assert.IsNotNull(insertedLog.Id);

            Log expectedChangedLog = dao.QueryById(insertedLog.IdValue);
            expectedChangedLog.InspectionFollowUp = !expectedChangedLog.InspectionFollowUp;
            expectedChangedLog.OperationsFollowUp = !expectedChangedLog.OperationsFollowUp;
            expectedChangedLog.ProcessControlFollowUp = !expectedChangedLog.ProcessControlFollowUp;
            expectedChangedLog.SupervisionFollowUp = !expectedChangedLog.SupervisionFollowUp;
            expectedChangedLog.EnvironmentalHealthSafetyFollowUp = !expectedChangedLog.EnvironmentalHealthSafetyFollowUp;
            expectedChangedLog.OtherFollowUp = true;
            expectedChangedLog.LastModifiedBy = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            expectedChangedLog.LastModifiedDate = modifiedDate;
            expectedChangedLog.CreatedDateTime = modifiedDate;
            expectedChangedLog.RecommendForShiftSummary = true;

            expectedChangedLog.RtfComments = "RTF (changed)";
            expectedChangedLog.PlainTextComments = "Plain Text (changed)";

            expectedChangedLog.CustomFieldEntries.Find(e => e.CustomFieldName.Equals("Field Name 1")).FieldEntry = "New Entry 1";
            expectedChangedLog.CustomFieldEntries.Find(e => e.CustomFieldName.Equals("Field Name 3")).FieldEntry = "New Entry 3";

            dao.Update(expectedChangedLog);

            Log actualChangedLog = dao.QueryById(expectedChangedLog.IdValue);

            Assert.AreEqual(expectedChangedLog.FunctionalLocations.Count, actualChangedLog.FunctionalLocations.Count);
            foreach (FunctionalLocation floc in expectedChangedLog.FunctionalLocations)
            {
                Assert.IsTrue(actualChangedLog.FunctionalLocations.ExistsById(floc));
            }
            
            actualChangedLog.FunctionalLocations = expectedChangedLog.FunctionalLocations;
            Assert.AreEqual(expectedChangedLog.CreationUser.Id, actualChangedLog.CreationUser.Id);
            Assert.AreEqual(expectedChangedLog.LastModifiedBy.Id, actualChangedLog.LastModifiedBy.Id);
            actualChangedLog.LastModifiedBy = expectedChangedLog.LastModifiedBy;
            Assert.AreEqual(actualChangedLog, expectedChangedLog);
            Assert.AreEqual(expectedChangedLog.CreatedDateTime, actualChangedLog.CreatedDateTime);
            Assert.AreEqual(expectedChangedLog.LogType, actualChangedLog.LogType);
            Assert.AreEqual(expectedChangedLog.RecommendForShiftSummary, actualChangedLog.RecommendForShiftSummary);
            Assert.AreEqual(expectedChangedLog.RtfComments, actualChangedLog.RtfComments);           
            Assert.AreEqual(expectedChangedLog.PlainTextComments, actualChangedLog.PlainTextComments);           
            Assert.AreEqual(true, actualChangedLog.OtherFollowUp);

            Assert.IsTrue(actualChangedLog.CustomFieldEntries.Exists(
                e => e.CustomFieldName.Equals("Field Name 1") && e.FieldEntry.Equals("New Entry 1") && e.DisplayOrder == 1));
            Assert.IsTrue(actualChangedLog.CustomFieldEntries.Exists(
                e => e.CustomFieldName.Equals("Field Name 2") && e.FieldEntry.Equals("Field Entry 2") && e.DisplayOrder == 2));
            Assert.IsTrue(actualChangedLog.CustomFieldEntries.Exists(
                e => e.CustomFieldName.Equals("Field Name 3") && e.FieldEntry.Equals("New Entry 3") && e.DisplayOrder == 3));
        }

        [Ignore] [Test]
        public void ShouldInsertALogAndCreateLogAssociationForActionItem()
        {
            IActionItemDao aiDao = DaoRegistry.GetDao<IActionItemDao>();
            ActionItem ai = ActionItemFixture.CreateAPendingActionItemWithFlocListAndNoId();
            aiDao.Insert(ai);

            Log log = LogFixture.CreateLogItemCreatedByUserWithSpecificId(11, UserFixture.CreateOperator(2, "testuser"));

            int initialCountOfAssociatedLogs = dao.QueryCountOfLogsAssociatedToActionItem(ai.IdValue);
            Log insertedLog = dao.Insert(log, ai);
            Assert.IsNotNull(insertedLog.Id);
            Assert.AreEqual(initialCountOfAssociatedLogs + 1, dao.QueryCountOfLogsAssociatedToActionItem(ai.IdValue));

            dao.Remove(insertedLog);
            Assert.AreEqual(initialCountOfAssociatedLogs, dao.QueryCountOfLogsAssociatedToActionItem(ai.IdValue));
        }

        [Ignore] [Test]
        public void ShouldInsertALogAndCreateLogAssociationForActionItemDefinition()
        {
            IActionItemDefinitionDao aiDao = DaoRegistry.GetDao<IActionItemDefinitionDao>();
            ActionItemDefinition actionItemDefinition = aiDao.QueryById(1);
            Log log = LogFixture.CreateLogItemCreatedByUserWithSpecificId(11, UserFixture.CreateOperator(2, "testuser"));

            int initialCountOfAssociatedLogs = dao.QueryCountOfLogsAssociatedToActionItemDefinition(actionItemDefinition.IdValue);
            Log insertedLog = dao.Insert(log, actionItemDefinition);
            Assert.IsNotNull(insertedLog.Id);
            Assert.AreEqual(initialCountOfAssociatedLogs + 1, dao.QueryCountOfLogsAssociatedToActionItemDefinition(actionItemDefinition.IdValue));

            dao.Remove(insertedLog);
            Assert.AreEqual(initialCountOfAssociatedLogs, dao.QueryCountOfLogsAssociatedToActionItemDefinition(actionItemDefinition.IdValue));
        }

        [Ignore] [Test]
        public void ShouldInsertDocumentLinks()
        {
            Log logForInsert = InsertLogWithTwoDocumentLinks();
            Log retrievedLog = dao.QueryById(logForInsert.IdValue);
            Assert.AreEqual(logForInsert.DocumentLinks.Count, retrievedLog.DocumentLinks.Count);

            Assert.That(retrievedLog.DocumentLinks, Has.Some.EqualTo(logForInsert.DocumentLinks[0]));
            Assert.That(retrievedLog.DocumentLinks, Has.Some.EqualTo(logForInsert.DocumentLinks[0]));
        }

        [Ignore] [Test]
        public void UpdateShouldRemoveDeletedDocumentLinks()
        {
            Log log = InsertLogWithTwoDocumentLinks();
            long removedLinkId = log.DocumentLinks[0].IdValue;
            long retainedLinkId = log.DocumentLinks[1].IdValue;
            log.DocumentLinks.Remove(log.DocumentLinks[0]);
            dao.Update(log);
            Log retrievedLog = dao.QueryById(log.IdValue);
            Assert.AreEqual(log.DocumentLinks.Count, retrievedLog.DocumentLinks.Count);

            Assert.That(retrievedLog.DocumentLinks, Has.None.Property("Id").EqualTo(removedLinkId));
            Assert.That(retrievedLog.DocumentLinks, Has.Some.Property("Id").EqualTo(retainedLinkId));

        }

        [Ignore] [Test]
        public void UpdateShouldAddNewDocumentLink()
        {
            Log log = GetLogToInsert();
            log.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            dao.Insert(log);
            long existingLinkId = log.DocumentLinks[0].IdValue;
            DocumentLink newLink = DocumentLinkFixture.CreateAnotherNewDocumentLink();
            log.DocumentLinks.Add(newLink);
            dao.Update(log);
            Log retrievedLog = dao.QueryById(log.IdValue);
            Assert.AreEqual(log.DocumentLinks.Count, retrievedLog.DocumentLinks.Count);

            Assert.That(retrievedLog.DocumentLinks, Has.Some.Property("Id").EqualTo(existingLinkId));

            Assert.That(retrievedLog.DocumentLinks, Has.Some.Property("Title").EqualTo(newLink.Title));
            Assert.That(retrievedLog.DocumentLinks,
                        Has.Some.Property("TitleWithUrl").EqualTo(newLink.TitleWithUrl));
                
        }

        [Ignore] [Test]
        public void ShouldQueryForLogByDefinitionDateAndFlocs()
        {
            Log log = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp(new DateTime(2005, 11, 15, 6, 7, 8, 9));
            log.FunctionalLocations.Clear();
            log.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF());
            log.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_SR1_OFFS_TKFM());
            LogDefinition logDefinition = LogDefinitionFixture.CreateLogDefinition(1);
            log.LogDefinition = logDefinition;
            dao.Insert(log);

            {
                bool hasADefinition = dao.HasLogForDefinitionSameDayAndAtLeastOneOfTheQueriedFlocs(logDefinition, log.LogDateTime, new ExactFlocSet(log.FunctionalLocations));
                Assert.IsTrue(hasADefinition);
            }
            {
                bool hasADefinition = dao.HasLogForDefinitionSameDayAndAtLeastOneOfTheQueriedFlocs(logDefinition, log.LogDateTime, new ExactFlocSet(FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF()));
                Assert.IsTrue(hasADefinition);
            }
            {
                bool hasADefinition = dao.HasLogForDefinitionSameDayAndAtLeastOneOfTheQueriedFlocs(logDefinition, log.LogDateTime, new ExactFlocSet(FunctionalLocationFixture.GetReal_SR1_OFFS_TKFM()));
                Assert.IsTrue(hasADefinition);
            }
            {
                bool hasADefinition = dao.HasLogForDefinitionSameDayAndAtLeastOneOfTheQueriedFlocs(logDefinition, log.LogDateTime, new ExactFlocSet(new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS_TKFM(), FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF_SAB() }));
                Assert.IsTrue(hasADefinition);
            }
            {
                bool hasADefinition = dao.HasLogForDefinitionSameDayAndAtLeastOneOfTheQueriedFlocs(logDefinition, log.LogDateTime, new ExactFlocSet(new List<FunctionalLocation> { FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF_SAB() }));
                Assert.IsFalse(hasADefinition);
            }
            {
                bool hasADefinition = dao.HasLogForDefinitionSameDayAndAtLeastOneOfTheQueriedFlocs(logDefinition, new DateTime(2007, 11, 15, 6, 7, 8, 9), new ExactFlocSet(log.FunctionalLocations));
                Assert.IsFalse(hasADefinition);
            }
            {
                bool hasADefinition = dao.HasLogForDefinitionSameDayAndAtLeastOneOfTheQueriedFlocs(LogDefinitionFixture.CreateLogDefinition(99999999), log.LogDateTime, new ExactFlocSet(log.FunctionalLocations));
                Assert.IsFalse(hasADefinition);
            }

            dao.Remove(log);
            {
                bool hasADefinition = dao.HasLogForDefinitionSameDayAndAtLeastOneOfTheQueriedFlocs(logDefinition, log.LogDateTime, new ExactFlocSet(log.FunctionalLocations));
                Assert.IsFalse(hasADefinition);
            }
        }

        [Ignore] [Test]
        public void ShouldReturnNumberOfLogsAssociatedToGivenActionItem()
        {
            IActionItemDao actionItemDao = DaoRegistry.GetDao<IActionItemDao>();
            ActionItem actionItem = ActionItemFixture.Create(Priority.Elevated);
            actionItemDao.Insert(actionItem);

            Log log = GetLogToInsert();
            dao.Insert(log, actionItem);

            Assert.AreEqual(1, dao.QueryCountOfLogsAssociatedToActionItem(actionItem.IdValue));
            Assert.AreEqual(0, dao.QueryCountOfLogsAssociatedToActionItem(-1));
        }

        [Ignore] [Test]
        public void ShouldReturnLogWithCreatedByRolePopulated()
        {
            // Create Log using Role from the DB
            Log insertedLog = dao.Insert(LogFixture.CreateLogItemWithSpecificRole(roleInDb));
            Assert.IsNotNull(insertedLog.Id);

            Log result = dao.QueryById(insertedLog.IdValue);
            Assert.IsNotNull(result.CreatedByRole);
        }

        [Ignore] [Test]
        public void ShouldInsertUpdateOperatingEngineerLogDefinition_StartWithFalse()
        {
            Log log = GetLogToInsert();
            log.IsOperatingEngineerLog = false;
            dao.Insert(log);

            Log inserted = dao.QueryById(log.IdValue);
            Assert.IsFalse(inserted.IsOperatingEngineerLog);

            inserted.IsOperatingEngineerLog = true;
            dao.Update(inserted);

            Log updated = dao.QueryById(log.IdValue);
            Assert.IsTrue(updated.IsOperatingEngineerLog);
        }

        [Ignore] [Test]
        public void ShouldInsertUpdateOperatingEngineerLogDefinition_StartWithTrue()
        {
            Log log = GetLogToInsert();
            log.IsOperatingEngineerLog = true;
            dao.Insert(log);

            Log inserted = dao.QueryById(log.IdValue);
            Assert.IsTrue(inserted.IsOperatingEngineerLog);

            inserted.IsOperatingEngineerLog = false;
            dao.Update(inserted);

            Log updated = dao.QueryById(log.IdValue);
            Assert.IsFalse(updated.IsOperatingEngineerLog);
        }

        [Ignore] [Test]
        public void ShouldInsertAndRetrieveFunctionalLocationList()
        {
            DateTime loggedDateTime = new DateTime(2012, 4, 15, 15, 0, 0);
            DateRange queryDateRange = new DateRange(new Date(2012, 4, 15), new Date(2012, 4, 15));

            Log log1 = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp(ShiftPatternFixture.CreateDayShift(), loggedDateTime);
            log1.WorkAssignment = WorkAssignmentFixture.GetSarniaAssignmentThatIsReallyInTheDatabaseTestData();
            log1.FunctionalLocations = new List<FunctionalLocation>();
            log1.FunctionalLocations.Clear();
            log1.FunctionalLocations.Add(FunctionalLocationFixture.GetReal("ED1-A002-U002"));
            log1.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_ED1_A001_U007());
            log1.FunctionalLocations.Add(FunctionalLocationFixture.GetReal("ED1-A002-U061"));
            log1.FunctionalLocations.Add(FunctionalLocationFixture.GetReal_ED1_A001_U007_SCC());

            dao.Insert(log1);

            {
                List<LogDTO> results = dtoDao.QueryByFunctionalLocations(new RootFlocSet(FunctionalLocationFixture.GetReal("ED1")), queryDateRange, null);

                LogDTO logDto = results.Find(dto => dto.Id == log1.Id);
                Assert.AreEqual("ED1-A001-U007, ED1-A001-U007-SCC, ED1-A002-U002, ED1-A002-U061", logDto.FunctionalLocationNames);
            }

            {
                List<LogDTO> results = dtoDao.QueryByFunctionalLocations(new RootFlocSet(FunctionalLocationFixture.GetReal("ED1")), queryDateRange.SqlFriendlyStart, queryDateRange.SqlFriendlyEnd, log1.WorkAssignment, null);

                LogDTO logDto = results.Find(dto => dto.Id == log1.Id);
                Assert.AreEqual("ED1-A001-U007, ED1-A001-U007-SCC, ED1-A002-U002, ED1-A002-U061", logDto.FunctionalLocationNames);
            }
        }

        [Ignore] [Test]
        public void ShouldUpdateInsertAndDeleteCustomFieldEntries()
        {
            WorkAssignment wa = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA"));

            CustomFieldGroup group1 = new CustomFieldGroup("group1", new List<WorkAssignment>(), new List<CustomField>(), true, true, true,true);             //ayman custom fields DMND0010030
            group1.WorkAssignments.Add(wa);
            CustomField field1 = new CustomField(null, "field1", 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            CustomField field2 = new CustomField(null, "field2", 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            group1.Fields.Add(field1);
            group1.Fields.Add(field2);
            customFieldGroupDao.Insert(group1);

            Log log = GetLogToInsert();            
            CustomFieldEntry entry1 = new CustomFieldEntry(field1) {FieldEntry = "val"};
            log.CustomFieldEntries.Clear();
            log.CustomFieldEntries.Add(entry1);
            log.CustomFields.Clear();
            log.CustomFields.Add(field1);
            log.CustomFields.Add(field2);
            dao.Insert(log);

            Log requeriedLog = dao.QueryById(log.IdValue);
            Assert.AreEqual(1, requeriedLog.CustomFieldEntries.Count);
            Assert.IsTrue(requeriedLog.CustomFieldEntries.Exists(entry => entry.FieldEntry == "val"));

            requeriedLog.CustomFieldEntries.Clear();
            dao.Update(requeriedLog);

            Log reRequeriedLog = dao.QueryById(log.IdValue);
            Assert.AreEqual(0, reRequeriedLog.CustomFieldEntries.Count);
        }

        [Ignore] [Test]
        public void ShouldInsertLogWithCustomFieldGroupsBasedOnCustomFieldsOnLog()
        {
            WorkAssignment wa = workAssignmentDao.Insert(WorkAssignmentFixture.CreateSarniaWorkAssignmentToBeInsertedInDatabase("WA"));

            CustomFieldGroup group1 = new CustomFieldGroup("group1", new List<WorkAssignment>(), new List<CustomField>(), true, true, true,true);           //ayman custom fields DMND0010030
            group1.WorkAssignments.Add(wa);
            CustomField field1 = new CustomField(null, "field1", 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            group1.Fields.Add(field1);
            customFieldGroupDao.Insert(group1);

            CustomFieldGroup group2 = new CustomFieldGroup("group2", new List<WorkAssignment>(), new List<CustomField>(), true, true, true,true);            //ayman custom fields DMND0010030
            group2.WorkAssignments.Add(wa);
            CustomField field2 = new CustomField(null, "field2", 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, null);
            group2.Fields.Add(field2);
            customFieldGroupDao.Insert(group2);

            // case 1: do a regular log insert. The log should be associated with both groups because the log has both custom fields on it
            {
                Log log = GetLogToInsert();
                log.WorkAssignment = wa;
                log.CustomFieldEntries.Clear();
                CustomFieldEntry entry1 = new CustomFieldEntry(field1) {FieldEntry = "val1"};
                CustomFieldEntry entry2 = new CustomFieldEntry(field2) {FieldEntry = "val2"};
                log.CustomFieldEntries.Add(entry1);
                log.CustomFieldEntries.Add(entry2);
                log.CustomFields.Clear();
                log.CustomFields.Add(field1);
                log.CustomFields.Add(field2);
                dao.Insert(log);

                List<CustomField> customFields = customFieldDao.QueryByCustomFieldGroupsForLogs(log.IdValue);
                Assert.AreEqual(2, customFields.Count);
                Assert.IsTrue(customFields.Exists(field => field.Name == "field1"));
                Assert.IsTrue(customFields.Exists(field => field.Name == "field2"));
            }

            // case 2: insert the log explicitly for group1 only by only associating the log with field1
            {
                Log log = GetLogToInsert();
                log.WorkAssignment = wa;
                log.CustomFieldEntries.Clear();
                CustomFieldEntry entry1 = new CustomFieldEntry(field1) {FieldEntry = "val1"};
                CustomFieldEntry entry2 = new CustomFieldEntry(field2) {FieldEntry = "val2"};
                log.CustomFieldEntries.Add(entry1);
                log.CustomFieldEntries.Add(entry2);
                log.CustomFields.Clear();
                log.CustomFields.Add(field1);
                dao.Insert(log);

                List<CustomField> customFields = customFieldDao.QueryByCustomFieldGroupsForLogs(log.IdValue);
                Assert.AreEqual(1, customFields.Count);
                Assert.IsTrue(customFields.Exists(field => field.Name == "field1"));
            }
        }

        [Ignore] [Test]
        public void QueryLogsInBatchesShouldQueryLogsInBatches()
        {
            Log log1 = GetSarniaDirectiveToInsert();
            Log log2 = GetSarniaDirectiveToInsert();
            Log log3 = GetSarniaDirectiveToInsert();
            Log log4 = GetSarniaDirectiveToInsert();
            Log log5 = GetSarniaDirectiveToInsert();

            dao.Insert(log1);
            dao.Insert(log2);
            dao.Insert(log3);
            dao.Insert(log4);
            dao.Insert(log5);

            LogType logType = log1.LogType;
            long siteId = log1.FunctionalLocations[0].Site.IdValue;

            List<Log> batch1 = dao.QueryLogsInBatches(siteId, 0, 2, logType);
            List<Log> batch2 = dao.QueryLogsInBatches(siteId, 1, 2, logType);
            List<Log> batch3 = dao.QueryLogsInBatches(siteId, 2, 2, logType);
            List<Log> batch4 = dao.QueryLogsInBatches(siteId, 3, 2, logType);

            Assert.AreEqual(2, batch1.Count);
            Assert.IsTrue(batch1.Exists(log => log.IdValue == log1.IdValue));
            Assert.IsTrue(batch1.Exists(log => log.IdValue == log2.IdValue));

            Assert.AreEqual(2, batch2.Count);
            Assert.IsTrue(batch2.Exists(log => log.IdValue == log3.IdValue));
            Assert.IsTrue(batch2.Exists(log => log.IdValue == log4.IdValue));

            Assert.AreEqual(1, batch3.Count);
            Assert.IsTrue(batch3.Exists(log => log.IdValue == log5.IdValue));

            Assert.AreEqual(0, batch4.Count);
        }

        [Ignore] [Test]
        public void CountLogsShouldCountLogs()
        {
            int initialCount = dao.QueryCountOfLogs(Site.SARNIA_ID, LogType.DailyDirective);

            Log log = GetSarniaDirectiveToInsert();
            dao.Insert(log);

            Assert.AreEqual(initialCount + 1, dao.QueryCountOfLogs(Site.SARNIA_ID, LogType.DailyDirective));
        }

        private Log InsertLogWithTwoDocumentLinks()
        {
            Log log = LogFixture.CreateLogItemOltUser1FortMcMurrayRequiresInspectionFollowUp();
            log.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            log.DocumentLinks.Add(DocumentLinkFixture.CreateAnotherNewDocumentLink());
            dao.Insert(log);
            return log;
        }

        private Log GetLogToInsert()
        {
            Log logToInsert = LogFixture.CreateLogItemWithSpecificRole(roleInDb);
            logToInsert.LastModifiedDate = DateTimeFixture.DateTimeNow;
            logToInsert.LastModifiedBy = UserFixture.CreateOperatorMickeyInFortMcMurrySite(); //randomly choosing ID
            logToInsert.RecommendForShiftSummary = true;
            logToInsert.WorkAssignment = new WorkAssignment(1, null, null, null, 0, null, true, true, null, null, null,true,true);
            return logToInsert;
        }

        private Log GetSarniaDirectiveToInsert()
        {
            FunctionalLocation floc = FunctionalLocationFixture.GetReal_SR1_PLT3_HYDU();
            User user = UserFixture.CreateOperatorGoofyInFortMcMurrySite();
            ShiftPattern shift = ShiftPatternFixture.CreateDayShift();
            DateTime now = shift.StartTime.Add(4).ToDateTime(new Date(2010, 03, 20));

            Log log = LogFixture.CreateLog(now, new List<FunctionalLocation> { floc },
                                 WorkAssignmentFixture.CreateConsoleOperator(), shift, user, LogType.DailyDirective,
                                 RoleFixture.GetRealRoleA(Site.OILSAND_ID));

            log.RtfComments = "Comments";
            log.PlainTextComments = "Comments";
            return log;
        }
    }
}
