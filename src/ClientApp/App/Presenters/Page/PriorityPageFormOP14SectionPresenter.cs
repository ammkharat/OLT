using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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
    public class PriorityPageFormOP14SectionPresenter :
        PriorityPageSectionPresenter<FormEdmontonOP14DTO, BaseEdmontonForm>
    {
        private readonly IFormEdmontonService formService;
        private readonly bool shouldShowSection;
        private readonly OP14TimerManager timerManager;

        public PriorityPageFormOP14SectionPresenter(IPage invokeControl,
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
            timerManager = new OP14TimerManager();

            this.invokeControl.Disposed += InvokeControlOnDisposed;
            if (shouldShowSection)
            {
                if (userContext.IsSelcSite)
                {
                    PriorityPageSectionKey.FormOP14.SectionName = "Active Critical System Defeats";
                }

                //INC0458108 : Added By Vibhor {Sarnia : Remove references to "OP-14" within form labels and menu items}
                if (ClientSession.GetUserContext().Site.Id == Site.SARNIA_ID)
                {
                    AddSectionNode(PriorityPageSectionKey.FormOP14_SarniaSection);
                }
                else
                {
                    AddSectionNode(PriorityPageSectionKey.FormOP14);
                }
                //END
                

                AddCriteriaBasedSubSectionNode(StringResources.PriorityPage_FormsOP14SubSectionActive,
                    new OP14ActiveCSDSectionCriteria());
                AddCriteriaBasedSubSectionNode(StringResources.PriorityPage_FormsOP14SubSectionRequiresApproval,
                    new OP14RequiredApprovalSectionCriteria());
                AddCriteriaBasedSubSectionNode(StringResources.PriorityPage_FormsOP14SubSectionExpired,
                    new OP14ExpiredSectionCriteria());

                remoteEventRepeater.ServerOP14FormCreated += HandleRepeaterCreated;
                remoteEventRepeater.ServerOP14FormUpdated += HandleRepeaterUpdated;
                remoteEventRepeater.ServerOP14FormRemoved += HandleRepeaterRemoved;
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
            if (e.SelectedItem is FormOP14)
            {
                var formOP14 = e.SelectedItem as FormOP14;
                var dto = formOP14.CreateDTO() as FormEdmontonOP14DTO;
                RegisterRenderTimer(dto);
            }
            Repeater_Created(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        private void HandleRepeaterUpdated<T>(object sender, DomainEventArgs<T> e) where T : BaseEdmontonForm
        {
            if (e.SelectedItem is FormOP14)
            {
                var formOP14 = e.SelectedItem as FormOP14;
                var dto = formOP14.CreateDTO() as FormEdmontonOP14DTO;
                RegisterRenderTimer(dto);
            }

            Repeater_Updated(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        private void HandleRepeaterRemoved<T>(object sender, DomainEventArgs<T> e) where T : BaseEdmontonForm
        {
            Repeater_Removed(sender, new DomainEventArgs<BaseEdmontonForm>(e.SelectedItem));
        }

        public List<FormEdmontonOP14DTO> QueryDtos()
        {
            if (!shouldShowSection)
            {
                return new List<FormEdmontonOP14DTO>();
            }

            List<FormEdmontonOP14DTO> dtos;
            if (userContext.SiteConfiguration.FormsFlocSetType.Equals(FunctionalLocationSetType.WorkPermit) &&
                userContext.HasFlocsForWorkPermits)
            {
                dtos =
                    formService.QueryFormOP14sThatAreApprovedByFunctionalLocations(
                        userContext.RootFlocSetForWorkPermits,
                        Clock.Now.SubtractDays(1));
            }
            else
            {
                dtos = formService.QueryFormOP14sThatAreApprovedByFunctionalLocations(userContext.RootFlocSet,
                    Clock.Now.SubtractDays(1)); 
            }
            
            return dtos;
        }

        public void LoadDtos(List<FormEdmontonOP14DTO> dtos)
        {
            dtos.ForEach(RegisterRenderTimer);
            dtos.RemoveAll(dto => dto.Status == FormStatus.Closed );
            Load(dtos);
        }

        protected override void UnsubscribeToEvents(IRemoteEventRepeater remoteEventRepeater)
        {
            remoteEventRepeater.ServerOP14FormCreated -= HandleRepeaterCreated;
            remoteEventRepeater.ServerOP14FormUpdated -= HandleRepeaterUpdated;
            remoteEventRepeater.ServerOP14FormRemoved -= HandleRepeaterRemoved;
            
            invokeControl.Disposed -= InvokeControlOnDisposed;
        }

        protected override bool IsRelevantItemFromServerEvent(BaseEdmontonForm item)
        {
            if (!(item is FormOP14)) return false;
            return item.FormStatus == FormStatus.Approved ||
                   (item as FormOP14).IsActiveAndRequiresApproval(Clock.Now);
        }

        protected override FormEdmontonOP14DTO GetDto(BaseEdmontonForm item,string ForAddUpdate)      //ayman action item reading
        {
            return (FormEdmontonOP14DTO) item.CreateDTO();
        }

        protected override NodeData GetNodeData(FormEdmontonOP14DTO dto)
        {
//Added By Vibhor : RITM0613645 : OLT - Mark as read tick mark for sarnia CSD

            //var dtos = formService.UserMarkedFormOp14AsRead(dto.IdValue, Convert.ToInt64(ClientSession.GetUserContext().User.Id.Value), Convert.ToInt64(ClientSession.GetUserContext().UserShift.ShiftPatternId));

            var dtos = formService.UserMarkedFormOp14AsReadOnPriorityPage(
                dto.IdValue, Convert.ToInt64(ClientSession.GetUserContext().User.Id.Value),
                Convert.ToInt64(ClientSession.GetUserContext().UserShift.ShiftPatternId),
                Clock.DateNow
                );

            if (dtos.Count > 0 && dtos != null)
            {
                dto.MarkAsReadCSD = true;
            }

            return new FormOP14NodeData(dto);
        }

        private void RegisterRenderTimer(FormEdmontonOP14DTO dto)
        {
            timerManager.Unregister(dto);
            var now = Clock.Now;

            // this will never auto change its grouping
            //if (dto.ValidTo < now) return;

            if (ClientSession.GetUserContext().IsSarniaSite) //Added By Vibhor : RITM0613645 : OLT - Mark as read tick mark for sarnia CSD
            {
                var timeUntilActive = TimeSpan.FromMinutes(userContext.SiteConfiguration.RefreshCSDOnPriorityPage);
                    SetupTimerCallback(timeUntilActive, dto);
            }

            // Below code commented by Vibhor --> //Added By Vibhor : RITM0613645 : OLT - Mark as read tick mark for sarnia CSD

            //if (ClientSession.GetUserContext().IsSarniaSite)   //ayman sarnia timer manager
            //{
            //    if (dto.ValidFrom.AddDays(3) > now)
            //    {
            //        var timeUntilActive = dto.ValidFrom.AddDays(3).Subtract(now);
            //        SetupTimerCallback(timeUntilActive, dto);
            //    }
            //    else
            //    {
            //        var timeUntilRequiresApprovalOrExpires = dto.ValidTo.Subtract(now);
            //        SetupTimerCallback(timeUntilRequiresApprovalOrExpires, dto);
            //    }
            //}
            //else
            //{

            //    if (dto.ValidFrom > now)
            //    {
            //        var timeUntilActive = dto.ValidFrom.Subtract(now);
            //        SetupTimerCallback(timeUntilActive, dto);
            //    }
            //    else
            //    {
            //        var timeUntilRequiresApprovalOrExpires = dto.ValidTo.Subtract(now);
            //        SetupTimerCallback(timeUntilRequiresApprovalOrExpires, dto);
            //    }
            //}

        }

        private void SetupTimerCallback(TimeSpan differenceInTime, FormEdmontonOP14DTO dto)
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
                invokeControl.Invoke(new Action<FormEdmontonOP14DTO>(RefreshItem), dto);
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
                if (!(dto is FormEdmontonOP14DTO)) return;
                var item = (FormEdmontonOP14DTO) dto;
                RegisterRenderTimer(item);
                Remove(item);
                Add(item);
            }
        }

        private class OP14ActiveCSDSectionCriteria : ISubSectionCriteria
        {
            public bool Matches(FormEdmontonOP14DTO dto)
            {
// INC0508116 : CSD Approval behavior chnages -- Added by Vibhor
                if (ClientSession.GetUserContext().IsSarniaSite) //ayman Sarnia
                {
                    if ((Clock.Now < dto.ValidFrom.AddDays(3) || dto.RemainingApprovals.Count == 0) && dto.Status == FormStatus.Approved)
                    {
                        return true;
                    }

                    if (dto.RemainingApprovals.Any(apr => apr.ToString().ToLower().Equals("operations manager")) && (Clock.Now < dto.ValidFrom.AddDays(3)) && dto.Status == FormStatus.Approved)
                    {
                        return true;
                    }

                    if (dto.RemainingApprovals.Any(apr => apr.ToString().Contains(">= 10")) && (Clock.Now < dto.ValidFrom.AddDays(9)) && dto.Status == FormStatus.Approved)
                    {
                        return true;
                    }
                    if (dto.RemainingApprovals.Any(apr => apr.ToString().Contains("> 30")) && (Clock.Now < dto.ValidFrom.AddDays(29) && Clock.Now <= dto.ValidTo) && dto.Status == FormStatus.Approved)
                    {
                        return true;
                    } 
                }
                    
                   // return (Clock.Now < dto.ValidFrom.AddDays(3) || dto.RemainingApprovals.Count == 0) && dto.Status == FormStatus.Approved;

                return dto.ValidTo > Clock.Now && dto.Status == FormStatus.Approved;
            }
        }

        private class OP14ExpiredSectionCriteria : ISubSectionCriteria
        {
            public bool Matches(FormEdmontonOP14DTO dto)
            {
                //ayman generic forms


                return dto.Status == FormStatus.Expired;
            }
        }

        private class OP14RequiredApprovalSectionCriteria : ISubSectionCriteria
        {
            public bool Matches(FormEdmontonOP14DTO dto)
            {
                if (ClientSession.GetUserContext().IsSarniaSite) //ayman Sarnia RITM0162061 
                {
// INC0508116 : CSD Approval behavior chnages -- Added by Vibhor
                    if (dto.RemainingApprovals.Any(apr => apr.ToString().ToLower().Equals("shift supervisor")) && Clock.Now <= dto.ValidTo)
                    {
                        return true;
                    }
                    if (dto.RemainingApprovals.Any(apr => apr.ToString().ToLower().Equals("operations manager")) && (Clock.Now >= dto.ValidFrom.AddDays(3) && Clock.Now <= dto.ValidTo))
                    {
                        return true;
                    }
                    if (dto.RemainingApprovals.Any(apr => apr.ToString().Contains(">= 10")) && (Clock.Now >= dto.ValidFrom.AddDays(9) && Clock.Now <= dto.ValidTo))
                    {
                        return true;
                    }
                    if (dto.RemainingApprovals.Any(apr => apr.ToString().Contains("> 30")) && (Clock.Now >= dto.ValidFrom.AddDays(29) && Clock.Now <= dto.ValidTo))
                    {
                        return true;
                    }


                }
                    //return (Clock.Now > dto.ValidFrom.AddDays(3) && dto.Status == FormStatus.WaitingForApproval) ||
                    //       (Clock.Now <= dto.ValidTo && dto.Status == FormStatus.WaitingForApproval);
                
                
                return dto.ValidTo > Clock.Now && dto.Status == FormStatus.WaitingForApproval; //FormStatus.Draft;   //ayman generic forms ...fixes...
                
            }
        }

       

        
    }
}