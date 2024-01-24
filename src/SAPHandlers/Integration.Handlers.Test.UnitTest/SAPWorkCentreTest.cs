using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Integration.Handlers
{
    [TestFixture]
    public class SAPWorkCentreTest
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void ShouldReturnFalseWithInValidWorkCentreNameOPRPRX()
        {
            var result = SAPWorkCentre.IsInWorkCentreList("OPRPRX");
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldReturnFalseWithInValidWorkCentreNameX()
        {
            var result = SAPWorkCentre.IsInWorkCentreList("X");
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldReturnTrueWithValidWorkCentreNameO()
        {
            var result = SAPWorkCentre.IsInWorkCentreList("O");
            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldReturnTrueWithValidWorkCentreNameOP()
        {
            var result = SAPWorkCentre.IsInWorkCentreList("OP");
            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldReturnTrueWithValidWorkCentreNameOPR()
        {
            var result = SAPWorkCentre.IsInWorkCentreList("OPR");
            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldReturnTrueWithValidWorkCentreNameOPRP()
        {
            var result = SAPWorkCentre.IsInWorkCentreList("OPRP");
            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldReturnTrueWithValidWorkCentreNameOPRPR()
        {
            var result = SAPWorkCentre.IsInWorkCentreList("OPRPR");
            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldReturnTrueWithValidWorkCentreNamePRTEC()
        {
            var result = SAPWorkCentre.IsInWorkCentreList("PRTEC");
            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldReturnTrueWithValidWorkCentreNamePRTEC1()
        {
            var result = SAPWorkCentre.IsInWorkCentreList("PRTEC1");
            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldReturnTrueWithValidWorkCentreNamePRTEC1DashC()
        {
            var result = SAPWorkCentre.IsInWorkCentreList("PRTEC1-C");
            Assert.IsTrue(result);
        }
    }
}