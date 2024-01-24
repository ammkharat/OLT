using System.Collections.Generic;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class SubmitPermitRequestEdmontonFormPresenter : SubmitPermitRequestWithGroupsOptionFormPresenter<PermitRequestEdmontonDTO>
    {
        private readonly IWorkPermitEdmontonService workPermitService;
        private readonly IPermitRequestEdmontonService permitRequestService;

        public SubmitPermitRequestEdmontonFormPresenter(List<PermitRequestEdmontonDTO> requests, SubmitPermitRequests<PermitRequestEdmontonDTO> submitPermitRequests, CheckPermitRequestAssociationAlreadyExists<PermitRequestEdmontonDTO> checkPermitRequestAssociationAlreadyExists, bool selectedPermitRequestsOnlyMode) : base(requests, submitPermitRequests, checkPermitRequestAssociationAlreadyExists, selectedPermitRequestsOnlyMode)
        {
            workPermitService = ClientServiceRegistry.Instance.GetService<IWorkPermitEdmontonService>();
            permitRequestService = ClientServiceRegistry.Instance.GetService<IPermitRequestEdmontonService>();
        }

        protected override List<IWorkPermitGroup> QueryAllGroups()
        {
            return workPermitService.QueryAllGroups().ConvertAll(group => (IWorkPermitGroup) group);
        }

        protected override List<PermitRequestEdmontonDTO> QueryPermitRequestsByCompletenessAndGroupAndDateWithinRange(List<PermitRequestCompletionStatus> completionStatuses, long groupId, Date date)
        {
            return permitRequestService.QueryByCompletenessAndGroupAndDateWithinRange(new List<PermitRequestCompletionStatus> { PermitRequestCompletionStatus.Complete, PermitRequestCompletionStatus.ForReview }, view.Group.Id.Value, view.Date);
        }
    }
}