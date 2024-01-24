using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class DirectiveTest
    {
        [Test]
        public void IsRelevantToVisibilityGroupsShouldReturnTrueIfUserCanReadGroupsThatTheDirectiveCanWriteTo()
        {
            WorkAssignment assignment1 = WorkAssignmentFixture.CreateShiftEngineer();
            List<WorkAssignmentVisibilityGroup> groups1 = new List<WorkAssignmentVisibilityGroup> {
                                                             new WorkAssignmentVisibilityGroup(null, assignment1.IdValue, 1, "one", VisibilityType.Write),
                                                             new WorkAssignmentVisibilityGroup(null, assignment1.IdValue, 1, "one", VisibilityType.Read),
                                                             new WorkAssignmentVisibilityGroup(null, assignment1.IdValue, 2, "two", VisibilityType.Read),
                                                             new WorkAssignmentVisibilityGroup(null, assignment1.IdValue, 3, "three", VisibilityType.Read),
                                                         };
            assignment1.SetVisibilityGroups(groups1);


            WorkAssignment assignment2 = WorkAssignmentFixture.CreateShiftEngineer();
            List<WorkAssignmentVisibilityGroup> groups2 = new List<WorkAssignmentVisibilityGroup> {
                                                             new WorkAssignmentVisibilityGroup(null, assignment2.IdValue, 1, "one", VisibilityType.Write),
                                                             new WorkAssignmentVisibilityGroup(null, assignment2.IdValue, 1, "one", VisibilityType.Read),
                                                             new WorkAssignmentVisibilityGroup(null, assignment2.IdValue, 2, "two", VisibilityType.Write),
                                                             new WorkAssignmentVisibilityGroup(null, assignment2.IdValue, 2, "two", VisibilityType.Read),
                                                             new WorkAssignmentVisibilityGroup(null, assignment2.IdValue, 4, "four", VisibilityType.Write),
                                                             new WorkAssignmentVisibilityGroup(null, assignment2.IdValue, 4, "four", VisibilityType.Read),
                                                         };
            assignment2.SetVisibilityGroups(groups2);

            Directive directive = DirectiveFixture.CreateForInsert();
            directive.WorkAssignments = new List<WorkAssignment> { assignment1, assignment2 };

            Assert.IsTrue(directive.IsRelevantTo(new List<long> { 1, 2, 4 }));
            Assert.IsTrue(directive.IsRelevantTo(new List<long> { 1, 3 }));
            Assert.IsFalse(directive.IsRelevantTo(new List<long> { 3 }));
        }

        [Test]
        public void IsRelevantToVisibilityGroupsShouldReturnTrueIfTheDirectiveHasNoWorkAssignment()
        {
            Directive directive = DirectiveFixture.CreateForInsert();
            directive.WorkAssignments = new List<WorkAssignment>();

            Assert.IsTrue(directive.IsRelevantTo(new List<long> { 1, 2, 3 }));
        }

        [Test]
        public void IsRelevantToVisibilityGroupsShouldReturnFalseIfTheDirectiveHasNoWritableVisibilityGroups()
        {
            WorkAssignment assignment = WorkAssignmentFixture.CreateShiftEngineer();
            assignment.SetVisibilityGroups(new List<WorkAssignmentVisibilityGroup>(0));
            
            Directive directive = DirectiveFixture.CreateForInsert();
            directive.WorkAssignments = new List<WorkAssignment> { assignment };

            Assert.IsFalse(directive.IsRelevantTo(new List<long> { 1, 2, 3 }));
        }
    }
}
