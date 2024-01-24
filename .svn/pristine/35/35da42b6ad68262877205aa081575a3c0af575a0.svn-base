using System;
using System.Collections.Generic;
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
    public class PriorityPageLubesCsdSectionPresenter :
        PriorityPageSectionPresenter<LubesCsdFormDTO, BaseEdmontonForm>
    {
        private readonly IFormEdmontonService formService;
        private readonly bool shouldShowSection;
        private readonly LubesCsdTimerManager timerManager;

        public PriorityPageLubesCsdSectionPresenter(IPage invokeControl,
            PriorityPageTree tree,
            IAuthorized authorized,
            UserContext userContext,
            IRemoteEventRepeater remoteEventRepeater,
            IFormEdmontonService formService,
            PriorityPageSectionConfiguration sectionConfiguration)
            : base(invokeControl, tree, userContext, remoteEventRepeater, sectionConfiguration)
        {
            this.formService = formService;
            shouldShowSection = authorized.ToViewLubeCsdsOnPrioritiesPage(userContext.UserRoleElements);
            timerManager = new LubesCsdTimerManager();

            this.invokeControl.Disposed += InvokeControlOnDisposed;
            if (shouldShowSection)
            {
                AddSectionNode(PriorityPageSectionKey.LubesCsd);
                AddCriteriaBasedSubSectionNode(StringResources.PriorityPage_LubesCsdSubSectionActive,
                    new LubesCsdActiveCSDSectionCriteria());
                AddCriteriaBasedSubSectionNode(StringResources.PriorityPage_LubesCsdSubSectionRequiresApproval,
                    new LubesCsdRequiredApprovalSectionCriteria());
                AddCriteriaBasedSubSectionNode(StringResources.PriorityPage_LubesCsdSubSectionExpired,
                    new LubesCsdExpiredSectionCriteria());

                remoteEventRepeater.ServerLubesCsdFormCreated += HandleRepeaterCreated;
                remoteEventRepeater.ServerLubesCsdFormUpdated += HandleRepeaterUpdated;
                remoteEventRepeater.ServerLubesCsdFormRemoved += HandleRepeaterRemoved;
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
            if (e.SelectedItem is LubesCsdForm)
            {
                var lubesCsdForm = e.SelectedItem as LubesCsdForm;
                var dto = lubesCsdForm.CreateDTO() as LubesCsdFormDTO;
                RegisterRenderTimer(dto);
            }
            Repeater_Created(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        private void HandleRepeaterUpdated<T>(object sender, DomainEventArgs<T> e) where T : BaseEdmontonForm
        {
            if (e.SelectedItem is LubesCsdForm)
            {
                var lubesCsdForm = e.SelectedItem as LubesCsdForm;
                var dto = lubesCsdForm.CreateDTO() as LubesCsdFormDTO;
                RegisterRenderTimer(dto);
            }

            Repeater_Updated(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        private void HandleRepeaterRemoved<T>(object sender, DomainEventArgs<T> e) where T : BaseEdmontonForm
        {
            Repeater_Removed(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        public List<LubesCsdFormDTO> QueryDtos()
        {
            if (!shouldShowSection)
            {
                return new List<LubesCsdFormDTO>();
            }

            List<LubesCsdFormDTO> dtos = formService.QueryFormLubesCsdsThatAreApprovedByFunctionalLocations(userContext.RootFlocSet, Clock.Now.SubtractDays(1));
            return dtos;
        }

        public void LoadDtos(List<LubesCsdFormDTO> dtos)
        {
            dtos.ForEach(RegisterRenderTimer);
            dtos.RemoveAll(dto => dto.Status == FormStatus.Closed);
            Load(dtos);
        }

        protected override void UnsubscribeToEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerLubesCsdFormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerLubesCsdFormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerLubesCsdFormRemoved -= HandleRepeaterRemoved;
            invokeControl.Disposed -= InvokeControlOnDisposed;
        }

        protected override bool IsRelevantItemFromServerEvent(BaseEdmontonForm item)
        {
            if (!(item is LubesCsdForm)) return false;
            return item.FormStatus == FormStatus.Approved ||
                   (item as LubesCsdForm).IsActiveAndRequiresApproval(Clock.Now);
        }

        protected override LubesCsdFormDTO GetDto(BaseEdmontonForm item,string ForAddUpdate)      //ayman action item reading
        {
            return (LubesCsdFormDTO) item.CreateDTO();
        }


        protected override NodeData GetNodeData(LubesCsdFormDTO dto)
        {
            return new LubesCsdNodeData(dto);
        }


        private void RegisterRenderTimer(LubesCsdFormDTO dto)
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

        private void SetupTimerCallback(TimeSpan differenceInTime, LubesCsdFormDTO dto)
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
                invokeControl.Invoke(new Action<LubesCsdFormDTO>(RefreshItem), dto);
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
                if (!(dto is LubesCsdFormDTO)) return;
                var item = (LubesCsdFormDTO) dto;
                RegisterRenderTimer(item);
                Remove(item);
                Add(item);
            }
        }

        private class LubesCsdActiveCSDSectionCriteria : ISubSectionCriteria
        {
            public bool Matches(LubesCsdFormDTO dto)
            {
                return dto.ValidTo > Clock.Now && dto.Status == FormStatus.Approved;
            }
        }

        private class LubesCsdExpiredSectionCriteria : ISubSectionCriteria
        {
            public bool Matches(LubesCsdFormDTO dto)
            {
                return dto.Status == FormStatus.Expired;
            }
        }

        private class LubesCsdRequiredApprovalSectionCriteria : ISubSectionCriteria
        {
            public bool Matches(LubesCsdFormDTO dto)
            {
                return dto.ValidFrom < Clock.Now && dto.ValidTo > Clock.Now && dto.Status == FormStatus.Draft;
            }
        }
    }
}