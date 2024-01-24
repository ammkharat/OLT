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
    public class PriorityPageMudsTemporaryInstallationsSectionPresenter :
        PriorityPageSectionPresenter<TemporaryInstallationsMudsDTO, BaseEdmontonForm>
    {
        private readonly IFormEdmontonService formService;
        private readonly bool shouldShowSection;
        private readonly MudsTemporaryInstallationsTimerManager timerManager;

        public PriorityPageMudsTemporaryInstallationsSectionPresenter(IPage invokeControl,
            PriorityPageTree tree,
            IAuthorized authorized,
            UserContext userContext,
            IRemoteEventRepeater remoteEventRepeater,
            IFormEdmontonService formService,
            PriorityPageSectionConfiguration sectionConfiguration)
            : base(invokeControl, tree, userContext, remoteEventRepeater, sectionConfiguration)
        {
            this.formService = formService;
            shouldShowSection = authorized.ToViewMudsTemporaryInstallationsOnPrioritiesPage(userContext.UserRoleElements);
            timerManager = new MudsTemporaryInstallationsTimerManager();
            this.invokeControl.Disposed += InvokeControlOnDisposed;
            if (shouldShowSection)
            {
                AddSectionNode(PriorityPageSectionKey.MudsTemporaryInstallations);
                AddCriteriaBasedSubSectionNode(StringResources.PriorityPage_MudsTemporaryInstallationsSubSectionActive,
                    new MudsTemporaryInstallationActiveSectionCriteria());
                AddCriteriaBasedSubSectionNode(
                    StringResources.PriorityPage_MudsTemporaryInstallationsSubSectionRequiresApproval,
                    new MudsTemporaryInstallationRequiredApprovalSectionCriteria());
                /* RITM0310589 : commemted by Vibhor
                AddCriteriaBasedSubSectionNode(StringResources.PriorityPage_MudsTemporaryInstallationsSubSectionExpired,
                    new MudsTemporaryInstallationExpiredSectionCriteria());
                AddCriteriaBasedSubSectionNode(
                    StringResources.PriorityPage_MudsTemporaryInstallationsSubSectionRecentlyClosed,
                    new MudsTemporaryInstallationRecentlyClosedSectionCriteria());
                 */

                remoteEventRepeater.ServerMudsTemporaryInstallationsFormCreated += HandleRepeaterCreated;
                remoteEventRepeater.ServerMudsTemporaryInstallationsFormUpdated += HandleRepeaterUpdated;
                remoteEventRepeater.ServerMudsTemporaryInstallationsFormRemoved += HandleRepeaterRemoved;
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
            if (e.SelectedItem is TemporaryInstallationsMUDS)
            {
                var temporaryInstallationsMuds = e.SelectedItem as TemporaryInstallationsMUDS;
                var dto = temporaryInstallationsMuds.CreateDTO() as TemporaryInstallationsMudsDTO;
                RegisterRenderTimer(dto);
            }
            Repeater_Created(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        private void HandleRepeaterUpdated<T>(object sender, DomainEventArgs<T> e) where T : BaseEdmontonForm
        {
            if (e.SelectedItem is TemporaryInstallationsMUDS)
            {
                var temporaryInstallationsMudsForm = e.SelectedItem as TemporaryInstallationsMUDS;
                var dto = temporaryInstallationsMudsForm.CreateDTO() as TemporaryInstallationsMudsDTO;
                RegisterRenderTimer(dto);
            }

            Repeater_Updated(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        private void HandleRepeaterRemoved<T>(object sender, DomainEventArgs<T> e) where T : BaseEdmontonForm
        {
            Repeater_Removed(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        public List<TemporaryInstallationsMudsDTO> QueryDtos()
        {
            if (!shouldShowSection)
            {
                return new List<TemporaryInstallationsMudsDTO>();
            }

            var dtos = formService.QueryMudsTemporaryInstallationsThatAreApprovedByFunctionalLocations(userContext.RootFlocSet,
                Clock.Now.SubtractDays(1));
            return dtos;
        }

        public void LoadDtos(List<TemporaryInstallationsMudsDTO> dtos)
        {
            dtos.ForEach(RegisterRenderTimer);
            Load(dtos);
        }

        protected override void UnsubscribeToEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerMudsTemporaryInstallationsFormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerMudsTemporaryInstallationsFormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerMudsTemporaryInstallationsFormRemoved -= HandleRepeaterRemoved;
            invokeControl.Disposed -= InvokeControlOnDisposed;
        }

        protected override bool IsRelevantItemFromServerEvent(BaseEdmontonForm item)
        {
            if (!(item is TemporaryInstallationsMUDS)) return false;

            //// Active drafts that have been closed and were never approved should return false so they are removed from 
            //// the "Active CSDs requiring approval" section of the CSDs on the priority page.
            //var isClosedAndNeverApproved = (item as TemporaryInstallationsMUDS).IsClosedAndNeverApproved;
            //if (isClosedAndNeverApproved) return false;

            //var isApproved = item.FormStatus == FormStatus.Approved;
            //var isClosed = item.FormStatus == FormStatus.Closed;
            //var isActiveAndRequiresApproval = (item as TemporaryInstallationsMUDS).IsActiveAndRequiresApproval(Clock.Now);

            //return isApproved || isClosed || isActiveAndRequiresApproval;

            return item.FormStatus == FormStatus.Approved ||
                   (item as TemporaryInstallationsMUDS).IsActiveAndRequiresApproval(Clock.Now);

        }

        protected override TemporaryInstallationsMudsDTO GetDto(BaseEdmontonForm item,string ForAddUpdate)   //ayman action item reading
        {
            return (TemporaryInstallationsMudsDTO)item.CreateDTO();
        }


        protected override NodeData GetNodeData(TemporaryInstallationsMudsDTO dto)
        {
            return new MudsTemporaryInstallationsNodeData(dto);
        }


        private void RegisterRenderTimer(TemporaryInstallationsMudsDTO dto)
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

        private void SetupTimerCallback(TimeSpan differenceInTime, TemporaryInstallationsMudsDTO dto)
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
                invokeControl.Invoke(new Action<TemporaryInstallationsMudsDTO>(RefreshItem), dto);
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
                if (!(dto is TemporaryInstallationsMudsDTO)) return;
                var item = (TemporaryInstallationsMudsDTO)dto;
                RegisterRenderTimer(item);
                Remove(item);
                Add(item);
            }
        }

        private class MudsTemporaryInstallationActiveSectionCriteria : ISubSectionCriteria
        {
            public bool Matches(TemporaryInstallationsMudsDTO dto)
            {
                return dto.ValidTo > Clock.Now && dto.Status == FormStatus.Approved;

            }
        }

        private class MudsTemporaryInstallationExpiredSectionCriteria : ISubSectionCriteria
        {
            public bool Matches(TemporaryInstallationsMudsDTO dto)
            {
                //if (dto.ValidTo < Clock.Now && dto.Status != FormStatus.Closed)
                //    return true;

                return dto.Status == FormStatus.Expired;
            }
        }

        private class MudsTemporaryInstallationRecentlyClosedSectionCriteria : ISubSectionCriteria
        {
            // Only shows CSDs that where at one point fully approved and have since closed over the last 3 days
            public bool Matches(TemporaryInstallationsMudsDTO dto)
            {
                var hasBeenApproved = dto.HasBeenApproved;
                var closedOverTheLast3Days = dto.ClosedDateTime > Clock.Now.SubtractDays(3) &&
                                             dto.ClosedDateTime < Clock.Now && dto.Status == FormStatus.Closed;

                return hasBeenApproved && closedOverTheLast3Days;
            }
        }

        private class MudsTemporaryInstallationRequiredApprovalSectionCriteria : ISubSectionCriteria
        {
            public bool Matches(TemporaryInstallationsMudsDTO dto)
            {
                return dto.ValidTo > Clock.Now && dto.Status == FormStatus.WaitingForApproval;
            }
        }
    }
}