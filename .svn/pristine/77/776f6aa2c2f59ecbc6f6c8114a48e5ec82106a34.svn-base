using System.Collections.Generic;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [TestFixture]
    public class WorkPermitLubesGroupTest
    {
        [Test]
        public void ShouldFindByPriority()
        {            
            WorkPermitLubesGroup group1 = new WorkPermitLubesGroup(1, "Group 1", 1, new List<int> { 1, 2 }, new List<string>());
            WorkPermitLubesGroup group2 = new WorkPermitLubesGroup(1, "Group 2", 1, new List<int> { 3 }, new List<string>());
            WorkPermitLubesGroup group3 = new WorkPermitLubesGroup(1, "Group 3", 1, new List<int> { 4, 5 }, new List<string>());
            List<WorkPermitLubesGroup> groups = new List<WorkPermitLubesGroup> { group1, group2, group3 };

            {
                WorkPermitLubesGroup group = WorkPermitLubesGroup.FindByPriority("1", groups);
                Assert.IsNotNull(group);
                Assert.AreEqual("Group 1", group.Name);                
            }
            {
                WorkPermitLubesGroup group = WorkPermitLubesGroup.FindByPriority("2", groups);
                Assert.IsNotNull(group);
                Assert.AreEqual("Group 1", group.Name);                
            }
            {
                WorkPermitLubesGroup group = WorkPermitLubesGroup.FindByPriority("3", groups);
                Assert.IsNotNull(group);
                Assert.AreEqual("Group 2", group.Name);                
            }
            {
                WorkPermitLubesGroup group = WorkPermitLubesGroup.FindByPriority("4", groups);
                Assert.IsNotNull(group);
                Assert.AreEqual("Group 3", group.Name);                
            }
            {
                WorkPermitLubesGroup group = WorkPermitLubesGroup.FindByPriority("5", groups);
                Assert.IsNotNull(group);
                Assert.AreEqual("Group 3", group.Name);                
            }
            {
                Assert.IsNull(WorkPermitLubesGroup.FindByPriority("42", groups));                
            }
        }

        [Test]
        public void ShouldFindByPlannerGroup()
        {
            WorkPermitLubesGroup group1 = new WorkPermitLubesGroup(1, "Group 1", 1, new List<int> { 1, 2 }, new List<string> { "PE1" });
            WorkPermitLubesGroup group2 = new WorkPermitLubesGroup(1, "Group 2", 1, new List<int> { 3 }, new List<string> { "PE2", "PE3"});
            WorkPermitLubesGroup group3 = new WorkPermitLubesGroup(1, "Group 3", 1, new List<int> { 4, 5 }, new List<string>());
            List<WorkPermitLubesGroup> groups = new List<WorkPermitLubesGroup> { group1, group2, group3 };

            {
                WorkPermitLubesGroup group = WorkPermitLubesGroup.FindByPlannerGroup("PE1", groups);
                Assert.IsNotNull(group);
                Assert.AreEqual("Group 1", group.Name);
            }
            {
                WorkPermitLubesGroup group = WorkPermitLubesGroup.FindByPlannerGroup("PE2", groups);
                Assert.IsNotNull(group);
                Assert.AreEqual("Group 2", group.Name);
            }
            {
                WorkPermitLubesGroup group = WorkPermitLubesGroup.FindByPlannerGroup("PE3", groups);
                Assert.IsNotNull(group);
                Assert.AreEqual("Group 2", group.Name);
            }          
            {
                Assert.IsNull(WorkPermitLubesGroup.FindByPlannerGroup("XYZ", groups));                
            }
        }
    }
}
