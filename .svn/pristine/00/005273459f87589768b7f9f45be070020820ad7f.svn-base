using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Domain.PriorityPage;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    class PriorityPageMontrealSulphurFormSectionPresenter : PriorityPageSectionPresenter<TemporaryInstallationsMudsDTO, BaseEdmontonForm>
    {
        private readonly IFormEdmontonService formService;
        private readonly bool authorizedToViewForms;
        private readonly bool authorizedToViewOvertimeForms;
        private readonly Range<Date> dateRange;

        public PriorityPageMontrealSulphurFormSectionPresenter(IPage invokeControl, PriorityPageTree tree, IAuthorized authorized,
                                                UserContext userContext,
                                                IRemoteEventRepeater remoteEventRepeater,
                                                IFormEdmontonService formService, 
                                                PriorityPageSectionConfiguration sectionConfiguration)
            : base(invokeControl, tree, userContext, remoteEventRepeater, sectionConfiguration)
        {
            this.formService = formService;
            authorizedToViewForms = authorized.ToApproveOrCloseMudsTemporaryInstallationsForms(userContext.UserRoleElements)
                                    || authorized.ToCreateMudsTemporaryInstallationsForm(userContext.UserRoleElements);
            if (authorizedToViewForms)
            {
                dateRange = new Range<Date>(Clock.DateNow.SubtractDays(userContext.SiteConfiguration.DaysToDisplayFormsBackwardsOnPriorityPage),Date.MaxValue);

                AddSectionNode(PriorityPageSectionKey.EdmontonForm);
                AddCatchAllSubSectionNode(StringResources.PriorityPage_FormsRequireApprovalSubSection);

                remoteEventRepeater.ServerMudsTemporaryInstallationsFormCreated += HandleRepeaterCreated;
                remoteEventRepeater.ServerMudsTemporaryInstallationsFormUpdated += HandleRepeaterUpdated;
                remoteEventRepeater.ServerMudsTemporaryInstallationsFormRemoved += HandleRepeaterRemoved;
            }
        }

        protected override void UnsubscribeToEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerMudsTemporaryInstallationsFormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerMudsTemporaryInstallationsFormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerMudsTemporaryInstallationsFormRemoved -= HandleRepeaterRemoved;
        }

        private void HandleRepeaterCreated<T>(object sender, DomainEventArgs<T> e) where T : BaseEdmontonForm
        {
            Repeater_Created(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        private void HandleRepeaterUpdated<T>(object sender, DomainEventArgs<T> e) where T : BaseEdmontonForm
        {
            Repeater_Updated(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        private void HandleRepeaterRemoved<T>(object sender, DomainEventArgs<T> e) where T : BaseEdmontonForm
        {
            Repeater_Removed(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        public List<TemporaryInstallationsMudsDTO> QueryDtos()
        {
            if (!authorizedToViewForms)
            {
                return new List<TemporaryInstallationsMudsDTO>();
            }

            List<TemporaryInstallationsMudsDTO> dtos = formService.QueryMudsTemporaryInstallationsThatAreApprovedByFunctionalLocations(userContext.RootFlocSet, Clock.Now.SubtractDays(1));
            return dtos;
        }

        public void LoadDtos(List<TemporaryInstallationsMudsDTO> dtos)
        
        {   
            dtos.RemoveAll(dto => (dto.Status == FormStatus.Draft || dto.Status == FormStatus.Expired || dto.Status == FormStatus.Closed || dto.Status == FormStatus.Approved));
            Load(dtos);
        }

        protected override bool IsRelevantItemFromServerEvent(BaseEdmontonForm item)
        {
            return item.FromDateTime.ToDate() <= dateRange.UpperBound &&
                   item.ToDateTime.ToDate() >= dateRange.LowerBound &&
                   item.FormStatus == FormStatus.WaitingForApproval;
        }

        protected override TemporaryInstallationsMudsDTO GetDto(BaseEdmontonForm item,string ForAddUpdate)        //ayman action item reading
        {
            return (TemporaryInstallationsMudsDTO)item.CreateDTO();
        }

        protected override NodeData GetNodeData(TemporaryInstallationsMudsDTO dto)
        {
            return new FormNodeData(dto);
        }
    }

}