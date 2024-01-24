using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class ActionItemDefinitionAutoReApprovalConfigurationDaoTest : AbstractDaoTest
    {
        private Site site;
        private IActionItemDefinitionAutoReApprovalConfigurationDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IActionItemDefinitionAutoReApprovalConfigurationDao>();
            site = SiteFixture.Sarnia();
        }

        protected override void Cleanup()
        {
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void ShouldQueryBySiteId()
        {
            long siteId = site.IdValue;
            const bool nameChange = true;
            const bool categoryChange = true;
            const bool operationalModeChange = true;
            const bool priorityChange = true;
            const bool descriptionChange = true;
            const bool documentLinksChange = true;
            const bool functionalLocationsChange = true;
            const bool targetDependenciesChange = true;
            const bool scheduleChange = true;
            const bool requiresResponseWhenTriggeredChange = true;
            const bool assignmentChange = true;
            const bool actionItemGenerationModeChange = true;

            ActionItemDefinitionAutoReApprovalConfiguration expected = new ActionItemDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                           nameChange,
                                                                                                                           categoryChange,
                                                                                                                           operationalModeChange,
                                                                                                                           priorityChange,
                                                                                                                           descriptionChange,
                                                                                                                           documentLinksChange,
                                                                                                                           functionalLocationsChange,
                                                                                                                           targetDependenciesChange,
                                                                                                                           scheduleChange,
                                                                                                                           requiresResponseWhenTriggeredChange,
                                                                                                                           assignmentChange,
                                                                                                                           actionItemGenerationModeChange);
            ActionItemDefinitionAutoReApprovalConfiguration actual = dao.QueryBySiteId(siteId);
            Assert.AreEqual(expected, actual);
        }
        
        private void UpdateTest(ActionItemDefinitionAutoReApprovalConfiguration expected)
        {
            dao.Update(expected);
            ActionItemDefinitionAutoReApprovalConfiguration actual = dao.QueryBySiteId(expected.SiteId);
            Assert.AreEqual(expected, actual);
        }

        [Ignore] [Test]
        public void ShouldUpdateNameChange()
        {
            long siteId = site.IdValue;
            const bool nameChange = true;
            const bool categoryChange = true;
            const bool operationalModeChange = true;
            const bool priorityChange = true;
            const bool descriptionChange = true;
            const bool documentLinksChange = true;
            const bool functionalLocationsChange = true;
            const bool targetDependenciesChange = true;
            const bool scheduleChange = true;
            const bool requiresResponseWhenTriggeredChange = true;
            const bool assignmentChange = true;
            const bool actionItemGenerationModeChange = true;

            ActionItemDefinitionAutoReApprovalConfiguration expected = new ActionItemDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                           nameChange,
                                                                                                                           categoryChange,
                                                                                                                           operationalModeChange,
                                                                                                                           priorityChange,
                                                                                                                           descriptionChange,
                                                                                                                           documentLinksChange,
                                                                                                                           functionalLocationsChange,
                                                                                                                           targetDependenciesChange,
                                                                                                                           scheduleChange,
                                                                                                                           requiresResponseWhenTriggeredChange,
                                                                                                                           assignmentChange,
                                                                                                                           actionItemGenerationModeChange);
            UpdateTest(expected);
        }

        [Ignore] [Test]
        public void ShouldUpdateCategoryChange()
        {
            long siteId = site.IdValue;
            const bool nameChange = true;
            const bool categoryChange = false;
            const bool operationalModeChange = true;
            const bool priorityChange = true;
            const bool descriptionChange = true;
            const bool documentLinksChange = true;
            const bool functionalLocationsChange = true;
            const bool targetDependenciesChange = true;
            const bool scheduleChange = true;
            const bool requiresResponseWhenTriggeredChange = true;
            const bool assignmentChange = true;
            const bool actionItemGenerationModeChange = true;

            ActionItemDefinitionAutoReApprovalConfiguration expected = new ActionItemDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                           nameChange,
                                                                                                                           categoryChange,
                                                                                                                           operationalModeChange,
                                                                                                                           priorityChange,
                                                                                                                           descriptionChange,
                                                                                                                           documentLinksChange,
                                                                                                                           functionalLocationsChange,
                                                                                                                           targetDependenciesChange,
                                                                                                                           scheduleChange,
                                                                                                                           requiresResponseWhenTriggeredChange,
                                                                                                                           assignmentChange,
                                                                                                                           actionItemGenerationModeChange);
            UpdateTest(expected);
        }

        [Ignore] [Test]
        public void ShouldUpdatePriorityChange()
        {
            long siteId = site.IdValue;
            const bool nameChange = true;
            const bool categoryChange = true;
            const bool operationalModeChange = true;
            const bool priorityChange = false;
            const bool descriptionChange = true;
            const bool documentLinksChange = true;
            const bool functionalLocationsChange = true;
            const bool targetDependenciesChange = true;
            const bool scheduleChange = true;
            const bool requiresResponseWhenTriggeredChange = true;
            const bool assignmentChange = true;
            const bool actionItemGenerationModeChange = true;

            ActionItemDefinitionAutoReApprovalConfiguration expected = new ActionItemDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                           nameChange,
                                                                                                                           categoryChange,
                                                                                                                           operationalModeChange,
                                                                                                                           priorityChange,
                                                                                                                           descriptionChange,
                                                                                                                           documentLinksChange,
                                                                                                                           functionalLocationsChange,
                                                                                                                           targetDependenciesChange,
                                                                                                                           scheduleChange,
                                                                                                                           requiresResponseWhenTriggeredChange,
                                                                                                                           assignmentChange,
                                                                                                                           actionItemGenerationModeChange);
            UpdateTest(expected);
        }

        [Ignore] [Test]
        public void ShouldUpdateDescriptionAndAssignmentChange()
        {
            long siteId = site.IdValue;
            const bool nameChange = true;
            const bool categoryChange = true;
            const bool operationalModeChange = true;
            const bool priorityChange = true;
            const bool descriptionChange = false;
            const bool documentLinksChange = true;
            const bool functionalLocationsChange = true;
            const bool targetDependenciesChange = true;
            const bool scheduleChange = true;
            const bool requiresResponseWhenTriggeredChange = true;
            const bool assignmentChange = false;
            const bool actionItemGenerationModeChange = true;

            ActionItemDefinitionAutoReApprovalConfiguration expected = new ActionItemDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                           nameChange,
                                                                                                                           categoryChange,
                                                                                                                           operationalModeChange,
                                                                                                                           priorityChange,
                                                                                                                           descriptionChange,
                                                                                                                           documentLinksChange,
                                                                                                                           functionalLocationsChange,
                                                                                                                           targetDependenciesChange,
                                                                                                                           scheduleChange,
                                                                                                                           requiresResponseWhenTriggeredChange,
                                                                                                                           assignmentChange,
                                                                                                                           actionItemGenerationModeChange);
            UpdateTest(expected);
        }

        [Ignore] [Test]
        public void ShouldUpdateDocumentLinksChange()
        {
            long siteId = site.IdValue;
            const bool nameChange = true;
            const bool categoryChange = true;
            const bool operationalModeChange = true;
            const bool priorityChange = true;
            const bool descriptionChange = true;
            const bool documentLinksChange = false;
            const bool functionalLocationsChange = true;
            const bool targetDependenciesChange = true;
            const bool scheduleChange = true;
            const bool requiresResponseWhenTriggeredChange = true;
            const bool assignmentChange = true;
            const bool actionItemGenerationModeChange = true;

            ActionItemDefinitionAutoReApprovalConfiguration expected = new ActionItemDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                           nameChange,
                                                                                                                           categoryChange,
                                                                                                                           operationalModeChange,
                                                                                                                           priorityChange,
                                                                                                                           descriptionChange,
                                                                                                                           documentLinksChange,
                                                                                                                           functionalLocationsChange,
                                                                                                                           targetDependenciesChange,
                                                                                                                           scheduleChange,
                                                                                                                           requiresResponseWhenTriggeredChange,
                                                                                                                           assignmentChange,
                                                                                                                           actionItemGenerationModeChange);
            UpdateTest(expected);
        }

        [Ignore] [Test]
        public void ShouldUpdateFunctionalLocationsChange()
        {
            long siteId = site.IdValue;
            const bool nameChange = true;
            const bool categoryChange = true;
            const bool operationalModeChange = true;
            const bool priorityChange = true;
            const bool descriptionChange = true;
            const bool documentLinksChange = true;
            const bool functionalLocationsChange = false;
            const bool targetDependenciesChange = true;
            const bool scheduleChange = true;
            const bool requiresResponseWhenTriggeredChange = true;
            const bool assignmentChange = true;
            const bool actionItemGenerationModeChange = true;

            ActionItemDefinitionAutoReApprovalConfiguration expected = new ActionItemDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                           nameChange,
                                                                                                                           categoryChange,
                                                                                                                           operationalModeChange,
                                                                                                                           priorityChange,
                                                                                                                           descriptionChange,
                                                                                                                           documentLinksChange,
                                                                                                                           functionalLocationsChange,
                                                                                                                           targetDependenciesChange,
                                                                                                                           scheduleChange,
                                                                                                                           requiresResponseWhenTriggeredChange,
                                                                                                                           assignmentChange,
                                                                                                                           actionItemGenerationModeChange);
            UpdateTest(expected);
        }

        [Ignore] [Test]
        public void ShouldUpdateTargetDependenciesChange()
        {
            long siteId = site.IdValue;
            const bool nameChange = true;
            const bool categoryChange = true;
            const bool operationalModeChange = true;
            const bool priorityChange = true;
            const bool descriptionChange = true;
            const bool documentLinksChange = true;
            const bool functionalLocationsChange = true;
            const bool targetDependenciesChange = false;
            const bool scheduleChange = true;
            const bool requiresResponseWhenTriggeredChange = true;
            const bool assignmentChange = true;
            const bool actionItemGenerationModeChange = true;

            ActionItemDefinitionAutoReApprovalConfiguration expected = new ActionItemDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                           nameChange,
                                                                                                                           categoryChange,
                                                                                                                           operationalModeChange,
                                                                                                                           priorityChange,
                                                                                                                           descriptionChange,
                                                                                                                           documentLinksChange,
                                                                                                                           functionalLocationsChange,
                                                                                                                           targetDependenciesChange,
                                                                                                                           scheduleChange,
                                                                                                                           requiresResponseWhenTriggeredChange,
                                                                                                                           assignmentChange,
                                                                                                                           actionItemGenerationModeChange);
            UpdateTest(expected);
        }

        [Ignore] [Test]
        public void ShouldUpdateScheduleChange()
        {
            long siteId = site.IdValue;
            const bool nameChange = true;
            const bool categoryChange = true;
            const bool operationalModeChange = true;
            const bool priorityChange = true;
            const bool descriptionChange = true;
            const bool documentLinksChange = true;
            const bool functionalLocationsChange = true;
            const bool targetDependenciesChange = true;
            const bool scheduleChange = false;
            const bool requiresResponseWhenTriggeredChange = true;
            const bool assignmentChange = true;
            const bool actionItemGenerationModeChange = true;

            ActionItemDefinitionAutoReApprovalConfiguration expected = new ActionItemDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                           nameChange,
                                                                                                                           categoryChange,
                                                                                                                           operationalModeChange,
                                                                                                                           priorityChange,
                                                                                                                           descriptionChange,
                                                                                                                           documentLinksChange,
                                                                                                                           functionalLocationsChange,
                                                                                                                           targetDependenciesChange,
                                                                                                                           scheduleChange,
                                                                                                                           requiresResponseWhenTriggeredChange,
                                                                                                                           assignmentChange,
                                                                                                                           actionItemGenerationModeChange);
            UpdateTest(expected);
        }

        [Ignore] [Test]
        public void ShouldUpdateRequiresResponseWhenTriggeredChange()
        {
            long siteId = site.IdValue;
            const bool nameChange = true;
            const bool categoryChange = true;
            const bool operationalModeChange = true;
            const bool priorityChange = true;
            const bool descriptionChange = true;
            const bool documentLinksChange = true;
            const bool functionalLocationsChange = true;
            const bool targetDependenciesChange = true;
            const bool scheduleChange = true;
            const bool requiresResponseWhenTriggeredChange = false;
            const bool assignmentChange = true;
            const bool actionItemGenerationModeChange = true;

            ActionItemDefinitionAutoReApprovalConfiguration expected = new ActionItemDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                           nameChange,
                                                                                                                           categoryChange,
                                                                                                                           operationalModeChange,
                                                                                                                           priorityChange,
                                                                                                                           descriptionChange,
                                                                                                                           documentLinksChange,
                                                                                                                           functionalLocationsChange,
                                                                                                                           targetDependenciesChange,
                                                                                                                           scheduleChange,
                                                                                                                           requiresResponseWhenTriggeredChange,
                                                                                                                           assignmentChange,
                                                                                                                           actionItemGenerationModeChange);
            UpdateTest(expected);
        }   
     
        [Ignore] [Test]
        public void ShouldUpdateactionItemGenerationModeChange()
        {
            long siteId = site.IdValue;
            const bool nameChange = true;
            const bool categoryChange = true;
            const bool operationalModeChange = true;
            const bool priorityChange = true;
            const bool descriptionChange = true;
            const bool documentLinksChange = true;
            const bool functionalLocationsChange = true;
            const bool targetDependenciesChange = true;
            const bool scheduleChange = true;
            const bool requiresResponseWhenTriggeredChange = true;
            const bool assignmentChange = true;
            const bool actionItemGenerationModeChange = false;

            ActionItemDefinitionAutoReApprovalConfiguration expected = new ActionItemDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                           nameChange,
                                                                                                                           categoryChange,
                                                                                                                           operationalModeChange,
                                                                                                                           priorityChange,
                                                                                                                           descriptionChange,
                                                                                                                           documentLinksChange,
                                                                                                                           functionalLocationsChange,
                                                                                                                           targetDependenciesChange,
                                                                                                                           scheduleChange,
                                                                                                                           requiresResponseWhenTriggeredChange,
                                                                                                                           assignmentChange,
                                                                                                                           actionItemGenerationModeChange);
            UpdateTest(expected);
        } 
    }
}