using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client.Security
{
    [TestFixture]
    public class SummaryLogAuthorizationTest
    {
        [Test]
        public void IsTimeInShift()
        {
            ShiftPattern shiftPattern =
                ShiftPatternFixture.CreateShiftPattern(new Time(22, 00), new Time(04, 00));

            Assert.IsFalse(SummaryLogAuthorization.IsTimeInExactShift(shiftPattern, new Time(21, 59)));
            Assert.IsTrue(SummaryLogAuthorization.IsTimeInExactShift(shiftPattern, new Time(22, 0)));
            Assert.IsTrue(SummaryLogAuthorization.IsTimeInExactShift(shiftPattern, new Time(22, 1)));
            Assert.IsTrue(SummaryLogAuthorization.IsTimeInExactShift(shiftPattern, new Time(3, 59)));
            Assert.IsTrue(SummaryLogAuthorization.IsTimeInExactShift(shiftPattern, new Time(4, 0)));
            Assert.IsFalse(SummaryLogAuthorization.IsTimeInExactShift(shiftPattern, new Time(4, 01)));
        }
        
    }
}