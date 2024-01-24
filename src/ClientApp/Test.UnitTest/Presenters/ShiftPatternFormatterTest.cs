using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class ShiftPatternFormatterTest
    {
        [Test]
        public void ShouldFormatShiftPattern()
        {
            ShiftPattern shift1 = ShiftPatternFixture.CreateDayShift();
            Assert.AreEqual(shift1.Name + ": " + shift1.StartTime + " - " + shift1.EndTime, new ShiftPatternFormatter(shift1).Format());
        }
    }
}
