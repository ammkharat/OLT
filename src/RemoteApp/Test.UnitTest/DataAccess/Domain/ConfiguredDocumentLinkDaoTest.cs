using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class ConfiguredDocumentLinkDaoTest : AbstractDaoTest
    {
        private IConfiguredDocumentLinkDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IConfiguredDocumentLinkDao>();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void QueryByLocationShouldReturnOnlyLinksForThatLocation()
        {
            dao.Insert(new ConfiguredDocumentLink(null, "heyo", "whoa", ConfiguredDocumentLinkLocation.WorkPermitMontreal, 0));
            dao.Remove(dao.Insert(new ConfiguredDocumentLink(null, "deleted", "deleted", ConfiguredDocumentLinkLocation.WorkPermitMontreal, 0)));
            dao.Insert(new ConfiguredDocumentLink(null, "otherLocationLink", "otherLocationLink", ConfiguredDocumentLinkLocation.ConfinedSpaceMontreal, 0));

            List<ConfiguredDocumentLink> links = dao.QueryByLocation(ConfiguredDocumentLinkLocation.WorkPermitMontreal);

            Assert.IsTrue(links.Count > 0);
            Assert.IsTrue(links.TrueForAll(link => link.Location.Equals(ConfiguredDocumentLinkLocation.WorkPermitMontreal)));
            Assert.IsFalse(links.Exists(link => link.Title == "deleted"));
        }

        [Ignore] [Test]
        public void UpdateValuesShouldDeleteAndInsertAndUpdateAsAppropriate()
        {
            ConfiguredDocumentLinkLocation linkLocation = ConfiguredDocumentLinkLocation.WorkPermitMontreal;
            int originalCountOfLinks = 0;            
            {
                List<ConfiguredDocumentLink> alreadyExistingLinks = dao.QueryByLocation(linkLocation);
                originalCountOfLinks += alreadyExistingLinks.Count;
            }

            ConfiguredDocumentLink linkOne = dao.Insert(new ConfiguredDocumentLink(null, "a-title", "a-link", linkLocation, 0));
            ConfiguredDocumentLink linkTwo = dao.Insert(new ConfiguredDocumentLink(null, "b-title", "b-link", linkLocation, 1));
            ConfiguredDocumentLink linkThree = dao.Insert(new ConfiguredDocumentLink(null, "c-title", "c-link", linkLocation, 2));

            // make sure our links made it in there
            {
                List<ConfiguredDocumentLink> links = dao.QueryByLocation(linkLocation);
                Assert.AreEqual(originalCountOfLinks + 3, links.Count);
                Assert.IsNotNull(links.Find(link => link.Id == linkOne.Id));
                Assert.IsNotNull(links.Find(link => link.Id == linkTwo.Id));
                Assert.IsNotNull(links.Find(link => link.Id == linkThree.Id));
            }

            // the real test
            {
                linkOne.Title = "Modified";
                ConfiguredDocumentLink newLink = dao.Insert(new ConfiguredDocumentLink(null, "New", "New-Link", linkLocation, 3));

                List<ConfiguredDocumentLink> links = new List<ConfiguredDocumentLink> { linkOne, linkThree, newLink };
                List<ConfiguredDocumentLink> deletedLinks = new List<ConfiguredDocumentLink> { linkTwo };

                dao.UpdateLinks(links, deletedLinks);

                List<ConfiguredDocumentLink> queriedLinks = dao.QueryByLocation(linkLocation);
                Assert.AreEqual(originalCountOfLinks + 3, queriedLinks.Count);

                ConfiguredDocumentLink queriedValueOne = queriedLinks.Find(link => link.Id == linkOne.Id);
                Assert.IsNotNull(queriedValueOne);
                Assert.IsNotNull(queriedLinks.Find(link => link.Id == linkThree.Id));
                Assert.IsNotNull(queriedLinks.Find(link => link.Id == newLink.Id));
                Assert.AreEqual("Modified", queriedValueOne.Title);
                Assert.IsNull(queriedLinks.Find(link => link.Id == linkTwo.Id));
            }

        }
    }
}
