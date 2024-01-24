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
    public class PriorityPageDocumentSuggestionSectionPresenter :
        PriorityPageSectionPresenter<DocumentSuggestionDTO, BaseEdmontonForm>
    {
        private readonly IFormEdmontonService formService;
        private readonly bool shouldShowSection;
        private readonly DocumentSuggestionTimerManager timerManager;

        public PriorityPageDocumentSuggestionSectionPresenter(IPage invokeControl,
            PriorityPageTree tree,
            IAuthorized authorized,
            UserContext userContext,
            IRemoteEventRepeater remoteEventRepeater,
            IFormEdmontonService formService,
            PriorityPageSectionConfiguration sectionConfiguration)
            : base(invokeControl, tree, userContext, remoteEventRepeater, sectionConfiguration)
        {
            this.formService = formService;
            shouldShowSection = authorized.ToViewDocumentSuggestionOnPrioritiesPage(userContext.UserRoleElements,
                userContext.SiteId);
            timerManager = new DocumentSuggestionTimerManager();

            this.invokeControl.Disposed += InvokeControlOnDisposed;
            if (shouldShowSection)
            {
                AddSectionNode(PriorityPageSectionKey.DocumentSuggestion);

                AddCriteriaBasedSubSectionNode(StringResources.PriorityPage_DocumentSuggestionSubSectionInitialReview,
                    new DocumentSuggestionInitialReviewSectionCriteria());
                AddCriteriaBasedSubSectionNode(StringResources.PriorityPage_DocumentSuggestionSubSectionOwnerReview,
                    new DocumentSuggestionOwnerReviewSectionCriteria());
                AddCriteriaBasedSubSectionNode(StringResources.PriorityPage_DocumentSuggestionSubSectionRevisionInProgress,
                    new DocumentSuggestionRevisionInProgressSectionCriteria());
                AddCriteriaBasedSubSectionNode(StringResources.PriorityPage_DocumentSuggestionSubSectionRecentlyCompleted,
                    new DocumentSuggestionRecentlyCompletedSectionCriteria());

                remoteEventRepeater.ServerDocumentSuggestionFormCreated += HandleRepeaterCreated;
                remoteEventRepeater.ServerDocumentSuggestionFormUpdated += HandleRepeaterUpdated;
                remoteEventRepeater.ServerDocumentSuggestionFormRemoved += HandleRepeaterRemoved;
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
            if (e.SelectedItem is DocumentSuggestion)
            {
                var documentSuggestion = e.SelectedItem as DocumentSuggestion;
                var dto = documentSuggestion.CreateDTO() as DocumentSuggestionDTO;
                RegisterRenderTimer(dto);
            }

            Repeater_Created(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        private void HandleRepeaterUpdated<T>(object sender, DomainEventArgs<T> e) where T : BaseEdmontonForm
        {
            if (e.SelectedItem is DocumentSuggestion)
            {
                var documentSuggestion = e.SelectedItem as DocumentSuggestion;
                var dto = documentSuggestion.CreateDTO() as DocumentSuggestionDTO;
                RegisterRenderTimer(dto);
            }

            Repeater_Updated(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        private void HandleRepeaterRemoved<T>(object sender, DomainEventArgs<T> e) where T : BaseEdmontonForm
        {
            Repeater_Removed(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        public List<DocumentSuggestionDTO> QueryDtos()
        {
            if (!shouldShowSection)
            {
                return new List<DocumentSuggestionDTO>();
            }

            var daysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage =
                userContext.SiteConfiguration.DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage;

            DateTime now = Clock.Now.SubtractDays(daysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage);

            List<DocumentSuggestionDTO> dtos =
                formService.QueryDocumentSuggestionsByFunctionalLocations(userContext.RootFlocSet, now, userContext.User.IdValue);
            return dtos;
        }

        public void LoadDtos(List<DocumentSuggestionDTO> dtos)
        {
            dtos.ForEach(RegisterRenderTimer);
            dtos.RemoveAll(dto => dto.Status == FormStatus.Closed);
            Load(dtos);
        }

        protected override void UnsubscribeToEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerDocumentSuggestionFormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerDocumentSuggestionFormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerDocumentSuggestionFormRemoved -= HandleRepeaterRemoved;
            invokeControl.Disposed -= InvokeControlOnDisposed;
        }

        protected override bool IsRelevantItemFromServerEvent(BaseEdmontonForm item)
        {
            if (!(item is DocumentSuggestion)) return false;

            return item.FormStatus == FormStatus.InitialReview ||
                   item.FormStatus == FormStatus.OwnerReview ||
                   item.FormStatus == FormStatus.RevisionInProgress ||
                   item.FormStatus == FormStatus.DocumentIssued ||
                   item.FormStatus == FormStatus.DocumentArchived ||
                   item.FormStatus == FormStatus.NotApproved;
        }

        protected override DocumentSuggestionDTO GetDto(BaseEdmontonForm item,string ForAddUpdate)      //ayman action item reading
        {
            return (DocumentSuggestionDTO) item.CreateDTO();
        }

        protected override NodeData GetNodeData(DocumentSuggestionDTO dto)
        {
            return new DocumentSuggestionNodeData(dto);
        }

        private void RegisterRenderTimer(DocumentSuggestionDTO dto)
        {
            timerManager.Unregister(dto);
            var now = Clock.Now;

            // forms that are draft, late, or in a final state will never auto change their status
            if (dto.Status == FormStatus.Draft || dto.IsLate(now) || dto.IsComplete()) return;

            if (dto.ValidFrom > now)
            {
                var timeUntilActive = dto.ValidFrom.Subtract(now);
                SetupTimerCallback(timeUntilActive, dto);
            }
            else
            {
                var timeUntilLate = dto.LatestCompletionDate.Subtract(now);
                SetupTimerCallback(timeUntilLate, dto);
            }
        }

        private void SetupTimerCallback(TimeSpan differenceInTime, DocumentSuggestionDTO dto)
        {
            var timeRemainingInShift = ClientSession.GetInstance().GetTimeRemainingInShiftWithPostShiftPadding();
            if ((differenceInTime.Ticks > 0 && (differenceInTime < timeRemainingInShift)))
            {
                SetupTimerForCallback(dto, differenceInTime);
            }
        }

        private void SetupTimerForCallback(DocumentSuggestionDTO dto, TimeSpan differenceInTime)
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
                invokeControl.Invoke(new Action<DocumentSuggestionDTO>(RefreshItem), dto);
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
                if (!(dto is DocumentSuggestionDTO)) return;
                var item = (DocumentSuggestionDTO) dto;
                RegisterRenderTimer(item);
                Remove(item);
                Add(item);
            }
        }

        private class DocumentSuggestionInitialReviewSectionCriteria : ISubSectionCriteria
        {
            public bool Matches(DocumentSuggestionDTO dto)
            {
                return dto.Status == FormStatus.InitialReview;
            }
        }

        private class DocumentSuggestionOwnerReviewSectionCriteria : ISubSectionCriteria
        {
            public bool Matches(DocumentSuggestionDTO dto)
            {
                return dto.Status == FormStatus.OwnerReview;
            }
        }

        private class DocumentSuggestionRecentlyCompletedSectionCriteria : ISubSectionCriteria
        {
            public bool Matches(DocumentSuggestionDTO dto)
            {
                return dto.Status == FormStatus.DocumentIssued ||
                       dto.Status == FormStatus.DocumentArchived ||
                       dto.Status == FormStatus.NotApproved;
            }
        }

        private class DocumentSuggestionRevisionInProgressSectionCriteria : ISubSectionCriteria
        {
            public bool Matches(DocumentSuggestionDTO dto)
            {
                return dto.Status == FormStatus.RevisionInProgress;
            }
        }
    }
}