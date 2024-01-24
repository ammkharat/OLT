using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class LogDefinitionTest
    {
        [Test]
        public void TakeSnapshotShouldCreateLogDefinitionHistory()
        {
            LogDefinition logDefinition = LogDefinitionFixture.CreateOperatingEngineerLogDefintionWithRecurringWeeklySchedule();
            logDefinition.CustomFieldEntries.Add(new CustomFieldEntry(1, 1, "Custom Field Name", "Field Entry", null,null, 1, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off,null));
            logDefinition.DocumentLinks.Add(DocumentLinkFixture.CreateDocumentLinkWithID(2));
            logDefinition.Id = -99;

            LogDefinitionHistory snapshot = logDefinition.TakeSnapshot(new List<CustomField> { new CustomField(1, "Custom Field Name", 1, null, CustomFieldType.GeneralText, CustomFieldPhdLinkType.Off, new List<CustomFieldDropDownValue>()) });
            
            Assert.AreEqual(logDefinition.Id, snapshot.Id);
            Assert.AreEqual(logDefinition.LastModifiedBy, snapshot.LastModifiedBy);
            Assert.AreEqual(logDefinition.LastModifiedDate, snapshot.LastModifiedDate);

            // CCTODO make this work for RTF comments
            //Assert.AreEqual(logDefinition.Comments.Count, snapshot.Comments.Count);
            //for (int i = 0; i < logDefinition.Comments.Count; i++)
            //{
            //    Assert.AreEqual(logDefinition.Comments[i].Text, snapshot.Comments[i].Text);                
            //}

            Assert.AreEqual(logDefinition.CustomFieldEntries.Count, snapshot.CustomFieldEntries.Count);

            Assert.AreEqual(logDefinition.Schedule.ToString(false), snapshot.Schedule);
            Assert.AreEqual(logDefinition.FunctionalLocations.ConvertAll(floc => floc.FullHierarchy).BuildCommaSeparatedList(), snapshot.FunctionalLocations);
            Assert.AreEqual(logDefinition.InspectionFollowUp, snapshot.InspectionFollowUp);
            Assert.AreEqual(logDefinition.ProcessControlFollowUp, snapshot.ProcessControlFollowUp);
            Assert.AreEqual(logDefinition.OperationsFollowUp, snapshot.OperationsFollowUp);
            Assert.AreEqual(logDefinition.SupervisionFollowUp, snapshot.SupervisionFollowUp);
            Assert.AreEqual(logDefinition.EnvironmentalHealthSafetyFollowUp, snapshot.EnvironmentalHealthSafetyFollowUp);
            Assert.AreEqual(logDefinition.OtherFollowUp, snapshot.OtherFollowUp);
            Assert.AreEqual(logDefinition.Deleted, snapshot.Deleted);
            
            Assert.AreEqual(logDefinition.DocumentLinks[0].TitleWithUrl, snapshot.DocumentLinks);
        }

        [Test]
        public void LogDefinitionsOfTypeStandardShouldBeRelevantByFloc()
        {
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Montreal());
            const int flocId = 1;

            FunctionalLocation sr1OffsBdof = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF();
            sr1OffsBdof.Id = flocId;

            FunctionalLocation sr1Plt3Bdp3 = FunctionalLocationFixture.GetReal_SR1_PLT3_BDP3();
            sr1Plt3Bdp3.Id = -1;

            LogDefinition logDefinition = LogDefinitionFixture.CreateLogDefinition(1, LogType.Standard);           
            logDefinition.FunctionalLocations = new List<FunctionalLocation> { sr1Plt3Bdp3, sr1OffsBdof };

            // client is at same level as one of the flocs
            Assert.IsTrue(logDefinition.IsRelevantTo(Site.SARNIA_ID, new List<string> { sr1OffsBdof.FullHierarchy }, null,null, siteConfiguration));

            // client is one level up
            FunctionalLocation sr1Offs = FunctionalLocationFixture.GetReal_SR1_OFFS();
            Assert.IsTrue(logDefinition.IsRelevantTo(Site.SARNIA_ID, new List<string> { sr1Offs.FullHierarchy }, null,null, siteConfiguration));

            // client is two levels up
            FunctionalLocation sr1 = FunctionalLocationFixture.GetReal_SR1();
            Assert.IsTrue(logDefinition.IsRelevantTo(Site.SARNIA_ID, new List<string> { sr1.FullHierarchy }, null,null, siteConfiguration));

            // client is one level down
            FunctionalLocation sr1OffsBdofSab = FunctionalLocationFixture.GetReal_SR1_OFFS_BDOF_SAB();
            Assert.IsTrue(logDefinition.IsRelevantTo(Site.SARNIA_ID, new List<string> { sr1OffsBdofSab.FullHierarchy },null, null, siteConfiguration));

            // client is not at same third level as log flocs
            FunctionalLocation sr1OffsTkfm = FunctionalLocationFixture.GetReal_SR1_OFFS_TKFM();
            Assert.IsFalse(logDefinition.IsRelevantTo(Site.SARNIA_ID, new List<string> { sr1OffsTkfm.FullHierarchy }, null,null, siteConfiguration));            

        }
    }
}
