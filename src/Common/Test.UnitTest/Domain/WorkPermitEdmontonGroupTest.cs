using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class WorkPermitEdmontonGroupTest
    {
        [Test]
        public void ShouldFindByPriority()
        {
            WorkPermitEdmontonGroup g1 = new WorkPermitEdmontonGroup(1, "g1", new List<long> { 0, 1, 2 }, 0, true);
            WorkPermitEdmontonGroup g2 = new WorkPermitEdmontonGroup(2, "g2", new List<long> { 3 }, 0, true);
            WorkPermitEdmontonGroup g3 = new WorkPermitEdmontonGroup(3, "g3", new List<long> { 4 }, 0, false);
            WorkPermitEdmontonGroup g4 = new WorkPermitEdmontonGroup(4, "g4", null, 0, false);

            List<WorkPermitEdmontonGroup> allGroups = new List<WorkPermitEdmontonGroup> {g1, g2, g3, g4};

            Assert.AreEqual(g1, WorkPermitEdmontonGroup.FindByPriority("0", allGroups));
            Assert.AreEqual(g1, WorkPermitEdmontonGroup.FindByPriority("1", allGroups));
            Assert.AreEqual(g1, WorkPermitEdmontonGroup.FindByPriority("2", allGroups));

            Assert.AreEqual(g2, WorkPermitEdmontonGroup.FindByPriority("3", allGroups));
            Assert.AreEqual(g3, WorkPermitEdmontonGroup.FindByPriority("4", allGroups));

            Assert.IsNull(WorkPermitEdmontonGroup.FindByPriority(null, allGroups));
            Assert.IsNull(WorkPermitEdmontonGroup.FindByPriority("42", allGroups));
        }
    }
}
