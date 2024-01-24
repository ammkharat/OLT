using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [TestFixture]
    public class TargetGapReasonTest
    {
        [Test]
        public void ShouldGetAllReasons()
        {
            TargetGapReason[] reasons = TargetGapReason.All;
            Assert.IsTrue(reasons.Length > 0);
        }

        [Test]
        public void ShouldGetAllReasonsPrecededWithEmptyReason()
        {
            TargetGapReason[] reasons = TargetGapReason.AllWithEmpty;
            Assert.AreEqual(1 + TargetGapReason.All.Length, reasons.Length);

            Assert.AreEqual(TargetGapReason.Null, reasons[0]);
        }

        [Test]
        public void ShouldGetReasonById()
        {
            const long EQUIPMENT_FAILURE_ID = 0;
            TargetGapReason reason = TargetGapReason.Get(EQUIPMENT_FAILURE_ID);
            Assert.AreEqual(EQUIPMENT_FAILURE_ID, reason.IdValue);
            Assert.AreEqual("Equipment Failure", reason.Name);
            Assert.IsTrue(reason.IsMechanical);
        }

        [Test]
        public void ShouldGetNullReasonIfUnrecognizedId()
        {
            Assert.AreEqual(TargetGapReason.Null, TargetGapReason.Get(-234789));
            Assert.AreEqual(TargetGapReason.Null, TargetGapReason.Get(null));
        }
    }
}
