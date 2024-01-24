using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [TestFixture]
    public class BaseMergeablePermitRequestTest
    {
        [Test]
        public void ShouldDetermineIfMatchesByPermitKey()
        {
            WorkPermitLubesGroup fakeGroup = new WorkPermitLubesGroup(1, "group 1", 0);

            BaseMergeablePermitRequest request1 = PermitRequestLubesFixture.CreateForInsert(fakeGroup);
            request1.WorkOrderNumber = "1111";
            request1.ClearWorkOrderSources();
            request1.AddWorkOrderSource("1111", "0010", null);

            BaseMergeablePermitRequest request2 = PermitRequestLubesFixture.CreateForInsert(fakeGroup);
            request2.WorkOrderNumber = "1111";
            request2.ClearWorkOrderSources();
            request2.AddWorkOrderSource("1111", "0020", null);

            Assert.IsTrue(request1.MatchesByPermitKey(new PermitKeyData("1111", "0010", null)));
            Assert.IsFalse(request1.MatchesByPermitKey(new PermitKeyData("1111", "0020", null)));
            Assert.IsFalse(request1.MatchesByPermitKey(new PermitKeyData("2222", "0010", null)));
            
            Assert.IsTrue(request2.MatchesByPermitKey(new PermitKeyData("1111", "0020", null)));
            Assert.IsFalse(request2.MatchesByPermitKey(new PermitKeyData("1111", "0010", null)));
            Assert.IsFalse(request2.MatchesByPermitKey(new PermitKeyData("2222", "0010", null)));            
        }
    }
}
