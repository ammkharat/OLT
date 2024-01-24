using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Client
{
    [TestFixture]
    public class ClientSessionTest
    {
        [Test]
        public void GetTimeRemainingInShiftWithPostShiftPaddingShouldWorkProperly()
        {
            // Now is 8:11am
            // The shift ended at 8am.
            // The end of shift padding is 120 minutes.
            // The time remaining should be 60 + 49 minutes = 109 minutes

            Clock.Freeze();
            Clock.Now = new DateTime(2014, 2, 5, 8, 11, 0);
            Date yesterday = new Date(Clock.Now.AddDays(-1));

            ClientSession session = ClientSession.GetInstance();
            UserShift userShift = UserShiftFixture.CreateUserShift(new Time(20), new Time(8), yesterday, new TimeSpan(0, 120, 0));            

            ClientSession.GetUserContext().UserShift = userShift;

            TimeSpan timeRemaining = session.GetTimeRemainingInShiftWithPostShiftPadding();
            Assert.AreEqual(109, timeRemaining.TotalMinutes);

            Clock.UnFreeze();
        }
    }
}
