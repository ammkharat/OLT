using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Client.Controls.GridRenderer.Utilities;
using Com.Suncor.Olt.Client.Controls.Page;
using Com.Suncor.Olt.Client.Domain.PriorityPage;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class PriorityPageFormGenericTemplateSectionPresenter :
        PriorityPageSectionPresenter<FormGenericTemplateDTO, BaseEdmontonForm>
    {
        private readonly IFormEdmontonService formService;
        private readonly bool shouldShowSection;
        private readonly GenericTemplateFormTimerManager timerManager;

        public PriorityPageFormGenericTemplateSectionPresenter(IPage invokeControl,
            PriorityPageTree tree,
            IAuthorized authorized,
            UserContext userContext,
            IRemoteEventRepeater remoteEventRepeater,
            IFormEdmontonService formService,
            PriorityPageSectionConfiguration sectionConfiguration)
            : base(invokeControl, tree, userContext, remoteEventRepeater, sectionConfiguration)
        {
            this.formService = formService;
            shouldShowSection = authorized.ToViewFormOP14sOnPrioritiesPage(userContext.UserRoleElements);
            timerManager = new GenericTemplateFormTimerManager();

            this.invokeControl.Disposed += InvokeControlOnDisposed;
            if (shouldShowSection)
            {
                //AddSectionNode(PriorityPageSectionKey.FormOP14);
                //AddCriteriaBasedSubSectionNode(StringResources.PriorityPage_FormsOP14SubSectionActive,
                //    new OP14ActiveCSDSectionCriteria());
                //AddCriteriaBasedSubSectionNode(StringResources.PriorityPage_FormsOP14SubSectionRequiresApproval,
                //    new OP14RequiredApprovalSectionCriteria());
                //AddCriteriaBasedSubSectionNode(StringResources.PriorityPage_FormsOP14SubSectionExpired,
                //    new OP14ExpiredSectionCriteria());

                remoteEventRepeater.ServerGenericTemplateFormCreated += HandleRepeaterCreated;
                remoteEventRepeater.ServerGenericTemplateFormUpdated += HandleRepeaterUpdated;
                remoteEventRepeater.ServerGenericTemplateFormRemoved += HandleRepeaterRemoved;
            }
        }

        private void InvokeControlOnDisposed(object sender, EventArgs eventArgs)
        {
            if (timerManager != null)
            {
                timerManager.Clear();
            }
        }

        private void HandleRepeaterCreated<T>(object sender, DomainEventArgs<T> e) where T : BaseEdmontonForm
        {
            if (e.SelectedItem is FormGenericTemplate)
            {
                var formOP14 = e.SelectedItem as FormGenericTemplate;
                var dto = formOP14.CreateDTO() as FormGenericTemplateDTO;
                RegisterRenderTimer(dto);
            }
            Repeater_Created(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        private void HandleRepeaterUpdated<T>(object sender, DomainEventArgs<T> e) where T : BaseEdmontonForm
        {
            if (e.SelectedItem is FormGenericTemplate)
            {
                var formOP14 = e.SelectedItem as FormGenericTemplate;
                var dto = formOP14.CreateDTO() as FormGenericTemplateDTO;
                RegisterRenderTimer(dto);
            }

            Repeater_Updated(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        private void HandleRepeaterRemoved<T>(object sender, DomainEventArgs<T> e) where T : BaseEdmontonForm
        {
            Repeater_Removed(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        //public List<FormGenericTemplateDTO> QueryDtos()
        //{
        //    if (!shouldShowSection)
        //    {
        //        return new List<FormGenericTemplateDTO>();
        //    }

        //    List<FormGenericTemplateDTO> dtos = null;
        //    if (userContext.SiteConfiguration.FormsFlocSetType.Equals(FunctionalLocationSetType.WorkPermit) &&
        //        userContext.HasFlocsForWorkPermits)
        //    //{
        //    //    dtos =
        //    //        formService.QueryFormOP14sThatAreApprovedByFunctionalLocations(
        //    //            userContext.RootFlocSetForWorkPermits,
        //    //            Clock.Now.SubtractDays(1));
        //    //}
        //    //else
        //    //{
        //    //    dtos = formService.QueryFormOP14sThatAreApprovedByFunctionalLocations(userContext.RootFlocSet,
        //    //        Clock.Now.SubtractDays(1)); 
        //    //}
           
        //    return dtos;
        //}

        public void LoadDtos(List<FormGenericTemplateDTO> dtos)
        {
            dtos.ForEach(RegisterRenderTimer);
            dtos.RemoveAll(dto => dto.Status == FormStatus.Closed );
            Load(dtos);
        }

        protected override void UnsubscribeToEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerGenericTemplateFormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerGenericTemplateFormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerGenericTemplateFormRemoved -= HandleRepeaterRemoved;
            invokeControl.Disposed -= InvokeControlOnDisposed;
        }

        protected override bool IsRelevantItemFromServerEvent(BaseEdmontonForm item)
        {
            if (!(item is FormGenericTemplate)) return false;
            return item.FormStatus == FormStatus.Approved ||
                   (item as FormGenericTemplate).IsActiveAndRequiresApproval(Clock.Now);
        }

        protected override FormGenericTemplateDTO GetDto(BaseEdmontonForm item,string ForAddUpdate)     //ayman action item reading
        {
            return (FormGenericTemplateDTO)item.CreateDTO();
        }

        protected override NodeData GetNodeData(FormGenericTemplateDTO dto)
        {
            return new FormGenericTemplateNodeData(dto);
        }

        private void RegisterRenderTimer(FormGenericTemplateDTO dto)
        {
            timerManager.Unregister(dto);
            var now = Clock.Now;

            // this will never auto change its grouping
            if (dto.ValidTo < now) return;

            if (dto.ValidFrom > now)
            {
                var timeUntilActive = dto.ValidFrom.Subtract(now);
                SetupTimerCallback(timeUntilActive, dto);
            }
            else
            {
                var timeUntilRequiresApprovalOrExpires = dto.ValidTo.Subtract(now);
                SetupTimerCallback(timeUntilRequiresApprovalOrExpires, dto);
            }
        }

        private void SetupTimerCallback(TimeSpan differenceInTime, FormGenericTemplateDTO dto)
        {
            var timeRemainingInShift = ClientSession.GetInstance().GetTimeRemainingInShiftWithPostShiftPadding();
            if (differenceInTime < timeRemainingInShift)
            {
                timerManager.RegisterTimer(dto, differenceInTime, HandleTimerFire);
            }
        }

        private void HandleTimerFire(object dto)
        {
            if (invokeControl.IsOnNonUiThread())
            {
                invokeControl.Invoke(new Action<FormGenericTemplateDTO>(RefreshItem), dto);
            }
            else
            {
                RefreshItem(dto);
            }
        }

        private void RefreshItem(object dto)
        {
            if (invokeControl.IsNotDisposed())
            {
                if (!(dto is FormGenericTemplateDTO)) return;
                var item = (FormGenericTemplateDTO)dto;
                RegisterRenderTimer(item);
                Remove(item);
                Add(item);
            }
        }

        private class OP14ActiveCSDSectionCriteria : ISubSectionCriteria
        {
            public bool Matches(FormGenericTemplateDTO dto)
            {
                return dto.ValidTo > Clock.Now && dto.Status == FormStatus.Approved;
            }
        }

        private class OP14ExpiredSectionCriteria : ISubSectionCriteria
        {
            public bool Matches(FormGenericTemplateDTO dto)
            {
                //ayman generic forms

                return dto.Status == FormStatus.Expired;
            }
        }

        private class OP14RequiredApprovalSectionCriteria : ISubSectionCriteria
        {
            public bool Matches(FormGenericTemplateDTO dto)
            {
                return dto.ValidTo > Clock.Now && dto.Status == FormStatus.WaitingForApproval; //FormStatus.Draft;   //ayman generic forms ...fixes...
            }
        }
    }
}