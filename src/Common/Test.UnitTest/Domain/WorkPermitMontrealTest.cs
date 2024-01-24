using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class WorkPermitMontrealTest
    {

        [Test]
        public void ShouldCloneConfinedSpaceCheckboxStateButNotNumber()
        {
            WorkPermitMontreal permit = WorkPermitMontrealFixture.CreateWorkPermitWithGivenId(5);
            permit.FormulaireDespaceClosAffiche = new TernaryString(true, "Some Value");
            permit.ConvertToClone();
            Assert.IsTrue(permit.FormulaireDespaceClosAffiche.CheckedWithNoValue);

            permit.FormulaireDespaceClosAffiche = new TernaryString(false, string.Empty);
            permit.ConvertToClone();
            Assert.IsFalse(permit.FormulaireDespaceClosAffiche.StateAsBool);

            permit.FormulaireDespaceClosAffiche = null;
            permit.ConvertToClone();
            Assert.IsNull(permit.FormulaireDespaceClosAffiche);
        }

        [Test]
        public void ShouldCloneDocumentLinksWithoutIds()
        {
            WorkPermitMontreal permit = WorkPermitMontrealFixture.CreateWorkPermitWithGivenId(5);
            permit.DocumentLinks.Add(DocumentLinkFixture.CreateDocumentLinkWithID(33));
            permit.ConvertToClone();

            Assert.AreEqual(1, permit.DocumentLinks.Count);
            Assert.IsTrue(permit.DocumentLinks.TrueForAll(link => link.Id == null));
        }

        [Test]
        public void ShouldBeRelevantToFlocsThatEqualOrAreParentOfPermit()
        {
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Montreal());

            FunctionalLocation thirdLevelFloc = FunctionalLocationFixture.GetReal_MT1_A001_U010();
            thirdLevelFloc.Id = 10;

            FunctionalLocation fourthLevelFloc = FunctionalLocationFixture.GetReal_MT1_A001_U010_SEG();
            fourthLevelFloc.Id = 11;

            FunctionalLocation fifthLevelFloc = FunctionalLocationFixture.GetReal_MT1_A001_U010_SEG_BPM0115();
            fifthLevelFloc.Id = 12;
            
            {
                WorkPermitMontreal permit = WorkPermitMontrealFixture.CreateForInsert(Clock.Now, Clock.Now, fifthLevelFloc);

                Assert.IsTrue(permit.IsRelevantTo(fifthLevelFloc.Site.IdValue, new List<string> { fifthLevelFloc.FullHierarchy }, null, null, siteConfiguration));
                Assert.IsTrue(permit.IsRelevantTo(fourthLevelFloc.Site.IdValue, new List<string> { fourthLevelFloc.FullHierarchy }, null, null, siteConfiguration));
                Assert.IsTrue(permit.IsRelevantTo(thirdLevelFloc.Site.IdValue, new List<string> { thirdLevelFloc.FullHierarchy }, null,null, siteConfiguration));
            }

            {
                WorkPermitMontreal permit = WorkPermitMontrealFixture.CreateForInsert(Clock.Now, Clock.Now, fourthLevelFloc);

                Assert.IsFalse(permit.IsRelevantTo(fifthLevelFloc.Site.IdValue, new List<string> { fifthLevelFloc.FullHierarchy }, null,null, siteConfiguration));
                Assert.IsTrue(permit.IsRelevantTo(fourthLevelFloc.Site.IdValue, new List<string> { fourthLevelFloc.FullHierarchy }, null,  null, siteConfiguration));
            }
        }
    }
}
