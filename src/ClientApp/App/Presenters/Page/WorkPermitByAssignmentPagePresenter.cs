using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class WorkPermitByAssignmentPagePresenter : WorkPermitPagePresenter
    {
        public WorkPermitByAssignmentPagePresenter() : base(new WorkPermitByAssignmentPage())
        {
        }

        protected override WorkAssignment WorkAssignment
        {
            get { return userContext.Assignment; }
        }

        private static bool HasWorkAssignment(WorkPermit workPermit)
        {
            return workPermit != null && workPermit.WorkAssignment != null;
        }

        protected override bool ShouldBeDisplayed(WorkPermit workPermit)
        {
            return base.ShouldBeDisplayed(workPermit) && HasWorkAssignment(workPermit) && userContext.HasSameAssignment(workPermit.WorkAssignment);
        }

        protected override UserGridLayoutIdentifier GridIdentifier
        {
            get { return UserGridLayoutIdentifier.WorkPermitsByAssignment; }
        }
    }
}