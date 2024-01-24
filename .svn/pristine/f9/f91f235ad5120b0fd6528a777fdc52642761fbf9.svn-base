using System;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class GasTestElementInfoConfigurationHistoryListTest
    {
        [Test]
        public void ShouldBeEqual()
        {
            DateTime date = new DateTime(2006, 01, 01);
            User user = UserFixture.CreateOperatorMickeyInFortMcMurrySite();
            GasTestElementInfoConfigurationHistoryList list1 = new GasTestElementInfoConfigurationHistoryList(date, user);
            GasTestElementInfoConfigurationHistoryList list2 = new GasTestElementInfoConfigurationHistoryList(date, user);
            Assert.AreEqual(list1, list2);
        }
    }
}
