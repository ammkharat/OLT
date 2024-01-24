using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;
using TargetDefinitionField = Com.Suncor.Olt.Common.Fixtures.TargetDefinitionAutoReApprovalConfigurationFixture.TargetDefinitionField;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [TestFixture]
    public class TargetDefinitionAutoReApprovalConfigurationTest
    {
        private Site currentSite;
        private TargetDefinition originalTargetDef;

        [SetUp]
        public void SetUp()
        {
            currentSite = SiteFixture.Sarnia();
            originalTargetDef = TargetDefinitionFixture.CreateTargetDefinitionWithGivenId(10);
        }
        
        [Test]
        public void ShouldNotRequireReApprovalForAnyChangesWhenNoneIsSet()
        {
            originalTargetDef.Category = TargetCategory.ENERGY_MANAGEMENT;
            originalTargetDef.Priority = Priority.High;
            originalTargetDef.OperationalMode = OperationalMode.Normal;
            originalTargetDef.Schedule = SingleScheduleFixture.Create2000Jan1AM15MinTo30Min();
            TargetDefinition targetDefWithChanges = TargetDefinitionFixture.CloneTargetDefinitionOneLevelDeep(originalTargetDef);
            targetDefWithChanges.Name += "New Name";

            targetDefWithChanges.Category = TargetCategory.PRODUCTION;
            targetDefWithChanges.OperationalMode = OperationalMode.ShutDown;
            targetDefWithChanges.Priority = Priority.Normal;
            targetDefWithChanges.Description += "New Description";
            targetDefWithChanges.DocumentLinks.Add(DocumentLinkFixture.CreateDocumentLinkWithID(10));
            targetDefWithChanges.FunctionalLocation = FunctionalLocationFixture.GetAny_Unit1();
            targetDefWithChanges.TagInfo = TagInfoFixture.CreateTagInfoWithId2FromDB();
            targetDefWithChanges.AssociatedTargetDTOs.Add(TargetDefinitionDTOFixture.CreateTargetDefinitionDTO());
            targetDefWithChanges.Schedule = ContinuousScheduleFixture.CreateContinuousScheduleWithNoEndDateFromOctober17AtMidnight();
            targetDefWithChanges.GenerateActionItem = !originalTargetDef.GenerateActionItem;
            targetDefWithChanges.RequiresResponseWhenAlerted = !originalTargetDef.RequiresResponseWhenAlerted;
            targetDefWithChanges.IsAlertRequired = !originalTargetDef.IsAlertRequired;

            TargetDefinitionAutoReApprovalConfiguration noneSelectedConfig = TargetDefinitionAutoReApprovalConfigurationFixture.CreateSelectedNoneTargetDefAutoReApprovalConfig(currentSite.IdValue);
            const bool expected = false;
            bool actual = noneSelectedConfig.RequrieReApproval(originalTargetDef, targetDefWithChanges);
            Assert.AreEqual(expected, actual);
        }

        #region Changing Individual Field Tests

        private void ShouldRequiresReApprovalTest(TargetDefinitionField requiredFieldChange, TargetDefinition targetDefWithChanges)
        {
            TargetDefinitionAutoReApprovalConfiguration config = TargetDefinitionAutoReApprovalConfigurationFixture.CreateConfiguration(currentSite.IdValue,
                                                                                                                                        requiredFieldChange);
            bool expected = true;
            bool actual = config.RequrieReApproval(originalTargetDef, targetDefWithChanges);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldRequiresReApprovalOnNameChange()
        {
            TargetDefinition targetDefWithChanges = TargetDefinitionFixture.CloneTargetDefinitionOneLevelDeep(originalTargetDef);
            targetDefWithChanges.Name += "New Name";
            ShouldRequiresReApprovalTest(TargetDefinitionField.Name, targetDefWithChanges);
        }

        [Test]
        public void ShouldRequriesReApprovalOnCategoryChanges()
        {
            foreach (TargetCategory category in TargetCategory.All)
            {
                TargetDefinition targetDefWithChanges = TargetDefinitionFixture.CloneTargetDefinitionOneLevelDeep(originalTargetDef);
                if (originalTargetDef.Category != category)
                {
                    targetDefWithChanges.Category = category;
                    ShouldRequiresReApprovalTest(TargetDefinitionField.Category, targetDefWithChanges);
                }
            }
        }

        [Test]
        public void ShouldRequriesReApprovalOnOperationalModeChanges()
        {
            foreach (OperationalMode operationalMode in OperationalMode.All)
            {
                TargetDefinition targetDefWithChanges = TargetDefinitionFixture.CloneTargetDefinitionOneLevelDeep(originalTargetDef);
                if (!originalTargetDef.HasOperationalMode(operationalMode))
                {
                    targetDefWithChanges.OperationalMode = operationalMode;
                    ShouldRequiresReApprovalTest(TargetDefinitionField.OperationalMode, targetDefWithChanges);
                }
            }
        }

        [Test]
        public void ShouldRequriesReApprovalOnPriorityChanges()
        {
            foreach (Priority priority in TargetDefinition.Priorities)
            {
                TargetDefinition targetDefWithChanges = TargetDefinitionFixture.CloneTargetDefinitionOneLevelDeep(originalTargetDef);
                if (originalTargetDef.Priority != priority)
                {
                    targetDefWithChanges.Priority = priority;
                    ShouldRequiresReApprovalTest(TargetDefinitionField.Priority, targetDefWithChanges);
                }
            }
        }

        [Test]
        public void ShouldRequriesReApprovalOnDescriptionChanges()
        {
            TargetDefinition targetDefWithChanges = TargetDefinitionFixture.CloneTargetDefinitionOneLevelDeep(originalTargetDef);
            targetDefWithChanges.Description += "More New Description";
            ShouldRequiresReApprovalTest(TargetDefinitionField.Description, targetDefWithChanges);
        }

        [Test]
        public void ShouldRequriesReApprovalOnFunctionalLocationChanges()
        {
            TargetDefinition targetDefWithChanges = TargetDefinitionFixture.CloneTargetDefinitionOneLevelDeep(originalTargetDef);
            targetDefWithChanges.FunctionalLocation = FunctionalLocationFixture.CreateNew("SOME-OTHER-UNIT");
            ShouldRequiresReApprovalTest(TargetDefinitionField.FunctionalLocation, targetDefWithChanges);
        }

        [Test]
        public void ShouldRequriesReApprovalOnPHTagChanges()
        {
            TargetDefinition targetDefWithChanges = TargetDefinitionFixture.CloneTargetDefinitionOneLevelDeep(originalTargetDef);
            targetDefWithChanges.TagInfo = TagInfoFixture.CreateTagInfoWithId2FromDB();
            ShouldRequiresReApprovalTest(TargetDefinitionField.PHTag, targetDefWithChanges);
        }

        [Test]
        public void ShouldRequriesReApprovalOnTargetDependenceisChange()
        {
            TargetDefinition targetDefWithChanges = TargetDefinitionFixture.CloneTargetDefinitionOneLevelDeep(originalTargetDef);
            targetDefWithChanges.AssociatedTargetDTOs.Add(TargetDefinitionDTOFixture.CreateTargetDefinitionDTO());
            ShouldRequiresReApprovalTest(TargetDefinitionField.TargetDependencies, targetDefWithChanges);
        }

        [Test]
        public void ShouldRequriesReApprovalOnScheduleChanges()
        {
            TargetDefinition targetDefWithChanges = TargetDefinitionFixture.CloneTargetDefinitionOneLevelDeep(originalTargetDef);
            targetDefWithChanges.Schedule = ContinuousScheduleFixture.CreateContinuousScheduleFromOctober17AtMidnightToOctober27AtMidnight();
            ShouldRequiresReApprovalTest(TargetDefinitionField.Schedule, targetDefWithChanges);
        }

        [Test]
        public void ShouldRequriesReApprovalOnGenerateActionItemChanges()
        {
            TargetDefinition targetDefWithChanges = TargetDefinitionFixture.CloneTargetDefinitionOneLevelDeep(originalTargetDef);
            targetDefWithChanges.GenerateActionItem = ! originalTargetDef.GenerateActionItem;
            ShouldRequiresReApprovalTest(TargetDefinitionField.GenerateActionItem, targetDefWithChanges);
        }

        [Test]
        public void ShouldRequriesReApprovalOnRequriesResponseWhenAlertedChanges()
        {
            TargetDefinition targetDefWithChanges = TargetDefinitionFixture.CloneTargetDefinitionOneLevelDeep(originalTargetDef);
            targetDefWithChanges.RequiresResponseWhenAlerted = ! originalTargetDef.RequiresResponseWhenAlerted;
            ShouldRequiresReApprovalTest(TargetDefinitionField.RequiresResponseWhenAlerted, targetDefWithChanges);
        }

        [Test]
        public void ShouldRequriesReApprovalOnSuppressAlertChanges()
        {
            TargetDefinition targetDefWithChanges = TargetDefinitionFixture.CloneTargetDefinitionOneLevelDeep(originalTargetDef);
            targetDefWithChanges.IsAlertRequired = ! originalTargetDef.IsAlertRequired;
            ShouldRequiresReApprovalTest(TargetDefinitionField.SuppressAlert, targetDefWithChanges);
        }
        #endregion
    }
}