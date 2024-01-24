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
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters.Page
{
    public class PriorityPageProcedureDeviationSectionPresenter :
        PriorityPageSectionPresenter<ProcedureDeviationDTO, BaseEdmontonForm>
    {
        private readonly IFormEdmontonService formService;
        private readonly bool shouldShowSection;
        private readonly ProcedureDeviationTimerManager timerManager;

        public PriorityPageProcedureDeviationSectionPresenter(IPage invokeControl,
            PriorityPageTree tree,
            IAuthorized authorized,
            UserContext userContext,
            IRemoteEventRepeater remoteEventRepeater,
            IFormEdmontonService formService,
            PriorityPageSectionConfiguration sectionConfiguration)
            : base(invokeControl, tree, userContext, remoteEventRepeater, sectionConfiguration)
        {
            this.formService = formService;
            shouldShowSection = authorized.ToViewProcedureDeviationOnPrioritiesPage(userContext.UserRoleElements,
                userContext.SiteId);
            timerManager = new ProcedureDeviationTimerManager();

            this.invokeControl.Disposed += InvokeControlOnDisposed;
            if (shouldShowSection)
            {
                AddSectionNode(PriorityPageSectionKey.ProcedureDeviation);

                AddCriteriaBasedSubSectionNode(
                    StringResources.PriorityPage_ProcedureDeviationSubSectionRevisionInProgress,
                    new ProcedureDeviationRevisionInProgressSectionCriteria());
                AddCriteriaBasedSubSectionNode(StringResources.PriorityPage_ProcedureDeviationSubSectionApproved,
                    new ProcedureDeviationApprovedSectionCriteria());
                AddCriteriaBasedSubSectionNode(
                    StringResources.PriorityPage_ProcedureDeviationSubSectionRecentlyCompleted,
                    new ProcedureDeviationRecentlyCompletedSectionCriteria());

                remoteEventRepeater.ServerProcedureDeviationFormCreated += HandleRepeaterCreated;
                remoteEventRepeater.ServerProcedureDeviationFormUpdated += HandleRepeaterUpdated;
                remoteEventRepeater.ServerProcedureDeviationFormRemoved += HandleRepeaterRemoved;
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
            if (e.SelectedItem is ProcedureDeviation)
            {
                var procedureDeviation = e.SelectedItem as ProcedureDeviation;
                var dto = procedureDeviation.CreateDTO() as ProcedureDeviationDTO;
                RegisterRenderTimer(dto);
            }

            Repeater_Created(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        private void HandleRepeaterUpdated<T>(object sender, DomainEventArgs<T> e) where T : BaseEdmontonForm
        {
            if (e.SelectedItem is ProcedureDeviation)
            {
                var procedureDeviation = e.SelectedItem as ProcedureDeviation;
                var dto = procedureDeviation.CreateDTO() as ProcedureDeviationDTO;
                RegisterRenderTimer(dto);
            }

            Repeater_Updated(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        private void HandleRepeaterRemoved<T>(object sender, DomainEventArgs<T> e) where T : BaseEdmontonForm
        {
            Repeater_Removed(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        public List<ProcedureDeviationDTO> QueryDtos()
        {
            if (!shouldShowSection)
            {
                return new List<ProcedureDeviationDTO>();
            }

            var daysToDisplayProcedureDeviationFormsBackwardsOnPriorityPage =
                userContext.SiteConfiguration.DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage;

            var now = Clock.Now.SubtractDays(daysToDisplayProcedureDeviationFormsBackwardsOnPriorityPage);

            var dtos =
                formService.QueryProcedureDeviationsByFunctionalLocations(userContext.RootFlocSet, now,
                    userContext.User.IdValue);
            return dtos;
        }

        public void LoadDtos(List<ProcedureDeviationDTO> dtos)
        {
            dtos.ForEach(RegisterRenderTimer);
            dtos.RemoveAll(dto => dto.Status == FormStatus.Closed);
            Load(dtos);
        }

        protected override void UnsubscribeToEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerProcedureDeviationFormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerProcedureDeviationFormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerProcedureDeviationFormRemoved -= HandleRepeaterRemoved;
            invokeControl.Disposed -= InvokeControlOnDisposed;
        }

        protected override bool IsRelevantItemFromServerEvent(BaseEdmontonForm item)
        {
            if (!(item is ProcedureDeviation)) return false;

            return item.FormStatus == FormStatus.RevisionInProgress ||
                   item.FormStatus == FormStatus.Approved ||
                   item.FormStatus == FormStatus.ExtensionReview ||
                   item.FormStatus == FormStatus.Expired ||
                   item.FormStatus == FormStatus.Complete ||
                   item.FormStatus == FormStatus.Cancelled;
        }

        protected override ProcedureDeviationDTO GetDto(BaseEdmontonForm item,string ForAddUpdate)    //ayman action item reading
        {
            return (ProcedureDeviationDTO) item.CreateDTO();
        }

        protected override NodeData GetNodeData(ProcedureDeviationDTO dto)
        {
            return new ProcedureDeviationNodeData(dto);
        }

        private void RegisterRenderTimer(ProcedureDeviationDTO dto)
        {
            timerManager.Unregister(dto);
            var now = Clock.Now;

            // forms that are draft, extension review, expired, or in a final state will never auto change their status
            if (dto.Status == FormStatus.Draft || dto.IsExtensionReview(now) || dto.IsExpired(now) || dto.IsComplete()) return;

            if (dto.ValidFrom > now)
            {
                var timeUntilActive = dto.ValidFrom.Subtract(now);
                SetupTimerCallback(timeUntilActive, dto);
            }
            else
            {
                var earliestExtensionReviewOrExpiredDate = dto.EarliestDateToExtensionReviewOrExpired(now);
                var timeUntilExtensionReviewOrExpired = earliestExtensionReviewOrExpiredDate.Subtract(now);
                SetupTimerCallback(timeUntilExtensionReviewOrExpired, dto);
            }
        }

        private void SetupTimerCallback(TimeSpan differenceInTime, ProcedureDeviationDTO dto)
        {
            var timeRemainingInShift = ClientSession.GetInstance().GetTimeRemainingInShiftWithPostShiftPadding();
            if ((differenceInTime.Ticks > 0 && (differenceInTime < timeRemainingInShift)))
            {
                SetupTimerForCallback(dto, differenceInTime);
            }
        }

        private void SetupTimerForCallback(ProcedureDeviationDTO dto, TimeSpan differenceInTime)
        {
            try
            {
                timerManager.RegisterTimer(dto, differenceInTime, HandleTimerFire);
            }
            catch (TimerDueTimeNegativeException)
            {
            }
        }

        private void HandleTimerFire(object dto)
        {
            if (invokeControl.IsOnNonUiThread())
            {
                invokeControl.Invoke(new Action<ProcedureDeviationDTO>(RefreshItem), dto);
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
                if (!(dto is ProcedureDeviationDTO)) return;
                var item = (ProcedureDeviationDTO) dto;
                RegisterRenderTimer(item);
                Remove(item);
                Add(item);
            }
        }

        private class ProcedureDeviationApprovedSectionCriteria : ISubSectionCriteria
        {
            public bool Matches(ProcedureDeviationDTO dto)
            {
                return dto.Status == FormStatus.Approved;
            }
        }

        private class ProcedureDeviationRecentlyCompletedSectionCriteria : ISubSectionCriteria
        {
            public bool Matches(ProcedureDeviationDTO dto)
            {
                return dto.IsComplete();
            }
        }

        private class ProcedureDeviationRevisionInProgressSectionCriteria : ISubSectionCriteria
        {
            public bool Matches(ProcedureDeviationDTO dto)
            {
                return dto.Status == FormStatus.RevisionInProgress;
            }
        }
    }
}