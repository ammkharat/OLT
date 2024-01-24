using System;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using ActionItemDefinitionField = Com.Suncor.Olt.Common.Fixtures.ActionItemDefinitionAutoReApprovalConfigurationFixture.ActionItemDefinitionField;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class ActionItemDefinitionAutoReApprovalConfigurationTest
    {
        private Site currentSite;
        private ActionItemDefinition originalActionItemDefinition;

        [SetUp]
        public void SetUp()
        {
            currentSite = SiteFixture.Sarnia();
            originalActionItemDefinition = ActionItemDefinitionFixture.CreateActionItemDefinition();
        }

        [Test]
        public void ShouldNotRequireReApprovalWhenNoneSelectedOnConfig()
        {
            originalActionItemDefinition.Category = BusinessCategoryFixture.GetProductionCategory();
            originalActionItemDefinition.OperationalMode = OperationalMode.Normal;
            originalActionItemDefinition.Priority = Priority.High;
            originalActionItemDefinition.Schedule = SingleScheduleFixture.Create2000Jan1AM15MinTo30Min();

            ActionItemDefinitionAutoReApprovalConfiguration config = ActionItemDefinitionAutoReApprovalConfigurationFixture.CreateSelectedNoneAIDAutoReApprovalConfiguration(currentSite.IdValue);
            ActionItemDefinition aidWithChanges = ActionItemDefinitionFixture.CloneActionItemDefinitionOneLevelDeep(originalActionItemDefinition);
            aidWithChanges.Name += "New Name";
            aidWithChanges.Category = BusinessCategoryFixture.GetRoutineActivityCategory();
            aidWithChanges.OperationalMode = OperationalMode.ShutDown;
            aidWithChanges.Priority = Priority.Normal;
            aidWithChanges.Description += "New Description";
            aidWithChanges.DocumentLinks.Add(DocumentLinkFixture.CreateDocumentLinkWithID(10));
            aidWithChanges.FunctionalLocations.Add(FunctionalLocationFixture.GetAny_Unit1());
            aidWithChanges.TargetDefinitionDTOs.Add(TargetDefinitionDTOFixture.CreateTargetDefinitionDTO());
            aidWithChanges.Schedule = ContinuousScheduleFixture.CreateContinuousScheduleWithNoEndDateFromOctober17AtMidnight();
            aidWithChanges.ResponseRequired = !originalActionItemDefinition.ResponseRequired;

            const bool expected = false;
            bool actual = config.RequireReApproval(originalActionItemDefinition, aidWithChanges);
            Assert.AreEqual(expected, actual);
        }

        #region RequrieReApproval - Individual Field Changes

        private void ShouldRequireReApprovalTest(ActionItemDefinition aidWithChanges, ActionItemDefinitionField requireApprovalField)
        {
            ActionItemDefinitionAutoReApprovalConfiguration config = ActionItemDefinitionAutoReApprovalConfigurationFixture.CreateConfiguration(currentSite.IdValue, requireApprovalField);
            const bool expected = true;
            bool actual = config.RequireReApproval(originalActionItemDefinition, aidWithChanges);
            Assert.AreEqual(expected, actual);
        }

        private void ShouldNotRequireReApprovalTest(ActionItemDefinition aidWithChanges, ActionItemDefinitionField requireApprovalField)
        {
            ActionItemDefinitionAutoReApprovalConfiguration config = ActionItemDefinitionAutoReApprovalConfigurationFixture.CreateConfiguration(currentSite.IdValue, requireApprovalField);
            const bool expected = false;
            bool actual = config.RequireReApproval(originalActionItemDefinition, aidWithChanges);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldRequireReApprovalWhenNameChanges()
        {
            ActionItemDefinition aidWithChanges = ActionItemDefinitionFixture.CloneActionItemDefinitionOneLevelDeep(originalActionItemDefinition);
            aidWithChanges.Name += "New Name";
            ShouldRequireReApprovalTest(aidWithChanges, ActionItemDefinitionField.Name);
        }

        [Test]
        public void ShouldRequireReApprovalWhenCategoryChanges()
        {
            foreach (BusinessCategory category in BusinessCategoryFixture.GetList())
            {
                ActionItemDefinition aidWithChanges = ActionItemDefinitionFixture.CloneActionItemDefinitionOneLevelDeep(originalActionItemDefinition);
                aidWithChanges.Category = category;

                if (category.Equals(originalActionItemDefinition.Category))
                {
                    ShouldNotRequireReApprovalTest(aidWithChanges, ActionItemDefinitionField.Category);
                }
                else
                {
                    ShouldRequireReApprovalTest(aidWithChanges, ActionItemDefinitionField.Category);
                }
            }
        }

        [Test]
        public void ShouldRequireReApprovalWhenOperationalModeChanges()
        {
            foreach (OperationalMode operationalMode in OperationalMode.All)
            {
                ActionItemDefinition aidWithChanges = ActionItemDefinitionFixture.CloneActionItemDefinitionOneLevelDeep(originalActionItemDefinition);
                aidWithChanges.OperationalMode = operationalMode;
                if (operationalMode.Equals(originalActionItemDefinition.OperationalMode))
                {
                    ShouldNotRequireReApprovalTest(aidWithChanges, ActionItemDefinitionField.OperationalMode);
                }
                else
                {
                    ShouldRequireReApprovalTest(aidWithChanges, ActionItemDefinitionField.OperationalMode);
                }
            }
        }

        [Test]
        public void ShouldRequireReApprovalWhenPriorityChanges()
        {
            foreach (Priority priority in ActionItemDefinition.Priorities)
            {
                ActionItemDefinition aidWithChanges = 
                    ActionItemDefinitionFixture.CloneActionItemDefinitionOneLevelDeep(originalActionItemDefinition);
                aidWithChanges.Priority = new Priority(priority.IdValue, priority.SortOrder);

                if (priority.Equals(originalActionItemDefinition.Priority))
                {
                    ShouldNotRequireReApprovalTest(aidWithChanges, ActionItemDefinitionField.Priority);
                }
                else
                {
                    ShouldRequireReApprovalTest(aidWithChanges, ActionItemDefinitionField.Priority);
                }
            }
        }

        [Test]
        public void ShouldRequireReApprovalWhenDescriptionChanges()
        {
            ActionItemDefinition aidWithChanges = ActionItemDefinitionFixture.CloneActionItemDefinitionOneLevelDeep(originalActionItemDefinition);
            aidWithChanges.Description += "New Description";
            ShouldRequireReApprovalTest(aidWithChanges, ActionItemDefinitionField.Description);
        }
        
        [Test]
        public void ShouldRequireReApprovalWhenDocumentsChanges()
        {
            ActionItemDefinition aidWithChanges = ActionItemDefinitionFixture.CloneActionItemDefinitionOneLevelDeep(originalActionItemDefinition);
            aidWithChanges.DocumentLinks.Add(DocumentLinkFixture.CreateDocumentLinkWithID(10));
            ShouldRequireReApprovalTest(aidWithChanges, ActionItemDefinitionField.DocumentLinks);
        }

        [Test]
        public void ShouldRequireReApprovalWhenFunctionalLocationsChange()
        {
            ActionItemDefinition aidWithChanges = ActionItemDefinitionFixture.CloneActionItemDefinitionOneLevelDeep(originalActionItemDefinition);
            aidWithChanges.FunctionalLocations.Add(FunctionalLocationFixture.GetAny_Equip1());
            ShouldRequireReApprovalTest(aidWithChanges, ActionItemDefinitionField.FunctionalLocations);
        }
        
        [Test]
        public void ShouldRequireReApprovalWhenTargetDependenciesChange()
        {
            ActionItemDefinition aidWithChanges = ActionItemDefinitionFixture.CloneActionItemDefinitionOneLevelDeep(originalActionItemDefinition);
            aidWithChanges.TargetDefinitionDTOs.Add(TargetDefinitionDTOFixture.CreateTargetDefinitionDTO());
            ShouldRequireReApprovalTest(aidWithChanges, ActionItemDefinitionField.TargetDependencies);
        }
        
        [Test]
        public void ShouldRequireReApprovalWhenScheduleChanges()
        {
            ActionItemDefinition aidWithChanges = ActionItemDefinitionFixture.CloneActionItemDefinitionOneLevelDeep(originalActionItemDefinition);
            aidWithChanges.Schedule = ContinuousScheduleFixture.CreateContinuousScheduleWithNoEndDateFromOctober17AtMidnight();
            ShouldRequireReApprovalTest(aidWithChanges, ActionItemDefinitionField.Schedule);
        }

        [Test]
        public void ShouldNotRequireReapprovalWhenScheduleIsTheSameExceptForThatItFired()
        {
            originalActionItemDefinition.Schedule = ContinuousScheduleFixture.CreateContinuousScheduleWithNoEndDateFromOctober17AtMidnight();

            ActionItemDefinition aidWithChanges = ActionItemDefinitionFixture.CloneActionItemDefinitionOneLevelDeep(originalActionItemDefinition);
            aidWithChanges.Schedule = ContinuousScheduleFixture.CreateContinuousScheduleWithNoEndDateFromOctober17AtMidnight();

            // first do the simple case, where all the properties are the same
            {
                ShouldNotRequireReApprovalTest(aidWithChanges, ActionItemDefinitionField.Schedule);    
            }

            // we want to ignore last invoked date time when we check whether reapproval is needed, because the schedule that the action item def'n form sets on
            // the editObject is a fresh one with no last invoked date/time and that is being compared to the original schedule which does have a last invoekd
            // date/time.
            {
                aidWithChanges.Schedule.LastInvokedDateTime = new DateTime(2013, 8, 13);
                ShouldNotRequireReApprovalTest(aidWithChanges, ActionItemDefinitionField.Schedule);
            }
        }

        [Test]
        public void ShouldRequireReApprovalWhenResponseRequiredChanges()
        {
            ActionItemDefinition aidWithChanges = ActionItemDefinitionFixture.CloneActionItemDefinitionOneLevelDeep(originalActionItemDefinition);
            aidWithChanges.ResponseRequired = !originalActionItemDefinition.ResponseRequired;
            ShouldRequireReApprovalTest(aidWithChanges, ActionItemDefinitionField.RequiresResponse);
        }

        [Test]
        public void ShouldRequireReApprovalWhenActionItemGenerationModeChanges()
        {
            ActionItemDefinition aidWithChanges = ActionItemDefinitionFixture.CloneActionItemDefinitionOneLevelDeep(originalActionItemDefinition);
            aidWithChanges.CreateAnActionItemForEachFunctionalLocation = !originalActionItemDefinition.CreateAnActionItemForEachFunctionalLocation;
            ShouldRequireReApprovalTest(aidWithChanges, ActionItemDefinitionField.ActionItemGenerationMode);
        }

        [Test]
        public void ShouldNotRequireReapprovalWhenAssignmentHasNotActuallyChangedButTheTwoAssignmentsBeingComparedHaveDifferentReferences()
        {
            WorkAssignment edmontonAssignmentCopy1 = WorkAssignmentFixture.GetEdmontonAssignmentThatIsReallyInTheDatabaseTestData();
            WorkAssignment edmontonAssignmentCopy2 = WorkAssignmentFixture.GetEdmontonAssignmentThatIsReallyInTheDatabaseTestData();

            originalActionItemDefinition.Assignment = edmontonAssignmentCopy1;
            ActionItemDefinition aidWithChanges = ActionItemDefinitionFixture.CloneActionItemDefinitionOneLevelDeep(originalActionItemDefinition);
            aidWithChanges.Assignment = edmontonAssignmentCopy2;

            ShouldNotRequireReApprovalTest(aidWithChanges, ActionItemDefinitionField.Assignment);                
        }
        
        [Test]
        public void ShouldRequireReapprovalWhenOneAssignmentIsNullAndTheOtherIsNot()
        {
            WorkAssignment edmontonAssignmentCopy1 = WorkAssignmentFixture.GetEdmontonAssignmentThatIsReallyInTheDatabaseTestData();

            {
                originalActionItemDefinition.Assignment = edmontonAssignmentCopy1;
                ActionItemDefinition aidWithChanges = ActionItemDefinitionFixture.CloneActionItemDefinitionOneLevelDeep(originalActionItemDefinition);
                aidWithChanges.Assignment = null;

                ShouldRequireReApprovalTest(aidWithChanges, ActionItemDefinitionField.Assignment);                
            }

            {
                originalActionItemDefinition.Assignment = null;
                ActionItemDefinition aidWithChanges = ActionItemDefinitionFixture.CloneActionItemDefinitionOneLevelDeep(originalActionItemDefinition);
                aidWithChanges.Assignment = edmontonAssignmentCopy1;

                ShouldRequireReApprovalTest(aidWithChanges, ActionItemDefinitionField.Assignment);
            }

            {
                originalActionItemDefinition.Assignment = null;
                ActionItemDefinition aidWithChanges = ActionItemDefinitionFixture.CloneActionItemDefinitionOneLevelDeep(originalActionItemDefinition);
                aidWithChanges.Assignment = null;

                ShouldNotRequireReApprovalTest(aidWithChanges, ActionItemDefinitionField.Assignment);
            }
        }

        #endregion
    }
}
