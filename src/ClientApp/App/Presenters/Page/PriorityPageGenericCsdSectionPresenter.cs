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
    public class PriorityPageGenericCsdSectionPresenter :
        PriorityPageSectionPresenter<GenericCsdDTO, BaseEdmontonForm>
    {
        private readonly IFormEdmontonService formService;
        private readonly bool shouldShowSection;
        private readonly GenericCsdTimerManager timerManager;

        public PriorityPageGenericCsdSectionPresenter(IPage invokeControl,
            PriorityPageTree tree,
            IAuthorized authorized,
            UserContext userContext,
            IRemoteEventRepeater remoteEventRepeater,
            IFormEdmontonService formService,
            PriorityPageSectionConfiguration sectionConfiguration)
            : base(invokeControl, tree, userContext, remoteEventRepeater, sectionConfiguration)
        {
            this.formService = formService;
            shouldShowSection = authorized.ToViewMontrealCsdsOnPrioritiesPage(userContext.UserRoleElements);
            timerManager = new GenericCsdTimerManager();

            this.invokeControl.Disposed += InvokeControlOnDisposed;
            if (shouldShowSection)
            {
                AddSectionNode(PriorityPageSectionKey.MontrealCsd);
                AddCriteriaBasedSubSectionNode(StringResources.PriorityPage_MontrealCsdSubSectionActive,
                    new GenericCsdActiveCsdSectionCriteria());
                AddCriteriaBasedSubSectionNode(StringResources.PriorityPage_MontrealCsdSubSectionRequiresApproval,
                    new GenericCsdRequiredApprovalSectionCriteria());
                AddCriteriaBasedSubSectionNode(StringResources.PriorityPage_MontrealCsdSubSectionExpired,
                    new GenericCsdExpiredSectionCriteria());
                AddCriteriaBasedSubSectionNode(StringResources.PriorityPage_MontrealCsdSubSectionRecentlyClosed,
                    new GenericCsdRecentlyClosedSectionCriteria());

                remoteEventRepeater.ServerGenericCsdFormCreated += HandleRepeaterCreated;
                remoteEventRepeater.ServerGenericCsdFormUpdated += HandleRepeaterUpdated;
                remoteEventRepeater.ServerGenericCsdFormRemoved += HandleRepeaterRemoved;
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
            if (e.SelectedItem is GenericCsd)
            {
                var montrealCsd = e.SelectedItem as GenericCsd;
                var dto = montrealCsd.CreateDTO() as GenericCsdDTO;
                RegisterRenderTimer(dto);
            }
            Repeater_Created(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        private void HandleRepeaterUpdated<T>(object sender, DomainEventArgs<T> e) where T : BaseEdmontonForm
        {
            if (e.SelectedItem is GenericCsd)
            {
                var montrealCsdForm = e.SelectedItem as GenericCsd;
                var dto = montrealCsdForm.CreateDTO() as GenericCsdDTO;
                RegisterRenderTimer(dto);
            }

            Repeater_Updated(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        private void HandleRepeaterRemoved<T>(object sender, DomainEventArgs<T> e) where T : BaseEdmontonForm
        {
            Repeater_Removed(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        public List<GenericCsdDTO> QueryDtos()
        {
            if (!shouldShowSection)
            {
                return new List<GenericCsdDTO>();
            }

            var dtos = formService.QueryGenericCsdsThatAreApprovedByFunctionalLocations(userContext.RootFlocSet,
                Clock.Now.SubtractDays(1));
            return dtos;
        }

        public void LoadDtos(List<GenericCsdDTO> dtos)
        {
            dtos.ForEach(RegisterRenderTimer);
            Load(dtos);

        }

        protected override void UnsubscribeToEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerGenericCsdFormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerGenericCsdFormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerGenericCsdFormRemoved -= HandleRepeaterRemoved;
            invokeControl.Disposed -= InvokeControlOnDisposed;
        }

        protected override bool IsRelevantItemFromServerEvent(BaseEdmontonForm item)
        {
            if (!(item is GenericCsd)) return false;

            // Active drafts that have been closed and were never approved should return false so they are removed from 
            // the "Active CSDs requiring approval" section of the CSDs on the priority page.
            var isClosedAndNeverApproved = (item as GenericCsd).IsClosedAndNeverApproved;
            if (isClosedAndNeverApproved) return false;

            var isApproved = item.FormStatus == FormStatus.Approved;
            var isClosed = item.FormStatus == FormStatus.Closed;
            var isActiveAndRequiresApproval = (item as GenericCsd).IsActiveAndRequiresApproval(Clock.Now);


            return isApproved || isClosed || isActiveAndRequiresApproval;
        }

        protected override GenericCsdDTO GetDto(BaseEdmontonForm item, string ForAddUpdate)   //ayman action item reading
        {
            return (GenericCsdDTO)item.CreateDTO();
        }


        protected override NodeData GetNodeData(GenericCsdDTO dto)
        {
            return new GenericCsdNodeData(dto);
        }


        private void RegisterRenderTimer(GenericCsdDTO dto)
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

        private void SetupTimerCallback(TimeSpan differenceInTime, GenericCsdDTO dto)
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
                invokeControl.Invoke(new Action<GenericCsdDTO>(RefreshItem), dto);
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
                if (!(dto is GenericCsdDTO)) return;
                var item = (GenericCsdDTO)dto;
                RegisterRenderTimer(item);
                Remove(item);
                Add(item);
            }
        }


        //MS: 3664 - Ayman

        private bool IsDirectorAndWithinThe5DaysGracePeriod(GenericCsdDTO dto)
        {

            return (dto.RemainingApprovalsString.ToLower().StartsWith("directeur") && dto.ValidFrom <= Clock.Now &&
                    dto.ValidFrom.AddDays(5) <= Clock.Now);
        }

        private bool IsManagerAndWithinThe3DaysGracePeriod(GenericCsdDTO dto)
        {
            return (dto.RemainingApprovalsString.StartsWith("Manager Opération (> 72 heures)") &&
                    dto.ValidFrom <= Clock.Now && dto.ValidFrom.AddDays(3) <= Clock.Now);
        }



        private class GenericCsdActiveCsdSectionCriteria : ISubSectionCriteria
        {
            public bool Matches(GenericCsdDTO dto)
            {
                //MS: 3664 - Ayman
                var directorAndWithin5Days = false;
                var managerAndWithin3Days = false;

                directorAndWithin5Days = (dto.RemainingApprovalsString.ToLower().StartsWith("directeur") && dto.ValidFrom <= Clock.Now &&
                    dto.ValidFrom.AddDays(5) >= Clock.Now && dto.Status != FormStatus.Closed);

                managerAndWithin3Days =
                    (dto.RemainingApprovalsString.StartsWith("Manager Opération (> 72 heures)") &&
                     dto.ValidFrom <= Clock.Now && dto.ValidFrom.AddDays(3) >= Clock.Now && dto.Status != FormStatus.Closed);

                if (directorAndWithin5Days)
                    return true;
                else if (managerAndWithin3Days)
                    return true;
                else
                return dto.ValidTo > Clock.Now && dto.Status == FormStatus.Approved; 

            }
        }

        private class GenericCsdExpiredSectionCriteria : ISubSectionCriteria
        {
            public bool Matches(GenericCsdDTO dto)
            {
                //MS: 3664 - Ayman

                var directorAndExpired = false;
                var managerAndExpired = false;

                directorAndExpired = (dto.RemainingApprovalsString.ToLower().StartsWith("directeur") && dto.ValidTo < Clock.Now && dto.Status != FormStatus.Closed);
                managerAndExpired = (dto.RemainingApprovalsString.StartsWith("Manager Opération (> 72 heures)") && dto.ValidTo < Clock.Now && dto.Status != FormStatus.Closed);

                if (directorAndExpired)
                    return true;
                else if (managerAndExpired)
                    return true;
                else

                return dto.Status == FormStatus.Expired; 
             
            }
        }

        private class GenericCsdRecentlyClosedSectionCriteria : ISubSectionCriteria
        {
            // Only shows CSDs that where at one point fully approved and have since closed over the last 3 days
            public bool Matches(GenericCsdDTO dto)
            {
                var hasBeenApproved = dto.HasBeenApproved;
                var closedOverTheLast3Days = dto.ClosedDateTime > Clock.Now.SubtractDays(3) &&
                                             dto.ClosedDateTime < Clock.Now && dto.Status == FormStatus.Closed;

                return hasBeenApproved && closedOverTheLast3Days;
            }
        }

        private class GenericCsdRequiredApprovalSectionCriteria : ISubSectionCriteria
        {
            public bool Matches(GenericCsdDTO dto)
            {
                //MS: 3664 - Ayman
                var directorAndWithin5Days = false;
                
                var managerAndWithin3Days = false;

                directorAndWithin5Days = (dto.RemainingApprovalsString.ToLower().StartsWith("directeur") && dto.ValidFrom <= Clock.Now &&
                    dto.ValidFrom.AddDays(5) <= Clock.Now && dto.ApprovedDateTime == null && dto.Status != FormStatus.Closed);

                managerAndWithin3Days = (dto.RemainingApprovalsString.StartsWith("Manager Opération (> 72 heures)") && dto.ValidFrom <= Clock.Now &&
                    dto.ValidFrom.AddDays(5) <= Clock.Now && dto.ApprovedDateTime == null && dto.Status != FormStatus.Closed);

               if (directorAndWithin5Days)
                   return true;
               else if (managerAndWithin3Days)
                   return true;
               else
                    return dto.ValidFrom <= Clock.Now && dto.ValidTo > Clock.Now && dto.Status == FormStatus.Draft && dto.Status != FormStatus.Closed; 
              
            }
        }
    }
}