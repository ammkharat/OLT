using Com.Suncor.Olt.Common.Domain.WorkPermit;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Utilities
{
    [TestFixture]
    public class WorkOrderWorkPermitMontrealTypeConverterTest
    {
        [Ignore] [Test]
        public void ShouldReturnColdPermitTypeForColdCodeWithBackspace()
        {
            Assert.That(WorkOrderWorkPermitMontrealTypeConverter.ToWorkPermitMontrealType(@"1\"), Is.EqualTo(WorkPermitMontrealType.COLD));
        }

        [Ignore] [Test]
        public void ShouldReturnColdPermitTypeForColdCode()
        {
            Assert.That(WorkOrderWorkPermitMontrealTypeConverter.ToWorkPermitMontrealType("1"), Is.EqualTo(WorkPermitMontrealType.COLD));
        }

        [Ignore] [Test]
        public void ShouldReturnColdPermitTypeForColdCodeWithSpacesInIt()
        {
            Assert.That(WorkOrderWorkPermitMontrealTypeConverter.ToWorkPermitMontrealType("   1     "), Is.EqualTo(WorkPermitMontrealType.COLD));
        }

        [Ignore] [Test]
        public void ShouldReturnNullForHotPermitTypeWhichIsNotUsedByMontreal()
        {
            Assert.That(WorkOrderWorkPermitMontrealTypeConverter.ToWorkPermitMontrealType("   2     "), Is.Null);
        }

        [Ignore] [Test]
        public void ShouldReturnNullForEmptyCode()
        {
            Assert.That(WorkOrderWorkPermitMontrealTypeConverter.ToWorkPermitMontrealType(string.Empty), Is.Null);
        }

        [Ignore] [Test]
        public void ShoulReturnNullForAllWhitespaceCode()
        {
            Assert.That(WorkOrderWorkPermitMontrealTypeConverter.ToWorkPermitMontrealType("    "), Is.Null);
        }

        [Ignore] [Test]
        public void ShouldReturnFreshAirForFreshAirCode()
        {
            Assert.That(WorkOrderWorkPermitMontrealTypeConverter.ToWorkPermitMontrealType("6   "), Is.EqualTo(WorkPermitMontrealType.FRESH_AIR_MASK));
        }

        [Ignore] [Test]
        public void ShouldReturnNullForCodeThatWeDoNotKnow()
        {
            Assert.That(WorkOrderWorkPermitMontrealTypeConverter.ToWorkPermitMontrealType("  7"), Is.Null);
        }
    }
}