using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class TargetDefinitionAutoReApprovalConfigurationDaoTest : AbstractDaoTest
    {
        private ITargetDefinitionAutoReApprovalConfigurationDao dao;
        private Site site;

        protected override void TestInitialize()
        {
            site = SiteFixture.Sarnia();
            dao = DaoRegistry.GetDao<ITargetDefinitionAutoReApprovalConfigurationDao>();
        }

        protected override void Cleanup()
        {
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void ShouldQueryBySiteId()
        {
            long siteId = site.Id.Value;
            const bool nameChange = true;
            const bool categoryChange = true;
            const bool operationalModeChange = true;
            const bool priorityChange = true;
            const bool descriptionChange = true;
            const bool documentLinksChange = true;
            const bool functionalLocationChange = true;
            const bool pHTagChange = true;
            const bool targetDependenciesChange = true;
            const bool scheduleChange = true;
            const bool generateActionItemChange = true;
            const bool requiesResponseWhenAlteredChange = true;
            const bool suppressAlertChange = true;
            TargetDefinitionAutoReApprovalConfiguration expected = new TargetDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                   nameChange,
                                                                                                                   categoryChange,
                                                                                                                   operationalModeChange,
                                                                                                                   priorityChange,
                                                                                                                   descriptionChange,
                                                                                                                   documentLinksChange,
                                                                                                                   functionalLocationChange,
                                                                                                                   pHTagChange,
                                                                                                                   targetDependenciesChange,
                                                                                                                   scheduleChange,
                                                                                                                   generateActionItemChange,
                                                                                                                   requiesResponseWhenAlteredChange,
                                                                                                                   suppressAlertChange);
            TargetDefinitionAutoReApprovalConfiguration actual = dao.QueryById(siteId);
            Assert.AreEqual(expected, actual);
        }

        [Ignore] [Test]
        public void ShouldQueryMontrealBySiteID()
        {
            TargetDefinitionAutoReApprovalConfiguration configuration = dao.QueryById(Site.MONTREAL_ID);
            Assert.IsNotNull(configuration);
        }

        private void UpdateTest(TargetDefinitionAutoReApprovalConfiguration expectedConfig)
        {
            dao.Update(expectedConfig);
            TargetDefinitionAutoReApprovalConfiguration actualConfig = dao.QueryById(expectedConfig.SiteId);
            Assert.AreEqual(expectedConfig, actualConfig);
        }

        [Ignore] [Test]
        public void ShouldUpdateNameChange()
        {
            long siteId = site.Id.Value;
            const bool nameChange = true;
            const bool categoryChange = false;
            const bool operationalModeChange = false;
            const bool priorityChange = false;
            const bool descriptionChange = false;
            const bool documentLinksChange = false;
            const bool functionalLocationChange = false;
            const bool pHTagChange = false;
            const bool targetDependenciesChange = false;
            const bool scheduleChange = false;
            const bool generateActionItemChange = false;
            const bool requiesResponseWhenAlteredChange = false;
            const bool suppressAlertChange = false;
            TargetDefinitionAutoReApprovalConfiguration expectedConfig = new TargetDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                         nameChange,
                                                                                                                         categoryChange,
                                                                                                                         operationalModeChange,
                                                                                                                         priorityChange,
                                                                                                                         descriptionChange,
                                                                                                                         documentLinksChange,
                                                                                                                         functionalLocationChange,
                                                                                                                         pHTagChange,
                                                                                                                         targetDependenciesChange,
                                                                                                                         scheduleChange,
                                                                                                                         generateActionItemChange,
                                                                                                                         requiesResponseWhenAlteredChange,
                                                                                                                         suppressAlertChange);
            UpdateTest(expectedConfig);
        }

        [Ignore] [Test]
        public void ShouldUpdateCategoryChange()
        {
            long siteId = site.Id.Value;
            const bool nameChange = false;
            const bool categoryChange = true;
            const bool operationalModeChange = false;
            const bool priorityChange = false;
            const bool descriptionChange = false;
            const bool documentLinksChange = false;
            const bool functionalLocationChange = false;
            const bool pHTagChange = false;
            const bool targetDependenciesChange = false;
            const bool scheduleChange = false;
            const bool generateActionItemChange = false;
            const bool requiesResponseWhenAlteredChange = false;
            const bool suppressAlertChange = false;
            TargetDefinitionAutoReApprovalConfiguration expectedConfig = new TargetDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                         nameChange,
                                                                                                                         categoryChange,
                                                                                                                         operationalModeChange,
                                                                                                                         priorityChange,
                                                                                                                         descriptionChange,
                                                                                                                         documentLinksChange,
                                                                                                                         functionalLocationChange,
                                                                                                                         pHTagChange,
                                                                                                                         targetDependenciesChange,
                                                                                                                         scheduleChange,
                                                                                                                         generateActionItemChange,
                                                                                                                         requiesResponseWhenAlteredChange,
                                                                                                                         suppressAlertChange);
            UpdateTest(expectedConfig);
        }

        [Ignore] [Test]
        public void ShouldUpdateOperationalModeChange()
        {
            long siteId = site.Id.Value;
            const bool nameChange = false;
            const bool categoryChange = false;
            const bool operationalModeChange = true;
            const bool priorityChange = false;
            const bool descriptionChange = false;
            const bool documentLinksChange = false;
            const bool functionalLocationChange = false;
            const bool pHTagChange = false;
            const bool targetDependenciesChange = false;
            const bool scheduleChange = false;
            const bool generateActionItemChange = false;
            const bool requiesResponseWhenAlteredChange = false;
            const bool suppressAlertChange = false;
            TargetDefinitionAutoReApprovalConfiguration expectedConfig = new TargetDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                         nameChange,
                                                                                                                         categoryChange,
                                                                                                                         operationalModeChange,
                                                                                                                         priorityChange,
                                                                                                                         descriptionChange,
                                                                                                                         documentLinksChange,
                                                                                                                         functionalLocationChange,
                                                                                                                         pHTagChange,
                                                                                                                         targetDependenciesChange,
                                                                                                                         scheduleChange,
                                                                                                                         generateActionItemChange,
                                                                                                                         requiesResponseWhenAlteredChange,
                                                                                                                         suppressAlertChange);
            UpdateTest(expectedConfig);
        }

        [Ignore] [Test]
        public void ShouldUpdatePriorityChange()
        {
            long siteId = site.Id.Value;
            const bool nameChange = false;
            const bool categoryChange = false;
            const bool operationalModeChange = false;
            const bool priorityChange = true;
            const bool descriptionChange = false;
            const bool documentLinksChange = false;
            const bool functionalLocationChange = false;
            const bool pHTagChange = false;
            const bool targetDependenciesChange = false;
            const bool scheduleChange = false;
            const bool generateActionItemChange = false;
            const bool requiesResponseWhenAlteredChange = false;
            const bool suppressAlertChange = false;
            TargetDefinitionAutoReApprovalConfiguration expectedConfig = new TargetDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                         nameChange,
                                                                                                                         categoryChange,
                                                                                                                         operationalModeChange,
                                                                                                                         priorityChange,
                                                                                                                         descriptionChange,
                                                                                                                         documentLinksChange,
                                                                                                                         functionalLocationChange,
                                                                                                                         pHTagChange,
                                                                                                                         targetDependenciesChange,
                                                                                                                         scheduleChange,
                                                                                                                         generateActionItemChange,
                                                                                                                         requiesResponseWhenAlteredChange,
                                                                                                                         suppressAlertChange);
            UpdateTest(expectedConfig);
        }

        [Ignore] [Test]
        public void ShouldUpdateDescriptionChange()
        {
            long siteId = site.Id.Value;
            const bool nameChange = false;
            const bool categoryChange = false;
            const bool operationalModeChange = false;
            const bool priorityChange = false;
            const bool descriptionChange = true;
            const bool documentLinksChange = false;
            const bool functionalLocationChange = false;
            const bool pHTagChange = false;
            const bool targetDependenciesChange = false;
            const bool scheduleChange = false;
            const bool generateActionItemChange = false;
            const bool requiesResponseWhenAlteredChange = false;
            const bool suppressAlertChange = false;
            TargetDefinitionAutoReApprovalConfiguration expectedConfig = new TargetDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                         nameChange,
                                                                                                                         categoryChange,
                                                                                                                         operationalModeChange,
                                                                                                                         priorityChange,
                                                                                                                         descriptionChange,
                                                                                                                         documentLinksChange,
                                                                                                                         functionalLocationChange,
                                                                                                                         pHTagChange,
                                                                                                                         targetDependenciesChange,
                                                                                                                         scheduleChange,
                                                                                                                         generateActionItemChange,
                                                                                                                         requiesResponseWhenAlteredChange,
                                                                                                                         suppressAlertChange);
            UpdateTest(expectedConfig);
        }

        [Ignore] [Test]
        public void ShouldUpdateDocumentLinksChange()
        {
            long siteId = site.Id.Value;
            const bool nameChange = false;
            const bool categoryChange = false;
            const bool operationalModeChange = false;
            const bool priorityChange = false;
            const bool descriptionChange = false;
            const bool documentLinksChange = true;
            const bool functionalLocationChange = false;
            const bool pHTagChange = false;
            const bool targetDependenciesChange = false;
            const bool scheduleChange = false;
            const bool generateActionItemChange = false;
            const bool requiesResponseWhenAlteredChange = false;
            const bool suppressAlertChange = false;
            TargetDefinitionAutoReApprovalConfiguration expectedConfig = new TargetDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                         nameChange,
                                                                                                                         categoryChange,
                                                                                                                         operationalModeChange,
                                                                                                                         priorityChange,
                                                                                                                         descriptionChange,
                                                                                                                         documentLinksChange,
                                                                                                                         functionalLocationChange,
                                                                                                                         pHTagChange,
                                                                                                                         targetDependenciesChange,
                                                                                                                         scheduleChange,
                                                                                                                         generateActionItemChange,
                                                                                                                         requiesResponseWhenAlteredChange,
                                                                                                                         suppressAlertChange);
            UpdateTest(expectedConfig);
        }

        [Ignore] [Test]
        public void ShouldUpdateFunctionalLocationChange()
        {
            long siteId = site.Id.Value;
            const bool nameChange = false;
            const bool categoryChange = false;
            const bool operationalModeChange = false;
            const bool priorityChange = false;
            const bool descriptionChange = false;
            const bool documentLinksChange = false;
            const bool functionalLocationChange = true;
            const bool pHTagChange = false;
            const bool targetDependenciesChange = false;
            const bool scheduleChange = false;
            const bool generateActionItemChange = false;
            const bool requiesResponseWhenAlteredChange = false;
            const bool suppressAlertChange = false;
            TargetDefinitionAutoReApprovalConfiguration expectedConfig = new TargetDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                         nameChange,
                                                                                                                         categoryChange,
                                                                                                                         operationalModeChange,
                                                                                                                         priorityChange,
                                                                                                                         descriptionChange,
                                                                                                                         documentLinksChange,
                                                                                                                         functionalLocationChange,
                                                                                                                         pHTagChange,
                                                                                                                         targetDependenciesChange,
                                                                                                                         scheduleChange,
                                                                                                                         generateActionItemChange,
                                                                                                                         requiesResponseWhenAlteredChange,
                                                                                                                         suppressAlertChange);
            UpdateTest(expectedConfig);
        }

        [Ignore] [Test]
        public void ShouldUpdatePHTagChange()
        {
            long siteId = site.Id.Value;
            const bool nameChange = false;
            const bool categoryChange = false;
            const bool operationalModeChange = false;
            const bool priorityChange = false;
            const bool descriptionChange = false;
            const bool documentLinksChange = false;
            const bool functionalLocationChange = false;
            const bool pHTagChange = true;
            const bool targetDependenciesChange = false;
            const bool scheduleChange = false;
            const bool generateActionItemChange = false;
            const bool requiesResponseWhenAlteredChange = false;
            const bool suppressAlertChange = false;
            TargetDefinitionAutoReApprovalConfiguration expectedConfig = new TargetDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                         nameChange,
                                                                                                                         categoryChange,
                                                                                                                         operationalModeChange,
                                                                                                                         priorityChange,
                                                                                                                         descriptionChange,
                                                                                                                         documentLinksChange,
                                                                                                                         functionalLocationChange,
                                                                                                                         pHTagChange,
                                                                                                                         targetDependenciesChange,
                                                                                                                         scheduleChange,
                                                                                                                         generateActionItemChange,
                                                                                                                         requiesResponseWhenAlteredChange,
                                                                                                                         suppressAlertChange);
            UpdateTest(expectedConfig);
        }

        [Ignore] [Test]
        public void ShouldUpdateTargetDependenciesChange()
        {
            long siteId = site.Id.Value;
            const bool nameChange = false;
            const bool categoryChange = false;
            const bool operationalModeChange = false;
            const bool priorityChange = false;
            const bool descriptionChange = false;
            const bool documentLinksChange = false;
            const bool functionalLocationChange = false;
            const bool pHTagChange = false;
            const bool targetDependenciesChange = true;
            const bool scheduleChange = false;
            const bool generateActionItemChange = false;
            const bool requiesResponseWhenAlteredChange = false;
            const bool suppressAlertChange = false;
            TargetDefinitionAutoReApprovalConfiguration expectedConfig = new TargetDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                         nameChange,
                                                                                                                         categoryChange,
                                                                                                                         operationalModeChange,
                                                                                                                         priorityChange,
                                                                                                                         descriptionChange,
                                                                                                                         documentLinksChange,
                                                                                                                         functionalLocationChange,
                                                                                                                         pHTagChange,
                                                                                                                         targetDependenciesChange,
                                                                                                                         scheduleChange,
                                                                                                                         generateActionItemChange,
                                                                                                                         requiesResponseWhenAlteredChange,
                                                                                                                         suppressAlertChange);
            UpdateTest(expectedConfig);
        }

        [Ignore] [Test]
        public void ShouldUpdateScheduleChange()
        {
            long siteId = site.Id.Value;
            const bool nameChange = false;
            const bool categoryChange = false;
            const bool operationalModeChange = false;
            const bool priorityChange = false;
            const bool descriptionChange = false;
            const bool documentLinksChange = false;
            const bool functionalLocationChange = false;
            const bool pHTagChange = false;
            const bool targetDependenciesChange = false;
            const bool scheduleChange = true;
            const bool generateActionItemChange = false;
            const bool requiesResponseWhenAlteredChange = false;
            const bool suppressAlertChange = false;
            TargetDefinitionAutoReApprovalConfiguration expectedConfig = new TargetDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                         nameChange,
                                                                                                                         categoryChange,
                                                                                                                         operationalModeChange,
                                                                                                                         priorityChange,
                                                                                                                         descriptionChange,
                                                                                                                         documentLinksChange,
                                                                                                                         functionalLocationChange,
                                                                                                                         pHTagChange,
                                                                                                                         targetDependenciesChange,
                                                                                                                         scheduleChange,
                                                                                                                         generateActionItemChange,
                                                                                                                         requiesResponseWhenAlteredChange,
                                                                                                                         suppressAlertChange);
            UpdateTest(expectedConfig);
        }

        [Ignore] [Test]
        public void ShouldUpdateGenerateActionItemChange()
        {
            long siteId = site.Id.Value;
            const bool nameChange = false;
            const bool categoryChange = false;
            const bool operationalModeChange = false;
            const bool priorityChange = false;
            const bool descriptionChange = false;
            const bool documentLinksChange = false;
            const bool functionalLocationChange = false;
            const bool pHTagChange = false;
            const bool targetDependenciesChange = false;
            const bool scheduleChange = false;
            const bool generateActionItemChange = true;
            const bool requiesResponseWhenAlteredChange = false;
            const bool suppressAlertChange = false;
            TargetDefinitionAutoReApprovalConfiguration expectedConfig = new TargetDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                         nameChange,
                                                                                                                         categoryChange,
                                                                                                                         operationalModeChange,
                                                                                                                         priorityChange,
                                                                                                                         descriptionChange,
                                                                                                                         documentLinksChange,
                                                                                                                         functionalLocationChange,
                                                                                                                         pHTagChange,
                                                                                                                         targetDependenciesChange,
                                                                                                                         scheduleChange,
                                                                                                                         generateActionItemChange,
                                                                                                                         requiesResponseWhenAlteredChange,
                                                                                                                         suppressAlertChange);
            UpdateTest(expectedConfig);
        }

        [Ignore] [Test]
        public void ShouldUpdateRequiresResponseChange()
        {
            long siteId = site.Id.Value;
            const bool nameChange = false;
            const bool categoryChange = false;
            const bool operationalModeChange = false;
            const bool priorityChange = false;
            const bool descriptionChange = false;
            const bool documentLinksChange = false;
            const bool functionalLocationChange = false;
            const bool pHTagChange = false;
            const bool targetDependenciesChange = false;
            const bool scheduleChange = false;
            const bool generateActionItemChange = false;
            const bool requiesResponseWhenAlteredChange = true;
            const bool suppressAlertChange = false;
            TargetDefinitionAutoReApprovalConfiguration expectedConfig = new TargetDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                         nameChange,
                                                                                                                         categoryChange,
                                                                                                                         operationalModeChange,
                                                                                                                         priorityChange,
                                                                                                                         descriptionChange,
                                                                                                                         documentLinksChange,
                                                                                                                         functionalLocationChange,
                                                                                                                         pHTagChange,
                                                                                                                         targetDependenciesChange,
                                                                                                                         scheduleChange,
                                                                                                                         generateActionItemChange,
                                                                                                                         requiesResponseWhenAlteredChange,
                                                                                                                         suppressAlertChange);
            UpdateTest(expectedConfig);
        }

        [Ignore] [Test]
        public void ShouldUpdateSuppressAlertChange()
        {
            long siteId = site.Id.Value;
            const bool nameChange = false;
            const bool categoryChange = false;
            const bool operationalModeChange = false;
            const bool priorityChange = false;
            const bool descriptionChange = false;
            const bool documentLinksChange = false;
            const bool functionalLocationChange = false;
            const bool pHTagChange = false;
            const bool targetDependenciesChange = false;
            const bool scheduleChange = false;
            const bool generateActionItemChange = false;
            const bool requiesResponseWhenAlteredChange = false;
            const bool suppressAlertChange = true;
            TargetDefinitionAutoReApprovalConfiguration expectedConfig = new TargetDefinitionAutoReApprovalConfiguration(siteId,
                                                                                                                         nameChange,
                                                                                                                         categoryChange,
                                                                                                                         operationalModeChange,
                                                                                                                         priorityChange,
                                                                                                                         descriptionChange,
                                                                                                                         documentLinksChange,
                                                                                                                         functionalLocationChange,
                                                                                                                         pHTagChange,
                                                                                                                         targetDependenciesChange,
                                                                                                                         scheduleChange,
                                                                                                                         generateActionItemChange,
                                                                                                                         requiesResponseWhenAlteredChange,
                                                                                                                         suppressAlertChange);
            UpdateTest(expectedConfig);
        }       
    }
}