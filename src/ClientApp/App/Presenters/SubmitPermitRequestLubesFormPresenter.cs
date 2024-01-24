using System.Collections.Generic;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class SubmitPermitRequestLubesFormPresenter : SubmitPermitRequestWithGroupsOptionFormPresenter<PermitRequestLubesDTO>
    {
        private readonly IWorkPermitLubesService workPermitService;
        private readonly IPermitRequestLubesService permitRequestService;

        public SubmitPermitRequestLubesFormPresenter(List<PermitRequestLubesDTO> requests, SubmitPermitRequests<PermitRequestLubesDTO> submitPermitRequests, CheckPermitRequestAssociationAlreadyExists<PermitRequestLubesDTO> checkPermitRequestAssociationAlreadyExists, bool selectedPermitRequestsOnlyMode)
            : base(requests, submitPermitRequests, checkPermitRequestAssociationAlreadyExists, selectedPermitRequestsOnlyMode)
        {
            workPermitService = ClientServiceRegistry.Instance.GetService<IWorkPermitLubesService>();
            permitRequestService = ClientServiceRegistry.Instance.GetService<IPermitRequestLubesService>();
        }

        protected override List<IWorkPermitGroup> QueryAllGroups()
        {
            return workPermitService.QueryAllGroups().ConvertAll(group => (IWorkPermitGroup) group);
        }

        protected override List<PermitRequestLubesDTO> QueryPermitRequestsByCompletenessAndGroupAndDateWithinRange(List<PermitRequestCompletionStatus> completionStatuses, long groupId, Date date)
        {
            return permitRequestService.QueryByCompletenessAndGroupAndDateWithinRange(new List<PermitRequestCompletionStatus> { PermitRequestCompletionStatus.Complete }, view.Group.Id.Value, view.Date);
        }
    }
}