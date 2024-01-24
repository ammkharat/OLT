using System.Collections.Generic;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class SubmitPermitRequestFortHillsFormPresenter : SubmitPermitRequestWithGroupsOptionFormPresenter<PermitRequestFortHillsDTO>
    {
        private readonly IWorkPermitFortHillsService workPermitService;
        private readonly IPermitRequestFortHillsService permitRequestService;

        public SubmitPermitRequestFortHillsFormPresenter(List<PermitRequestFortHillsDTO> requests, SubmitPermitRequests<PermitRequestFortHillsDTO> submitPermitRequests, CheckPermitRequestAssociationAlreadyExists<PermitRequestFortHillsDTO> checkPermitRequestAssociationAlreadyExists, bool selectedPermitRequestsOnlyMode) : base(requests, submitPermitRequests, checkPermitRequestAssociationAlreadyExists, selectedPermitRequestsOnlyMode)
        {
            workPermitService = ClientServiceRegistry.Instance.GetService<IWorkPermitFortHillsService>();
            permitRequestService = ClientServiceRegistry.Instance.GetService<IPermitRequestFortHillsService>();
        }

        protected override List<IWorkPermitGroup> QueryAllGroups()
        {
            return workPermitService.QueryAllGroups().ConvertAll(group => (IWorkPermitGroup) group);
        }

        protected override List<PermitRequestFortHillsDTO> QueryPermitRequestsByCompletenessAndGroupAndDateWithinRange(List<PermitRequestCompletionStatus> completionStatuses, long groupId, Date date)
        {
            return permitRequestService.QueryByCompletenessAndGroupAndDateWithinRange(new List<PermitRequestCompletionStatus> { PermitRequestCompletionStatus.Complete, PermitRequestCompletionStatus.ForReview }, view.Group.Id.Value, view.Date);
        }
    }
}