using System.Collections.Generic;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class SummaryLogTest
    {
        [Test]
        public void ShiftSummaryLogShouldNotBeFunctionalLocationRelevant()
        {
            SummaryLog log = SummaryLogFixture.CreateSummaryLog();
            Assert.IsFalse(log is IFunctionalLocationRelevant);
        }

        [Test]
        public void ShouldMatchBySiteWhenCheckingForRelevanceForShiftSummaryLog()
        {
            SummaryLog log = SummaryLogFixture.CreateSummaryLog();

            FunctionalLocation floc = log.FunctionalLocations[0];

            floc.Site = SiteFixture.Denver();
                       
            Assert.IsTrue(log.IsRelevantTo(SiteFixture.Denver().IdValue));
            Assert.IsFalse(log.IsRelevantTo(112233));
        }

        [Test]
        public void IsRelevantToVisibilityGroupsShouldReturnTrueIfUserCanReadGroupsThatTheLogCanWriteTo()
        {
            WorkAssignment assignment = WorkAssignmentFixture.CreateShiftEngineer();
            List<WorkAssignmentVisibilityGroup> groups = new List<WorkAssignmentVisibilityGroup>
                                                             {
                                                                 new WorkAssignmentVisibilityGroup(null, assignment.IdValue, 1, "one", VisibilityType.Write),
                                                                 new WorkAssignmentVisibilityGroup(null, assignment.IdValue, 1, "one", VisibilityType.Read),
                                                                 new WorkAssignmentVisibilityGroup(null, assignment.IdValue, 2, "two", VisibilityType.Read),
                                                                 new WorkAssignmentVisibilityGroup(null, assignment.IdValue, 3, "three", VisibilityType.Write)
                                                             };

            assignment.SetVisibilityGroups(groups);
            
            SummaryLog summaryLog = SummaryLogFixture.CreateSummaryLog();
            summaryLog.WorkAssignment = assignment;

            Assert.IsTrue(summaryLog.IsRelevantTo(new List<long> { 1, 2, 3 }));
            Assert.IsFalse(summaryLog.IsRelevantTo(new List<long> { 2 }));
            Assert.IsTrue(summaryLog.IsRelevantTo(new List<long> { 3, 4 }));
        }

    }
}
