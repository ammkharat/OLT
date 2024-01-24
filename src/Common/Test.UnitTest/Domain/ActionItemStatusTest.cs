using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    /// <summary>
    /// Summary description for ActionItemStatusTest
    /// </summary>
    [TestFixture]
    public class ActionItemStatusTest
    {

        [Test]
        public void ShouldGetPendingStatusByUsingIndexFromPendingObject()
        {
            Assert.AreEqual(ActionItemStatus.Current, ActionItemStatus.Get(ActionItemStatus.Current.Id.Value));
        }


    }
}
