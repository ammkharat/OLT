using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Domain
{
    public class UserLoginSelections
    {
        private readonly WorkAssignment workAssignment;
        private readonly List<FunctionalLocation> selectedFlocs;
        private readonly List<long> readableVisibilityGroupIds;

        public UserLoginSelections(WorkAssignment workAssignment, List<FunctionalLocation> selectedFlocs, List<long> readableVisibilityGroupIds)
        {
            this.workAssignment = workAssignment;
            this.selectedFlocs = selectedFlocs;
            this.readableVisibilityGroupIds = readableVisibilityGroupIds;
        }

        public List<long> ReadableVisibilityGroupIds
        {
            get { return readableVisibilityGroupIds; }
        }

        public List<FunctionalLocation> SelectedFlocs
        {
            get { return selectedFlocs; }
        }

        public WorkAssignment WorkAssignment
        {
            get { return workAssignment; }
        }
    }

}
