using Com.Suncor.Olt.Common.Domain.WorkPermit;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class PermitRequestBasedWorkPermitStatusTest
    {
        [Test]
        public void PendingShouldBeLessThanIssued()
        {
            Assert.That(PermitRequestBasedWorkPermitStatus.Pending < PermitRequestBasedWorkPermitStatus.Issued);
        }

        [Test]
        public void IssuedShouldBeGreaterThanX()
        {
            Assert.That(PermitRequestBasedWorkPermitStatus.Pending > PermitRequestBasedWorkPermitStatus.Requested);
        }

        [Test]
        public void IssuedShouldBeLessThanAllTerminatingStatueses()
        {
            Assert.That(PermitRequestBasedWorkPermitStatus.Issued < PermitRequestBasedWorkPermitStatus.Complete);
            Assert.That(PermitRequestBasedWorkPermitStatus.Issued < PermitRequestBasedWorkPermitStatus.Incomplete);
            Assert.That(PermitRequestBasedWorkPermitStatus.Issued < PermitRequestBasedWorkPermitStatus.Void);
            Assert.That(PermitRequestBasedWorkPermitStatus.Issued < PermitRequestBasedWorkPermitStatus.CompletionUnknown);
        }

        [Test]
        public void AllTerminatingStatusesShouldBeEqual()
        {
            Assert.That(PermitRequestBasedWorkPermitStatus.Complete < PermitRequestBasedWorkPermitStatus.Incomplete, Is.False);
            Assert.That(PermitRequestBasedWorkPermitStatus.Complete < PermitRequestBasedWorkPermitStatus.Void, Is.False);
            Assert.That(PermitRequestBasedWorkPermitStatus.Incomplete < PermitRequestBasedWorkPermitStatus.Void, Is.False);
            Assert.That(PermitRequestBasedWorkPermitStatus.CompletionUnknown < PermitRequestBasedWorkPermitStatus.Incomplete, Is.False);

            Assert.That(PermitRequestBasedWorkPermitStatus.Complete > PermitRequestBasedWorkPermitStatus.Incomplete, Is.False);
            Assert.That(PermitRequestBasedWorkPermitStatus.Complete > PermitRequestBasedWorkPermitStatus.Void, Is.False);
            Assert.That(PermitRequestBasedWorkPermitStatus.Incomplete > PermitRequestBasedWorkPermitStatus.Void, Is.False);
            Assert.That(PermitRequestBasedWorkPermitStatus.CompletionUnknown > PermitRequestBasedWorkPermitStatus.Incomplete, Is.False);

            Assert.That(PermitRequestBasedWorkPermitStatus.Complete <= PermitRequestBasedWorkPermitStatus.Incomplete, Is.True);
            Assert.That(PermitRequestBasedWorkPermitStatus.Complete <= PermitRequestBasedWorkPermitStatus.Void, Is.True);
            Assert.That(PermitRequestBasedWorkPermitStatus.Incomplete <= PermitRequestBasedWorkPermitStatus.Void, Is.True);
            Assert.That(PermitRequestBasedWorkPermitStatus.CompletionUnknown <= PermitRequestBasedWorkPermitStatus.Incomplete, Is.True);

            Assert.That(PermitRequestBasedWorkPermitStatus.Complete >= PermitRequestBasedWorkPermitStatus.Incomplete, Is.True);
            Assert.That(PermitRequestBasedWorkPermitStatus.Complete >= PermitRequestBasedWorkPermitStatus.Void, Is.True);
            Assert.That(PermitRequestBasedWorkPermitStatus.Incomplete >= PermitRequestBasedWorkPermitStatus.Void, Is.True);
            Assert.That(PermitRequestBasedWorkPermitStatus.CompletionUnknown >= PermitRequestBasedWorkPermitStatus.Incomplete, Is.True);
        }
    }
}