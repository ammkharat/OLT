using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class ContractorTest
    {
        [Test]
        public void EqualsShouldReturnTrueWhenTwoContractorsHaveTheSameInformation()
        {
            Contractor contractor1 = ContractorFixture.CreateContractor(1, "Joe's Plumbing");
            Contractor contractor2 = ContractorFixture.CreateContractor(1, "Joe's Plumbing");
            
            Assert.IsTrue(contractor1.Equals(contractor2));
        }

        [Test]
        public void EqualsShouldReturnFalseWhenTwoContractorsHaveDifferentInformation()
        {
            Contractor contractor1 = ContractorFixture.CreateContractor(1, "Joe's Plumbing");
            Contractor contractor2 = ContractorFixture.CreateContractor(1, "Mike and the Mechanics");

            Assert.IsFalse(contractor1.Equals(contractor2));
        }
        
        
    }
}
