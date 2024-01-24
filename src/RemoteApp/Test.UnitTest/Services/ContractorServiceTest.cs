using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using NMock2;
using NUnit.Framework;
using Is = NMock2.Is;

namespace Com.Suncor.Olt.Remote.Services
{
    [TestFixture]
    public class ContractorServiceTest
    {
        private Mockery mock;
        private IContractorService contractorService;
        private IContractorDao mockDao;
        private Site site;
        
        [SetUp]
        public void SetUp()
        {
            mock = new Mockery();
            mockDao = mock.NewMock<IContractorDao>();
            
            contractorService = new ContractorService(mockDao);

            site = SiteFixture.Denver();
        }

        [TearDown]
        public void TearDown()
        {
            DaoRegistry.Clear();
        }
 
        [Ignore] [Test]
        public void ShouldReturnAllContractorsForGivenSite()
        {
            List<Contractor> contractors = new List<Contractor>();
            
            Expect.Once.On(mockDao).Method("QueryBySite").With(site.IdValue).Will(Return.Value(contractors));
            
            List<Contractor> retrievedContractors = contractorService.QueryBySite(site);
            
            Assert.AreEqual(contractors, retrievedContractors);
            
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void UpdateSiteContractorsWithNewContractorsShouldInsertContractors()
        {
            Contractor newContractor1 = new Contractor();
            Contractor newContractor2 = new Contractor();
            List<Contractor> contractors = new List<Contractor>(new[] { newContractor1, newContractor2 });

            Contractor newContractor1WithId = ContractorFixture.CreateContractor(-897234);
            Contractor newContractor2WithId = ContractorFixture.CreateContractor(-234798);

            Expect.Once.On(mockDao).Method("QueryBySite").With(site.IdValue).Will(Return.Value(new List<Contractor>()));
            Expect.Once.On(mockDao).Method("Insert").With(Is.Same(newContractor1)).Will(Return.Value(newContractor1WithId));
            Expect.Once.On(mockDao).Method("Insert").With(Is.Same(newContractor2)).Will(Return.Value(newContractor2WithId));
            
            contractorService.UpdateContractors(site, contractors);
            
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void DeleteContractorsGivenExistingContractorIsMissingInNewlyConfiguredContractorList()
        {
            List<Contractor> newContractorList = new List<Contractor>();

            Contractor existingContractor1 = ContractorFixture.CreateContractor(-897234);
            Contractor existingContractor2 = ContractorFixture.CreateContractor(-234798);
            List<Contractor> existingContractorList = new List<Contractor>(new[] { existingContractor1, existingContractor2 });
            
            Expect.Once.On(mockDao).Method("QueryBySite").With(site.IdValue).Will(Return.Value(existingContractorList));
            Expect.Once.On(mockDao).Method("Remove").With(existingContractor1);
            Expect.Once.On(mockDao).Method("Remove").With(existingContractor2);
            
            contractorService.UpdateContractors(site, newContractorList);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Ignore] [Test]
        public void UpdateContractorsGivenSameContractorIdWithDifferentContractorInformation()
        {
            Contractor existingContractor1 = ContractorFixture.CreateContractor(-897234, "Josie & Plumbing");
            Contractor existingContractor2 = ContractorFixture.CreateContractor(-234798, "Mike and the Mechanics");
            List<Contractor> existingContractorList = new List<Contractor>(new[] { existingContractor1, existingContractor2 });
            
            Contractor changedContractor1 = ContractorFixture.CreateContractor(-897234, "Joe's Plumbing");
            Contractor changedContractor2 = ContractorFixture.CreateContractor(-234798, "Mike & the Mechanics");
            List<Contractor> changedContractorList = new List<Contractor>(new[] {changedContractor1, changedContractor2});

            Expect.Once.On(mockDao).Method("QueryBySite").With(site.IdValue).Will(Return.Value(existingContractorList));
            Expect.Once.On(mockDao).Method("Update").With(changedContractor1);
            Expect.Once.On(mockDao).Method("Update").With(changedContractor2);
            
            contractorService.UpdateContractors(site, changedContractorList);
            
            mock.VerifyAllExpectationsHaveBeenMet();            
        }

        [Ignore] [Test]
        public void ShouldNotUpdateContractorsGivenSameInformation()
        {
            Contractor existingContractor = ContractorFixture.CreateContractor(-897234, "Josie & Plumbing");
            List<Contractor> existingContractorList = new List<Contractor>(new[] { existingContractor });

            Contractor changedContractor = ContractorFixture.CreateContractor(-897234, "Josie & Plumbing");
            List<Contractor> changedContractorList = new List<Contractor>(new[] { changedContractor });

            Expect.Once.On(mockDao).Method("QueryBySite").With(site.IdValue).Will(Return.Value(existingContractorList));

            contractorService.UpdateContractors(site, changedContractorList);

            mock.VerifyAllExpectationsHaveBeenMet();            

        }
    }
}
