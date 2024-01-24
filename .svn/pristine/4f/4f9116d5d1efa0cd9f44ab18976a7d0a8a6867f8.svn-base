using Com.Suncor.Olt.Common.Domain.WorkPermit;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class WorkPermitStatusTest
    {
        [Test]
        public void ShouldGetPendingStatus()
        {
           Assert.AreEqual(WorkPermitStatus.Pending, WorkPermitStatus.Get(1));
        }

        [Test]
        public void ShouldGetApprovedStatus()
        {
            Assert.AreEqual(WorkPermitStatus.Approved, WorkPermitStatus.Get(2));
        }


        [Test]
        public void ShouldGetCompletedStatus()
        {
            Assert.AreEqual(WorkPermitStatus.Complete, WorkPermitStatus.Get(3));
        }


        [Test]
        public void ShouldGetRejectedStatus()
        {
            Assert.AreEqual(WorkPermitStatus.Rejected, WorkPermitStatus.Get(4));
        }

        [Test]
        public void ShouldGetIssuedStatus()
        {
            Assert.AreEqual(WorkPermitStatus.Issued, WorkPermitStatus.Get(5));
        }
    }
}
