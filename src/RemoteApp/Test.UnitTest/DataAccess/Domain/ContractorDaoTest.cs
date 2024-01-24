using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class ContractorDaoTest : AbstractDaoTest
    {
        private IContractorDao dao;
        private Site site;
        
        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IContractorDao>();
            site = SiteFixture.Sarnia();
        }

        protected override void Cleanup()
        {
        }

        [Ignore] [Test]
        public void QueryBySiteShouldReturnListOfContractors()
        {

            Contractor sarniaContractor = dao.Insert(ContractorFixture.CreateContractor("Joe's Plumbling", site));
            Site denverSite = SiteFixture.Denver();
            Contractor denverContractor = dao.Insert(ContractorFixture.CreateContractor("Ray's Sub Shop", denverSite));

            List<Contractor> retrievedContractors = dao.QueryBySite(denverSite.Id.Value);
            Assert.That(retrievedContractors, Has.Some.Property("Id").EqualTo(denverContractor.Id));
            Assert.That(retrievedContractors, Has.None.Property("Id").EqualTo(sarniaContractor.Id));
        }
        
        [Ignore] [Test]
        public void ShouldInsertContractor()
        {
            Contractor insertedContractor = dao.Insert(ContractorFixture.CreateContractor("Joe's Plumbling", site));
            Assert.IsNotNull(insertedContractor.Id);

            List<Contractor> retrievedContractors = dao.QueryBySite(site.Id.Value);

            Contractor retrievedContractor = retrievedContractors.FindById(insertedContractor);

            Assert.AreEqual("Joe's Plumbling", retrievedContractor.CompanyName);
            Assert.AreEqual(site.Id, retrievedContractor.Site.Id);
        }

        [Ignore] [Test]
        public void ShouldRemoveContractor()
        {
            Contractor insertedContractor = dao.Insert(ContractorFixture.CreateContractor("Joe's Plumbling", site));
            List<Contractor> retrievedContractors = dao.QueryBySite(site.Id.Value);

            Assert.That(retrievedContractors, Has.Some.Property("Id").EqualTo(insertedContractor.Id));
           
            dao.Remove(insertedContractor);
            List<Contractor> retrievedContractors2 = dao.QueryBySite(site.Id.Value);

            Assert.That(retrievedContractors2, Has.None.Property("Id").EqualTo(insertedContractor.Id));
        }

        [Ignore] [Test]
        public void ShouldUpdateContractor()
        {
            Site newSite = SiteFixture.Denver();

            Contractor insertedContractor = dao.Insert(ContractorFixture.CreateContractor("Joe's Plumbling", site));
            insertedContractor.CompanyName = "Ray's Sub Shop";
            insertedContractor.Site = newSite;
            
            dao.Update(insertedContractor);

            List<Contractor> retrievedContractors = dao.QueryBySite(newSite.Id.Value);
            Contractor updatedContractor = retrievedContractors.FindById(insertedContractor);
            
            Assert.AreEqual("Ray's Sub Shop", updatedContractor.CompanyName);
            Assert.AreEqual(newSite.Id, updatedContractor.Site.Id);
        }
    }
}
