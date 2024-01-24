using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.PlantHistorian;
using Com.Suncor.Olt.Remote.Bootstrap;
using NMock2;
using NMock2.Matchers;
using NUnit.Framework;
using Has = NUnit.Framework.Has;
using Is = NUnit.Framework.Is;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class TargetDefinitionDaoTest : AbstractDaoTest
    {
        private Mockery mocks;
        
        private ITargetDefinitionDao dao;
        private ITargetDefinitionReadWriteTagConfigurationDao configDao;
        private IPlantHistorianGateway mockPlantHistorianGateway;
        private ITagDao tagDao;
        private IActionItemDefinitionDao actionItemDefinitionDao;

        private TargetDefinition targetDefinition;
        private const decimal updatedTagValue = 42m;

        private readonly List<long> allSiteIds = new List<long>{ Site.SARNIA_ID, Site.DENVER_ID, Site.OILSAND_ID, Site.FIREBAG_ID, Site.SITE_WIDE_SERVICES_ID, Site.EDMONTON_ID, Site.MONTREAL_ID };

        protected override void TestInitialize()
        {
            mocks = new Mockery();
            mockPlantHistorianGateway = mocks.NewMock<IPlantHistorianGateway>();
            
            // Create a new TargetDefinitionDao to allow mocking of the Plant Historian Gateway & Time Service Dao.
            dao = Bootstrapper.CreateManagedDao<ITargetDefinitionDao>(Bootstrapper.ConnectionString, new TargetDefinitionDao(mockPlantHistorianGateway));
            
            configDao = DaoRegistry.GetDao<ITargetDefinitionReadWriteTagConfigurationDao>();
            targetDefinition = TargetDefinitionFixture.CreateTargetDefinition();
            targetDefinition.Assignment = null;
            tagDao = DaoRegistry.GetDao<ITagDao>();
            actionItemDefinitionDao = DaoRegistry.GetDao<IActionItemDefinitionDao>();
        }

        protected override void Cleanup()
        {
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void QueryByIdShouldReturnDefaultWhenReadWriteTagConfigurationDoesnotExistsForTargetDefinitionId()
        {
            const int targetDefinitionIdWithNoReadWriteTag = 1;
            targetDefinition = dao.QueryById(targetDefinitionIdWithNoReadWriteTag);
            Assert.That(targetDefinition.ReadWriteTagsConfiguration.GapUnitValue.Direction, Is.EqualTo(TagDirection.None));
            Assert.That(targetDefinition.ReadWriteTagsConfiguration.MaxValue.Direction, Is.EqualTo(TagDirection.None));
            Assert.That(targetDefinition.ReadWriteTagsConfiguration.MinValue.Direction, Is.EqualTo(TagDirection.None));
            Assert.That(targetDefinition.ReadWriteTagsConfiguration.TargetValue.Direction, Is.EqualTo(TagDirection.None));
        }

        [Ignore] [Test]
        public void ShouldInsertTargetDefinitionReadWriteTagConfigurationWhenInsertTargetDefinition()
        {
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinitionWithoutId();
            definition.Assignment = null;
            definition.ReadWriteTagsConfiguration.MaxValue.Direction = TagDirection.Read;
            definition.ReadWriteTagsConfiguration.MaxValue.Tag = TagInfoFixture.CreateTagInfoWithId2FromDB();
            Assert.IsFalse(definition.ReadWriteTagsConfiguration.IsInDatabase());

            Stub.On(mockPlantHistorianGateway).Method("ReadTagValues").WithAnyArguments().Will(Return.Value(new decimal?[]{17m}));
            
            TargetDefinition inserted = dao.Insert(definition);
            Assert.IsTrue(inserted.ReadWriteTagsConfiguration.IsInDatabase());

            TargetDefinitionReadWriteTagConfiguration insertedConfig =
                    configDao.QueryByTargetDefinitionId(inserted.IdValue);
            
            Assert.AreEqual(definition.ReadWriteTagsConfiguration, insertedConfig);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldNotWriteToPlantHistorianGatewayIfTagConfigurationsAreSetToRead()
        {
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinitionWithoutId();
            definition.Approve(definition.LastModifiedBy, definition.LastModifiedDate);
            definition.Assignment = null;

            TargetDefinitionFixture.SetReadWriteTagConfigurationsToWrite(definition, updatedTagValue);
            dao.Insert(definition);
            
            definition.ReadWriteTagsConfiguration.MaxValue.Direction = TagDirection.Read;
            definition.ReadWriteTagsConfiguration.MaxValue.Tag = TagInfoFixture.CreateMockTagForDenver(13, "32TI350.PV");
            TagInfo minTag = definition.ReadWriteTagsConfiguration.MinValue.Tag;
            Expect.Once.On(mockPlantHistorianGateway).Method("WriteTagValue").With(minTag, updatedTagValue);
            TagInfo gapTag = definition.ReadWriteTagsConfiguration.GapUnitValue.Tag;
            Expect.Once.On(mockPlantHistorianGateway).Method("WriteTagValue").With(gapTag,  updatedTagValue);
            TagInfo targetTag = definition.ReadWriteTagsConfiguration.TargetValue.Tag;
            Expect.Once.On(mockPlantHistorianGateway).Method("WriteTagValue").With(targetTag,  updatedTagValue);
            dao.WriteTagValues(definition);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldNotWriteToPlantHistorianGatewayIfTagConfigurationsAreSetToNone()
        {
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinitionWithoutId();
            definition.Approve(definition.LastModifiedBy, definition.LastModifiedDate);
            definition.Assignment = null;

            TargetDefinitionFixture.SetReadWriteTagConfigurationsToWrite(definition, updatedTagValue);
            dao.Insert(definition);
            
            definition.ReadWriteTagsConfiguration.MaxValue.Direction = TagDirection.None;
            TagInfo minTag = definition.ReadWriteTagsConfiguration.MinValue.Tag;
            Expect.Once.On(mockPlantHistorianGateway).Method("WriteTagValue").With(minTag, updatedTagValue);
            TagInfo gapTag = definition.ReadWriteTagsConfiguration.GapUnitValue.Tag;
            Expect.Once.On(mockPlantHistorianGateway).Method("WriteTagValue").With(gapTag,  updatedTagValue);
            TagInfo targetTag = definition.ReadWriteTagsConfiguration.TargetValue.Tag;
            Expect.Once.On(mockPlantHistorianGateway).Method("WriteTagValue").With(targetTag,  updatedTagValue);
            dao.WriteTagValues(definition);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Ignore] [Test]
        public void InsertShouldIncludePreApprovedTargetRanges()
        {
            targetDefinition.PreApprovedMinValue = 1.33m;
            targetDefinition.PreApprovedMaxValue = 133.0m;
            targetDefinition.PreApprovedNeverToExceedMinimum = 1.22m;
            targetDefinition.PreApprovedNeverToExceedMaximum = 122.0m;
            TargetDefinition insertedTargetDef = dao.Insert(targetDefinition);
            TargetDefinition retrievedTargetDef = dao.QueryById(insertedTargetDef.IdValue);
            Assert.AreEqual(1.33m, retrievedTargetDef.PreApprovedMinValue);
            Assert.AreEqual(133.0m, retrievedTargetDef.PreApprovedMaxValue);
            Assert.AreEqual(1.22m, retrievedTargetDef.PreApprovedNeverToExceedMinimum);
            Assert.AreEqual(122.0m, retrievedTargetDef.PreApprovedNeverToExceedMaximum);
        }

        [Ignore] [Test]
        public void UpdateShouldIncludePreApprovedTargetRanges()
        {
            targetDefinition = dao.QueryById(1);
            targetDefinition.PreApprovedMinValue = 1.33m;
            targetDefinition.PreApprovedMaxValue = 133.0m;
            targetDefinition.PreApprovedNeverToExceedMinimum = 1.22m;
            targetDefinition.PreApprovedNeverToExceedMaximum = 122.0m;
            dao.Update(targetDefinition);
            TargetDefinition retrievedTargetDef = dao.QueryById(1);
            Assert.AreEqual(1.33m, retrievedTargetDef.PreApprovedMinValue);
            Assert.AreEqual(133.0m, retrievedTargetDef.PreApprovedMaxValue);
            Assert.AreEqual(1.22m, retrievedTargetDef.PreApprovedNeverToExceedMinimum);
            Assert.AreEqual(122.0m, retrievedTargetDef.PreApprovedNeverToExceedMaximum);
        }

        [Ignore] [Test]
        public void ShouldQueryForOperationalMode()
        {
            targetDefinition = dao.QueryById(1);
            Assert.IsTrue(targetDefinition.HasOperationalMode(OperationalMode.ShutDown));
        }

        [Ignore] [Test]
        public void ShouldUpdateOperationalMode()
        {
            targetDefinition = dao.QueryById(2);
            Assert.IsTrue(targetDefinition.HasOperationalMode(OperationalMode.Normal));
            targetDefinition.OperationalMode = OperationalMode.ShutDown;
            dao.Update(targetDefinition);
            TargetDefinition tdAfterUpdate = dao.QueryById(2);
            Assert.IsTrue(tdAfterUpdate.HasOperationalMode(OperationalMode.ShutDown));
        }

        [Ignore] [Test]
        public void ShouldInsertOperationalMode()
        {
            targetDefinition = TargetDefinitionFixture.CreateTargetDefinition();
            targetDefinition.Assignment = null;
            targetDefinition.OperationalMode = OperationalMode.ShutDown;
            dao.Insert(targetDefinition);
            TargetDefinition afterInserted = dao.QueryById(targetDefinition.IdValue);
            Assert.IsTrue(targetDefinition.HasOperationalMode(afterInserted.OperationalMode));
            Assert.IsTrue(targetDefinition.Id.Equals(afterInserted.Id));
        }

        [Ignore] [Test]
        public void AddNewShouldReturnTheTargetWithNewId()
        {
            TargetDefinition targetToInsert =
                    TargetDefinitionFixture.CreateATargetWithRecurringDailyScheduleAndPendingTargetFixture();
            targetToInsert.Assignment = null;
            targetToInsert = dao.Insert(targetToInsert);
            Assert.IsNotNull(targetToInsert.Id);
            TargetDefinition resultTarget = dao.QueryById(targetToInsert.IdValue);
            Assert.IsNotNull(resultTarget);
        }

        [Ignore] [Test]
        public void AddNewWithMaxValuesOnlyShouldReturnTheTargetWithNewIdAndMinValueNull()
        {
            TargetDefinition targetToInsert =
                    TargetDefinitionFixture.CreateATargetWithMaxValueOnlyRecurringDailyScheduleAndActiveTargetFixture();
            targetToInsert.Assignment = null;
            targetToInsert = dao.Insert(targetToInsert);

            Assert.IsNotNull(targetToInsert.Id);
            TargetDefinition resultTarget = dao.QueryById(targetToInsert.IdValue);
            Assert.IsNotNull(resultTarget);
            Assert.IsNull(resultTarget.MinValue);
        }

        [Ignore] [Test]
        public void GetTargetByIdShouldReturnOneRecordIfIdEqualsOne()
        {
            const long id = 1;
            TargetDefinition results = dao.QueryById(id);
            Assert.AreEqual(id, results.Id);
        }

        [Ignore] [Test]
        public void GetTargetDefinitionByIdShouldReturnAssociatedComments()
        {
            const long targetDefinitionWithCommentsId = TargetDefinitionFixture.TARGET_DEFINITION_WITH_2_COMMENTS_ID;
            TargetDefinition retrievedTargetDefinition = dao.QueryById(targetDefinitionWithCommentsId);
            Assert.AreEqual(targetDefinitionWithCommentsId, retrievedTargetDefinition.Id);
            List<Comment> expectedComments =
                    CommentFixture.GetCommentsForTargetDefinitionInDb(targetDefinitionWithCommentsId);
            Assert.AreEqual(expectedComments.Count, retrievedTargetDefinition.Comments.Count);
        }

        [Ignore] [Test]
        public void InsertedAndRetreivedTargetShouldBeEqual()
        {
            TargetDefinition originalTarget 
                    =TargetDefinitionFixture.CreateATargetWithRecurringDailyScheduleAndPendingTargetFixtureWithTestDescription();
            originalTarget.Assignment = null;
            originalTarget.RequiresResponseWhenAlerted = true;
            originalTarget.IsActive = false;
            originalTarget.Comments.Add(CommentFixture.CreateComment());
            dao.Insert(originalTarget);
            Assert.IsNotNull(originalTarget.Id);
            //doing it this way since fixture tag, mode objects are not the same as database versions.
            TargetDefinition retreivedTarget = dao.QueryById(originalTarget.IdValue);
            Assert.AreEqual(originalTarget.TagInfo.Id, retreivedTarget.TagInfo.Id);
            Assert.AreEqual(originalTarget.Status.Id, retreivedTarget.Status.Id);
            Assert.AreEqual(originalTarget.FunctionalLocation.Id, retreivedTarget.FunctionalLocation.Id);
            Assert.AreEqual(originalTarget.MaxValue, retreivedTarget.MaxValue);
            Assert.AreEqual(originalTarget.MinValue, retreivedTarget.MinValue);
            Assert.AreEqual(originalTarget.NeverToExceedMaximum, retreivedTarget.NeverToExceedMaximum);
            Assert.AreEqual(originalTarget.NeverToExceedMinimum, retreivedTarget.NeverToExceedMinimum);
            Assert.AreEqual(originalTarget.MaxValueFrequency, retreivedTarget.MaxValueFrequency);
            Assert.AreEqual(originalTarget.MinValueFrequency, retreivedTarget.MinValueFrequency);
            Assert.AreEqual(originalTarget.NeverToExceedMaxFrequency, retreivedTarget.NeverToExceedMaxFrequency);
            Assert.AreEqual(originalTarget.NeverToExceedMinFrequency, retreivedTarget.NeverToExceedMinFrequency);
            Assert.AreEqual(originalTarget.TargetValue, retreivedTarget.TargetValue);
            Assert.AreEqual(originalTarget.GapUnitValue, retreivedTarget.GapUnitValue);
            Assert.AreEqual(originalTarget.Schedule.Id, retreivedTarget.Schedule.Id);
            Assert.AreEqual(originalTarget.Description, retreivedTarget.Description);
            Assert.AreEqual(originalTarget.IsActive, retreivedTarget.IsActive);
            Assert.AreEqual(originalTarget.RequiresResponseWhenAlerted, retreivedTarget.RequiresResponseWhenAlerted);
            Assert.AreEqual(originalTarget.Comments.Count, retreivedTarget.Comments.Count);
        }

        [Ignore] [Test]
        public void RemoveTargetShouldPerformASoftDeletePreventingFurtherQueriesOnTheTarget()
        {
            TargetDefinition target =
                    TargetDefinitionFixture.CreateATargetWithRecurringDailyScheduleAndPendingTargetFixture();
            target.Assignment = null;
            target.Name = DateTimeFixture.DateTimeNow + "DL";
            dao.Insert(target);
            dao.Remove(target);
            TargetDefinition removedTarget = dao.QueryById(target.IdValue);
            Assert.IsTrue(removedTarget.Deleted);
        }

        [Ignore] [Test]
        public void RemovingTargetShouldAlsoRemoveTargetAssociationLinks()
        {
            TargetDefinition childTarget = TargetDefinitionFixture.CreateTargetDefinitionWithoutId();
            childTarget.Assignment = null;
            dao.Insert(childTarget);
            TargetDefinitionDTO childTargetDTO = new TargetDefinitionDTO(childTarget);
            TargetDefinition parentTarget = TargetDefinitionFixture.CreateTargetDefinitionWithoutId();
            parentTarget.Assignment = null;
            parentTarget.AssociatedTargetDTOs.Add(childTargetDTO);
            dao.Insert(parentTarget);
            List<string> parentTargetNames = dao.QueryParentTargets(childTarget.IdValue);
            Assert.AreEqual(1, parentTargetNames.Count);
            dao.Remove(parentTarget);
            parentTargetNames = dao.QueryParentTargets(childTarget.IdValue);
            Assert.AreEqual(0, parentTargetNames.Count);
        }

        [Ignore] [Test]
        public void UpdateTargetMaxValueShouldUpdateTheTargetMaxValue()
        {
            TargetDefinition target = dao.QueryById(1);
            const decimal expectedMaxValue = 999.99m;
            target.MaxValue = expectedMaxValue;
            dao.Update(target);
            TargetDefinition actualTarget = dao.QueryById(1);
            Assert.AreEqual(expectedMaxValue, actualTarget.MaxValue);
        }

        [Ignore] [Test]
        public void UpdateTargetByAlertRequiredAndIdShouldSetExceedingControlBoundaryToTrueIfTargetIdIsOne()
        {
            TargetDefinition originalTarget = dao.QueryById(1);
            originalTarget.IsAlertRequired = true;
            dao.Update(originalTarget);
            TargetDefinition expectedTarget = dao.QueryById(1);
            Assert.IsTrue(expectedTarget.IsAlertRequired);
        }

        [Ignore] [Test]
        public void QueryTargetByScheduleId()
        {
            TargetDefinition definition = dao.QueryByScheduleId(4);
            Assert.AreEqual((long) 6, definition.Id);
        }

        [Ignore] [Test]
        public void QueryTargetShouldReturnInsertedTargetTargetValue()
        {
            QueryTargetShouldReturnInsertedTargetWithCorrespondingTargetValue(TargetValue.CreateMinimizeTarget());
            QueryTargetShouldReturnInsertedTargetWithCorrespondingTargetValue(TargetValue.CreateMaximizeTarget());
            QueryTargetShouldReturnInsertedTargetWithCorrespondingTargetValue(TargetValue.CreateEmptyTarget());
        }

        [Ignore] [Test]
        public void QueryTargetShouldReturnUpdatedTargetWithNewTargetValue()
        {
            QueryTargetShouldReturnUpdatedTargetWithCorrespondingTargetValue(TargetValue.CreateSpecifiedTarget(3.0m),
                                                                             TargetValue.CreateMinimizeTarget());
            QueryTargetShouldReturnUpdatedTargetWithCorrespondingTargetValue(TargetValue.CreateSpecifiedTarget(3.0m),
                                                                             TargetValue.CreateMaximizeTarget());
            QueryTargetShouldReturnUpdatedTargetWithCorrespondingTargetValue(TargetValue.CreateSpecifiedTarget(3.0m),
                                                                             TargetValue.CreateEmptyTarget());
            QueryTargetShouldReturnUpdatedTargetWithCorrespondingTargetValue(TargetValue.CreateMinimizeTarget(),
                                                                             TargetValue.CreateSpecifiedTarget(16.0m));
        }

        [Ignore] [Test]
        public void UpdateTargetShouldUpdateTargetScheduleStartDateAndDescription()
        {
            TargetDefinition originalTarget = dao.QueryById(1);
            originalTarget.Schedule =
                    RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000();
            originalTarget.Schedule.Id = 1;
            dao.Update(originalTarget);
            TargetDefinition actualTarget = dao.QueryById(1);
            Assert.AreEqual(originalTarget.Schedule.Id, actualTarget.Schedule.Id);
        }

        [Ignore] [Test]
        public void UpdateShouldSetNewReadWriteConfiguration()
        {
            TargetDefinition originalTarget = dao.QueryById(1);
            originalTarget.ReadWriteTagsConfiguration.GapUnitValue.Direction = TagDirection.Write;
            dao.Update(originalTarget);

            TargetDefinition updatedTarget = dao.QueryById(1);
            Assert.That(updatedTarget.ReadWriteTagsConfiguration.GapUnitValue.Direction, Is.EqualTo(TagDirection.Write));

        }

        [Ignore] [Test]
        public void InsertTargetAssociatedWithAnotherTarget()
        {
            TargetDefinition childTarget =
                    TargetDefinitionFixture.CreateATargetWithRecurringDailyScheduleAndActiveTargetFixture();
            childTarget.Assignment = null;
            dao.Insert(childTarget);
            Assert.IsNotNull(childTarget.Id);
            TargetDefinition parentTarget =
                    TargetDefinitionFixture.
                            CreateATargetWithRecurringHourlyScheduleOfEverySixHoursAndAssociationToAnotherTarget(
                            childTarget.IdValue);
            parentTarget.Name = DateTimeFixture.DateTimeNow + "PAR";
            parentTarget.Assignment = null;
            dao.Insert(parentTarget);
            Assert.IsNotNull(parentTarget.Id);
            TargetDefinition actualTarget = dao.QueryById(parentTarget.IdValue);
            Assert.AreEqual(childTarget.Id, actualTarget.AssociatedTargetDTOs[0].Id);
        }

        [Ignore] [Test]
        public void QueryTargetsWithActiveStatusByName()
        {
            Site site = SiteFixture.Sarnia();
            const string name = "TestDa";
            List<TargetDefinition> results = dao.QueryActiveByName(site.IdValue, name);
            Assert.IsTrue(results.Count > 0);
            foreach(TargetDefinition targetDef in results)
            {
                Assert.IsTrue(targetDef.IsActive);
                Assert.AreEqual(site.Id, targetDef.FunctionalLocation.Site.Id);
            }
        }

        [Ignore] [Test]
        public void QueryTargetByNameShouldReturnAllValidRecords()
        {
            Site site = SiteFixture.Sarnia();
            const string name = "TestData Target Duplicate";
            List<TargetDefinition> results = dao.QueryByName(site.IdValue, name);
            Assert.AreEqual(2, results.Count);
        }


        [Ignore] [Test]
        public void UpdateTargetShouldUpdateTargetAssociations()
        {
            TargetDefinition originalTarget = dao.QueryById(1);
            long[] associatedIds = {2};
            List<TargetDefinitionDTO> associatedTargetDTOs =
                    TargetDefinitionDTOFixture.CreateTargetDefinitionDTOList(associatedIds);
            originalTarget.AssociatedTargetDTOs = associatedTargetDTOs;
            dao.Update(originalTarget);
            TargetDefinition actualTarget = dao.QueryById(1);
            Assert.AreEqual(originalTarget.AssociatedTargetDTOs[0].Id, actualTarget.AssociatedTargetDTOs[0].Id);
        }

        [Ignore] [Test]
        public void UpdateTargetDefinitionShouldInsertNewComments()
        {
            TargetDefinition definition =
                    dao.QueryById(TargetDefinitionFixture.TARGET_DEFINITION_FOR_ADDING_COMMENTS_ID);
            int oldCommentCount = definition.Comments.Count;
            Comment newComment = CommentFixture.CreateComment();
            Assert.IsNull(newComment.Id);
            definition.Comments.Add(newComment);
            dao.Update(definition);
            Assert.IsNotNull(newComment.Id);
            definition = dao.QueryById(TargetDefinitionFixture.TARGET_DEFINITION_FOR_ADDING_COMMENTS_ID);
            Assert.AreEqual(oldCommentCount + 1, definition.Comments.Count);
        }

        [Ignore] [Test]
        public void OnInsertAndUpdateDaoSavesName()
        {
            TargetDefinition targetToInsert =
                    TargetDefinitionFixture.CreateATargetWithRecurringDailyScheduleAndPendingTargetFixture();
            targetToInsert.Assignment = null;
            string expected = DateTimeFixture.DateTimeNow + "INS";
            targetToInsert.Name = expected;
            dao.Insert(targetToInsert);
            string actual = dao.QueryById(targetToInsert.IdValue).Name;
            Assert.AreEqual(expected, actual);
            expected = targetToInsert.Name + "2";
            targetToInsert.Name = expected;
            dao.Update(targetToInsert);
            actual = dao.QueryById(targetToInsert.IdValue).Name;
            Assert.AreEqual(expected, actual);
        }

        [Ignore] [Test]
        public void GetCountShouldReturnNumberOfTargetDefinitionsWithTheSameNameForTheSpecifiedSite()
        {
            TargetDefinition sarniaDefinition = TargetDefinitionFixture.CreateTargetDefinitionWithoutId();
            sarniaDefinition.FunctionalLocation = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            string targetName = sarniaDefinition.Name;
            sarniaDefinition.Assignment = null;
            dao.Insert(sarniaDefinition);
            Assert.AreEqual(1, dao.GetCount(targetName, sarniaDefinition.FunctionalLocation.Site.IdValue));

            sarniaDefinition.Id = null;
            dao.Insert(sarniaDefinition);
            Assert.AreEqual(2, dao.GetCount(targetName, sarniaDefinition.FunctionalLocation.Site.IdValue));

            TargetDefinition denverDefinition = TargetDefinitionFixture.CreateTargetDefinitionWithoutId();
            denverDefinition.Assignment = null;
            denverDefinition.FunctionalLocation = FunctionalLocationFixture.GetReal_DN1_3003_0000();
            denverDefinition.Name = targetName;
            dao.Insert(denverDefinition);
            Assert.AreEqual(1, dao.GetCount(targetName, denverDefinition.FunctionalLocation.Site.IdValue));
            Assert.AreEqual(2, dao.GetCount(targetName, sarniaDefinition.FunctionalLocation.Site.IdValue));            
        }

        [Ignore] [Test]
        public void GetCountByNameForSiteShouldBeCaseInsensitive()
        {
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinitionWithoutId();
            definition.Assignment = null;
            definition.Name = "Target Definition Name";
            dao.Insert(definition);
            Assert.AreEqual(1, dao.GetCount("TARGET DEFINITION NAME", definition.FunctionalLocation.Site.IdValue));
            Assert.AreEqual(1, dao.GetCount("target definition name", definition.FunctionalLocation.Site.IdValue));
        }

        [Ignore] [Test]
        public void QueryParentTargetsShouldReturnAtLeastOneValue()
        {
            List<string> parents = dao.QueryParentTargets(2);
            Assert.IsTrue(parents.Count > 0);
            // check that one of the parents has an id of 1.
            bool result = false;
            foreach(string parentName in parents)
            {
                if("Parent with association".Equals(parentName))
                {
                    result = true;
                    break;
                }
            }
            Assert.IsTrue(result);
        }

        [Ignore] [Test]
        public void ShouldReturnLinkedActionItemDefinitionCount()
        {
            TargetDefinition newTargetDefinition = TargetDefinitionFixture.CreateTargetDefinition();
            newTargetDefinition.Assignment = null;
            newTargetDefinition = dao.Insert(newTargetDefinition);
            long targetId = newTargetDefinition.IdValue;

            InsertActionItemWithTargetDefinition(targetId, false);
            InsertActionItemWithTargetDefinition(targetId, false);
            InsertActionItemWithTargetDefinition(targetId, true);

            int actual = dao.QueryLinkedActionItemDefinitionCount(targetId);
            Assert.AreEqual(2, actual);
        }

        private void InsertActionItemWithTargetDefinition(long targetId, bool removed)
        {
            ActionItemDefinition definition = ActionItemDefinitionFixture.CreateWithLinkedTargetDefinition();
            definition.TargetDefinitionDTOs[0].Id = targetId;
            actionItemDefinitionDao.Insert(definition);
            if (removed)
            {
                actionItemDefinitionDao.Remove(definition);
            }
        }

        [Ignore] [Test]
        public void OnInsertLastModifiedUserIsSetCorrectly()
        {
            TargetDefinition targetDef =
                    TargetDefinitionFixture.CreateATargetWithRecurringDailyScheduleAndPendingTargetFixture();
            targetDef.Assignment = null;
            long targetDefId = dao.Insert(targetDef).IdValue;
            TargetDefinition targetDefQueryResult = dao.QueryById(targetDefId);
            Assert.AreEqual(targetDef.LastModifiedBy.Id, targetDefQueryResult.LastModifiedBy.Id);
        }

        [Ignore] [Test]
        public void OnUpdateLastModifiedUserIsSetCorrectly()
        {
            TargetDefinition targetDef =
                    TargetDefinitionFixture.CreateATargetWithRecurringDailyScheduleAndPendingTargetFixture();
            targetDef.Assignment = null;
            long targetDefId = dao.Insert(targetDef).IdValue;
            TargetDefinition targetDefQueryResult = dao.QueryById(targetDefId);
            User expectedUpdateUser = UserFixture.CreateSupervisor(5, "who cares as long is a test user");
            targetDefQueryResult.LastModifiedBy = expectedUpdateUser;
            dao.Update(targetDefQueryResult);
            targetDefQueryResult = dao.QueryById(targetDefId);
            Assert.AreEqual(expectedUpdateUser.Id, targetDefQueryResult.LastModifiedBy.Id);
        }

        [Ignore] [Test]
        public void ShouldLoadMinTargetValueFromDbIfConfigurationIsSetToNone()
        {
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinitionWithoutId();
            definition.Assignment = null;

            const decimal minValue = 1000m;
            definition.MinValue = minValue;
            definition.ReadWriteTagsConfiguration.MinValue.Direction = TagDirection.None;
            definition.ReadWriteTagsConfiguration.MinValue.Tag = TagInfoFixture.CreateTagInfoWithId2FromDB();
            TargetDefinition inserted = dao.Insert(definition);
            Assert.AreEqual(minValue, inserted.MinValue);
            TargetDefinition expectedTargetDefinition = dao.QueryById(inserted.IdValue);
            Assert.AreEqual(minValue, expectedTargetDefinition.MinValue);
        }

        [Ignore] [Test]
        public void ShouldLoadMinTargetValueFromPlantHistorianAndOverrideValueFromDatabaseIfConfigurationIsSetToRead()
        {
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinitionWithoutId();
            definition.Assignment = null;

            definition.MinValue = updatedTagValue + 1000;
            definition.ReadWriteTagsConfiguration.MinValue.Direction = TagDirection.Read;
            definition.ReadWriteTagsConfiguration.MinValue.Tag = TagInfoFixture.CreateTagInfoWithId2FromDB();
            Expect.AtLeastOnce
                .On(mockPlantHistorianGateway)
                .Method("ReadTagValues")
                .With(
                        new AlwaysMatcher(true, "Hello"),
                        new EqualMatcher(definition.ReadWriteTagsConfiguration.MinValue.Tag),
                        new AlwaysTrueMatcher())
                .Will(Return.Value(new decimal?[] { updatedTagValue }));

            TargetDefinition inserted = dao.Insert(definition);
            Assert.AreEqual(updatedTagValue, inserted.MinValue);

            TargetDefinition expectedTargetDefinition = dao.QueryById(inserted.IdValue);
            Assert.AreEqual(updatedTagValue, expectedTargetDefinition.MinValue);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldLoadMaxTargetValueFromDbIfConfigurationIsSetToNone()
        {
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinitionWithoutId();
            definition.Assignment = null;

            const decimal maxValue = 1000;
            definition.MaxValue = maxValue;
            definition.ReadWriteTagsConfiguration.MaxValue.Direction = TagDirection.None;
            definition.ReadWriteTagsConfiguration.MaxValue.Tag = TagInfoFixture.CreateTagInfoWithId2FromDB();
            TargetDefinition inserted = dao.Insert(definition);
            Assert.AreEqual(maxValue, inserted.MaxValue);
            TargetDefinition expectedTargetDefinition = dao.QueryById(inserted.IdValue);
            Assert.AreEqual(maxValue, expectedTargetDefinition.MaxValue);
        }

        [Ignore] [Test]
        public void ShouldLoadMaxTargetValueFromDbIfConfigurationIsSetToNoneOnUpdate()
        {
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinitionWithoutId();
            definition.Assignment = null;

            const decimal maxValue = 1000;
            definition.ReadWriteTagsConfiguration.MaxValue.Direction = TagDirection.Read;
            definition.ReadWriteTagsConfiguration.MaxValue.Tag = TagInfoFixture.CreateTagInfoWithId2FromDB();
            Expect.Once.On(mockPlantHistorianGateway)
                    .Method("ReadTagValues")
                    .With(
                          new AlwaysMatcher(true, "Hello"),
                          new EqualMatcher(definition.ReadWriteTagsConfiguration.MaxValue.Tag),
                          new AlwaysTrueMatcher())
                    .Will(Return.Value(new decimal?[] {updatedTagValue}));

            TargetDefinition inserted = dao.Insert(definition);
            Assert.AreEqual(updatedTagValue, inserted.MaxValue);
            inserted.MaxValue = maxValue;
            inserted.ReadWriteTagsConfiguration.MaxValue.Direction = TagDirection.None;
            dao.Update(definition);
            Assert.AreEqual(maxValue, inserted.MaxValue);
            TargetDefinition expectedTargetDefinition = dao.QueryById(inserted.IdValue);
            Assert.AreEqual(maxValue, expectedTargetDefinition.MaxValue);
        }

        [Ignore] [Test]
        public void ShouldLoadMaxTargetValueFromPlantHistorianAndOverideValuesInDatabaseIfConfigurationIsSetToReadOnUpdate()
        {
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinitionWithoutId();
            definition.Assignment = null;

            const decimal maxValue = 99m;
            definition.MaxValue = maxValue;
            TargetDefinition inserted = dao.Insert(definition);
            Assert.AreEqual(maxValue, inserted.MaxValue);
            inserted.ReadWriteTagsConfiguration.MaxValue.Direction = TagDirection.Read;
            inserted.ReadWriteTagsConfiguration.MaxValue.Tag = TagInfoFixture.CreateTagInfoWithId2FromDB();

            Expect.AtLeastOnce.On(mockPlantHistorianGateway)
                    .Method("ReadTagValues")
                    .With(
                            new AlwaysMatcher(true, "Hello"),
                            new EqualMatcher(definition.ReadWriteTagsConfiguration.MaxValue.Tag),
                            new AlwaysTrueMatcher())
                    .Will(Return.Value(new decimal?[] { updatedTagValue }));

            dao.Update(definition);
            Assert.AreEqual(updatedTagValue, inserted.MaxValue);
            TargetDefinition expectedTargetDefinition = dao.QueryById(inserted.IdValue);
            Assert.AreEqual(updatedTagValue, expectedTargetDefinition.MaxValue);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldLoadMaxTargetValueFromPlantHistorianAndOverrideDatabaseValuesIfConfigurationIsSetToRead()
        {
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinitionWithoutId();
            definition.Assignment = null;

            definition.MaxValue = updatedTagValue + 1000;
            definition.ReadWriteTagsConfiguration.MaxValue.Direction = TagDirection.Read;
            definition.ReadWriteTagsConfiguration.MaxValue.Tag = TagInfoFixture.CreateTagInfoWithId2FromDB();

            Expect.AtLeastOnce.On(mockPlantHistorianGateway)
                .Method("ReadTagValues")
                .With(
                    new AlwaysMatcher(true, "hello"),
                    new EqualMatcher(definition.ReadWriteTagsConfiguration.MaxValue.Tag),
                    new AlwaysTrueMatcher())
                .Will(Return.Value(new decimal?[] { updatedTagValue }));

            TargetDefinition inserted = dao.Insert(definition);
            Assert.AreEqual(updatedTagValue, inserted.MaxValue);
            TargetDefinition expectedTargetDefinition = dao.QueryById(inserted.IdValue);
            Assert.AreEqual(updatedTagValue, expectedTargetDefinition.MaxValue);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldLoadGapTargetValueFromDbIfConfigurationIsSetToNone()
        {
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinitionWithoutId();
            definition.Assignment = null;

            const decimal gapValue = 1000;
            definition.GapUnitValue = gapValue;
            definition.ReadWriteTagsConfiguration.GapUnitValue.Direction = TagDirection.None;
            definition.ReadWriteTagsConfiguration.GapUnitValue.Tag = TagInfoFixture.CreateTagInfoWithId2FromDB();
            TargetDefinition inserted = dao.Insert(definition);
            Assert.AreEqual(gapValue, inserted.GapUnitValue);
            TargetDefinition expectedTargetDefinition = dao.QueryById(inserted.IdValue);
            Assert.AreEqual(gapValue, expectedTargetDefinition.GapUnitValue);
        }

        [Ignore] [Test]
        public void ShouldLoadGapTargetValueFromPlantHistorianAndOverrideDatabaseValuesIfConfigurationIsSetToRead()
        {
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinitionWithoutId();
            definition.Assignment = null;

            definition.GapUnitValue = updatedTagValue + 1000;
            definition.ReadWriteTagsConfiguration.GapUnitValue.Direction = TagDirection.Read;
            definition.ReadWriteTagsConfiguration.GapUnitValue.Tag = TagInfoFixture.CreateTagInfoWithId2FromDB();

            Expect.AtLeastOnce.On(mockPlantHistorianGateway)
                .Method("ReadTagValues")
                .With(
                    new AlwaysMatcher(true, "hello"),
                    new EqualMatcher(definition.ReadWriteTagsConfiguration.GapUnitValue.Tag),
                    new AlwaysTrueMatcher())
                .Will(Return.Value(new decimal?[] { updatedTagValue }));

            TargetDefinition inserted = dao.Insert(definition);
            Assert.AreEqual(updatedTagValue, inserted.GapUnitValue);
          
            TargetDefinition expectedTargetDefinition = dao.QueryById(inserted.IdValue);
            Assert.AreEqual(updatedTagValue, expectedTargetDefinition.GapUnitValue);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldLoadTargetValueAsMaximizedTargetFromDbIfConfigurationIsSetToNone()
        {
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinitionWithoutId();
            TargetValue targetValue = TargetValue.CreateMaximizeTarget();
            definition.Assignment = null;

            definition.TargetValue = targetValue;
            definition.ReadWriteTagsConfiguration.TargetValue.Direction = TagDirection.None;
            definition.ReadWriteTagsConfiguration.TargetValue.Tag = TagInfoFixture.CreateTagInfoWithId2FromDB();
            TargetDefinition inserted = dao.Insert(definition);
            Assert.AreEqual(targetValue, inserted.TargetValue);
            TargetDefinition expectedTargetDefinition = dao.QueryById(inserted.IdValue);
            Assert.AreEqual(targetValue, expectedTargetDefinition.TargetValue);
        }

        [Ignore] [Test]
        public void ShouldLoadTargetValueAsSpecifiedTargetFromDbIfConfigurationIsSetToNone()
        {
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinitionWithoutId();
            TargetValue targetValue = TargetValue.CreateSpecifiedTarget(1234);
            definition.Assignment = null;

            definition.TargetValue = targetValue;
            definition.ReadWriteTagsConfiguration.TargetValue.Direction = TagDirection.None;
            definition.ReadWriteTagsConfiguration.TargetValue.Tag = TagInfoFixture.CreateTagInfoWithId2FromDB();
            TargetDefinition inserted = dao.Insert(definition);
            Assert.AreEqual(targetValue, inserted.TargetValue);
            TargetDefinition expectedTargetDefinition = dao.QueryById(inserted.IdValue);
            Assert.AreEqual(targetValue, expectedTargetDefinition.TargetValue);
        }

        [Ignore] [Test]
        public void ShouldLoadTargetValueFromPlantHistorianAsSpecifiedIfConfigurationIsSetToRead()
        {
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinitionWithoutId();
            definition.Assignment = null;

            TargetValue expectedTargetValue = TargetValue.CreateSpecifiedTarget(updatedTagValue);
            definition.TargetValue = TargetValue.CreateMaximizeTarget();
            definition.ReadWriteTagsConfiguration.TargetValue.Direction = TagDirection.Read;
            definition.ReadWriteTagsConfiguration.TargetValue.Tag = TagInfoFixture.CreateTagInfoWithId2FromDB();

            Expect.AtLeastOnce.On(mockPlantHistorianGateway)
                .Method("ReadTagValues")
                .With(
                    new AlwaysMatcher(true, "hello"),
                    new EqualMatcher(definition.ReadWriteTagsConfiguration.TargetValue.Tag),
                    new AlwaysTrueMatcher())
                .Will(Return.Value(new decimal?[] { updatedTagValue }));

            TargetDefinition inserted = dao.Insert(definition);
            Assert.AreEqual(expectedTargetValue, inserted.TargetValue);

            TargetDefinition expectedTargetDefinition = dao.QueryById(inserted.IdValue);
            Assert.AreEqual(expectedTargetValue, expectedTargetDefinition.TargetValue);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
        
        [Ignore] [Test]
        public void ShouldInsertTagConfigurationValuesOnlyToDbIfTagConfigurationsAreSetToRead()
        {
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetWithoutIdAndConfigurationSetToRead();
            definition.Assignment = null;
            definition.ReadWriteTagsConfiguration.MaxValue.Tag = tagDao.QueryById(90916);
            definition.ReadWriteTagsConfiguration.MinValue.Tag = tagDao.QueryById(90919);
            definition.ReadWriteTagsConfiguration.TargetValue.Tag = tagDao.QueryById(90920);
            definition.ReadWriteTagsConfiguration.GapUnitValue.Tag = tagDao.QueryById(90989);

            const decimal maxValue = 2m;
            const decimal minValue = 1m;
            const decimal gapUnitValue = 3m;
            const decimal targetValue = 4m;
            AssertGetTagValueFromPlantHistorian(definition, gapUnitValue, maxValue, minValue, targetValue);
            TargetDefinition inserted = dao.Insert(definition);
            TargetDefinition found = dao.QueryById(inserted.IdValue);
            Assert.AreEqual(inserted.ReadWriteTagsConfiguration.MaxValue.Direction,
                            found.ReadWriteTagsConfiguration.MaxValue.Direction);
            Assert.AreEqual(maxValue, found.MaxValue);
            Assert.AreEqual(inserted.ReadWriteTagsConfiguration.MinValue.Direction,
                            found.ReadWriteTagsConfiguration.MinValue.Direction);
            Assert.AreEqual(minValue, found.MinValue);
            Assert.AreEqual(inserted.ReadWriteTagsConfiguration.GapUnitValue.Direction,
                            found.ReadWriteTagsConfiguration.GapUnitValue.Direction);
            Assert.AreEqual(gapUnitValue, found.GapUnitValue);
            Assert.AreEqual(inserted.ReadWriteTagsConfiguration.TargetValue.Direction,found.ReadWriteTagsConfiguration.TargetValue.Direction);
            found.TargetValue.Do(new AssertTargetValueAction(targetValue));
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private void AssertGetTagValueFromPlantHistorian(TargetDefinition definition, decimal gapUnitValue, decimal maxValue, decimal minValue, decimal targetValue)
        {
            Expect.AtLeastOnce.On(mockPlantHistorianGateway)
                .Method("ReadTagValues")
                .With(new AlwaysMatcher(true, "1"),
                    new EqualMatcher(definition.ReadWriteTagsConfiguration.MaxValue.Tag),
                    new AlwaysTrueMatcher())
                .Will(Return.Value(new decimal?[] { maxValue }));

            Expect.AtLeastOnce.On(mockPlantHistorianGateway)
                .Method("ReadTagValues")
                .With(
                    new AlwaysMatcher(true, "2"), 
                    new EqualMatcher(definition.ReadWriteTagsConfiguration.MinValue.Tag),
                    new AlwaysTrueMatcher())
                .Will(Return.Value(new decimal?[] { minValue }));

            Expect.AtLeastOnce.On(mockPlantHistorianGateway)
                .Method("ReadTagValues")
                .With(
                    new AlwaysMatcher(true, "3"),
                    new EqualMatcher(definition.ReadWriteTagsConfiguration.GapUnitValue.Tag),
                    new AlwaysTrueMatcher())
                .Will(Return.Value(new decimal?[] { gapUnitValue }));

            Expect.AtLeastOnce.On(mockPlantHistorianGateway)
                .Method("ReadTagValues")
                .With(
                    new AlwaysMatcher(true, "4"),
                    new EqualMatcher(definition.ReadWriteTagsConfiguration.TargetValue.Tag),
                    new AlwaysTrueMatcher())
                .Will(Return.Value(new decimal?[] { targetValue }));

        }

        [Ignore] [Test]
        public void
        ShouldNotUpdateTagIfConfigurationIsSetToWriteAndTargetDefinitionDoesRequireApprovalAndStatusIsNotApproved()
        {
            TargetDefinition target = TargetDefinitionFixture.CreateTargetDefinitionWithoutId();
            target.Assignment = null;
            target.WaitForApproval();
            dao.Insert(target);
            TargetDefinitionFixture.SetReadWriteTagConfigurationsToWrite(target, updatedTagValue);
            dao.Update(target);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldUpdateTagIfConfigurationIsSetToWriteAndTargetDefinitionDoesRequireApprovalAndStatusIsApproved()
        {
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinitionWithoutId();
            definition.Assignment = null;

            definition.Approve(definition.LastModifiedBy, definition.LastModifiedDate);
            dao.Insert(definition);
            TargetDefinitionFixture.SetReadWriteTagConfigurationsToWrite(definition, updatedTagValue);
            dao.Update(definition);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldInsertTagConfigurationValuesToDbOnlyIfTagConfigurationsAreSetToWriteAndTargetDefinitionNeedsApprovalButStatusIsNotApproved()
        {
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetWithoutIdAndConfigurationSetToWrite(updatedTagValue);
            definition.Assignment = null;
            definition.WaitForApproval();
            TargetDefinition inserted = dao.Insert(definition);
            TargetDefinition found = dao.QueryById(inserted.IdValue);
            Assert.AreEqual(inserted.ReadWriteTagsConfiguration.MaxValue.Direction,
                            found.ReadWriteTagsConfiguration.MaxValue.Direction);
            Assert.AreEqual(updatedTagValue, found.MinValue);
            Assert.AreEqual(inserted.ReadWriteTagsConfiguration.MinValue.Direction,
                            found.ReadWriteTagsConfiguration.MinValue.Direction);
            Assert.AreEqual(updatedTagValue, found.MaxValue);
            Assert.AreEqual(inserted.ReadWriteTagsConfiguration.TargetValue.Direction,
                            found.ReadWriteTagsConfiguration.TargetValue.Direction);
            Assert.AreEqual(TargetValue.CreateSpecifiedTarget(updatedTagValue), found.TargetValue);
            Assert.AreEqual(inserted.ReadWriteTagsConfiguration.GapUnitValue.Direction,
                            found.ReadWriteTagsConfiguration.GapUnitValue.Direction);
            Assert.AreEqual(updatedTagValue, found.GapUnitValue);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void InsertShouldInsertDocumentLinks()
        {
            TargetDefinition definitionForInsert = CreateTargetDefinitionWithTwoDocumentLinks();
            dao.Insert(definitionForInsert);
            TargetDefinition retrievedDefinition = dao.QueryById(definitionForInsert.IdValue);
            Assert.AreEqual(definitionForInsert.DocumentLinks.Count, retrievedDefinition.DocumentLinks.Count);

            Assert.That(retrievedDefinition.DocumentLinks,
                        Has.Some.EqualTo(definitionForInsert.DocumentLinks[0]));
            Assert.That(retrievedDefinition.DocumentLinks,
                        Has.Some.EqualTo(definitionForInsert.DocumentLinks[1]));

        }

        [Ignore] [Test]
        public void UpdateShouldRemoveDeletedDocumentLinks()
        {
            TargetDefinition definition = CreateTargetDefinitionWithTwoDocumentLinks();
            dao.Insert(definition);
            long retainedLinkId = definition.DocumentLinks[0].IdValue;
            long removedLinkId = definition.DocumentLinks[1].IdValue;
            definition.DocumentLinks.Remove(definition.DocumentLinks[1]);
            dao.Update(definition);
            TargetDefinition retrievedDefinition = dao.QueryById(definition.IdValue);
            Assert.AreEqual(definition.DocumentLinks.Count, retrievedDefinition.DocumentLinks.Count);

            Assert.That(retrievedDefinition.DocumentLinks, Has.None.Property("Id").EqualTo(removedLinkId));
            Assert.That(retrievedDefinition.DocumentLinks, Has.Some.Property("Id").EqualTo(retainedLinkId));

        }

        private static TargetDefinition CreateTargetDefinitionWithTwoDocumentLinks()
        {
            TargetDefinition definitionForInsert =
                    TargetDefinitionFixture.CreateTargetWithoutIdAndConfigurationSetToWrite(updatedTagValue);
            definitionForInsert.Assignment = null;
            definitionForInsert.WaitForApproval();
            definitionForInsert.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            definitionForInsert.DocumentLinks.Add(DocumentLinkFixture.CreateAnotherNewDocumentLink());
            return definitionForInsert;
        }

        [Ignore] [Test]
        public void UpdateShouldInsertNewDocumentLinks()
        {
            TargetDefinition definition = CreateTargetDefinitionWithTwoDocumentLinks();
            definition.Assignment = null;
            definition.DocumentLinks.Add(DocumentLinkFixture.CreateNewDocumentLink());
            dao.Insert(definition);
            long existingLinkId = definition.DocumentLinks[0].IdValue;
            DocumentLink newLink = DocumentLinkFixture.CreateAnotherNewDocumentLink();
            definition.DocumentLinks.Add(newLink);
            dao.Update(definition);
            TargetDefinition retrievedDefinition = dao.QueryById(definition.IdValue);
            Assert.AreEqual(definition.DocumentLinks.Count, retrievedDefinition.DocumentLinks.Count);

            Assert.That(retrievedDefinition.DocumentLinks, Has.Some.Property("Id").EqualTo( existingLinkId));

            Assert.That(retrievedDefinition.DocumentLinks, Has.Some.Property("Title").EqualTo(newLink.Title));
            Assert.That(retrievedDefinition.DocumentLinks,
                        Has.Some.Property("TitleWithUrl").EqualTo(newLink.TitleWithUrl));
        }

        [Ignore] [Test]
        public void ShouldQueryTargetDefinitionWithTagsAlreadyWrittenTo()
        {           
            long? newTargetDefinitionId = null;
            TagDirection direction = TagDirection.Write;
            const long tagId = 12;
            
            List<TargetDefinition> result = dao.QueryTargetDefinitionAlreadyUsingTag(newTargetDefinitionId, direction, tagId);
            Assert.That(result, Has.Some.Property("Id").EqualTo(-3));
        }

        [Ignore] [Test]
        public void QueryTargetDefinitionAlreadyUsingTagShouldNotReturnDeletedTargets()
        {                                                
            const int realSarniaTagId = 8;
            TagInfo tagInfo = tagDao.QueryById(realSarniaTagId);
            TagDirection direction = TagDirection.Read;
            long tagId = tagInfo.IdValue;            
            List<TargetDefinition> initialResult =
                dao.QueryTargetDefinitionAlreadyUsingTag(null, direction, tagId);
            
            TargetDefinition deletedTargetDefinition = TargetDefinitionFixture.CreateTargetWithoutIdAndConfigurationSetToNone();
            deletedTargetDefinition.Assignment = null;
            deletedTargetDefinition.ReadWriteTagsConfiguration.MaxValue = new ReadWriteTagConfiguration(direction, tagInfo);
            OltStub.On(mockPlantHistorianGateway);
            
            deletedTargetDefinition = dao.Insert(deletedTargetDefinition);
            dao.Remove(deletedTargetDefinition);

            List<TargetDefinition> result =
                dao.QueryTargetDefinitionAlreadyUsingTag(null, direction, tagId);                        
            
            Assert.AreEqual(initialResult, result);
        }
        
        [Ignore] [Test]
        public void ShouldNotAttemptToWriteIfConfigurationIsSetToWriteAndMaxValueIsNull()
        {            
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetWithoutIdAndConfigurationSetToWrite(updatedTagValue);           
            definition.MaxValue = null;
            definition.Assignment = null;

            TargetDefinitionReadWriteTagConfiguration targetDefinitionReadWriteTagConfiguration = definition.ReadWriteTagsConfiguration;

            Expect.Once.On(mockPlantHistorianGateway).Method("WriteTagValue").With(targetDefinitionReadWriteTagConfiguration.GapUnitValue.Tag, updatedTagValue);
            Expect.Once.On(mockPlantHistorianGateway).Method("WriteTagValue").With(targetDefinitionReadWriteTagConfiguration.MinValue.Tag, updatedTagValue);
            Expect.Once.On(mockPlantHistorianGateway).Method("WriteTagValue").With(targetDefinitionReadWriteTagConfiguration.TargetValue.Tag, updatedTagValue);
            
            Expect.Never.On(mockPlantHistorianGateway)
                  .Method("WriteTagValue")
                  .With(new EqualMatcher(targetDefinitionReadWriteTagConfiguration.MaxValue.Tag), new AlwaysTrueMatcher());

            dao.Insert(definition);
            dao.WriteTagValues(definition);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldNotAttemptToWriteIfConfigurationIsSetToWriteAndMinValueIsNull()
        {
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetWithoutIdAndConfigurationSetToWrite(updatedTagValue);
            definition.MinValue = null;
            definition.Assignment = null;

            TargetDefinitionReadWriteTagConfiguration targetDefinitionReadWriteTagConfiguration = definition.ReadWriteTagsConfiguration;

            Expect.Once.On(mockPlantHistorianGateway).Method("WriteTagValue").With(targetDefinitionReadWriteTagConfiguration.GapUnitValue.Tag, updatedTagValue);
            Expect.Once.On(mockPlantHistorianGateway).Method("WriteTagValue").With(targetDefinitionReadWriteTagConfiguration.TargetValue.Tag, updatedTagValue);
            Expect.Once.On(mockPlantHistorianGateway).Method("WriteTagValue").With(targetDefinitionReadWriteTagConfiguration.MaxValue.Tag, updatedTagValue);

            Expect.Never.On(mockPlantHistorianGateway).Method("WriteTagValue").With(new EqualMatcher(targetDefinitionReadWriteTagConfiguration.MinValue.Tag), new AlwaysTrueMatcher());

            dao.Insert(definition);
            dao.WriteTagValues(definition);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldNotAttemptToWriteIfConfigurationIsSetToWriteAndGapUnitValueIsNull()
        {
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetWithoutIdAndConfigurationSetToWrite(updatedTagValue);
            definition.GapUnitValue = null;
            definition.Assignment = null;

            TargetDefinitionReadWriteTagConfiguration targetDefinitionReadWriteTagConfiguration = definition.ReadWriteTagsConfiguration;

            Expect.Once.On(mockPlantHistorianGateway).Method("WriteTagValue").With(targetDefinitionReadWriteTagConfiguration.MaxValue.Tag, updatedTagValue);
            Expect.Once.On(mockPlantHistorianGateway).Method("WriteTagValue").With(targetDefinitionReadWriteTagConfiguration.MinValue.Tag, updatedTagValue);
            Expect.Once.On(mockPlantHistorianGateway).Method("WriteTagValue").With(targetDefinitionReadWriteTagConfiguration.TargetValue.Tag, updatedTagValue);

            Expect.Never.On(mockPlantHistorianGateway)
                  .Method("WriteTagValue")
                  .With(new EqualMatcher(targetDefinitionReadWriteTagConfiguration.GapUnitValue.Tag), new AlwaysTrueMatcher());

            

            dao.Insert(definition);
            dao.WriteTagValues(definition);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldNotAttemptToWriteIfConfigurationIsSetToWriteAndTargetValueIsEmpty()
        {
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetWithoutIdAndConfigurationSetToWrite(updatedTagValue);
            definition.TargetValue = TargetValue.CreateEmptyTarget();
            definition.Assignment = null;

            TargetDefinitionReadWriteTagConfiguration targetDefinitionReadWriteTagConfiguration = definition.ReadWriteTagsConfiguration;

            Expect.Once.On(mockPlantHistorianGateway).Method("WriteTagValue").With(targetDefinitionReadWriteTagConfiguration.MaxValue.Tag, updatedTagValue);
            Expect.Once.On(mockPlantHistorianGateway).Method("WriteTagValue").With(targetDefinitionReadWriteTagConfiguration.MinValue.Tag, updatedTagValue);
            Expect.Once.On(mockPlantHistorianGateway).Method("WriteTagValue").With(targetDefinitionReadWriteTagConfiguration.GapUnitValue.Tag,  updatedTagValue);

            Expect.Never.On(mockPlantHistorianGateway)
                  .Method("WriteTagValue")
                  .With(new EqualMatcher(targetDefinitionReadWriteTagConfiguration.TargetValue.Tag), new AlwaysTrueMatcher());

            dao.Insert(definition);
            dao.WriteTagValues(definition);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void ShouldQueryTargetDefinitionsWithInvalidTag()
        {                        
            TargetDefinition targetMarkedInvalid = TargetDefinitionFixture.CreateTargetDefinition();
            targetMarkedInvalid.Assignment = null;

            targetMarkedInvalid.Status = TargetDefinitionStatus.InvalidTag;
            dao.Insert(targetMarkedInvalid);

            TargetDefinition targetMarkedValid = TargetDefinitionFixture.CreateTargetDefinition();
            targetMarkedValid.Assignment = null;
            targetMarkedValid.Status = TargetDefinitionStatus.Pending;
            dao.Insert(targetMarkedValid);
            
            List<TargetDefinition> targetDefinitions = dao.QueryTargetDefinitionsWithInvalidTag(targetMarkedInvalid.TagInfo);

            Assert.That(targetDefinitions, Has.None.Property("Id").EqualTo( targetMarkedValid.IdValue));
            Assert.That(targetDefinitions, Has.Some.Property("Id").EqualTo( targetMarkedInvalid.IdValue));

        }

        [Ignore] [Test]
        public void ShouldQueryTargetDefinitionsWithValidTag()
        {
            TargetDefinition targetMarkedInvalid = TargetDefinitionFixture.CreateTargetDefinition();
            targetMarkedInvalid.Assignment = null;
            targetMarkedInvalid.Status = TargetDefinitionStatus.InvalidTag;
            dao.Insert(targetMarkedInvalid);

            TargetDefinition targetMarkedValid = TargetDefinitionFixture.CreateTargetDefinition();
            targetMarkedValid.Assignment = null;
            targetMarkedValid.Status = TargetDefinitionStatus.Pending;
            dao.Insert(targetMarkedValid);

            List<TargetDefinition> targetDefinitions = dao.QueryTargetDefinitionsWithValidTag(targetMarkedInvalid.TagInfo);

            Assert.That(targetDefinitions, Has.None.Property("Id").EqualTo( targetMarkedInvalid.IdValue));
            Assert.That(targetDefinitions, Has.Some.Property("Id").EqualTo( targetMarkedValid.IdValue));
        }

        [Ignore] [Test]
        public void ShouldUpdateStatus()
        {
            User user = UserFixture.CreateSupervisorUserCalledOltUser1ThatMapsToFirstUserInDB();
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinition();
            definition.Assignment = null;

            Assert.AreEqual(TargetDefinitionStatus.Pending, definition.Status);
            definition = dao.Insert(definition);

            DateTime now = DateTimeFixture.DateTimeNow;
            definition.HasInvalidTag(definition.LastModifiedBy, now);
            dao.UpdateStatus(definition);

            definition = dao.QueryById(definition.IdValue);            
            Assert.AreEqual(TargetDefinitionStatus.InvalidTag, definition.Status);
            Assert.IsFalse(definition.IsActive);
            Assert.AreEqual(user.Id, definition.LastModifiedBy.Id);
            Assert.That(now, Is.EqualTo(definition.LastModifiedDate).Within(TimeSpan.FromSeconds(10)));
        }

        [Ignore] [Test]
        public void ShouldNotReturnExceptionListBecauseTagsAreNotRead()
        {
            TagInfo tagToInsert = new TagInfo(1, "NotARealTag", "A Tag that does not exist", "Celcius", false,1);
            tagDao.Insert(tagToInsert);
            
            TargetDefinition definition = TargetDefinitionFixture.CreateATargetWithRecurringWeeklySchedule();
            definition.Assignment = null;

            definition.Approve(UserFixture.CreateSAPUser(), DateTimeFixture.DateTimeNow);

            // set one of the tags to read from PlantHistorian.
            definition.ReadWriteTagsConfiguration.GapUnitValue.Direction = TagDirection.Read;
            definition.ReadWriteTagsConfiguration.GapUnitValue.Tag = tagToInsert;

            // On Insert, just let everything go fine.
            Expect.Once.On(mockPlantHistorianGateway).Method("ReadTagValues").With(new AlwaysMatcher(true, "Hello"),
                                                                                   new EqualMatcher(tagToInsert),
                                                                                   new AlwaysTrueMatcher())
                .Will(Return.Value(new decimal?[] {17.00m}));

            Stub.On(mockPlantHistorianGateway).Method("ReadTagValues").WithAnyArguments().Will(Return.Value(new decimal?[] { 17m }));

            dao.Insert(definition);

            SchedulingList<TargetDefinition, OLTException> scheduling = dao.QueryAllAvailableForScheduling(allSiteIds);

            CollectionAssert.IsEmpty(scheduling.ExceptionList);

            mocks.VerifyAllExpectationsHaveBeenMet();            
        }

        [Ignore] [Test]
        public void ShouldQueryAllAvailableForScheduling()
        {            
            long idOfEx1Definition;
            long idOfDN1Definition;

            FunctionalLocation EX1_FACL_TOOL = FunctionalLocationFixture.GetReal_EX1_OPLT_TOOL();
            FunctionalLocation DN1_3003_0000 = FunctionalLocationFixture.GetReal_DN1_3003_0000();

            {
                TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinition(false, EX1_FACL_TOOL.Site);
                definition.Assignment = null;

                definition.Schedule.EndDate = new Date(DateTime.Now.AddDays(1));
                definition.IsActive = true;
                definition.FunctionalLocation = EX1_FACL_TOOL;

                idOfEx1Definition = dao.Insert(definition).IdValue;                
            }

            {
                TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinition(false, DN1_3003_0000.Site);
                definition.Assignment = null;

                definition.Schedule.EndDate = new Date(DateTime.Now.AddDays(1));

                definition.IsActive = true;
                definition.FunctionalLocation = DN1_3003_0000;
                idOfDN1Definition = dao.Insert(definition).IdValue;                
            }

            SchedulingList<TargetDefinition, OLTException> availableForSchedulingWithEx1 = 
                dao.QueryAllAvailableForScheduling(new List<long>{EX1_FACL_TOOL.Site.IdValue});
            Assert.IsTrue(availableForSchedulingWithEx1.DomainObjectList.Exists(td => td.IdValue == idOfEx1Definition));
            Assert.IsFalse(availableForSchedulingWithEx1.DomainObjectList.Exists(td => td.IdValue == idOfDN1Definition));

            SchedulingList<TargetDefinition, OLTException> availableForSchedulingWithDn1 = 
                dao.QueryAllAvailableForScheduling(new List<long>{DN1_3003_0000.Site.IdValue});
            Assert.IsFalse(availableForSchedulingWithDn1.DomainObjectList.Exists(td => td.IdValue == idOfEx1Definition));
            Assert.IsTrue(availableForSchedulingWithDn1.DomainObjectList.Exists(td => td.IdValue == idOfDN1Definition));

            SchedulingList<TargetDefinition, OLTException> availableForSchedulingForAllSites =
                dao.QueryAllAvailableForScheduling(allSiteIds);
            Assert.IsTrue(availableForSchedulingForAllSites.DomainObjectList.Exists(td => td.IdValue == idOfEx1Definition));
            Assert.IsTrue(availableForSchedulingForAllSites.DomainObjectList.Exists(td => td.IdValue == idOfDN1Definition));
        }

        [Ignore] [Test]
        public void ShouldUpdateAfterUnableToAccessTags()
        {
            TargetDefinition definition = TargetDefinitionFixture.CreateTargetDefinition();
            definition.Assignment = null;

            definition.IsActive = true;
            dao.Insert(definition);

            definition = dao.QueryById(definition.IdValue);

            Assert.IsTrue(definition.IsActive);
            Assert.AreNotEqual(7, definition.LastModifiedBy);
            Assert.IsEmpty(definition.Comments);

            User lastModifiedUser = UserFixture.CreateUserWithGivenId(7);
            DateTime lastModifiedDate = new DateTime(2005, 6, 7);

            definition.IsActive = false;
            definition.LastModifiedBy = lastModifiedUser;
            definition.LastModifiedDate = lastModifiedDate;

            definition.Comments.Add(new Comment(lastModifiedUser, lastModifiedDate, "This is a new comment"));

            dao.UpdateAfterUnableToAccessTags(definition);

            definition = dao.QueryById(definition.IdValue);

            Assert.IsFalse(definition.IsActive);
            Assert.AreEqual(7, definition.LastModifiedBy.Id);         
            Assert.AreEqual(lastModifiedDate, definition.LastModifiedDate);
            Assert.IsNotEmpty(definition.Comments);
        }

        private void QueryTargetShouldReturnInsertedTargetWithCorrespondingTargetValue(TargetValue targetValue)
        {
            targetDefinition.TargetValue = targetValue;
            targetDefinition = dao.Insert(targetDefinition);
            TargetDefinition retrievedTargetDefinition = dao.QueryById(targetDefinition.IdValue);
            Assert.AreEqual(targetValue, retrievedTargetDefinition.TargetValue);
        }

        private void QueryTargetShouldReturnUpdatedTargetWithCorrespondingTargetValue(TargetValue oldTargetValue,
                                                                                      TargetValue newTargetValue)
        {
            targetDefinition.TargetValue = oldTargetValue;
            targetDefinition = dao.Insert(targetDefinition);
            targetDefinition.TargetValue = newTargetValue;
            dao.Update(targetDefinition);
            TargetDefinition retrievedTargetDefinition = dao.QueryById(targetDefinition.IdValue);
            Assert.AreEqual(newTargetValue, retrievedTargetDefinition.TargetValue);
        }

        private class AssertTargetValueAction : ITargetAction
        {
            private readonly decimal expectedValue;

            public AssertTargetValueAction(decimal value)
            {
                expectedValue = value;
            }

            public void DoForMinimize()
            {
                // Do Nothing
            }

            public void DoForMaximize()
            {
                // Do Nothing
            }

            public void DoForEmpty()
            {
                // Do Nothing
            }

            public void DoWithSpecifiedValue(decimal specifiedValue)
            {
                Assert.AreEqual(expectedValue, specifiedValue);
            }
        }
    }
}