using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Common.Utility
{
    public class WorkPermitWorkAssignmentDeterminator
    {
        private readonly List<AssignmentFlocConfiguration> allWorkAssignments;
        private readonly IFunctionalLocationService functionalLocationService;

        public WorkPermitWorkAssignmentDeterminator(
            List<AssignmentFlocConfiguration> allWorkAssignments,
            IFunctionalLocationService functionalLocationService)
        {
            this.allWorkAssignments = allWorkAssignments;
            this.functionalLocationService = functionalLocationService;
        }

        public AssignmentFlocConfiguration GetWorkAssignment(FunctionalLocation floc)
        {
            var resultingWorkAssignments = new List<AssignmentFlocConfiguration>();

            GetWorkAssignments(floc, resultingWorkAssignments);

            if (resultingWorkAssignments.Count == 1)
            {
                return resultingWorkAssignments[0];
            }

            return null;
        }

        private void GetWorkAssignments(FunctionalLocation floc,
            List<AssignmentFlocConfiguration> resultingWorkAssignments)
        {
            var workAssignmentsWithMatchingFloc =
                new List<AssignmentFlocConfiguration>();

            foreach (var workAssignment in allWorkAssignments)
            {
                if (workAssignment.FunctionalLocations.Exists(f => f.IdValue == floc.IdValue))
                {
                    workAssignmentsWithMatchingFloc.Add(workAssignment);
                }
            }

            if (workAssignmentsWithMatchingFloc.Count >= 1)
            {
                resultingWorkAssignments.AddRange(workAssignmentsWithMatchingFloc);
                return;
            }

            if (workAssignmentsWithMatchingFloc.Count == 0)
            {
                var hierarchy = new FunctionalLocationHierarchy(floc);
                var parentHierarchy = hierarchy.ParentHierarchy;
                var siteId = floc.Site.IdValue;

                var fullHierarchy = parentHierarchy != null ? parentHierarchy.ToString() : null;

                if (string.IsNullOrEmpty(fullHierarchy))
                {
                    return;
                }

                var parentFloc =
                    functionalLocationService.QueryByFullHierarchy(fullHierarchy, siteId);

                GetWorkAssignments(parentFloc, resultingWorkAssignments);
            }
        }

        public bool IsFunctionalLocationOrParentWithinWorkAssignment(
            WorkAssignment workAssignment, FunctionalLocation functionalLocation)
        {
            var results = new List<AssignmentFlocConfiguration>();
            GetWorkAssignments(functionalLocation, results);

            if (results.Exists(wa => wa.WorkAssignmentId == workAssignment.IdValue))
            {
                return true;
            }

            return false;
        }
    }
}