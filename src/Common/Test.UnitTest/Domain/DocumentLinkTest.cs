using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class DocumentLinkTest
    {
        [Test]
        public void ShouldCloneDocumentLinkWithoutId()
        {
            DocumentLink link = DocumentLinkFixture.CreateDocumentLinkWithID(2);
            DocumentLink clonedLink = link.CloneWithoutId();            
            Assert.AreEqual(link.Title, clonedLink.Title);
            Assert.AreEqual(link.TitleWithUrl, clonedLink.TitleWithUrl);
            Assert.AreEqual(null, clonedLink.Id);
        }

        [Test]
        public void CloneOfDocumentShouldPerformACopyOfFields()
        {
            DocumentLink link = DocumentLinkFixture.CreateDocumentLinkWithID(2);
            DocumentLink clonedLink = link.CloneWithoutId();
            link.Title = "Update original document title to verify a clone is taking place.";
            Assert.AreNotEqual(link.Title, clonedLink.Title);
        }
    }
}
