using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ISubmitPermitRequestWithGroupsOptionFormView : ISubmitPermitRequestFormView
    {
        event Action GroupSelectionChanged;

        List<IWorkPermitGroup> AllGroups { set; }
        IWorkPermitGroup Group { get; }
        bool SubmitAllCompletedPermitRequestsForASpecificGroup { get; }
        bool SubmitOnlySelectedPermitRequests { get; }
        bool GroupSelectionEnabled { set; }
        event Action SubmissionTypeChanged;
        void DisableAllCompletedPermitRequestsOption();
        void SetErrorForNoCompletedPermitRequestsFound();
    }
}
