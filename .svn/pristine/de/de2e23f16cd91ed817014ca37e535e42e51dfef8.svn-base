using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class WorkAssignmentTest
    {
        [Test] // What is this testing? That a fixture works? I'm confused. (Dustin)
        public void ShouldCreateWorkAssignmentWithName()
        {
            WorkAssignment workAssignment = WorkAssignmentFixture.CreateUnitLeader();
            Assert.AreEqual("IU", workAssignment.Name);
        }
        
        [Test]
        public void ShouldGenerateDisplayNameBasedOnNameAndDescription()
        {
            WorkAssignment assignment = WorkAssignmentFixture.CreateUnitLeader();
            Assert.AreEqual("IU - UnitLeader", assignment.DisplayName);
        }

        [Test]
        public void ShouldCompareEquality()
        {
            {
                WorkAssignment asg1 = new WorkAssignment(1, "asg1", "asg1 desc", "category", 1, null, true, true, null, null, null,true,true);
                WorkAssignment asg2 = new WorkAssignment(1, "asg2", "asg2 desc", "category", 1, null, true, true, null, null, null,true,true);
                Assert.IsTrue(asg1.Equals(asg2));
            }

            {
                WorkAssignment asg1 = new WorkAssignment(1, "asg1", "asg1 desc", "category", 1, null, true, true, null, null, null,true,true);
                WorkAssignment asg2 = new WorkAssignment(2, "asg1", "asg1 desc", "category", 1, null, true, true, null, null, null,true,true);
                Assert.IsFalse(asg1.Equals(asg2));
            }

            {
                WorkAssignment asg1 = new WorkAssignment(1, "asg1", "asg1 desc", "category", 1, null, true, true, null, null, null,true,true);
                WorkAssignment asg2 = new WorkAssignment("asg2", "asg2 desc", "category", 1, null);
                Assert.IsFalse(asg1.Equals(asg2));
            }

            {
                WorkAssignment asg1 = new WorkAssignment("asg1", "asg1 desc", "category", 1, null);
                WorkAssignment asg2 = new WorkAssignment("asg1", "asg1 desc", "category", 1, null);

                Assert.IsTrue(asg1.Equals(asg2));
            }

            {
                WorkAssignment asg1 = new WorkAssignment("asg1", "asg1 desc", "category", 1, null);
                Assert.IsTrue(asg1.Equals(asg1));
            }

            {
                WorkAssignment asg1 = new WorkAssignment("asg1", "asg1 desc", "category", 1, null);
                Assert.IsFalse(asg1.Equals(null));
            }
        }
    }
}
