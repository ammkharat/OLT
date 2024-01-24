using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Handlers.Adapters
{
    [TestFixture]
    public class WorkOrderWorkPermitAttributeTest
    {
        [Test]
        public void ShouldParseMultipleAttributes()
        {
            var workPermitAttributes = WorkOrderWorkPermitAttribute.FromString("ABC");
            Assert.That(workPermitAttributes.IsConfinedSpaceEntry, Is.True);
            Assert.That(workPermitAttributes.IsBurnOrOpenFlame, Is.True);
            Assert.That(workPermitAttributes.IsSystemEntry, Is.True);
        }

        [Test]
        public void ShouldParseMultipleAttributesWithDelimiter()
        {
            var workPermitAttributes = WorkOrderWorkPermitAttribute.FromString(@"A\G\F\");
            Assert.That(workPermitAttributes.IsConfinedSpaceEntry, Is.True);
            Assert.That(workPermitAttributes.IsHotTap, Is.True);
            Assert.That(workPermitAttributes.IsExcavation, Is.True);
        }

        [Test]
        public void ShouldParseSingleAttributeWithDelimiter()
        {
            var workPermitAttributes = WorkOrderWorkPermitAttribute.FromString(@"A\");
            Assert.That(workPermitAttributes.IsConfinedSpaceEntry, Is.True);
        }

        [Test]
        public void ShouldParseSingleAttributeWithNoDelimiter()
        {
            var workPermitAttributes = WorkOrderWorkPermitAttribute.FromString("A");
            Assert.That(workPermitAttributes.IsConfinedSpaceEntry, Is.True);
        }
    }
}